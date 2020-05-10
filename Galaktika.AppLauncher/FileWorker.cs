using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaktika.AppLauncher
{
	public delegate void AffectedFileCountChangedHandler(int fileCount);
	public delegate void AffectedSizeChangedHandler(long size);
	public delegate void FileNameChangedHandler(string fileName);

	public class FileWorker
	{
		public int FileCount { get; private set; } = 0;
		public long Size { get; private set; } = 0;

		public event AffectedFileCountChangedHandler AffectedFileCountChanged;
		public event AffectedSizeChangedHandler AffectedSizeChanged;
		public event FileNameChangedHandler FileNameChanged;

		public void CopyDirectoryWithFiles(DirectoryInfo src, DirectoryInfo dst)
		{
			CopyFilesRecursively(src, dst);
		}

		private void CopyFilesRecursively(DirectoryInfo source, DirectoryInfo target)
		{
			foreach (DirectoryInfo dir in source.GetDirectories())
				CopyFilesRecursively(dir, target.CreateSubdirectory(dir.Name));
			foreach (FileInfo file in source.GetFiles())
			{
				//Size += file.Length;
				AffectedSizeChanged?.Invoke(Size += file.Length);
				AffectedFileCountChanged?.Invoke(FileCount++);
				FileNameChanged?.Invoke(file.Name);
				if (IsCopyNeed(file, target))
				{
					file.CopyTo(Path.Combine(target.FullName, file.Name), true);
				}
			}
		}

		private bool IsCopyNeed(FileInfo file, DirectoryInfo destination)
		{
			FileInfo targetFile = new FileInfo(string.Format("{0}\\{1}", destination.FullName, file.Name));
			return 
				!targetFile.Exists 
				|| file.LastWriteTime != targetFile.LastWriteTime;
		}
	}
}
