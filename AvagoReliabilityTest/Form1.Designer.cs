namespace AvagoReliabilityTest
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        protected override void OnFormClosing(System.Windows.Forms.FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            //Anthony Temporary Disable
            //LibPXI.Instrument_Uninit();
        }
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._txtstresson_CH49 = new System.Windows.Forms.TextBox();
            this._txtstresson_CH33 = new System.Windows.Forms.TextBox();
            this._txtstresson_CH17 = new System.Windows.Forms.TextBox();
            this._txtstresson_CH1 = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this._txtFilename = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this._txtStressFreq4MHz = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this._txtStopFreq4 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this._txtStartFreq4 = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this._txtStressFreq3MHz = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this._txtStartFreq3 = new System.Windows.Forms.TextBox();
            this._txtStopFreq3 = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this._txtStressFreq2MHz = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this._txtStartFreq2 = new System.Windows.Forms.TextBox();
            this._txtStopFreq2 = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this._txtStressFreq1MHz = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this._txtStartFreq1 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this._txtStopFreq1 = new System.Windows.Forms.TextBox();
            this._txtBurnInDuration = new System.Windows.Forms.TextBox();
            this._txtBIInterval = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._txtEstFinishTestDate = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this._txtsecond = new System.Windows.Forms.TextBox();
            this._txtminute = new System.Windows.Forms.TextBox();
            this._txthour = new System.Windows.Forms.TextBox();
            this._txtChannelDisplay = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this._txtTimeToNextMeas = new System.Windows.Forms.TextBox();
            this._txtBurnInStarted = new System.Windows.Forms.TextBox();
            this._txtElapsedBITime = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this._btntestrun = new System.Windows.Forms.Button();
            this._btnClear = new System.Windows.Forms.Button();
            this._btnExit = new System.Windows.Forms.Button();
            this._btnCalibration = new System.Windows.Forms.Button();
            this._btnAbort = new System.Windows.Forms.Button();
            this._btnStart = new System.Windows.Forms.Button();
            this._btnInit = new System.Windows.Forms.Button();
            this._pnChart = new System.Windows.Forms.Panel();
            this._btnCH56 = new System.Windows.Forms.Button();
            this._btnCH61 = new System.Windows.Forms.Button();
            this.panel64 = new System.Windows.Forms.Panel();
            this._btnCH64 = new System.Windows.Forms.Button();
            this._btnCH63 = new System.Windows.Forms.Button();
            this._btnCH62 = new System.Windows.Forms.Button();
            this.panel63 = new System.Windows.Forms.Panel();
            this._btnCH60 = new System.Windows.Forms.Button();
            this._btnCH59 = new System.Windows.Forms.Button();
            this._btnCH58 = new System.Windows.Forms.Button();
            this._btnCH57 = new System.Windows.Forms.Button();
            this.panel35 = new System.Windows.Forms.Panel();
            this.panel60 = new System.Windows.Forms.Panel();
            this.panel59 = new System.Windows.Forms.Panel();
            this.panel58 = new System.Windows.Forms.Panel();
            this.panel62 = new System.Windows.Forms.Panel();
            this.panel57 = new System.Windows.Forms.Panel();
            this.panel56 = new System.Windows.Forms.Panel();
            this.panel61 = new System.Windows.Forms.Panel();
            this.panel55 = new System.Windows.Forms.Panel();
            this.panel54 = new System.Windows.Forms.Panel();
            this.panel53 = new System.Windows.Forms.Panel();
            this.panel52 = new System.Windows.Forms.Panel();
            this.panel51 = new System.Windows.Forms.Panel();
            this.panel50 = new System.Windows.Forms.Panel();
            this.panel49 = new System.Windows.Forms.Panel();
            this.panel48 = new System.Windows.Forms.Panel();
            this.panel47 = new System.Windows.Forms.Panel();
            this.panel46 = new System.Windows.Forms.Panel();
            this.panel45 = new System.Windows.Forms.Panel();
            this.panel44 = new System.Windows.Forms.Panel();
            this.panel43 = new System.Windows.Forms.Panel();
            this.panel42 = new System.Windows.Forms.Panel();
            this.panel41 = new System.Windows.Forms.Panel();
            this.panel40 = new System.Windows.Forms.Panel();
            this.panel39 = new System.Windows.Forms.Panel();
            this.panel38 = new System.Windows.Forms.Panel();
            this.panel37 = new System.Windows.Forms.Panel();
            this.panel36 = new System.Windows.Forms.Panel();
            this.panel34 = new System.Windows.Forms.Panel();
            this.panel33 = new System.Windows.Forms.Panel();
            this.panel32 = new System.Windows.Forms.Panel();
            this.panel31 = new System.Windows.Forms.Panel();
            this.panel30 = new System.Windows.Forms.Panel();
            this.panel29 = new System.Windows.Forms.Panel();
            this.panel28 = new System.Windows.Forms.Panel();
            this.panel27 = new System.Windows.Forms.Panel();
            this.panel26 = new System.Windows.Forms.Panel();
            this.panel25 = new System.Windows.Forms.Panel();
            this.panel24 = new System.Windows.Forms.Panel();
            this.panel23 = new System.Windows.Forms.Panel();
            this.panel22 = new System.Windows.Forms.Panel();
            this.panel21 = new System.Windows.Forms.Panel();
            this.panel20 = new System.Windows.Forms.Panel();
            this.panel19 = new System.Windows.Forms.Panel();
            this.panel18 = new System.Windows.Forms.Panel();
            this.panel17 = new System.Windows.Forms.Panel();
            this.panel16 = new System.Windows.Forms.Panel();
            this.panel15 = new System.Windows.Forms.Panel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this._btnCH55 = new System.Windows.Forms.Button();
            this._btnCH54 = new System.Windows.Forms.Button();
            this._btnCH53 = new System.Windows.Forms.Button();
            this._btnCH52 = new System.Windows.Forms.Button();
            this._btnCH50 = new System.Windows.Forms.Button();
            this._btnCH49 = new System.Windows.Forms.Button();
            this._btnCH48 = new System.Windows.Forms.Button();
            this._btnCH47 = new System.Windows.Forms.Button();
            this._btnCH45 = new System.Windows.Forms.Button();
            this._btnCH44 = new System.Windows.Forms.Button();
            this._btnCH43 = new System.Windows.Forms.Button();
            this._btnCH42 = new System.Windows.Forms.Button();
            this._btnCH40 = new System.Windows.Forms.Button();
            this._btnCH39 = new System.Windows.Forms.Button();
            this._btnCH38 = new System.Windows.Forms.Button();
            this._btnCH37 = new System.Windows.Forms.Button();
            this._btnCH35 = new System.Windows.Forms.Button();
            this._btnCH34 = new System.Windows.Forms.Button();
            this._btnCH33 = new System.Windows.Forms.Button();
            this._btnCH32 = new System.Windows.Forms.Button();
            this._btnCH30 = new System.Windows.Forms.Button();
            this._btnCH29 = new System.Windows.Forms.Button();
            this._btnCH28 = new System.Windows.Forms.Button();
            this._btnCH27 = new System.Windows.Forms.Button();
            this._btnCH25 = new System.Windows.Forms.Button();
            this._btnCH24 = new System.Windows.Forms.Button();
            this._btnCH23 = new System.Windows.Forms.Button();
            this._btnCH22 = new System.Windows.Forms.Button();
            this._btnCH20 = new System.Windows.Forms.Button();
            this._btnCH19 = new System.Windows.Forms.Button();
            this._btnCH18 = new System.Windows.Forms.Button();
            this._btnCH17 = new System.Windows.Forms.Button();
            this._btnCH15 = new System.Windows.Forms.Button();
            this._btnCH14 = new System.Windows.Forms.Button();
            this._btnCH13 = new System.Windows.Forms.Button();
            this._btnCH12 = new System.Windows.Forms.Button();
            this._btnCH10 = new System.Windows.Forms.Button();
            this._btnCH9 = new System.Windows.Forms.Button();
            this._btnCH8 = new System.Windows.Forms.Button();
            this._btnCH7 = new System.Windows.Forms.Button();
            this._btnCH5 = new System.Windows.Forms.Button();
            this._btnCH4 = new System.Windows.Forms.Button();
            this._btnCH3 = new System.Windows.Forms.Button();
            this._btnCH2 = new System.Windows.Forms.Button();
            this._btnCH51 = new System.Windows.Forms.Button();
            this._btnCH46 = new System.Windows.Forms.Button();
            this._btnCH41 = new System.Windows.Forms.Button();
            this._btnCH36 = new System.Windows.Forms.Button();
            this._btnCH31 = new System.Windows.Forms.Button();
            this._btnCH26 = new System.Windows.Forms.Button();
            this._btnCH21 = new System.Windows.Forms.Button();
            this._btnCH16 = new System.Windows.Forms.Button();
            this._btnCH11 = new System.Windows.Forms.Button();
            this._btnCH6 = new System.Windows.Forms.Button();
            this._btnCH1 = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.BItimer = new System.Windows.Forms.Timer(this.components);
            this.timer_end = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this._pnChart.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox8);
            this.groupBox1.Controls.Add(this._txtFilename);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.groupBox7);
            this.groupBox1.Controls.Add(this.groupBox6);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this._txtBurnInDuration);
            this.groupBox1.Controls.Add(this._txtBIInterval);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(16, 11);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1365, 223);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Setting";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.label1);
            this.groupBox8.Controls.Add(this.label2);
            this.groupBox8.Controls.Add(this._txtstresson_CH49);
            this.groupBox8.Controls.Add(this._txtstresson_CH33);
            this.groupBox8.Controls.Add(this._txtstresson_CH17);
            this.groupBox8.Controls.Add(this._txtstresson_CH1);
            this.groupBox8.Controls.Add(this.label27);
            this.groupBox8.Controls.Add(this.label26);
            this.groupBox8.Location = new System.Drawing.Point(7, 116);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox8.Size = new System.Drawing.Size(605, 80);
            this.groupBox8.TabIndex = 49;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "When stress test is on / off (dBm) : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 17);
            this.label1.TabIndex = 42;
            this.label1.Text = "VSA 1 Channel 01 :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 17);
            this.label2.TabIndex = 43;
            this.label2.Text = "VSA 2 Channel 17 :";
            // 
            // _txtstresson_CH49
            // 
            this._txtstresson_CH49.Location = new System.Drawing.Point(424, 46);
            this._txtstresson_CH49.Margin = new System.Windows.Forms.Padding(4);
            this._txtstresson_CH49.Name = "_txtstresson_CH49";
            this._txtstresson_CH49.ReadOnly = true;
            this._txtstresson_CH49.Size = new System.Drawing.Size(104, 22);
            this._txtstresson_CH49.TabIndex = 47;
            this._txtstresson_CH49.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _txtstresson_CH33
            // 
            this._txtstresson_CH33.Location = new System.Drawing.Point(424, 20);
            this._txtstresson_CH33.Margin = new System.Windows.Forms.Padding(4);
            this._txtstresson_CH33.Name = "_txtstresson_CH33";
            this._txtstresson_CH33.ReadOnly = true;
            this._txtstresson_CH33.Size = new System.Drawing.Size(104, 22);
            this._txtstresson_CH33.TabIndex = 46;
            this._txtstresson_CH33.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _txtstresson_CH17
            // 
            this._txtstresson_CH17.Location = new System.Drawing.Point(144, 47);
            this._txtstresson_CH17.Margin = new System.Windows.Forms.Padding(4);
            this._txtstresson_CH17.Name = "_txtstresson_CH17";
            this._txtstresson_CH17.ReadOnly = true;
            this._txtstresson_CH17.Size = new System.Drawing.Size(104, 22);
            this._txtstresson_CH17.TabIndex = 3;
            this._txtstresson_CH17.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _txtstresson_CH1
            // 
            this._txtstresson_CH1.Location = new System.Drawing.Point(144, 22);
            this._txtstresson_CH1.Margin = new System.Windows.Forms.Padding(4);
            this._txtstresson_CH1.Name = "_txtstresson_CH1";
            this._txtstresson_CH1.ReadOnly = true;
            this._txtstresson_CH1.Size = new System.Drawing.Size(104, 22);
            this._txtstresson_CH1.TabIndex = 1;
            this._txtstresson_CH1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(285, 46);
            this.label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(131, 17);
            this.label27.TabIndex = 45;
            this.label27.Text = "VSA 4 Channel 49 :";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(284, 20);
            this.label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(131, 17);
            this.label26.TabIndex = 44;
            this.label26.Text = "VSA 3 Channel 33 :";
            // 
            // _txtFilename
            // 
            this._txtFilename.Location = new System.Drawing.Point(199, 21);
            this._txtFilename.Margin = new System.Windows.Forms.Padding(4);
            this._txtFilename.Name = "_txtFilename";
            this._txtFilename.Size = new System.Drawing.Size(392, 22);
            this._txtFilename.TabIndex = 41;
            this._txtFilename.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(8, 26);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(173, 17);
            this.label21.TabIndex = 40;
            this.label21.Text = "File name                        : ";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this._txtStressFreq4MHz);
            this.groupBox7.Controls.Add(this.label20);
            this.groupBox7.Controls.Add(this.label17);
            this.groupBox7.Controls.Add(this._txtStopFreq4);
            this.groupBox7.Controls.Add(this.label6);
            this.groupBox7.Controls.Add(this._txtStartFreq4);
            this.groupBox7.Location = new System.Drawing.Point(619, 158);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox7.Size = new System.Drawing.Size(740, 46);
            this.groupBox7.TabIndex = 39;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "VSG 4";
            // 
            // _txtStressFreq4MHz
            // 
            this._txtStressFreq4MHz.Location = new System.Drawing.Point(619, 16);
            this._txtStressFreq4MHz.Margin = new System.Windows.Forms.Padding(4);
            this._txtStressFreq4MHz.Name = "_txtStressFreq4MHz";
            this._txtStressFreq4MHz.Size = new System.Drawing.Size(105, 22);
            this._txtStressFreq4MHz.TabIndex = 42;
            this._txtStressFreq4MHz.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._txtStressFreq4MHz.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._txtStressFreq4MHz_KeyPress);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(485, 20);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(127, 17);
            this.label20.TabIndex = 42;
            this.label20.Text = "Stress Freq (MHz):";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(247, 20);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(116, 17);
            this.label17.TabIndex = 42;
            this.label17.Text = "Stop Freq (MHz):";
            // 
            // _txtStopFreq4
            // 
            this._txtStopFreq4.Location = new System.Drawing.Point(371, 16);
            this._txtStopFreq4.Margin = new System.Windows.Forms.Padding(4);
            this._txtStopFreq4.Name = "_txtStopFreq4";
            this._txtStopFreq4.Size = new System.Drawing.Size(105, 22);
            this._txtStopFreq4.TabIndex = 36;
            this._txtStopFreq4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._txtStopFreq4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._txtStopFreq4_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 20);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 17);
            this.label6.TabIndex = 42;
            this.label6.Text = "Start Freq (MHz):";
            // 
            // _txtStartFreq4
            // 
            this._txtStartFreq4.Location = new System.Drawing.Point(132, 16);
            this._txtStartFreq4.Margin = new System.Windows.Forms.Padding(4);
            this._txtStartFreq4.Name = "_txtStartFreq4";
            this._txtStartFreq4.Size = new System.Drawing.Size(105, 22);
            this._txtStartFreq4.TabIndex = 30;
            this._txtStartFreq4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._txtStartFreq4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._txtStartFreq4_KeyPress);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label19);
            this.groupBox6.Controls.Add(this.label16);
            this.groupBox6.Controls.Add(this._txtStressFreq3MHz);
            this.groupBox6.Controls.Add(this.label7);
            this.groupBox6.Controls.Add(this._txtStartFreq3);
            this.groupBox6.Controls.Add(this._txtStopFreq3);
            this.groupBox6.Location = new System.Drawing.Point(619, 110);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox6.Size = new System.Drawing.Size(740, 46);
            this.groupBox6.TabIndex = 39;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "VSG 3";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(485, 20);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(127, 17);
            this.label19.TabIndex = 41;
            this.label19.Text = "Stress Freq (MHz):";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(247, 20);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(116, 17);
            this.label16.TabIndex = 41;
            this.label16.Text = "Stop Freq (MHz):";
            // 
            // _txtStressFreq3MHz
            // 
            this._txtStressFreq3MHz.Location = new System.Drawing.Point(619, 16);
            this._txtStressFreq3MHz.Margin = new System.Windows.Forms.Padding(4);
            this._txtStressFreq3MHz.Name = "_txtStressFreq3MHz";
            this._txtStressFreq3MHz.Size = new System.Drawing.Size(105, 22);
            this._txtStressFreq3MHz.TabIndex = 41;
            this._txtStressFreq3MHz.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._txtStressFreq3MHz.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._txtStressFreq3MHz_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 20);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 17);
            this.label7.TabIndex = 40;
            this.label7.Text = "Start Freq (MHz):";
            // 
            // _txtStartFreq3
            // 
            this._txtStartFreq3.Location = new System.Drawing.Point(132, 16);
            this._txtStartFreq3.Margin = new System.Windows.Forms.Padding(4);
            this._txtStartFreq3.Name = "_txtStartFreq3";
            this._txtStartFreq3.Size = new System.Drawing.Size(105, 22);
            this._txtStartFreq3.TabIndex = 29;
            this._txtStartFreq3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._txtStartFreq3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._txtStartFreq3_KeyPress);
            // 
            // _txtStopFreq3
            // 
            this._txtStopFreq3.Location = new System.Drawing.Point(371, 16);
            this._txtStopFreq3.Margin = new System.Windows.Forms.Padding(4);
            this._txtStopFreq3.Name = "_txtStopFreq3";
            this._txtStopFreq3.Size = new System.Drawing.Size(105, 22);
            this._txtStopFreq3.TabIndex = 35;
            this._txtStopFreq3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._txtStopFreq3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._txtStopFreq3_KeyPress);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this._txtStressFreq2MHz);
            this.groupBox5.Controls.Add(this.label18);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this._txtStartFreq2);
            this.groupBox5.Controls.Add(this._txtStopFreq2);
            this.groupBox5.Location = new System.Drawing.Point(619, 60);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox5.Size = new System.Drawing.Size(740, 46);
            this.groupBox5.TabIndex = 38;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "VSG 2";
            // 
            // _txtStressFreq2MHz
            // 
            this._txtStressFreq2MHz.Location = new System.Drawing.Point(619, 17);
            this._txtStressFreq2MHz.Margin = new System.Windows.Forms.Padding(4);
            this._txtStressFreq2MHz.Name = "_txtStressFreq2MHz";
            this._txtStressFreq2MHz.Size = new System.Drawing.Size(105, 22);
            this._txtStressFreq2MHz.TabIndex = 27;
            this._txtStressFreq2MHz.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._txtStressFreq2MHz.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._txtStressFreq2MHz_KeyPress);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(485, 21);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(127, 17);
            this.label18.TabIndex = 27;
            this.label18.Text = "Stress Freq (MHz):";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(247, 21);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(116, 17);
            this.label14.TabIndex = 40;
            this.label14.Text = "Stop Freq (MHz):";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 21);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 17);
            this.label8.TabIndex = 39;
            this.label8.Text = "Start Freq (MHz):";
            // 
            // _txtStartFreq2
            // 
            this._txtStartFreq2.Location = new System.Drawing.Point(132, 17);
            this._txtStartFreq2.Margin = new System.Windows.Forms.Padding(4);
            this._txtStartFreq2.Name = "_txtStartFreq2";
            this._txtStartFreq2.Size = new System.Drawing.Size(105, 22);
            this._txtStartFreq2.TabIndex = 28;
            this._txtStartFreq2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._txtStartFreq2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._txtStartFreq2_KeyPress);
            // 
            // _txtStopFreq2
            // 
            this._txtStopFreq2.Location = new System.Drawing.Point(371, 17);
            this._txtStopFreq2.Margin = new System.Windows.Forms.Padding(4);
            this._txtStopFreq2.Name = "_txtStopFreq2";
            this._txtStopFreq2.Size = new System.Drawing.Size(105, 22);
            this._txtStopFreq2.TabIndex = 34;
            this._txtStopFreq2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._txtStopFreq2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._txtStopFreq2_KeyPress);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this._txtStressFreq1MHz);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this._txtStartFreq1);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this._txtStopFreq1);
            this.groupBox4.Location = new System.Drawing.Point(619, 12);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(740, 46);
            this.groupBox4.TabIndex = 37;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "VSG 1";
            // 
            // _txtStressFreq1MHz
            // 
            this._txtStressFreq1MHz.Location = new System.Drawing.Point(619, 17);
            this._txtStressFreq1MHz.Margin = new System.Windows.Forms.Padding(4);
            this._txtStressFreq1MHz.Name = "_txtStressFreq1MHz";
            this._txtStressFreq1MHz.Size = new System.Drawing.Size(105, 22);
            this._txtStressFreq1MHz.TabIndex = 26;
            this._txtStressFreq1MHz.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._txtStressFreq1MHz.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._txtStressFreq1MHz_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(485, 21);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(127, 17);
            this.label12.TabIndex = 25;
            this.label12.Text = "Stress Freq (MHz):";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 20);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Start Freq (MHz):";
            // 
            // _txtStartFreq1
            // 
            this._txtStartFreq1.Location = new System.Drawing.Point(132, 16);
            this._txtStartFreq1.Margin = new System.Windows.Forms.Padding(4);
            this._txtStartFreq1.Name = "_txtStartFreq1";
            this._txtStartFreq1.Size = new System.Drawing.Size(105, 22);
            this._txtStartFreq1.TabIndex = 21;
            this._txtStartFreq1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._txtStartFreq1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._txtStartFreq1_KeyPress);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(247, 21);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(116, 17);
            this.label15.TabIndex = 24;
            this.label15.Text = "Stop Freq (MHz):";
            // 
            // _txtStopFreq1
            // 
            this._txtStopFreq1.Location = new System.Drawing.Point(371, 16);
            this._txtStopFreq1.Margin = new System.Windows.Forms.Padding(4);
            this._txtStopFreq1.Name = "_txtStopFreq1";
            this._txtStopFreq1.Size = new System.Drawing.Size(105, 22);
            this._txtStopFreq1.TabIndex = 23;
            this._txtStopFreq1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._txtStopFreq1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._txtStopFreq1_KeyPress);
            // 
            // _txtBurnInDuration
            // 
            this._txtBurnInDuration.Location = new System.Drawing.Point(199, 76);
            this._txtBurnInDuration.Margin = new System.Windows.Forms.Padding(4);
            this._txtBurnInDuration.Name = "_txtBurnInDuration";
            this._txtBurnInDuration.Size = new System.Drawing.Size(140, 22);
            this._txtBurnInDuration.TabIndex = 7;
            this._txtBurnInDuration.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._txtBurnInDuration.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._txtBurnInDuration_KeyPress);
            // 
            // _txtBIInterval
            // 
            this._txtBIInterval.Location = new System.Drawing.Point(199, 48);
            this._txtBIInterval.Margin = new System.Windows.Forms.Padding(4);
            this._txtBIInterval.Name = "_txtBIInterval";
            this._txtBIInterval.Size = new System.Drawing.Size(141, 22);
            this._txtBIInterval.TabIndex = 6;
            this._txtBIInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._txtBIInterval.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._txtBIInterval_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 79);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Burn In Duration (hours) :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 50);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Burn In Interval (hours)   :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(9, 69);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(206, 24);
            this.label9.TabIndex = 16;
            this.label9.Text = "Elapsed B.I Time(hrs)  :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(9, 115);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(208, 24);
            this.label10.TabIndex = 17;
            this.label10.Text = "Time to Next Meas.      :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(15, 162);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(209, 24);
            this.label11.TabIndex = 18;
            this.label11.Text = "Burn In Started On        :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._txtEstFinishTestDate);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this._txtsecond);
            this.groupBox2.Controls.Add(this._txtminute);
            this.groupBox2.Controls.Add(this._txthour);
            this.groupBox2.Controls.Add(this._txtChannelDisplay);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this._txtTimeToNextMeas);
            this.groupBox2.Controls.Add(this._txtBurnInStarted);
            this.groupBox2.Controls.Add(this._txtElapsedBITime);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(1393, 11);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(520, 244);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Time Display";
            // 
            // _txtEstFinishTestDate
            // 
            this._txtEstFinishTestDate.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this._txtEstFinishTestDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtEstFinishTestDate.Location = new System.Drawing.Point(233, 20);
            this._txtEstFinishTestDate.Margin = new System.Windows.Forms.Padding(4);
            this._txtEstFinishTestDate.Name = "_txtEstFinishTestDate";
            this._txtEstFinishTestDate.ReadOnly = true;
            this._txtEstFinishTestDate.Size = new System.Drawing.Size(111, 30);
            this._txtEstFinishTestDate.TabIndex = 46;
            this._txtEstFinishTestDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(8, 26);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(206, 24);
            this.label25.TabIndex = 45;
            this.label25.Text = "Est. Finish Test Date    :";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(372, 203);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(64, 17);
            this.label24.TabIndex = 44;
            this.label24.Text = "Second :";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(230, 203);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(58, 17);
            this.label23.TabIndex = 43;
            this.label23.Text = "Minute :";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(88, 203);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(47, 17);
            this.label22.TabIndex = 42;
            this.label22.Text = "Hour :";
            // 
            // _txtsecond
            // 
            this._txtsecond.Location = new System.Drawing.Point(444, 200);
            this._txtsecond.Margin = new System.Windows.Forms.Padding(4);
            this._txtsecond.Name = "_txtsecond";
            this._txtsecond.ReadOnly = true;
            this._txtsecond.Size = new System.Drawing.Size(48, 22);
            this._txtsecond.TabIndex = 27;
            this._txtsecond.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _txtminute
            // 
            this._txtminute.Location = new System.Drawing.Point(296, 200);
            this._txtminute.Margin = new System.Windows.Forms.Padding(4);
            this._txtminute.Name = "_txtminute";
            this._txtminute.ReadOnly = true;
            this._txtminute.Size = new System.Drawing.Size(48, 22);
            this._txtminute.TabIndex = 26;
            this._txtminute.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _txthour
            // 
            this._txthour.Location = new System.Drawing.Point(143, 200);
            this._txthour.Margin = new System.Windows.Forms.Padding(4);
            this._txthour.Name = "_txthour";
            this._txthour.ReadOnly = true;
            this._txthour.Size = new System.Drawing.Size(48, 22);
            this._txthour.TabIndex = 25;
            this._txthour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _txtChannelDisplay
            // 
            this._txtChannelDisplay.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this._txtChannelDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 38.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtChannelDisplay.Location = new System.Drawing.Point(375, 86);
            this._txtChannelDisplay.Margin = new System.Windows.Forms.Padding(4);
            this._txtChannelDisplay.Name = "_txtChannelDisplay";
            this._txtChannelDisplay.ReadOnly = true;
            this._txtChannelDisplay.Size = new System.Drawing.Size(113, 80);
            this._txtChannelDisplay.TabIndex = 24;
            this._txtChannelDisplay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(382, 48);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(97, 25);
            this.label13.TabIndex = 23;
            this.label13.Text = "Channel :";
            // 
            // _txtTimeToNextMeas
            // 
            this._txtTimeToNextMeas.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this._txtTimeToNextMeas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtTimeToNextMeas.Location = new System.Drawing.Point(232, 111);
            this._txtTimeToNextMeas.Margin = new System.Windows.Forms.Padding(4);
            this._txtTimeToNextMeas.Name = "_txtTimeToNextMeas";
            this._txtTimeToNextMeas.ReadOnly = true;
            this._txtTimeToNextMeas.Size = new System.Drawing.Size(111, 30);
            this._txtTimeToNextMeas.TabIndex = 21;
            this._txtTimeToNextMeas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _txtBurnInStarted
            // 
            this._txtBurnInStarted.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this._txtBurnInStarted.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtBurnInStarted.Location = new System.Drawing.Point(232, 156);
            this._txtBurnInStarted.Margin = new System.Windows.Forms.Padding(4);
            this._txtBurnInStarted.Name = "_txtBurnInStarted";
            this._txtBurnInStarted.ReadOnly = true;
            this._txtBurnInStarted.Size = new System.Drawing.Size(111, 30);
            this._txtBurnInStarted.TabIndex = 20;
            this._txtBurnInStarted.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _txtElapsedBITime
            // 
            this._txtElapsedBITime.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this._txtElapsedBITime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtElapsedBITime.Location = new System.Drawing.Point(232, 65);
            this._txtElapsedBITime.Margin = new System.Windows.Forms.Padding(4);
            this._txtElapsedBITime.Name = "_txtElapsedBITime";
            this._txtElapsedBITime.ReadOnly = true;
            this._txtElapsedBITime.Size = new System.Drawing.Size(111, 30);
            this._txtElapsedBITime.TabIndex = 19;
            this._txtElapsedBITime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this._btntestrun);
            this.groupBox3.Controls.Add(this._btnClear);
            this.groupBox3.Controls.Add(this._btnExit);
            this.groupBox3.Controls.Add(this._btnCalibration);
            this.groupBox3.Controls.Add(this._btnAbort);
            this.groupBox3.Controls.Add(this._btnStart);
            this.groupBox3.Controls.Add(this._btnInit);
            this.groupBox3.Location = new System.Drawing.Point(1739, 263);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(160, 742);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            // 
            // _btntestrun
            // 
            this._btntestrun.BackColor = System.Drawing.Color.Orange;
            this._btntestrun.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btntestrun.Location = new System.Drawing.Point(8, 128);
            this._btntestrun.Margin = new System.Windows.Forms.Padding(4);
            this._btntestrun.Name = "_btntestrun";
            this._btntestrun.Size = new System.Drawing.Size(144, 70);
            this._btntestrun.TabIndex = 6;
            this._btntestrun.Text = " TEST RUN ";
            this._btntestrun.UseVisualStyleBackColor = false;
            this._btntestrun.Visible = false;
            this._btntestrun.Click += new System.EventHandler(this._btntestrun_Click);
            // 
            // _btnClear
            // 
            this._btnClear.BackColor = System.Drawing.Color.Yellow;
            this._btnClear.Font = new System.Drawing.Font("Calibri", 18.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnClear.Location = new System.Drawing.Point(8, 427);
            this._btnClear.Margin = new System.Windows.Forms.Padding(4);
            this._btnClear.Name = "_btnClear";
            this._btnClear.Size = new System.Drawing.Size(144, 74);
            this._btnClear.TabIndex = 5;
            this._btnClear.Text = "CLEAR";
            this._btnClear.UseVisualStyleBackColor = false;
            this._btnClear.Visible = false;
            this._btnClear.Click += new System.EventHandler(this._btnClear_Click);
            // 
            // _btnExit
            // 
            this._btnExit.BackColor = System.Drawing.Color.Aqua;
            this._btnExit.Font = new System.Drawing.Font("Calibri", 18.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnExit.Location = new System.Drawing.Point(8, 647);
            this._btnExit.Margin = new System.Windows.Forms.Padding(4);
            this._btnExit.Name = "_btnExit";
            this._btnExit.Size = new System.Drawing.Size(144, 74);
            this._btnExit.TabIndex = 4;
            this._btnExit.Text = "EXIT";
            this._btnExit.UseVisualStyleBackColor = false;
            this._btnExit.Click += new System.EventHandler(this._btnExit_Click);
            // 
            // _btnCalibration
            // 
            this._btnCalibration.BackColor = System.Drawing.Color.Fuchsia;
            this._btnCalibration.Font = new System.Drawing.Font("Calibri", 18.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnCalibration.Location = new System.Drawing.Point(8, 538);
            this._btnCalibration.Margin = new System.Windows.Forms.Padding(4);
            this._btnCalibration.Name = "_btnCalibration";
            this._btnCalibration.Size = new System.Drawing.Size(144, 74);
            this._btnCalibration.TabIndex = 3;
            this._btnCalibration.Text = "CAL";
            this._btnCalibration.UseVisualStyleBackColor = false;
            this._btnCalibration.Visible = false;
            this._btnCalibration.Click += new System.EventHandler(this._btnCalibration_Click);
            // 
            // _btnAbort
            // 
            this._btnAbort.BackColor = System.Drawing.Color.Red;
            this._btnAbort.Font = new System.Drawing.Font("Calibri", 18.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnAbort.Location = new System.Drawing.Point(8, 324);
            this._btnAbort.Margin = new System.Windows.Forms.Padding(4);
            this._btnAbort.Name = "_btnAbort";
            this._btnAbort.Size = new System.Drawing.Size(144, 74);
            this._btnAbort.TabIndex = 2;
            this._btnAbort.Text = "ABORT";
            this._btnAbort.UseVisualStyleBackColor = false;
            this._btnAbort.Click += new System.EventHandler(this._btnAbort_Click);
            // 
            // _btnStart
            // 
            this._btnStart.BackColor = System.Drawing.Color.Lime;
            this._btnStart.Font = new System.Drawing.Font("Calibri", 18.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnStart.Location = new System.Drawing.Point(8, 225);
            this._btnStart.Margin = new System.Windows.Forms.Padding(4);
            this._btnStart.Name = "_btnStart";
            this._btnStart.Size = new System.Drawing.Size(144, 70);
            this._btnStart.TabIndex = 1;
            this._btnStart.Text = "START";
            this._btnStart.UseVisualStyleBackColor = false;
            this._btnStart.Visible = false;
            this._btnStart.Click += new System.EventHandler(this._btnStart_Click);
            // 
            // _btnInit
            // 
            this._btnInit.BackColor = System.Drawing.Color.Blue;
            this._btnInit.Font = new System.Drawing.Font("Calibri", 18.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnInit.Location = new System.Drawing.Point(8, 23);
            this._btnInit.Margin = new System.Windows.Forms.Padding(4);
            this._btnInit.Name = "_btnInit";
            this._btnInit.Size = new System.Drawing.Size(144, 74);
            this._btnInit.TabIndex = 0;
            this._btnInit.Text = "INIT";
            this._btnInit.UseVisualStyleBackColor = false;
            this._btnInit.Click += new System.EventHandler(this._btnInit_Click);
            // 
            // _pnChart
            // 
            this._pnChart.AutoScroll = true;
            this._pnChart.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._pnChart.Controls.Add(this._btnCH56);
            this._pnChart.Controls.Add(this._btnCH61);
            this._pnChart.Controls.Add(this.panel64);
            this._pnChart.Controls.Add(this._btnCH64);
            this._pnChart.Controls.Add(this._btnCH63);
            this._pnChart.Controls.Add(this._btnCH62);
            this._pnChart.Controls.Add(this.panel63);
            this._pnChart.Controls.Add(this._btnCH60);
            this._pnChart.Controls.Add(this._btnCH59);
            this._pnChart.Controls.Add(this._btnCH58);
            this._pnChart.Controls.Add(this._btnCH57);
            this._pnChart.Controls.Add(this.panel35);
            this._pnChart.Controls.Add(this.panel60);
            this._pnChart.Controls.Add(this.panel59);
            this._pnChart.Controls.Add(this.panel58);
            this._pnChart.Controls.Add(this.panel62);
            this._pnChart.Controls.Add(this.panel57);
            this._pnChart.Controls.Add(this.panel56);
            this._pnChart.Controls.Add(this.panel61);
            this._pnChart.Controls.Add(this.panel55);
            this._pnChart.Controls.Add(this.panel54);
            this._pnChart.Controls.Add(this.panel53);
            this._pnChart.Controls.Add(this.panel52);
            this._pnChart.Controls.Add(this.panel51);
            this._pnChart.Controls.Add(this.panel50);
            this._pnChart.Controls.Add(this.panel49);
            this._pnChart.Controls.Add(this.panel48);
            this._pnChart.Controls.Add(this.panel47);
            this._pnChart.Controls.Add(this.panel46);
            this._pnChart.Controls.Add(this.panel45);
            this._pnChart.Controls.Add(this.panel44);
            this._pnChart.Controls.Add(this.panel43);
            this._pnChart.Controls.Add(this.panel42);
            this._pnChart.Controls.Add(this.panel41);
            this._pnChart.Controls.Add(this.panel40);
            this._pnChart.Controls.Add(this.panel39);
            this._pnChart.Controls.Add(this.panel38);
            this._pnChart.Controls.Add(this.panel37);
            this._pnChart.Controls.Add(this.panel36);
            this._pnChart.Controls.Add(this.panel34);
            this._pnChart.Controls.Add(this.panel33);
            this._pnChart.Controls.Add(this.panel32);
            this._pnChart.Controls.Add(this.panel31);
            this._pnChart.Controls.Add(this.panel30);
            this._pnChart.Controls.Add(this.panel29);
            this._pnChart.Controls.Add(this.panel28);
            this._pnChart.Controls.Add(this.panel27);
            this._pnChart.Controls.Add(this.panel26);
            this._pnChart.Controls.Add(this.panel25);
            this._pnChart.Controls.Add(this.panel24);
            this._pnChart.Controls.Add(this.panel23);
            this._pnChart.Controls.Add(this.panel22);
            this._pnChart.Controls.Add(this.panel21);
            this._pnChart.Controls.Add(this.panel20);
            this._pnChart.Controls.Add(this.panel19);
            this._pnChart.Controls.Add(this.panel18);
            this._pnChart.Controls.Add(this.panel17);
            this._pnChart.Controls.Add(this.panel16);
            this._pnChart.Controls.Add(this.panel15);
            this._pnChart.Controls.Add(this.panel14);
            this._pnChart.Controls.Add(this.panel13);
            this._pnChart.Controls.Add(this.panel12);
            this._pnChart.Controls.Add(this.panel11);
            this._pnChart.Controls.Add(this.panel10);
            this._pnChart.Controls.Add(this.panel9);
            this._pnChart.Controls.Add(this.panel8);
            this._pnChart.Controls.Add(this.panel7);
            this._pnChart.Controls.Add(this.panel6);
            this._pnChart.Controls.Add(this.panel5);
            this._pnChart.Controls.Add(this.panel4);
            this._pnChart.Controls.Add(this.panel3);
            this._pnChart.Controls.Add(this.panel2);
            this._pnChart.Controls.Add(this.panel1);
            this._pnChart.Controls.Add(this._btnCH55);
            this._pnChart.Controls.Add(this._btnCH54);
            this._pnChart.Controls.Add(this._btnCH53);
            this._pnChart.Controls.Add(this._btnCH52);
            this._pnChart.Controls.Add(this._btnCH50);
            this._pnChart.Controls.Add(this._btnCH49);
            this._pnChart.Controls.Add(this._btnCH48);
            this._pnChart.Controls.Add(this._btnCH47);
            this._pnChart.Controls.Add(this._btnCH45);
            this._pnChart.Controls.Add(this._btnCH44);
            this._pnChart.Controls.Add(this._btnCH43);
            this._pnChart.Controls.Add(this._btnCH42);
            this._pnChart.Controls.Add(this._btnCH40);
            this._pnChart.Controls.Add(this._btnCH39);
            this._pnChart.Controls.Add(this._btnCH38);
            this._pnChart.Controls.Add(this._btnCH37);
            this._pnChart.Controls.Add(this._btnCH35);
            this._pnChart.Controls.Add(this._btnCH34);
            this._pnChart.Controls.Add(this._btnCH33);
            this._pnChart.Controls.Add(this._btnCH32);
            this._pnChart.Controls.Add(this._btnCH30);
            this._pnChart.Controls.Add(this._btnCH29);
            this._pnChart.Controls.Add(this._btnCH28);
            this._pnChart.Controls.Add(this._btnCH27);
            this._pnChart.Controls.Add(this._btnCH25);
            this._pnChart.Controls.Add(this._btnCH24);
            this._pnChart.Controls.Add(this._btnCH23);
            this._pnChart.Controls.Add(this._btnCH22);
            this._pnChart.Controls.Add(this._btnCH20);
            this._pnChart.Controls.Add(this._btnCH19);
            this._pnChart.Controls.Add(this._btnCH18);
            this._pnChart.Controls.Add(this._btnCH17);
            this._pnChart.Controls.Add(this._btnCH15);
            this._pnChart.Controls.Add(this._btnCH14);
            this._pnChart.Controls.Add(this._btnCH13);
            this._pnChart.Controls.Add(this._btnCH12);
            this._pnChart.Controls.Add(this._btnCH10);
            this._pnChart.Controls.Add(this._btnCH9);
            this._pnChart.Controls.Add(this._btnCH8);
            this._pnChart.Controls.Add(this._btnCH7);
            this._pnChart.Controls.Add(this._btnCH5);
            this._pnChart.Controls.Add(this._btnCH4);
            this._pnChart.Controls.Add(this._btnCH3);
            this._pnChart.Controls.Add(this._btnCH2);
            this._pnChart.Controls.Add(this._btnCH51);
            this._pnChart.Controls.Add(this._btnCH46);
            this._pnChart.Controls.Add(this._btnCH41);
            this._pnChart.Controls.Add(this._btnCH36);
            this._pnChart.Controls.Add(this._btnCH31);
            this._pnChart.Controls.Add(this._btnCH26);
            this._pnChart.Controls.Add(this._btnCH21);
            this._pnChart.Controls.Add(this._btnCH16);
            this._pnChart.Controls.Add(this._btnCH11);
            this._pnChart.Controls.Add(this._btnCH6);
            this._pnChart.Controls.Add(this._btnCH1);
            this._pnChart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._pnChart.Location = new System.Drawing.Point(16, 263);
            this._pnChart.Margin = new System.Windows.Forms.Padding(4);
            this._pnChart.Name = "_pnChart";
            this._pnChart.Size = new System.Drawing.Size(1717, 754);
            this._pnChart.TabIndex = 21;
            // 
            // _btnCH56
            // 
            this._btnCH56.Enabled = false;
            this._btnCH56.Location = new System.Drawing.Point(5, 3313);
            this._btnCH56.Margin = new System.Windows.Forms.Padding(4);
            this._btnCH56.Name = "_btnCH56";
            this._btnCH56.Size = new System.Drawing.Size(333, 28);
            this._btnCH56.TabIndex = 169;
            this._btnCH56.Text = "CH56";
            this._btnCH56.UseVisualStyleBackColor = true;
            this._btnCH56.Click += new System.EventHandler(this._btnCH56_Click);
            // 
            // _btnCH61
            // 
            this._btnCH61.Enabled = false;
            this._btnCH61.Location = new System.Drawing.Point(4, 3577);
            this._btnCH61.Margin = new System.Windows.Forms.Padding(4);
            this._btnCH61.Name = "_btnCH61";
            this._btnCH61.Size = new System.Drawing.Size(333, 28);
            this._btnCH61.TabIndex = 34;
            this._btnCH61.Text = "CH61";
            this._btnCH61.UseVisualStyleBackColor = true;
            this._btnCH61.Click += new System.EventHandler(this._btnCH61_Click);
            // 
            // panel64
            // 
            this.panel64.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel64.Location = new System.Drawing.Point(1029, 3351);
            this.panel64.Margin = new System.Windows.Forms.Padding(4);
            this.panel64.Name = "panel64";
            this.panel64.Size = new System.Drawing.Size(333, 222);
            this.panel64.TabIndex = 167;
            // 
            // _btnCH64
            // 
            this._btnCH64.Enabled = false;
            this._btnCH64.Location = new System.Drawing.Point(1029, 3580);
            this._btnCH64.Margin = new System.Windows.Forms.Padding(4);
            this._btnCH64.Name = "_btnCH64";
            this._btnCH64.Size = new System.Drawing.Size(333, 28);
            this._btnCH64.TabIndex = 136;
            this._btnCH64.Text = "CH64";
            this._btnCH64.UseVisualStyleBackColor = true;
            this._btnCH64.Click += new System.EventHandler(this._btnCH64_Click);
            // 
            // _btnCH63
            // 
            this._btnCH63.Enabled = false;
            this._btnCH63.Location = new System.Drawing.Point(688, 3580);
            this._btnCH63.Margin = new System.Windows.Forms.Padding(4);
            this._btnCH63.Name = "_btnCH63";
            this._btnCH63.Size = new System.Drawing.Size(333, 28);
            this._btnCH63.TabIndex = 134;
            this._btnCH63.Text = "CH63";
            this._btnCH63.UseVisualStyleBackColor = true;
            this._btnCH63.Click += new System.EventHandler(this._btnCH63_Click);
            // 
            // _btnCH62
            // 
            this._btnCH62.Enabled = false;
            this._btnCH62.Location = new System.Drawing.Point(347, 3580);
            this._btnCH62.Margin = new System.Windows.Forms.Padding(4);
            this._btnCH62.Name = "_btnCH62";
            this._btnCH62.Size = new System.Drawing.Size(333, 28);
            this._btnCH62.TabIndex = 132;
            this._btnCH62.Text = "CH62";
            this._btnCH62.UseVisualStyleBackColor = true;
            this._btnCH62.Click += new System.EventHandler(this._btnCH62_Click);
            // 
            // panel63
            // 
            this.panel63.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel63.Location = new System.Drawing.Point(688, 3351);
            this.panel63.Margin = new System.Windows.Forms.Padding(4);
            this.panel63.Name = "panel63";
            this.panel63.Size = new System.Drawing.Size(333, 222);
            this.panel63.TabIndex = 166;
            // 
            // _btnCH60
            // 
            this._btnCH60.Enabled = false;
            this._btnCH60.Location = new System.Drawing.Point(1369, 3316);
            this._btnCH60.Margin = new System.Windows.Forms.Padding(4);
            this._btnCH60.Name = "_btnCH60";
            this._btnCH60.Size = new System.Drawing.Size(333, 28);
            this._btnCH60.TabIndex = 130;
            this._btnCH60.Text = "CH60";
            this._btnCH60.UseVisualStyleBackColor = true;
            this._btnCH60.Click += new System.EventHandler(this._btnCH60_Click);
            // 
            // _btnCH59
            // 
            this._btnCH59.Enabled = false;
            this._btnCH59.Location = new System.Drawing.Point(1028, 3316);
            this._btnCH59.Margin = new System.Windows.Forms.Padding(4);
            this._btnCH59.Name = "_btnCH59";
            this._btnCH59.Size = new System.Drawing.Size(333, 28);
            this._btnCH59.TabIndex = 128;
            this._btnCH59.Text = "CH59";
            this._btnCH59.UseVisualStyleBackColor = true;
            this._btnCH59.Click += new System.EventHandler(this._btnCH59_Click);
            // 
            // _btnCH58
            // 
            this._btnCH58.Enabled = false;
            this._btnCH58.Location = new System.Drawing.Point(688, 3316);
            this._btnCH58.Margin = new System.Windows.Forms.Padding(4);
            this._btnCH58.Name = "_btnCH58";
            this._btnCH58.Size = new System.Drawing.Size(333, 28);
            this._btnCH58.TabIndex = 126;
            this._btnCH58.Text = "CH58";
            this._btnCH58.UseVisualStyleBackColor = true;
            this._btnCH58.Click += new System.EventHandler(this._btnCH58_Click);
            // 
            // _btnCH57
            // 
            this._btnCH57.Enabled = false;
            this._btnCH57.Location = new System.Drawing.Point(347, 3316);
            this._btnCH57.Margin = new System.Windows.Forms.Padding(4);
            this._btnCH57.Name = "_btnCH57";
            this._btnCH57.Size = new System.Drawing.Size(333, 28);
            this._btnCH57.TabIndex = 124;
            this._btnCH57.Text = "CH57";
            this._btnCH57.UseVisualStyleBackColor = true;
            this._btnCH57.Click += new System.EventHandler(this._btnCH57_Click);
            // 
            // panel35
            // 
            this.panel35.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel35.Location = new System.Drawing.Point(1371, 1666);
            this.panel35.Margin = new System.Windows.Forms.Padding(4);
            this.panel35.Name = "panel35";
            this.panel35.Size = new System.Drawing.Size(333, 246);
            this.panel35.TabIndex = 168;
            // 
            // panel60
            // 
            this.panel60.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel60.Location = new System.Drawing.Point(1369, 3087);
            this.panel60.Margin = new System.Windows.Forms.Padding(4);
            this.panel60.Name = "panel60";
            this.panel60.Size = new System.Drawing.Size(333, 222);
            this.panel60.TabIndex = 163;
            // 
            // panel59
            // 
            this.panel59.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel59.Location = new System.Drawing.Point(1029, 3087);
            this.panel59.Margin = new System.Windows.Forms.Padding(4);
            this.panel59.Name = "panel59";
            this.panel59.Size = new System.Drawing.Size(333, 222);
            this.panel59.TabIndex = 162;
            // 
            // panel58
            // 
            this.panel58.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel58.Location = new System.Drawing.Point(688, 3087);
            this.panel58.Margin = new System.Windows.Forms.Padding(4);
            this.panel58.Name = "panel58";
            this.panel58.Size = new System.Drawing.Size(333, 222);
            this.panel58.TabIndex = 161;
            // 
            // panel62
            // 
            this.panel62.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel62.Location = new System.Drawing.Point(347, 3351);
            this.panel62.Margin = new System.Windows.Forms.Padding(4);
            this.panel62.Name = "panel62";
            this.panel62.Size = new System.Drawing.Size(333, 222);
            this.panel62.TabIndex = 165;
            // 
            // panel57
            // 
            this.panel57.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel57.Location = new System.Drawing.Point(347, 3087);
            this.panel57.Margin = new System.Windows.Forms.Padding(4);
            this.panel57.Name = "panel57";
            this.panel57.Size = new System.Drawing.Size(333, 222);
            this.panel57.TabIndex = 160;
            // 
            // panel56
            // 
            this.panel56.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel56.Location = new System.Drawing.Point(5, 3087);
            this.panel56.Margin = new System.Windows.Forms.Padding(4);
            this.panel56.Name = "panel56";
            this.panel56.Size = new System.Drawing.Size(333, 222);
            this.panel56.TabIndex = 159;
            // 
            // panel61
            // 
            this.panel61.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel61.Location = new System.Drawing.Point(5, 3349);
            this.panel61.Margin = new System.Windows.Forms.Padding(4);
            this.panel61.Name = "panel61";
            this.panel61.Size = new System.Drawing.Size(333, 222);
            this.panel61.TabIndex = 164;
            // 
            // panel55
            // 
            this.panel55.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel55.Location = new System.Drawing.Point(1371, 2822);
            this.panel55.Margin = new System.Windows.Forms.Padding(4);
            this.panel55.Name = "panel55";
            this.panel55.Size = new System.Drawing.Size(333, 222);
            this.panel55.TabIndex = 152;
            // 
            // panel54
            // 
            this.panel54.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel54.Location = new System.Drawing.Point(1029, 2822);
            this.panel54.Margin = new System.Windows.Forms.Padding(4);
            this.panel54.Name = "panel54";
            this.panel54.Size = new System.Drawing.Size(333, 222);
            this.panel54.TabIndex = 152;
            // 
            // panel53
            // 
            this.panel53.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel53.Location = new System.Drawing.Point(688, 2822);
            this.panel53.Margin = new System.Windows.Forms.Padding(4);
            this.panel53.Name = "panel53";
            this.panel53.Size = new System.Drawing.Size(333, 222);
            this.panel53.TabIndex = 152;
            // 
            // panel52
            // 
            this.panel52.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel52.Location = new System.Drawing.Point(347, 2822);
            this.panel52.Margin = new System.Windows.Forms.Padding(4);
            this.panel52.Name = "panel52";
            this.panel52.Size = new System.Drawing.Size(333, 222);
            this.panel52.TabIndex = 152;
            // 
            // panel51
            // 
            this.panel51.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel51.Location = new System.Drawing.Point(4, 2822);
            this.panel51.Margin = new System.Windows.Forms.Padding(4);
            this.panel51.Name = "panel51";
            this.panel51.Size = new System.Drawing.Size(333, 222);
            this.panel51.TabIndex = 158;
            // 
            // panel50
            // 
            this.panel50.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel50.Location = new System.Drawing.Point(1371, 2533);
            this.panel50.Margin = new System.Windows.Forms.Padding(4);
            this.panel50.Name = "panel50";
            this.panel50.Size = new System.Drawing.Size(333, 246);
            this.panel50.TabIndex = 151;
            // 
            // panel49
            // 
            this.panel49.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel49.Location = new System.Drawing.Point(1029, 2533);
            this.panel49.Margin = new System.Windows.Forms.Padding(4);
            this.panel49.Name = "panel49";
            this.panel49.Size = new System.Drawing.Size(333, 246);
            this.panel49.TabIndex = 151;
            // 
            // panel48
            // 
            this.panel48.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel48.Location = new System.Drawing.Point(688, 2533);
            this.panel48.Margin = new System.Windows.Forms.Padding(4);
            this.panel48.Name = "panel48";
            this.panel48.Size = new System.Drawing.Size(333, 246);
            this.panel48.TabIndex = 151;
            // 
            // panel47
            // 
            this.panel47.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel47.Location = new System.Drawing.Point(347, 2533);
            this.panel47.Margin = new System.Windows.Forms.Padding(4);
            this.panel47.Name = "panel47";
            this.panel47.Size = new System.Drawing.Size(333, 246);
            this.panel47.TabIndex = 151;
            // 
            // panel46
            // 
            this.panel46.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel46.Location = new System.Drawing.Point(4, 2533);
            this.panel46.Margin = new System.Windows.Forms.Padding(4);
            this.panel46.Name = "panel46";
            this.panel46.Size = new System.Drawing.Size(333, 246);
            this.panel46.TabIndex = 151;
            // 
            // panel45
            // 
            this.panel45.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel45.Location = new System.Drawing.Point(1371, 2244);
            this.panel45.Margin = new System.Windows.Forms.Padding(4);
            this.panel45.Name = "panel45";
            this.panel45.Size = new System.Drawing.Size(333, 246);
            this.panel45.TabIndex = 150;
            // 
            // panel44
            // 
            this.panel44.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel44.Location = new System.Drawing.Point(1029, 2244);
            this.panel44.Margin = new System.Windows.Forms.Padding(4);
            this.panel44.Name = "panel44";
            this.panel44.Size = new System.Drawing.Size(333, 246);
            this.panel44.TabIndex = 150;
            // 
            // panel43
            // 
            this.panel43.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel43.Location = new System.Drawing.Point(688, 2244);
            this.panel43.Margin = new System.Windows.Forms.Padding(4);
            this.panel43.Name = "panel43";
            this.panel43.Size = new System.Drawing.Size(333, 246);
            this.panel43.TabIndex = 150;
            // 
            // panel42
            // 
            this.panel42.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel42.Location = new System.Drawing.Point(347, 2244);
            this.panel42.Margin = new System.Windows.Forms.Padding(4);
            this.panel42.Name = "panel42";
            this.panel42.Size = new System.Drawing.Size(333, 246);
            this.panel42.TabIndex = 150;
            // 
            // panel41
            // 
            this.panel41.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel41.Location = new System.Drawing.Point(4, 2244);
            this.panel41.Margin = new System.Windows.Forms.Padding(4);
            this.panel41.Name = "panel41";
            this.panel41.Size = new System.Drawing.Size(333, 246);
            this.panel41.TabIndex = 157;
            // 
            // panel40
            // 
            this.panel40.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel40.Location = new System.Drawing.Point(1371, 1954);
            this.panel40.Margin = new System.Windows.Forms.Padding(4);
            this.panel40.Name = "panel40";
            this.panel40.Size = new System.Drawing.Size(333, 246);
            this.panel40.TabIndex = 150;
            // 
            // panel39
            // 
            this.panel39.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel39.Location = new System.Drawing.Point(1029, 1954);
            this.panel39.Margin = new System.Windows.Forms.Padding(4);
            this.panel39.Name = "panel39";
            this.panel39.Size = new System.Drawing.Size(333, 246);
            this.panel39.TabIndex = 150;
            // 
            // panel38
            // 
            this.panel38.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel38.Location = new System.Drawing.Point(688, 1956);
            this.panel38.Margin = new System.Windows.Forms.Padding(4);
            this.panel38.Name = "panel38";
            this.panel38.Size = new System.Drawing.Size(333, 246);
            this.panel38.TabIndex = 150;
            // 
            // panel37
            // 
            this.panel37.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel37.Location = new System.Drawing.Point(347, 1956);
            this.panel37.Margin = new System.Windows.Forms.Padding(4);
            this.panel37.Name = "panel37";
            this.panel37.Size = new System.Drawing.Size(333, 246);
            this.panel37.TabIndex = 150;
            // 
            // panel36
            // 
            this.panel36.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel36.Location = new System.Drawing.Point(4, 1956);
            this.panel36.Margin = new System.Windows.Forms.Padding(4);
            this.panel36.Name = "panel36";
            this.panel36.Size = new System.Drawing.Size(333, 246);
            this.panel36.TabIndex = 150;
            // 
            // panel34
            // 
            this.panel34.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel34.Location = new System.Drawing.Point(1029, 1666);
            this.panel34.Margin = new System.Windows.Forms.Padding(4);
            this.panel34.Name = "panel34";
            this.panel34.Size = new System.Drawing.Size(333, 246);
            this.panel34.TabIndex = 150;
            // 
            // panel33
            // 
            this.panel33.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel33.Location = new System.Drawing.Point(688, 1668);
            this.panel33.Margin = new System.Windows.Forms.Padding(4);
            this.panel33.Name = "panel33";
            this.panel33.Size = new System.Drawing.Size(333, 246);
            this.panel33.TabIndex = 150;
            // 
            // panel32
            // 
            this.panel32.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel32.Location = new System.Drawing.Point(347, 1666);
            this.panel32.Margin = new System.Windows.Forms.Padding(4);
            this.panel32.Name = "panel32";
            this.panel32.Size = new System.Drawing.Size(333, 246);
            this.panel32.TabIndex = 150;
            // 
            // panel31
            // 
            this.panel31.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel31.Location = new System.Drawing.Point(4, 1668);
            this.panel31.Margin = new System.Windows.Forms.Padding(4);
            this.panel31.Name = "panel31";
            this.panel31.Size = new System.Drawing.Size(333, 246);
            this.panel31.TabIndex = 149;
            // 
            // panel30
            // 
            this.panel30.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel30.Location = new System.Drawing.Point(1371, 1377);
            this.panel30.Margin = new System.Windows.Forms.Padding(4);
            this.panel30.Name = "panel30";
            this.panel30.Size = new System.Drawing.Size(333, 246);
            this.panel30.TabIndex = 148;
            // 
            // panel29
            // 
            this.panel29.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel29.Location = new System.Drawing.Point(1029, 1377);
            this.panel29.Margin = new System.Windows.Forms.Padding(4);
            this.panel29.Name = "panel29";
            this.panel29.Size = new System.Drawing.Size(333, 246);
            this.panel29.TabIndex = 148;
            // 
            // panel28
            // 
            this.panel28.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel28.Location = new System.Drawing.Point(688, 1377);
            this.panel28.Margin = new System.Windows.Forms.Padding(4);
            this.panel28.Name = "panel28";
            this.panel28.Size = new System.Drawing.Size(333, 246);
            this.panel28.TabIndex = 148;
            // 
            // panel27
            // 
            this.panel27.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel27.Location = new System.Drawing.Point(347, 1377);
            this.panel27.Margin = new System.Windows.Forms.Padding(4);
            this.panel27.Name = "panel27";
            this.panel27.Size = new System.Drawing.Size(333, 246);
            this.panel27.TabIndex = 156;
            // 
            // panel26
            // 
            this.panel26.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel26.Location = new System.Drawing.Point(4, 1377);
            this.panel26.Margin = new System.Windows.Forms.Padding(4);
            this.panel26.Name = "panel26";
            this.panel26.Size = new System.Drawing.Size(333, 246);
            this.panel26.TabIndex = 155;
            // 
            // panel25
            // 
            this.panel25.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel25.Location = new System.Drawing.Point(1371, 1088);
            this.panel25.Margin = new System.Windows.Forms.Padding(4);
            this.panel25.Name = "panel25";
            this.panel25.Size = new System.Drawing.Size(333, 246);
            this.panel25.TabIndex = 148;
            // 
            // panel24
            // 
            this.panel24.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel24.Location = new System.Drawing.Point(1029, 1089);
            this.panel24.Margin = new System.Windows.Forms.Padding(4);
            this.panel24.Name = "panel24";
            this.panel24.Size = new System.Drawing.Size(333, 246);
            this.panel24.TabIndex = 148;
            // 
            // panel23
            // 
            this.panel23.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel23.Location = new System.Drawing.Point(688, 1088);
            this.panel23.Margin = new System.Windows.Forms.Padding(4);
            this.panel23.Name = "panel23";
            this.panel23.Size = new System.Drawing.Size(333, 246);
            this.panel23.TabIndex = 148;
            // 
            // panel22
            // 
            this.panel22.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel22.Location = new System.Drawing.Point(347, 1088);
            this.panel22.Margin = new System.Windows.Forms.Padding(4);
            this.panel22.Name = "panel22";
            this.panel22.Size = new System.Drawing.Size(333, 246);
            this.panel22.TabIndex = 154;
            // 
            // panel21
            // 
            this.panel21.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel21.Location = new System.Drawing.Point(4, 1088);
            this.panel21.Margin = new System.Windows.Forms.Padding(4);
            this.panel21.Name = "panel21";
            this.panel21.Size = new System.Drawing.Size(333, 246);
            this.panel21.TabIndex = 153;
            // 
            // panel20
            // 
            this.panel20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel20.Location = new System.Drawing.Point(1371, 800);
            this.panel20.Margin = new System.Windows.Forms.Padding(4);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(333, 246);
            this.panel20.TabIndex = 152;
            // 
            // panel19
            // 
            this.panel19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel19.Location = new System.Drawing.Point(1029, 799);
            this.panel19.Margin = new System.Windows.Forms.Padding(4);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(333, 246);
            this.panel19.TabIndex = 148;
            // 
            // panel18
            // 
            this.panel18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel18.Location = new System.Drawing.Point(688, 800);
            this.panel18.Margin = new System.Windows.Forms.Padding(4);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(333, 246);
            this.panel18.TabIndex = 147;
            // 
            // panel17
            // 
            this.panel17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel17.Location = new System.Drawing.Point(347, 799);
            this.panel17.Margin = new System.Windows.Forms.Padding(4);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(333, 246);
            this.panel17.TabIndex = 151;
            // 
            // panel16
            // 
            this.panel16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel16.Location = new System.Drawing.Point(4, 799);
            this.panel16.Margin = new System.Windows.Forms.Padding(4);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(333, 246);
            this.panel16.TabIndex = 150;
            // 
            // panel15
            // 
            this.panel15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel15.Location = new System.Drawing.Point(1371, 534);
            this.panel15.Margin = new System.Windows.Forms.Padding(4);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(333, 222);
            this.panel15.TabIndex = 149;
            // 
            // panel14
            // 
            this.panel14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel14.Location = new System.Drawing.Point(1029, 534);
            this.panel14.Margin = new System.Windows.Forms.Padding(4);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(333, 222);
            this.panel14.TabIndex = 148;
            // 
            // panel13
            // 
            this.panel13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel13.Location = new System.Drawing.Point(688, 534);
            this.panel13.Margin = new System.Windows.Forms.Padding(4);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(333, 222);
            this.panel13.TabIndex = 147;
            // 
            // panel12
            // 
            this.panel12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel12.Location = new System.Drawing.Point(347, 534);
            this.panel12.Margin = new System.Windows.Forms.Padding(4);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(333, 222);
            this.panel12.TabIndex = 147;
            // 
            // panel11
            // 
            this.panel11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel11.Location = new System.Drawing.Point(4, 534);
            this.panel11.Margin = new System.Windows.Forms.Padding(4);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(333, 222);
            this.panel11.TabIndex = 146;
            // 
            // panel10
            // 
            this.panel10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel10.Location = new System.Drawing.Point(1371, 270);
            this.panel10.Margin = new System.Windows.Forms.Padding(4);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(333, 222);
            this.panel10.TabIndex = 146;
            // 
            // panel9
            // 
            this.panel9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel9.Location = new System.Drawing.Point(1029, 270);
            this.panel9.Margin = new System.Windows.Forms.Padding(4);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(333, 222);
            this.panel9.TabIndex = 146;
            // 
            // panel8
            // 
            this.panel8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel8.Location = new System.Drawing.Point(688, 270);
            this.panel8.Margin = new System.Windows.Forms.Padding(4);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(333, 222);
            this.panel8.TabIndex = 146;
            // 
            // panel7
            // 
            this.panel7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel7.Location = new System.Drawing.Point(347, 270);
            this.panel7.Margin = new System.Windows.Forms.Padding(4);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(333, 222);
            this.panel7.TabIndex = 146;
            // 
            // panel6
            // 
            this.panel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel6.Location = new System.Drawing.Point(5, 270);
            this.panel6.Margin = new System.Windows.Forms.Padding(4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(333, 222);
            this.panel6.TabIndex = 145;
            // 
            // panel5
            // 
            this.panel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel5.Location = new System.Drawing.Point(1371, 4);
            this.panel5.Margin = new System.Windows.Forms.Padding(4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(333, 222);
            this.panel5.TabIndex = 144;
            // 
            // panel4
            // 
            this.panel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel4.Location = new System.Drawing.Point(1029, 5);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(333, 222);
            this.panel4.TabIndex = 144;
            // 
            // panel3
            // 
            this.panel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(688, 4);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(333, 222);
            this.panel3.TabIndex = 144;
            // 
            // panel2
            // 
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(347, 4);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(333, 222);
            this.panel2.TabIndex = 143;
            // 
            // panel1
            // 
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(333, 222);
            this.panel1.TabIndex = 142;
            // 
            // _btnCH55
            // 
            this._btnCH55.Enabled = false;
            this._btnCH55.Location = new System.Drawing.Point(1369, 3051);
            this._btnCH55.Margin = new System.Windows.Forms.Padding(4);
            this._btnCH55.Name = "_btnCH55";
            this._btnCH55.Size = new System.Drawing.Size(333, 28);
            this._btnCH55.TabIndex = 122;
            this._btnCH55.Text = "CH55";
            this._btnCH55.UseVisualStyleBackColor = true;
            this._btnCH55.Click += new System.EventHandler(this._btnCH55_Click);
            // 
            // _btnCH54
            // 
            this._btnCH54.Enabled = false;
            this._btnCH54.Location = new System.Drawing.Point(1028, 3051);
            this._btnCH54.Margin = new System.Windows.Forms.Padding(4);
            this._btnCH54.Name = "_btnCH54";
            this._btnCH54.Size = new System.Drawing.Size(333, 28);
            this._btnCH54.TabIndex = 120;
            this._btnCH54.Text = "CH54";
            this._btnCH54.UseVisualStyleBackColor = true;
            this._btnCH54.Click += new System.EventHandler(this._btnCH54_Click);
            // 
            // _btnCH53
            // 
            this._btnCH53.Enabled = false;
            this._btnCH53.Location = new System.Drawing.Point(687, 3051);
            this._btnCH53.Margin = new System.Windows.Forms.Padding(4);
            this._btnCH53.Name = "_btnCH53";
            this._btnCH53.Size = new System.Drawing.Size(333, 28);
            this._btnCH53.TabIndex = 118;
            this._btnCH53.Text = "CH53";
            this._btnCH53.UseVisualStyleBackColor = true;
            this._btnCH53.Click += new System.EventHandler(this._btnCH53_Click);
            // 
            // _btnCH52
            // 
            this._btnCH52.Enabled = false;
            this._btnCH52.Location = new System.Drawing.Point(345, 3051);
            this._btnCH52.Margin = new System.Windows.Forms.Padding(4);
            this._btnCH52.Name = "_btnCH52";
            this._btnCH52.Size = new System.Drawing.Size(333, 28);
            this._btnCH52.TabIndex = 116;
            this._btnCH52.Text = "CH52";
            this._btnCH52.UseVisualStyleBackColor = true;
            this._btnCH52.Click += new System.EventHandler(this._btnCH52_Click);
            // 
            // _btnCH50
            // 
            this._btnCH50.Enabled = false;
            this._btnCH50.Location = new System.Drawing.Point(1365, 2786);
            this._btnCH50.Margin = new System.Windows.Forms.Padding(4);
            this._btnCH50.Name = "_btnCH50";
            this._btnCH50.Size = new System.Drawing.Size(333, 28);
            this._btnCH50.TabIndex = 114;
            this._btnCH50.Text = "CH50";
            this._btnCH50.UseVisualStyleBackColor = true;
            this._btnCH50.Click += new System.EventHandler(this._btnCH50_Click);
            // 
            // _btnCH49
            // 
            this._btnCH49.Enabled = false;
            this._btnCH49.Location = new System.Drawing.Point(1028, 2786);
            this._btnCH49.Margin = new System.Windows.Forms.Padding(4);
            this._btnCH49.Name = "_btnCH49";
            this._btnCH49.Size = new System.Drawing.Size(333, 28);
            this._btnCH49.TabIndex = 112;
            this._btnCH49.Text = "CH49";
            this._btnCH49.UseVisualStyleBackColor = true;
            this._btnCH49.Click += new System.EventHandler(this._btnCH49_Click);
            // 
            // _btnCH48
            // 
            this._btnCH48.Enabled = false;
            this._btnCH48.Location = new System.Drawing.Point(687, 2786);
            this._btnCH48.Margin = new System.Windows.Forms.Padding(4);
            this._btnCH48.Name = "_btnCH48";
            this._btnCH48.Size = new System.Drawing.Size(333, 28);
            this._btnCH48.TabIndex = 110;
            this._btnCH48.Text = "CH48";
            this._btnCH48.UseVisualStyleBackColor = true;
            this._btnCH48.Click += new System.EventHandler(this._btnCH48_Click);
            // 
            // _btnCH47
            // 
            this._btnCH47.Enabled = false;
            this._btnCH47.Location = new System.Drawing.Point(345, 2786);
            this._btnCH47.Margin = new System.Windows.Forms.Padding(4);
            this._btnCH47.Name = "_btnCH47";
            this._btnCH47.Size = new System.Drawing.Size(333, 28);
            this._btnCH47.TabIndex = 108;
            this._btnCH47.Text = "CH47";
            this._btnCH47.UseVisualStyleBackColor = true;
            this._btnCH47.Click += new System.EventHandler(this._btnCH47_Click);
            // 
            // _btnCH45
            // 
            this._btnCH45.Enabled = false;
            this._btnCH45.Location = new System.Drawing.Point(1371, 2497);
            this._btnCH45.Margin = new System.Windows.Forms.Padding(4);
            this._btnCH45.Name = "_btnCH45";
            this._btnCH45.Size = new System.Drawing.Size(333, 28);
            this._btnCH45.TabIndex = 106;
            this._btnCH45.Text = "CH45";
            this._btnCH45.UseVisualStyleBackColor = true;
            this._btnCH45.Click += new System.EventHandler(this._btnCH45_Click);
            // 
            // _btnCH44
            // 
            this._btnCH44.Enabled = false;
            this._btnCH44.Location = new System.Drawing.Point(1029, 2497);
            this._btnCH44.Margin = new System.Windows.Forms.Padding(4);
            this._btnCH44.Name = "_btnCH44";
            this._btnCH44.Size = new System.Drawing.Size(333, 28);
            this._btnCH44.TabIndex = 104;
            this._btnCH44.Text = "CH44";
            this._btnCH44.UseVisualStyleBackColor = true;
            this._btnCH44.Click += new System.EventHandler(this._btnCH44_Click);
            // 
            // _btnCH43
            // 
            this._btnCH43.Enabled = false;
            this._btnCH43.Location = new System.Drawing.Point(688, 2497);
            this._btnCH43.Margin = new System.Windows.Forms.Padding(4);
            this._btnCH43.Name = "_btnCH43";
            this._btnCH43.Size = new System.Drawing.Size(333, 28);
            this._btnCH43.TabIndex = 102;
            this._btnCH43.Text = "CH43";
            this._btnCH43.UseVisualStyleBackColor = true;
            this._btnCH43.Click += new System.EventHandler(this._btnCH43_Click);
            // 
            // _btnCH42
            // 
            this._btnCH42.Enabled = false;
            this._btnCH42.Location = new System.Drawing.Point(347, 2497);
            this._btnCH42.Margin = new System.Windows.Forms.Padding(4);
            this._btnCH42.Name = "_btnCH42";
            this._btnCH42.Size = new System.Drawing.Size(333, 28);
            this._btnCH42.TabIndex = 100;
            this._btnCH42.Text = "CH42";
            this._btnCH42.UseVisualStyleBackColor = true;
            this._btnCH42.Click += new System.EventHandler(this._btnCH42_Click);
            // 
            // _btnCH40
            // 
            this._btnCH40.Enabled = false;
            this._btnCH40.Location = new System.Drawing.Point(1367, 2208);
            this._btnCH40.Margin = new System.Windows.Forms.Padding(4);
            this._btnCH40.Name = "_btnCH40";
            this._btnCH40.Size = new System.Drawing.Size(333, 28);
            this._btnCH40.TabIndex = 98;
            this._btnCH40.Text = "CH40";
            this._btnCH40.UseVisualStyleBackColor = true;
            this._btnCH40.Click += new System.EventHandler(this._btnCH40_Click);
            // 
            // _btnCH39
            // 
            this._btnCH39.Enabled = false;
            this._btnCH39.Location = new System.Drawing.Point(1025, 2208);
            this._btnCH39.Margin = new System.Windows.Forms.Padding(4);
            this._btnCH39.Name = "_btnCH39";
            this._btnCH39.Size = new System.Drawing.Size(333, 28);
            this._btnCH39.TabIndex = 96;
            this._btnCH39.Text = "CH39";
            this._btnCH39.UseVisualStyleBackColor = true;
            this._btnCH39.Click += new System.EventHandler(this._btnCH39_Click);
            // 
            // _btnCH38
            // 
            this._btnCH38.Enabled = false;
            this._btnCH38.Location = new System.Drawing.Point(688, 2208);
            this._btnCH38.Margin = new System.Windows.Forms.Padding(4);
            this._btnCH38.Name = "_btnCH38";
            this._btnCH38.Size = new System.Drawing.Size(333, 28);
            this._btnCH38.TabIndex = 94;
            this._btnCH38.Text = "CH38";
            this._btnCH38.UseVisualStyleBackColor = true;
            this._btnCH38.Click += new System.EventHandler(this._btnCH38_Click);
            // 
            // _btnCH37
            // 
            this._btnCH37.Enabled = false;
            this._btnCH37.Location = new System.Drawing.Point(343, 2208);
            this._btnCH37.Margin = new System.Windows.Forms.Padding(4);
            this._btnCH37.Name = "_btnCH37";
            this._btnCH37.Size = new System.Drawing.Size(333, 28);
            this._btnCH37.TabIndex = 92;
            this._btnCH37.Text = "CH37";
            this._btnCH37.UseVisualStyleBackColor = true;
            this._btnCH37.Click += new System.EventHandler(this._btnCH37_Click);
            // 
            // _btnCH35
            // 
            this._btnCH35.Enabled = false;
            this._btnCH35.Location = new System.Drawing.Point(1369, 1920);
            this._btnCH35.Margin = new System.Windows.Forms.Padding(4);
            this._btnCH35.Name = "_btnCH35";
            this._btnCH35.Size = new System.Drawing.Size(333, 28);
            this._btnCH35.TabIndex = 90;
            this._btnCH35.Text = "CH35";
            this._btnCH35.UseVisualStyleBackColor = true;
            this._btnCH35.Click += new System.EventHandler(this._btnCH35_Click);
            // 
            // _btnCH34
            // 
            this._btnCH34.Enabled = false;
            this._btnCH34.Location = new System.Drawing.Point(1028, 1919);
            this._btnCH34.Margin = new System.Windows.Forms.Padding(4);
            this._btnCH34.Name = "_btnCH34";
            this._btnCH34.Size = new System.Drawing.Size(333, 28);
            this._btnCH34.TabIndex = 88;
            this._btnCH34.Text = "CH34";
            this._btnCH34.UseVisualStyleBackColor = true;
            this._btnCH34.Click += new System.EventHandler(this._btnCH34_Click);
            // 
            // _btnCH33
            // 
            this._btnCH33.Enabled = false;
            this._btnCH33.Location = new System.Drawing.Point(687, 1920);
            this._btnCH33.Margin = new System.Windows.Forms.Padding(4);
            this._btnCH33.Name = "_btnCH33";
            this._btnCH33.Size = new System.Drawing.Size(333, 28);
            this._btnCH33.TabIndex = 86;
            this._btnCH33.Text = "CH33";
            this._btnCH33.UseVisualStyleBackColor = true;
            this._btnCH33.Click += new System.EventHandler(this._btnCH33_Click);
            // 
            // _btnCH32
            // 
            this._btnCH32.Enabled = false;
            this._btnCH32.Location = new System.Drawing.Point(345, 1920);
            this._btnCH32.Margin = new System.Windows.Forms.Padding(4);
            this._btnCH32.Name = "_btnCH32";
            this._btnCH32.Size = new System.Drawing.Size(333, 28);
            this._btnCH32.TabIndex = 84;
            this._btnCH32.Text = "CH32";
            this._btnCH32.UseVisualStyleBackColor = true;
            this._btnCH32.Click += new System.EventHandler(this._btnCH32_Click);
            // 
            // _btnCH30
            // 
            this._btnCH30.Enabled = false;
            this._btnCH30.Location = new System.Drawing.Point(1371, 1631);
            this._btnCH30.Margin = new System.Windows.Forms.Padding(4);
            this._btnCH30.Name = "_btnCH30";
            this._btnCH30.Size = new System.Drawing.Size(333, 28);
            this._btnCH30.TabIndex = 82;
            this._btnCH30.Text = "CH30";
            this._btnCH30.UseVisualStyleBackColor = true;
            this._btnCH30.Click += new System.EventHandler(this._btnCH30_Click);
            // 
            // _btnCH29
            // 
            this._btnCH29.Enabled = false;
            this._btnCH29.Location = new System.Drawing.Point(1029, 1631);
            this._btnCH29.Margin = new System.Windows.Forms.Padding(4);
            this._btnCH29.Name = "_btnCH29";
            this._btnCH29.Size = new System.Drawing.Size(333, 28);
            this._btnCH29.TabIndex = 80;
            this._btnCH29.Text = "CH29";
            this._btnCH29.UseVisualStyleBackColor = true;
            this._btnCH29.Click += new System.EventHandler(this._btnCH29_Click);
            // 
            // _btnCH28
            // 
            this._btnCH28.Enabled = false;
            this._btnCH28.Location = new System.Drawing.Point(688, 1631);
            this._btnCH28.Margin = new System.Windows.Forms.Padding(4);
            this._btnCH28.Name = "_btnCH28";
            this._btnCH28.Size = new System.Drawing.Size(333, 28);
            this._btnCH28.TabIndex = 78;
            this._btnCH28.Text = "CH28";
            this._btnCH28.UseVisualStyleBackColor = true;
            this._btnCH28.Click += new System.EventHandler(this._btnCH28_Click);
            // 
            // _btnCH27
            // 
            this._btnCH27.Enabled = false;
            this._btnCH27.Location = new System.Drawing.Point(347, 1631);
            this._btnCH27.Margin = new System.Windows.Forms.Padding(4);
            this._btnCH27.Name = "_btnCH27";
            this._btnCH27.Size = new System.Drawing.Size(333, 28);
            this._btnCH27.TabIndex = 76;
            this._btnCH27.Text = "CH27";
            this._btnCH27.UseVisualStyleBackColor = true;
            this._btnCH27.Click += new System.EventHandler(this._btnCH27_Click);
            // 
            // _btnCH25
            // 
            this._btnCH25.Enabled = false;
            this._btnCH25.Location = new System.Drawing.Point(1371, 1342);
            this._btnCH25.Margin = new System.Windows.Forms.Padding(4);
            this._btnCH25.Name = "_btnCH25";
            this._btnCH25.Size = new System.Drawing.Size(333, 28);
            this._btnCH25.TabIndex = 74;
            this._btnCH25.Text = "CH25";
            this._btnCH25.UseVisualStyleBackColor = true;
            this._btnCH25.Click += new System.EventHandler(this._btnCH25_Click);
            // 
            // _btnCH24
            // 
            this._btnCH24.Enabled = false;
            this._btnCH24.Location = new System.Drawing.Point(1029, 1342);
            this._btnCH24.Margin = new System.Windows.Forms.Padding(4);
            this._btnCH24.Name = "_btnCH24";
            this._btnCH24.Size = new System.Drawing.Size(333, 28);
            this._btnCH24.TabIndex = 72;
            this._btnCH24.Text = "CH24";
            this._btnCH24.UseVisualStyleBackColor = true;
            this._btnCH24.Click += new System.EventHandler(this._btnCH24_Click);
            // 
            // _btnCH23
            // 
            this._btnCH23.Enabled = false;
            this._btnCH23.Location = new System.Drawing.Point(688, 1342);
            this._btnCH23.Margin = new System.Windows.Forms.Padding(4);
            this._btnCH23.Name = "_btnCH23";
            this._btnCH23.Size = new System.Drawing.Size(333, 28);
            this._btnCH23.TabIndex = 70;
            this._btnCH23.Text = "CH23";
            this._btnCH23.UseVisualStyleBackColor = true;
            this._btnCH23.Click += new System.EventHandler(this._btnCH23_Click);
            // 
            // _btnCH22
            // 
            this._btnCH22.Enabled = false;
            this._btnCH22.Location = new System.Drawing.Point(347, 1342);
            this._btnCH22.Margin = new System.Windows.Forms.Padding(4);
            this._btnCH22.Name = "_btnCH22";
            this._btnCH22.Size = new System.Drawing.Size(333, 28);
            this._btnCH22.TabIndex = 68;
            this._btnCH22.Text = "CH22";
            this._btnCH22.UseVisualStyleBackColor = true;
            this._btnCH22.Click += new System.EventHandler(this._btnCH22_Click);
            // 
            // _btnCH20
            // 
            this._btnCH20.Enabled = false;
            this._btnCH20.Location = new System.Drawing.Point(1371, 1052);
            this._btnCH20.Margin = new System.Windows.Forms.Padding(4);
            this._btnCH20.Name = "_btnCH20";
            this._btnCH20.Size = new System.Drawing.Size(333, 28);
            this._btnCH20.TabIndex = 66;
            this._btnCH20.Text = "CH20";
            this._btnCH20.UseVisualStyleBackColor = true;
            this._btnCH20.Click += new System.EventHandler(this._btnCH20_Click);
            // 
            // _btnCH19
            // 
            this._btnCH19.Enabled = false;
            this._btnCH19.Location = new System.Drawing.Point(1029, 1054);
            this._btnCH19.Margin = new System.Windows.Forms.Padding(4);
            this._btnCH19.Name = "_btnCH19";
            this._btnCH19.Size = new System.Drawing.Size(333, 28);
            this._btnCH19.TabIndex = 64;
            this._btnCH19.Text = "CH19";
            this._btnCH19.UseVisualStyleBackColor = true;
            this._btnCH19.Click += new System.EventHandler(this._btnCH19_Click);
            // 
            // _btnCH18
            // 
            this._btnCH18.Enabled = false;
            this._btnCH18.Location = new System.Drawing.Point(688, 1052);
            this._btnCH18.Margin = new System.Windows.Forms.Padding(4);
            this._btnCH18.Name = "_btnCH18";
            this._btnCH18.Size = new System.Drawing.Size(333, 28);
            this._btnCH18.TabIndex = 62;
            this._btnCH18.Text = "CH18";
            this._btnCH18.UseVisualStyleBackColor = true;
            this._btnCH18.Click += new System.EventHandler(this._btnCH18_Click);
            // 
            // _btnCH17
            // 
            this._btnCH17.Enabled = false;
            this._btnCH17.Location = new System.Drawing.Point(347, 1052);
            this._btnCH17.Margin = new System.Windows.Forms.Padding(4);
            this._btnCH17.Name = "_btnCH17";
            this._btnCH17.Size = new System.Drawing.Size(333, 28);
            this._btnCH17.TabIndex = 60;
            this._btnCH17.Text = "CH17";
            this._btnCH17.UseVisualStyleBackColor = true;
            this._btnCH17.Click += new System.EventHandler(this._btnCH17_Click);
            // 
            // _btnCH15
            // 
            this._btnCH15.Enabled = false;
            this._btnCH15.Location = new System.Drawing.Point(1371, 763);
            this._btnCH15.Margin = new System.Windows.Forms.Padding(4);
            this._btnCH15.Name = "_btnCH15";
            this._btnCH15.Size = new System.Drawing.Size(333, 28);
            this._btnCH15.TabIndex = 58;
            this._btnCH15.Text = "CH15";
            this._btnCH15.UseVisualStyleBackColor = true;
            this._btnCH15.Click += new System.EventHandler(this._btnCH15_Click);
            // 
            // _btnCH14
            // 
            this._btnCH14.Enabled = false;
            this._btnCH14.Location = new System.Drawing.Point(1029, 763);
            this._btnCH14.Margin = new System.Windows.Forms.Padding(4);
            this._btnCH14.Name = "_btnCH14";
            this._btnCH14.Size = new System.Drawing.Size(333, 28);
            this._btnCH14.TabIndex = 56;
            this._btnCH14.Text = "CH14";
            this._btnCH14.UseVisualStyleBackColor = true;
            this._btnCH14.Click += new System.EventHandler(this._btnCH14_Click);
            // 
            // _btnCH13
            // 
            this._btnCH13.Enabled = false;
            this._btnCH13.Location = new System.Drawing.Point(688, 763);
            this._btnCH13.Margin = new System.Windows.Forms.Padding(4);
            this._btnCH13.Name = "_btnCH13";
            this._btnCH13.Size = new System.Drawing.Size(333, 28);
            this._btnCH13.TabIndex = 54;
            this._btnCH13.Text = "CH13";
            this._btnCH13.UseVisualStyleBackColor = true;
            this._btnCH13.Click += new System.EventHandler(this._btnCH13_Click);
            // 
            // _btnCH12
            // 
            this._btnCH12.Enabled = false;
            this._btnCH12.Location = new System.Drawing.Point(347, 763);
            this._btnCH12.Margin = new System.Windows.Forms.Padding(4);
            this._btnCH12.Name = "_btnCH12";
            this._btnCH12.Size = new System.Drawing.Size(333, 28);
            this._btnCH12.TabIndex = 52;
            this._btnCH12.Text = "CH12";
            this._btnCH12.UseVisualStyleBackColor = true;
            this._btnCH12.Click += new System.EventHandler(this._btnCH12_Click);
            // 
            // _btnCH10
            // 
            this._btnCH10.Enabled = false;
            this._btnCH10.Location = new System.Drawing.Point(1369, 498);
            this._btnCH10.Margin = new System.Windows.Forms.Padding(4);
            this._btnCH10.Name = "_btnCH10";
            this._btnCH10.Size = new System.Drawing.Size(333, 28);
            this._btnCH10.TabIndex = 50;
            this._btnCH10.Text = "CH10";
            this._btnCH10.UseVisualStyleBackColor = true;
            this._btnCH10.Click += new System.EventHandler(this._btnCH10_Click);
            // 
            // _btnCH9
            // 
            this._btnCH9.Enabled = false;
            this._btnCH9.Location = new System.Drawing.Point(1028, 498);
            this._btnCH9.Margin = new System.Windows.Forms.Padding(4);
            this._btnCH9.Name = "_btnCH9";
            this._btnCH9.Size = new System.Drawing.Size(333, 28);
            this._btnCH9.TabIndex = 48;
            this._btnCH9.Text = "CH9";
            this._btnCH9.UseVisualStyleBackColor = true;
            this._btnCH9.Click += new System.EventHandler(this._btnCH9_Click);
            // 
            // _btnCH8
            // 
            this._btnCH8.Enabled = false;
            this._btnCH8.Location = new System.Drawing.Point(687, 498);
            this._btnCH8.Margin = new System.Windows.Forms.Padding(4);
            this._btnCH8.Name = "_btnCH8";
            this._btnCH8.Size = new System.Drawing.Size(333, 28);
            this._btnCH8.TabIndex = 46;
            this._btnCH8.Text = "CH8";
            this._btnCH8.UseVisualStyleBackColor = true;
            this._btnCH8.Click += new System.EventHandler(this._btnCH8_Click);
            // 
            // _btnCH7
            // 
            this._btnCH7.Enabled = false;
            this._btnCH7.Location = new System.Drawing.Point(345, 498);
            this._btnCH7.Margin = new System.Windows.Forms.Padding(4);
            this._btnCH7.Name = "_btnCH7";
            this._btnCH7.Size = new System.Drawing.Size(333, 28);
            this._btnCH7.TabIndex = 44;
            this._btnCH7.Text = "CH7";
            this._btnCH7.UseVisualStyleBackColor = true;
            this._btnCH7.Click += new System.EventHandler(this._btnCH7_Click);
            // 
            // _btnCH5
            // 
            this._btnCH5.Enabled = false;
            this._btnCH5.Location = new System.Drawing.Point(1371, 234);
            this._btnCH5.Margin = new System.Windows.Forms.Padding(4);
            this._btnCH5.Name = "_btnCH5";
            this._btnCH5.Size = new System.Drawing.Size(333, 28);
            this._btnCH5.TabIndex = 42;
            this._btnCH5.Text = "CH5";
            this._btnCH5.UseVisualStyleBackColor = true;
            this._btnCH5.Click += new System.EventHandler(this._btnCH5_Click);
            // 
            // _btnCH4
            // 
            this._btnCH4.Enabled = false;
            this._btnCH4.Location = new System.Drawing.Point(1029, 234);
            this._btnCH4.Margin = new System.Windows.Forms.Padding(4);
            this._btnCH4.Name = "_btnCH4";
            this._btnCH4.Size = new System.Drawing.Size(333, 28);
            this._btnCH4.TabIndex = 40;
            this._btnCH4.Text = "CH4";
            this._btnCH4.UseVisualStyleBackColor = true;
            this._btnCH4.Click += new System.EventHandler(this._btnCH4_Click);
            // 
            // _btnCH3
            // 
            this._btnCH3.Enabled = false;
            this._btnCH3.Location = new System.Drawing.Point(688, 234);
            this._btnCH3.Margin = new System.Windows.Forms.Padding(4);
            this._btnCH3.Name = "_btnCH3";
            this._btnCH3.Size = new System.Drawing.Size(333, 28);
            this._btnCH3.TabIndex = 38;
            this._btnCH3.Text = "CH3";
            this._btnCH3.UseVisualStyleBackColor = true;
            this._btnCH3.Click += new System.EventHandler(this._btnCH3_Click);
            // 
            // _btnCH2
            // 
            this._btnCH2.Enabled = false;
            this._btnCH2.Location = new System.Drawing.Point(347, 235);
            this._btnCH2.Margin = new System.Windows.Forms.Padding(4);
            this._btnCH2.Name = "_btnCH2";
            this._btnCH2.Size = new System.Drawing.Size(333, 28);
            this._btnCH2.TabIndex = 36;
            this._btnCH2.Text = "CH2";
            this._btnCH2.UseVisualStyleBackColor = true;
            this._btnCH2.Click += new System.EventHandler(this._btnCH2_Click);
            // 
            // _btnCH51
            // 
            this._btnCH51.Enabled = false;
            this._btnCH51.Location = new System.Drawing.Point(3, 3051);
            this._btnCH51.Margin = new System.Windows.Forms.Padding(4);
            this._btnCH51.Name = "_btnCH51";
            this._btnCH51.Size = new System.Drawing.Size(333, 28);
            this._btnCH51.TabIndex = 30;
            this._btnCH51.Text = "CH51";
            this._btnCH51.UseVisualStyleBackColor = true;
            this._btnCH51.Click += new System.EventHandler(this._btnCH51_Click);
            // 
            // _btnCH46
            // 
            this._btnCH46.Enabled = false;
            this._btnCH46.Location = new System.Drawing.Point(3, 2786);
            this._btnCH46.Margin = new System.Windows.Forms.Padding(4);
            this._btnCH46.Name = "_btnCH46";
            this._btnCH46.Size = new System.Drawing.Size(333, 28);
            this._btnCH46.TabIndex = 28;
            this._btnCH46.Text = "CH46";
            this._btnCH46.UseVisualStyleBackColor = true;
            this._btnCH46.Click += new System.EventHandler(this._btnCH46_Click);
            // 
            // _btnCH41
            // 
            this._btnCH41.Enabled = false;
            this._btnCH41.Location = new System.Drawing.Point(4, 2497);
            this._btnCH41.Margin = new System.Windows.Forms.Padding(4);
            this._btnCH41.Name = "_btnCH41";
            this._btnCH41.Size = new System.Drawing.Size(333, 28);
            this._btnCH41.TabIndex = 26;
            this._btnCH41.Text = "CH41";
            this._btnCH41.UseVisualStyleBackColor = true;
            this._btnCH41.Click += new System.EventHandler(this._btnCH41_Click);
            // 
            // _btnCH36
            // 
            this._btnCH36.Enabled = false;
            this._btnCH36.Location = new System.Drawing.Point(0, 2208);
            this._btnCH36.Margin = new System.Windows.Forms.Padding(4);
            this._btnCH36.Name = "_btnCH36";
            this._btnCH36.Size = new System.Drawing.Size(333, 28);
            this._btnCH36.TabIndex = 24;
            this._btnCH36.Text = "CH36";
            this._btnCH36.UseVisualStyleBackColor = true;
            this._btnCH36.Click += new System.EventHandler(this._btnCH36_Click);
            // 
            // _btnCH31
            // 
            this._btnCH31.Enabled = false;
            this._btnCH31.Location = new System.Drawing.Point(3, 1920);
            this._btnCH31.Margin = new System.Windows.Forms.Padding(4);
            this._btnCH31.Name = "_btnCH31";
            this._btnCH31.Size = new System.Drawing.Size(333, 28);
            this._btnCH31.TabIndex = 22;
            this._btnCH31.Text = "CH31";
            this._btnCH31.UseVisualStyleBackColor = true;
            this._btnCH31.Click += new System.EventHandler(this._btnCH31_Click);
            // 
            // _btnCH26
            // 
            this._btnCH26.Enabled = false;
            this._btnCH26.Location = new System.Drawing.Point(4, 1631);
            this._btnCH26.Margin = new System.Windows.Forms.Padding(4);
            this._btnCH26.Name = "_btnCH26";
            this._btnCH26.Size = new System.Drawing.Size(333, 28);
            this._btnCH26.TabIndex = 20;
            this._btnCH26.Text = "CH26";
            this._btnCH26.UseVisualStyleBackColor = true;
            this._btnCH26.Click += new System.EventHandler(this._btnCH26_Click);
            // 
            // _btnCH21
            // 
            this._btnCH21.Enabled = false;
            this._btnCH21.Location = new System.Drawing.Point(4, 1342);
            this._btnCH21.Margin = new System.Windows.Forms.Padding(4);
            this._btnCH21.Name = "_btnCH21";
            this._btnCH21.Size = new System.Drawing.Size(333, 28);
            this._btnCH21.TabIndex = 18;
            this._btnCH21.Text = "CH21";
            this._btnCH21.UseVisualStyleBackColor = true;
            this._btnCH21.Click += new System.EventHandler(this._btnCH21_Click);
            // 
            // _btnCH16
            // 
            this._btnCH16.Enabled = false;
            this._btnCH16.Location = new System.Drawing.Point(4, 1052);
            this._btnCH16.Margin = new System.Windows.Forms.Padding(4);
            this._btnCH16.Name = "_btnCH16";
            this._btnCH16.Size = new System.Drawing.Size(333, 28);
            this._btnCH16.TabIndex = 16;
            this._btnCH16.Text = "CH16";
            this._btnCH16.UseVisualStyleBackColor = true;
            this._btnCH16.Click += new System.EventHandler(this._btnCH16_Click);
            // 
            // _btnCH11
            // 
            this._btnCH11.Enabled = false;
            this._btnCH11.Location = new System.Drawing.Point(4, 763);
            this._btnCH11.Margin = new System.Windows.Forms.Padding(4);
            this._btnCH11.Name = "_btnCH11";
            this._btnCH11.Size = new System.Drawing.Size(333, 28);
            this._btnCH11.TabIndex = 14;
            this._btnCH11.Text = "CH11";
            this._btnCH11.UseVisualStyleBackColor = true;
            this._btnCH11.Click += new System.EventHandler(this._btnCH11_Click);
            // 
            // _btnCH6
            // 
            this._btnCH6.Enabled = false;
            this._btnCH6.Location = new System.Drawing.Point(4, 498);
            this._btnCH6.Margin = new System.Windows.Forms.Padding(4);
            this._btnCH6.Name = "_btnCH6";
            this._btnCH6.Size = new System.Drawing.Size(333, 28);
            this._btnCH6.TabIndex = 12;
            this._btnCH6.Text = "CH6";
            this._btnCH6.UseVisualStyleBackColor = true;
            this._btnCH6.Click += new System.EventHandler(this._btnCH6_Click);
            // 
            // _btnCH1
            // 
            this._btnCH1.Enabled = false;
            this._btnCH1.Location = new System.Drawing.Point(4, 235);
            this._btnCH1.Margin = new System.Windows.Forms.Padding(4);
            this._btnCH1.Name = "_btnCH1";
            this._btnCH1.Size = new System.Drawing.Size(333, 28);
            this._btnCH1.TabIndex = 11;
            this._btnCH1.Text = "CH1";
            this._btnCH1.UseVisualStyleBackColor = true;
            this._btnCH1.Click += new System.EventHandler(this._btnCH1_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // BItimer
            // 
            this.BItimer.Enabled = true;
            this.BItimer.Interval = 10;
            this.BItimer.Tick += new System.EventHandler(this.BItimer_Tick_1);
            // 
            // timer_end
            // 
            this.timer_end.Tick += new System.EventHandler(this.timer_end_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(1914, 1047);
            this.Controls.Add(this._pnChart);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Avago Burn In System (3 Band) Rev 4.0";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this._pnChart.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox _txtBurnInDuration;
        private System.Windows.Forms.TextBox _txtBIInterval;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _txtstresson_CH17;
        private System.Windows.Forms.TextBox _txtstresson_CH1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox _txtTimeToNextMeas;
        private System.Windows.Forms.TextBox _txtBurnInStarted;
        private System.Windows.Forms.TextBox _txtElapsedBITime;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button _btnAbort;
        private System.Windows.Forms.Button _btnStart;
        private System.Windows.Forms.Button _btnInit;
        private System.Windows.Forms.Panel _pnChart;
        private System.Windows.Forms.Button _btnCH64;
        private System.Windows.Forms.Button _btnCH63;
        private System.Windows.Forms.Button _btnCH62;
        private System.Windows.Forms.Button _btnCH60;
        private System.Windows.Forms.Button _btnCH59;
        private System.Windows.Forms.Button _btnCH58;
        private System.Windows.Forms.Button _btnCH57;
        private System.Windows.Forms.Button _btnCH55;
        private System.Windows.Forms.Button _btnCH54;
        private System.Windows.Forms.Button _btnCH53;
        private System.Windows.Forms.Button _btnCH52;
        private System.Windows.Forms.Button _btnCH50;
        private System.Windows.Forms.Button _btnCH49;
        private System.Windows.Forms.Button _btnCH48;
        private System.Windows.Forms.Button _btnCH47;
        private System.Windows.Forms.Button _btnCH45;
        private System.Windows.Forms.Button _btnCH44;
        private System.Windows.Forms.Button _btnCH43;
        private System.Windows.Forms.Button _btnCH42;
        private System.Windows.Forms.Button _btnCH40;
        private System.Windows.Forms.Button _btnCH39;
        private System.Windows.Forms.Button _btnCH38;
        private System.Windows.Forms.Button _btnCH37;
        private System.Windows.Forms.Button _btnCH35;
        private System.Windows.Forms.Button _btnCH34;
        private System.Windows.Forms.Button _btnCH33;
        private System.Windows.Forms.Button _btnCH32;
        private System.Windows.Forms.Button _btnCH30;
        private System.Windows.Forms.Button _btnCH29;
        private System.Windows.Forms.Button _btnCH28;
        private System.Windows.Forms.Button _btnCH27;
        private System.Windows.Forms.Button _btnCH25;
        private System.Windows.Forms.Button _btnCH24;
        private System.Windows.Forms.Button _btnCH23;
        private System.Windows.Forms.Button _btnCH22;
        private System.Windows.Forms.Button _btnCH20;
        private System.Windows.Forms.Button _btnCH19;
        private System.Windows.Forms.Button _btnCH18;
        private System.Windows.Forms.Button _btnCH17;
        private System.Windows.Forms.Button _btnCH15;
        private System.Windows.Forms.Button _btnCH14;
        private System.Windows.Forms.Button _btnCH13;
        private System.Windows.Forms.Button _btnCH12;
        private System.Windows.Forms.Button _btnCH10;
        private System.Windows.Forms.Button _btnCH9;
        private System.Windows.Forms.Button _btnCH8;
        private System.Windows.Forms.Button _btnCH7;
        private System.Windows.Forms.Button _btnCH5;
        private System.Windows.Forms.Button _btnCH4;
        private System.Windows.Forms.Button _btnCH3;
        private System.Windows.Forms.Button _btnCH2;
        private System.Windows.Forms.Button _btnCH61;
        private System.Windows.Forms.Button _btnCH51;
        private System.Windows.Forms.Button _btnCH46;
        private System.Windows.Forms.Button _btnCH41;
        private System.Windows.Forms.Button _btnCH36;
        private System.Windows.Forms.Button _btnCH31;
        private System.Windows.Forms.Button _btnCH26;
        private System.Windows.Forms.Button _btnCH21;
        private System.Windows.Forms.Button _btnCH16;
        private System.Windows.Forms.Button _btnCH11;
        private System.Windows.Forms.Button _btnCH6;
        private System.Windows.Forms.Button _btnCH1;
        private System.Windows.Forms.Button _btnCalibration;
        private System.Windows.Forms.Button _btnExit;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox _txtStopFreq4;
        private System.Windows.Forms.TextBox _txtStopFreq3;
        private System.Windows.Forms.TextBox _txtStopFreq2;
        private System.Windows.Forms.TextBox _txtStartFreq4;
        private System.Windows.Forms.TextBox _txtStartFreq3;
        private System.Windows.Forms.TextBox _txtStartFreq2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox _txtStopFreq1;
        private System.Windows.Forms.TextBox _txtStartFreq1;
        private System.Windows.Forms.TextBox _txtChannelDisplay;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox _txtStressFreq4MHz;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox _txtStressFreq3MHz;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox _txtStressFreq2MHz;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox _txtStressFreq1MHz;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel64;
        private System.Windows.Forms.Panel panel63;
        private System.Windows.Forms.Panel panel62;
        private System.Windows.Forms.Panel panel61;
        private System.Windows.Forms.Panel panel60;
        private System.Windows.Forms.Panel panel59;
        private System.Windows.Forms.Panel panel58;
        private System.Windows.Forms.Panel panel57;
        private System.Windows.Forms.Panel panel56;
        private System.Windows.Forms.Panel panel55;
        private System.Windows.Forms.Panel panel54;
        private System.Windows.Forms.Panel panel53;
        private System.Windows.Forms.Panel panel52;
        private System.Windows.Forms.Panel panel51;
        private System.Windows.Forms.Panel panel50;
        private System.Windows.Forms.Panel panel49;
        private System.Windows.Forms.Panel panel48;
        private System.Windows.Forms.Panel panel47;
        private System.Windows.Forms.Panel panel46;
        private System.Windows.Forms.Panel panel45;
        private System.Windows.Forms.Panel panel44;
        private System.Windows.Forms.Panel panel43;
        private System.Windows.Forms.Panel panel42;
        private System.Windows.Forms.Panel panel41;
        private System.Windows.Forms.Panel panel40;
        private System.Windows.Forms.Panel panel39;
        private System.Windows.Forms.Panel panel38;
        private System.Windows.Forms.Panel panel37;
        private System.Windows.Forms.Panel panel36;
        private System.Windows.Forms.Panel panel34;
        private System.Windows.Forms.Panel panel33;
        private System.Windows.Forms.Panel panel32;
        private System.Windows.Forms.Panel panel31;
        private System.Windows.Forms.Panel panel30;
        private System.Windows.Forms.Panel panel29;
        private System.Windows.Forms.Panel panel28;
        private System.Windows.Forms.Panel panel27;
        private System.Windows.Forms.Panel panel26;
        private System.Windows.Forms.Panel panel25;
        private System.Windows.Forms.Panel panel24;
        private System.Windows.Forms.Panel panel23;
        private System.Windows.Forms.Panel panel22;
        private System.Windows.Forms.Panel panel21;
        private System.Windows.Forms.Panel panel20;
        private System.Windows.Forms.Panel panel19;
        private System.Windows.Forms.Panel panel18;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel35;
        private System.Windows.Forms.Timer BItimer;
        private System.Windows.Forms.TextBox _txtsecond;
        private System.Windows.Forms.TextBox _txtminute;
        private System.Windows.Forms.TextBox _txthour;
        private System.Windows.Forms.TextBox _txtFilename;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button _btnClear;
        private System.Windows.Forms.Button _btnCH56;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox _txtEstFinishTestDate;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Button _btntestrun;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TextBox _txtstresson_CH49;
        private System.Windows.Forms.TextBox _txtstresson_CH33;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Timer timer_end;
    }
}

