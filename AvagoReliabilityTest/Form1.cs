using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using ZedGraph;

namespace AvagoReliabilityTest
{
    public partial class Form1 : Form
    {
        public LibPXI LibPXI = new LibPXI();
        public string DTime;
        public System.Windows.Forms.Timer cdTimer = new System.Windows.Forms.Timer();
        public int  TimeCounter;
        public bool timerStop  ;
        public int  channel = 1;
        int second = 0;
        int minute    ;
        int hour      ;
        int i         ;
        int start_counter           = 0;
        int SaveDataSetting_counter = 0;
        string[] Sg_Unit = new string[] { "VSG1", "VSG2", "VSG3", "VSG4" };

        int channelDisplay;
        private bool _btnInitWasClicked  = false;
        private bool _btnStartWasClicked = false;
        private bool _btnAbortWasClicked = false;
        public  bool updateDisplay       = false;
        public  bool stresstestpowon     = false;
        public  bool stresstestpowoff    = false;
        public  bool Performancetest     = false;
        public  bool test_setting_file   = false;

        public string FileDate = "";

        #region ZedGraph Init
        ZedGraphControl graph1  = new ZedGraphControl();
        ZedGraphControl graph2  = new ZedGraphControl();
        ZedGraphControl graph3  = new ZedGraphControl();
        ZedGraphControl graph4  = new ZedGraphControl();
        ZedGraphControl graph5  = new ZedGraphControl();
        ZedGraphControl graph6  = new ZedGraphControl();
        ZedGraphControl graph7  = new ZedGraphControl();
        ZedGraphControl graph8  = new ZedGraphControl();
        ZedGraphControl graph9  = new ZedGraphControl();
        ZedGraphControl graph10 = new ZedGraphControl();
        ZedGraphControl graph11 = new ZedGraphControl();
        ZedGraphControl graph12 = new ZedGraphControl();
        ZedGraphControl graph13 = new ZedGraphControl();
        ZedGraphControl graph14 = new ZedGraphControl();
        ZedGraphControl graph15 = new ZedGraphControl();
        ZedGraphControl graph16 = new ZedGraphControl();
        ZedGraphControl graph17 = new ZedGraphControl();
        ZedGraphControl graph18 = new ZedGraphControl();
        ZedGraphControl graph19 = new ZedGraphControl();
        ZedGraphControl graph20 = new ZedGraphControl();
        ZedGraphControl graph21 = new ZedGraphControl();
        ZedGraphControl graph22 = new ZedGraphControl();
        ZedGraphControl graph23 = new ZedGraphControl();
        ZedGraphControl graph24 = new ZedGraphControl();
        ZedGraphControl graph25 = new ZedGraphControl();
        ZedGraphControl graph26 = new ZedGraphControl();
        ZedGraphControl graph27 = new ZedGraphControl();
        ZedGraphControl graph28 = new ZedGraphControl();
        ZedGraphControl graph29 = new ZedGraphControl();
        ZedGraphControl graph30 = new ZedGraphControl();
        ZedGraphControl graph31 = new ZedGraphControl();
        ZedGraphControl graph32 = new ZedGraphControl();
        ZedGraphControl graph33 = new ZedGraphControl();
        ZedGraphControl graph34 = new ZedGraphControl();
        ZedGraphControl graph35 = new ZedGraphControl();
        ZedGraphControl graph36 = new ZedGraphControl();
        ZedGraphControl graph37 = new ZedGraphControl();
        ZedGraphControl graph38 = new ZedGraphControl();
        ZedGraphControl graph39 = new ZedGraphControl();
        ZedGraphControl graph40 = new ZedGraphControl();
        ZedGraphControl graph41 = new ZedGraphControl();
        ZedGraphControl graph42 = new ZedGraphControl();
        ZedGraphControl graph43 = new ZedGraphControl();
        ZedGraphControl graph44 = new ZedGraphControl();
        ZedGraphControl graph45 = new ZedGraphControl();
        ZedGraphControl graph46 = new ZedGraphControl();
        ZedGraphControl graph47 = new ZedGraphControl();
        ZedGraphControl graph48 = new ZedGraphControl();
        ZedGraphControl graph49 = new ZedGraphControl();
        ZedGraphControl graph50 = new ZedGraphControl();
        ZedGraphControl graph51 = new ZedGraphControl();
        ZedGraphControl graph52 = new ZedGraphControl();
        ZedGraphControl graph53 = new ZedGraphControl();
        ZedGraphControl graph54 = new ZedGraphControl();
        ZedGraphControl graph55 = new ZedGraphControl();
        ZedGraphControl graph56 = new ZedGraphControl();
        ZedGraphControl graph57 = new ZedGraphControl();
        ZedGraphControl graph58 = new ZedGraphControl();
        ZedGraphControl graph59 = new ZedGraphControl();
        ZedGraphControl graph60 = new ZedGraphControl();
        ZedGraphControl graph61 = new ZedGraphControl();
        ZedGraphControl graph62 = new ZedGraphControl();
        ZedGraphControl graph63 = new ZedGraphControl();
        ZedGraphControl graph64 = new ZedGraphControl();
        #endregion

        public Form1()
        {
            InitializeComponent();
            InitializeGraph();

            //check if datasetting file exist
            bool testsettingfile_Exist = System.IO.File.Exists(@"C:\ReliabilityTest\Datasetting_folder\Datasetting_file.txt");
            
            //read all lines inside datasetting file 
           if (testsettingfile_Exist == true)
                {
                    string[] test_setting = System.IO.File.ReadAllLines(@"C:\ReliabilityTest\Datasetting_folder\Datasetting_file.txt");
                    if (test_setting[0]  != "" && test_setting[1]  != "" && test_setting[2]  != "" && test_setting[3]  != "" && test_setting[4] != ""
                     && test_setting[5]  != "" && test_setting[6]  != "" && test_setting[7]  != "" && test_setting[8]  != "" && test_setting[9] != ""
                     && test_setting[10] != "" && test_setting[11] != "" && test_setting[12] != "" && test_setting[13] != "")
                    {
                            //load texts from datasetting file into every setting text boxes(0-13)
                            _txtBIInterval.Text     = test_setting[0];
                            _txtBurnInDuration.Text = test_setting[1];

                            _txtStartFreq1.Text     = test_setting[2];
                            _txtStartFreq2.Text     = test_setting[3];
                            _txtStartFreq3.Text     = test_setting[4];
                            _txtStartFreq4.Text     = test_setting[5];

                            _txtStopFreq1.Text      = test_setting[6];
                            _txtStopFreq2.Text      = test_setting[7];
                            _txtStopFreq3.Text      = test_setting[8];
                            _txtStopFreq4.Text      = test_setting[9];

                            _txtStressFreq1MHz.Text = test_setting[10];
                            _txtStressFreq2MHz.Text = test_setting[11];
                            _txtStressFreq3MHz.Text = test_setting[12];
                            _txtStressFreq4MHz.Text = test_setting[13];
                    }
                }
        }

        public void InitializeGraph()
        {
            #region initgraph
            this.panel1.Controls.Add(graph1);
            graph1.Dock = DockStyle.Fill;
            this.panel2.Controls.Add(graph2);
            graph2.Dock = DockStyle.Fill;
            this.panel3.Controls.Add(graph3);
            graph3.Dock = DockStyle.Fill;
            this.panel4.Controls.Add(graph4);
            graph4.Dock = DockStyle.Fill;
            this.panel5.Controls.Add(graph5);
            graph5.Dock = DockStyle.Fill;
            this.panel6.Controls.Add(graph6);
            graph6.Dock = DockStyle.Fill;
            this.panel7.Controls.Add(graph7);
            graph7.Dock = DockStyle.Fill;
            this.panel8.Controls.Add(graph8);
            graph8.Dock = DockStyle.Fill;
            this.panel9.Controls.Add(graph9);
            graph9.Dock = DockStyle.Fill;
            this.panel10.Controls.Add(graph10);
            graph10.Dock = DockStyle.Fill;
            this.panel11.Controls.Add(graph11);
            graph11.Dock = DockStyle.Fill;
            this.panel12.Controls.Add(graph12);
            graph12.Dock = DockStyle.Fill;
            this.panel13.Controls.Add(graph13);
            graph13.Dock = DockStyle.Fill;
            this.panel14.Controls.Add(graph14);
            graph14.Dock = DockStyle.Fill;
            this.panel15.Controls.Add(graph15);
            graph15.Dock = DockStyle.Fill;
            this.panel16.Controls.Add(graph16);
            graph16.Dock = DockStyle.Fill;
            this.panel17.Controls.Add(graph17);
            graph17.Dock = DockStyle.Fill;
            this.panel18.Controls.Add(graph18);
            graph18.Dock = DockStyle.Fill;
            this.panel19.Controls.Add(graph19);
            graph19.Dock = DockStyle.Fill;
            this.panel20.Controls.Add(graph20);
            graph20.Dock = DockStyle.Fill;
            this.panel21.Controls.Add(graph21);
            graph21.Dock = DockStyle.Fill;
            this.panel22.Controls.Add(graph22);
            graph22.Dock = DockStyle.Fill;
            this.panel23.Controls.Add(graph23);
            graph23.Dock = DockStyle.Fill;
            this.panel24.Controls.Add(graph24);
            graph24.Dock = DockStyle.Fill;
            this.panel25.Controls.Add(graph25);
            graph25.Dock = DockStyle.Fill;
            this.panel26.Controls.Add(graph26);
            graph26.Dock = DockStyle.Fill;
            this.panel27.Controls.Add(graph27);
            graph27.Dock = DockStyle.Fill;
            this.panel28.Controls.Add(graph28);
            graph28.Dock = DockStyle.Fill;
            this.panel29.Controls.Add(graph29);
            graph29.Dock = DockStyle.Fill;
            this.panel30.Controls.Add(graph30);
            graph30.Dock = DockStyle.Fill;
            this.panel31.Controls.Add(graph31);
            graph31.Dock = DockStyle.Fill;
            this.panel32.Controls.Add(graph32);
            graph32.Dock = DockStyle.Fill;
            this.panel33.Controls.Add(graph33);
            graph33.Dock = DockStyle.Fill;
            this.panel34.Controls.Add(graph34);
            graph34.Dock = DockStyle.Fill;
            this.panel35.Controls.Add(graph35);
            graph35.Dock = DockStyle.Fill;
            this.panel36.Controls.Add(graph36);
            graph36.Dock = DockStyle.Fill;
            this.panel37.Controls.Add(graph37);
            graph37.Dock = DockStyle.Fill;
            this.panel38.Controls.Add(graph38);
            graph38.Dock = DockStyle.Fill;
            this.panel39.Controls.Add(graph39);
            graph39.Dock = DockStyle.Fill;
            this.panel40.Controls.Add(graph40);
            graph40.Dock = DockStyle.Fill;
            this.panel41.Controls.Add(graph41);
            graph41.Dock = DockStyle.Fill;
            this.panel42.Controls.Add(graph42);
            graph42.Dock = DockStyle.Fill;
            this.panel43.Controls.Add(graph43);
            graph43.Dock = DockStyle.Fill;
            this.panel44.Controls.Add(graph44);
            graph44.Dock = DockStyle.Fill;
            this.panel45.Controls.Add(graph45);
            graph45.Dock = DockStyle.Fill;
            this.panel46.Controls.Add(graph46);
            graph46.Dock = DockStyle.Fill;
            this.panel47.Controls.Add(graph47);
            graph47.Dock = DockStyle.Fill;
            this.panel48.Controls.Add(graph48);
            graph48.Dock = DockStyle.Fill;
            this.panel49.Controls.Add(graph49);
            graph49.Dock = DockStyle.Fill;
            this.panel50.Controls.Add(graph50);
            graph50.Dock = DockStyle.Fill;
            this.panel51.Controls.Add(graph51);
            graph51.Dock = DockStyle.Fill;
            this.panel52.Controls.Add(graph52);
            graph52.Dock = DockStyle.Fill;
            this.panel53.Controls.Add(graph53);
            graph53.Dock = DockStyle.Fill;
            this.panel54.Controls.Add(graph54);
            graph54.Dock = DockStyle.Fill;
            this.panel55.Controls.Add(graph55);
            graph55.Dock = DockStyle.Fill;
            this.panel56.Controls.Add(graph56);
            graph56.Dock = DockStyle.Fill;
            this.panel57.Controls.Add(graph57);
            graph57.Dock = DockStyle.Fill;
            this.panel58.Controls.Add(graph58);
            graph58.Dock = DockStyle.Fill;
            this.panel59.Controls.Add(graph59);
            graph59.Dock = DockStyle.Fill;
            this.panel60.Controls.Add(graph60);
            graph60.Dock = DockStyle.Fill;
            this.panel61.Controls.Add(graph61);
            graph61.Dock = DockStyle.Fill;
            this.panel62.Controls.Add(graph62);
            graph62.Dock = DockStyle.Fill;
            this.panel63.Controls.Add(graph63);
            graph63.Dock = DockStyle.Fill;
            this.panel64.Controls.Add(graph64);
            graph64.Dock = DockStyle.Fill;
            #endregion
        }

        private void _btnInit_Click(object sender, EventArgs e)
        {
            _btnInitWasClicked = true;
            bool excelLoading  = false;
            GlobalVariable.fileDateSet = false;
            GlobalVariable.numTest = 1;
            
            if (!excelLoading)
            {
                GlobalVariable.SweepAmplitude = new double[] { -20, -20, -20, -20 };
                GlobalVariable.StressAmp      = new double[] {   0,   0,   0,   0 };
                GlobalVariable.StartSweepFreq = new double[4];
                GlobalVariable.StopSweepFreq  = new double[4];
                GlobalVariable.StressFreq     = new double[4];

                LibPXI.Instrument_Init();

                GlobalVariable.bRunTest = false;
                _btnInit.Visible        = false;
                _btntestrun.Visible     = true;
                _btnStart.Visible       = true;
                _btnAbort.Visible       = true;
                _btnClear.Visible       = false;
                _btnCalibration.Visible = true;
                _btnExit.Visible        = true;
                ChannelButtonEnabled(true);
            }
            GlobalVariable.numTest  = 1;
            DateTime date           = DateTime.Now;
            GlobalVariable.abortSet = false;
        }

