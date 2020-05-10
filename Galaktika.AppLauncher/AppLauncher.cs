using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaktika.AppLauncher
{
	public class AppLauncher
	{
		public FileWorker FileWorker { get; set; } = null;
		public int TotalFilesCount { get; private set; } = 0;
		public long TotalSize { get; private set; } = 0;

		public void RunTargetApp()
		{
			string dstDir = ConfigurationManager.AppSettings["DestinationDirectory"];
			string exe = ConfigurationManager.AppSettings["ExecutableFile"];
			string processName = string.Concat(dstDir, "\\", exe);

			Process.Start(processName);
		}

		public void CopyTargetApp()
		{
			string srcDirs = ConfigurationManager.AppSettings["SourceDirectories"];
			if (!RepositoryHelper.DirectoryListNotEmpty(srcDirs))
			{
				throw new ArgumentException("Недопустимый аргумент", "SorceDirectories");
			}
			List<string> srcDirsList = RepositoryHelper.GetRepositoryList(srcDirs);
			foreach (string path in srcDirsList)
			{
				if (!Directory.Exists(path))
				{
					throw new ArgumentException("Директория-источник не существует", path);
				}
			}
			TotalFilesCount = srcDirsList.Select(x => DirectoryHelper.GetFilesCountRecursively(new DirectoryInfo(x))).Sum();
			TotalSize = srcDirsList.Select(x => DirectoryHelper.GetFilesSizeRecursively(new DirectoryInfo(x))).Sum();

			string dstDir = ConfigurationManager.AppSettings["DestinationDirectory"];
			if (!RepositoryHelper.DirectoryListNotEmpty(dstDir)) return;
			List<string> dstDirsList = RepositoryHelper.GetRepositoryList(dstDir);
			if (dstDirsList.Count != 1)
			{
				throw new ArgumentException("Указано несколько дирекорий назначения", "DestinationDirectory");
			}

			if (!Directory.Exists(dstDir))
				Directory.CreateDirectory(dstDir);

			foreach (string srcDir in srcDirsList)
			{
				DirectoryInfo dstInfo = new DirectoryInfo(dstDir);
				DirectoryInfo srcInfo = new DirectoryInfo(srcDir);
				FileWorker.CopyDirectoryWithFiles(srcInfo, dstInfo);
			}
		}
	}
}
