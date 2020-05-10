using Galaktika.AppLauncher.Forms.Forms;
using Galaktika.AppLauncher.Forms.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Galaktika.AppLauncher.Forms
{
	static class Program
	{
		/// <summary>
		/// Главная точка входа для приложения.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Form progress = new ProgressForm(new ProgressViewModel());
			Application.Run(progress);
			if (progress.DialogResult == DialogResult.OK)
				new AppLauncher().RunTargetApp();
		}
	}
}
