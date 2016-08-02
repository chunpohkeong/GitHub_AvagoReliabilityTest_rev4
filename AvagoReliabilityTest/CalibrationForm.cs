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
    public partial class CalibrationForm : Form
    {
        public LibPXI LibPXI = new LibPXI();

        public CalibrationForm()
        {
            InitializeComponent();
            GlobalVariable.Cal1To8 = false;
            GlobalVariable.Cal9To16 = false;
            GlobalVariable.Cal17To24 = false;
            GlobalVariable.Cal25To32 = false;
            GlobalVariable.Cal33To40 = false;
            GlobalVariable.Cal41To48 = false;
            GlobalVariable.Cal49To56 = false;
            GlobalVariable.Cal57To64 = false;
            GlobalVariable.CalForm1 = false;
            GlobalVariable.CalForm2 = false;
            GlobalVariable.CalForm3 = false;
            GlobalVariable.CalForm4 = false;

            GlobalVariable.iCalCount = 0;
        }
        private Form1 mainForm = null;
        public CalibrationForm(Form callingForm)
        {
            mainForm = callingForm as Form1;
            InitializeComponent();
        }
        private void _btnCalStart_Click(object sender, EventArgs e)
        {
            double[] offsetCalFreqList = new double[4];
            int counter = 0;
            bool failData = false;
            this.mainForm.Enabled = false;
            this.mainForm.WindowState = FormWindowState.Minimized;
            bool chechBoxChecked = false;
            bool cal1 = false;
            bool cal2 = false;
            bool cal3 = false;
            bool cal4=false;
            GlobalVariable.iCalCount = 0;
            //Initial Channel for Calibration
            if (_cbChannelGroup1.Checked)
            {
                GlobalVariable.Cal1To8 = true;
                GlobalVariable.Cal9To16 = true;
                GlobalVariable.CalForm1 = true;
                GlobalVariable.iCalCount++;
                chechBoxChecked = true;
                if (_txtFreqMHz1.Text == "")
                    failData = true;
                else
                {
                    GlobalVariable.dCalFreq1 = Convert.ToDouble(_txtFreqMHz1.Text);
                    GlobalVariable.calBand1 = _txtCalBand1.Text;
                    cal1 = true;
                    counter++;
                }
            }
            #region
            //if (_cbChannelGroup2.Checked)
            //{
            //    GlobalVariable.Cal9To16 = true;
            //    chechBoxChecked = true;
            //}
            #endregion
            if (_cbChannelGroup3.Checked)
            {
                GlobalVariable.Cal17To24 = true;
                GlobalVariable.Cal25To32 = true;
                GlobalVariable.CalForm2 = true;
                GlobalVariable.iCalCount++;
                chechBoxChecked = true;
                if (_txtFreqMHz2.Text == "")
                    failData = true;
                else
                {
                    GlobalVariable.dCalFreq2 = Convert.ToDouble(_txtFreqMHz2.Text);
                    GlobalVariable.calBand2 = _txtCalBand2.Text;
                    cal2=true;
                    counter++;
                }
            }
            #region
            //if (_cbChannelGroup4.Checked)
            //{
            //    GlobalVariable.Cal25To32 = true;
            //    chechBoxChecked = true;
            //}
            #endregion
            if (_cbChannelGroup5.Checked)
            {
                GlobalVariable.Cal33To40 = true;
                GlobalVariable.Cal41To48 = true;
                GlobalVariable.CalForm3 = true;
                GlobalVariable.iCalCount++;
                chechBoxChecked = true;
                if (_txtFreqMHz3.Text == "")
                    failData = true;
                else
                {
                    GlobalVariable.dCalFreq3 = Convert.ToDouble(_txtFreqMHz3.Text);
                    GlobalVariable.calBand3 = _txtCalBand3.Text;
                    cal3 = true;
                    counter++;
                }
            }
            #region 
            //if (_cbChannelGroup6.Checked)
            //{
            //    GlobalVariable.Cal41To48 = true;
            //    chechBoxChecked = true;
            //}
            #endregion
            if (_cbChannelGroup7.Checked)
            {
                GlobalVariable.Cal49To56 = true;
                GlobalVariable.Cal57To64 = true;
                GlobalVariable.CalForm4 = true;
                GlobalVariable.iCalCount++;
                chechBoxChecked = true;
                if (_txtFreqMHz4.Text == "")
                    failData = true;
                else
                {
                    GlobalVariable.dCalFreq4 = Convert.ToDouble(_txtFreqMHz4.Text);
                    GlobalVariable.calBand4 = _txtCalBand4.Text;
                    cal4=true;
                    counter++;
                }
            }
            #region
            //if (_cbChannelGroup8.Checked)
            //{
            //    GlobalVariable.Cal57To64 = true;
            //    chechBoxChecked = true;
            //}
            #endregion
            if (chechBoxChecked)
            {
                if (!failData)
                {
                    Array.Resize(ref offsetCalFreqList, counter);
                    for (int i = 0; i < counter; i++)
                    {
                        if (cal1)
                        {
                            offsetCalFreqList[i] = GlobalVariable.dCalFreq1;
                            cal1 = false;
                        }
                        else if (cal2)
                        {
                            offsetCalFreqList[i] = GlobalVariable.dCalFreq2;
                            cal2 = false;
                        }
                        else if (cal3)
                        {
                            offsetCalFreqList[i] = GlobalVariable.dCalFreq3;
                            cal3 = false;
                        }
                        else if (cal4)
                        {
                            offsetCalFreqList[i] = GlobalVariable.dCalFreq4;
                            cal4 = false;
                        }
                    }
                    LibPXI.CalOffset(0, offsetCalFreqList);

                    Calibration_SubForm calSubForm = new Calibration_SubForm();
                    if (_txtCalFileName.Text == "")
                    {
                        GlobalVariable.calFileName = "CalibrationFile";
                    }
                    else
                    {
                        GlobalVariable.calFileName = _txtCalFileName.Text;
                    }
                    calSubForm.Show();
                    
                    this.Close();
                    //LibPXI.Calibration();
                }
                else
                {
                    MessageBox.Show("Please key all frequency point on channel selected.", "Warning", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("No Channel have been selected, Please reselect again", "Warning", MessageBoxButtons.OK);
            }
        }

        private void _btnCalReset_Click(object sender, EventArgs e)
        {
            _cbChannelGroup1.Checked = false;
            //_cbChannelGroup2.Checked = false;
            _cbChannelGroup3.Checked = false;
            //_cbChannelGroup4.Checked = false;
            _cbChannelGroup5.Checked = false;
            //_cbChannelGroup6.Checked = false;
            _cbChannelGroup7.Checked = false;
            //_cbChannelGroup8.Checked = false;
            GlobalVariable.iCalCount = 0;
        }

        private void _btnChannelAll_Click(object sender, EventArgs e)
        {
            _cbChannelGroup1.Checked = true;
            _cbChannelGroup3.Checked = true;
            _cbChannelGroup5.Checked = true;
            _cbChannelGroup7.Checked = true;
            GlobalVariable.iCalCount = 4;
        }

    }
}
