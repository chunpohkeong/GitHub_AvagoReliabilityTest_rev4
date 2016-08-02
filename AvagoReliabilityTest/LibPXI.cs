using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using Agilent.AgM938x.Interop;
using Agilent.AgM9391.Interop;
using Agilent.AgMWSwitch.Interop;

//using Excel = Microsoft.Office.Interop.Excel;

namespace AvagoReliabilityTest 
{
    public class LibPXI : GlobalVariable
    {
        //Local Public Variable
        
        public bool simulateHardware = false;
        public string VSG1Resource   = "M9381A_1";
        public string VSG2Resource   = "M9381A_2";
        public string VSG3Resource   = "M9381A_3";
        public string VSG4Resource   = "M9381A_4";
        public string VSAResource    = "M9391A";
        public string Waveform       = "CW.WAVEFORM";
        public bool Inst_Init = false;
        public bool stresstestpowon = false;//chun30516
        public bool stresstestpowoff = false;//chun30516
        public double arbSampleRate = 0;
        public double arbRmsValue = 0;
        public double arbScale = 0;
        public AgM938xMarkerEnum rfMarker = AgM938xMarkerEnum.AgM938xMarkerNone;
        public AgM938xMarkerEnum alcMarker = AgM938xMarkerEnum.AgM938xMarkerNone;

        public double[] CalOffsetList =  new double[4];
        public List<double> CalFreqList = new List<double>();
        public List<double> CalResult = new List<double>();
        public List<int> CalChannel = new List<int>();
        public List<string> CalBandList = new List<string>();

        public List<List<double>> Result = new List<List<double>>();
        public List<double> subStressResult = new List<double>();
        public List<double> subSweepResult = new List<double>();
        //Local Private Variable
        HiPerfTimer hiTimer = new HiPerfTimer();

        

        public void Instrument_Init()
        {

            #region Loading Excel Condition File
            //Microsoft.Office.Interop.Excel.Application ExcelApps = new Microsoft.Office.Interop.Excel.Application();

            //if (GlobalVariable.conditionFilePath == null)
            //{
            //    MessageBox.Show("Condition didnt exist, Please check it", "Error Message", MessageBoxButtons.OK);
            //    Inst_Init = false;
            //}
            //else
            //{
            //    ReadExcelConditionFile();
            //}
            #endregion

            #region PXI VSG Init
            int errorCode = -1;
            string errorMessage = string.Empty;
            bool idQuery = true;
            bool reset = true;
            string M9381Options = string.Format("QueryInstrStatus=true, Simulate={0},  ShareAllVisaSessions=true, UsePlayArbThreadPool=true", (simulateHardware ? "true" : "false"));

            if (VSG1 == null || VSA == null)
            {
                VSG1 = new AgM938x();
                VSG2 = new AgM938x();
                VSG3 = new AgM938x();
                VSG4 = new AgM938x();
                VSA = new AgM9391();
                Inst_Init = true;
            }

            //VSG 1 Instrument Init
            VSG1.Initialize(ResourceName: VSG1Resource, IdQuery: idQuery, Reset: reset, OptionString: M9381Options);
            do
            {
                VSG1.Utility.ErrorQuery(ref errorCode, ref errorMessage);
                if (errorCode != 0)
                    Console.WriteLine(errorMessage);
            } while (errorCode != 0);

            //VSG 2 Instrument Init
            VSG2.Initialize(ResourceName: VSG2Resource, IdQuery: idQuery, Reset: reset, OptionString: M9381Options);
            do
            {
                VSG2.Utility.ErrorQuery(ref errorCode, ref errorMessage);
                if (errorCode != 0)
                    Console.WriteLine(errorMessage);
            } while (errorCode != 0);

            //VSG 3 Instrument Init
            VSG3.Initialize(ResourceName: VSG3Resource, IdQuery: idQuery, Reset: reset, OptionString: M9381Options);
            do
            {
                VSG3.Utility.ErrorQuery(ref errorCode, ref errorMessage);
                if (errorCode != 0)
                    Console.WriteLine(errorMessage);
            } while (errorCode != 0);

            //VSG 4 Instrument Init
            VSG4.Initialize(ResourceName: VSG4Resource, IdQuery: idQuery, Reset: reset, OptionString: M9381Options);
            do
            {
                VSG4.Utility.ErrorQuery(ref errorCode, ref errorMessage);
                if (errorCode != 0)
                    Console.WriteLine(errorMessage);
            } while (errorCode != 0);

            //Trigger Setup
            VSG1.Triggers.SynchronizationOutputTrigger.Configure(true, AgM938xMarkerEnum.AgM938xMarkerNone, AgM938xTriggerPolarityEnum.AgM938xTriggerPolarityPositive, 10e-6, AgM938xSynchronizationTriggerTypeEnum.AgM938xSynchronizationTriggerTypePerArb);
            VSG2.Triggers.SynchronizationOutputTrigger.Configure(true, AgM938xMarkerEnum.AgM938xMarkerNone, AgM938xTriggerPolarityEnum.AgM938xTriggerPolarityPositive, 10e-6, AgM938xSynchronizationTriggerTypeEnum.AgM938xSynchronizationTriggerTypePerArb);
            VSG3.Triggers.SynchronizationOutputTrigger.Configure(true, AgM938xMarkerEnum.AgM938xMarkerNone, AgM938xTriggerPolarityEnum.AgM938xTriggerPolarityPositive, 10e-6, AgM938xSynchronizationTriggerTypeEnum.AgM938xSynchronizationTriggerTypePerArb);
            VSG4.Triggers.SynchronizationOutputTrigger.Configure(true, AgM938xMarkerEnum.AgM938xMarkerNone, AgM938xTriggerPolarityEnum.AgM938xTriggerPolarityPositive, 10e-6, AgM938xSynchronizationTriggerTypeEnum.AgM938xSynchronizationTriggerTypePerArb);

            AgM938xTriggerEnum[] triggerList = new AgM938xTriggerEnum[] { AgM938xTriggerEnum.AgM938xTriggerFrontPanelTrigger2 };

            VSG1.Triggers2.SynchronizationOutputTrigger2.SetDestinationList(ref triggerList);
            VSG2.Triggers2.SynchronizationOutputTrigger2.SetDestinationList(ref triggerList);
            VSG3.Triggers2.SynchronizationOutputTrigger2.SetDestinationList(ref triggerList);
            VSG4.Triggers2.SynchronizationOutputTrigger2.SetDestinationList(ref triggerList);

            VSG1.Triggers.SynchronizationOutputTrigger.Enabled = true;
            VSG2.Triggers.SynchronizationOutputTrigger.Enabled = true;
            VSG3.Triggers.SynchronizationOutputTrigger.Enabled = true;
            VSG4.Triggers.SynchronizationOutputTrigger.Enabled = true;

            VSG1.Triggers.SynchronizationOutputTrigger.PulseWidth = 20e-6;
            VSG2.Triggers.SynchronizationOutputTrigger.PulseWidth = 20e-6;
            VSG3.Triggers.SynchronizationOutputTrigger.PulseWidth = 20e-6;
            VSG4.Triggers.SynchronizationOutputTrigger.PulseWidth = 20e-6;

            VSG1.Apply();
            VSG2.Apply();
            VSG3.Apply();
            VSG4.Apply();

            SG_LoadWaveform(Waveform);
            #endregion

            #region PXI VSA Init
            string M9391Options = string.Format("QueryInstrStatus=true, Simulate={0}, M9391Setup= Model=, Trace=false, ShareAllVisaSessions=true", (simulateHardware ? "true" : "false"));

            VSA.Initialize(ResourceName: VSAResource, IdQuery: idQuery, Reset: reset, OptionString: M9391Options);

            do
            {
                VSA.Utility.ErrorQuery(ref errorCode, ref errorMessage);
                if (errorCode != 0)
                    Console.WriteLine(errorMessage);
            } while (errorCode != 0);

            //Triggering Setup
            VSA.Triggers.ExternalTrigger.Holdoff = 16e-9;
            VSA.Triggers.ExternalTrigger.Source = AgM9391TriggerEnum.AgM9391TriggerFrontPanelTrigger1;
            VSA.Triggers.AcquisitionTrigger.Mode = AgM9391AcquisitionTriggerModeEnum.AgM9391AcquisitionTriggerModeImmediate;
            VSA.Triggers.AcquisitionTrigger.Delay = 100e-6;
            VSA.Triggers.AcquisitionTrigger.TimeoutMode = AgM9391TriggerTimeoutModeEnum.AgM9391TriggerTimeoutModeAutoTriggerOnTimeout;
            VSA.Triggers.AcquisitionTrigger.Timeout = 100;
            VSA.Triggers.ExternalTrigger.Slope = AgM9391TriggerSlopeEnum.AgM9391TriggerSlopePositive;
            VSA.Apply();
            #endregion

            #region Switch Init
            string SW01Resource = "SW1";
            string SW02Resource = "SW2";
            string SW03Resource = "SW3";
            string SW04Resource = "SW4";
            string SW05Resource = "SW5";
            string SW06Resource = "SW6";
            string SW07Resource = "SW7";
            string SW08Resource = "SW8";
            string SW09Resource = "SW9";
            string SW10Resource = "SW10";
            string SW11Resource = "SW11";
            string SwitchOptions = "QueryInstrStatus=true, Simulate=false, DriverSetup= Model=, Trace=false";
            if (SW01 == null)
            {
                SW01 = new AgMWSwitch();
                SW02 = new AgMWSwitch();
                SW03 = new AgMWSwitch();
                SW04 = new AgMWSwitch();
                SW05 = new AgMWSwitch();
                SW06 = new AgMWSwitch();
                SW07 = new AgMWSwitch();
                SW08 = new AgMWSwitch();
                SW09 = new AgMWSwitch();
                SW10 = new AgMWSwitch();
                SW11 = new AgMWSwitch();
            }
            SW01.Initialize(SW01Resource, idQuery, reset, SwitchOptions);
            string name = SW01.Identity.InstrumentModel;
            SW02.Initialize(SW02Resource, idQuery, reset, SwitchOptions);
            SW03.Initialize(SW03Resource, idQuery, reset, SwitchOptions);
            SW04.Initialize(SW04Resource, idQuery, reset, SwitchOptions);
            SW05.Initialize(SW05Resource, idQuery, reset, SwitchOptions);
            SW06.Initialize(SW06Resource, idQuery, reset, SwitchOptions);
            SW07.Initialize(SW07Resource, idQuery, reset, SwitchOptions);
            SW08.Initialize(SW08Resource, idQuery, reset, SwitchOptions);
            SW09.Initialize(SW09Resource, idQuery, reset, SwitchOptions);
            SW10.Initialize(SW10Resource, idQuery, reset, SwitchOptions);
            SW11.Initialize(SW11Resource, idQuery, reset, SwitchOptions);

            #endregion
            

            MessageBox.Show("All Instruments success init", "Instruments Init", MessageBoxButtons.OK);

        }