        private void _btntestrun_Click(object sender, EventArgs e)
        {
            _btntestrun.Visible = true;
            _btnStart.Visible = true;
            _btnClear.Visible = true;
            _btnAbort.Visible = true;
            _btnCalibration.Visible = true;

            DialogResult dialogResult = MessageBox.Show("Are you going to perform test run? Please click OK to test run, Cancel to clear charts then continue program", "Test run", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                GlobalVariable.bRunTest = true;
                GlobalVariable.isStop = false;
                GlobalVariable.iTsChannel = 1;

                //clear subsweep result before testrun
                for (int i = 0; i < 64; i++)
                {
                    ChannelButtonEnabled(false);
                    switch (GlobalVariable.iTsChannel.ToString())
                    {
                        #region case 1-16
                        case "1":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "2":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "3":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "4":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "5":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "6":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "7":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "8":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "9":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "10":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "11":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "12":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "13":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "14":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "15":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "16":
                            LibPXI.subSweepResult.Clear();
                            break;
                        #endregion
                        #region case 17-32
                        case "17":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "18":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "19":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "20":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "21":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "22":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "23":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "24":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "25":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "26":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "27":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "28":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "29":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "30":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "31":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "32":
                            LibPXI.subSweepResult.Clear();
                            break;
                        #endregion
                        #region case 33-48
                        case "33":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "34":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "35":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "36":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "37":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "38":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "39":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "40":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "41":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "42":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "43":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "44":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "45":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "46":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "47":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "48":
                            LibPXI.subSweepResult.Clear();
                            break;
                        #endregion
                        #region case 48-64
                        case "49":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "50":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "51":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "52":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "53":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "54":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "55":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "56":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "57":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "58":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "59":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "60":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "61":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "62":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "63":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "64":
                            LibPXI.subSweepResult.Clear();
                            break;
                        #endregion
                        default:
                            MessageBox.Show("Didn't have this Channel", "Error", MessageBoxButtons.OK);
                            break;
                    }
                }
                #region clear
                graph1.GraphPane.CurveList.Clear();
                graph2.GraphPane.CurveList.Clear();
                graph3.GraphPane.CurveList.Clear();
                graph4.GraphPane.CurveList.Clear();
                graph5.GraphPane.CurveList.Clear();
                graph6.GraphPane.CurveList.Clear();
                graph7.GraphPane.CurveList.Clear();
                graph8.GraphPane.CurveList.Clear();
                graph9.GraphPane.CurveList.Clear();
                graph10.GraphPane.CurveList.Clear();

                graph11.GraphPane.CurveList.Clear();
                graph12.GraphPane.CurveList.Clear();
                graph13.GraphPane.CurveList.Clear();
                graph14.GraphPane.CurveList.Clear();
                graph15.GraphPane.CurveList.Clear();
                graph16.GraphPane.CurveList.Clear();
                graph17.GraphPane.CurveList.Clear();
                graph18.GraphPane.CurveList.Clear();
                graph19.GraphPane.CurveList.Clear();
                graph20.GraphPane.CurveList.Clear();

                graph21.GraphPane.CurveList.Clear();
                graph22.GraphPane.CurveList.Clear();
                graph23.GraphPane.CurveList.Clear();
                graph24.GraphPane.CurveList.Clear();
                graph25.GraphPane.CurveList.Clear();
                graph26.GraphPane.CurveList.Clear();
                graph27.GraphPane.CurveList.Clear();
                graph28.GraphPane.CurveList.Clear();
                graph29.GraphPane.CurveList.Clear();
                graph30.GraphPane.CurveList.Clear();

                graph31.GraphPane.CurveList.Clear();
                graph32.GraphPane.CurveList.Clear();
                graph33.GraphPane.CurveList.Clear();
                graph34.GraphPane.CurveList.Clear();
                graph35.GraphPane.CurveList.Clear();
                graph36.GraphPane.CurveList.Clear();
                graph37.GraphPane.CurveList.Clear();
                graph38.GraphPane.CurveList.Clear();
                graph39.GraphPane.CurveList.Clear();
                graph40.GraphPane.CurveList.Clear();

                graph41.GraphPane.CurveList.Clear();
                graph42.GraphPane.CurveList.Clear();
                graph43.GraphPane.CurveList.Clear();
                graph44.GraphPane.CurveList.Clear();
                graph45.GraphPane.CurveList.Clear();
                graph46.GraphPane.CurveList.Clear();
                graph47.GraphPane.CurveList.Clear();
                graph48.GraphPane.CurveList.Clear();
                graph49.GraphPane.CurveList.Clear();
                graph50.GraphPane.CurveList.Clear();

                graph51.GraphPane.CurveList.Clear();
                graph52.GraphPane.CurveList.Clear();
                graph53.GraphPane.CurveList.Clear();
                graph54.GraphPane.CurveList.Clear();
                graph55.GraphPane.CurveList.Clear();
                graph56.GraphPane.CurveList.Clear();
                graph57.GraphPane.CurveList.Clear();
                graph58.GraphPane.CurveList.Clear();
                graph59.GraphPane.CurveList.Clear();
                graph60.GraphPane.CurveList.Clear();

                graph61.GraphPane.CurveList.Clear();
                graph62.GraphPane.CurveList.Clear();
                graph63.GraphPane.CurveList.Clear();
                graph64.GraphPane.CurveList.Clear();
                #endregion
                #region graphs refresh
                graph1.Refresh();
                graph2.Refresh();
                graph3.Refresh();
                graph4.Refresh();
                graph5.Refresh();
                graph6.Refresh();
                graph7.Refresh();
                graph8.Refresh();
                graph9.Refresh();
                graph10.Refresh();
                graph11.Refresh();
                graph12.Refresh();
                graph13.Refresh();
                graph14.Refresh();
                graph15.Refresh();
                graph16.Refresh();
                graph17.Refresh();
                graph18.Refresh();
                graph19.Refresh();
                graph20.Refresh();
                graph21.Refresh();
                graph22.Refresh();
                graph23.Refresh();
                graph24.Refresh();
                graph25.Refresh();
                graph26.Refresh();
                graph27.Refresh();
                graph28.Refresh();
                graph29.Refresh();
                graph30.Refresh();
                graph31.Refresh();
                graph32.Refresh();
                graph33.Refresh();
                graph34.Refresh();
                graph35.Refresh();
                graph36.Refresh();
                graph37.Refresh();
                graph38.Refresh();
                graph39.Refresh();
                graph40.Refresh();
                graph41.Refresh();
                graph42.Refresh();
                graph43.Refresh();
                graph44.Refresh();
                graph45.Refresh();
                graph46.Refresh();
                graph47.Refresh();
                graph48.Refresh();
                graph49.Refresh();
                graph50.Refresh();
                graph51.Refresh();
                graph52.Refresh();
                graph53.Refresh();
                graph54.Refresh();
                graph55.Refresh();
                graph56.Refresh();
                graph57.Refresh();
                graph58.Refresh();
                graph59.Refresh();
                graph60.Refresh();
                graph61.Refresh();
                graph62.Refresh();
                graph63.Refresh();
                graph64.Refresh();
                #endregion

                GlobalVariable.bRunTest = true;
                GlobalVariable.isStop = false;
                GlobalVariable.iTsChannel = 1;

                //capture subsweep result when testrun 
                for (int i = 0; i < 64; i++)
                {
                    ChannelButtonEnabled(false);
                    LibPXI.SweepTest();
                    switch (GlobalVariable.iTsChannel.ToString())
                    {
                        #region case1-16
                        case "1":
                            #region Channel 1
                            #region New Graph method
                            PointPairList result1 = new PointPairList();

                            int i1 = 0;
                            foreach (double tempResult in LibPXI.subSweepResult)
                            {
                                result1.Add(i1, tempResult);
                                i1++;
                            }
                            LineItem test1 = graph1.GraphPane.AddCurve("", result1, Color.YellowGreen, SymbolType.None);
                            graph1.GraphPane.Title.Text = "Channel 01";
                            graph1.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                            graph1.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                            graph1.GraphPane.XAxis.Scale.Max = 402;
                            graph1.IsAutoScrollRange = true;
                            graph1.AxisChange();
                            graph1.Invalidate();
                            #endregion
                            #endregion
                            break;
                        case "2":
                            #region Channel 2
                            #region New Graph method
                            PointPairList result2 = new PointPairList();
                            int i2 = 0;
                            foreach (double tempResult in LibPXI.subSweepResult)
                            {
                                result2.Add(i2, tempResult);
                                i2++;
                            }
                            LineItem test2 = graph2.GraphPane.AddCurve("", result2, Color.YellowGreen, SymbolType.None);
                            graph2.GraphPane.Title.Text = "Channel 02";
                            graph2.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                            graph2.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                            graph2.GraphPane.XAxis.Scale.Max = 402;
                            graph2.IsAutoScrollRange = true;
                            graph2.AxisChange();
                            graph2.Invalidate();
                            #endregion
                            #endregion
                            break;
                        case "3":
                            #region Channel 3
                            #region New Graph method
                            PointPairList result3 = new PointPairList();
                            int i3 = 0;
                            foreach (double tempResult in LibPXI.subSweepResult)
                            {
                                result3.Add(i3, tempResult);
                                i3++;
                            }
                            LineItem test3 = graph3.GraphPane.AddCurve("", result3, Color.YellowGreen, SymbolType.None);
                            graph3.GraphPane.Title.Text = "Channel 03";
                            graph3.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                            graph3.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                            graph3.GraphPane.XAxis.Scale.Max = 402;
                            graph3.IsAutoScrollRange = true;
                            graph3.AxisChange();
                            graph3.Invalidate();
                            #endregion
                            #endregion
                            break;
                        case "4":
                            #region Channel 4
                            #region New Graph method
                            PointPairList result4 = new PointPairList();
                            int i4 = 0;
                            foreach (double tempResult in LibPXI.subSweepResult)
                            {
                                result4.Add(i4, tempResult);
                                i4++;
                            }
                            LineItem test4 = graph4.GraphPane.AddCurve("", result4, Color.YellowGreen, SymbolType.None);
                            graph4.GraphPane.Title.Text = "Channel 04";
                            graph4.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                            graph4.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                            graph4.GraphPane.XAxis.Scale.Max = 402;
                            graph4.IsAutoScrollRange = true;
                            graph4.AxisChange();
                            graph4.Invalidate();
                            #endregion
                            #endregion
                            break;
                        case "5":
                            #region Channel 5
                            #region New Graph method
                            PointPairList result5 = new PointPairList();
                            int i5 = 0;
                            foreach (double tempResult in LibPXI.subSweepResult)
                            {
                                result5.Add(i5, tempResult);
                                i5++;
                            }
                            LineItem test5 = graph5.GraphPane.AddCurve("", result5, Color.YellowGreen, SymbolType.None);
                            graph5.GraphPane.Title.Text = "Channel 05";
                            graph5.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                            graph5.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                            graph5.GraphPane.XAxis.Scale.Max = 402;
                            graph5.IsAutoScrollRange = true;
                            graph5.AxisChange();
                            graph5.Invalidate();
                            #endregion
                            #endregion
                            break;
                        case "6":
                            #region Channel 6
                            #region New Graph method
                            PointPairList result6 = new PointPairList();
                            int i6 = 0;
                            foreach (double tempResult in LibPXI.subSweepResult)
                            {
                                result6.Add(i6, tempResult);
                                i6++;
                            }
                            LineItem test6 = graph6.GraphPane.AddCurve("", result6, Color.YellowGreen, SymbolType.None);
                            graph6.GraphPane.Title.Text = "Channel 06";
                            graph6.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                            graph6.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                            graph6.GraphPane.XAxis.Scale.Max = 402;
                            graph6.IsAutoScrollRange = true;
                            graph6.AxisChange();
                            graph6.Invalidate();
                            #endregion
                            #endregion
                            break;
                        case "7":
                            #region Channel 7
                            #region New Graph method
                            PointPairList result7 = new PointPairList();
                            int i7 = 0;
                            foreach (double tempResult in LibPXI.subSweepResult)
                            {
                                result7.Add(i7, tempResult);
                                i7++;
                            }
                            LineItem test7 = graph7.GraphPane.AddCurve("", result7, Color.YellowGreen, SymbolType.None);
                            graph7.GraphPane.Title.Text = "Channel 07";
                            graph7.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                            graph7.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                            graph7.GraphPane.XAxis.Scale.Max = 402;
                            graph7.IsAutoScrollRange = true;
                            graph7.AxisChange();
                            graph7.Invalidate();
                            #endregion
                            #endregion
                            break;
                        case "8":
                            #region Channel 8
                            #region New Graph method
                            PointPairList result8 = new PointPairList();
                            int i8 = 0;
                            foreach (double tempResult in LibPXI.subSweepResult)
                            {
                                result8.Add(i8, tempResult);
                                i8++;
                            }
                            LineItem test8 = graph8.GraphPane.AddCurve("", result8, Color.YellowGreen, SymbolType.None);
                            graph8.GraphPane.Title.Text = "Channel 08";
                            graph8.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                            graph8.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                            graph8.GraphPane.XAxis.Scale.Max = 402;
                            graph8.IsAutoScrollRange = true;
                            graph8.AxisChange();
                            graph8.Invalidate();
                            #endregion
                            #endregion
                            break;
                        case "9":
                            #region Channel 9
                            #region New Graph method
                            PointPairList result9 = new PointPairList();
                            int i9 = 0;
                            foreach (double tempResult in LibPXI.subSweepResult)
                            {
                                result9.Add(i9, tempResult);
                                i9++;
                            }
                            LineItem test9 = graph9.GraphPane.AddCurve("", result9, Color.YellowGreen, SymbolType.None);
                            graph9.GraphPane.Title.Text = "Channel 09";
                            graph9.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                            graph9.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                            graph9.GraphPane.XAxis.Scale.Max = 402;
                            graph9.IsAutoScrollRange = true;
                            graph9.AxisChange();
                            graph9.Invalidate();
                            #endregion
                            #endregion
                            break;
                        case "10":
                            #region Channel 10
                            #region New Graph method
                            PointPairList result10 = new PointPairList();
                            int i10 = 0;
                            foreach (double tempResult in LibPXI.subSweepResult)
                            {
                                result10.Add(i10, tempResult);
                                i10++;
                            }
                            LineItem test10 = graph10.GraphPane.AddCurve("", result10, Color.YellowGreen, SymbolType.None);
                            graph10.GraphPane.Title.Text = "Channel 10";
                            graph10.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                            graph10.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                            graph10.GraphPane.XAxis.Scale.Max = 402;
                            graph10.IsAutoScrollRange = true;
                            graph10.AxisChange();
                            graph10.Invalidate();
                            #endregion
                            #endregion
                            break;
                        case "11":
                            #region Channel 11
                            #region New Graph method
                            PointPairList result11 = new PointPairList();
                            int i11 = 0;
                            foreach (double tempResult in LibPXI.subSweepResult)
                            {
                                result11.Add(i11, tempResult);
                                i11++;
                            }
                            LineItem test11 = graph11.GraphPane.AddCurve("", result11, Color.YellowGreen, SymbolType.None);
                            graph11.GraphPane.Title.Text = "Channel 11";
                            graph11.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                            graph11.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                            graph11.GraphPane.XAxis.Scale.Max = 402;
                            graph11.IsAutoScrollRange = true;
                            graph11.AxisChange();
                            graph11.Invalidate();
                            #endregion
                            #endregion
                            break;
                        case "12":
                            #region Channel 12
                            #region New Graph method
                            PointPairList result12 = new PointPairList();
                            int i12 = 0;
                            foreach (double tempResult in LibPXI.subSweepResult)
                            {
                                result12.Add(i12, tempResult);
                                i12++;
                            }
                            LineItem test12 = graph12.GraphPane.AddCurve("", result12, Color.YellowGreen, SymbolType.None);
                            graph12.GraphPane.Title.Text = "Channel 12";
                            graph12.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                            graph12.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                            graph12.GraphPane.XAxis.Scale.Max = 402;
                            graph12.IsAutoScrollRange = true;
                            graph12.AxisChange();
                            graph12.Invalidate();
                            #endregion
                            #endregion
                            break;
                        case "13":
                            #region Channel 13
                            #region New Graph method
                            PointPairList result13 = new PointPairList();
                            int i13 = 0;
                            foreach (double tempResult in LibPXI.subSweepResult)
                            {
                                result13.Add(i13, tempResult);
                                i13++;
                            }
                            LineItem test13 = graph13.GraphPane.AddCurve("", result13, Color.YellowGreen, SymbolType.None);
                            graph13.GraphPane.Title.Text = "Channel 13";
                            graph13.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                            graph13.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                            graph13.GraphPane.XAxis.Scale.Max = 402;
                            graph13.IsAutoScrollRange = true;
                            graph13.AxisChange();
                            graph13.Invalidate();
                            #endregion
                            #endregion
                            break;
                        case "14":
                            #region Channel 14
                            #region New Graph method
                            PointPairList result14 = new PointPairList();
                            int i14 = 0;
                            foreach (double tempResult in LibPXI.subSweepResult)
                            {
                                result14.Add(i14, tempResult);
                                i14++;
                            }
                            LineItem test14 = graph14.GraphPane.AddCurve("", result14, Color.YellowGreen, SymbolType.None);
                            graph14.GraphPane.Title.Text = "Channel 14";
                            graph14.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                            graph14.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                            graph14.GraphPane.XAxis.Scale.Max = 402;
                            graph14.IsAutoScrollRange = true;
                            graph14.AxisChange();
                            graph14.Invalidate();
                            #endregion
                            #endregion
                            break;
                        case "15":
                            #region Channel 15
                            #region New Graph method
                            PointPairList result15 = new PointPairList();
                            int i15 = 0;
                            foreach (double tempResult in LibPXI.subSweepResult)
                            {
                                result15.Add(i15, tempResult);
                                i15++;
                            }
                            LineItem test15 = graph15.GraphPane.AddCurve("", result15, Color.YellowGreen, SymbolType.None);
                            graph15.GraphPane.Title.Text = "Channel 15";
                            graph15.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                            graph15.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                            graph15.GraphPane.XAxis.Scale.Max = 402;
                            graph15.IsAutoScrollRange = true;
                            graph15.AxisChange();
                            graph15.Invalidate();
                            #endregion
                            #endregion
                            break;
                        case "16":
                            #region Channel 16
                            #region New Graph method
                            PointPairList result16 = new PointPairList();
                            int i16 = 0;
                            foreach (double tempResult in LibPXI.subSweepResult)
                            {
                                result16.Add(i16, tempResult);
                                i16++;
                            }
                            LineItem test16 = graph16.GraphPane.AddCurve("", result16, Color.YellowGreen, SymbolType.None);
                            graph16.GraphPane.Title.Text = "Channel 16";
                            graph16.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                            graph16.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                            graph16.GraphPane.XAxis.Scale.Max = 402;
                            graph16.IsAutoScrollRange = true;
                            graph16.AxisChange();
                            graph16.Invalidate();
                            #endregion
                            #endregion
                            break;
                        #endregion
                        #region case17-32
                        case "17":
                            #region Channel 17
                            #region New Graph method
                            PointPairList result17 = new PointPairList();
                            int i17 = 0;
                            foreach (double tempResult in LibPXI.subSweepResult)
                            {
                                result17.Add(i17, tempResult);
                                i17++;
                            }
                            LineItem test17 = graph17.GraphPane.AddCurve("", result17, Color.YellowGreen, SymbolType.None);
                            graph17.GraphPane.Title.Text = "Channel 17";
                            graph17.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                            graph17.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                            graph17.GraphPane.XAxis.Scale.Max = 402;
                            graph17.IsAutoScrollRange = true;
                            graph17.AxisChange();
                            graph17.Invalidate();
                            #endregion
                            #endregion
                            break;
                        case "18":
                            #region Channel 18
                            #region New Graph method
                            PointPairList result18 = new PointPairList();
                            int i18 = 0;
                            foreach (double tempResult in LibPXI.subSweepResult)
                            {
                                result18.Add(i18, tempResult);
                                i18++;
                            }
                            LineItem test18 = graph18.GraphPane.AddCurve("", result18, Color.YellowGreen, SymbolType.None);
                            graph18.GraphPane.Title.Text = "Channel 18";
                            graph18.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                            graph18.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                            graph18.GraphPane.XAxis.Scale.Max = 402;
                            graph18.IsAutoScrollRange = true;
                            graph18.AxisChange();
                            graph18.Invalidate();
                            #endregion
                            #endregion
                            break;
                        case "19":
                            #region Channel 19
                            #region New Graph method
                            PointPairList result19 = new PointPairList();
                            int i19 = 0;
                            foreach (double tempResult in LibPXI.subSweepResult)
                            {
                                result19.Add(i19, tempResult);
                                i19++;
                            }
                            LineItem test19 = graph19.GraphPane.AddCurve("", result19, Color.YellowGreen, SymbolType.None);
                            graph19.GraphPane.Title.Text = "Channel 19";
                            graph19.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                            graph19.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                            graph19.GraphPane.XAxis.Scale.Max = 402;
                            graph19.IsAutoScrollRange = true;
                            graph19.AxisChange();
                            graph19.Invalidate();
                            #endregion
                            #endregion
                            break;
                        case "20":
                            #region Channel 20
                            #region New Graph method
                            PointPairList result20 = new PointPairList();
                            int i20 = 0;
                            foreach (double tempResult in LibPXI.subSweepResult)
                            {
                                result20.Add(i20, tempResult);
                                i20++;
                            }
                            LineItem test20 = graph20.GraphPane.AddCurve("", result20, Color.YellowGreen, SymbolType.None);
                            graph20.GraphPane.Title.Text = "Channel 20";
                            graph20.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                            graph20.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                            graph20.GraphPane.XAxis.Scale.Max = 402;
                            graph20.IsAutoScrollRange = true;
                            graph20.AxisChange();
                            graph20.Invalidate();
                            #endregion
                            #endregion
                            break;
                        case "21":
                            #region Channel 21
                            #region New Graph method
                            PointPairList result21 = new PointPairList();
                            int i21 = 0;
                            foreach (double tempResult in LibPXI.subSweepResult)
                            {
                                result21.Add(i21, tempResult);
                                i21++;
                            }
                            LineItem test21 = graph21.GraphPane.AddCurve("", result21, Color.YellowGreen, SymbolType.None);
                            graph21.GraphPane.Title.Text = "Channel 21";
                            graph21.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                            graph21.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                            graph21.GraphPane.XAxis.Scale.Max = 402;
                            graph21.IsAutoScrollRange = true;
                            graph21.AxisChange();
                            graph21.Invalidate();
                            #endregion

                            #endregion
                            break;
                        case "22":
                            #region Channel 22
                            #region New Graph method
                            PointPairList result22 = new PointPairList();
                            int i22 = 0;
                            foreach (double tempResult in LibPXI.subSweepResult)
                            {
                                result22.Add(i22, tempResult);
                                i22++;
                            }
                            LineItem test22 = graph22.GraphPane.AddCurve("", result22, Color.YellowGreen, SymbolType.None);
                            graph22.GraphPane.Title.Text = "Channel 22";
                            graph22.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                            graph22.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                            graph22.GraphPane.XAxis.Scale.Max = 402;
                            graph22.IsAutoScrollRange = true;
                            graph22.AxisChange();
                            graph22.Invalidate();
                            #endregion

                            #endregion
                            break;
                        case "23":
                            #region Channel 23
                            #region New Graph method
                            PointPairList result23 = new PointPairList();
                            int i23 = 0;
                            foreach (double tempResult in LibPXI.subSweepResult)
                            {
                                result23.Add(i23, tempResult);
                                i23++;
                            }
                            LineItem test23 = graph23.GraphPane.AddCurve("", result23, Color.YellowGreen, SymbolType.None);
                            graph23.GraphPane.Title.Text = "Channel 23";
                            graph23.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                            graph23.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                            graph23.GraphPane.XAxis.Scale.Max = 402;
                            graph23.IsAutoScrollRange = true;
                            graph23.AxisChange();
                            graph23.Invalidate();
                            #endregion
                            #endregion
                            break;
                        case "24":
                            #region Channel 24
                            #region New Graph method
                            PointPairList result24 = new PointPairList();
                            int i24 = 0;
                            foreach (double tempResult in LibPXI.subSweepResult)
                            {
                                result24.Add(i24, tempResult);
                                i24++;
                            }
                            LineItem test24 = graph24.GraphPane.AddCurve("", result24, Color.YellowGreen, SymbolType.None);
                            graph24.GraphPane.Title.Text = "Channel 24";
                            graph24.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                            graph24.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                            graph24.GraphPane.XAxis.Scale.Max = 402;
                            graph24.IsAutoScrollRange = true;
                            graph24.AxisChange();
                            graph24.Invalidate();
                            #endregion
                            #endregion
                            break;
                        case "25":
                            #region Channel 25
                            #region New Graph method
                            PointPairList result25 = new PointPairList();
                            int i25 = 0;
                            foreach (double tempResult in LibPXI.subSweepResult)
                            {
                                result25.Add(i25, tempResult);
                                i25++;
                            }
                            LineItem test25 = graph25.GraphPane.AddCurve("", result25, Color.YellowGreen, SymbolType.None);
                            graph25.GraphPane.Title.Text = "Channel 25";
                            graph25.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                            graph25.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                            graph25.GraphPane.XAxis.Scale.Max = 402;
                            graph25.IsAutoScrollRange = true;
                            graph25.AxisChange();
                            graph25.Invalidate();
                            #endregion
                            #endregion
                            break;
                        case "26":
                            #region Channel 26
                            #region New Graph method
                            PointPairList result26 = new PointPairList();
                            int i26 = 0;
                            foreach (double tempResult in LibPXI.subSweepResult)
                            {
                                result26.Add(i26, tempResult);
                                i26++;
                            }
                            LineItem test26 = graph26.GraphPane.AddCurve("", result26, Color.YellowGreen, SymbolType.None);
                            graph26.GraphPane.Title.Text = "Channel 26";
                            graph26.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                            graph26.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                            graph26.GraphPane.XAxis.Scale.Max = 402;
                            graph26.IsAutoScrollRange = true;
                            graph26.AxisChange();
                            graph26.Invalidate();
                            #endregion
                            #endregion
                            break;
                        case "27":
                            #region Channel 27
                            #region New Graph method
                            PointPairList result27 = new PointPairList();
                            int i27 = 0;
                            foreach (double tempResult in LibPXI.subSweepResult)
                            {
                                result27.Add(i27, tempResult);
                                i27++;
                            }
                            LineItem test27 = graph27.GraphPane.AddCurve("", result27, Color.YellowGreen, SymbolType.None);
                            graph27.GraphPane.Title.Text = "Channel 27";
                            graph27.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                            graph27.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                            graph27.GraphPane.XAxis.Scale.Max = 402;
                            graph27.IsAutoScrollRange = true;
                            graph27.AxisChange();
                            graph27.Invalidate();
                            #endregion
                            #endregion
                            break;
                        case "28":
                            #region Channel 28
                            #region New Graph method
                            PointPairList result28 = new PointPairList();
                            int i28 = 0;
                            foreach (double tempResult in LibPXI.subSweepResult)
                            {
                                result28.Add(i28, tempResult);
                                i28++;
                            }
                            LineItem test28 = graph28.GraphPane.AddCurve("", result28, Color.YellowGreen, SymbolType.None);
                            graph28.GraphPane.Title.Text = "Channel 28";
                            graph28.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                            graph28.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                            graph28.GraphPane.XAxis.Scale.Max = 402;
                            graph28.IsAutoScrollRange = true;
                            graph28.AxisChange();
                            graph28.Invalidate();
                            #endregion
                            #endregion
                            break;
                        case "29":
                            #region Channel 29
                            #region New Graph method
                            PointPairList result29 = new PointPairList();
                            int i29 = 0;
                            foreach (double tempResult in LibPXI.subSweepResult)
                            {
                                result29.Add(i29, tempResult);
                                i29++;
                            }
                            LineItem test29 = graph29.GraphPane.AddCurve("", result29, Color.YellowGreen, SymbolType.None);
                            graph29.GraphPane.Title.Text = "Channel 29";
                            graph29.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                            graph29.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                            graph29.GraphPane.XAxis.Scale.Max = 402;
                            graph29.IsAutoScrollRange = true;
                            graph29.AxisChange();
                            graph29.Invalidate();
                            #endregion
                            #endregion
                            break;
                        case "30":
                            #region Channel 30
                            #region New Graph method
                            PointPairList result30 = new PointPairList();
                            int i30 = 0;
                            foreach (double tempResult in LibPXI.subSweepResult)
                            {
                                result30.Add(i30, tempResult);
                                i30++;
                            }
                            LineItem test30 = graph30.GraphPane.AddCurve("", result30, Color.YellowGreen, SymbolType.None);
                            graph30.GraphPane.Title.Text = "Channel 30";
                            graph30.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                            graph30.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                            graph30.GraphPane.XAxis.Scale.Max = 402;
                            graph30.IsAutoScrollRange = true;
                            graph30.AxisChange();
                            graph30.Invalidate();
                            #endregion
                            #endregion
                            break;
                        case "31":
                            #region Channel 31
                            #region New Graph method
                            PointPairList result31 = new PointPairList();
                            int i31 = 0;
                            foreach (double tempResult in LibPXI.subSweepResult)
                            {
                                result31.Add(i31, tempResult);
                                i31++;
                            }
                            LineItem test31 = graph31.GraphPane.AddCurve("", result31, Color.YellowGreen, SymbolType.None);
                            graph31.GraphPane.Title.Text = "Channel 31";
                            graph31.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                            graph31.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                            graph31.GraphPane.XAxis.Scale.Max = 402;
                            graph31.IsAutoScrollRange = true;
                            graph31.AxisChange();
                            graph31.Invalidate();
                            #endregion

                            #endregion
                            break;
                        case "32":
                            #region Channel 32
                            #region New Graph method
                            PointPairList result32 = new PointPairList();
                            int i32 = 0;
                            foreach (double tempResult in LibPXI.subSweepResult)
                            {
                                result32.Add(i32, tempResult);
                                i32++;
                            }
                            LineItem test32 = graph32.GraphPane.AddCurve("", result32, Color.YellowGreen, SymbolType.None);
                            graph32.GraphPane.Title.Text = "Channel 32";
                            graph32.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                            graph32.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                            graph32.GraphPane.XAxis.Scale.Max = 402;
                            graph32.IsAutoScrollRange = true;
                            graph32.AxisChange();
                            graph32.Invalidate();
                            #endregion

                            #endregion
                            break;
                        #endregion
                        #region case33-48
                        case "33":
                            #region Channel 33
                            #region New Graph method
                            PointPairList result33 = new PointPairList();
                            int i33 = 0;
                            foreach (double tempResult in LibPXI.subSweepResult)
                            {
                                result33.Add(i33, tempResult);
                                i33++;
                            }
                            LineItem test33 = graph33.GraphPane.AddCurve("", result33, Color.YellowGreen, SymbolType.None);
                            graph33.GraphPane.Title.Text = "Channel 33";
                            graph33.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                            graph33.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                            graph33.GraphPane.XAxis.Scale.Max = 402;
                            graph33.IsAutoScrollRange = true;
                            graph33.AxisChange();
                            graph33.Invalidate();
                            #endregion
                            #endregion
                            break;
                        case "34":
                            #region Channel 34
                            #region New Graph method
                            PointPairList result34 = new PointPairList();
                            int i34 = 0;
                            foreach (double tempResult in LibPXI.subSweepResult)
                            {
                                result34.Add(i34, tempResult);
                                i34++;
                            }
                            LineItem test34 = graph34.GraphPane.AddCurve("", result34, Color.YellowGreen, SymbolType.None);
                            graph34.GraphPane.Title.Text = "Channel 34";
                            graph34.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                            graph34.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                            graph34.GraphPane.XAxis.Scale.Max = 402;
                            graph34.IsAutoScrollRange = true;
                            graph34.AxisChange();
                            graph34.Invalidate();
                            #endregion
                            #endregion
                            break;
                        case "35":
                            #region Channel 35
                            #region New Graph method
                            PointPairList result35 = new PointPairList();
                            int i35 = 0;
                            foreach (double tempResult in LibPXI.subSweepResult)
                            {
                                result35.Add(i35, tempResult);
                                i35++;
                            }
                            LineItem test35 = graph35.GraphPane.AddCurve("", result35, Color.YellowGreen, SymbolType.None);
                            graph35.GraphPane.Title.Text = "Channel 35";
                            graph35.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                            graph35.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                            graph35.GraphPane.XAxis.Scale.Max = 402;
                            graph35.IsAutoScrollRange = true;
                            graph35.AxisChange();
                            graph35.Invalidate();
                            #endregion
                            #endregion
                            break;
                        case "36":
                            #region Channel 36
                            #region New Graph method
                            PointPairList result36 = new PointPairList();
                            int i36 = 0;
                            foreach (double tempResult in LibPXI.subSweepResult)
                            {
                                result36.Add(i36, tempResult);
                                i36++;
                            }
                            LineItem test36 = graph36.GraphPane.AddCurve("", result36, Color.YellowGreen, SymbolType.None);
                            graph36.GraphPane.Title.Text = "Channel 36";
                            graph36.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                            graph36.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                            graph36.GraphPane.XAxis.Scale.Max = 402;
                            graph36.IsAutoScrollRange = true;
                            graph36.AxisChange();
                            graph36.Invalidate();
                            #endregion
                            #endregion
                            break;
                        case "37":
                            #region Channel 37
                            #region New Graph method
                            PointPairList result37 = new PointPairList();
                            int i37 = 0;
                            foreach (double tempResult in LibPXI.subSweepResult)
                            {
                                result37.Add(i37, tempResult);
                                i37++;
                            }
                            LineItem test37 = graph37.GraphPane.AddCurve("", result37, Color.YellowGreen, SymbolType.None);
                            graph37.GraphPane.Title.Text = "Channel 37";
                            graph37.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                            graph37.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                            graph37.GraphPane.XAxis.Scale.Max = 402;
                            graph37.IsAutoScrollRange = true;
                            graph37.AxisChange();
                            graph37.Invalidate();
                            #endregion
                            #endregion
                            break;
                        case "38":
                            #region Channel 38
                            #region New Graph method
                            PointPairList result38 = new PointPairList();
                            int i38 = 0;
                            foreach (double tempResult in LibPXI.subSweepResult)
                            {
                                result38.Add(i38, tempResult);
                                i38++;
                            }
                            LineItem test38 = graph38.GraphPane.AddCurve("", result38, Color.YellowGreen, SymbolType.None);
                            graph38.GraphPane.Title.Text = "Channel 38";
                            graph38.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                            graph38.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                            graph38.GraphPane.XAxis.Scale.Max = 402;
                            graph38.IsAutoScrollRange = true;
                            graph38.AxisChange();
                            graph38.Invalidate();
                            #endregion
                            #endregion
                            break;
                        case "39":
                            #region Channel 39
                            #region New Graph method
                            PointPairList result39 = new PointPairList();
                            int i39 = 0;
                            foreach (double tempResult in LibPXI.subSweepResult)
                            {
                                result39.Add(i39, tempResult);
                                i39++;
                            }
                            LineItem test39 = graph39.GraphPane.AddCurve("", result39, Color.YellowGreen, SymbolType.None);
                            graph39.GraphPane.Title.Text = "Channel 39";
                            graph39.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                            graph39.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                            graph39.GraphPane.XAxis.Scale.Max = 402;
                            graph39.IsAutoScrollRange = true;
                            graph39.AxisChange();
                            graph39.Invalidate();
                            #endregion
                            #endregion
                            break;
                        case "40":
                            #region Channel 40
                            #region New Graph method
                            PointPairList result40 = new PointPairList();
                            int i40 = 0;
                            foreach (double tempResult in LibPXI.subSweepResult)
                            {
                                result40.Add(i40, tempResult);
                                i40++;
                            }
                            LineItem test40 = graph40.GraphPane.AddCurve("", result40, Color.YellowGreen, SymbolType.None);
                            graph40.GraphPane.Title.Text = "Channel 40";
                            graph40.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                            graph40.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                            graph40.GraphPane.XAxis.Scale.Max = 402;
                            graph40.IsAutoScrollRange = true;
                            graph40.AxisChange();
                            graph40.Invalidate();
                            #endregion
                            #endregion
                            break;
                        case "41":
                            #region Channel 41
                            #region New Graph method
                            PointPairList result41 = new PointPairList();
                            int i41 = 0;
                            foreach (double tempResult in LibPXI.subSweepResult)
                            {
                                result41.Add(i41, tempResult);
                                i41++;
                            }
                            LineItem test41 = graph41.GraphPane.AddCurve("", result41, Color.YellowGreen, SymbolType.None);
                            graph41.GraphPane.Title.Text = "Channel 41";
                            graph41.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                            graph41.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                            graph41.GraphPane.XAxis.Scale.Max = 402;
                            graph41.IsAutoScrollRange = true;
                            graph41.AxisChange();
                            graph41.Invalidate();
                            #endregion

                            #endregion
                            break;
                        case "42":
                            #region Channel 42
                            #region New Graph method
                            PointPairList result42 = new PointPairList();
                            int i42 = 0;
                            foreach (double tempResult in LibPXI.subSweepResult)
                            {
                                result42.Add(i42, tempResult);
                                i42++;
                            }
                            LineItem test42 = graph42.GraphPane.AddCurve("", result42, Color.YellowGreen, SymbolType.None);
                            graph42.GraphPane.Title.Text = "Channel 42";
                            graph42.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                            graph42.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                            graph42.GraphPane.XAxis.Scale.Max = 402;
                            graph42.IsAutoScrollRange = true;
                            graph42.AxisChange();
                            graph42.Invalidate();
                            #endregion

                            #endregion
                            break;
                        case "43":
                            #region Channel 43
                            #region New Graph method
                            PointPairList result43 = new PointPairList();
                            int i43 = 0;
                            foreach (double tempResult in LibPXI.subSweepResult)
                            {
                                result43.Add(i43, tempResult);
                                i43++;
                            }
                            LineItem test43 = graph43.GraphPane.AddCurve("", result43, Color.YellowGreen, SymbolType.None);
                            graph43.GraphPane.Title.Text = "Channel 43";
                            graph43.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                            graph43.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                            graph43.GraphPane.XAxis.Scale.Max = 402;
                            graph43.IsAutoScrollRange = true;
                            graph43.AxisChange();
                            graph43.Invalidate();
                            #endregion
                            #endregion
                            break;
                        case "44":
                            #region Channel 44
                            #region New Graph method
                            PointPairList result44 = new PointPairList();
                            int i44 = 0;
                            foreach (double tempResult in LibPXI.subSweepResult)
                            {
                                result44.Add(i44, tempResult);
                                i44++;
                            }
                            LineItem test44 = graph44.GraphPane.AddCurve("", result44, Color.YellowGreen, SymbolType.None);
                            graph44.GraphPane.Title.Text = "Channel 44";
                            graph44.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                            graph44.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                            graph44.GraphPane.XAxis.Scale.Max = 402;
                            graph44.IsAutoScrollRange = true;
                            graph44.AxisChange();
                            graph44.Invalidate();
                            #endregion
                            #endregion
                            break;
                        case "45":
                            #region Channel 45
                            #region New Graph method
                            PointPairList result45 = new PointPairList();
                            int i45 = 0;
                            foreach (double tempResult in LibPXI.subSweepResult)
                            {
                                result45.Add(i45, tempResult);
                                i45++;
                            }
                            LineItem test45 = graph45.GraphPane.AddCurve("", result45, Color.YellowGreen, SymbolType.None);
                            graph45.GraphPane.Title.Text = "Channel 45";
                            graph45.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                            graph45.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                            graph45.GraphPane.XAxis.Scale.Max = 402;
                            graph45.IsAutoScrollRange = true;
                            graph45.AxisChange();
                            graph45.Invalidate();
                            #endregion
                            #endregion
                            break;
                        case "46":
                            #region Channel 46
                            #region New Graph method
                            PointPairList result46 = new PointPairList();
                            int i46 = 0;
                            foreach (double tempResult in LibPXI.subSweepResult)
                            {
                                result46.Add(i46, tempResult);
                                i46++;
                            }
                            LineItem test46 = graph46.GraphPane.AddCurve("", result46, Color.YellowGreen, SymbolType.None);
                            graph46.GraphPane.Title.Text = "Channel 46";
                            graph46.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                            graph46.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                            graph46.GraphPane.XAxis.Scale.Max = 402;
                            graph46.IsAutoScrollRange = true;
                            graph46.AxisChange();
                            graph46.Invalidate();
                            #endregion
                            #endregion
                            break;
                        case "47":
                            #region Channel 47
                            #region New Graph method
                            PointPairList result47 = new PointPairList();
                            int i47 = 0;
                            foreach (double tempResult in LibPXI.subSweepResult)
                            {
                                result47.Add(i47, tempResult);
                                i47++;
                            }
                            LineItem test47 = graph47.GraphPane.AddCurve("", result47, Color.YellowGreen, SymbolType.None);
                            graph47.GraphPane.Title.Text = "Channel 47";
                            graph47.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                            graph47.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                            graph47.GraphPane.XAxis.Scale.Max = 402;
                            graph47.IsAutoScrollRange = true;
                            graph47.AxisChange();
                            graph47.Invalidate();
                            #endregion
                            #endregion
                            break;
                        case "48":
                            #region Channel 48
                            #region New Graph method
                            PointPairList result48 = new PointPairList();
                            int i48 = 0;
                            foreach (double tempResult in LibPXI.subSweepResult)
                            {
                                result48.Add(i48, tempResult);
                                i48++;
                            }
                            LineItem test48 = graph48.GraphPane.AddCurve("", result48, Color.YellowGreen, SymbolType.None);
                            graph48.GraphPane.Title.Text = "Channel 48";
                            graph48.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                            graph48.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                            graph48.GraphPane.XAxis.Scale.Max = 402;
                            graph48.IsAutoScrollRange = true;
                            graph48.AxisChange();
                            graph48.Invalidate();
                            #endregion
                            #endregion
                            break;
                        #endregion
                        #region case49-64
                        case "49":
                            #region Channel 49
                            #region New Graph method
                            PointPairList result49 = new PointPairList();
                            int i49 = 0;
                            foreach (double tempResult in LibPXI.subSweepResult)
                            {
                                result49.Add(i49, tempResult);
                                i49++;
                            }
                            LineItem test49 = graph49.GraphPane.AddCurve("", result49, Color.YellowGreen, SymbolType.None);
                            graph49.GraphPane.Title.Text = "Channel 49";
                            graph49.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                            graph49.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                            graph49.GraphPane.XAxis.Scale.Max = 402;
                            graph49.IsAutoScrollRange = true;
                            graph49.AxisChange();
                            graph49.Invalidate();
                            #endregion
                            #endregion
                            break;
                        case "50":
                            #region Channel 50
                            #region New Graph method
                            PointPairList result50 = new PointPairList();
                            int i50 = 0;
                            foreach (double tempResult in LibPXI.subSweepResult)
                            {
                                result50.Add(i50, tempResult);
                                i50++;
                            }
                            LineItem test50 = graph50.GraphPane.AddCurve("", result50, Color.YellowGreen, SymbolType.None);
                            graph50.GraphPane.Title.Text = "Channel 50";
                            graph50.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                            graph50.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                            graph50.GraphPane.XAxis.Scale.Max = 402;
                            graph50.IsAutoScrollRange = true;
                            graph50.AxisChange();
                            graph10.Invalidate();
                            #endregion
                            #endregion
                            break;
                        case "51":
                            #region Channel 51
                            #region New Graph method
                            PointPairList result51 = new PointPairList();
                            int i51 = 0;
                            foreach (double tempResult in LibPXI.subSweepResult)
                            {
                                result51.Add(i51, tempResult);
                                i51++;
                            }
                            LineItem test51 = graph51.GraphPane.AddCurve("", result51, Color.YellowGreen, SymbolType.None);
                            graph51.GraphPane.Title.Text = "Channel 51";
                            graph51.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                            graph51.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                            graph51.GraphPane.XAxis.Scale.Max = 402;
                            graph51.IsAutoScrollRange = true;
                            graph51.AxisChange();
                            graph51.Invalidate();
                            #endregion

                            #endregion
                            break;
                        case "52":
                            #region Channel 52
                            #region New Graph method
                            PointPairList result52 = new PointPairList();
                            int i52 = 0;
                            foreach (double tempResult in LibPXI.subSweepResult)
                            {
                                result52.Add(i52, tempResult);
                                i52++;
                            }
                            LineItem test52 = graph52.GraphPane.AddCurve("", result52, Color.YellowGreen, SymbolType.None);
                            graph52.GraphPane.Title.Text = "Channel 52";
                            graph52.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                            graph52.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                            graph52.GraphPane.XAxis.Scale.Max = 402;
                            graph52.IsAutoScrollRange = true;
                            graph52.AxisChange();
                            graph52.Invalidate();
                            #endregion

                            #endregion
                            break;
                        case "53":
                            #region Channel 53
                            #region New Graph method
                            PointPairList result53 = new PointPairList();
                            int i53 = 0;
                            foreach (double tempResult in LibPXI.subSweepResult)
                            {
                                result53.Add(i53, tempResult);
                                i53++;
                            }
                            LineItem test53 = graph53.GraphPane.AddCurve("", result53, Color.YellowGreen, SymbolType.None);
                            graph53.GraphPane.Title.Text = "Channel 53";
                            graph53.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                            graph53.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                            graph53.GraphPane.XAxis.Scale.Max = 402;
                            graph53.IsAutoScrollRange = true;
                            graph53.AxisChange();
                            graph53.Invalidate();
                            #endregion
                            #endregion
                            break;
                        case "54":
                            #region Channel 54
                            #region New Graph method
                            PointPairList result54 = new PointPairList();
                            int i54 = 0;
                            foreach (double tempResult in LibPXI.subSweepResult)
                            {
                                result54.Add(i54, tempResult);
                                i54++;
                            }
                            LineItem test54 = graph54.GraphPane.AddCurve("", result54, Color.YellowGreen, SymbolType.None);
                            graph54.GraphPane.Title.Text = "Channel 54";
                            graph54.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                            graph54.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                            graph54.GraphPane.XAxis.Scale.Max = 402;
                            graph54.IsAutoScrollRange = true;
                            graph54.AxisChange();
                            graph54.Invalidate();
                            #endregion
                            #endregion
                            break;
                        case "55":
                            #region Channel 55
                            #region New Graph method
                            PointPairList result55 = new PointPairList();
                            int i55 = 0;
                            foreach (double tempResult in LibPXI.subSweepResult)
                            {
                                result55.Add(i55, tempResult);
                                i55++;
                            }
                            LineItem test55 = graph55.GraphPane.AddCurve("", result55, Color.YellowGreen, SymbolType.None);
                            graph55.GraphPane.Title.Text = "Channel 55";
                            graph55.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                            graph55.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                            graph55.GraphPane.XAxis.Scale.Max = 402;
                            graph55.IsAutoScrollRange = true;
                            graph55.AxisChange();
                            graph55.Invalidate();
                            #endregion
                            #endregion
                            break;
                        case "56":
                            #region Channel 56
                            #region New Graph method
                            PointPairList result56 = new PointPairList();
                            int i56 = 0;
                            foreach (double tempResult in LibPXI.subSweepResult)
                            {
                                result56.Add(i56, tempResult);
                                i56++;
                            }
                            LineItem test56 = graph56.GraphPane.AddCurve("", result56, Color.YellowGreen, SymbolType.None);
                            graph56.GraphPane.Title.Text = "Channel 56";
                            graph56.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                            graph56.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                            graph56.GraphPane.XAxis.Scale.Max = 402;
                            graph56.IsAutoScrollRange = true;
                            graph56.AxisChange();
                            graph56.Invalidate();
                            #endregion
                            #endregion
                            break;
                        case "57":
                            #region Channel 57
                            #region New Graph method
                            PointPairList result57 = new PointPairList();
                            int i57 = 0;
                            foreach (double tempResult in LibPXI.subSweepResult)
                            {
                                result57.Add(i57, tempResult);
                                i57++;
                            }
                            LineItem test57 = graph57.GraphPane.AddCurve("", result57, Color.YellowGreen, SymbolType.None);
                            graph57.GraphPane.Title.Text = "Channel 57";
                            graph57.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                            graph57.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                            graph57.GraphPane.XAxis.Scale.Max = 402;
                            graph57.IsAutoScrollRange = true;
                            graph57.AxisChange();
                            graph57.Invalidate();
                            #endregion
                            #endregion
                            break;
                        case "58":
                            #region Channel 58
                            #region New Graph method
                            PointPairList result58 = new PointPairList();
                            int i58 = 0;
                            foreach (double tempResult in LibPXI.subSweepResult)
                            {
                                result58.Add(i58, tempResult);
                                i58++;
                            }
                            LineItem test58 = graph58.GraphPane.AddCurve("", result58, Color.YellowGreen, SymbolType.None);
                            graph58.GraphPane.Title.Text = "Channel 58";
                            graph58.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                            graph58.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                            graph58.GraphPane.XAxis.Scale.Max = 402;
                            graph58.IsAutoScrollRange = true;
                            graph58.AxisChange();
                            graph58.Invalidate();
                            #endregion
                            #endregion
                            break;
                        case "59":
                            #region Channel 59
                            #region New Graph method
                            PointPairList result59 = new PointPairList();
                            int i59 = 0;
                            foreach (double tempResult in LibPXI.subSweepResult)
                            {
                                result59.Add(i59, tempResult);
                                i59++;
                            }
                            LineItem test59 = graph59.GraphPane.AddCurve("", result59, Color.YellowGreen, SymbolType.None);
                            graph59.GraphPane.Title.Text = "Channel 59";
                            graph59.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                            graph59.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                            graph59.GraphPane.XAxis.Scale.Max = 402;
                            graph59.IsAutoScrollRange = true;
                            graph59.AxisChange();
                            graph59.Invalidate();
                            #endregion
                            #endregion
                            break;
                        case "60":
                            #region Channel 60
                            #region New Graph method
                            PointPairList result60 = new PointPairList();
                            int i60 = 0;
                            foreach (double tempResult in LibPXI.subSweepResult)
                            {
                                result60.Add(i60, tempResult);
                                i60++;
                            }
                            LineItem test60 = graph60.GraphPane.AddCurve("", result60, Color.YellowGreen, SymbolType.None);
                            graph60.GraphPane.Title.Text = "Channel 60";
                            graph60.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                            graph60.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                            graph60.GraphPane.XAxis.Scale.Max = 402;
                            graph60.IsAutoScrollRange = true;
                            graph60.AxisChange();
                            graph60.Invalidate();
                            #endregion
                            #endregion
                            break;
                        case "61":
                            #region Channel 61
                            #region New Graph method
                            PointPairList result61 = new PointPairList();
                            int i61 = 0;
                            foreach (double tempResult in LibPXI.subSweepResult)
                            {
                                result61.Add(i61, tempResult);
                                i61++;
                            }
                            LineItem test61 = graph61.GraphPane.AddCurve("", result61, Color.YellowGreen, SymbolType.None);
                            graph61.GraphPane.Title.Text = "Channel 61";
                            graph61.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                            graph61.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                            graph61.GraphPane.XAxis.Scale.Max = 402;
                            graph61.IsAutoScrollRange = true;
                            graph61.AxisChange();
                            graph61.Invalidate();
                            #endregion

                            #endregion
                            break;
                        case "62":
                            #region Channel 62
                            #region New Graph method
                            PointPairList result62 = new PointPairList();
                            int i62 = 0;
                            foreach (double tempResult in LibPXI.subSweepResult)
                            {
                                result62.Add(i62, tempResult);
                                i62++;
                            }
                            LineItem test62 = graph62.GraphPane.AddCurve("", result62, Color.YellowGreen, SymbolType.None);
                            graph62.GraphPane.Title.Text = "Channel 62";
                            graph62.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                            graph62.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                            graph62.GraphPane.XAxis.Scale.Max = 402;
                            graph62.IsAutoScrollRange = true;
                            graph62.AxisChange();
                            graph62.Invalidate();
                            #endregion

                            #endregion
                            break;
                        case "63":
                            #region Channel 63
                            #region New Graph method
                            PointPairList result63 = new PointPairList();
                            int i63 = 0;
                            foreach (double tempResult in LibPXI.subSweepResult)
                            {
                                result63.Add(i63, tempResult);
                                i63++;
                            }
                            LineItem test63 = graph63.GraphPane.AddCurve("", result63, Color.YellowGreen, SymbolType.None);
                            graph63.GraphPane.Title.Text = "Channel 63";
                            graph63.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                            graph63.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                            graph63.GraphPane.XAxis.Scale.Max = 402;
                            graph63.IsAutoScrollRange = true;
                            graph63.AxisChange();
                            graph63.Invalidate();
                            #endregion
                            #endregion
                            break;
                        case "64":
                            #region Channel 64
                            #region New Graph method
                            PointPairList result64 = new PointPairList();
                            int i64 = 0;
                            foreach (double tempResult in LibPXI.subSweepResult)
                            {
                                result64.Add(i64, tempResult);
                                i64++;
                            }
                            LineItem test64 = graph64.GraphPane.AddCurve("", result64, Color.YellowGreen, SymbolType.None);
                            graph64.GraphPane.Title.Text = "Channel 64";
                            graph64.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                            graph64.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                            graph64.GraphPane.XAxis.Scale.Max = 402;
                            graph64.IsAutoScrollRange = true;
                            graph64.AxisChange();
                            graph64.Invalidate();
                            //bool stresstestpowon = true;
                            #endregion
                            #endregion
                            break;
                        #endregion
                        default:
                            MessageBox.Show("Didn't have this Channel", "Error", MessageBoxButtons.OK);
                            break;
                    }
                    UpdateChannelDisplay();
                    GlobalVariable.iTsChannel++;
                }
            }
            else if (dialogResult == DialogResult.Cancel)
            {
                GlobalVariable.bRunTest = true;
                GlobalVariable.isStop = false;
                GlobalVariable.iTsChannel = 1;

                for (int i = 0; i < 64; i++)
                {
                    ChannelButtonEnabled(false);
                    //clear sub sweep result
                    #region clear sub sweep result
                    switch (GlobalVariable.iTsChannel.ToString())
                    {
                        #region case 1-16
                        case "1":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "2":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "3":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "4":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "5":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "6":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "7":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "8":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "9":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "10":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "11":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "12":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "13":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "14":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "15":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "16":
                            LibPXI.subSweepResult.Clear();
                            break;
                        #endregion
                        #region case 17-32
                        case "17":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "18":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "19":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "20":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "21":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "22":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "23":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "24":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "25":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "26":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "27":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "28":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "29":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "30":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "31":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "32":
                            LibPXI.subSweepResult.Clear();
                            break;
                        #endregion
                        #region case 33-48
                        case "33":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "34":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "35":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "36":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "37":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "38":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "39":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "40":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "41":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "42":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "43":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "44":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "45":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "46":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "47":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "48":
                            LibPXI.subSweepResult.Clear();
                            break;
                        #endregion
                        #region case 48-64
                        case "49":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "50":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "51":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "52":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "53":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "54":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "55":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "56":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "57":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "58":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "59":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "60":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "61":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "62":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "63":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "64":
                            LibPXI.subSweepResult.Clear();
                            break;
                        #endregion
                        default:
                            MessageBox.Show("Didn't have this Channel", "Error", MessageBoxButtons.OK);
                            break;
                    }
                    #endregion
                }
                #region graphs clear
                #region graph1-16
                graph1.GraphPane.CurveList.Clear();
                graph2.GraphPane.CurveList.Clear();
                graph3.GraphPane.CurveList.Clear();
                graph4.GraphPane.CurveList.Clear();
                graph5.GraphPane.CurveList.Clear();
                graph6.GraphPane.CurveList.Clear();
                graph7.GraphPane.CurveList.Clear();
                graph8.GraphPane.CurveList.Clear();
                graph9.GraphPane.CurveList.Clear();
                graph10.GraphPane.CurveList.Clear();
                graph11.GraphPane.CurveList.Clear();
                graph12.GraphPane.CurveList.Clear();
                graph13.GraphPane.CurveList.Clear();
                graph14.GraphPane.CurveList.Clear();
                graph15.GraphPane.CurveList.Clear();
                graph16.GraphPane.CurveList.Clear();
                #endregion
                #region graph17-32
                graph17.GraphPane.CurveList.Clear();
                graph18.GraphPane.CurveList.Clear();
                graph19.GraphPane.CurveList.Clear();
                graph20.GraphPane.CurveList.Clear();
                graph21.GraphPane.CurveList.Clear();
                graph22.GraphPane.CurveList.Clear();
                graph23.GraphPane.CurveList.Clear();
                graph24.GraphPane.CurveList.Clear();
                graph25.GraphPane.CurveList.Clear();
                graph26.GraphPane.CurveList.Clear();
                graph27.GraphPane.CurveList.Clear();
                graph28.GraphPane.CurveList.Clear();
                graph29.GraphPane.CurveList.Clear();
                graph30.GraphPane.CurveList.Clear();
                graph31.GraphPane.CurveList.Clear();
                graph32.GraphPane.CurveList.Clear();
                #endregion
                #region graph33-48
                graph33.GraphPane.CurveList.Clear();
                graph34.GraphPane.CurveList.Clear();
                graph35.GraphPane.CurveList.Clear();
                graph36.GraphPane.CurveList.Clear();
                graph37.GraphPane.CurveList.Clear();
                graph38.GraphPane.CurveList.Clear();
                graph39.GraphPane.CurveList.Clear();
                graph40.GraphPane.CurveList.Clear();
                graph41.GraphPane.CurveList.Clear();
                graph42.GraphPane.CurveList.Clear();
                graph43.GraphPane.CurveList.Clear();
                graph44.GraphPane.CurveList.Clear();
                graph45.GraphPane.CurveList.Clear();
                graph46.GraphPane.CurveList.Clear();
                graph47.GraphPane.CurveList.Clear();
                graph48.GraphPane.CurveList.Clear();
                #endregion
                #region graph49-64
                graph49.GraphPane.CurveList.Clear();
                graph50.GraphPane.CurveList.Clear();
                graph51.GraphPane.CurveList.Clear();
                graph52.GraphPane.CurveList.Clear();
                graph53.GraphPane.CurveList.Clear();
                graph54.GraphPane.CurveList.Clear();
                graph55.GraphPane.CurveList.Clear();
                graph56.GraphPane.CurveList.Clear();
                graph57.GraphPane.CurveList.Clear();
                graph58.GraphPane.CurveList.Clear();
                graph59.GraphPane.CurveList.Clear();
                graph60.GraphPane.CurveList.Clear();
                graph61.GraphPane.CurveList.Clear();
                graph62.GraphPane.CurveList.Clear();
                graph63.GraphPane.CurveList.Clear();
                graph64.GraphPane.CurveList.Clear();
                #endregion
                #endregion
                #region graphs refresh
                graph1.Refresh();
                graph2.Refresh();
                graph3.Refresh();
                graph4.Refresh();
                graph5.Refresh();
                graph6.Refresh();
                graph7.Refresh();
                graph8.Refresh();
                graph9.Refresh();
                graph10.Refresh();
                graph11.Refresh();
                graph12.Refresh();
                graph13.Refresh();
                graph14.Refresh();
                graph15.Refresh();
                graph16.Refresh();
                graph17.Refresh();
                graph18.Refresh();
                graph19.Refresh();
                graph20.Refresh();
                graph21.Refresh();
                graph22.Refresh();
                graph23.Refresh();
                graph24.Refresh();
                graph25.Refresh();
                graph26.Refresh();
                graph27.Refresh();
                graph28.Refresh();
                graph29.Refresh();
                graph30.Refresh();
                graph31.Refresh();
                graph32.Refresh();
                graph33.Refresh();
                graph34.Refresh();
                graph35.Refresh();
                graph36.Refresh();
                graph37.Refresh();
                graph38.Refresh();
                graph39.Refresh();
                graph40.Refresh();
                graph41.Refresh();
                graph42.Refresh();
                graph43.Refresh();
                graph44.Refresh();
                graph45.Refresh();
                graph46.Refresh();
                graph47.Refresh();
                graph48.Refresh();
                graph49.Refresh();
                graph50.Refresh();
                graph51.Refresh();
                graph52.Refresh();
                graph53.Refresh();
                graph54.Refresh();
                graph55.Refresh();
                graph56.Refresh();
                graph57.Refresh();
                graph58.Refresh();
                graph59.Refresh();
                graph60.Refresh();
                graph61.Refresh();
                graph62.Refresh();
                graph63.Refresh();
                graph64.Refresh();
                #endregion
                _btnStart_Click(sender, e);
            }
        }

