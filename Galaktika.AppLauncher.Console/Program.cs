using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaktika.AppLauncher.Console
{
	class Program
	{
		static void Main(string[] args)
		{
			AppLauncher launcher = new AppLauncher
			{
				FileWorker = new FileWorker()
			};
			launcher.FileWorker.FileNameChanged += new FileNameChangedHandler(
				(file) => {
					System.Console.WriteLine(file);
				});
			launcher.CopyTargetApp();
			launcher.RunTargetApp();
		}
	}
}
