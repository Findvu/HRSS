namespace HRSS
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
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.groupCapture = new System.Windows.Forms.GroupBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.radio8x = new System.Windows.Forms.RadioButton();
			this.buttonCapture = new System.Windows.Forms.Button();
			this.textCustom = new System.Windows.Forms.TextBox();
			this.radioCustom = new System.Windows.Forms.RadioButton();
			this.radio4x = new System.Windows.Forms.RadioButton();
			this.radio2x = new System.Windows.Forms.RadioButton();
			this.radio1x = new System.Windows.Forms.RadioButton();
			this.labelStatus = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.timerMonitor = new System.Windows.Forms.Timer(this.components);
			this.timerRestore = new System.Windows.Forms.Timer(this.components);
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.groupCapture.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox1.Location = new System.Drawing.Point(26, 370);
			this.pictureBox1.Margin = new System.Windows.Forms.Padding(6);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(610, 360);
			this.pictureBox1.TabIndex = 2;
			this.pictureBox1.TabStop = false;
			// 
			// groupCapture
			// 
			this.groupCapture.Controls.Add(this.label2);
			this.groupCapture.Controls.Add(this.label1);
			this.groupCapture.Controls.Add(this.checkBox1);
			this.groupCapture.Controls.Add(this.radio8x);
			this.groupCapture.Controls.Add(this.buttonCapture);
			this.groupCapture.Controls.Add(this.textCustom);
			this.groupCapture.Controls.Add(this.radioCustom);
			this.groupCapture.Controls.Add(this.radio4x);
			this.groupCapture.Controls.Add(this.radio2x);
			this.groupCapture.Controls.Add(this.radio1x);
			this.groupCapture.Enabled = false;
			this.groupCapture.Location = new System.Drawing.Point(26, 75);
			this.groupCapture.Margin = new System.Windows.Forms.Padding(6);
			this.groupCapture.Name = "groupCapture";
			this.groupCapture.Padding = new System.Windows.Forms.Padding(6);
			this.groupCapture.Size = new System.Drawing.Size(610, 217);
			this.groupCapture.TabIndex = 38;
			this.groupCapture.TabStop = false;
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(367, 123);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(28, 27);
			this.checkBox1.TabIndex = 12;
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// radio8x
			// 
			this.radio8x.AutoSize = true;
			this.radio8x.Location = new System.Drawing.Point(271, 40);
			this.radio8x.Margin = new System.Windows.Forms.Padding(6);
			this.radio8x.Name = "radio8x";
			this.radio8x.Size = new System.Drawing.Size(66, 29);
			this.radio8x.TabIndex = 11;
			this.radio8x.Text = "8x";
			this.radio8x.UseVisualStyleBackColor = true;
			// 
			// buttonCapture
			// 
			this.buttonCapture.Location = new System.Drawing.Point(36, 102);
			this.buttonCapture.Margin = new System.Windows.Forms.Padding(6);
			this.buttonCapture.Name = "buttonCapture";
			this.buttonCapture.Size = new System.Drawing.Size(301, 77);
			this.buttonCapture.TabIndex = 10;
			this.buttonCapture.Text = "Take Screenshot";
			this.buttonCapture.UseVisualStyleBackColor = true;
			this.buttonCapture.Click += new System.EventHandler(this.buttonCapture_Click);
			// 
			// textCustom
			// 
			this.textCustom.Location = new System.Drawing.Point(388, 40);
			this.textCustom.Margin = new System.Windows.Forms.Padding(6);
			this.textCustom.Name = "textCustom";
			this.textCustom.Size = new System.Drawing.Size(186, 31);
			this.textCustom.TabIndex = 9;
			this.textCustom.Text = "1200x800";
			this.textCustom.TextChanged += new System.EventHandler(this.TextCustom_TextChanged);
			// 
			// radioCustom
			// 
			this.radioCustom.AutoSize = true;
			this.radioCustom.Location = new System.Drawing.Point(354, 41);
			this.radioCustom.Margin = new System.Windows.Forms.Padding(6);
			this.radioCustom.Name = "radioCustom";
			this.radioCustom.Size = new System.Drawing.Size(49, 29);
			this.radioCustom.TabIndex = 5;
			this.radioCustom.Text = " ";
			this.radioCustom.UseVisualStyleBackColor = true;
			// 
			// radio4x
			// 
			this.radio4x.AutoSize = true;
			this.radio4x.Location = new System.Drawing.Point(192, 40);
			this.radio4x.Margin = new System.Windows.Forms.Padding(6);
			this.radio4x.Name = "radio4x";
			this.radio4x.Size = new System.Drawing.Size(66, 29);
			this.radio4x.TabIndex = 6;
			this.radio4x.Text = "4x";
			this.radio4x.UseVisualStyleBackColor = true;
			// 
			// radio2x
			// 
			this.radio2x.AutoSize = true;
			this.radio2x.Location = new System.Drawing.Point(114, 40);
			this.radio2x.Margin = new System.Windows.Forms.Padding(6);
			this.radio2x.Name = "radio2x";
			this.radio2x.Size = new System.Drawing.Size(66, 29);
			this.radio2x.TabIndex = 7;
			this.radio2x.Text = "2x";
			this.radio2x.UseVisualStyleBackColor = true;
			// 
			// radio1x
			// 
			this.radio1x.AutoSize = true;
			this.radio1x.Checked = true;
			this.radio1x.Location = new System.Drawing.Point(36, 40);
			this.radio1x.Margin = new System.Windows.Forms.Padding(6);
			this.radio1x.Name = "radio1x";
			this.radio1x.Size = new System.Drawing.Size(66, 29);
			this.radio1x.TabIndex = 8;
			this.radio1x.TabStop = true;
			this.radio1x.Text = "1x";
			this.radio1x.UseVisualStyleBackColor = true;
			// 
			// labelStatus
			// 
			this.labelStatus.AutoSize = true;
			this.labelStatus.ForeColor = System.Drawing.Color.Red;
			this.labelStatus.Location = new System.Drawing.Point(332, 29);
			this.labelStatus.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.labelStatus.Name = "labelStatus";
			this.labelStatus.Size = new System.Drawing.Size(184, 25);
			this.labelStatus.TabIndex = 37;
			this.labelStatus.Text = "IMVU not running.";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(102, 29);
			this.label13.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(218, 25);
			this.label13.TabIndex = 36;
			this.label13.Text = "Detected Resolution: ";
			// 
			// timerMonitor
			// 
			this.timerMonitor.Enabled = true;
			this.timerMonitor.Interval = 1000;
			this.timerMonitor.Tick += new System.EventHandler(this.timerMonitor_Tick);
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(26, 302);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(610, 55);
			this.progressBar1.TabIndex = 39;
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(397, 113);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(163, 25);
			this.label1.TabIndex = 13;
			this.label1.Text = "Remove top-left";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(397, 138);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(178, 25);
			this.label2.TabIndex = 14;
			this.label2.Text = "background color";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(668, 753);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.groupCapture);
			this.Controls.Add(this.labelStatus);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.pictureBox1);
			this.Margin = new System.Windows.Forms.Padding(6);
			this.Name = "Form1";
			this.Text = "HRSS (imvu-e.com)";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.groupCapture.ResumeLayout(false);
			this.groupCapture.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupCapture;
        private System.Windows.Forms.Button buttonCapture;
        private System.Windows.Forms.TextBox textCustom;
        private System.Windows.Forms.RadioButton radioCustom;
        private System.Windows.Forms.RadioButton radio4x;
        private System.Windows.Forms.RadioButton radio2x;
        private System.Windows.Forms.RadioButton radio1x;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Timer timerMonitor;
        private System.Windows.Forms.Timer timerRestore;
		private System.Windows.Forms.RadioButton radio8x;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
	}
}

