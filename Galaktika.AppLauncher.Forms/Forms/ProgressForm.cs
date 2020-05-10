using Galaktika.AppLauncher.Forms.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Galaktika.AppLauncher.Forms.Forms
{
	public partial class ProgressForm : Form
	{
		private ProgressViewModel vm;

		private ProgressForm()
		{
			InitializeComponent();
		}

		public ProgressForm(ProgressViewModel vm) : this()
		{
			this.vm = vm;
		}

		private void bind()
		{
		}

		private void backBind()
		{
			pbMain.Value = vm.ProgressPercent;
			lblPercent.Text = string.Format("{0}%", vm.ProgressPercent);
			lblFileName.Text = vm.FileName;
			//bgwMain.ReportProgress(vm.ProgressPercent, vm.FileName);
		}

		private void ProgressForm_Load(object sender, EventArgs e)
		{
			bgwMain.RunWorkerAsync();
		}

		private void bgwMain_DoWork(object sender, DoWorkEventArgs e)
		{
			vm.Run(bgwMain);
		}

		private void bgwMain_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			bind();
			//pbMain.Value = e.ProgressPercentage;
			//lblPercent.Text = string.Format("{0}%", e.ProgressPercentage);
			//lblFileName.Text = e.UserState.ToString();
			backBind();
		}

		private void bgwMain_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (e.Cancelled)
				DialogResult = System.Windows.Forms.DialogResult.Cancel;
			else if (e.Error != null)
			{
				MessageBox.Show(e.Error.ToString());
				DialogResult = System.Windows.Forms.DialogResult.Abort;
			}
			else
				DialogResult = System.Windows.Forms.DialogResult.OK;

			this.Close();
		}
	}
}