        public void Instrument_Uninit()
        {
            if (Inst_Init)
            {
                if (VSG1.Initialized)
                    VSG1.Close();
                if (VSG2.Initialized)
                    VSG2.Close();
                if (VSG3.Initialized)
                    VSG3.Close();
                if (VSG4.Initialized)
                    VSG4.Close();
                if (VSA.Initialized)
                    VSA.Close();
                if (SW01.Initialized)
                    SW01.Close();
                if (SW02.Initialized)
                    SW02.Close();
                if (SW03.Initialized)
                    SW03.Close();
                if (SW04.Initialized)
                    SW04.Close();
                if (SW05.Initialized)
                    SW05.Close();
                if (SW06.Initialized)
                    SW06.Close();
                if (SW07.Initialized)
                    SW07.Close();
                if (SW08.Initialized)
                    SW08.Close();
                if (SW09.Initialized)
                    SW09.Close();
                if (SW10.Initialized)
                    SW10.Close();
                if (SW11.Initialized)
                    SW11.Close();
            }
        }

        public void SaveCalibrationData(List<double> result)
        {
            DateTime date = DateTime.Now;
            string dt = date.ToString("yyyyMMdd_HHmmss");
            StreamWriter sw;
            bool folderExist = System.IO.Directory.Exists(@"C:\Calibration File");
            if (!folderExist)
                System.IO.Directory.CreateDirectory(@"C:\Calibration File");

            sw = File.CreateText(@"C:\Calibration File\" + GlobalVariable.calFileName + "_" + dt + ".csv");

            sw.WriteLine("Chamber:,TH#11");
            sw.WriteLine("Channel,,1-16,17-32,33-48,49-64");
            sw.WriteLine("Stress Freq,MHz," + GlobalVariable.dCalFreq1.ToString() + "," + GlobalVariable.dCalFreq2.ToString() + "," + GlobalVariable.dCalFreq3.ToString() + "," + GlobalVariable.dCalFreq4.ToString());
            sw.WriteLine("Stress Amp,dBm," + GlobalVariable.dAmplitude.ToString() + "," + GlobalVariable.dAmplitude.ToString() + "," + GlobalVariable.dAmplitude.ToString() + "," + GlobalVariable.dAmplitude.ToString());
            sw.WriteLine("Power input,,30dBm,30dBm,30dBm,30dBm");
            
            sw.WriteLine("Stress Temperature");
            sw.WriteLine("Readout");
            sw.WriteLine();
            sw.WriteLine("Cable No.,Input Pwr (dBm),Unit No., Freq., Band");
            for (int i = 0; i < result.Count; i++)
            {
                sw.WriteLine((i + 1).ToString() + "," + result[i] + ",," + CalFreqList[i] + "," + CalBandList[i]);
            }
            sw.Close();
            CalFreqList.Clear();
            CalBandList.Clear();
        }
        //Calibration
        public void Calibration(double SgInputPower, int startChannel, double FreqMHz, ref double[] tempCalResult)
        {
            double result = 0;
            bool overload = false;
            SgInputPower = -2;
            string calband = "";

            if (GlobalVariable.Cal1To8)
            {
                VsgSetup(VSG1, FreqMHz, SgInputPower);
                VsaSetup_Pow(FreqMHz, 0);
                calband = GlobalVariable.calBand1;
            }
            else if (GlobalVariable.Cal17To24)
            {
                VsgSetup(VSG2, FreqMHz, SgInputPower);
                VsaSetup_Pow(FreqMHz, 0);
                calband = GlobalVariable.calBand2;
            }
            else if (GlobalVariable.Cal33To40)
            {
                VsgSetup(VSG3, FreqMHz, SgInputPower);
                VsaSetup_Pow(FreqMHz, 0);
                calband = GlobalVariable.calBand3;
            }
            else if (GlobalVariable.Cal49To56)
            {
                VsgSetup(VSG4, FreqMHz, SgInputPower);
                VsaSetup_Pow(FreqMHz, 0);
                calband = GlobalVariable.calBand4;
            }
            int i = 0;
            bool endTest = false;
            do
            {
                //SetSwitchPath(startChannel + i);
                DialogResult buttonResult = MessageBox.Show("Please connect to Channel " + (startChannel + i).ToString() + " cable to VSA", "Calibration", MessageBoxButtons.OKCancel);
                if (buttonResult == DialogResult.OK)
                {
                    VSA.Arm();
                    VSA.PowerAcquisition.ReadPower(0, AgM9391PowerUnitsEnum.AgM9391PowerUnitsdBm, ref result, ref overload);
                    tempCalResult[i] = result;
                    MessageBox.Show("Channel " + (startChannel + i).ToString() + " result : " + result.ToString(), "Calibration Result", MessageBoxButtons.OK);
                }
                else if (buttonResult == DialogResult.Cancel)
                {
                    endTest = true;
                }
                CalFreqList.Add(FreqMHz);
                CalBandList.Add(calband);
                i++;
                if (i == 16)
                    endTest = true;
            } while (endTest == false);
        }

        public void CalOffset(double inputPower, double[] freqMHzList)
        {
            double Sa_Attenuator = 0;
            double result = 0;
            bool overload  = false;
            Array.Resize(ref CalOffsetList, freqMHzList.Length);
            string msg = "";
            if (inputPower >= 10)
            {
                Sa_Attenuator = 10;
            }
            else if (inputPower >= -10)
            {
                Sa_Attenuator = 0;
            }
            else
            {
                Sa_Attenuator = -10;
            }
            
            VsgSetup(VSG1, freqMHzList[0], inputPower);
            VsaSetup_Pow(freqMHzList[0], Sa_Attenuator);

            MessageBox.Show("Please connect output cable(analyzer) direct to VSG1(source), Once done please press OK to start performance Path Loss Calibration", "Calibration", MessageBoxButtons.OK);
            for (int i = 0; i < freqMHzList.Length; i++)
            {
                VSG1.RF.Frequency = freqMHzList[i] * 1e6;
                VSG1.Apply();
                VSA.RF.Frequency = freqMHzList[i] * 1e6;
                VSA.Apply();

                VSA.PowerAcquisition.ReadPower(0, AgM9391PowerUnitsEnum.AgM9391PowerUnitsdBm, ref result, ref overload);

                CalOffsetList[i] = result - inputPower;
                msg = "Frequency : " + (freqMHzList[i] *1e6).ToString() + "-> Loss : " + CalOffsetList[i] + " , ";

            }

            MessageBox.Show(msg, "Path Loss Result", MessageBoxButtons.OK);
        }

        public void SG_LoadWaveform(string waveform)
        {
            if(waveform.Contains("CW.WAVEFORM"))
            {
                generatePowerRampArb(waveform, 0, 0, 10e-3, 4e6);
            }
        }

        public void SweepTest()
        {
            int channel = GlobalVariable.iTsChannel;
            double SaAttenuator = 0;
            bool overload = false;
            double centFreq = 0;
            double span = 0;
            
            if (channel <= 16)
            {
                SetSwitchPath(GlobalVariable.iTsChannel);
                span = GlobalVariable.StopSweepFreq[0] - GlobalVariable.StartSweepFreq[0];
                VsgSetup(VSG1, GlobalVariable.StartSweepFreq[0], GlobalVariable.SweepAmplitude[0]);
                VsaSetup(GlobalVariable.StartSweepFreq[0], SaAttenuator);
            }
            else if (channel > 16 && channel <= 32)
            {
                SetSwitchPath(GlobalVariable.iTsChannel);
                span = GlobalVariable.StopSweepFreq[1] - GlobalVariable.StartSweepFreq[1];
                VsgSetup(VSG2, GlobalVariable.StartSweepFreq[1], GlobalVariable.SweepAmplitude[1]);
                VsaSetup(GlobalVariable.StartSweepFreq[1], SaAttenuator);
            }
            else if (channel > 32 && channel <= 48)
            {
                SetSwitchPath(GlobalVariable.iTsChannel);
                span = GlobalVariable.StopSweepFreq[2] - GlobalVariable.StartSweepFreq[2];
                VsgSetup(VSG3, GlobalVariable.StartSweepFreq[2], GlobalVariable.SweepAmplitude[2]);
                VsaSetup(GlobalVariable.StartSweepFreq[2], SaAttenuator);
            }
            else if (channel > 48 && channel <= 64)
            {
                SetSwitchPath(GlobalVariable.iTsChannel);
                span = GlobalVariable.StopSweepFreq[3] - GlobalVariable.StartSweepFreq[3];
                VsgSetup(VSG4, GlobalVariable.StartSweepFreq[3], GlobalVariable.SweepAmplitude[3]);
                VsaSetup(GlobalVariable.StartSweepFreq[3], SaAttenuator);
            }

            #region Measurement
            int numPoint = 401;//Convert.ToInt16(span);
            double[][] fftData = new double[numPoint][];
            double[] maxResult = new double[numPoint];
            double freqInt = span / numPoint;

            for (int i = 0; i < numPoint; i++)
            {
                fftData[i] = new double[128];
                if(channel <=16)
                {
                    VSG1.RF.Frequency = (GlobalVariable.StartSweepFreq[0] + (i * freqInt)) * 1e6;
                    VSG1.Apply();
                    VSA.RF.Frequency = (GlobalVariable.StartSweepFreq[0] + (i * freqInt)) * 1e6;
                }
                else if (channel > 16 && channel <= 32)
                {
                    VSG2.RF.Frequency = (GlobalVariable.StartSweepFreq[1] + (i * freqInt)) * 1e6;
                    VSG2.Apply();
                    VSA.RF.Frequency = (GlobalVariable.StartSweepFreq[1] + (i * freqInt)) * 1e6;
                }
                else if (channel > 32 && channel <= 48)
                {
                    VSG3.RF.Frequency = (GlobalVariable.StartSweepFreq[2] + (i * freqInt)) * 1e6;
                    VSG3.Apply();
                    VSA.RF.Frequency = (GlobalVariable.StartSweepFreq[2] + (i * freqInt)) * 1e6;
                }
                else if (channel > 48 && channel <= 64)
                {
                    VSG4.RF.Frequency = (GlobalVariable.StartSweepFreq[3] + (i * freqInt)) * 1e6;
                    VSG4.Apply();
                    VSA.RF.Frequency = (GlobalVariable.StartSweepFreq[3] + (i * freqInt)) * 1e6;
                }
                VSA.Apply();
                VSA.Arm();
                VSA.FFTAcquisition.ReadMagnitudeData(0, ref fftData[i], ref overload);
                if (overload)
                {
                    MessageBox.Show("ADC overload", "Error", MessageBoxButtons.OK);
                }
            }
            #endregion

            #region Process Data
            bool tempCorrelation = false;
            if (tempCorrelation)
            {
                double[] tempMaxData = new double[fftData[1].Length];
                for (int i = 0; i < fftData[1].Length; i++)
                {
                    tempMaxData[i] = -999;
                }

                for (int i = 0; i < numPoint; i++)
                {
                    double[] tempResult = new double[fftData[i].Length];

                    for (int j = 0; j < fftData[i].Length; j++)
                    {
                        tempResult[j] = 10 * Math.Log10(fftData[i][j]);
                        if (tempMaxData[j] <= tempResult[j])
                            tempMaxData[j] = tempResult[j];
                    }
                }
                for (int i = 0; i < numPoint; i++)
                {
                    subSweepResult.Add(tempMaxData[i]);
                }
            }
            else
            {
                
                for (int i = 0; i < numPoint; i++)
                {
                    double[] tempResult = new double[fftData[i].Length];
                    for (int j = 0; j < fftData[i].Length; j++)
                    {
                        tempResult[j] = 10 * Math.Log10(fftData[i][j]);
                    }
                    subSweepResult.Add(tempResult.Max());
                }

            }
            #endregion

           

        }

        public void StressTest_PowOn(double freqMHz, double Sg_InputPower, string Sg_Unit)//chun30516
        {
            //if (stresstestpowon == true)
           // {
                switch (Sg_Unit)
                {
                    case "VSG1":
                        VSG1.RF.Frequency = freqMHz * 1e6;
                        VSG1.ALC.Enabled = true;
                        VSG1.RF.Level = Sg_InputPower;
                        VSG1.Modulation.BasebandPower = 0;
                        VSG1.RF.OutputEnabled = true;
                        VSG1.Apply();
                        break;

                    case "VSG2":
                        VSG2.RF.Frequency = freqMHz * 1e6;
                        VSG2.ALC.Enabled = true;
                        VSG2.RF.Level = Sg_InputPower;
                        VSG2.Modulation.BasebandPower = 0;
                        VSG2.RF.OutputEnabled = true;
                        VSG2.Apply();
                        break;

                    case "VSG3":
                        VSG3.RF.Frequency = freqMHz * 1e6;
                        VSG3.ALC.Enabled = true;
                        VSG3.RF.Level = Sg_InputPower;
                        VSG3.Modulation.BasebandPower = 0;
                        VSG3.RF.OutputEnabled = true;
                        VSG3.Apply();
                        break;

                    case "VSG4":
                        VSG4.RF.Frequency = freqMHz * 1e6;
                        VSG4.ALC.Enabled = true;
                        VSG4.RF.Level = Sg_InputPower;
                        VSG4.Modulation.BasebandPower = 0;
                        VSG4.RF.OutputEnabled = true;
                        VSG4.Apply();
                        break;
                }
            //}
        }
    
        public void StressTest_PowOff(string Sg_Unit)  //30516
        {
            stresstestpowoff = true;
            if (stresstestpowoff == true)
            {
                switch (Sg_Unit)
                {
                    case "VSG1":
                        VSG1.RF.OutputEnabled = false;
                        VSG1.Apply();
                        break;
                    case "VSG2":
                        VSG2.RF.OutputEnabled = false;
                        VSG2.Apply();
                        break;
                    case "VSG3":
                        VSG3.RF.OutputEnabled = false;
                        VSG3.Apply();
                        break;
                    case "VSG4":
                        VSG4.RF.OutputEnabled = false;
                        VSG4.Apply();
                        break;
                }
            }
        }


        public void StressTest()
        {
            int channel = GlobalVariable.iTsChannel;
            double SaAttenuator = 0;
            bool overload = false;
            double result = 0;

            //GlobalVariable.StressFreq = new double[] { 1100, 1200, 1300, 1400 };    //Anthony Temp add
            GlobalVariable.StressAmp = new double[] { -2, -2, -2, -2 };     //Anthony Temp add

            if (channel <= 16)
            {
                VsgSetup(VSG1, GlobalVariable.StressFreq[0], GlobalVariable.StressAmp[0]);
                VsaSetup_Pow(GlobalVariable.StressFreq[0], SaAttenuator);
            }
            else if (channel > 16 && channel <= 32)
            {
                VsgSetup(VSG2, GlobalVariable.StressFreq[1], GlobalVariable.StressAmp[1]);
                VsaSetup_Pow(GlobalVariable.StressFreq[1], SaAttenuator);
            }
            else if (channel > 32 && channel <= 48)
            {
                VsgSetup(VSG3, GlobalVariable.StressFreq[2], GlobalVariable.StressAmp[2]);
                VsaSetup_Pow(GlobalVariable.StressFreq[2], SaAttenuator);
            }
            else if (channel > 48 && channel <= 64)
            {
                VsgSetup(VSG4, GlobalVariable.StressFreq[3], GlobalVariable.StressAmp[3]);
                VsaSetup_Pow(GlobalVariable.StressFreq[3], SaAttenuator);
            }

            #region Measurement
            VSA.Arm();
            VSA.PowerAcquisition.ReadPower(0, AgM9391PowerUnitsEnum.AgM9391PowerUnitsdBm, ref result, ref overload);
            subStressResult.Add(result);

            VSG1.RF.OutputEnabled = false;
            VSG1.Apply();
            VSG2.RF.OutputEnabled = false;
            VSG2.Apply();
            VSG3.RF.OutputEnabled = false;
            VSG3.Apply();
            VSG4.RF.OutputEnabled = false;
            VSG4.Apply();

            #endregion

        }

        public void UpdateConfiguration()
        {

        }

        //public void ReadExcelConditionFile()
        //{
        //    int sRow = 1;
        //    int sCol = 1;

        //    Excel.Application xApps =new Excel.Application();
        //    Excel.Workbook xWorkbook;
        //    Excel.Worksheet xWorksheet;
        //    Excel.Range xRange;

        //    xWorkbook = xApps.Workbooks.Open(GlobalVariable.conditionFilePath);
        //    xWorksheet = (Excel.Worksheet)xWorkbook.Worksheets[1];
        //    xRange = xWorksheet.UsedRange;
        //    int sRowCount = 0;
        //    int sColCount = 0;
        //    bool searchDone = false;
        //    do
        //    {
        //        string checkEnd = "";

        //        checkEnd = xRange.Cells[sRow][sCol];
        //        if (checkEnd.Contains("#end"))
        //        {
        //            searchDone = true;
        //        }
        //        sRow++;
        //        sCol++;
        //        sRowCount++;
        //        sColCount++;
        //    } while (searchDone == false);

        //    for (sRow = 1; sRow <= sRowCount; sRow++)
        //    {
        //        for (sCol = 1; sCol <= sColCount; sCol++)
        //        {
        //            if(sRow ==1)
        //            {
        //                if (sCol == 1)
        //                    GlobalVariable.excelHeader[0] = xRange.Cells[sRow][sCol];
        //                if (sCol == 2)
        //                    GlobalVariable.excelContent[sRow-1][0] = xRange.Cells[sRow][sCol];
        //            }
        //            else if (sRow == 2)
        //            {
        //                if (sCol == 1)
        //                    GlobalVariable.excelHeader[1] = xRange.Cells[sRow][sCol];
        //                if (sCol == 2)
        //                    GlobalVariable.excelContent[sRow - 1][0] = xRange.Cells[sRow][sCol];
        //            }
        //            else if(sRow ==4)
        //            {
        //                GlobalVariable.excelHeader[sCol + 1] = xRange.Cells[sRow][sCol];
        //            }
        //            else if (sRow >= 5)
        //            {
        //                GlobalVariable.excelContent[sRow - 2][sCol - 1] = xRange.Cells[sRow][sCol];
        //                if (GlobalVariable.excelContent[sRow - 2][0].Contains("1"))
        //                    GlobalVariable.bUseVSG1 = true;
        //                if (GlobalVariable.excelContent[sRow - 2][0].Contains("2"))
        //                    GlobalVariable.bUseVSG2 = true;
        //                if (GlobalVariable.excelContent[sRow - 2][0].Contains("3"))
        //                    GlobalVariable.bUseVSG3 = true;
        //                if (GlobalVariable.excelContent[sRow - 2][0].Contains("4"))
        //                    GlobalVariable.bUseVSG4 = true;
        //            }
        //        }
        //    }


        //}

        public void generatePowerRampArb(string refName, double minPower, double maxPower, double duration, double sampleRate)
        {
            
            // Determine number of points
            int numPoints = (int)(1e-3 * sampleRate); // duration 1ms chee on
            int i;
            // Calcualte the scale factors
            double amplitude = Math.Sqrt(2) / 2;
            double scaleIncr = (maxPower - minPower) / (numPoints);

            // Create waveform and build array
            double[] waveform = new double[numPoints * 4];
            //for (int i = 0; i < waveform.Length / 4; i++)
            //{
            //    // Create I and Q and correct amplitude
            //    waveform[2 * i] = amplitude * Math.Pow(10, (minPower + i * scaleIncr) / 20);
            //    waveform[2 * i + 1] = waveform[2 * i];
            //}
            //for (int i = 0; i < waveform.Length / 4; i++)
            //{
            //    // Create I and Q and correct amplitude
            //    waveform[waveform.Length / 2 + 2 * i] = amplitude * Math.Pow(10, (maxPower - i * scaleIncr) / 20);
            //    waveform[waveform.Length / 2 + 2 * i + 1] = waveform[waveform.Length / 2 + 2 * i];
            //}

            for (i = 0; i < waveform.Length / 4; i++)
            {
                // Create I and Q and correct amplitude


                waveform[waveform.Length / 2 + 2 * i] = amplitude * Math.Pow(10, (minPower + i * scaleIncr) / 20);
                waveform[waveform.Length / 2 + 2 * i + 1] = waveform[waveform.Length / 2 + 2 * i];

            
            }
            for (i = 0; i < waveform.Length / 4; i++)
            {
                //  Create I and Q and correct amplitude

                waveform[2 * i] = amplitude * Math.Pow(10, (maxPower - i * scaleIncr) / 20);
                waveform[2 * i + 1] = waveform[2 * i];

            }
            //for (i = 0; i < waveform.Length / 4; i++)
            //{
            //    // Create I and Q and correct amplitude


            //        waveform[waveform.Length / 2 + 2 * i] = amplitude * Math.Pow(10, (minPower + i * scaleIncr) / 20);
            //        waveform[waveform.Length / 2 + 2 * i + 1] = waveform[waveform.Length / 2 + 2 * i];

            //}

            //for (i = 0; i < waveform.Length / 4; i++)
            //{
            //    // Create I and Q and correct amplitude

            //        waveform[2 * i] = amplitude * Math.Pow(10, (maxPower - i * scaleIncr) / 20);
            //        waveform[2 * i + 1] = waveform[2 * i];

            //}

            ////}

            VSG1.Modulation.IQ.UploadArbDoubles(refName, ref waveform, sampleRate, 0, 1);
            VSG2.Modulation.IQ.UploadArbDoubles(refName, ref waveform, sampleRate, 0, 1);
            VSG3.Modulation.IQ.UploadArbDoubles(refName, ref waveform, sampleRate, 0, 1);
            VSG4.Modulation.IQ.UploadArbDoubles(refName, ref waveform, sampleRate, 0, 1);
            
        }

        public void VsgSetup(AgM938x vsg, double freqMHz, double Pin)
        {
            vsg.RF.Frequency = freqMHz * 1e6;
            vsg.Modulation.BasebandFrequency = 0;
            vsg.RF.Level = Pin;
            vsg.Modulation.BasebandPower = 0;
            vsg.RF.OutputEnabled = true;
            vsg.Modulation.PlayArb(Waveform, AgM938xStartEventEnum.AgM938xStartEventImmediate);
            vsg.Modulation.IQ.ArbInformation(Waveform, ref arbSampleRate, ref arbRmsValue, ref arbScale, ref rfMarker, ref alcMarker);
            vsg.Apply();

        }

        public void VsaSetup(double freqMHz, double Sa_Attenuator)
        {
            double FftSpan = 128e6;
            double FftTime = 0;
            int FftLength = 0;

            VSA.RF.Frequency = freqMHz * 1e6;
            VSA.PowerAcquisition.OffsetFrequency = 0;
            VSA.RF.Power = Sa_Attenuator;
            VSA.RF.Conversion = AgM9391ConversionEnum.AgM9391ConversionAuto;
            VSA.RF.IFBandwidth = 4e6;
            VSA.RF.PeakToAverage = arbRmsValue;
            VSA.Modules.Downconverter.PreamplifierMode = AgM9391PreamplifierModesEnum.AgM9391PreamplifierModesOff;
            VSA.AcquisitionMode = AgM9391AcquisitionModeEnum.AgM9391AcquisitionModeFFT;
            VSA.FFTAcquisition.Length = AgM9391FFTAcquisitionLengthEnum.AgM9391FFTAcquisitionLength_128;
            VSA.FFTAcquisition.SampleRate = FftSpan;
            FftLength = VSA.FFTAcquisition.Samples;
            FftTime = FftLength / FftSpan;
            VSA.FFTAcquisition.WindowShape = AgM9391FFTWindowShapeEnum.AgM9391FFTWindowShapeUniform;
            VSA.MemoryMode = AgM9391MemoryModeEnum.AgM9391MemoryModeLargeAcquisition;
            VSA.Apply();
        }

        public void VsaSetup_Pow(double freqMHz, double Sa_Attenuator)
        {
            VSA.AcquisitionMode = AgM9391AcquisitionModeEnum.AgM9391AcquisitionModePower;
            VSA.RF.Frequency = freqMHz * 1e6;
            VSA.RF.Power = Sa_Attenuator;
            VSA.PowerAcquisition.OffsetFrequency = 0;
            VSA.PowerAcquisition.Bandwidth = 4e6;
            VSA.Apply();
        }

       

        ////Create Max Hold Function - Anthony
        //public void MaxHold(double []RawData, double []TempMaxHold, ref double []maxHoldResult)
        //{
        //    int size = RawData.Length;
        //    double [] maxHold = new double[size];

        //    for (int i = 0; i < size; i++)
        //    {
        //        if (RawData[i] > TempMaxHold[i])
        //            TempMaxHold[i] = RawData[i];
        //    }
        //    maxHoldResult = TempMaxHold;
        //}

        //Set PXI M9161D Configuration Path - Design based on 64 channels //Anthony
        public void SetSwitchPath(int channel)
        {
            #region Switch Setup
            switch (channel.ToString())
            {
                case "1":
                    SW02.Route.OpenAll();
                    SW03.Route.OpenAll();
                    SW01.Route.CloseChannel("b1ch1");
                    SW01.Route.CloseChannel("b2ch1");
                    SW03.Route.CloseChannel("b2ch1");
                    break;
                case "2":
                    SW02.Route.OpenAll();
                    SW03.Route.OpenAll();
                    SW01.Route.CloseChannel("b1ch1");
                    SW01.Route.CloseChannel("b2ch1");
                    SW03.Route.CloseChannel("b2ch2");
                    break;
                case "3":
                    SW02.Route.OpenAll();
                    SW03.Route.OpenAll();
                    SW01.Route.CloseChannel("b1ch1");
                    SW01.Route.CloseChannel("b2ch1");
                    SW03.Route.CloseChannel("b2ch3");
                    break;
                case "4":
                    SW02.Route.OpenAll();
                    SW03.Route.OpenAll();
                    SW01.Route.CloseChannel("b1ch1");
                    SW01.Route.CloseChannel("b2ch1");
                    SW03.Route.CloseChannel("b2ch4");
                    break;
                case "5":
                    SW02.Route.OpenAll();
                    SW03.Route.OpenAll();
                    SW01.Route.CloseChannel("b1ch1");
                    SW01.Route.CloseChannel("b2ch2");
                    SW04.Route.CloseChannel("b1ch1");
                    break;
                case "6":
                    SW02.Route.OpenAll();
                    SW03.Route.OpenAll();
                    SW01.Route.CloseChannel("b1ch1");
                    SW01.Route.CloseChannel("b2ch2");
                    SW04.Route.CloseChannel("b1ch2");
                    break;
                case "7":
                    SW02.Route.OpenAll();
                    SW03.Route.OpenAll();
                    SW01.Route.CloseChannel("b1ch1");
                    SW01.Route.CloseChannel("b2ch2");
                    SW04.Route.CloseChannel("b1ch3");
                    break;
                case "8":
                    SW02.Route.OpenAll();
                    SW03.Route.OpenAll();
                    SW01.Route.CloseChannel("b1ch1");
                    SW01.Route.CloseChannel("b2ch2");
                    SW04.Route.CloseChannel("b1ch4");
                    break;
                case "9":
                    SW02.Route.OpenAll();
                    SW03.Route.OpenAll();
                    SW01.Route.CloseChannel("b1ch1");
                    SW01.Route.CloseChannel("b2ch3");
                    SW04.Route.CloseChannel("b2ch1");
                    break;
                case "10":
                    SW02.Route.OpenAll();
                    SW03.Route.OpenAll();
                    SW01.Route.CloseChannel("b1ch1");
                    SW01.Route.CloseChannel("b2ch3");
                    SW04.Route.CloseChannel("b2ch2");
                    break;
                case "11":
                    SW02.Route.OpenAll();
                    SW03.Route.OpenAll();
                    SW01.Route.CloseChannel("b1ch1");
                    SW01.Route.CloseChannel("b2ch3");
                    SW04.Route.CloseChannel("b2ch3");
                    break;
                case "12":
                    SW02.Route.OpenAll();
                    SW03.Route.OpenAll();
                    SW01.Route.CloseChannel("b1ch1");
                    SW01.Route.CloseChannel("b2ch3");
                    SW04.Route.CloseChannel("b2ch4");
                    break;
                case "13":
                    SW02.Route.OpenAll();
                    SW03.Route.OpenAll();
                    SW01.Route.CloseChannel("b1ch1");
                    SW01.Route.CloseChannel("b2ch4");
                    SW05.Route.CloseChannel("b1ch1");
                    break;
                case "14":
                    SW02.Route.OpenAll();
                    SW03.Route.OpenAll();
                    SW01.Route.CloseChannel("b1ch1");
                    SW01.Route.CloseChannel("b2ch4");
                    SW05.Route.CloseChannel("b1ch2");
                    break;
                case "15":
                    SW02.Route.OpenAll();
                    SW03.Route.OpenAll();
                    SW01.Route.CloseChannel("b1ch1");
                    SW01.Route.CloseChannel("b2ch4");
                    SW05.Route.CloseChannel("b1ch3");
                    break;
                case "16":
                    SW02.Route.OpenAll();
                    SW03.Route.OpenAll();
                    SW01.Route.CloseChannel("b1ch1");
                    SW01.Route.CloseChannel("b2ch4");
                    SW05.Route.CloseChannel("b1ch4");
                    break;
                case "17":
                    SW01.Route.OpenAll();
                    SW03.Route.OpenAll();
                    SW01.Route.CloseChannel("b1ch2");
                    SW02.Route.CloseChannel("b1ch1");
                    SW05.Route.CloseChannel("b2ch1");
                    break;
                case "18":
                    SW01.Route.OpenAll();
                    SW03.Route.OpenAll();
                    SW01.Route.CloseChannel("b1ch2");
                    SW02.Route.CloseChannel("b1ch1");
                    SW05.Route.CloseChannel("b2ch2");
                    break;
                case "19":
                    SW01.Route.OpenAll();
                    SW03.Route.OpenAll();
                    SW01.Route.CloseChannel("b1ch2");
                    SW02.Route.CloseChannel("b1ch1");
                    SW05.Route.CloseChannel("b2ch3");
                    break;
                case "20":
                    SW01.Route.OpenAll();
                    SW03.Route.OpenAll();
                    SW01.Route.CloseChannel("b1ch2");
                    SW02.Route.CloseChannel("b1ch1");
                    SW05.Route.CloseChannel("b2ch4");
                    break;
                case "21":
                    SW01.Route.OpenAll();
                    SW03.Route.OpenAll();
                    SW01.Route.CloseChannel("b1ch2");
                    SW02.Route.CloseChannel("b1ch2");
                    SW06.Route.CloseChannel("b1ch1");
                    break;
                case "22":
                    SW01.Route.OpenAll();
                    SW03.Route.OpenAll();
                    SW01.Route.CloseChannel("b1ch2");
                    SW02.Route.CloseChannel("b1ch2");
                    SW06.Route.CloseChannel("b1ch2");
                    break;
                case "23":
                    SW01.Route.OpenAll();
                    SW03.Route.OpenAll();
                    SW01.Route.CloseChannel("b1ch2");
                    SW02.Route.CloseChannel("b1ch2");
                    SW06.Route.CloseChannel("b1ch3");
                    break;
                case "24":
                    SW01.Route.OpenAll();
                    SW03.Route.OpenAll();
                    SW01.Route.CloseChannel("b1ch2");
                    SW02.Route.CloseChannel("b1ch2");
                    SW06.Route.CloseChannel("b1ch4");
                    break;
                case "25":
                    SW01.Route.OpenAll();
                    SW03.Route.OpenAll();
                    SW01.Route.CloseChannel("b1ch2");
                    SW02.Route.CloseChannel("b1ch3");
                    SW06.Route.CloseChannel("b2ch1");
                    break;
                case "26":
                    SW01.Route.OpenAll();
                    SW03.Route.OpenAll();
                    SW01.Route.CloseChannel("b1ch2");
                    SW02.Route.CloseChannel("b1ch3");
                    SW06.Route.CloseChannel("b2ch2");
                    break;
                case "27":
                    SW01.Route.OpenAll();
                    SW03.Route.OpenAll();
                    SW01.Route.CloseChannel("b1ch2");
                    SW02.Route.CloseChannel("b1ch3");
                    SW06.Route.CloseChannel("b2ch3");
                    break;
                case "28":
                    SW01.Route.OpenAll();
                    SW03.Route.OpenAll();
                    SW01.Route.CloseChannel("b1ch2");
                    SW02.Route.CloseChannel("b1ch3");
                    SW06.Route.CloseChannel("b2ch4");
                    break;
                case "29":
                    SW01.Route.OpenAll();
                    SW03.Route.OpenAll();
                    SW01.Route.CloseChannel("b1ch2");
                    SW02.Route.CloseChannel("b1ch4");
                    SW07.Route.CloseChannel("b1ch1");
                    break;
                case "30":
                    SW01.Route.OpenAll();
                    SW03.Route.OpenAll();
                    SW01.Route.CloseChannel("b1ch2");
                    SW02.Route.CloseChannel("b1ch4");
                    SW07.Route.CloseChannel("b1ch2");
                    break;
                case "31":
                    SW01.Route.OpenAll();
                    SW03.Route.OpenAll();
                    SW01.Route.CloseChannel("b1ch2");
                    SW02.Route.CloseChannel("b1ch4");
                    SW07.Route.CloseChannel("b1ch3");
                    break;
                case "32":
                    SW01.Route.OpenAll();
                    SW03.Route.OpenAll();
                    SW01.Route.CloseChannel("b1ch2");
                    SW02.Route.CloseChannel("b1ch4");
                    SW07.Route.CloseChannel("b1ch4");
                    break;
                case "33":
                    SW01.Route.OpenAll();
                    SW03.Route.OpenAll();
                    SW01.Route.CloseChannel("b1ch3");
                    SW02.Route.CloseChannel("b2ch1");
                    SW07.Route.CloseChannel("b2ch1");
                    break;
                case "34":
                    SW01.Route.OpenAll();
                    SW03.Route.OpenAll();
                    SW01.Route.CloseChannel("b1ch3");
                    SW02.Route.CloseChannel("b2ch1");
                    SW07.Route.CloseChannel("b2ch2");
                    break;
                case "35":
                    SW01.Route.OpenAll();
                    SW03.Route.OpenAll();
                    SW01.Route.CloseChannel("b1ch3");
                    SW02.Route.CloseChannel("b2ch1");
                    SW07.Route.CloseChannel("b2ch3");
                    break;
                case "36":
                    SW01.Route.OpenAll();
                    SW03.Route.OpenAll();
                    SW01.Route.CloseChannel("b1ch3");
                    SW02.Route.CloseChannel("b2ch1");
                    SW07.Route.CloseChannel("b2ch4");
                    break;
                case "37":
                    SW01.Route.OpenAll();
                    SW03.Route.OpenAll();
                    SW01.Route.CloseChannel("b1ch3");
                    SW02.Route.CloseChannel("b2ch2");
                    SW08.Route.CloseChannel("b1ch1");
                    break;
                case "38":
                    SW01.Route.OpenAll();
                    SW03.Route.OpenAll();
                    SW01.Route.CloseChannel("b1ch3");
                    SW02.Route.CloseChannel("b2ch2");
                    SW08.Route.CloseChannel("b1ch2");
                    break;
                case "39":
                    SW01.Route.OpenAll();
                    SW03.Route.OpenAll();
                    SW01.Route.CloseChannel("b1ch3");
                    SW02.Route.CloseChannel("b2ch2");
                    SW08.Route.CloseChannel("b1ch3");
                    break;
                case "40":
                    SW01.Route.OpenAll();
                    SW03.Route.OpenAll();
                    SW01.Route.CloseChannel("b1ch3");
                    SW02.Route.CloseChannel("b2ch2");
                    SW08.Route.CloseChannel("b1ch4");
                    break;
                case "41":
                    SW01.Route.OpenAll();
                    SW03.Route.OpenAll();
                    SW01.Route.CloseChannel("b1ch3");
                    SW02.Route.CloseChannel("b2ch3");
                    SW08.Route.CloseChannel("b2ch1");
                    break;
                case "42":
                    SW01.Route.OpenAll();
                    SW03.Route.OpenAll();
                    SW01.Route.CloseChannel("b1ch3");
                    SW02.Route.CloseChannel("b2ch3");
                    SW08.Route.CloseChannel("b2ch2");
                    break;
                case "43":
                    SW01.Route.OpenAll();
                    SW03.Route.OpenAll();
                    SW01.Route.CloseChannel("b1ch3");
                    SW02.Route.CloseChannel("b2ch3");
                    SW08.Route.CloseChannel("b2ch3");
                    break;
                case "44":
                    SW01.Route.OpenAll();
                    SW03.Route.OpenAll();
                    SW01.Route.CloseChannel("b1ch3");
                    SW02.Route.CloseChannel("b2ch3");
                    SW08.Route.CloseChannel("b2ch4");
                    break;
                case "45":
                    SW01.Route.OpenAll();
                    SW03.Route.OpenAll();
                    SW01.Route.CloseChannel("b1ch3");
                    SW02.Route.CloseChannel("b2ch4");
                    SW09.Route.CloseChannel("b1ch1");
                    break;
                case "46":
                    SW01.Route.OpenAll();
                    SW03.Route.OpenAll();
                    SW01.Route.CloseChannel("b1ch3");
                    SW02.Route.CloseChannel("b2ch4");
                    SW09.Route.CloseChannel("b1ch2");
                    break;
                case "47":
                    SW01.Route.OpenAll();
                    SW03.Route.OpenAll();
                    SW01.Route.CloseChannel("b1ch3");
                    SW02.Route.CloseChannel("b2ch4");
                    SW09.Route.CloseChannel("b1ch3");
                    break;
                case "48":
                    SW01.Route.OpenAll();
                    SW03.Route.OpenAll();
                    SW01.Route.CloseChannel("b1ch3");
                    SW02.Route.CloseChannel("b2ch4");
                    SW09.Route.CloseChannel("b1ch4");
                    break;
                case "49":
                    SW01.Route.OpenAll();
                    SW02.Route.OpenAll();
                    SW01.Route.CloseChannel("b1ch4");
                    SW03.Route.CloseChannel("b1ch1");
                    SW09.Route.CloseChannel("b2ch1");
                    break;
                case "50":
                    SW01.Route.OpenAll();
                    SW02.Route.OpenAll();
                    SW01.Route.CloseChannel("b1ch4");
                    SW03.Route.CloseChannel("b1ch1");
                    SW09.Route.CloseChannel("b2ch2");
                    break;
                case "51":
                    SW01.Route.OpenAll();
                    SW02.Route.OpenAll();
                    SW01.Route.CloseChannel("b1ch4");
                    SW03.Route.CloseChannel("b1ch1");
                    SW09.Route.CloseChannel("b2ch3");
                    break;
                case "52":
                    SW01.Route.OpenAll();
                    SW02.Route.OpenAll();
                    SW01.Route.CloseChannel("b1ch4");
                    SW03.Route.CloseChannel("b1ch1");
                    SW09.Route.CloseChannel("b2ch4");
                    break;
                case "53":
                    SW01.Route.OpenAll();
                    SW02.Route.OpenAll();
                    SW01.Route.CloseChannel("b1ch4");
                    SW03.Route.CloseChannel("b1ch2");
                    SW10.Route.CloseChannel("b1ch1");
                    break;
                case "54":
                    SW01.Route.OpenAll();
                    SW02.Route.OpenAll();
                    SW01.Route.CloseChannel("b1ch4");
                    SW03.Route.CloseChannel("b1ch2");
                    SW10.Route.CloseChannel("b1ch2");
                    break;
                case "55":
                    SW01.Route.OpenAll();
                    SW02.Route.OpenAll();
                    SW01.Route.CloseChannel("b1ch4");
                    SW03.Route.CloseChannel("b1ch2");
                    SW10.Route.CloseChannel("b1ch3");
                    break;
                case "56":
                    SW01.Route.OpenAll();
                    SW02.Route.OpenAll();
                    SW01.Route.CloseChannel("b1ch4");
                    SW03.Route.CloseChannel("b1ch2");
                    SW10.Route.CloseChannel("b1ch4");
                    break;
                case "57":
                    SW01.Route.OpenAll();
                    SW02.Route.OpenAll();
                    SW01.Route.CloseChannel("b1ch4");
                    SW03.Route.CloseChannel("b1ch3");
                    SW10.Route.CloseChannel("b2ch1");
                    break;
                case "58":
                    SW01.Route.OpenAll();
                    SW02.Route.OpenAll();
                    SW01.Route.CloseChannel("b1ch4");
                    SW03.Route.CloseChannel("b1ch3");
                    SW10.Route.CloseChannel("b2ch2");
                    break;
                case "59":
                    SW01.Route.OpenAll();
                    SW02.Route.OpenAll();
                    SW01.Route.CloseChannel("b1ch4");
                    SW03.Route.CloseChannel("b1ch3");
                    SW10.Route.CloseChannel("b2ch3");
                    break;
                case "60":
                    SW01.Route.OpenAll();
                    SW02.Route.OpenAll();
                    SW01.Route.CloseChannel("b1ch4");
                    SW03.Route.CloseChannel("b1ch3");
                    SW10.Route.CloseChannel("b2ch4");
                    break;
                case "61":
                    SW01.Route.OpenAll();
                    SW02.Route.OpenAll();
                    SW01.Route.CloseChannel("b1ch4");
                    SW03.Route.CloseChannel("b1ch4");
                    SW11.Route.CloseChannel("b1ch1");
                    break;
                case "62":
                    SW01.Route.OpenAll();
                    SW02.Route.OpenAll();
                    SW01.Route.CloseChannel("b1ch4");
                    SW03.Route.CloseChannel("b1ch4");
                    SW11.Route.CloseChannel("b1ch2");
                    break;
                case "63":
                    SW01.Route.OpenAll();
                    SW02.Route.OpenAll();
                    SW01.Route.CloseChannel("b1ch4");
                    SW03.Route.CloseChannel("b1ch4");
                    SW11.Route.CloseChannel("b1ch3");
                    break;
                case "64":
                    SW01.Route.OpenAll();
                    SW02.Route.OpenAll();
                    SW01.Route.CloseChannel("b1ch4");
                    SW03.Route.CloseChannel("b1ch4");
                    SW11.Route.CloseChannel("b1ch4");
                    break;
                default:
                    SW01.Route.OpenAll();
                    SW02.Route.OpenAll();
                    SW03.Route.OpenAll();
                    SW04.Route.OpenAll();
                    SW05.Route.OpenAll();
                    SW06.Route.OpenAll();
                    SW07.Route.OpenAll();
                    SW08.Route.OpenAll();
                    SW09.Route.OpenAll();
                    SW10.Route.OpenAll();
                    SW11.Route.OpenAll();
                    MessageBox.Show("Channel do not in List", "Switch Error Message", MessageBoxButtons.OK);
                    break;

            }
            #endregion
        }
    }
}
