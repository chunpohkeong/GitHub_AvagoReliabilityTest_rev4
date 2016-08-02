using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace AvagoReliabilityTest
{
    public partial class TroubleShootForm : Form
    {
        LibPXI Pxi = new LibPXI();
        public int strNumbTrest;
        ZedGraphControl graph1 = new ZedGraphControl();
        public double [][]TempSaveData = new double [10][];
        public int measurementCount = 1;
        public TroubleShootForm()
        {
            InitializeComponent();
            strNumbTrest = 1;
        }

        private Form1 mainForm = null;
        public TroubleShootForm(Form callMainForm)
        {
            mainForm = callMainForm as Form1;
            InitializeComponent();
            this.panel1.Controls.Add(graph1);
            graph1.Dock = DockStyle.Fill;
         
            measurementCount = 1;
        }

        private void _btnMeasure_Click(object sender, EventArgs e)
        {
            Pxi.SetSwitchPath(GlobalVariable.iTsChannel);
            Pxi.SweepTest();
            Pxi.Result.Add(Pxi.subSweepResult);

            PointPairList result1 = new PointPairList();

            int i1 = 0;
            foreach (double result in Pxi.subSweepResult)
            {
                result1.Add(i1, result);
                i1++;
            }
            LineItem test1 = graph1.GraphPane.AddCurve("", result1, Color.YellowGreen, SymbolType.None);
            graph1.GraphPane.Title.Text = "Channel " + GlobalVariable.iTsChannel;///
            graph1.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
            graph1.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
            graph1.GraphPane.XAxis.Scale.Max = 402;///
            graph1.IsAutoScrollRange = true;
            graph1.AxisChange();
            graph1.Invalidate();
            SaveData();
            Pxi.subSweepResult.Clear();
        }

        private void _btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            mainForm.Enabled = true;
        }

        private void TroubleShootForm_Load(object sender, EventArgs e)
        {

        }


        public void SaveData()
        {
            #region SaveData
            StringBuilder sb = new StringBuilder();
            string folderName = @"C:\RealibilityTest\";
            string fileName = "Result_TroubleShoot_" + GlobalVariable.iTsChannel.ToString() + ".csv";
            bool folderExist = System.IO.Directory.Exists(folderName);
            if (!folderExist)
            {
                System.IO.Directory.CreateDirectory(folderName);
            }

            bool fileExist = System.IO.File.Exists(folderName + fileName);

            sb.Append("Test_" + GlobalVariable.numTest.ToString()).Append(",");
            foreach (double tempResult in Pxi.subSweepResult)
            {
                sb.Append(tempResult).Append(",");
            }
            sb.Append("\n");

            if (fileExist)
            {
                System.IO.File.AppendAllText(folderName + fileName, sb.ToString()); //Anthony
            }
            else
            {
                System.IO.File.WriteAllText(folderName + fileName, sb.ToString()); //Anthony
            }

            sb = null;
            #endregion
        }
    }
}
