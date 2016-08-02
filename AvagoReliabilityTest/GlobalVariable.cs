namespace AvagoReliabilityTest
{
    public class GlobalVariable
    {
        public static Agilent.AgM9391.Interop.AgM9391 VSA { get; set; }
        public static Agilent.AgM938x.Interop.AgM938x VSG1 { get; set; }
        public static Agilent.AgM938x.Interop.AgM938x VSG2 { get; set; }
        public static Agilent.AgM938x.Interop.AgM938x VSG3 { get; set; }
        public static Agilent.AgM938x.Interop.AgM938x VSG4 { get; set; }

        public static Agilent.AgMWSwitch.Interop.AgMWSwitch SW01 { get; set; }
        public static Agilent.AgMWSwitch.Interop.AgMWSwitch SW02 { get; set; }
        public static Agilent.AgMWSwitch.Interop.AgMWSwitch SW03 { get; set; }
        public static Agilent.AgMWSwitch.Interop.AgMWSwitch SW04 { get; set; }
        public static Agilent.AgMWSwitch.Interop.AgMWSwitch SW05 { get; set; }
        public static Agilent.AgMWSwitch.Interop.AgMWSwitch SW06 { get; set; }
        public static Agilent.AgMWSwitch.Interop.AgMWSwitch SW07 { get; set; }
        public static Agilent.AgMWSwitch.Interop.AgMWSwitch SW08 { get; set; }
        public static Agilent.AgMWSwitch.Interop.AgMWSwitch SW09 { get; set; }
        public static Agilent.AgMWSwitch.Interop.AgMWSwitch SW10 { get; set; }
        public static Agilent.AgMWSwitch.Interop.AgMWSwitch SW11 { get; set; }

        public static bool bCloseCalForm { get; set; }
        public static bool bCloseMainForm { get; set; }
        public static bool bCloseSubCalFomr { get; set; }
        public static bool bUseVSG1 { get; set; }
        public static bool bUseVSG2 { get; set; }
        public static bool bUseVSG3 { get; set; }
        public static bool bUseVSG4 { get; set; }
        public static bool bRunTest { get; set; }
        public static bool Cal1To8 { get; set; }
        public static bool Cal9To16 { get; set; }
        public static bool Cal17To24 { get; set; }
        public static bool Cal25To32 { get; set; }
        public static bool Cal33To40 { get; set; }
        public static bool Cal41To48 { get; set; }
        public static bool Cal49To56 { get; set; }
        public static bool Cal57To64 { get; set; }
        public static bool CalForm1 { get; set; }
        public static bool CalForm2 { get; set; }
        public static bool CalForm3 { get; set; }
        public static bool CalForm4 { get; set; }
        public static bool isStop { get; set; }
        public static bool timerStart { get; set; }
        public static bool fileDateSet { get; set; }
        public static bool abortSet { get; set; }


        public static double dStartFreq1 { get; set; }
        public static double dStartFreq2 { get; set; }
        public static double dStartFreq3 { get; set; }
        public static double dStartFreq4 { get; set; }
        public static double dStopFreq1 { get; set; }
        public static double dStopFreq2 { get; set; }
        public static double dStopFreq3 { get; set; }
        public static double dStopFreq4 { get; set; }
        public static double dAmplitude { get; set; }
        public static double dCalResult { get; set; }
        public static double dCalFreq1 { get; set; }
        public static double dCalFreq2 { get; set; }
        public static double dCalFreq3 { get; set; }
        public static double dCalFreq4 { get; set; }

        public static int iCalCount { get; set; }
        public static int iTsChannel { get; set; }
        public static float iDelayTimeMs { get; set; }//chun
        public static float iTotalTimeMs { get; set; }//chun
        public static int numTest { get; set; }

        public static string conditionFilePath { get; set; }
        public static string dataFilePath { get; set; }
        public static string[] excelHeader { get; set; }
        public static string[][] excelContent { get; set; }
        public static string calFileName { get; set; }
        public static string calBand1 { get; set; }
        public static string calBand2 { get; set; }
        public static string calBand3 { get; set; }
        public static string calBand4 { get; set; }

        //Condition File
        public static string Chamber { get; set; }
        public static string Date { get; set; }
        public static double[] VsgUnit { get; set; }
        public static int[] StartChannel { get; set; }
        public static int[] StopChannel { get; set; }
        public static string[] ProductName { get; set; }
        public static string[] RdcNumber { get; set; }
        public static double[] StartSweepFreq { get; set; }
        public static double[] StopSweepFreq { get; set; }
        public static double[] SweepAmplitude { get; set; }
        public static double[] StressFreq { get; set; }
        public static double[] StressAmp { get; set; }

        //Result
        
    }
}
