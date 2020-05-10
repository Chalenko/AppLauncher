using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Galaktika.AppLauncher.Test
{
	[TestClass]
	public class DirectoryHelperTest
	{
		[TestMethod]
		public void FilesCountRecousively5Files()
		{
			//Arrange
			string dir = "C:\\Temp\\TestDir1";
			DirectoryInfo di = new DirectoryInfo(dir);
			if (!di.Exists)
				di.Create();
			for (int i = 0; i < 5; i++) { var fs = File.Create(dir + "\\" + i + ".txt"); fs.Close(); }
			di.Refresh();

			//Act
			int filesCount = DirectoryHelper.GetFilesCountRecursively(di);

			//Undo
			if (di.Exists)
				di.Delete(true);

			//Assert
			Assert.AreEqual(5, filesCount);
		}

		[TestMethod]
		public void FilesCountRecousively0Files()
		{
			//Arrange
			string dir = "C:\\Temp\\TestDir2";
			DirectoryInfo di = new DirectoryInfo(dir);
			if (!di.Exists)
				di.Create();
			di.Refresh();

			//Act
			int filesCount = DirectoryHelper.GetFilesCountRecursively(di);

			//Undo
			if (di.Exists)
				di.Delete(true);

			//Assert
			Assert.AreEqual(0, filesCount);
		}

		[TestMethod]
		public void FilesCountRecousively1FilesAnd3FilesInSub()
		{
			//Arrange
			string dir = "C:\\Temp\\TestDir3";
			string subDir = "C:\\Temp\\TestDir3\\TestDir4";
			DirectoryInfo di = new DirectoryInfo(dir);
			if (!di.Exists)
				di.Create();
			for (int i = 0; i < 1; i++) { var fs = File.Create(dir + "\\" + i + ".txt"); fs.Close(); }
			DirectoryInfo sDi = new DirectoryInfo(subDir);
			if (!sDi.Exists)
				sDi.Create();
			for (int i = 0; i < 3; i++) { var fs = File.Create(subDir + "\\" + i + ".txt"); fs.Close(); }
			di.Refresh();

			//Act
			int filesCount = DirectoryHelper.GetFilesCountRecursively(di);

			//Undo
			if (di.Exists)
				di.Delete(true);

			//Assert
			Assert.AreEqual(4, filesCount);
		}

		[TestMethod]
		public void FilesCountRecousivelyThrowExceptionIfDirectoryNotExist()
		{
			//Arrange
			string dir = "C:\\Temp\\TestDir5";
			DirectoryInfo di = new DirectoryInfo(dir);
			if (di.Exists)
				di.Delete(true);
			di.Refresh();

			//Act
			try
			{
				int filesCount = DirectoryHelper.GetFilesCountRecursively(di);
			}

			//Assert
			catch (ArgumentException ex)
			{
				Assert.AreEqual("Директория не существует\r\nИмя параметра: directory", ex.Message);
				return;
			}

			if (di.Exists)
				di.Delete(true);

			Assert.Fail();
		}
	}
}
