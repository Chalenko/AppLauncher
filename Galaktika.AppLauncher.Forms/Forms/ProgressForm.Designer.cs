namespace Galaktika.AppLauncher.Forms.Forms
{
	partial class ProgressForm
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.pbMain = new System.Windows.Forms.ProgressBar();
			this.lblPercent = new System.Windows.Forms.Label();
			this.lblFileName = new System.Windows.Forms.Label();
			this.bgwMain = new System.ComponentModel.BackgroundWorker();
			this.lblPleaseWait = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// pbMain
			// 
			this.pbMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pbMain.Location = new System.Drawing.Point(12, 35);
			this.pbMain.Name = "pbMain";
			this.pbMain.Size = new System.Drawing.Size(411, 31);
			this.pbMain.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.pbMain.TabIndex = 0;
			// 
			// lblPercent
			// 
			this.lblPercent.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.lblPercent.AutoSize = true;
			this.lblPercent.Location = new System.Drawing.Point(196, 41);
			this.lblPercent.Name = "lblPercent";
			this.lblPercent.Size = new System.Drawing.Size(28, 17);
			this.lblPercent.TabIndex = 1;
			this.lblPercent.Text = "0%";
			// 
			// lblFileName
			// 
			this.lblFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblFileName.AutoSize = true;
			this.lblFileName.Location = new System.Drawing.Point(12, 72);
			this.lblFileName.Name = "lblFileName";
			this.lblFileName.Size = new System.Drawing.Size(67, 17);
			this.lblFileName.TabIndex = 2;
			this.lblFileName.Text = "FileName";
			// 
			// bgwMain
			// 
			this.bgwMain.WorkerReportsProgress = true;
			this.bgwMain.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwMain_DoWork);
			this.bgwMain.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwMain_ProgressChanged);
			this.bgwMain.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwMain_RunWorkerCompleted);
			// 
			// lblPleaseWait
			// 
			this.lblPleaseWait.Location = new System.Drawing.Point(12, 9);
			this.lblPleaseWait.Name = "lblPleaseWait";
			this.lblPleaseWait.Size = new System.Drawing.Size(411, 23);
			this.lblPleaseWait.TabIndex = 3;
			this.lblPleaseWait.Text = "Идет обновление системы. Пожалуйста подождите...";
			this.lblPleaseWait.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// ProgressForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(435, 98);
			this.Controls.Add(this.lblPleaseWait);
			this.Controls.Add(this.lblFileName);
			this.Controls.Add(this.lblPercent);
			this.Controls.Add(this.pbMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ProgressForm";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Обновление системы";
			this.Load += new System.EventHandler(this.ProgressForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ProgressBar pbMain;
		private System.Windows.Forms.Label lblPercent;
		private System.Windows.Forms.Label lblFileName;
		private System.ComponentModel.BackgroundWorker bgwMain;
		private System.Windows.Forms.Label lblPleaseWait;
	}
}