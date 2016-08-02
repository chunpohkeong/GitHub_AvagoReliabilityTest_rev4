namespace AvagoReliabilityTest
{
    partial class CalibrationForm
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
            this.mainForm.Enabled = true;
            this.mainForm.WindowState = System.Windows.Forms.FormWindowState.Normal;
            GlobalVariable.bCloseCalForm = true;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._gbChannelSelection = new System.Windows.Forms.GroupBox();
            this._txtFreqMHz4 = new System.Windows.Forms.TextBox();
            this._txtFreqMHz3 = new System.Windows.Forms.TextBox();
            this._txtFreqMHz2 = new System.Windows.Forms.TextBox();
            this._txtFreqMHz1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._btnChannelAll = new System.Windows.Forms.Button();
            this._cbChannelGroup7 = new System.Windows.Forms.CheckBox();
            this._cbChannelGroup5 = new System.Windows.Forms.CheckBox();
            this._cbChannelGroup3 = new System.Windows.Forms.CheckBox();
            this._cbChannelGroup1 = new System.Windows.Forms.CheckBox();
            this._btnCalStart = new System.Windows.Forms.Button();
            this._btnCalReset = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this._txtCalBand1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this._txtCalBand2 = new System.Windows.Forms.TextBox();
            this._txtCalBand3 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this._txtCalBand4 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this._txtCalFileName = new System.Windows.Forms.TextBox();
            this._gbChannelSelection.SuspendLayout();
            this.SuspendLayout();
            // 
            // _gbChannelSelection
            // 
            this._gbChannelSelection.Controls.Add(this.label8);
            this._gbChannelSelection.Controls.Add(this._txtCalBand4);
            this._gbChannelSelection.Controls.Add(this.label7);
            this._gbChannelSelection.Controls.Add(this._txtCalBand3);
            this._gbChannelSelection.Controls.Add(this._txtCalBand2);
            this._gbChannelSelection.Controls.Add(this.label6);
            this._gbChannelSelection.Controls.Add(this._txtCalBand1);
            this._gbChannelSelection.Controls.Add(this.label5);
            this._gbChannelSelection.Controls.Add(this._txtFreqMHz4);
            this._gbChannelSelection.Controls.Add(this._txtFreqMHz3);
            this._gbChannelSelection.Controls.Add(this._txtFreqMHz2);
            this._gbChannelSelection.Controls.Add(this._txtFreqMHz1);
            this._gbChannelSelection.Controls.Add(this.label4);
            this._gbChannelSelection.Controls.Add(this.label3);
            this._gbChannelSelection.Controls.Add(this.label2);
            this._gbChannelSelection.Controls.Add(this.label1);
            this._gbChannelSelection.Controls.Add(this._btnChannelAll);
            this._gbChannelSelection.Controls.Add(this._cbChannelGroup7);
            this._gbChannelSelection.Controls.Add(this._cbChannelGroup5);
            this._gbChannelSelection.Controls.Add(this._cbChannelGroup3);
            this._gbChannelSelection.Controls.Add(this._cbChannelGroup1);
            this._gbChannelSelection.Location = new System.Drawing.Point(12, 63);
            this._gbChannelSelection.Name = "_gbChannelSelection";
            this._gbChannelSelection.Size = new System.Drawing.Size(353, 277);
            this._gbChannelSelection.TabIndex = 0;
            this._gbChannelSelection.TabStop = false;
            this._gbChannelSelection.Text = "Channel Selection";
            // 
            // _txtFreqMHz4
            // 
            this._txtFreqMHz4.Location = new System.Drawing.Point(236, 186);
            this._txtFreqMHz4.Name = "_txtFreqMHz4";
            this._txtFreqMHz4.Size = new System.Drawing.Size(100, 20);
            this._txtFreqMHz4.TabIndex = 16;
            // 
            // _txtFreqMHz3
            // 
            this._txtFreqMHz3.Location = new System.Drawing.Point(236, 134);
            this._txtFreqMHz3.Name = "_txtFreqMHz3";
            this._txtFreqMHz3.Size = new System.Drawing.Size(100, 20);
            this._txtFreqMHz3.TabIndex = 15;
            // 
            // _txtFreqMHz2
            // 
            this._txtFreqMHz2.Location = new System.Drawing.Point(236, 82);
            this._txtFreqMHz2.Name = "_txtFreqMHz2";
            this._txtFreqMHz2.Size = new System.Drawing.Size(100, 20);
            this._txtFreqMHz2.TabIndex = 14;
            // 
            // _txtFreqMHz1
            // 
            this._txtFreqMHz1.Location = new System.Drawing.Point(236, 30);
            this._txtFreqMHz1.Name = "_txtFreqMHz1";
            this._txtFreqMHz1.Size = new System.Drawing.Size(100, 20);
            this._txtFreqMHz1.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(136, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Frequency (MHz) :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(136, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Frequency (MHz) :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(136, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Frequency (MHz) :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(136, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Frequency (MHz) :";
            // 
            // _btnChannelAll
            // 
            this._btnChannelAll.Location = new System.Drawing.Point(139, 248);
            this._btnChannelAll.Name = "_btnChannelAll";
            this._btnChannelAll.Size = new System.Drawing.Size(75, 23);
            this._btnChannelAll.TabIndex = 8;
            this._btnChannelAll.Text = "Select All";
            this._btnChannelAll.UseVisualStyleBackColor = true;
            this._btnChannelAll.Click += new System.EventHandler(this._btnChannelAll_Click);
            // 
            // _cbChannelGroup7
            // 
            this._cbChannelGroup7.AutoSize = true;
            this._cbChannelGroup7.Location = new System.Drawing.Point(20, 188);
            this._cbChannelGroup7.Name = "_cbChannelGroup7";
            this._cbChannelGroup7.Size = new System.Drawing.Size(101, 17);
            this._cbChannelGroup7.TabIndex = 6;
            this._cbChannelGroup7.Text = "Channel 49 - 64";
            this._cbChannelGroup7.UseVisualStyleBackColor = true;
            // 
            // _cbChannelGroup5
            // 
            this._cbChannelGroup5.AutoSize = true;
            this._cbChannelGroup5.Location = new System.Drawing.Point(20, 136);
            this._cbChannelGroup5.Name = "_cbChannelGroup5";
            this._cbChannelGroup5.Size = new System.Drawing.Size(101, 17);
            this._cbChannelGroup5.TabIndex = 4;
            this._cbChannelGroup5.Text = "Channel 33 - 48";
            this._cbChannelGroup5.UseVisualStyleBackColor = true;
            // 
            // _cbChannelGroup3
            // 
            this._cbChannelGroup3.AutoSize = true;
            this._cbChannelGroup3.Location = new System.Drawing.Point(20, 84);
            this._cbChannelGroup3.Name = "_cbChannelGroup3";
            this._cbChannelGroup3.Size = new System.Drawing.Size(101, 17);
            this._cbChannelGroup3.TabIndex = 2;
            this._cbChannelGroup3.Text = "Channel 17 - 32";
            this._cbChannelGroup3.UseVisualStyleBackColor = true;
            // 
            // _cbChannelGroup1
            // 
            this._cbChannelGroup1.AutoSize = true;
            this._cbChannelGroup1.Location = new System.Drawing.Point(20, 32);
            this._cbChannelGroup1.Name = "_cbChannelGroup1";
            this._cbChannelGroup1.Size = new System.Drawing.Size(95, 17);
            this._cbChannelGroup1.TabIndex = 0;
            this._cbChannelGroup1.Text = "Channel 1 - 16";
            this._cbChannelGroup1.UseVisualStyleBackColor = true;
            // 
            // _btnCalStart
            // 
            this._btnCalStart.Location = new System.Drawing.Point(113, 346);
            this._btnCalStart.Name = "_btnCalStart";
            this._btnCalStart.Size = new System.Drawing.Size(56, 23);
            this._btnCalStart.TabIndex = 1;
            this._btnCalStart.Text = "Start";
            this._btnCalStart.UseVisualStyleBackColor = true;
            this._btnCalStart.Click += new System.EventHandler(this._btnCalStart_Click);
            // 
            // _btnCalReset
            // 
            this._btnCalReset.Location = new System.Drawing.Point(202, 346);
            this._btnCalReset.Name = "_btnCalReset";
            this._btnCalReset.Size = new System.Drawing.Size(55, 23);
            this._btnCalReset.TabIndex = 2;
            this._btnCalReset.Text = "Reset";
            this._btnCalReset.UseVisualStyleBackColor = true;
            this._btnCalReset.Click += new System.EventHandler(this._btnCalReset_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(136, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Band :";
            // 
            // _txtCalBand1
            // 
            this._txtCalBand1.Location = new System.Drawing.Point(236, 56);
            this._txtCalBand1.Name = "_txtCalBand1";
            this._txtCalBand1.Size = new System.Drawing.Size(100, 20);
            this._txtCalBand1.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(136, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Band :";
            // 
            // _txtCalBand2
            // 
            this._txtCalBand2.Location = new System.Drawing.Point(236, 108);
            this._txtCalBand2.Name = "_txtCalBand2";
            this._txtCalBand2.Size = new System.Drawing.Size(100, 20);
            this._txtCalBand2.TabIndex = 20;
            // 
            // _txtCalBand3
            // 
            this._txtCalBand3.Location = new System.Drawing.Point(236, 160);
            this._txtCalBand3.Name = "_txtCalBand3";
            this._txtCalBand3.Size = new System.Drawing.Size(100, 20);
            this._txtCalBand3.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(136, 163);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Band :";
            // 
            // _txtCalBand4
            // 
            this._txtCalBand4.Location = new System.Drawing.Point(236, 212);
            this._txtCalBand4.Name = "_txtCalBand4";
            this._txtCalBand4.Size = new System.Drawing.Size(100, 20);
            this._txtCalBand4.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(136, 215);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "Band :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(112, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Calibration File Name :";
            // 
            // _txtCalFileName
            // 
            this._txtCalFileName.Location = new System.Drawing.Point(127, 25);
            this._txtCalFileName.Name = "_txtCalFileName";
            this._txtCalFileName.Size = new System.Drawing.Size(221, 20);
            this._txtCalFileName.TabIndex = 25;
            // 
            // CalibrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 381);
            this.Controls.Add(this._txtCalFileName);
            this.Controls.Add(this.label9);
            this.Controls.Add(this._btnCalReset);
            this.Controls.Add(this._btnCalStart);
            this.Controls.Add(this._gbChannelSelection);
            this.Name = "CalibrationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CalibrationForm";
            this._gbChannelSelection.ResumeLayout(false);
            this._gbChannelSelection.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox _gbChannelSelection;
        private System.Windows.Forms.CheckBox _cbChannelGroup7;
        private System.Windows.Forms.CheckBox _cbChannelGroup5;
        private System.Windows.Forms.CheckBox _cbChannelGroup3;
        private System.Windows.Forms.CheckBox _cbChannelGroup1;
        private System.Windows.Forms.Button _btnCalStart;
        private System.Windows.Forms.Button _btnCalReset;
        private System.Windows.Forms.Button _btnChannelAll;
        private System.Windows.Forms.TextBox _txtFreqMHz4;
        private System.Windows.Forms.TextBox _txtFreqMHz3;
        private System.Windows.Forms.TextBox _txtFreqMHz2;
        private System.Windows.Forms.TextBox _txtFreqMHz1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox _txtCalBand4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox _txtCalBand3;
        private System.Windows.Forms.TextBox _txtCalBand2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox _txtCalBand1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox _txtCalFileName;
    }
}