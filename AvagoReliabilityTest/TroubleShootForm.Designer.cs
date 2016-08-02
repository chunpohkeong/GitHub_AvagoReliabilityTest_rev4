namespace AvagoReliabilityTest
{
    partial class TroubleShootForm
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
            mainForm.Enabled = true;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._btnMeasure = new System.Windows.Forms.Button();
            this._btnClose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // _btnMeasure
            // 
            this._btnMeasure.Location = new System.Drawing.Point(247, 439);
            this._btnMeasure.Name = "_btnMeasure";
            this._btnMeasure.Size = new System.Drawing.Size(75, 23);
            this._btnMeasure.TabIndex = 3;
            this._btnMeasure.Text = "Measure";
            this._btnMeasure.UseVisualStyleBackColor = true;
            this._btnMeasure.Click += new System.EventHandler(this._btnMeasure_Click);
            // 
            // _btnClose
            // 
            this._btnClose.Location = new System.Drawing.Point(362, 439);
            this._btnClose.Name = "_btnClose";
            this._btnClose.Size = new System.Drawing.Size(75, 23);
            this._btnClose.TabIndex = 4;
            this._btnClose.Text = "Close";
            this._btnClose.UseVisualStyleBackColor = true;
            this._btnClose.Click += new System.EventHandler(this._btnClose_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(6, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(683, 422);
            this.panel1.TabIndex = 5;
            // 
            // TroubleShootForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 486);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this._btnClose);
            this.Controls.Add(this._btnMeasure);
            this.Name = "TroubleShootForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.TroubleShootForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _btnMeasure;
        private System.Windows.Forms.Button _btnClose;
        private System.Windows.Forms.Panel panel1;
    }
}