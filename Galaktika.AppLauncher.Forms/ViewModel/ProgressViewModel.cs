using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaktika.AppLauncher.Forms.ViewModel
{
	public class ProgressViewModel
	{
		public int ProgressPercent { get; private set; }
		public string FileName { get; private set; } = "file";

		public void Run(BackgroundWorker worker)
		{
			AppLauncher launcher = new AppLauncher
			{
				FileWorker = new FileWorker()
			};
			launcher.FileWorker.FileNameChanged += new FileNameChangedHandler(
				(file) => {
					FileName = file;
					worker.ReportProgress(ProgressPercent, FileName);
				});
			launcher.FileWorker.AffectedFileCountChanged += new AffectedFileCountChangedHandler(
				(count) =>
				{
					ProgressPercent = (int)Math.Min(100.0 * count / launcher.TotalFilesCount, 100);
					worker.ReportProgress(ProgressPercent, FileName);
				});
			//launcher.FileWorker.AffectedSizeChanged += new AffectedSizeChangedHandler(
			//	(size) => {
			//		ProgressPercent = (int)Math.Min(100.0 * size / launcher.TotalSize, 100);
			//		worker.ReportProgress(ProgressPercent, FileName);
			//	});
			launcher.CopyTargetApp();
		}
	}
}