        private void _btnStart_Click(object sender, EventArgs e)
        {  
            if (_btnInitWasClicked == true)
            {
                if (_txtBurnInDuration.Text != "" && _txtBIInterval.Text != "")
                {
                    //read burn in interval, burn in duration from textbox
                    GlobalVariable.iDelayTimeMs = Convert.ToSingle(_txtBIInterval.Text)     * (int)3.6e6;
                    GlobalVariable.iTotalTimeMs = Convert.ToSingle(_txtBurnInDuration.Text) * (int)3.6e6;
                }
                else
                {
                    MessageBox.Show("Please enter Burn in Interval and Burn in Duration.", "Instruments Init", MessageBoxButtons.OK);
                }

                start_counter++;
                if (start_counter == 1 )//&& _btnInitWasClicked == true )
                {
                    DateTime DTFinish = DateTime.Now;
                    
                    if (GlobalVariable.iTotalTimeMs < (int)3.6e6)
                    {
                        //estimate days to complete test 
                        string DtFinish = DTFinish.AddMinutes(Convert.ToSingle(_txtBurnInDuration.Text) * 60).ToString("yyyyMMdd");
                        _txtEstFinishTestDate.Text = DtFinish;
                    }
                    else if (GlobalVariable.iTotalTimeMs >= (int)3.6e6)
                    {
                        //estimate minutes to complete test
                        string DtFinish = DTFinish.AddDays(Convert.ToSingle(_txtBurnInDuration.Text) / 24).ToString("yyyyMMdd");
                        _txtEstFinishTestDate.Text = DtFinish;
                    }
                }

                #region readonly
                _txtFilename.ReadOnly = true;
                _txtBIInterval.ReadOnly = true;
                _txtBurnInDuration.ReadOnly = true;
                _txtStartFreq1.ReadOnly = true;
                _txtStartFreq2.ReadOnly = true;
                _txtStartFreq3.ReadOnly = true;
                _txtStartFreq4.ReadOnly = true;
                _txtStressFreq1MHz.ReadOnly = true;
                _txtStressFreq2MHz.ReadOnly = true;
                _txtStressFreq3MHz.ReadOnly = true;
                _txtStressFreq4MHz.ReadOnly = true;
                _txtStopFreq1.ReadOnly = true;
                _txtStopFreq2.ReadOnly = true;
                _txtStopFreq3.ReadOnly = true;
                _txtStopFreq4.ReadOnly = true;
                #endregion

                if (!GlobalVariable.fileDateSet)
                {
                    //create file date 
                    DateTime date = DateTime.Now;
                    FileDate = date.ToString("yyyyMMdd_HHmmss");
                    GlobalVariable.fileDateSet = true;
                }

                //create burn in time 
                DTime = DateTime.Now.ToString("HH:mm:ss");
                _txtBurnInStarted.Text = DTime;

                //create time for next measurement 
                DateTime TimetoNextMeas = DateTime.Now;

                if (GlobalVariable.iDelayTimeMs < (int)3.6e6)
                {
                    string DtTimetoNextMeas = TimetoNextMeas.AddMinutes(Convert.ToSingle(_txtBIInterval.Text)).ToString("HH:mm:ss");
                    _txtTimeToNextMeas.Text = DtTimetoNextMeas;
                }
                else if (GlobalVariable.iDelayTimeMs >= (int)3.6e6)
                {
                    string DtTimetoNextMeas = TimetoNextMeas.AddHours(Convert.ToSingle(_txtBIInterval.Text)).ToString("HH:mm:ss");
                    _txtTimeToNextMeas.Text = DtTimetoNextMeas;
                }


                //read startsweep , stopsweep , stress frequencies from text box
                if (_txtStartFreq1.Text     != "" && _txtStartFreq2.Text     != "" && _txtStartFreq3.Text     != "" && _txtStartFreq4.Text     != ""
                 && _txtStopFreq1.Text      != "" && _txtStopFreq2.Text      != "" && _txtStopFreq3.Text      != "" && _txtStopFreq4.Text      != ""
                 && _txtStressFreq1MHz.Text != "" && _txtStressFreq2MHz.Text != "" && _txtStressFreq3MHz.Text != "" && _txtStressFreq4MHz.Text != "")
                {
                    GlobalVariable.StartSweepFreq[0] = Convert.ToDouble(_txtStartFreq1.Text);
                    GlobalVariable.StartSweepFreq[1] = Convert.ToDouble(_txtStartFreq2.Text);
                    GlobalVariable.StartSweepFreq[2] = Convert.ToDouble(_txtStartFreq3.Text);
                    GlobalVariable.StartSweepFreq[3] = Convert.ToDouble(_txtStartFreq4.Text);

                    GlobalVariable.StopSweepFreq[0]  = Convert.ToDouble(_txtStopFreq1.Text);
                    GlobalVariable.StopSweepFreq[1]  = Convert.ToDouble(_txtStopFreq2.Text);
                    GlobalVariable.StopSweepFreq[2]  = Convert.ToDouble(_txtStopFreq3.Text);
                    GlobalVariable.StopSweepFreq[3]  = Convert.ToDouble(_txtStopFreq4.Text);

                    GlobalVariable.StressFreq[0]     = Convert.ToDouble(_txtStressFreq1MHz.Text);
                    GlobalVariable.StressFreq[1]     = Convert.ToDouble(_txtStressFreq2MHz.Text);
                    GlobalVariable.StressFreq[2]     = Convert.ToDouble(_txtStressFreq3MHz.Text);
                    GlobalVariable.StressFreq[3]     = Convert.ToDouble(_txtStressFreq4MHz.Text);
                }

                else
                {
                    MessageBox.Show("Please enter frequencies into text boxes", "Instruments Init", MessageBoxButtons.OK);
                }

                SaveDataSetting_counter++;
                if (SaveDataSetting_counter == 1)
                {
                    System.IO.File.WriteAllText(@"C:\ReliabilityTest\Datasetting_folder\Datasetting_file.txt", String.Empty);
                    SaveDataSetting();
                }

                GlobalVariable.bRunTest = true;
                GlobalVariable.isStop   = false;
                GlobalVariable.iTsChannel = 1;

                for (int i = 0; i < 64; i++)
                {
                    ChannelButtonEnabled(false);
					
                    LibPXI.SweepTest();
                    //when ABORT button was clicked
                    #region when ABORT button was clicked
                    if (GlobalVariable.abortSet == true)
                    {
                        updateDisplay = false;
                        BItimer.Stop();
                        stresstestpowoff = true;
                        stresstest_powoff();

                        hour = 0;
                        minute = 0;
                        second = 0;
                    }
                    #endregion
                    LibPXI.Result.Add(LibPXI.subSweepResult);
                    SaveData();

                    UpdateChannelDisplay();
                    updateDisplay   = true;
                    UpdateDisplay();
                    BItimer.Start();
                    stresstestpowon = true;
                    stresstest_powon();

                    _btnStart.Visible       = false;
                    _btnAbort.Visible       = true;
                    _btntestrun.Visible     = false;
                    _btnClear.Visible       = false;
                    _btnCalibration.Visible = false;

                    GlobalVariable.iTsChannel++;
                    LibPXI.subStressResult.Clear();
                    LibPXI.subSweepResult.Clear();
                }
                GlobalVariable.numTest++;
            }
        }

        private void _btnAbort_Click(object sender, EventArgs e)
        {
            start_counter           = 0;
            SaveDataSetting_counter = 0;
            _btnAbortWasClicked     = true;
            //_btnInitWasClicked = false;
            GlobalVariable.abortSet = true;
            GlobalVariable.bRunTest = false;
            GlobalVariable.isStop   = true;
            backgroundWorker1.CancelAsync();
            ChannelButtonEnabled(true);
            _btnAbort.Visible       = false;
            _btntestrun.Visible     = true;
            _btnStart.Visible       = true;
            _btnClear.Visible       = true;
            _btnCalibration.Visible = true;

            _txtChannelDisplay.Text = channelDisplay.ToString();//chun5316

            #region readonly
            _txtFilename.ReadOnly = false;
            _txtBIInterval.ReadOnly = false;
            _txtBurnInDuration.ReadOnly = false;
            _txtStartFreq1.ReadOnly = false;
            _txtStartFreq2.ReadOnly = false;
            _txtStartFreq3.ReadOnly = false;
            _txtStartFreq4.ReadOnly = false;
            _txtStressFreq1MHz.ReadOnly = false;
            _txtStressFreq2MHz.ReadOnly = false;
            _txtStressFreq3MHz.ReadOnly = false;
            _txtStressFreq4MHz.ReadOnly = false;
            _txtStopFreq1.ReadOnly = false;
            _txtStopFreq2.ReadOnly = false;
            _txtStopFreq3.ReadOnly = false;
            _txtStopFreq4.ReadOnly = false;
            #endregion
        }

        private void _btnClear_Click(object sender, EventArgs e)
        {
            if (GlobalVariable.abortSet == true)
            {
                _btnClear.Visible = true;
                hour   = 0;
                minute = 0;
                second = 0;
                start_counter   =  0 ;
                _txthour.Text   = "0";
                _txtminute.Text = "0";
                _txtsecond.Text = "0";
                _txtEstFinishTestDate.Clear();
                _txtElapsedBITime.Clear();
                _txtTimeToNextMeas.Clear();
                _txtBurnInStarted.Clear();
                _txtEstFinishTestDate.Clear();

                GlobalVariable.bRunTest = false;
                GlobalVariable.isStop = true;
                GlobalVariable.iTsChannel = 1;

                //clear subsweep result
                for (int i = 0; i < 64; i++)
                {
                    ChannelButtonEnabled(false);
                    switch (GlobalVariable.iTsChannel.ToString())
                    {
                        #region case 1-16
                        case "1":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "2":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "3":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "4":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "5":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "6":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "7":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "8":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "9":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "10":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "11":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "12":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "13":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "14":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "15":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "16":
                            LibPXI.subSweepResult.Clear();
                            break;
                        #endregion
                        #region case 17-32
                        case "17":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "18":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "19":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "20":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "21":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "22":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "23":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "24":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "25":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "26":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "27":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "28":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "29":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "30":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "31":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "32":
                            LibPXI.subSweepResult.Clear();
                            break;
                        #endregion
                        #region case 33-48
                        case "33":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "34":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "35":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "36":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "37":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "38":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "39":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "40":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "41":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "42":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "43":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "44":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "45":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "46":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "47":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "48":
                            LibPXI.subSweepResult.Clear();
                            break;
                        #endregion
                        #region case 48-64
                        case "49":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "50":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "51":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "52":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "53":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "54":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "55":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "56":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "57":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "58":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "59":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "60":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "61":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "62":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "63":
                            LibPXI.subSweepResult.Clear();
                            break;
                        case "64":
                            LibPXI.subSweepResult.Clear();
                            break;
                        #endregion
                        default:
                            MessageBox.Show("Didn't have this Channel.", "ERROR", MessageBoxButtons.OK);
                            break;
                    }
                }
                #region clear
                graph1.GraphPane.CurveList.Clear();
                graph2.GraphPane.CurveList.Clear();
                graph3.GraphPane.CurveList.Clear();
                graph4.GraphPane.CurveList.Clear();
                graph5.GraphPane.CurveList.Clear();
                graph6.GraphPane.CurveList.Clear();
                graph7.GraphPane.CurveList.Clear();
                graph8.GraphPane.CurveList.Clear();
                graph9.GraphPane.CurveList.Clear();
                graph10.GraphPane.CurveList.Clear();

                graph11.GraphPane.CurveList.Clear();
                graph12.GraphPane.CurveList.Clear();
                graph13.GraphPane.CurveList.Clear();
                graph14.GraphPane.CurveList.Clear();
                graph15.GraphPane.CurveList.Clear();
                graph16.GraphPane.CurveList.Clear();
                graph17.GraphPane.CurveList.Clear();
                graph18.GraphPane.CurveList.Clear();
                graph19.GraphPane.CurveList.Clear();
                graph20.GraphPane.CurveList.Clear();

                graph21.GraphPane.CurveList.Clear();
                graph22.GraphPane.CurveList.Clear();
                graph23.GraphPane.CurveList.Clear();
                graph24.GraphPane.CurveList.Clear();
                graph25.GraphPane.CurveList.Clear();
                graph26.GraphPane.CurveList.Clear();
                graph27.GraphPane.CurveList.Clear();
                graph28.GraphPane.CurveList.Clear();
                graph29.GraphPane.CurveList.Clear();
                graph30.GraphPane.CurveList.Clear();

                graph31.GraphPane.CurveList.Clear();
                graph32.GraphPane.CurveList.Clear();
                graph33.GraphPane.CurveList.Clear();
                graph34.GraphPane.CurveList.Clear();
                graph35.GraphPane.CurveList.Clear();
                graph36.GraphPane.CurveList.Clear();
                graph37.GraphPane.CurveList.Clear();
                graph38.GraphPane.CurveList.Clear();
                graph39.GraphPane.CurveList.Clear();
                graph40.GraphPane.CurveList.Clear();

                graph41.GraphPane.CurveList.Clear();
                graph42.GraphPane.CurveList.Clear();
                graph43.GraphPane.CurveList.Clear();
                graph44.GraphPane.CurveList.Clear();
                graph45.GraphPane.CurveList.Clear();
                graph46.GraphPane.CurveList.Clear();
                graph47.GraphPane.CurveList.Clear();
                graph48.GraphPane.CurveList.Clear();
                graph49.GraphPane.CurveList.Clear();
                graph50.GraphPane.CurveList.Clear();

                graph51.GraphPane.CurveList.Clear();
                graph52.GraphPane.CurveList.Clear();
                graph53.GraphPane.CurveList.Clear();
                graph54.GraphPane.CurveList.Clear();
                graph55.GraphPane.CurveList.Clear();
                graph56.GraphPane.CurveList.Clear();
                graph57.GraphPane.CurveList.Clear();
                graph58.GraphPane.CurveList.Clear();
                graph59.GraphPane.CurveList.Clear();
                graph60.GraphPane.CurveList.Clear();

                graph61.GraphPane.CurveList.Clear();
                graph62.GraphPane.CurveList.Clear();
                graph63.GraphPane.CurveList.Clear();
                graph64.GraphPane.CurveList.Clear();
                #endregion
                #region graphs refresh
                graph1.Refresh();
                graph2.Refresh();
                graph3.Refresh();
                graph4.Refresh();
                graph5.Refresh();
                graph6.Refresh();
                graph7.Refresh();
                graph8.Refresh();
                graph9.Refresh();
                graph10.Refresh();
                graph11.Refresh();
                graph12.Refresh();
                graph13.Refresh();
                graph14.Refresh();
                graph15.Refresh();
                graph16.Refresh();
                graph17.Refresh();
                graph18.Refresh();
                graph19.Refresh();
                graph20.Refresh();
                graph21.Refresh();
                graph22.Refresh();
                graph23.Refresh();
                graph24.Refresh();
                graph25.Refresh();
                graph26.Refresh();
                graph27.Refresh();
                graph28.Refresh();
                graph29.Refresh();
                graph30.Refresh();
                graph31.Refresh();
                graph32.Refresh();
                graph33.Refresh();
                graph34.Refresh();
                graph35.Refresh();
                graph36.Refresh();
                graph37.Refresh();
                graph38.Refresh();
                graph39.Refresh();
                graph40.Refresh();
                graph41.Refresh();
                graph42.Refresh();
                graph43.Refresh();
                graph44.Refresh();
                graph45.Refresh();
                graph46.Refresh();
                graph47.Refresh();
                graph48.Refresh();
                graph49.Refresh();
                graph50.Refresh();
                graph51.Refresh();
                graph52.Refresh();
                graph53.Refresh();
                graph54.Refresh();
                graph55.Refresh();
                graph56.Refresh();
                graph57.Refresh();
                graph58.Refresh();
                graph59.Refresh();
                graph60.Refresh();
                graph61.Refresh();
                graph62.Refresh();
                graph63.Refresh();
                graph64.Refresh();
                #endregion
            }
            else if (GlobalVariable.abortSet == false)
            {
                MessageBox.Show("Please click ABORT button before clear button.");
            }
        }

