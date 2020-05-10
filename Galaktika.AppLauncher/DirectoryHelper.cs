using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaktika.AppLauncher
{
	public class DirectoryHelper
	{
		public static int GetFilesCountRecursively(DirectoryInfo directory)
		{
			if (!directory.Exists)
			{
				throw new ArgumentException("Директория не существует", "directory");
			}
			var cICount = directory.GetFiles().Count();
			foreach (DirectoryInfo cDiSubdirectory in directory.GetDirectories())
			{
				cICount += GetFilesCountRecursively(cDiSubdirectory);
			}
			return cICount;
		}

		public static long GetFilesSizeRecursively(DirectoryInfo directory)
		{
			if (!directory.Exists)
			{
				throw new ArgumentException("Директория не существует", "directory");
			}
			long size = directory.GetFiles().Select(x => x.Length).Sum();
			foreach (DirectoryInfo cDiSubdirectory in directory.GetDirectories())
			{
				size += GetFilesSizeRecursively(cDiSubdirectory);
			}
			return size;
		}
	}
}
