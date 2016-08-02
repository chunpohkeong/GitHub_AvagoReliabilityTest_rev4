using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AvagoReliabilityTest
{
    public partial class Calibration_SubForm : Form
    {
        LibPXI Pxi = new LibPXI();
        public double[] CalResult = new double[16];
        public int calCount = 0;
        public List<double> ResultList = new List<double>();
        public Calibration_SubForm()
        {
            InitializeComponent();
        }

        private void _btnCalibration_Click(object sender, EventArgs e)
        {
            CalibrationProcess();
        }

        private void _btnCalNext_Click(object sender, EventArgs e)
        {
            calCount++;
            for (int i = 0; i < 16; i++)
            {
                ResultList.Add(CalResult[i]);
            }

            if (calCount != GlobalVariable.iCalCount)
            {
                if (GlobalVariable.CalForm1)
                    GlobalVariable.CalForm1 = false;
                else if (GlobalVariable.CalForm2)
                    GlobalVariable.CalForm2 = false;
                else if (GlobalVariable.CalForm3)
                    GlobalVariable.CalForm3 = false;
                else if (GlobalVariable.CalForm4)
                    GlobalVariable.CalForm4 = false;
                ChannelDisplayUpdate();
                CalibrationProcess();
            }
            else if (_btnCalNext.Text.Contains("Finish"))
            {
                Pxi.SaveCalibrationData(ResultList);
                this.Close();
                Form1 mainForm = new Form1();
                mainForm.WindowState = FormWindowState.Normal;
            }
        }

        private void CalibrationProcess()
        {
            if (GlobalVariable.CalForm1)
            {
                Pxi.Calibration(Convert.ToDouble(_txtSgInputPower.Text), 1, GlobalVariable.dCalFreq1, ref CalResult);
                for (int i = 0; i < 16; i++)
                {
                    CalResult[i] -= Pxi.CalOffsetList[calCount];
                }
            }
            else if (GlobalVariable.CalForm2)
            {
                Pxi.Calibration(Convert.ToDouble(_txtSgInputPower.Text), 17, GlobalVariable.dCalFreq2, ref CalResult);
                for (int i = 0; i < 16; i++)
                {
                    CalResult[i] -= Pxi.CalOffsetList[calCount];
                }
            }
            else if (GlobalVariable.CalForm3)
            {
                Pxi.Calibration(Convert.ToDouble(_txtSgInputPower.Text), 33, GlobalVariable.dCalFreq3, ref CalResult);
                for (int i = 0; i < 16; i++)
                {
                    CalResult[i] -= Pxi.CalOffsetList[calCount];
                }
            }
            else if (GlobalVariable.CalForm4)
            {
                Pxi.Calibration(Convert.ToDouble(_txtSgInputPower.Text), 49, GlobalVariable.dCalFreq4, ref CalResult);
                for (int i = 0; i < 16; i++)
                {
                    CalResult[i] -= Pxi.CalOffsetList[calCount];
                }
            }

            GlobalVariable.dAmplitude = Convert.ToDouble(_txtSgInputPower.Text);
            #region Result Update
            _txtCalResult1.Text = CalResult[0].ToString();
            _txtCalResult2.Text = CalResult[1].ToString();
            _txtCalResult3.Text = CalResult[2].ToString();
            _txtCalResult4.Text = CalResult[3].ToString();
            _txtCalResult5.Text = CalResult[4].ToString();
            _txtCalResult6.Text = CalResult[5].ToString();
            _txtCalResult7.Text = CalResult[6].ToString();
            _txtCalResult8.Text = CalResult[7].ToString();
            _txtCalResult9.Text = CalResult[8].ToString();
            _txtCalResult10.Text = CalResult[9].ToString();
            _txtCalResult11.Text = CalResult[10].ToString();
            _txtCalResult12.Text = CalResult[11].ToString();
            _txtCalResult13.Text = CalResult[12].ToString();
            _txtCalResult14.Text = CalResult[13].ToString();
            _txtCalResult15.Text = CalResult[14].ToString();
            _txtCalResult16.Text = CalResult[15].ToString();
            #endregion

            _btnCalNext.Enabled = true;
            
            if (calCount == GlobalVariable.iCalCount - 1)
            {
                _btnCalNext.Text = "Finish";
            }
        }
        private void ChannelDisplayUpdate()
        {
            #region Edited by Anthony
            if (GlobalVariable.Cal1To8 && GlobalVariable.CalForm1 == true)
            {
                label1.Text = "Channel 1 :";
                label2.Text = "Channel 2 :";
                label3.Text = "Channel 3 :";
                label4.Text = "Channel 4 :";
                label5.Text = "Channel 5 :";
                label6.Text = "Channel 6 :";
                label7.Text = "Channel 7 :";
                label8.Text = "Channel 8 :";
                label9.Text = "Channel 9 :";
                label10.Text = "Channel 10 :";
                label11.Text = "Channel 11 :";
                label12.Text = "Channel 12 :";
                label13.Text = "Channel 13 :";
                label14.Text = "Channel 14 :";
                label15.Text = "Channel 15 :";
                label16.Text = "Channel 16 :";
            }
            else if (GlobalVariable.Cal17To24 && GlobalVariable.CalForm2 == true)
            {
                label1.Text = "Channel 17 :";
                label2.Text = "Channel 18 :";
                label3.Text = "Channel 19 :";
                label4.Text = "Channel 20 :";
                label5.Text = "Channel 21 :";
                label6.Text = "Channel 22 :";
                label7.Text = "Channel 23 :";
                label8.Text = "Channel 24 :";
                label9.Text = "Channel 25 :";
                label10.Text = "Channel 26 :";
                label11.Text = "Channel 27 :";
                label12.Text = "Channel 28 :";
                label13.Text = "Channel 29 :";
                label14.Text = "Channel 30 :";
                label15.Text = "Channel 31 :";
                label16.Text = "Channel 32 :";
            }
            else if (GlobalVariable.Cal33To40 && GlobalVariable.CalForm3 == true)
            {
                label1.Text = "Channel 33 :";
                label2.Text = "Channel 34 :";
                label3.Text = "Channel 35 :";
                label4.Text = "Channel 36 :";
                label5.Text = "Channel 37 :";
                label6.Text = "Channel 38 :";
                label7.Text = "Channel 39 :";
                label8.Text = "Channel 40 :";
                label9.Text = "Channel 42 :";
                label10.Text = "Channel 42 :";
                label11.Text = "Channel 43 :";
                label12.Text = "Channel 44 :";
                label13.Text = "Channel 45 :";
                label14.Text = "Channel 46 :";
                label15.Text = "Channel 47 :";
                label16.Text = "Channel 48 :";
            }
            else if (GlobalVariable.Cal49To56 && GlobalVariable.CalForm4 == true)
            {
                label1.Text = "Channel 49 :";
                label2.Text = "Channel 50 :";
                label3.Text = "Channel 51 :";
                label4.Text = "Channel 52 :";
                label5.Text = "Channel 53 :";
                label6.Text = "Channel 54 :";
                label7.Text = "Channel 55 :";
                label8.Text = "Channel 56 :";
                label9.Text = "Channel 57 :";
                label10.Text = "Channel 58 :";
                label11.Text = "Channel 59 :";
                label12.Text = "Channel 60 :";
                label13.Text = "Channel 61 :";
                label14.Text = "Channel 62 :";
                label15.Text = "Channel 63 :";
                label16.Text = "Channel 64 :";
            }

            _txtCalResult1.Text = "";
            _txtCalResult2.Text = "";
            _txtCalResult3.Text = "";
            _txtCalResult4.Text = "";
            _txtCalResult5.Text = "";
            _txtCalResult6.Text = "";
            _txtCalResult7.Text = "";
            _txtCalResult8.Text = "";
            _txtCalResult9.Text = "";
            _txtCalResult10.Text = "";
            _txtCalResult11.Text = "";
            _txtCalResult12.Text = "";
            _txtCalResult13.Text = "";
            _txtCalResult14.Text = "";
            _txtCalResult15.Text = "";
            _txtCalResult16.Text = "";
           
            #endregion

        }

        private void Calibration_SubForm_Load(object sender, EventArgs e)
        {
            ChannelDisplayUpdate();
        }
    }
}