        private void _btnCalibration_Click(object sender, EventArgs e)
        {
            CalibrationForm calForm = new CalibrationForm(this);
            calForm.ShowDialog();
            if (!GlobalVariable.bCloseCalForm)
            {
                this.WindowState = FormWindowState.Minimized;
                this.Enabled = false;
            }
        }

        private void _btnExit_Click(object sender, EventArgs e)
        {
            if (_btnAbortWasClicked == true)
            {
                LibPXI.Instrument_Uninit();
                this.Close();
            }
            else
            {
                MessageBox.Show("Please click ABORT button before click Exit button.");
            }
        }

        
        private void ChannelButtonEnabled(bool enabled)
        {
            #region channelbuttonenabled
            _btnCH1.Enabled = enabled;
            _btnCH2.Enabled = enabled;
            _btnCH3.Enabled = enabled;
            _btnCH4.Enabled = enabled;
            _btnCH5.Enabled = enabled;
            _btnCH6.Enabled = enabled;
            _btnCH7.Enabled = enabled;
            _btnCH8.Enabled = enabled;
            _btnCH9.Enabled = enabled;
            _btnCH10.Enabled = enabled;
            _btnCH11.Enabled = enabled;
            _btnCH12.Enabled = enabled;
            _btnCH13.Enabled = enabled;
            _btnCH14.Enabled = enabled;
            _btnCH15.Enabled = enabled;
            _btnCH16.Enabled = enabled;
            _btnCH17.Enabled = enabled;
            _btnCH18.Enabled = enabled;
            _btnCH19.Enabled = enabled;
            _btnCH20.Enabled = enabled;
            _btnCH21.Enabled = enabled;
            _btnCH22.Enabled = enabled;
            _btnCH23.Enabled = enabled;
            _btnCH24.Enabled = enabled;
            _btnCH25.Enabled = enabled;
            _btnCH26.Enabled = enabled;
            _btnCH27.Enabled = enabled;
            _btnCH28.Enabled = enabled;
            _btnCH29.Enabled = enabled;
            _btnCH30.Enabled = enabled;
            _btnCH31.Enabled = enabled;
            _btnCH32.Enabled = enabled;
            _btnCH33.Enabled = enabled;
            _btnCH34.Enabled = enabled;
            _btnCH35.Enabled = enabled;
            _btnCH36.Enabled = enabled;
            _btnCH37.Enabled = enabled;
            _btnCH38.Enabled = enabled;
            _btnCH39.Enabled = enabled;
            _btnCH40.Enabled = enabled;
            _btnCH41.Enabled = enabled;
            _btnCH42.Enabled = enabled;
            _btnCH43.Enabled = enabled;
            _btnCH44.Enabled = enabled;
            _btnCH45.Enabled = enabled;
            _btnCH46.Enabled = enabled;
            _btnCH47.Enabled = enabled;
            _btnCH48.Enabled = enabled;
            _btnCH49.Enabled = enabled;
            _btnCH50.Enabled = enabled;
            _btnCH51.Enabled = enabled;
            _btnCH52.Enabled = enabled;
            _btnCH53.Enabled = enabled;
            _btnCH54.Enabled = enabled;
            _btnCH55.Enabled = enabled;
            _btnCH56.Enabled = enabled;
            _btnCH57.Enabled = enabled;
            _btnCH58.Enabled = enabled;
            _btnCH59.Enabled = enabled;
            _btnCH60.Enabled = enabled;
            _btnCH61.Enabled = enabled;
            _btnCH62.Enabled = enabled;
            _btnCH63.Enabled = enabled;
            _btnCH64.Enabled = enabled;
            #endregion
        }

        //Trouble Shoot Button
        #region Troubleshoot CH Button
        private void _btnCH1_Click(object sender, EventArgs e)
        {
            GlobalVariable.iTsChannel = 1;
            TroubleShootForm tsForm = new TroubleShootForm(this);
            this.Enabled = false;
            tsForm.Text = "Channel 1";
            tsForm.Show();
        }
        //Trouble Shoot Button
        private void _btnCH2_Click(object sender, EventArgs e)
        {
            GlobalVariable.iTsChannel = 2;
            TroubleShootForm tsForm = new TroubleShootForm(this);
            this.Enabled = false;
            tsForm.Text = "Channel 2";
            tsForm.Show();
        }
        //Trouble Shoot Button
        private void _btnCH3_Click(object sender, EventArgs e)
        {
            GlobalVariable.iTsChannel = 3;
            TroubleShootForm tsForm = new TroubleShootForm(this);
            this.Enabled = false;
            tsForm.Text = "Channel 3";
            tsForm.Show();
        }
        //Trouble Shoot Button
        private void _btnCH4_Click(object sender, EventArgs e)
        {
            GlobalVariable.iTsChannel = 4;
            TroubleShootForm tsForm = new TroubleShootForm(this);
            this.Enabled = false;
            tsForm.Text = "Channel 4";
            tsForm.Show();
        }
        //Trouble Shoot Button
        private void _btnCH5_Click(object sender, EventArgs e)
        {
            GlobalVariable.iTsChannel = 5;
            TroubleShootForm tsForm = new TroubleShootForm(this);
            this.Enabled = false;
            tsForm.Text = "Channel 5";
            tsForm.Show();
        }
        //Trouble Shoot Button
        private void _btnCH6_Click(object sender, EventArgs e)
        {
            GlobalVariable.iTsChannel = 6;
            TroubleShootForm tsForm = new TroubleShootForm(this);
            this.Enabled = false;
            tsForm.Text = "Channel 6";
            tsForm.Show();
        }
        //Trouble Shoot Button
        private void _btnCH7_Click(object sender, EventArgs e)
        {
            GlobalVariable.iTsChannel = 7;
            TroubleShootForm tsForm = new TroubleShootForm(this);
            this.Enabled = false;
            tsForm.Text = "Channel 7";
            tsForm.Show();
        }
        //Trouble Shoot Button
        private void _btnCH8_Click(object sender, EventArgs e)
        {
            GlobalVariable.iTsChannel = 8;
            TroubleShootForm tsForm = new TroubleShootForm(this);
            this.Enabled = false;
            tsForm.Text = "Channel 8";
            tsForm.Show();
        }
        //Trouble Shoot Button
        private void _btnCH9_Click(object sender, EventArgs e)
        {
            GlobalVariable.iTsChannel = 9;
            TroubleShootForm tsForm = new TroubleShootForm(this);
            this.Enabled = false;
            tsForm.Text = "Channel 9";
            tsForm.Show();
        }
        //Trouble Shoot Button
        private void _btnCH10_Click(object sender, EventArgs e)
        {
            GlobalVariable.iTsChannel = 10;
            TroubleShootForm tsForm = new TroubleShootForm(this);
            this.Enabled = false;
            tsForm.Text = "Channel 10";
            tsForm.Show();
        }
        //Trouble Shoot Button
        private void _btnCH11_Click(object sender, EventArgs e)
        {
            GlobalVariable.iTsChannel = 11;
            TroubleShootForm tsForm = new TroubleShootForm(this);
            this.Enabled = false;
            tsForm.Text = "Channel 11";
            tsForm.Show();
        }
        //Trouble Shoot Button
        private void _btnCH12_Click(object sender, EventArgs e)
        {
            GlobalVariable.iTsChannel = 12;
            TroubleShootForm tsForm = new TroubleShootForm(this);
            this.Enabled = false;
            tsForm.Text = "Channel 12";
            tsForm.Show();
        }
        //Trouble Shoot Button
        private void _btnCH13_Click(object sender, EventArgs e)
        {
            GlobalVariable.iTsChannel = 13;
            TroubleShootForm tsForm = new TroubleShootForm(this);
            this.Enabled = false;
            tsForm.Text = "Channel 13";
            tsForm.Show();
        }
        //Trouble Shoot Button
        private void _btnCH14_Click(object sender, EventArgs e)
        {
            GlobalVariable.iTsChannel = 14;
            TroubleShootForm tsForm = new TroubleShootForm(this);
            this.Enabled = false;
            tsForm.Text = "Channel 14";
            tsForm.Show();
        }
        //Trouble Shoot Button
        private void _btnCH15_Click(object sender, EventArgs e)
        {
            GlobalVariable.iTsChannel = 15;
            TroubleShootForm tsForm = new TroubleShootForm(this);
            this.Enabled = false;
            tsForm.Text = "Channel 15";
            tsForm.Show();
        }
        //Trouble Shoot Button
        private void _btnCH16_Click(object sender, EventArgs e)
        {
            GlobalVariable.iTsChannel = 16;
            TroubleShootForm tsForm = new TroubleShootForm(this);
            this.Enabled = false;
            tsForm.Text = "Channel 16";
            tsForm.Show();
        }
        //Trouble Shoot Button
        private void _btnCH17_Click(object sender, EventArgs e)
        {
            GlobalVariable.iTsChannel = 17;
            TroubleShootForm tsForm = new TroubleShootForm(this);
            this.Enabled = false;
            tsForm.Text = "Channel 17";
            tsForm.Show();
        }
        //Trouble Shoot Button
        private void _btnCH18_Click(object sender, EventArgs e)
        {
            GlobalVariable.iTsChannel = 18;
            TroubleShootForm tsForm = new TroubleShootForm(this);
            this.Enabled = false;
            tsForm.Text = "Channel 18";
            tsForm.Show();
        }
        //Trouble Shoot Button
        private void _btnCH19_Click(object sender, EventArgs e)
        {
            GlobalVariable.iTsChannel = 19;
            TroubleShootForm tsForm = new TroubleShootForm(this);
            this.Enabled = false;
            tsForm.Text = "Channel 19";
            tsForm.Show();
        }
        //Trouble Shoot Button
        private void _btnCH20_Click(object sender, EventArgs e)
        {
            GlobalVariable.iTsChannel = 20;
            TroubleShootForm tsForm = new TroubleShootForm(this);
            this.Enabled = false;
            tsForm.Text = "Channel 20";
            tsForm.Show();
        }
        //Trouble Shoot Button
        private void _btnCH21_Click(object sender, EventArgs e)
        {
            GlobalVariable.iTsChannel = 21;
            TroubleShootForm tsForm = new TroubleShootForm(this);
            this.Enabled = false;
            tsForm.Text = "Channel 21";
            tsForm.Show();
        }
        //Trouble Shoot Button
        private void _btnCH22_Click(object sender, EventArgs e)
        {
            GlobalVariable.iTsChannel = 22;
            TroubleShootForm tsForm = new TroubleShootForm(this);
            this.Enabled = false;
            tsForm.Text = "Channel 22";
            tsForm.Show();
        }
        //Trouble Shoot Button
        private void _btnCH23_Click(object sender, EventArgs e)
        {
            GlobalVariable.iTsChannel = 23;
            TroubleShootForm tsForm = new TroubleShootForm(this);
            this.Enabled = false;
            tsForm.Text = "Channel 23";
            tsForm.Show();
        }
        //Trouble Shoot Button
        private void _btnCH24_Click(object sender, EventArgs e)
        {
            GlobalVariable.iTsChannel = 24;
            TroubleShootForm tsForm = new TroubleShootForm(this);
            this.Enabled = false;
            tsForm.Text = "Channel 24";
            tsForm.Show();
        }
        //Trouble Shoot Button
        private void _btnCH25_Click(object sender, EventArgs e)
        {
            GlobalVariable.iTsChannel = 25;
            TroubleShootForm tsForm = new TroubleShootForm(this);
            this.Enabled = false;
            tsForm.Text = "Channel 25";
            tsForm.Show();
        }
        //Trouble Shoot Button
        private void _btnCH26_Click(object sender, EventArgs e)
        {
            GlobalVariable.iTsChannel = 26;
            TroubleShootForm tsForm = new TroubleShootForm(this);
            this.Enabled = false;
            tsForm.Text = "Channel 26";
            tsForm.Show();
        }
        //Trouble Shoot Button
        private void _btnCH27_Click(object sender, EventArgs e)
        {
            GlobalVariable.iTsChannel = 27;
            TroubleShootForm tsForm = new TroubleShootForm(this);
            this.Enabled = false;
            tsForm.Text = "Channel 27";
            tsForm.Show();
        }
        //Trouble Shoot Button
        private void _btnCH28_Click(object sender, EventArgs e)
        {
            GlobalVariable.iTsChannel = 28;
            TroubleShootForm tsForm = new TroubleShootForm(this);
            this.Enabled = false;
            tsForm.Text = "Channel 28";
            tsForm.Show();
        }
        //Trouble Shoot Button
        private void _btnCH29_Click(object sender, EventArgs e)
        {
            GlobalVariable.iTsChannel = 29;
            TroubleShootForm tsForm = new TroubleShootForm(this);
            this.Enabled = false;
            tsForm.Text = "Channel 29";
            tsForm.Show();
        }
        //Trouble Shoot Button
        private void _btnCH30_Click(object sender, EventArgs e)
        {
            GlobalVariable.iTsChannel = 30;
            TroubleShootForm tsForm = new TroubleShootForm(this);
            this.Enabled = false;
            tsForm.Text = "Channel 30";
            tsForm.Show();
        }
        //Trouble Shoot Button
        private void _btnCH31_Click(object sender, EventArgs e)
        {
            GlobalVariable.iTsChannel = 31;
            TroubleShootForm tsForm = new TroubleShootForm(this);
            this.Enabled = false;
            tsForm.Text = "Channel 31";
            tsForm.Show();
        }
        //Trouble Shoot Button
        private void _btnCH32_Click(object sender, EventArgs e)
        {
            GlobalVariable.iTsChannel = 32;
            TroubleShootForm tsForm = new TroubleShootForm(this);
            this.Enabled = false;
            tsForm.Text = "Channel 32";
            tsForm.Show();
        }
        //Trouble Shoot Button
        private void _btnCH33_Click(object sender, EventArgs e)
        {
            GlobalVariable.iTsChannel = 33;
            TroubleShootForm tsForm = new TroubleShootForm(this);
            this.Enabled = false;
            tsForm.Text = "Channel 33";
            tsForm.Show();
        }
        //Trouble Shoot Button
        private void _btnCH34_Click(object sender, EventArgs e)
        {
            GlobalVariable.iTsChannel = 34;
            TroubleShootForm tsForm = new TroubleShootForm(this);
            this.Enabled = false;
            tsForm.Text = "Channel 34";
            tsForm.Show();
        }
        //Trouble Shoot Button
        private void _btnCH35_Click(object sender, EventArgs e)
        {
            GlobalVariable.iTsChannel = 35;
            TroubleShootForm tsForm = new TroubleShootForm(this);
            this.Enabled = false;
            tsForm.Text = "Channel 35";
            tsForm.Show();
        }
        //Trouble Shoot Button
        private void _btnCH36_Click(object sender, EventArgs e)
        {
            GlobalVariable.iTsChannel = 36;
            TroubleShootForm tsForm = new TroubleShootForm(this);
            this.Enabled = false;
            tsForm.Text = "Channel 36";
            tsForm.Show();
        }
        //Trouble Shoot Button
        private void _btnCH37_Click(object sender, EventArgs e)
        {
            GlobalVariable.iTsChannel = 37;
            TroubleShootForm tsForm = new TroubleShootForm(this);
            this.Enabled = false;
            tsForm.Text = "Channel 37";
            tsForm.Show();
        }
        //Trouble Shoot Button
        private void _btnCH38_Click(object sender, EventArgs e)
        {
            GlobalVariable.iTsChannel = 38;
            TroubleShootForm tsForm = new TroubleShootForm(this);
            this.Enabled = false;
            tsForm.Text = "Channel 38";
            tsForm.Show();
        }
        //Trouble Shoot Button
        private void _btnCH39_Click(object sender, EventArgs e)
        {
            GlobalVariable.iTsChannel = 39;
            TroubleShootForm tsForm = new TroubleShootForm(this);
            this.Enabled = false;
            tsForm.Text = "Channel 39";
            tsForm.Show();
        }
        //Trouble Shoot Button
        private void _btnCH40_Click(object sender, EventArgs e)
        {
            GlobalVariable.iTsChannel = 40;
            TroubleShootForm tsForm = new TroubleShootForm(this);
            this.Enabled = false;
            tsForm.Text = "Channel 40";
            tsForm.Show();
        }
        //Trouble Shoot Button
        private void _btnCH41_Click(object sender, EventArgs e)
        {
            GlobalVariable.iTsChannel = 41;
            TroubleShootForm tsForm = new TroubleShootForm(this);
            this.Enabled = false;
            tsForm.Text = "Channel 41";
            tsForm.Show();
        }
        //Trouble Shoot Button
        private void _btnCH42_Click(object sender, EventArgs e)
        {
            GlobalVariable.iTsChannel = 42;
            TroubleShootForm tsForm = new TroubleShootForm(this);
            this.Enabled = false;
            tsForm.Text = "Channel 42";
            tsForm.Show();
        }
        //Trouble Shoot Button
        private void _btnCH43_Click(object sender, EventArgs e)
        {
            GlobalVariable.iTsChannel = 43;
            TroubleShootForm tsForm = new TroubleShootForm(this);
            this.Enabled = false;
            tsForm.Text = "Channel 43";
            tsForm.Show();
        }
        //Trouble Shoot Button
        private void _btnCH44_Click(object sender, EventArgs e)
        {
            GlobalVariable.iTsChannel = 44;
            TroubleShootForm tsForm = new TroubleShootForm(this);
            this.Enabled = false;
            tsForm.Text = "Channel 44";
            tsForm.Show();
        }
        //Trouble Shoot Button
        private void _btnCH45_Click(object sender, EventArgs e)
        {
            GlobalVariable.iTsChannel = 45;
            TroubleShootForm tsForm = new TroubleShootForm(this);
            this.Enabled = false;
            tsForm.Text = "Channel 45";
            tsForm.Show();
        }
        //Trouble Shoot Button
        private void _btnCH46_Click(object sender, EventArgs e)
        {
            GlobalVariable.iTsChannel = 46;
            TroubleShootForm tsForm = new TroubleShootForm(this);
            this.Enabled = false;
            tsForm.Text = "Channel 46";
            tsForm.Show();
        }
        //Trouble Shoot Button
        private void _btnCH47_Click(object sender, EventArgs e)
        {
            GlobalVariable.iTsChannel = 47;
            TroubleShootForm tsForm = new TroubleShootForm(this);
            this.Enabled = false;
            tsForm.Text = "Channel 47";
            tsForm.Show();
        }
        //Trouble Shoot Button
        private void _btnCH48_Click(object sender, EventArgs e)
        {
            GlobalVariable.iTsChannel = 48;
            TroubleShootForm tsForm = new TroubleShootForm(this);
            this.Enabled = false;
            tsForm.Text = "Channel 48";
            tsForm.Show();
        }
        //Trouble Shoot Button
        private void _btnCH49_Click(object sender, EventArgs e)
        {
            GlobalVariable.iTsChannel = 49;
            TroubleShootForm tsForm = new TroubleShootForm(this);
            this.Enabled = false;
            tsForm.Text = "Channel 49";
            tsForm.Show();
        }
        //Trouble Shoot Button
        private void _btnCH50_Click(object sender, EventArgs e)
        {
            GlobalVariable.iTsChannel = 50;
            TroubleShootForm tsForm = new TroubleShootForm(this);
            this.Enabled = false;
            tsForm.Text = "Channel 50";
            tsForm.Show();
        }
        //Trouble Shoot Button
        private void _btnCH51_Click(object sender, EventArgs e)
        {
            GlobalVariable.iTsChannel = 51;
            TroubleShootForm tsForm = new TroubleShootForm(this);
            this.Enabled = false;
            tsForm.Text = "Channel 51";
            tsForm.Show();
        }
        //Trouble Shoot Button
        private void _btnCH52_Click(object sender, EventArgs e)
        {
            GlobalVariable.iTsChannel = 52;
            TroubleShootForm tsForm = new TroubleShootForm(this);
            this.Enabled = false;
            tsForm.Text = "Channel 52";
            tsForm.Show();
        }
        //Trouble Shoot Button
        private void _btnCH53_Click(object sender, EventArgs e)
        {
            GlobalVariable.iTsChannel = 53;
            TroubleShootForm tsForm = new TroubleShootForm(this);
            this.Enabled = false;
            tsForm.Text = "Channel 53";
            tsForm.Show();
        }
        //Trouble Shoot Button
        private void _btnCH54_Click(object sender, EventArgs e)
        {
            GlobalVariable.iTsChannel = 54;
            TroubleShootForm tsForm = new TroubleShootForm(this);
            this.Enabled = false;
            tsForm.Text = "Channel 54";
            tsForm.Show();
        }
        //Trouble Shoot Button
        private void _btnCH55_Click(object sender, EventArgs e)
        {
            GlobalVariable.iTsChannel = 55;
            TroubleShootForm tsForm = new TroubleShootForm(this);
            this.Enabled = false;
            tsForm.Text = "Channel 55";
            tsForm.Show();
        }
        //Trouble Shoot Button
        private void _btnCH56_Click(object sender, EventArgs e)
        {
            GlobalVariable.iTsChannel = 56;
            TroubleShootForm tsForm = new TroubleShootForm(this);
            this.Enabled = false;
            tsForm.Text = "Channel 56";
            tsForm.Show();
        }
        //Trouble Shoot Button
        private void _btnCH57_Click(object sender, EventArgs e)
        {
            GlobalVariable.iTsChannel = 57;
            TroubleShootForm tsForm = new TroubleShootForm(this);
            this.Enabled = false;
            tsForm.Text = "Channel 57";
            tsForm.Show();
        }
        //Trouble Shoot Button
        private void _btnCH58_Click(object sender, EventArgs e)
        {
            GlobalVariable.iTsChannel = 58;
            TroubleShootForm tsForm = new TroubleShootForm(this);
            this.Enabled = false;
            tsForm.Text = "Channel 58";
            tsForm.Show();
        }
        //Trouble Shoot Button
        private void _btnCH59_Click(object sender, EventArgs e)
        {
            GlobalVariable.iTsChannel = 59;
            TroubleShootForm tsForm = new TroubleShootForm(this);
            this.Enabled = false;
            tsForm.Text = "Channel 59";
            tsForm.Show();
        }
        //Trouble Shoot Button
        private void _btnCH60_Click(object sender, EventArgs e)
        {
            GlobalVariable.iTsChannel = 60;
            TroubleShootForm tsForm = new TroubleShootForm(this);
            this.Enabled = false;
            tsForm.Text = "Channel 60";
            tsForm.Show();
        }
        //Trouble Shoot Button
        private void _btnCH61_Click(object sender, EventArgs e)
        {
            GlobalVariable.iTsChannel = 61;
            TroubleShootForm tsForm = new TroubleShootForm(this);
            this.Enabled = false;
            tsForm.Text = "Channel 61";
            tsForm.Show();
        }
        //Trouble Shoot Button
        private void _btnCH62_Click(object sender, EventArgs e)
        {
            GlobalVariable.iTsChannel = 62;
            TroubleShootForm tsForm = new TroubleShootForm(this);
            this.Enabled = false;
            tsForm.Text = "Channel 62";
            tsForm.Show();
        }
        //Trouble Shoot Button
        private void _btnCH63_Click(object sender, EventArgs e)
        {
            GlobalVariable.iTsChannel = 63;
            TroubleShootForm tsForm = new TroubleShootForm(this);
            this.Enabled = false;
            tsForm.Text = "Channel 63";
            tsForm.Show();
        }
        //Trouble Shoot Button
        private void _btnCH64_Click(object sender, EventArgs e)
        {
            GlobalVariable.iTsChannel = 64;
            TroubleShootForm tsForm = new TroubleShootForm(this);
            this.Enabled = false;
            tsForm.Text = "Channel 64";
            tsForm.Show();
        }
        #endregion

        private void ClearChartDisplay()
        {
            #region clearchartdisplay
            //chartCH1.Series.Clear();
            //chartCH2.Series.Clear();
            //chartCH3.Series.Clear();
            //chartCH4.Series.Clear();
            //chartCH5.Series.Clear();
            //chartCH6.Series.Clear();
            //chartCH7.Series.Clear();
            //chartCH8.Series.Clear();
            //chartCH9.Series.Clear();
            //chartCH10.Series.Clear();
            //chartCH11.Series.Clear();
            //chartCH12.Series.Clear();
            //chartCH13.Series.Clear();
            //chartCH14.Series.Clear();
            //chartCH15.Series.Clear();
            //chartCH16.Series.Clear();
            //chartCH17.Series.Clear();
            //chartCH18.Series.Clear();
            //chartCH19.Series.Clear();
            //chartCH20.Series.Clear();
            //chartCH21.Series.Clear();
            //chartCH22.Series.Clear();
            //chartCH23.Series.Clear();
            //chartCH24.Series.Clear();
            //chartCH25.Series.Clear();
            //chartCH26.Series.Clear();
            //chartCH27.Series.Clear();
            //chartCH28.Series.Clear();
            //chartCH29.Series.Clear();
            //chartCH30.Series.Clear();
            //chartCH31.Series.Clear();
            //chartCH32.Series.Clear();
            //chartCH33.Series.Clear();
            //chartCH34.Series.Clear();
            //chartCH35.Series.Clear();
            //chartCH36.Series.Clear();
            //chartCH37.Series.Clear();
            //chartCH38.Series.Clear();
            //chartCH39.Series.Clear();
            //chartCH40.Series.Clear();
            //chartCH41.Series.Clear();
            //chartCH42.Series.Clear();
            //chartCH43.Series.Clear();
            //chartCH44.Series.Clear();
            //chartCH45.Series.Clear();
            //chartCH46.Series.Clear();
            //chartCH47.Series.Clear();
            //chartCH48.Series.Clear();
            //chartCH49.Series.Clear();
            //chartCH50.Series.Clear();
            //chartCH51.Series.Clear();
            //chartCH52.Series.Clear();
            //chartCH53.Series.Clear();
            //chartCH54.Series.Clear();
            //chartCH55.Series.Clear();
            //chartCH56.Series.Clear();
            //chartCH57.Series.Clear();
            //chartCH58.Series.Clear();
            //chartCH59.Series.Clear();
            //chartCH60.Series.Clear();
            //chartCH61.Series.Clear();
            //chartCH62.Series.Clear();
            //chartCH63.Series.Clear();
            //chartCH64.Series.Clear();
            #endregion
        }

        //update channel number (square box)
        private void UpdateChannelDisplay()
        {
            _txtChannelDisplay.Text = GlobalVariable.iTsChannel.ToString();
        }

        //update 64 charts display
        private void UpdateDisplay()
        {
            #region updatedisplay
            string strNumTest = GlobalVariable.numTest.ToString();
            //string DtTimetoNextMeas;
            //double tempYMaxResult = 0;
            //double tempYMinResult = 0;
            //double tempXMaxFreq   = 0;
            //double tempXMinFreq   = 0;
            //double Ydelta         = 0;
            //double Xdelta         = 0;

            switch (GlobalVariable.iTsChannel.ToString())
            {
                #region case1-16
                case "1":
                    #region Channel 1
                    #region New Graph method
                    PointPairList result1 = new PointPairList();
                    int i1 = 0;
                    foreach (double tempResult in LibPXI.subSweepResult)
                    {
                        result1.Add(i1, tempResult);
                        i1++;
                        #region GlobalVariable.abortSet == true
                        if (GlobalVariable.abortSet == true)
                        {
                            updateDisplay = false;
                            BItimer.Stop();
                            stresstestpowoff = true;
                            if (stresstestpowoff == true)
                            {
                                #region stresstest_powoff
                                if (GlobalVariable.iTsChannel <= 16)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);
                                }
                                else if (GlobalVariable.iTsChannel <= 32)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);
                                }
                                else if (GlobalVariable.iTsChannel <= 48)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);
                                }
                                else if (GlobalVariable.iTsChannel <= 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                else if (GlobalVariable.iTsChannel > 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                #endregion
                            }
                            hour = 0;
                            minute = 0;
                            second = 0;
                        }
                        #endregion}
                    }
                    LineItem test1 = graph1.GraphPane.AddCurve("", result1, Color.YellowGreen, SymbolType.None);
                    graph1.GraphPane.Title.Text = "Channel 01";
                    graph1.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                    graph1.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                    graph1.GraphPane.XAxis.Scale.Max = 402;
                    graph1.IsAutoScrollRange = true;
                    graph1.AxisChange();
                    graph1.Invalidate();
                    #endregion
                    #endregion
                    break;
                case "2":
                    #region Channel 2
                    #region New Graph method

                    PointPairList result2 = new PointPairList();
                    int i2 = 0;
                    foreach (double tempResult in LibPXI.subSweepResult)
                    {
                        result2.Add(i2, tempResult);
                        i2++;
                        #region GlobalVariable.abortSet == true
                        if (GlobalVariable.abortSet == true)
                        {
                            updateDisplay = false;
                            BItimer.Stop();
                            stresstestpowoff = true;
                            if (stresstestpowoff == true)
                            {
                                #region stresstest_powoff
                                if (GlobalVariable.iTsChannel <= 16)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);
                                }
                                else if (GlobalVariable.iTsChannel <= 32)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);
                                }
                                else if (GlobalVariable.iTsChannel <= 48)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);
                                }
                                else if (GlobalVariable.iTsChannel <= 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                else if (GlobalVariable.iTsChannel > 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                #endregion
                            }
                            hour = 0;
                            minute = 0;
                            second = 0;
                        }
                        #endregion}
                    }
                    LineItem test2 = graph2.GraphPane.AddCurve("", result2, Color.YellowGreen, SymbolType.None);
                    graph2.GraphPane.Title.Text = "Channel 02";
                    graph2.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                    graph2.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                    graph2.GraphPane.XAxis.Scale.Max = 402;
                    graph2.IsAutoScrollRange = true;
                    graph2.AxisChange();
                    graph2.Invalidate();
                    #endregion
                    #endregion
                    break;
                case "3":
                    #region Channel 3
                    #region New Graph method

                    PointPairList result3 = new PointPairList();
                    int i3 = 0;
                    foreach (double tempResult in LibPXI.subSweepResult)
                    {
                        result3.Add(i3, tempResult);
                        i3++;
                        #region GlobalVariable.abortSet == true
                        if (GlobalVariable.abortSet == true)
                        {
                            updateDisplay = false;
                            BItimer.Stop();
                            stresstestpowoff = true;
                            if (stresstestpowoff == true)
                            {
                                #region stresstest_powoff
                                if (GlobalVariable.iTsChannel <= 16)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);
                                }
                                else if (GlobalVariable.iTsChannel <= 32)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);
                                }
                                else if (GlobalVariable.iTsChannel <= 48)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);
                                }
                                else if (GlobalVariable.iTsChannel <= 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                else if (GlobalVariable.iTsChannel > 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                #endregion
                            }
                            hour = 0;
                            minute = 0;
                            second = 0;
                        }
                        #endregion}
                    }
                    LineItem test3 = graph3.GraphPane.AddCurve("", result3, Color.YellowGreen, SymbolType.None);
                    graph3.GraphPane.Title.Text = "Channel 03";
                    graph3.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                    graph3.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                    graph3.GraphPane.XAxis.Scale.Max = 402;
                    graph3.IsAutoScrollRange = true;
                    graph3.AxisChange();
                    graph3.Invalidate();
                    #endregion
                    #endregion
                    break;
                case "4":
                    #region Channel 4
                    #region New Graph method

                    PointPairList result4 = new PointPairList();
                    int i4 = 0;
                    foreach (double tempResult in LibPXI.subSweepResult)
                    {
                        result4.Add(i4, tempResult);
                        i4++;
                        #region GlobalVariable.abortSet == true
                        if (GlobalVariable.abortSet == true)
                        {
                            updateDisplay = false;
                            BItimer.Stop();
                            stresstestpowoff = true;
                            if (stresstestpowoff == true)
                            {
                                #region stresstest_powoff
                                if (GlobalVariable.iTsChannel <= 16)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);
                                }
                                else if (GlobalVariable.iTsChannel <= 32)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);
                                }
                                else if (GlobalVariable.iTsChannel <= 48)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);
                                }
                                else if (GlobalVariable.iTsChannel <= 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                else if (GlobalVariable.iTsChannel > 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                #endregion
                            }
                            hour = 0;
                            minute = 0;
                            second = 0;
                        }
                        #endregion}
                    }
                    LineItem test4 = graph4.GraphPane.AddCurve("", result4, Color.YellowGreen, SymbolType.None);
                    graph4.GraphPane.Title.Text = "Channel 04";
                    graph4.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                    graph4.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                    graph4.GraphPane.XAxis.Scale.Max = 402;
                    graph4.IsAutoScrollRange = true;
                    graph4.AxisChange();
                    graph4.Invalidate();
                    #endregion
                    #endregion
                    break;
                case "5":
                    #region Channel 5
                    #region New Graph method

                    PointPairList result5 = new PointPairList();
                    int i5 = 0;
                    foreach (double tempResult in LibPXI.subSweepResult)
                    {
                        result5.Add(i5, tempResult);
                        i5++;
                        #region GlobalVariable.abortSet == true
                        if (GlobalVariable.abortSet == true)
                        {
                            updateDisplay = false;
                            BItimer.Stop();
                            stresstestpowoff = true;
                            if (stresstestpowoff == true)
                            {
                                #region stresstest_powoff
                                if (GlobalVariable.iTsChannel <= 16)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);
                                }
                                else if (GlobalVariable.iTsChannel <= 32)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);
                                }
                                else if (GlobalVariable.iTsChannel <= 48)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);
                                }
                                else if (GlobalVariable.iTsChannel <= 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                else if (GlobalVariable.iTsChannel > 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                #endregion
                            }
                            hour = 0;
                            minute = 0;
                            second = 0;
                        }
                        #endregion}
                    }
                    LineItem test5 = graph5.GraphPane.AddCurve("", result5, Color.YellowGreen, SymbolType.None);
                    graph5.GraphPane.Title.Text = "Channel 05";
                    graph5.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                    graph5.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                    graph5.GraphPane.XAxis.Scale.Max = 402;
                    graph5.IsAutoScrollRange = true;
                    graph5.AxisChange();
                    graph5.Invalidate();
                    #endregion
                    #endregion
                    break;
                case "6":
                    #region Channel 6
                    #region New Graph method

                    PointPairList result6 = new PointPairList();
                    int i6 = 0;
                    foreach (double tempResult in LibPXI.subSweepResult)
                    {
                        result6.Add(i6, tempResult);
                        i6++;
                        #region GlobalVariable.abortSet == true
                        if (GlobalVariable.abortSet == true)
                        {
                            updateDisplay = false;
                            BItimer.Stop();
                            stresstestpowoff = true;
                            if (stresstestpowoff == true)
                            {
                                #region stresstest_powoff
                                if (GlobalVariable.iTsChannel <= 16)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);
                                }
                                else if (GlobalVariable.iTsChannel <= 32)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);
                                }
                                else if (GlobalVariable.iTsChannel <= 48)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);
                                }
                                else if (GlobalVariable.iTsChannel <= 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                else if (GlobalVariable.iTsChannel > 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                #endregion
                            }
                            hour = 0;
                            minute = 0;
                            second = 0;
                        }
                        #endregion}
                    }
                    LineItem test6 = graph6.GraphPane.AddCurve("", result6, Color.YellowGreen, SymbolType.None);
                    graph6.GraphPane.Title.Text = "Channel 06";
                    graph6.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                    graph6.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                    graph6.GraphPane.XAxis.Scale.Max = 402;
                    graph6.IsAutoScrollRange = true;
                    graph6.AxisChange();
                    graph6.Invalidate();
                    #endregion
                    #endregion
                    break;
                case "7":
                    #region Channel 7
                    #region New Graph method

                    PointPairList result7 = new PointPairList();
                    int i7 = 0;
                    foreach (double tempResult in LibPXI.subSweepResult)
                    {
                        result7.Add(i7, tempResult);
                        i7++;
                        #region GlobalVariable.abortSet == true
                        if (GlobalVariable.abortSet == true)
                        {
                            updateDisplay = false;
                            BItimer.Stop();
                            stresstestpowoff = true;
                            if (stresstestpowoff == true)
                            {
                                #region stresstest_powoff
                                if (GlobalVariable.iTsChannel <= 16)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);
                                }
                                else if (GlobalVariable.iTsChannel <= 32)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);
                                }
                                else if (GlobalVariable.iTsChannel <= 48)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);
                                }
                                else if (GlobalVariable.iTsChannel <= 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                else if (GlobalVariable.iTsChannel > 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                #endregion
                            }
                            hour = 0;
                            minute = 0;
                            second = 0;
                        }
                        #endregion}
                    }
                    LineItem test7 = graph7.GraphPane.AddCurve("", result7, Color.YellowGreen, SymbolType.None);
                    graph7.GraphPane.Title.Text = "Channel 07";
                    graph7.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                    graph7.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                    graph7.GraphPane.XAxis.Scale.Max = 402;
                    graph7.IsAutoScrollRange = true;
                    graph7.AxisChange();
                    graph7.Invalidate();
                    #endregion
                    #endregion
                    break;
                case "8":
                    #region Channel 8
                    #region New Graph method

                    PointPairList result8 = new PointPairList();
                    int i8 = 0;
                    foreach (double tempResult in LibPXI.subSweepResult)
                    {
                        result8.Add(i8, tempResult);
                        i8++;
                        #region GlobalVariable.abortSet == true
                        if (GlobalVariable.abortSet == true)
                        {
                            updateDisplay = false;
                            BItimer.Stop();
                            stresstestpowoff = true;
                            if (stresstestpowoff == true)
                            {
                                #region stresstest_powoff
                                if (GlobalVariable.iTsChannel <= 16)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);
                                }
                                else if (GlobalVariable.iTsChannel <= 32)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);
                                }
                                else if (GlobalVariable.iTsChannel <= 48)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);
                                }
                                else if (GlobalVariable.iTsChannel <= 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                else if (GlobalVariable.iTsChannel > 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                #endregion
                            }
                            hour = 0;
                            minute = 0;
                            second = 0;
                        }
                        #endregion}
                    }
                    LineItem test8 = graph8.GraphPane.AddCurve("", result8, Color.YellowGreen, SymbolType.None);
                    graph8.GraphPane.Title.Text = "Channel 08";
                    graph8.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                    graph8.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                    graph8.GraphPane.XAxis.Scale.Max = 402;
                    graph8.IsAutoScrollRange = true;
                    graph8.AxisChange();
                    graph8.Invalidate();
                    #endregion
                    #endregion
                    break;
                case "9":
                    #region Channel 9
                    #region New Graph method

                    PointPairList result9 = new PointPairList();
                    int i9 = 0;
                    foreach (double tempResult in LibPXI.subSweepResult)
                    {
                        result9.Add(i9, tempResult);
                        i9++;
                        #region GlobalVariable.abortSet == true
                        if (GlobalVariable.abortSet == true)
                        {
                            updateDisplay = false;
                            BItimer.Stop();
                            stresstestpowoff = true;
                            if (stresstestpowoff == true)
                            {
                                #region stresstest_powoff
                                if (GlobalVariable.iTsChannel <= 16)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);
                                }
                                else if (GlobalVariable.iTsChannel <= 32)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);
                                }
                                else if (GlobalVariable.iTsChannel <= 48)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);
                                }
                                else if (GlobalVariable.iTsChannel <= 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                else if (GlobalVariable.iTsChannel > 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                #endregion
                            }
                            hour = 0;
                            minute = 0;
                            second = 0;
                        }
                        #endregion}
                    }
                    LineItem test9 = graph9.GraphPane.AddCurve("", result9, Color.YellowGreen, SymbolType.None);
                    graph9.GraphPane.Title.Text = "Channel 09";
                    graph9.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                    graph9.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                    graph9.GraphPane.XAxis.Scale.Max = 402;
                    graph9.IsAutoScrollRange = true;
                    graph9.AxisChange();
                    graph9.Invalidate();
                    #endregion
                    #endregion
                    break;
                case "10":
                    #region Channel 10
                    #region New Graph method

                    PointPairList result10 = new PointPairList();
                    int i10 = 0;
                    foreach (double tempResult in LibPXI.subSweepResult)
                    {
                        result10.Add(i10, tempResult);
                        i10++;
                        #region GlobalVariable.abortSet == true
                        if (GlobalVariable.abortSet == true)
                        {
                            updateDisplay = false;
                            BItimer.Stop();
                            stresstestpowoff = true;
                            if (stresstestpowoff == true)
                            {
                                #region stresstest_powoff
                                if (GlobalVariable.iTsChannel <= 16)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);
                                }
                                else if (GlobalVariable.iTsChannel <= 32)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);
                                }
                                else if (GlobalVariable.iTsChannel <= 48)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);
                                }
                                else if (GlobalVariable.iTsChannel <= 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                else if (GlobalVariable.iTsChannel > 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                #endregion
                            }
                            hour = 0;
                            minute = 0;
                            second = 0;
                        }
                        #endregion}
                    }
                    LineItem test10 = graph10.GraphPane.AddCurve("", result10, Color.YellowGreen, SymbolType.None);
                    graph10.GraphPane.Title.Text = "Channel 10";
                    graph10.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                    graph10.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                    graph10.GraphPane.XAxis.Scale.Max = 402;
                    graph10.IsAutoScrollRange = true;
                    graph10.AxisChange();
                    graph10.Invalidate();
                    #endregion
                    #endregion
                    break;
                case "11":
                    #region Channel 11
                    #region New Graph method

                    PointPairList result11 = new PointPairList();
                    int i11 = 0;
                    foreach (double tempResult in LibPXI.subSweepResult)
                    {
                        result11.Add(i11, tempResult);
                        i11++;
                        #region GlobalVariable.abortSet == true
                        if (GlobalVariable.abortSet == true)
                        {
                            updateDisplay = false;
                            BItimer.Stop();
                            stresstestpowoff = true;
                            if (stresstestpowoff == true)
                            {
                                #region stresstest_powoff
                                if (GlobalVariable.iTsChannel <= 16)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);
                                }
                                else if (GlobalVariable.iTsChannel <= 32)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);
                                }
                                else if (GlobalVariable.iTsChannel <= 48)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);
                                }
                                else if (GlobalVariable.iTsChannel <= 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                else if (GlobalVariable.iTsChannel > 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                #endregion
                            }
                            hour = 0;
                            minute = 0;
                            second = 0;
                        }
                        #endregion}
                    }
                    LineItem test11 = graph11.GraphPane.AddCurve("", result11, Color.YellowGreen, SymbolType.None);
                    graph11.GraphPane.Title.Text = "Channel 11";
                    graph11.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                    graph11.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                    graph11.GraphPane.XAxis.Scale.Max = 402;
                    graph11.IsAutoScrollRange = true;
                    graph11.AxisChange();
                    graph11.Invalidate();
                    #endregion
                    #endregion
                    break;
                case "12":
                    #region Channel 12
                    #region New Graph method
                    PointPairList result12 = new PointPairList();
                    int i12 = 0;
                    foreach (double tempResult in LibPXI.subSweepResult)
                    {
                        result12.Add(i12, tempResult);
                        i12++;
                        #region GlobalVariable.abortSet == true
                        if (GlobalVariable.abortSet == true)
                        {
                            updateDisplay = false;
                            BItimer.Stop();
                            stresstestpowoff = true;
                            if (stresstestpowoff == true)
                            {
                                #region stresstest_powoff
                                if (GlobalVariable.iTsChannel <= 16)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);
                                }
                                else if (GlobalVariable.iTsChannel <= 32)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);
                                }
                                else if (GlobalVariable.iTsChannel <= 48)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);
                                }
                                else if (GlobalVariable.iTsChannel <= 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                else if (GlobalVariable.iTsChannel > 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                #endregion
                            }
                            hour = 0;
                            minute = 0;
                            second = 0;
                        }
                        #endregion}
                    }
                    LineItem test12 = graph12.GraphPane.AddCurve("", result12, Color.YellowGreen, SymbolType.None);
                    graph12.GraphPane.Title.Text = "Channel 12";
                    graph12.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                    graph12.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                    graph12.GraphPane.XAxis.Scale.Max = 402;
                    graph12.IsAutoScrollRange = true;
                    graph12.AxisChange();
                    graph12.Invalidate();
                    #endregion
                    #endregion
                    break;
                case "13":
                    #region Channel 13
                    #region New Graph method
                    PointPairList result13 = new PointPairList();
                    int i13 = 0;
                    foreach (double tempResult in LibPXI.subSweepResult)
                    {
                        result13.Add(i13, tempResult);
                        i13++;
                        #region GlobalVariable.abortSet == true
                        if (GlobalVariable.abortSet == true)
                        {
                            updateDisplay = false;
                            BItimer.Stop();
                            stresstestpowoff = true;
                            if (stresstestpowoff == true)
                            {
                                #region stresstest_powoff
                                if (GlobalVariable.iTsChannel <= 16)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);
                                }
                                else if (GlobalVariable.iTsChannel <= 32)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);
                                }
                                else if (GlobalVariable.iTsChannel <= 48)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);
                                }
                                else if (GlobalVariable.iTsChannel <= 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                else if (GlobalVariable.iTsChannel > 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                #endregion
                            }
                            hour = 0;
                            minute = 0;
                            second = 0;
                        }
                        #endregion}
                    }
                    LineItem test13 = graph13.GraphPane.AddCurve("", result13, Color.YellowGreen, SymbolType.None);
                    graph13.GraphPane.Title.Text = "Channel 13";
                    graph13.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                    graph13.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                    graph13.GraphPane.XAxis.Scale.Max = 402;
                    graph13.IsAutoScrollRange = true;
                    graph13.AxisChange();
                    graph13.Invalidate();
                    #endregion
                    #endregion
                    break;
                case "14":
                    #region Channel 14
                    #region New Graph method
                    PointPairList result14 = new PointPairList();
                    int i14 = 0;
                    foreach (double tempResult in LibPXI.subSweepResult)
                    {
                        result14.Add(i14, tempResult);
                        i14++;
                        #region GlobalVariable.abortSet == true
                        if (GlobalVariable.abortSet == true)
                        {
                            updateDisplay = false;
                            BItimer.Stop();
                            stresstestpowoff = true;
                            if (stresstestpowoff == true)
                            {
                                #region stresstest_powoff
                                if (GlobalVariable.iTsChannel <= 16)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);
                                }
                                else if (GlobalVariable.iTsChannel <= 32)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);
                                }
                                else if (GlobalVariable.iTsChannel <= 48)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);
                                }
                                else if (GlobalVariable.iTsChannel <= 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                else if (GlobalVariable.iTsChannel > 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                #endregion
                            }
                            hour = 0;
                            minute = 0;
                            second = 0;
                        }
                        #endregion}
                    }
                    LineItem test14 = graph14.GraphPane.AddCurve("", result14, Color.YellowGreen, SymbolType.None);
                    graph14.GraphPane.Title.Text = "Channel 14";
                    graph14.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                    graph14.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                    graph14.GraphPane.XAxis.Scale.Max = 402;
                    graph14.IsAutoScrollRange = true;
                    graph14.AxisChange();
                    graph14.Invalidate();
                    #endregion
                    #endregion
                    break;
                case "15":
                    #region Channel 15
                    #region New Graph method
                    PointPairList result15 = new PointPairList();
                    int i15 = 0;
                    foreach (double tempResult in LibPXI.subSweepResult)
                    {
                        result15.Add(i15, tempResult);
                        i15++;
                        #region GlobalVariable.abortSet == true
                        if (GlobalVariable.abortSet == true)
                        {
                            updateDisplay = false;
                            BItimer.Stop();
                            stresstestpowoff = true;
                            if (stresstestpowoff == true)
                            {
                                #region stresstest_powoff
                                if (GlobalVariable.iTsChannel <= 16)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);
                                }
                                else if (GlobalVariable.iTsChannel <= 32)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);
                                }
                                else if (GlobalVariable.iTsChannel <= 48)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);
                                }
                                else if (GlobalVariable.iTsChannel <= 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                else if (GlobalVariable.iTsChannel > 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                #endregion
                            }
                            hour = 0;
                            minute = 0;
                            second = 0;
                        }
                        #endregion}
                    }
                    LineItem test15 = graph15.GraphPane.AddCurve("", result15, Color.YellowGreen, SymbolType.None);
                    graph15.GraphPane.Title.Text = "Channel 15";
                    graph15.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                    graph15.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                    graph15.GraphPane.XAxis.Scale.Max = 402;
                    graph15.IsAutoScrollRange = true;
                    graph15.AxisChange();
                    graph15.Invalidate();
                    #endregion
                    #endregion
                    break;
                case "16":
                    #region Channel 16
                    #region New Graph method
                    PointPairList result16 = new PointPairList();
                    int i16 = 0;
                    foreach (double tempResult in LibPXI.subSweepResult)
                    {
                        result16.Add(i16, tempResult);
                        i16++;
                        #region GlobalVariable.abortSet == true
                        if (GlobalVariable.abortSet == true)
                        {
                            updateDisplay = false;
                            BItimer.Stop();
                            stresstestpowoff = true;
                            if (stresstestpowoff == true)
                            {
                                #region stresstest_powoff
                                if (GlobalVariable.iTsChannel <= 16)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);
                                }
                                else if (GlobalVariable.iTsChannel <= 32)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);
                                }
                                else if (GlobalVariable.iTsChannel <= 48)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);
                                }
                                else if (GlobalVariable.iTsChannel <= 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                else if (GlobalVariable.iTsChannel > 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                #endregion
                            }
                            hour = 0;
                            minute = 0;
                            second = 0;
                        }
                        #endregion}
                    }
                    LineItem test16 = graph16.GraphPane.AddCurve("", result16, Color.YellowGreen, SymbolType.None);
                    graph16.GraphPane.Title.Text = "Channel 16";
                    graph16.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                    graph16.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                    graph16.GraphPane.XAxis.Scale.Max = 402;
                    graph16.IsAutoScrollRange = true;
                    graph16.AxisChange();
                    graph16.Invalidate();
                    #endregion
                    #endregion
                    break;
                #endregion
                #region case17-32
                case "17":
                    #region Channel 17
                    #region New Graph method
                    PointPairList result17 = new PointPairList();
                    int i17 = 0;
                    foreach (double tempResult in LibPXI.subSweepResult)
                    {
                        result17.Add(i17, tempResult);
                        i17++;
                        #region GlobalVariable.abortSet == true
                        if (GlobalVariable.abortSet == true)
                        {
                            updateDisplay = false;
                            BItimer.Stop();
                            stresstestpowoff = true;
                            if (stresstestpowoff == true)
                            {
                                #region stresstest_powoff
                                if (GlobalVariable.iTsChannel <= 16)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);
                                }
                                else if (GlobalVariable.iTsChannel <= 32)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);
                                }
                                else if (GlobalVariable.iTsChannel <= 48)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);
                                }
                                else if (GlobalVariable.iTsChannel <= 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                else if (GlobalVariable.iTsChannel > 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                #endregion
                            }
                            hour = 0;
                            minute = 0;
                            second = 0;
                        }
                        #endregion}
                    }
                    LineItem test17 = graph17.GraphPane.AddCurve("", result17, Color.YellowGreen, SymbolType.None);
                    graph17.GraphPane.Title.Text = "Channel 17";
                    graph17.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                    graph17.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                    graph17.GraphPane.XAxis.Scale.Max = 402;
                    graph17.IsAutoScrollRange = true;
                    graph17.AxisChange();
                    graph17.Invalidate();
                    #endregion
                    #endregion
                    break;
                case "18":
                    #region Channel 18
                    #region New Graph method
                    PointPairList result18 = new PointPairList();
                    int i18 = 0;
                    foreach (double tempResult in LibPXI.subSweepResult)
                    {
                        result18.Add(i18, tempResult);
                        i18++;
                        #region GlobalVariable.abortSet == true
                        if (GlobalVariable.abortSet == true)
                        {
                            updateDisplay = false;
                            BItimer.Stop();
                            stresstestpowoff = true;
                            if (stresstestpowoff == true)
                            {
                                #region stresstest_powoff
                                if (GlobalVariable.iTsChannel <= 16)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);
                                }
                                else if (GlobalVariable.iTsChannel <= 32)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);
                                }
                                else if (GlobalVariable.iTsChannel <= 48)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);
                                }
                                else if (GlobalVariable.iTsChannel <= 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                else if (GlobalVariable.iTsChannel > 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                #endregion
                            }
                            hour = 0;
                            minute = 0;
                            second = 0;
                        }
                        #endregion}
                    }
                    LineItem test18 = graph18.GraphPane.AddCurve("", result18, Color.YellowGreen, SymbolType.None);
                    graph18.GraphPane.Title.Text = "Channel 18";
                    graph18.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                    graph18.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                    graph18.GraphPane.XAxis.Scale.Max = 402;
                    graph18.IsAutoScrollRange = true;
                    graph18.AxisChange();
                    graph18.Invalidate();
                    #endregion
                    #endregion
                    break;
                case "19":
                    #region Channel 19
                    #region New Graph method
                    PointPairList result19 = new PointPairList();
                    int i19 = 0;
                    foreach (double tempResult in LibPXI.subSweepResult)
                    {
                        result19.Add(i19, tempResult);
                        i19++;
                        #region GlobalVariable.abortSet == true
                        if (GlobalVariable.abortSet == true)
                        {
                            updateDisplay = false;
                            BItimer.Stop();
                            stresstestpowoff = true;
                            if (stresstestpowoff == true)
                            {
                                #region stresstest_powoff
                                if (GlobalVariable.iTsChannel <= 16)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);
                                }
                                else if (GlobalVariable.iTsChannel <= 32)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);
                                }
                                else if (GlobalVariable.iTsChannel <= 48)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);
                                }
                                else if (GlobalVariable.iTsChannel <= 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                else if (GlobalVariable.iTsChannel > 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                #endregion
                            }
                            hour = 0;
                            minute = 0;
                            second = 0;
                        }
                        #endregion}
                    }
                    LineItem test19 = graph19.GraphPane.AddCurve("", result19, Color.YellowGreen, SymbolType.None);
                    graph19.GraphPane.Title.Text = "Channel 19";
                    graph19.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                    graph19.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                    graph19.GraphPane.XAxis.Scale.Max = 402;
                    graph19.IsAutoScrollRange = true;
                    graph19.AxisChange();
                    graph19.Invalidate();
                    #endregion
                    #endregion
                    break;
                case "20":
                    #region Channel 20
                    #region New Graph method
                    PointPairList result20 = new PointPairList();
                    int i20 = 0;
                    foreach (double tempResult in LibPXI.subSweepResult)
                    {
                        result20.Add(i20, tempResult);
                        i20++;
                        #region GlobalVariable.abortSet == true
                        if (GlobalVariable.abortSet == true)
                        {
                            updateDisplay = false;
                            BItimer.Stop();
                            stresstestpowoff = true;
                            if (stresstestpowoff == true)
                            {
                                #region stresstest_powoff
                                if (GlobalVariable.iTsChannel <= 16)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);
                                }
                                else if (GlobalVariable.iTsChannel <= 32)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);
                                }
                                else if (GlobalVariable.iTsChannel <= 48)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);
                                }
                                else if (GlobalVariable.iTsChannel <= 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                else if (GlobalVariable.iTsChannel > 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                #endregion
                            }
                            hour = 0;
                            minute = 0;
                            second = 0;
                        }
                        #endregion}
                    }
                    LineItem test20 = graph20.GraphPane.AddCurve("", result20, Color.YellowGreen, SymbolType.None);
                    graph20.GraphPane.Title.Text = "Channel 20";
                    graph20.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                    graph20.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                    graph20.GraphPane.XAxis.Scale.Max = 402;
                    graph20.IsAutoScrollRange = true;
                    graph20.AxisChange();
                    graph20.Invalidate();
                    #endregion
                    #endregion
                    break;
                case "21":
                    #region Channel 21
                    #region New Graph method
                    PointPairList result21 = new PointPairList();
                    int i21 = 0;
                    foreach (double tempResult in LibPXI.subSweepResult)
                    {
                        result21.Add(i21, tempResult);
                        i21++;
                        #region GlobalVariable.abortSet == true
                        if (GlobalVariable.abortSet == true)
                        {
                            updateDisplay = false;
                            BItimer.Stop();
                            stresstestpowoff = true;
                            if (stresstestpowoff == true)
                            {
                                #region stresstest_powoff
                                if (GlobalVariable.iTsChannel <= 16)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);
                                }
                                else if (GlobalVariable.iTsChannel <= 32)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);
                                }
                                else if (GlobalVariable.iTsChannel <= 48)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);
                                }
                                else if (GlobalVariable.iTsChannel <= 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                else if (GlobalVariable.iTsChannel > 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                #endregion
                            }
                            hour = 0;
                            minute = 0;
                            second = 0;
                        }
                        #endregion}
                    }
                    LineItem test21 = graph21.GraphPane.AddCurve("", result21, Color.YellowGreen, SymbolType.None);
                    graph21.GraphPane.Title.Text = "Channel 21";
                    graph21.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                    graph21.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                    graph21.GraphPane.XAxis.Scale.Max = 402;
                    graph21.IsAutoScrollRange = true;
                    graph21.AxisChange();
                    graph21.Invalidate();
                    #endregion
                    #endregion
                    break;
                case "22":
                    #region Channel 22
                    #region New Graph method
                    PointPairList result22 = new PointPairList();
                    int i22 = 0;
                    foreach (double tempResult in LibPXI.subSweepResult)
                    {
                        result22.Add(i22, tempResult);
                        i22++;
                        #region GlobalVariable.abortSet == true
                        if (GlobalVariable.abortSet == true)
                        {
                            updateDisplay = false;
                            BItimer.Stop();
                            stresstestpowoff = true;
                            if (stresstestpowoff == true)
                            {
                                #region stresstest_powoff
                                if (GlobalVariable.iTsChannel <= 16)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);
                                }
                                else if (GlobalVariable.iTsChannel <= 32)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);
                                }
                                else if (GlobalVariable.iTsChannel <= 48)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);
                                }
                                else if (GlobalVariable.iTsChannel <= 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                else if (GlobalVariable.iTsChannel > 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                #endregion
                            }
                            hour = 0;
                            minute = 0;
                            second = 0;
                        }
                        #endregion}
                    }
                    LineItem test22 = graph22.GraphPane.AddCurve("", result22, Color.YellowGreen, SymbolType.None);
                    graph22.GraphPane.Title.Text = "Channel 22";
                    graph22.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                    graph22.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                    graph22.GraphPane.XAxis.Scale.Max = 402;
                    graph22.IsAutoScrollRange = true;
                    graph22.AxisChange();
                    graph22.Invalidate();
                    #endregion
                    #endregion
                    break;
                case "23":
                    #region Channel 23
                    #region New Graph method
                    PointPairList result23 = new PointPairList();
                    int i23 = 0;
                    foreach (double tempResult in LibPXI.subSweepResult)
                    {
                        result23.Add(i23, tempResult);
                        i23++;
                        #region GlobalVariable.abortSet == true
                        if (GlobalVariable.abortSet == true)
                        {
                            updateDisplay = false;
                            BItimer.Stop();
                            stresstestpowoff = true;
                            if (stresstestpowoff == true)
                            {
                                #region stresstest_powoff
                                if (GlobalVariable.iTsChannel <= 16)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);
                                }
                                else if (GlobalVariable.iTsChannel <= 32)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);
                                }
                                else if (GlobalVariable.iTsChannel <= 48)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);
                                }
                                else if (GlobalVariable.iTsChannel <= 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                else if (GlobalVariable.iTsChannel > 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                #endregion
                            }
                            hour = 0;
                            minute = 0;
                            second = 0;
                        }
                        #endregion}
                    }
                    LineItem test23 = graph23.GraphPane.AddCurve("", result23, Color.YellowGreen, SymbolType.None);
                    graph23.GraphPane.Title.Text = "Channel 23";
                    graph23.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                    graph23.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                    graph23.GraphPane.XAxis.Scale.Max = 402;
                    graph23.IsAutoScrollRange = true;
                    graph23.AxisChange();
                    graph23.Invalidate();
                    #endregion
                    #endregion
                    break;
                case "24":
                    #region Channel 24
                    #region New Graph method
                    PointPairList result24 = new PointPairList();
                    int i24 = 0;
                    foreach (double tempResult in LibPXI.subSweepResult)
                    {
                        result24.Add(i24, tempResult);
                        i24++;
                        #region GlobalVariable.abortSet == true
                        if (GlobalVariable.abortSet == true)
                        {
                            updateDisplay = false;
                            BItimer.Stop();
                            stresstestpowoff = true;
                            if (stresstestpowoff == true)
                            {
                                #region stresstest_powoff
                                if (GlobalVariable.iTsChannel <= 16)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);
                                }
                                else if (GlobalVariable.iTsChannel <= 32)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);
                                }
                                else if (GlobalVariable.iTsChannel <= 48)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);
                                }
                                else if (GlobalVariable.iTsChannel <= 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                else if (GlobalVariable.iTsChannel > 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                #endregion
                            }
                            hour = 0;
                            minute = 0;
                            second = 0;
                        }
                        #endregion}
                    }
                    LineItem test24 = graph24.GraphPane.AddCurve("", result24, Color.YellowGreen, SymbolType.None);
                    graph24.GraphPane.Title.Text = "Channel 24";
                    graph24.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                    graph24.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                    graph24.GraphPane.XAxis.Scale.Max = 402;
                    graph24.IsAutoScrollRange = true;
                    graph24.AxisChange();
                    graph24.Invalidate();
                    #endregion
                    #endregion
                    break;
                case "25":
                    #region Channel 25
                    #region New Graph method
                    PointPairList result25 = new PointPairList();
                    int i25 = 0;
                    foreach (double tempResult in LibPXI.subSweepResult)
                    {
                        result25.Add(i25, tempResult);
                        i25++;
                        #region GlobalVariable.abortSet == true
                        if (GlobalVariable.abortSet == true)
                        {
                            updateDisplay = false;
                            BItimer.Stop();
                            stresstestpowoff = true;
                            if (stresstestpowoff == true)
                            {
                                #region stresstest_powoff
                                if (GlobalVariable.iTsChannel <= 16)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);
                                }
                                else if (GlobalVariable.iTsChannel <= 32)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);
                                }
                                else if (GlobalVariable.iTsChannel <= 48)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);
                                }
                                else if (GlobalVariable.iTsChannel <= 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                else if (GlobalVariable.iTsChannel > 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                #endregion
                            }
                            hour = 0;
                            minute = 0;
                            second = 0;
                        }
                        #endregion}
                    }
                    LineItem test25 = graph25.GraphPane.AddCurve("", result25, Color.YellowGreen, SymbolType.None);
                    graph25.GraphPane.Title.Text = "Channel 25";
                    graph25.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                    graph25.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                    graph25.GraphPane.XAxis.Scale.Max = 402;
                    graph25.IsAutoScrollRange = true;
                    graph25.AxisChange();
                    graph25.Invalidate();
                    #endregion
                    #endregion
                    break;
                case "26":
                    #region Channel 26
                    #region New Graph method
                    PointPairList result26 = new PointPairList();
                    int i26 = 0;
                    foreach (double tempResult in LibPXI.subSweepResult)
                    {
                        result26.Add(i26, tempResult);
                        i26++;
                        #region GlobalVariable.abortSet == true
                        if (GlobalVariable.abortSet == true)
                        {
                            updateDisplay = false;
                            BItimer.Stop();
                            stresstestpowoff = true;
                            if (stresstestpowoff == true)
                            {
                                #region stresstest_powoff
                                if (GlobalVariable.iTsChannel <= 16)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);
                                }
                                else if (GlobalVariable.iTsChannel <= 32)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);
                                }
                                else if (GlobalVariable.iTsChannel <= 48)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);
                                }
                                else if (GlobalVariable.iTsChannel <= 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                else if (GlobalVariable.iTsChannel > 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                #endregion
                            }
                            hour = 0;
                            minute = 0;
                            second = 0;
                        }
                        #endregion}
                    }
                    LineItem test26 = graph26.GraphPane.AddCurve("", result26, Color.YellowGreen, SymbolType.None);
                    graph26.GraphPane.Title.Text = "Channel 26";
                    graph26.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                    graph26.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                    graph26.GraphPane.XAxis.Scale.Max = 402;
                    graph26.IsAutoScrollRange = true;
                    graph26.AxisChange();
                    graph26.Invalidate();
                    #endregion
                    #endregion
                    break;
                case "27":
                    #region Channel 27
                    #region New Graph method
                    PointPairList result27 = new PointPairList();
                    int i27 = 0;
                    foreach (double tempResult in LibPXI.subSweepResult)
                    {
                        result27.Add(i27, tempResult);
                        i27++;
                        #region GlobalVariable.abortSet == true
                        if (GlobalVariable.abortSet == true)
                        {
                            updateDisplay = false;
                            BItimer.Stop();
                            stresstestpowoff = true;
                            if (stresstestpowoff == true)
                            {
                                #region stresstest_powoff
                                if (GlobalVariable.iTsChannel <= 16)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);
                                }
                                else if (GlobalVariable.iTsChannel <= 32)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);
                                }
                                else if (GlobalVariable.iTsChannel <= 48)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);
                                }
                                else if (GlobalVariable.iTsChannel <= 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                else if (GlobalVariable.iTsChannel > 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                #endregion
                            }
                            hour = 0;
                            minute = 0;
                            second = 0;
                        }
                        #endregion}
                    }
                    LineItem test27 = graph27.GraphPane.AddCurve("", result27, Color.YellowGreen, SymbolType.None);
                    graph27.GraphPane.Title.Text = "Channel 27";
                    graph27.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                    graph27.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                    graph27.GraphPane.XAxis.Scale.Max = 402;
                    graph27.IsAutoScrollRange = true;
                    graph27.AxisChange();
                    graph27.Invalidate();
                    #endregion
                    #endregion
                    break;
                case "28":
                    #region Channel 28
                    #region New Graph method
                    PointPairList result28 = new PointPairList();
                    int i28 = 0;
                    foreach (double tempResult in LibPXI.subSweepResult)
                    {
                        result28.Add(i28, tempResult);
                        i28++;
                        #region GlobalVariable.abortSet == true
                        if (GlobalVariable.abortSet == true)
                        {
                            updateDisplay = false;
                            BItimer.Stop();
                            stresstestpowoff = true;
                            if (stresstestpowoff == true)
                            {
                                #region stresstest_powoff
                                if (GlobalVariable.iTsChannel <= 16)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);
                                }
                                else if (GlobalVariable.iTsChannel <= 32)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);
                                }
                                else if (GlobalVariable.iTsChannel <= 48)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);
                                }
                                else if (GlobalVariable.iTsChannel <= 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                else if (GlobalVariable.iTsChannel > 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                #endregion
                            }
                            hour = 0;
                            minute = 0;
                            second = 0;
                        }
                        #endregion}
                    }
                    LineItem test28 = graph28.GraphPane.AddCurve("", result28, Color.YellowGreen, SymbolType.None);
                    graph28.GraphPane.Title.Text = "Channel 28";
                    graph28.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                    graph28.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                    graph28.GraphPane.XAxis.Scale.Max = 402;
                    graph28.IsAutoScrollRange = true;
                    graph28.AxisChange();
                    graph28.Invalidate();
                    #endregion
                    #endregion
                    break;
                case "29":
                    #region Channel 29
                    #region New Graph method
                    PointPairList result29 = new PointPairList();
                    int i29 = 0;
                    foreach (double tempResult in LibPXI.subSweepResult)
                    {
                        result29.Add(i29, tempResult);
                        i29++;
                        #region GlobalVariable.abortSet == true
                        if (GlobalVariable.abortSet == true)
                        {
                            updateDisplay = false;
                            BItimer.Stop();
                            stresstestpowoff = true;
                            if (stresstestpowoff == true)
                            {
                                #region stresstest_powoff
                                if (GlobalVariable.iTsChannel <= 16)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);
                                }
                                else if (GlobalVariable.iTsChannel <= 32)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);
                                }
                                else if (GlobalVariable.iTsChannel <= 48)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);
                                }
                                else if (GlobalVariable.iTsChannel <= 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                else if (GlobalVariable.iTsChannel > 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                #endregion
                            }
                            hour = 0;
                            minute = 0;
                            second = 0;
                        }
                        #endregion}
                    }
                    LineItem test29 = graph29.GraphPane.AddCurve("", result29, Color.YellowGreen, SymbolType.None);
                    graph29.GraphPane.Title.Text = "Channel 29";
                    graph29.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                    graph29.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                    graph29.GraphPane.XAxis.Scale.Max = 402;
                    graph29.IsAutoScrollRange = true;
                    graph29.AxisChange();
                    graph29.Invalidate();
                    #endregion
                    #endregion
                    break;
                case "30":
                    #region Channel 30
                    #region New Graph method
                    PointPairList result30 = new PointPairList();
                    int i30 = 0;
                    foreach (double tempResult in LibPXI.subSweepResult)
                    {
                        result30.Add(i30, tempResult);
                        i30++;
                        #region GlobalVariable.abortSet == true
                        if (GlobalVariable.abortSet == true)
                        {
                            updateDisplay = false;
                            BItimer.Stop();
                            stresstestpowoff = true;
                            if (stresstestpowoff == true)
                            {
                                #region stresstest_powoff
                                if (GlobalVariable.iTsChannel <= 16)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);
                                }
                                else if (GlobalVariable.iTsChannel <= 32)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);
                                }
                                else if (GlobalVariable.iTsChannel <= 48)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);
                                }
                                else if (GlobalVariable.iTsChannel <= 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                else if (GlobalVariable.iTsChannel > 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                #endregion
                            }
                            hour = 0;
                            minute = 0;
                            second = 0;
                        }
                        #endregion}
                    }
                    LineItem test30 = graph30.GraphPane.AddCurve("", result30, Color.YellowGreen, SymbolType.None);
                    graph30.GraphPane.Title.Text = "Channel 30";
                    graph30.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                    graph30.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                    graph30.GraphPane.XAxis.Scale.Max = 402;
                    graph30.IsAutoScrollRange = true;
                    graph30.AxisChange();
                    graph30.Invalidate();
                    #endregion
                    #endregion
                    break;
                case "31":
                    #region Channel 31
                    #region New Graph method
                    PointPairList result31 = new PointPairList();
                    int i31 = 0;
                    foreach (double tempResult in LibPXI.subSweepResult)
                    {
                        result31.Add(i31, tempResult);
                        i31++;
                        #region GlobalVariable.abortSet == true
                        if (GlobalVariable.abortSet == true)
                        {
                            updateDisplay = false;
                            BItimer.Stop();
                            stresstestpowoff = true;
                            if (stresstestpowoff == true)
                            {
                                #region stresstest_powoff
                                if (GlobalVariable.iTsChannel <= 16)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);
                                }
                                else if (GlobalVariable.iTsChannel <= 32)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);
                                }
                                else if (GlobalVariable.iTsChannel <= 48)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);
                                }
                                else if (GlobalVariable.iTsChannel <= 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                else if (GlobalVariable.iTsChannel > 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                #endregion
                            }
                            hour = 0;
                            minute = 0;
                            second = 0;
                        }
                        #endregion}
                    }
                    LineItem test31 = graph31.GraphPane.AddCurve("", result31, Color.YellowGreen, SymbolType.None);
                    graph31.GraphPane.Title.Text = "Channel 31";
                    graph31.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                    graph31.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                    graph31.GraphPane.XAxis.Scale.Max = 402;
                    graph31.IsAutoScrollRange = true;
                    graph31.AxisChange();
                    graph31.Invalidate();
                    #endregion
                    #endregion
                    break;
                case "32":
                    #region Channel 32
                    #region New Graph method
                    PointPairList result32 = new PointPairList();
                    int i32 = 0;
                    foreach (double tempResult in LibPXI.subSweepResult)
                    {
                        result32.Add(i32, tempResult);
                        i32++;
                        #region GlobalVariable.abortSet == true
                        if (GlobalVariable.abortSet == true)
                        {
                            updateDisplay = false;
                            BItimer.Stop();
                            stresstestpowoff = true;
                            if (stresstestpowoff == true)
                            {
                                #region stresstest_powoff
                                if (GlobalVariable.iTsChannel <= 16)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);
                                }
                                else if (GlobalVariable.iTsChannel <= 32)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);
                                }
                                else if (GlobalVariable.iTsChannel <= 48)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);
                                }
                                else if (GlobalVariable.iTsChannel <= 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                else if (GlobalVariable.iTsChannel > 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                #endregion
                            }
                            hour = 0;
                            minute = 0;
                            second = 0;
                        }
                        #endregion}
                    }
                    LineItem test32 = graph32.GraphPane.AddCurve("", result32, Color.YellowGreen, SymbolType.None);
                    graph32.GraphPane.Title.Text = "Channel 32";
                    graph32.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                    graph32.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                    graph32.GraphPane.XAxis.Scale.Max = 402;
                    graph32.IsAutoScrollRange = true;
                    graph32.AxisChange();
                    graph32.Invalidate();
                    #endregion
                    #endregion
                    break;
                #endregion
                #region case33-48
                case "33":
                    #region Channel 33
                    #region New Graph method
                    PointPairList result33 = new PointPairList();
                    int i33 = 0;
                    foreach (double tempResult in LibPXI.subSweepResult)
                    {
                        result33.Add(i33, tempResult);
                        i33++;
                        #region GlobalVariable.abortSet == true
                        if (GlobalVariable.abortSet == true)
                        {
                            updateDisplay = false;
                            BItimer.Stop();
                            stresstestpowoff = true;
                            if (stresstestpowoff == true)
                            {
                                #region stresstest_powoff
                                if (GlobalVariable.iTsChannel <= 16)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);
                                }
                                else if (GlobalVariable.iTsChannel <= 32)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);
                                }
                                else if (GlobalVariable.iTsChannel <= 48)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);
                                }
                                else if (GlobalVariable.iTsChannel <= 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                else if (GlobalVariable.iTsChannel > 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                #endregion
                            }
                            hour = 0;
                            minute = 0;
                            second = 0;
                        }
                        #endregion}
                    }
                    LineItem test33 = graph33.GraphPane.AddCurve("", result33, Color.YellowGreen, SymbolType.None);
                    graph33.GraphPane.Title.Text = "Channel 33";
                    graph33.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                    graph33.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                    graph33.GraphPane.XAxis.Scale.Max = 402;
                    graph33.IsAutoScrollRange = true;
                    graph33.AxisChange();
                    graph33.Invalidate();
                    #endregion
                    #endregion
                    break;
                case "34":
                    #region Channel 34
                    #region New Graph method
                    PointPairList result34 = new PointPairList();
                    int i34 = 0;
                    foreach (double tempResult in LibPXI.subSweepResult)
                    {
                        result34.Add(i34, tempResult);
                        i34++;
                        #region GlobalVariable.abortSet == true
                        if (GlobalVariable.abortSet == true)
                        {
                            updateDisplay = false;
                            BItimer.Stop();
                            stresstestpowoff = true;
                            if (stresstestpowoff == true)
                            {
                                #region stresstest_powoff
                                if (GlobalVariable.iTsChannel <= 16)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);
                                }
                                else if (GlobalVariable.iTsChannel <= 32)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);
                                }
                                else if (GlobalVariable.iTsChannel <= 48)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);
                                }
                                else if (GlobalVariable.iTsChannel <= 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                else if (GlobalVariable.iTsChannel > 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                #endregion
                            }
                            hour = 0;
                            minute = 0;
                            second = 0;
                        }
                        #endregion}
                    }
                    LineItem test34 = graph34.GraphPane.AddCurve("", result34, Color.YellowGreen, SymbolType.None);
                    graph34.GraphPane.Title.Text = "Channel 34";
                    graph34.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                    graph34.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                    graph34.GraphPane.XAxis.Scale.Max = 402;
                    graph34.IsAutoScrollRange = true;
                    graph34.AxisChange();
                    graph34.Invalidate();
                    #endregion
                    #endregion
                    break;
                case "35":
                    #region Channel 35
                    #region New Graph method
                    PointPairList result35 = new PointPairList();
                    int i35 = 0;
                    foreach (double tempResult in LibPXI.subSweepResult)
                    {
                        result35.Add(i35, tempResult);
                        i35++;
                        #region GlobalVariable.abortSet == true
                        if (GlobalVariable.abortSet == true)
                        {
                            updateDisplay = false;
                            BItimer.Stop();
                            stresstestpowoff = true;
                            if (stresstestpowoff == true)
                            {
                                #region stresstest_powoff
                                if (GlobalVariable.iTsChannel <= 16)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);
                                }
                                else if (GlobalVariable.iTsChannel <= 32)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);
                                }
                                else if (GlobalVariable.iTsChannel <= 48)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);
                                }
                                else if (GlobalVariable.iTsChannel <= 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                else if (GlobalVariable.iTsChannel > 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                #endregion
                            }
                            hour = 0;
                            minute = 0;
                            second = 0;
                        }
                        #endregion}
                    }
                    LineItem test35 = graph35.GraphPane.AddCurve("", result35, Color.YellowGreen, SymbolType.None);
                    graph35.GraphPane.Title.Text = "Channel 35";
                    graph35.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                    graph35.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                    graph35.GraphPane.XAxis.Scale.Max = 402;
                    graph35.IsAutoScrollRange = true;
                    graph35.AxisChange();
                    graph35.Invalidate();
                    #endregion
                    #endregion
                    break;
                case "36":
                    #region Channel 36
                    #region New Graph method
                    PointPairList result36 = new PointPairList();
                    int i36 = 0;
                    foreach (double tempResult in LibPXI.subSweepResult)
                    {
                        result36.Add(i36, tempResult);
                        i36++;
                        #region GlobalVariable.abortSet == true
                        if (GlobalVariable.abortSet == true)
                        {
                            updateDisplay = false;
                            BItimer.Stop();
                            stresstestpowoff = true;
                            if (stresstestpowoff == true)
                            {
                                #region stresstest_powoff
                                if (GlobalVariable.iTsChannel <= 16)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);
                                }
                                else if (GlobalVariable.iTsChannel <= 32)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);
                                }
                                else if (GlobalVariable.iTsChannel <= 48)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);
                                }
                                else if (GlobalVariable.iTsChannel <= 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                else if (GlobalVariable.iTsChannel > 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                #endregion
                            }
                            hour = 0;
                            minute = 0;
                            second = 0;
                        }
                        #endregion}
                    }
                    LineItem test36 = graph36.GraphPane.AddCurve("", result36, Color.YellowGreen, SymbolType.None);
                    graph36.GraphPane.Title.Text = "Channel 36";
                    graph36.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                    graph36.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                    graph36.GraphPane.XAxis.Scale.Max = 402;
                    graph36.IsAutoScrollRange = true;
                    graph36.AxisChange();
                    graph36.Invalidate();
                    #endregion
                    #endregion
                    break;
                case "37":
                    #region Channel 37
                    #region New Graph method
                    PointPairList result37 = new PointPairList();
                    int i37 = 0;
                    foreach (double tempResult in LibPXI.subSweepResult)
                    {
                        result37.Add(i37, tempResult);
                        i37++;
                        #region GlobalVariable.abortSet == true
                        if (GlobalVariable.abortSet == true)
                        {
                            updateDisplay = false;
                            BItimer.Stop();
                            stresstestpowoff = true;
                            if (stresstestpowoff == true)
                            {
                                #region stresstest_powoff
                                if (GlobalVariable.iTsChannel <= 16)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);
                                }
                                else if (GlobalVariable.iTsChannel <= 32)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);
                                }
                                else if (GlobalVariable.iTsChannel <= 48)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);
                                }
                                else if (GlobalVariable.iTsChannel <= 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                else if (GlobalVariable.iTsChannel > 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                #endregion
                            }
                            hour = 0;
                            minute = 0;
                            second = 0;
                        }
                        #endregion}
                    }
                    LineItem test37 = graph37.GraphPane.AddCurve("", result37, Color.YellowGreen, SymbolType.None);
                    graph37.GraphPane.Title.Text = "Channel 37";
                    graph37.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                    graph37.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                    graph37.GraphPane.XAxis.Scale.Max = 402;
                    graph37.IsAutoScrollRange = true;
                    graph37.AxisChange();
                    graph37.Invalidate();
                    #endregion
                    #endregion
                    break;
                case "38":
                    #region Channel 38
                    #region New Graph method
                    PointPairList result38 = new PointPairList();
                    int i38 = 0;
                    foreach (double tempResult in LibPXI.subSweepResult)
                    {
                        result38.Add(i38, tempResult);
                        i38++;
                        #region GlobalVariable.abortSet == true
                        if (GlobalVariable.abortSet == true)
                        {
                            updateDisplay = false;
                            BItimer.Stop();
                            stresstestpowoff = true;
                            if (stresstestpowoff == true)
                            {
                                #region stresstest_powoff
                                if (GlobalVariable.iTsChannel <= 16)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);
                                }
                                else if (GlobalVariable.iTsChannel <= 32)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);
                                }
                                else if (GlobalVariable.iTsChannel <= 48)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);
                                }
                                else if (GlobalVariable.iTsChannel <= 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                else if (GlobalVariable.iTsChannel > 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                #endregion
                            }
                            hour = 0;
                            minute = 0;
                            second = 0;
                        }
                        #endregion}
                    }
                    LineItem test38 = graph38.GraphPane.AddCurve("", result38, Color.YellowGreen, SymbolType.None);
                    graph38.GraphPane.Title.Text = "Channel 38";
                    graph38.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                    graph38.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                    graph38.GraphPane.XAxis.Scale.Max = 402;
                    graph38.IsAutoScrollRange = true;
                    graph38.AxisChange();
                    graph38.Invalidate();
                    #endregion
                    #endregion
                    break;
                case "39":
                    #region Channel 39
                    #region New Graph method
                    PointPairList result39 = new PointPairList();
                    int i39 = 0;
                    foreach (double tempResult in LibPXI.subSweepResult)
                    {
                        result39.Add(i39, tempResult);
                        i39++;
                        #region GlobalVariable.abortSet == true
                        if (GlobalVariable.abortSet == true)
                        {
                            updateDisplay = false;
                            BItimer.Stop();
                            stresstestpowoff = true;
                            if (stresstestpowoff == true)
                            {
                                #region stresstest_powoff
                                if (GlobalVariable.iTsChannel <= 16)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);
                                }
                                else if (GlobalVariable.iTsChannel <= 32)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);
                                }
                                else if (GlobalVariable.iTsChannel <= 48)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);
                                }
                                else if (GlobalVariable.iTsChannel <= 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                else if (GlobalVariable.iTsChannel > 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                #endregion
                            }
                            hour = 0;
                            minute = 0;
                            second = 0;
                        }
                        #endregion}
                    }
                    LineItem test39 = graph39.GraphPane.AddCurve("", result39, Color.YellowGreen, SymbolType.None);
                    graph39.GraphPane.Title.Text = "Channel 39";
                    graph39.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                    graph39.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                    graph39.GraphPane.XAxis.Scale.Max = 402;
                    graph39.IsAutoScrollRange = true;
                    graph39.AxisChange();
                    graph39.Invalidate();
                    #endregion
                    #endregion
                    break;
                case "40":
                    #region Channel 40
                    #region New Graph method
                    PointPairList result40 = new PointPairList();
                    int i40 = 0;
                    foreach (double tempResult in LibPXI.subSweepResult)
                    {
                        result40.Add(i40, tempResult);
                        i40++;
                        #region GlobalVariable.abortSet == true
                        if (GlobalVariable.abortSet == true)
                        {
                            updateDisplay = false;
                            BItimer.Stop();
                            stresstestpowoff = true;
                            if (stresstestpowoff == true)
                            {
                                #region stresstest_powoff
                                if (GlobalVariable.iTsChannel <= 16)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);
                                }
                                else if (GlobalVariable.iTsChannel <= 32)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);
                                }
                                else if (GlobalVariable.iTsChannel <= 48)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);
                                }
                                else if (GlobalVariable.iTsChannel <= 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                else if (GlobalVariable.iTsChannel > 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                #endregion
                            }
                            hour = 0;
                            minute = 0;
                            second = 0;
                        }
                        #endregion}
                    }
                    LineItem test40 = graph40.GraphPane.AddCurve("", result40, Color.YellowGreen, SymbolType.None);
                    graph40.GraphPane.Title.Text = "Channel 40";
                    graph40.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                    graph40.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                    graph40.GraphPane.XAxis.Scale.Max = 402;
                    graph40.IsAutoScrollRange = true;
                    graph40.AxisChange();
                    graph40.Invalidate();
                    #endregion
                    #endregion
                    break;
                case "41":
                    #region Channel 41
                    #region New Graph method
                    PointPairList result41 = new PointPairList();
                    int i41 = 0;
                    foreach (double tempResult in LibPXI.subSweepResult)
                    {
                        result41.Add(i41, tempResult);
                        i41++;
                        #region GlobalVariable.abortSet == true
                        if (GlobalVariable.abortSet == true)
                        {
                            updateDisplay = false;
                            BItimer.Stop();
                            stresstestpowoff = true;
                            if (stresstestpowoff == true)
                            {
                                #region stresstest_powoff
                                if (GlobalVariable.iTsChannel <= 16)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);
                                }
                                else if (GlobalVariable.iTsChannel <= 32)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);
                                }
                                else if (GlobalVariable.iTsChannel <= 48)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);
                                }
                                else if (GlobalVariable.iTsChannel <= 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                else if (GlobalVariable.iTsChannel > 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                #endregion
                            }
                            hour = 0;
                            minute = 0;
                            second = 0;
                        }
                        #endregion}
                    }
                    LineItem test41 = graph41.GraphPane.AddCurve("", result41, Color.YellowGreen, SymbolType.None);
                    graph41.GraphPane.Title.Text = "Channel 41";
                    graph41.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                    graph41.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                    graph41.GraphPane.XAxis.Scale.Max = 402;
                    graph41.IsAutoScrollRange = true;
                    graph41.AxisChange();
                    graph41.Invalidate();
                    #endregion
                    #endregion
                    break;
                case "42":
                    #region Channel 42
                    #region New Graph method
                    PointPairList result42 = new PointPairList();
                    int i42 = 0;
                    foreach (double tempResult in LibPXI.subSweepResult)
                    {
                        result42.Add(i42, tempResult);
                        i42++;
                        #region GlobalVariable.abortSet == true
                        if (GlobalVariable.abortSet == true)
                        {
                            updateDisplay = false;
                            BItimer.Stop();
                            stresstestpowoff = true;
                            if (stresstestpowoff == true)
                            {
                                #region stresstest_powoff
                                if (GlobalVariable.iTsChannel <= 16)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);
                                }
                                else if (GlobalVariable.iTsChannel <= 32)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);
                                }
                                else if (GlobalVariable.iTsChannel <= 48)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);
                                }
                                else if (GlobalVariable.iTsChannel <= 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                else if (GlobalVariable.iTsChannel > 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                #endregion
                            }
                            hour = 0;
                            minute = 0;
                            second = 0;
                        }
                        #endregion}
                    }
                    LineItem test42 = graph42.GraphPane.AddCurve("", result42, Color.YellowGreen, SymbolType.None);
                    graph42.GraphPane.Title.Text = "Channel 42";
                    graph42.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                    graph42.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                    graph42.GraphPane.XAxis.Scale.Max = 402;
                    graph42.IsAutoScrollRange = true;
                    graph42.AxisChange();
                    graph42.Invalidate();
                    #endregion
                    #endregion
                    break;
                case "43":
                    #region Channel 43
                    #region New Graph method
                    PointPairList result43 = new PointPairList();
                    int i43 = 0;
                    foreach (double tempResult in LibPXI.subSweepResult)
                    {
                        result43.Add(i43, tempResult);
                        i43++;
                        #region GlobalVariable.abortSet == true
                        if (GlobalVariable.abortSet == true)
                        {
                            updateDisplay = false;
                            BItimer.Stop();
                            stresstestpowoff = true;
                            if (stresstestpowoff == true)
                            {
                                #region stresstest_powoff
                                if (GlobalVariable.iTsChannel <= 16)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);
                                }
                                else if (GlobalVariable.iTsChannel <= 32)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);
                                }
                                else if (GlobalVariable.iTsChannel <= 48)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);
                                }
                                else if (GlobalVariable.iTsChannel <= 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                else if (GlobalVariable.iTsChannel > 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                #endregion
                            }
                            hour = 0;
                            minute = 0;
                            second = 0;
                        }
                        #endregion}
                    }
                    LineItem test43 = graph43.GraphPane.AddCurve("", result43, Color.YellowGreen, SymbolType.None);
                    graph43.GraphPane.Title.Text = "Channel 43";
                    graph43.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                    graph43.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                    graph43.GraphPane.XAxis.Scale.Max = 402;
                    graph43.IsAutoScrollRange = true;
                    graph43.AxisChange();
                    graph43.Invalidate();
                    #endregion
                    #endregion
                    break;
                case "44":
                    #region Channel 44
                    #region New Graph method
                    PointPairList result44 = new PointPairList();
                    int i44 = 0;
                    foreach (double tempResult in LibPXI.subSweepResult)
                    {
                        result44.Add(i44, tempResult);
                        i44++;
                        #region GlobalVariable.abortSet == true
                        if (GlobalVariable.abortSet == true)
                        {
                            updateDisplay = false;
                            BItimer.Stop();
                            stresstestpowoff = true;
                            if (stresstestpowoff == true)
                            {
                                #region stresstest_powoff
                                if (GlobalVariable.iTsChannel <= 16)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);
                                }
                                else if (GlobalVariable.iTsChannel <= 32)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);
                                }
                                else if (GlobalVariable.iTsChannel <= 48)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);
                                }
                                else if (GlobalVariable.iTsChannel <= 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                else if (GlobalVariable.iTsChannel > 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                #endregion
                            }
                            hour = 0;
                            minute = 0;
                            second = 0;
                        }
                        #endregion}
                    }
                    LineItem test44 = graph44.GraphPane.AddCurve("", result44, Color.YellowGreen, SymbolType.None);
                    graph44.GraphPane.Title.Text = "Channel 44";
                    graph44.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                    graph44.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                    graph44.GraphPane.XAxis.Scale.Max = 402;
                    graph44.IsAutoScrollRange = true;
                    graph44.AxisChange();
                    graph44.Invalidate();
                    #endregion
                    #endregion
                    break;
                case "45":
                    #region Channel 45
                    #region New Graph method
                    PointPairList result45 = new PointPairList();
                    int i45 = 0;
                    foreach (double tempResult in LibPXI.subSweepResult)
                    {
                        result45.Add(i45, tempResult);
                        i45++;
                        #region GlobalVariable.abortSet == true
                        if (GlobalVariable.abortSet == true)
                        {
                            updateDisplay = false;
                            BItimer.Stop();
                            stresstestpowoff = true;
                            if (stresstestpowoff == true)
                            {
                                #region stresstest_powoff
                                if (GlobalVariable.iTsChannel <= 16)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);
                                }
                                else if (GlobalVariable.iTsChannel <= 32)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);
                                }
                                else if (GlobalVariable.iTsChannel <= 48)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);
                                }
                                else if (GlobalVariable.iTsChannel <= 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                else if (GlobalVariable.iTsChannel > 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                #endregion
                            }
                            hour = 0;
                            minute = 0;
                            second = 0;
                        }
                        #endregion}
                    }
                    LineItem test45 = graph45.GraphPane.AddCurve("", result45, Color.YellowGreen, SymbolType.None);
                    graph45.GraphPane.Title.Text = "Channel 45";
                    graph45.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                    graph45.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                    graph45.GraphPane.XAxis.Scale.Max = 402;
                    graph45.IsAutoScrollRange = true;
                    graph45.AxisChange();
                    graph45.Invalidate();
                    #endregion
                    #endregion
                    break;
                case "46":
                    #region Channel 46
                    #region New Graph method
                    PointPairList result46 = new PointPairList();
                    int i46 = 0;
                    foreach (double tempResult in LibPXI.subSweepResult)
                    {
                        result46.Add(i46, tempResult);
                        i46++;
                        #region GlobalVariable.abortSet == true
                        if (GlobalVariable.abortSet == true)
                        {
                            updateDisplay = false;
                            BItimer.Stop();
                            stresstestpowoff = true;
                            if (stresstestpowoff == true)
                            {
                                #region stresstest_powoff
                                if (GlobalVariable.iTsChannel <= 16)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);
                                }
                                else if (GlobalVariable.iTsChannel <= 32)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);
                                }
                                else if (GlobalVariable.iTsChannel <= 48)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);
                                }
                                else if (GlobalVariable.iTsChannel <= 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                else if (GlobalVariable.iTsChannel > 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                #endregion
                            }
                            hour = 0;
                            minute = 0;
                            second = 0;
                        }
                        #endregion}
                    }
                    LineItem test46 = graph46.GraphPane.AddCurve("", result46, Color.YellowGreen, SymbolType.None);
                    graph46.GraphPane.Title.Text = "Channel 46";
                    graph46.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                    graph46.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                    graph46.GraphPane.XAxis.Scale.Max = 402;
                    graph46.IsAutoScrollRange = true;
                    graph46.AxisChange();
                    graph46.Invalidate();
                    #endregion
                    #endregion
                    break;
                case "47":
                    #region Channel 47
                    #region New Graph method
                    PointPairList result47 = new PointPairList();
                    int i47 = 0;
                    foreach (double tempResult in LibPXI.subSweepResult)
                    {
                        result47.Add(i47, tempResult);
                        i47++;
                        #region GlobalVariable.abortSet == true
                        if (GlobalVariable.abortSet == true)
                        {
                            updateDisplay = false;
                            BItimer.Stop();
                            stresstestpowoff = true;
                            if (stresstestpowoff == true)
                            {
                                #region stresstest_powoff
                                if (GlobalVariable.iTsChannel <= 16)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);
                                }
                                else if (GlobalVariable.iTsChannel <= 32)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);
                                }
                                else if (GlobalVariable.iTsChannel <= 48)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);
                                }
                                else if (GlobalVariable.iTsChannel <= 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                else if (GlobalVariable.iTsChannel > 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                #endregion
                            }
                            hour = 0;
                            minute = 0;
                            second = 0;
                        }
                        #endregion}
                    }
                    LineItem test47 = graph47.GraphPane.AddCurve("", result47, Color.YellowGreen, SymbolType.None);
                    graph47.GraphPane.Title.Text = "Channel 47";
                    graph47.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                    graph47.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                    graph47.GraphPane.XAxis.Scale.Max = 402;
                    graph47.IsAutoScrollRange = true;
                    graph47.AxisChange();
                    graph47.Invalidate();
                    #endregion
                    #endregion
                    break;
                case "48":
                    #region Channel 48
                    #region New Graph method
                    PointPairList result48 = new PointPairList();
                    int i48 = 0;
                    foreach (double tempResult in LibPXI.subSweepResult)
                    {
                        result48.Add(i48, tempResult);
                        i48++;
                        #region GlobalVariable.abortSet == true
                        if (GlobalVariable.abortSet == true)
                        {
                            updateDisplay = false;
                            BItimer.Stop();
                            stresstestpowoff = true;
                            if (stresstestpowoff == true)
                            {
                                #region stresstest_powoff
                                if (GlobalVariable.iTsChannel <= 16)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);
                                }
                                else if (GlobalVariable.iTsChannel <= 32)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);
                                }
                                else if (GlobalVariable.iTsChannel <= 48)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);
                                }
                                else if (GlobalVariable.iTsChannel <= 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                else if (GlobalVariable.iTsChannel > 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                #endregion
                            }
                            hour = 0;
                            minute = 0;
                            second = 0;
                        }
                        #endregion}
                    }
                    LineItem test48 = graph48.GraphPane.AddCurve("", result48, Color.YellowGreen, SymbolType.None);
                    graph48.GraphPane.Title.Text = "Channel 48";
                    graph48.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                    graph48.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                    graph48.GraphPane.XAxis.Scale.Max = 402;
                    graph48.IsAutoScrollRange = true;
                    graph48.AxisChange();
                    graph48.Invalidate();
                    #endregion
                    #endregion
                    break;
                #endregion
                #region case49-64
                case "49":
                    #region Channel 49
                    #region New Graph method
                    PointPairList result49 = new PointPairList();
                    int i49 = 0;
                    foreach (double tempResult in LibPXI.subSweepResult)
                    {
                        result49.Add(i49, tempResult);
                        i49++;
                        #region GlobalVariable.abortSet == true
                        if (GlobalVariable.abortSet == true)
                        {
                            updateDisplay = false;
                            BItimer.Stop();
                            stresstestpowoff = true;
                            if (stresstestpowoff == true)
                            {
                                #region stresstest_powoff
                                if (GlobalVariable.iTsChannel <= 16)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);
                                }
                                else if (GlobalVariable.iTsChannel <= 32)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);
                                }
                                else if (GlobalVariable.iTsChannel <= 48)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);
                                }
                                else if (GlobalVariable.iTsChannel <= 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                else if (GlobalVariable.iTsChannel > 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                #endregion
                            }
                            hour = 0;
                            minute = 0;
                            second = 0;
                        }
                        #endregion}
                    }
                    LineItem test49 = graph49.GraphPane.AddCurve("", result49, Color.YellowGreen, SymbolType.None);
                    graph49.GraphPane.Title.Text = "Channel 49";
                    graph49.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                    graph49.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                    graph49.GraphPane.XAxis.Scale.Max = 402;
                    graph49.IsAutoScrollRange = true;
                    graph49.AxisChange();
                    graph49.Invalidate();
                    #endregion
                    #endregion
                    break;
                case "50":
                    #region Channel 50
                    #region New Graph method
                    PointPairList result50 = new PointPairList();
                    int i50 = 0;
                    foreach (double tempResult in LibPXI.subSweepResult)
                    {
                        result50.Add(i50, tempResult);
                        i50++;
                        #region GlobalVariable.abortSet == true
                        if (GlobalVariable.abortSet == true)
                        {
                            updateDisplay = false;
                            BItimer.Stop();
                            stresstestpowoff = true;
                            if (stresstestpowoff == true)
                            {
                                #region stresstest_powoff
                                if (GlobalVariable.iTsChannel <= 16)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);
                                }
                                else if (GlobalVariable.iTsChannel <= 32)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);
                                }
                                else if (GlobalVariable.iTsChannel <= 48)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);
                                }
                                else if (GlobalVariable.iTsChannel <= 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                else if (GlobalVariable.iTsChannel > 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                #endregion
                            }
                            hour = 0;
                            minute = 0;
                            second = 0;
                        }
                        #endregion}
                    }
                    LineItem test50 = graph50.GraphPane.AddCurve("", result50, Color.YellowGreen, SymbolType.None);
                    graph50.GraphPane.Title.Text = "Channel 50";
                    graph50.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                    graph50.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                    graph50.GraphPane.XAxis.Scale.Max = 402;
                    graph50.IsAutoScrollRange = true;
                    graph50.AxisChange();
                    graph10.Invalidate();
                    #endregion
                    #endregion
                    break;
                case "51":
                    #region Channel 51
                    #region New Graph method
                    PointPairList result51 = new PointPairList();
                    int i51 = 0;
                    foreach (double tempResult in LibPXI.subSweepResult)
                    {
                        result51.Add(i51, tempResult);
                        i51++;
                        #region GlobalVariable.abortSet == true
                        if (GlobalVariable.abortSet == true)
                        {
                            updateDisplay = false;
                            BItimer.Stop();
                            stresstestpowoff = true;
                            if (stresstestpowoff == true)
                            {
                                #region stresstest_powoff
                                if (GlobalVariable.iTsChannel <= 16)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);
                                }
                                else if (GlobalVariable.iTsChannel <= 32)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);
                                }
                                else if (GlobalVariable.iTsChannel <= 48)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);
                                }
                                else if (GlobalVariable.iTsChannel <= 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                else if (GlobalVariable.iTsChannel > 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                #endregion
                            }
                            hour = 0;
                            minute = 0;
                            second = 0;
                        }
                        #endregion}
                    }
                    LineItem test51 = graph51.GraphPane.AddCurve("", result51, Color.YellowGreen, SymbolType.None);
                    graph51.GraphPane.Title.Text = "Channel 51";
                    graph51.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                    graph51.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                    graph51.GraphPane.XAxis.Scale.Max = 402;
                    graph51.IsAutoScrollRange = true;
                    graph51.AxisChange();
                    graph51.Invalidate();
                    #endregion
                    #endregion
                    break;
                case "52":
                    #region Channel 52
                    #region New Graph method
                    PointPairList result52 = new PointPairList();
                    int i52 = 0;
                    foreach (double tempResult in LibPXI.subSweepResult)
                    {
                        result52.Add(i52, tempResult);
                        i52++;
                        #region GlobalVariable.abortSet == true
                        if (GlobalVariable.abortSet == true)
                        {
                            updateDisplay = false;
                            BItimer.Stop();
                            stresstestpowoff = true;
                            if (stresstestpowoff == true)
                            {
                                #region stresstest_powoff
                                if (GlobalVariable.iTsChannel <= 16)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);
                                }
                                else if (GlobalVariable.iTsChannel <= 32)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);
                                }
                                else if (GlobalVariable.iTsChannel <= 48)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);
                                }
                                else if (GlobalVariable.iTsChannel <= 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                else if (GlobalVariable.iTsChannel > 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                #endregion
                            }
                            hour = 0;
                            minute = 0;
                            second = 0;
                        }
                        #endregion}
                    }
                    LineItem test52 = graph52.GraphPane.AddCurve("", result52, Color.YellowGreen, SymbolType.None);
                    graph52.GraphPane.Title.Text = "Channel 52";
                    graph52.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                    graph52.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                    graph52.GraphPane.XAxis.Scale.Max = 402;
                    graph52.IsAutoScrollRange = true;
                    graph52.AxisChange();
                    graph52.Invalidate();
                    #endregion
                    #endregion
                    break;
                case "53":
                    #region Channel 53
                    #region New Graph method
                    PointPairList result53 = new PointPairList();
                    int i53 = 0;
                    foreach (double tempResult in LibPXI.subSweepResult)
                    {
                        result53.Add(i53, tempResult);
                        i53++;
                        #region GlobalVariable.abortSet == true
                        if (GlobalVariable.abortSet == true)
                        {
                            updateDisplay = false;
                            BItimer.Stop();
                            stresstestpowoff = true;
                            if (stresstestpowoff == true)
                            {
                                #region stresstest_powoff
                                if (GlobalVariable.iTsChannel <= 16)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);
                                }
                                else if (GlobalVariable.iTsChannel <= 32)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);
                                }
                                else if (GlobalVariable.iTsChannel <= 48)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);
                                }
                                else if (GlobalVariable.iTsChannel <= 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                else if (GlobalVariable.iTsChannel > 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                #endregion
                            }
                            hour = 0;
                            minute = 0;
                            second = 0;
                        }
                        #endregion}
                    }
                    LineItem test53 = graph53.GraphPane.AddCurve("", result53, Color.YellowGreen, SymbolType.None);
                    graph53.GraphPane.Title.Text = "Channel 53";
                    graph53.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                    graph53.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                    graph53.GraphPane.XAxis.Scale.Max = 402;
                    graph53.IsAutoScrollRange = true;
                    graph53.AxisChange();
                    graph53.Invalidate();
                    #endregion
                    #endregion
                    break;
                case "54":
                    #region Channel 54
                    #region New Graph method
                    PointPairList result54 = new PointPairList();
                    int i54 = 0;
                    foreach (double tempResult in LibPXI.subSweepResult)
                    {
                        result54.Add(i54, tempResult);
                        i54++;
                        #region GlobalVariable.abortSet == true
                        if (GlobalVariable.abortSet == true)
                        {
                            updateDisplay = false;
                            BItimer.Stop();
                            stresstestpowoff = true;
                            if (stresstestpowoff == true)
                            {
                                #region stresstest_powoff
                                if (GlobalVariable.iTsChannel <= 16)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);
                                }
                                else if (GlobalVariable.iTsChannel <= 32)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);
                                }
                                else if (GlobalVariable.iTsChannel <= 48)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);
                                }
                                else if (GlobalVariable.iTsChannel <= 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                else if (GlobalVariable.iTsChannel > 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                #endregion
                            }
                            hour = 0;
                            minute = 0;
                            second = 0;
                        }
                        #endregion}
                    }
                    LineItem test54 = graph54.GraphPane.AddCurve("", result54, Color.YellowGreen, SymbolType.None);
                    graph54.GraphPane.Title.Text = "Channel 54";
                    graph54.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                    graph54.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                    graph54.GraphPane.XAxis.Scale.Max = 402;
                    graph54.IsAutoScrollRange = true;
                    graph54.AxisChange();
                    graph54.Invalidate();
                    #endregion
                    #endregion
                    break;
                case "55":
                    #region Channel 55
                    #region New Graph method
                    PointPairList result55 = new PointPairList();
                    int i55 = 0;
                    foreach (double tempResult in LibPXI.subSweepResult)
                    {
                        result55.Add(i55, tempResult);
                        i55++;
                        #region GlobalVariable.abortSet == true
                        if (GlobalVariable.abortSet == true)
                        {
                            updateDisplay = false;
                            BItimer.Stop();
                            stresstestpowoff = true;
                            if (stresstestpowoff == true)
                            {
                                #region stresstest_powoff
                                if (GlobalVariable.iTsChannel <= 16)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);
                                }
                                else if (GlobalVariable.iTsChannel <= 32)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);
                                }
                                else if (GlobalVariable.iTsChannel <= 48)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);
                                }
                                else if (GlobalVariable.iTsChannel <= 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                else if (GlobalVariable.iTsChannel > 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                #endregion
                            }
                            hour = 0;
                            minute = 0;
                            second = 0;
                        }
                        #endregion}
                    }
                    LineItem test55 = graph55.GraphPane.AddCurve("", result55, Color.YellowGreen, SymbolType.None);
                    graph55.GraphPane.Title.Text = "Channel 55";
                    graph55.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                    graph55.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                    graph55.GraphPane.XAxis.Scale.Max = 402;
                    graph55.IsAutoScrollRange = true;
                    graph55.AxisChange();
                    graph55.Invalidate();
                    #endregion
                    #endregion
                    break;
                case "56":
                    #region Channel 56
                    #region New Graph method
                    PointPairList result56 = new PointPairList();
                    int i56 = 0;
                    foreach (double tempResult in LibPXI.subSweepResult)
                    {
                        result56.Add(i56, tempResult);
                        i56++;
                        #region GlobalVariable.abortSet == true
                        if (GlobalVariable.abortSet == true)
                        {
                            updateDisplay = false;
                            BItimer.Stop();
                            stresstestpowoff = true;
                            if (stresstestpowoff == true)
                            {
                                #region stresstest_powoff
                                if (GlobalVariable.iTsChannel <= 16)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);
                                }
                                else if (GlobalVariable.iTsChannel <= 32)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);
                                }
                                else if (GlobalVariable.iTsChannel <= 48)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);
                                }
                                else if (GlobalVariable.iTsChannel <= 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                else if (GlobalVariable.iTsChannel > 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                #endregion
                            }
                            hour = 0;
                            minute = 0;
                            second = 0;
                        }
                        #endregion}
                    }
                    LineItem test56 = graph56.GraphPane.AddCurve("", result56, Color.YellowGreen, SymbolType.None);
                    graph56.GraphPane.Title.Text = "Channel 56";
                    graph56.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                    graph56.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                    graph56.GraphPane.XAxis.Scale.Max = 402;
                    graph56.IsAutoScrollRange = true;
                    graph56.AxisChange();
                    graph56.Invalidate();
                    #endregion
                    #endregion
                    break;
                case "57":
                    #region Channel 57
                    #region New Graph method
                    PointPairList result57 = new PointPairList();
                    int i57 = 0;
                    foreach (double tempResult in LibPXI.subSweepResult)
                    {
                        result57.Add(i57, tempResult);
                        i57++;
                        #region GlobalVariable.abortSet == true
                        if (GlobalVariable.abortSet == true)
                        {
                            updateDisplay = false;
                            BItimer.Stop();
                            stresstestpowoff = true;
                            if (stresstestpowoff == true)
                            {
                                #region stresstest_powoff
                                if (GlobalVariable.iTsChannel <= 16)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);
                                }
                                else if (GlobalVariable.iTsChannel <= 32)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);
                                }
                                else if (GlobalVariable.iTsChannel <= 48)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);
                                }
                                else if (GlobalVariable.iTsChannel <= 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                else if (GlobalVariable.iTsChannel > 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                #endregion
                            }
                            hour = 0;
                            minute = 0;
                            second = 0;
                        }
                        #endregion}
                    }
                    LineItem test57 = graph57.GraphPane.AddCurve("", result57, Color.YellowGreen, SymbolType.None);
                    graph57.GraphPane.Title.Text = "Channel 57";
                    graph57.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                    graph57.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                    graph57.GraphPane.XAxis.Scale.Max = 402;
                    graph57.IsAutoScrollRange = true;
                    graph57.AxisChange();
                    graph57.Invalidate();
                    #endregion
                    #endregion
                    break;
                case "58":
                    #region Channel 58
                    #region New Graph method
                    PointPairList result58 = new PointPairList();
                    int i58 = 0;
                    foreach (double tempResult in LibPXI.subSweepResult)
                    {
                        result58.Add(i58, tempResult);
                        i58++;
                        #region GlobalVariable.abortSet == true
                        if (GlobalVariable.abortSet == true)
                        {
                            updateDisplay = false;
                            BItimer.Stop();
                            stresstestpowoff = true;
                            if (stresstestpowoff == true)
                            {
                                #region stresstest_powoff
                                if (GlobalVariable.iTsChannel <= 16)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);
                                }
                                else if (GlobalVariable.iTsChannel <= 32)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);
                                }
                                else if (GlobalVariable.iTsChannel <= 48)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);
                                }
                                else if (GlobalVariable.iTsChannel <= 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                else if (GlobalVariable.iTsChannel > 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                #endregion
                            }
                            hour = 0;
                            minute = 0;
                            second = 0;
                        }
                        #endregion}
                    }
                    LineItem test58 = graph58.GraphPane.AddCurve("", result58, Color.YellowGreen, SymbolType.None);
                    graph58.GraphPane.Title.Text = "Channel 58";
                    graph58.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                    graph58.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                    graph58.GraphPane.XAxis.Scale.Max = 402;
                    graph58.IsAutoScrollRange = true;
                    graph58.AxisChange();
                    graph58.Invalidate();
                    #endregion
                    #endregion
                    break;
                case "59":
                    #region Channel 59
                    #region New Graph method
                    PointPairList result59 = new PointPairList();
                    int i59 = 0;
                    foreach (double tempResult in LibPXI.subSweepResult)
                    {
                        result59.Add(i59, tempResult);
                        i59++;
                        #region GlobalVariable.abortSet == true
                        if (GlobalVariable.abortSet == true)
                        {
                            updateDisplay = false;
                            BItimer.Stop();
                            stresstestpowoff = true;
                            if (stresstestpowoff == true)
                            {
                                #region stresstest_powoff
                                if (GlobalVariable.iTsChannel <= 16)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);
                                }
                                else if (GlobalVariable.iTsChannel <= 32)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);
                                }
                                else if (GlobalVariable.iTsChannel <= 48)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);
                                }
                                else if (GlobalVariable.iTsChannel <= 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                else if (GlobalVariable.iTsChannel > 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                #endregion
                            }
                            hour = 0;
                            minute = 0;
                            second = 0;
                        }
                        #endregion}
                    }
                    LineItem test59 = graph59.GraphPane.AddCurve("", result59, Color.YellowGreen, SymbolType.None);
                    graph59.GraphPane.Title.Text = "Channel 59";
                    graph59.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                    graph59.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                    graph59.GraphPane.XAxis.Scale.Max = 402;
                    graph59.IsAutoScrollRange = true;
                    graph59.AxisChange();
                    graph59.Invalidate();
                    #endregion
                    #endregion
                    break;
                case "60":
                    #region Channel 60
                    #region New Graph method
                    PointPairList result60 = new PointPairList();
                    int i60 = 0;
                    foreach (double tempResult in LibPXI.subSweepResult)
                    {
                        result60.Add(i60, tempResult);
                        i60++;
                        #region GlobalVariable.abortSet == true
                        if (GlobalVariable.abortSet == true)
                        {
                            updateDisplay = false;
                            BItimer.Stop();
                            stresstestpowoff = true;
                            if (stresstestpowoff == true)
                            {
                                #region stresstest_powoff
                                if (GlobalVariable.iTsChannel <= 16)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);
                                }
                                else if (GlobalVariable.iTsChannel <= 32)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);
                                }
                                else if (GlobalVariable.iTsChannel <= 48)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);
                                }
                                else if (GlobalVariable.iTsChannel <= 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                else if (GlobalVariable.iTsChannel > 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                #endregion
                            }
                            hour = 0;
                            minute = 0;
                            second = 0;
                        }
                        #endregion}
                    }
                    LineItem test60 = graph60.GraphPane.AddCurve("", result60, Color.YellowGreen, SymbolType.None);
                    graph60.GraphPane.Title.Text = "Channel 60";
                    graph60.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                    graph60.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                    graph60.GraphPane.XAxis.Scale.Max = 402;
                    graph60.IsAutoScrollRange = true;
                    graph60.AxisChange();
                    graph60.Invalidate();
                    #endregion
                    #endregion
                    break;
                case "61":
                    #region Channel 61
                    #region New Graph method
                    PointPairList result61 = new PointPairList();
                    int i61 = 0;
                    foreach (double tempResult in LibPXI.subSweepResult)
                    {
                        result61.Add(i61, tempResult);
                        i61++;
                        #region GlobalVariable.abortSet == true
                        if (GlobalVariable.abortSet == true)
                        {
                            updateDisplay = false;
                            BItimer.Stop();
                            stresstestpowoff = true;
                            if (stresstestpowoff == true)
                            {
                                #region stresstest_powoff
                                if (GlobalVariable.iTsChannel <= 16)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);
                                }
                                else if (GlobalVariable.iTsChannel <= 32)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);
                                }
                                else if (GlobalVariable.iTsChannel <= 48)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);
                                }
                                else if (GlobalVariable.iTsChannel <= 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                else if (GlobalVariable.iTsChannel > 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                #endregion
                            }
                            hour = 0;
                            minute = 0;
                            second = 0;
                        }
                        #endregion}
                    }
                    LineItem test61 = graph61.GraphPane.AddCurve("", result61, Color.YellowGreen, SymbolType.None);
                    graph61.GraphPane.Title.Text = "Channel 61";
                    graph61.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                    graph61.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                    graph61.GraphPane.XAxis.Scale.Max = 402;
                    graph61.IsAutoScrollRange = true;
                    graph61.AxisChange();
                    graph61.Invalidate();
                    #endregion

                    #endregion
                    break;
                case "62":
                    #region Channel 62
                    #region New Graph method
                    PointPairList result62 = new PointPairList();
                    int i62 = 0;
                    foreach (double tempResult in LibPXI.subSweepResult)
                    {
                        result62.Add(i62, tempResult);
                        i62++;
                        #region GlobalVariable.abortSet == true
                        if (GlobalVariable.abortSet == true)
                        {
                            updateDisplay = false;
                            BItimer.Stop();
                            stresstestpowoff = true;
                            if (stresstestpowoff == true)
                            {
                                #region stresstest_powoff
                                if (GlobalVariable.iTsChannel <= 16)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);
                                }
                                else if (GlobalVariable.iTsChannel <= 32)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);
                                }
                                else if (GlobalVariable.iTsChannel <= 48)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);
                                }
                                else if (GlobalVariable.iTsChannel <= 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                else if (GlobalVariable.iTsChannel > 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                #endregion
                            }
                            hour = 0;
                            minute = 0;
                            second = 0;
                        }
                        #endregion}
                    }
                    LineItem test62 = graph62.GraphPane.AddCurve("", result62, Color.YellowGreen, SymbolType.None);
                    graph62.GraphPane.Title.Text = "Channel 62";
                    graph62.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                    graph62.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                    graph62.GraphPane.XAxis.Scale.Max = 402;
                    graph62.IsAutoScrollRange = true;
                    graph62.AxisChange();
                    graph62.Invalidate();
                    #endregion

                    #endregion
                    break;
                case "63":
                    #region Channel 63
                    #region New Graph method
                    PointPairList result63 = new PointPairList();
                    int i63 = 0;
                    foreach (double tempResult in LibPXI.subSweepResult)
                    {
                        result63.Add(i63, tempResult);
                        i63++;
                        #region GlobalVariable.abortSet == true
                        if (GlobalVariable.abortSet == true)
                        {
                            updateDisplay = false;
                            BItimer.Stop();
                            stresstestpowoff = true;
                            if (stresstestpowoff == true)
                            {
                                #region stresstest_powoff
                                if (GlobalVariable.iTsChannel <= 16)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);
                                }
                                else if (GlobalVariable.iTsChannel <= 32)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);
                                }
                                else if (GlobalVariable.iTsChannel <= 48)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);
                                }
                                else if (GlobalVariable.iTsChannel <= 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                else if (GlobalVariable.iTsChannel > 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                #endregion
                            }
                            hour = 0;
                            minute = 0;
                            second = 0;
                        }
                        #endregion}
                    }
                    LineItem test63 = graph63.GraphPane.AddCurve("", result63, Color.YellowGreen, SymbolType.None);
                    graph63.GraphPane.Title.Text = "Channel 63";
                    graph63.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                    graph63.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                    graph63.GraphPane.XAxis.Scale.Max = 402;
                    graph63.IsAutoScrollRange = true;
                    graph63.AxisChange();
                    graph63.Invalidate();
                    #endregion
                    #endregion
                    break;
                case "64":
                    #region Channel 64
                    #region New Graph method
                    PointPairList result64 = new PointPairList();
                    int i64 = 0;
                    foreach (double tempResult in LibPXI.subSweepResult)
                    {
                        result64.Add(i64, tempResult);
                        i64++;
                        #region GlobalVariable.abortSet == true
                        if (GlobalVariable.abortSet == true)
                        {
                            updateDisplay = false;
                            BItimer.Stop();
                            stresstestpowoff = true;
                            if (stresstestpowoff == true)
                            {
                                #region stresstest_powoff
                                if (GlobalVariable.iTsChannel <= 16)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);
                                }
                                else if (GlobalVariable.iTsChannel <= 32)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);
                                }
                                else if (GlobalVariable.iTsChannel <= 48)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);
                                }
                                else if (GlobalVariable.iTsChannel <= 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                else if (GlobalVariable.iTsChannel > 64)
                                {

                                    LibPXI.StressTest_PowOff(Sg_Unit[0]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[1]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[2]);

                                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                                }
                                #endregion
                            }
                            hour = 0;
                            minute = 0;
                            second = 0;
                        }
                        #endregion}
                    }
                    LineItem test64 = graph64.GraphPane.AddCurve("", result64, Color.YellowGreen, SymbolType.None);
                    graph64.GraphPane.Title.Text = "Channel 64";
                    graph64.GraphPane.XAxis.Title.Text = "Frequency(MHz)";
                    graph64.GraphPane.YAxis.Title.Text = "Signal Strength(dBm)";
                    graph64.GraphPane.XAxis.Scale.Max = 402;
                    graph64.IsAutoScrollRange = true;
                    graph64.AxisChange();
                    graph64.Invalidate();
                    //bool stresstestpowon = true;
                    #endregion
                    #endregion
                    break;
                #endregion
                default:
                    MessageBox.Show("Didn't have this Channel", "Error", MessageBoxButtons.OK);
                    break;
            }

            //updateDisplay           = true; 
            //BItimer.Start();
            //GlobalVariable.abortSet = false;

            //DateTime TimetoNextMeas = DateTime.Now;
            //if (GlobalVariable.iDelayTimeMs < 1)
            //{
            //    string DtTimetoNextMeas = TimetoNextMeas.AddMinutes(Convert.ToSingle(_txtBIInterval.Text)).ToString("HH:mm:ss");
            //    _txtTimeToNextMeas.Text = DtTimetoNextMeas;
            //}
            //else if (GlobalVariable.iDelayTimeMs >= 1)
            //{
            //    string DtTimetoNextMeas = TimetoNextMeas.AddHours(Convert.ToSingle(_txtBIInterval.Text)).ToString("HH:mm:ss");
            //    _txtTimeToNextMeas.Text = DtTimetoNextMeas;
            //}  
            #endregion
        }

        //stress test power on 
        private void stresstest_powon()
        {
            double freqMHz1 = Convert.ToDouble(_txtStressFreq1MHz.Text);
            double freqMHz2 = Convert.ToDouble(_txtStressFreq2MHz.Text);
            double freqMHz3 = Convert.ToDouble(_txtStressFreq3MHz.Text);
            double freqMHz4 = Convert.ToDouble(_txtStressFreq4MHz.Text);
            double[] Sg_InputPower = new double[] { -2, -2, -2, -2 };
            string[] Sg_Unit = new string[] { "VSG1", "VSG2", "VSG3", "VSG4" };

            stresstestpowon = true;
            if (stresstestpowon == true)
            {
                #region stresstest_powon
                if (GlobalVariable.iTsChannel <= 16)
                {
                    LibPXI.StressTest_PowOn(freqMHz1, Sg_InputPower[0], Sg_Unit[0]);

                    if (GlobalVariable.iTsChannel == 1)
                    {
                        int dbm1;
                        double result1;
					    bool overload = false;
                        LibPXI.SetSwitchPath(1);
                        LibPXI.VsaSetup_Pow(freqMHz1, 0);
                        LibPXI.VSA.Arm();
                        LibPXI.VSA.PowerAcquisition.ReadPower(0, AgM9391PowerUnitsEnum.AgM9391PowerUnitsdBm, ref result1, ref overload);
                        dbm1 = LibPXI.VSA.subStressResult.Add(result1);
						_txtstresson_CH1.Clear();
                        _txtstresson_CH1.Text = Convert.ToString(dbm1);

                    }
                }
                else if (GlobalVariable.iTsChannel <= 32)
                {
                    LibPXI.StressTest_PowOn(freqMHz2, Sg_InputPower[1], Sg_Unit[1]);
                    if (GlobalVariable.iTsChannel == 17)
                    {
                        int dbm17;
                        double result17;
                        bool overload = false;
                        LibPXI.SetSwitchPath(17);
                        LibPXI.VsaSetup_Pow(freqMHz2, 0);
                        LibPXI.VSA.Arm();
                        LibPXI.VSA.PowerAcquisition.ReadPower(0, AgM9391PowerUnitsEnum.AgM9391PowerUnitsdBm, ref result17, ref overload);
                        dbm17 = LibPXI.VSA.subStressResult.Add(result17);
						_txtstresson_CH17.Clear();
                        _txtstresson_CH17.Text = Convert.ToString(dbm17);
                    }
                }
                else if (GlobalVariable.iTsChannel <= 48)
                {
                    LibPXI.StressTest_PowOn(freqMHz3, Sg_InputPower[2], Sg_Unit[2]);
                    if (GlobalVariable.iTsChannel == 33)
                    {
                        int dbm33;
                        double result33;
                        bool overload = false;
                        LibPXI.SetSwitchPath(33);
                        LibPXI.VsaSetup_Pow(freqMHz3, 0);
                        LibPXI.VSA.Arm();
                        LibPXI.VSA.PowerAcquisition.ReadPower(0, AgM9391PowerUnitsEnum.AgM9391PowerUnitsdBm, ref result33, ref overload);
                        dbm33 = LibPXI.VSA.subStressResult.Add(result33);
						_txtstresson_CH33.Clear();
                        _txtstresson_CH33.Text = Convert.ToString(dbm33);
                    }
                }
                else if (GlobalVariable.iTsChannel <= 64)
                {
                    LibPXI.StressTest_PowOn(freqMHz4, Sg_InputPower[3], Sg_Unit[3]);
                    if (GlobalVariable.iTsChannel == 49)
                    {
                        int dbm49;
                        double result49;
                        bool overload = false;
                        LibPXI.SetSwitchPath(49);
                        LibPXI.VsaSetup_Pow(freqMHz4, 0);
                        LibPXI.VSA.Arm();
                        LibPXI.VSA.PowerAcquisition.ReadPower(0, AgM9391PowerUnitsEnum.AgM9391PowerUnitsdBm, ref result49, ref overload);
                        dbm49 = LibPXI.VSA.subStressResult.Add(result49);
						_txtstresson_CH49.Clear();
                        _txtstresson_CH49.Text = Convert.ToString(dbm49);
                    }
                #endregion
                }
            }
        }

        //stress test power off
        private void stresstest_powoff()
        {
            stresstestpowoff = true;
            if (stresstestpowoff == true)
            {
                #region stresstest_powoff
                if (GlobalVariable.iTsChannel <= 16)
                {
                    LibPXI.StressTest_PowOff(Sg_Unit[0]);
                    if (GlobalVariable.iTsChannel == 1)
                    {
                        int dbm1;
                        double result1;
                        bool overload = false;
                        LibPXI.SetSwitchPath(1);
                        LibPXI.VsaSetup_Pow(GlobalVariable.StressFreq[0], 0);
                        LibPXI.VSA.Arm();
                        LibPXI.VSA.PowerAcquisition.ReadPower(0, AgM9391PowerUnitsEnum.AgM9391PowerUnitsdBm, ref result1, ref overload);
                        dbm1 = LibPXI.VSA.subStressResult.Add(result1);
                        _txtstresson_CH1.Clear();
                        _txtstresson_CH1.Text = Convert.ToString(result1);
                    }
                }
                else if (GlobalVariable.iTsChannel <= 32)
                {
                    LibPXI.StressTest_PowOff(Sg_Unit[1]);
                    if (GlobalVariable.iTsChannel == 17)
                    {
                        int dbm17;
                        double result17;
                        bool overload = false;
                        LibPXI.SetSwitchPath(17);
                        LibPXI.VsaSetup_Pow(GlobalVariable.StressFreq[1], 0);
                        LibPXI.VSA.Arm();
                        LibPXI.VSA.PowerAcquisition.ReadPower(0, AgM9391PowerUnitsEnum.AgM9391PowerUnitsdBm, ref result17, ref overload);
                        dbm17 = LibPXI.VSA.subStressResult.Add(result17);
                        _txtstresson_CH17.Clear();
                        _txtstresson_CH17.Text = Convert.ToString(dbm17);
                    }
                }
                else if (GlobalVariable.iTsChannel <= 48)
                {
                    LibPXI.StressTest_PowOff(Sg_Unit[2]);
                    if (GlobalVariable.iTsChannel == 33)
                    {
                        int dbm33;
                        double result33;
                        bool overload = false;
                        LibPXI.SetSwitchPath(33);
                        LibPXI.VsaSetup_Pow(GlobalVariable.StressFreq[2], 0);
                        LibPXI.VSA.Arm();
                        LibPXI.VSA.PowerAcquisition.ReadPower(0, AgM9391PowerUnitsEnum.AgM9391PowerUnitsdBm, ref result33, ref overload);
                        dbm33 = LibPXI.VSA.subStressResult.Add(result33);
                        _txtstresson_CH33.Clear();
                        _txtstresson_CH33.Text = Convert.ToString(dbm33);
                    }
                }
                else if (GlobalVariable.iTsChannel <= 64)
                {
                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                    if (GlobalVariable.iTsChannel == 49)
                    {
                        int dbm49;
                        double result49;
                        bool overload = false;
                        LibPXI.SetSwitchPath(64);
                        LibPXI.VsaSetup_Pow(GlobalVariable.StressFreq[3], 0);
                        LibPXI.VSA.Arm();
                        LibPXI.VSA.PowerAcquisition.ReadPower(0, AgM9391PowerUnitsEnum.AgM9391PowerUnitsdBm, ref result49, ref overload);
                        dbm49 = LibPXI.VSA.subStressResult.Add(result49);
                        _txtstresson_CH49.Clear();
                        _txtstresson_CH49.Text = Convert.ToString(dbm49);
                    }
                }

                //else if channel > 64
                #region else if channel > 64
                else if (GlobalVariable.iTsChannel > 64)
                {
                    LibPXI.StressTest_PowOff(Sg_Unit[0]);
                    if (GlobalVariable.iTsChannel == 1)
                    {
                        int dbm1;
                        double result1;
                        bool overload = false;
                        LibPXI.SetSwitchPath(1);
                        LibPXI.VsaSetup_Pow(GlobalVariable.StressFreq[0], 0);
                        LibPXI.VSA.Arm();
                        LibPXI.VSA.PowerAcquisition.ReadPower(0, AgM9391PowerUnitsEnum.AgM9391PowerUnitsdBm, ref result1, ref overload);
                        dbm1 = LibPXI.VSA.subStressResult.Add(result1);
                        _txtstresson_CH1.Clear();
                        _txtstresson_CH1.Text = Convert.ToString(dbm1);
                    }

                    LibPXI.StressTest_PowOff(Sg_Unit[1]);
                    if (GlobalVariable.iTsChannel == 17)
                    {
                        int dbm17;
                        double result17;
                        bool overload = false;
                        LibPXI.SetSwitchPath(17);
                        LibPXI.VsaSetup_Pow(GlobalVariable.StressFreq[1], 0);
                        LibPXI.VSA.Arm();
                        LibPXI.VSA.PowerAcquisition.ReadPower(0, AgM9391PowerUnitsEnum.AgM9391PowerUnitsdBm, ref result17, ref overload);
                        LibPXI.subStressResult.Add(result17);
                        dbm17 = LibPXI.VSA.subStressResult.Add(result17);
                        _txtstresson_CH17.Clear();
                        _txtstresson_CH17.Text = Convert.ToString(result17);
                    }

                    LibPXI.StressTest_PowOff(Sg_Unit[2]);
                    if (GlobalVariable.iTsChannel == 33)
                    {
                        int dbm33;
                        double result33;
                        bool overload = false;
                        LibPXI.SetSwitchPath(33);
                        LibPXI.VsaSetup_Pow(GlobalVariable.StressFreq[2], 0);
                        LibPXI.VSA.Arm();
                        LibPXI.VSA.PowerAcquisition.ReadPower(0, AgM9391PowerUnitsEnum.AgM9391PowerUnitsdBm, ref result33, ref overload);
                        dbm33 = LibPXI.VSA.subStressResult.Add(result33);
                        _txtstresson_CH33.Clear();
                        _txtstresson_CH33.Text = Convert.ToString(dbm33);
                    }

                    LibPXI.StressTest_PowOff(Sg_Unit[3]);
                    if (GlobalVariable.iTsChannel == 49)
                    {
                        int dbm49;
                        double result49;
                        bool overload = false;
                        LibPXI.SetSwitchPath(64);
                        LibPXI.VsaSetup_Pow(GlobalVariable.StressFreq[3], 0);
                        LibPXI.VSA.Arm();
                        LibPXI.VSA.PowerAcquisition.ReadPower(0, AgM9391PowerUnitsEnum.AgM9391PowerUnitsdBm, ref result49, ref overload);
                        dbm49 = LibPXI.VSA.subStressResult.Add(result49);
                        _txtstresson_CH49.Clear();
                        _txtstresson_CH49.Text = Convert.ToString(dbm49);
                    }
                #endregion
                }
                #endregion
            }
        }

        //Update backgroundworker1 progress
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //channel++;//chun42716
            //UpdateChannelDisplay();
            //UpdateDisplay();
            //LibPXI.subStressResult.Clear();
            //LibPXI.subSweepResult.Clear();
            channel++;
            //timer1.Start();//chun42816


        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //UpdateDisplay();
            ////UpdateChannelDisplay();
            //LibPXI.subStressResult.Clear();
            //LibPXI.subSweepResult.Clear();
            //channel++;

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeCounter--;
            if (TimeCounter == 0)
            {
                cdTimer.Stop();
                timerStop = true;
            }
        }
        //give instruction to do work

        #region backgroundWorker1_DoWork
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //do
            //{
            if (backgroundWorker1.CancellationPending == true)
            {
                e.Cancel = true;
                GlobalVariable.isStop = true;
            }
            else
            {
                if (channel <= 64)
                {
                    Thread.Sleep(50);
                    GlobalVariable.iTsChannel = channel;
                    LibPXI.StressTest();
                    LibPXI.Result.Add(LibPXI.subStressResult);
                    LibPXI.SweepTest();
                    LibPXI.Result.Add(LibPXI.subSweepResult);
                    UpdateChannelDisplay();
                    UpdateDisplay();
                    int tempPercentage = (int)Math.Ceiling(((double)channel / 64) * 100);
                    backgroundWorker1.ReportProgress(tempPercentage);
                }
                else if (channel == 65)
                {
                    //timerStop = false;
                    //TimeCounter = Convert.ToInt16(_txtBIInterval.Text) * 3600;
                    //cdTimer.Tick += new EventHandler(timer1_Tick);
                    //cdTimer.Interval = 1000;
                    //cdTimer.Start();

                    //if (timerStop)
                    //{
                    //    channel = 1;
                    //    GlobalVariable.iTsChannel = channel;
                    //    //Thread.Sleep(1000);
                    //    LibPXI.StressTest();
                    //    LibPXI.Result.Add(LibPXI.subStressResult);
                    //    LibPXI.SweepTest();
                    //    LibPXI.Result.Add(LibPXI.subSweepResult);
                    //}

                    GlobalVariable.numTest++;
                    //timer1.Stop();//chun3516
                    //timer2.Stop();//chun3516
                    //MessageBox.Show("Timer Start Count", "Timer", MessageBoxButtons.OK);
                    channel = 1;
                }
            }
            //} while (!GlobalVariable.isStop); 
        }
        #endregion

        //save data into csv file
        public void SaveData()
        {
            #region SaveData
            DateTime datadt = DateTime.Now;//chun30516
            string Datadate = datadt.ToString("yyyyMMdd");//chun30516
            string Datatime = datadt.ToString("HH:mm:ss");//chun30516
            //DateTime datatm = DateTime.Now;//chun30516

            StringBuilder sb = new StringBuilder();
            string folderName = @"C:\RealibilityTest\" + FileDate + "_" + _txtFilename.Text + @"\";
            string fileName = "Result_" + _txtFilename.Text + "_" + FileDate + "_Channel_" + GlobalVariable.iTsChannel.ToString() + ".csv";
            bool folderExist = System.IO.Directory.Exists(folderName);
            if (!folderExist)
            {
                System.IO.Directory.CreateDirectory(folderName);
            }

            bool fileExist = System.IO.File.Exists(folderName + fileName);

            sb.Append("Test_" + GlobalVariable.numTest.ToString() + "_" + Datadate + "_" + Datatime).Append(",");//chun30516
            foreach (double tempResult in LibPXI.subSweepResult)
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

        public void SaveDataSetting()
        {
            #region SaveDataSetting
            StringBuilder sds = new StringBuilder();
            String foldername = @"C:\ReliabilityTest\Datasetting_folder" + @"\";
            String filename   = "Datasetting_file.txt";
            bool folderExist  = System.IO.Directory.Exists(filename);
            test_setting_file = true;

            if(!folderExist)
            {
                System.IO.Directory.CreateDirectory(foldername);
            }

            bool fileExist = System.IO.File.Exists(foldername + filename);

            sds.Append(_txtBIInterval.Text     + Environment.NewLine);
            sds.Append(_txtBurnInDuration.Text + Environment.NewLine);
            sds.Append(_txtStartFreq1.Text     + Environment.NewLine);
            sds.Append(_txtStartFreq2.Text     + Environment.NewLine);
            sds.Append(_txtStartFreq3.Text     + Environment.NewLine);
            sds.Append(_txtStartFreq4.Text     + Environment.NewLine);
            sds.Append(_txtStopFreq1.Text      + Environment.NewLine);
            sds.Append(_txtStopFreq2.Text      + Environment.NewLine);
            sds.Append(_txtStopFreq3.Text      + Environment.NewLine);
            sds.Append(_txtStopFreq4.Text      + Environment.NewLine);
            sds.Append(_txtStressFreq1MHz.Text + Environment.NewLine);
            sds.Append(_txtStressFreq2MHz.Text + Environment.NewLine);
            sds.Append(_txtStressFreq3MHz.Text + Environment.NewLine);
            sds.Append(_txtStressFreq4MHz.Text + Environment.NewLine);

            if (fileExist)
            {
                System.IO.File.AppendAllText(foldername + filename, sds.ToString());
            }
            else
            {
                System.IO.File.WriteAllText(foldername + filename, sds.ToString());
            }

            sds = null;

            #endregion
        }

        #region keypress numbers only
        //allow only number not character to be keyed into burn interval text box
        private void _txtBIInterval_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (char.IsDigit(e.KeyChar) || (e.KeyChar == '.'))
            {
                e.Handled = false;
            }
        }
       
        //allow only number not character to be keyed into burn in duration text box
        private void _txtBurnInDuration_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (char.IsDigit(e.KeyChar) || (e.KeyChar == '.'))
            {
                e.Handled = false;
            }
        }

        //allow only number not character to be keyed into start frequency1 textbox 
        private void _txtStartFreq1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (char.IsDigit(e.KeyChar) || (e.KeyChar == '.'))
            {
                e.Handled = false;
            }
        }

        //allow only number not character to be keyed into start frequency2 textbox 
        private void _txtStartFreq2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (char.IsDigit(e.KeyChar) || (e.KeyChar == '.'))
            {
                e.Handled = false;
            }
        }

        //allow only number not character to be keyed into start frequency3 textbox 
        private void _txtStartFreq3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (char.IsDigit(e.KeyChar) || (e.KeyChar == '.'))
            {
                e.Handled = false;
            }
        }

        //allow only number not character to be keyed into start frequency4 textbox 
        private void _txtStartFreq4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (char.IsDigit(e.KeyChar) || (e.KeyChar == '.'))
            {
                e.Handled = false;
            }
        }

        //allow only number not character to be keyed into stop frequency1 textbox 
        private void _txtStopFreq1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (char.IsDigit(e.KeyChar) || (e.KeyChar == '.'))
            {
                e.Handled = false;
            }
        }

        //allow only number not character to be keyed into stop frequency2 textbox 
        private void _txtStopFreq2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (char.IsDigit(e.KeyChar) || (e.KeyChar == '.'))
            {
                e.Handled = false;
            }
        }

        //allow only number not character to be keyed into stop frequency3 textbox 
        private void _txtStopFreq3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (char.IsDigit(e.KeyChar) || (e.KeyChar == '.'))
            {
                e.Handled = false;
            }
        }

        //allow only number not character to be keyed into stop frequency4 textbox 
        private void _txtStopFreq4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (char.IsDigit(e.KeyChar) || (e.KeyChar == '.'))
            {
                e.Handled = false;
            }
        }

        //allow only number not character to be keyed into stress frequency1 textbox 
        private void _txtStressFreq1MHz_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (char.IsDigit(e.KeyChar) || (e.KeyChar == '.'))
            {
                e.Handled = false;
            }
        }

        //allow only number not character to be keyed into stress frequency2 textbox 
        private void _txtStressFreq2MHz_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (char.IsDigit(e.KeyChar) || (e.KeyChar == '.'))
            {
                e.Handled = false;
            }
        }

        //allow only number not character to be keyed into stress frequency3 textbox 
        private void _txtStressFreq3MHz_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (char.IsDigit(e.KeyChar) || (e.KeyChar == '.'))
            {
                e.Handled = false;
            }
        }

        //allow only number not character to be keyed into stress frequency4 textbox 
        private void _txtStressFreq4MHz_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (char.IsDigit(e.KeyChar) || (e.KeyChar == '.'))
            {
                e.Handled = false;
            }
        }
#endregion

        //timer end that exactly stop at burn in duration (timer no stop when stress power off and update charts)
        private void timer_end_Tick(object sender, EventArgs e)
        {
            int second_end = 0;
            if (_btnInitWasClicked == true && _btnStartWasClicked == true && start_counter == 1)
            {
                second_end++;

                //when ABORT button was clicked
                #region when ABORT button was clicked
                if (GlobalVariable.abortSet == true)
                {
                    updateDisplay = false;
                    timer_end.Stop();
                    stresstestpowoff = true;
                    stresstest_powoff();

                    hour = 0;
                    minute = 0;
                    second = 0;
                }
                #endregion

                if (((second_end * (int)3.6e6) % GlobalVariable.iTotalTimeMs) == 0)
                {
                    updateDisplay = false;
                    BItimer.Stop();
                    stresstestpowoff = true;
                    stresstest_powoff();

                    _btnAbort_Click(sender, e);

                    DialogResult dialogResult = MessageBox.Show("Test Finish");
                    hour = 0;
                    minute = 0;
                    second = 0;
                    _txthour.Text   = hour.ToString();//"0";
                    _txtminute.Text = minute.ToString();//"0";
                    _txtsecond.Text = second.ToString();//"0";
                    _txtElapsedBITime.Clear();
                    _txtTimeToNextMeas.Clear();
                    _txtBurnInStarted.Clear();
                    _txtEstFinishTestDate.Clear();
                }
            }
        }

        //burn in timer tick 
        private void BItimer_Tick_1(object sender, EventArgs e)
        {
            #region checking BIIterval & BIDuration
            if (stresstestpowon == true)
            {
                if ((_txtBIInterval.Text.ToString() == "") || (_txtBurnInDuration.Text.ToString() == ""))
                {
                    BItimer.Stop();
                }
                else
                {
                    GlobalVariable.iDelayTimeMs = Convert.ToSingle(_txtBIInterval.Text)     * (int)3.6e6;
                    GlobalVariable.iTotalTimeMs = Convert.ToSingle(_txtBurnInDuration.Text) * (int)3.6e6;
                }
            #endregion

                _btnAbort.Visible = true;

                #region GlobalVariable.abortSet == false
                if (!GlobalVariable.abortSet)
                {
                    if (updateDisplay == true)
                    {
                        _btnStart.Visible = false;
                        _btnAbort.Visible = true;///
                        second = second + 1;
                        _txtsecond.Text = second.ToString();

                                    //when ABORT button was clicked
                                    #region when ABORT button was clicked
                                    if (GlobalVariable.abortSet == true)
                                    {
                                        updateDisplay = false;
                                        BItimer.Stop();
                                        stresstestpowoff = true;
                                        stresstest_powoff();

                                        hour   = 0;
                                        minute = 0;
                                        second = 0;
                                    }
                                    #endregion

                        //when 1 minute  
                        if (second % 60 == 0)
                        {
                                        #region when ABORT button was clicked
                                        if (GlobalVariable.abortSet == true)
                                        {
                                            updateDisplay = false;
                                            BItimer.Stop();
                                            stresstestpowoff = true;
                                            stresstest_powoff();

                                            hour   = 0;
                                            minute = 0;
                                            second = 0;
                                        }
                                        #endregion
                            // _txtsecond.Text = second.ToString();///
                            second = 0;
                            _txtsecond.Text = second.ToString();///
                            minute = minute + 1;
                            _txtminute.Text = minute.ToString();



                            //when Burn In Interval is in MINUTES
                            #region   //when Burn In Interval is in MINUTES
                            if (GlobalVariable.iDelayTimeMs < (int)3.6e6)
                            {
                                //when BITimer reach Burn In Interval
                                if (((minute * (int)3.6e6) % (60 * GlobalVariable.iDelayTimeMs) == 0))
                                {
                                                #region when ABORT button was clicked
                                                if (GlobalVariable.abortSet == true)
                                                {
                                                    updateDisplay = false;
                                                    BItimer.Stop();
                                                    stresstestpowoff = true;
                                                    stresstest_powoff();

                                                    hour = 0;
                                                    minute = 0;
                                                    second = 0;
                                                }
                                                #endregion
                                    
                                    //_txtminute.Text = minute.ToString();///
                                    second          = 0;
                                    _txtsecond.Text = second.ToString();///
                                    minute = minute + 1;
                                    _txtminute.Text = minute.ToString();

                                    _txtElapsedBITime.Text = minute.ToString();
                                    BItimer.Stop();
                                    stresstestpowoff = true;
                                    stresstest_powoff();
                                    _btnStart_Click(sender, e);

                                    //when Burn In Duration is in MINUTES
                                    if (GlobalVariable.iTotalTimeMs < (int)3.6e6)
                                    {
                                        //when Burn In Interval reach Burn In Duration
                                        if ((minute * (int)3.6e6) % (60 * GlobalVariable.iTotalTimeMs) == 0)
                                        {
                                                       
                                            _txtminute.Text  = minute.ToString();///
                                            updateDisplay    = false;
                                            BItimer.Stop();
                                            stresstestpowoff = true;
                                            stresstest_powoff();

                                            _btnAbort_Click(sender, e);

                                            DialogResult dialogResult = MessageBox.Show("Test Finish");
                                            hour   = 0;
                                            minute = 0;
                                            second = 0;
                                            _txthour.Text   = hour.ToString();// "0";
                                            _txtminute.Text = minute.ToString();// "0";
                                            _txtsecond.Text = second.ToString();// "0";
                                            _txtElapsedBITime.Clear();
                                            _txtTimeToNextMeas.Clear();
                                            _txtBurnInStarted.Clear();
                                            _txtEstFinishTestDate.Clear();
                                        }
                                    }

                                    //when Burn In Interval is in HOUR
                                    else if (GlobalVariable.iTotalTimeMs >= (int)3.6e6)
                                    {
                                        //when Burn In Interval reach Burn In Duration
                                        if (((hour * (int)3.6e6) % GlobalVariable.iTotalTimeMs) == 0)
                                        {
                                            _txthour.Text = hour.ToString();///
                                            updateDisplay = false;
                                            BItimer.Stop();
                                            stresstestpowoff = true;
                                            stresstest_powoff();

                                            _btnAbort_Click(sender, e);

                                            DialogResult dialogResult = MessageBox.Show("Test Finish");
                                            hour   = 0;
                                            minute = 0;
                                            second = 0;
                                            _txthour.Text   = hour.ToString()  ;// "0";
                                            _txtminute.Text = minute.ToString();// "0";
                                            _txtsecond.Text = second.ToString();// "0";
                                            _txtElapsedBITime.Clear();
                                            _txtTimeToNextMeas.Clear();
                                            _txtBurnInStarted.Clear();
                                            _txtEstFinishTestDate.Clear();
                                        }
                                    }
                                }
                            }
                            #endregion



                            //when Burn In Interval is in HOUR
                            #region //When Burn In Interval is in HOUR
                            else if (GlobalVariable.iDelayTimeMs >= (int)3.6e6)
                            {
                                            
                                //when BITimer reach Burn In Interval
                                if (((minute * (int)3.6e6) % (60 * GlobalVariable.iDelayTimeMs)) == 0)
                                {
                                                #region when ABORT button was clicked
                                                if (GlobalVariable.abortSet == true)
                                                {
                                                    updateDisplay = false;
                                                    BItimer.Stop();
                                                    stresstestpowoff = true;
                                                    stresstest_powoff();

                                                    hour = 0;
                                                    minute = 0;
                                                    second = 0;
                                                }
                                                #endregion

                                    //_txtminute.Text = minute.ToString();///
                                    minute                 = 0;
                                    _txtminute.Text = minute.ToString();///
                                    hour                   = hour + 1;
                                    _txthour.Text          = hour.ToString();
                                    _txtElapsedBITime.Text = hour.ToString();
                                    BItimer.Stop();
                                    stresstestpowoff = true;
                                    stresstest_powoff();
                                    _btnStart_Click(sender, e);

                                    //when Burn In Interval is in HOUR
                                    //if (GlobalVariable.iTotalTimeMs >= (int)3.6e6)
                                    //{
                                    if (((hour * (int)3.6e6) % GlobalVariable.iTotalTimeMs) == 0)
                                    {
                                        _txthour.Text = hour.ToString();///
                                        updateDisplay = false;
                                        BItimer.Stop();
                                        stresstestpowoff = true;
                                        stresstest_powoff();

                                        _btnAbort_Click(sender, e);

                                        DialogResult dialogResult = MessageBox.Show("Test Finish");
                                        hour   = 0;
                                        minute = 0;
                                        second = 0;
                                        _txthour.Text   = hour.ToString();// "0";
                                        _txtminute.Text = minute.ToString();// "0";
                                        _txtsecond.Text = second.ToString();//"0";
                                        _txtElapsedBITime.Clear();
                                        _txtTimeToNextMeas.Clear();
                                        _txtBurnInStarted.Clear();
                                        _txtEstFinishTestDate.Clear();
                                    }
                                    //}
                                }
                            }
                            #endregion
                        }
                    }
                }
                #endregion
            }
        }

     

    }//dont delete this line
}//dont delete this line
