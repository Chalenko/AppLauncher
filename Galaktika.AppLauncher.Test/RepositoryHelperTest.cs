using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Galaktika.AppLauncher.Test
{
	[TestClass]
	public class RepositoryTester
	{
		[TestMethod]
		public void DirectoryListNotEmptyReturnTrueIf1Repos()
		{
			//Arrange
			string sourceString = "D:\\Programs\\Modelio Open Source 3.7";

			//Act
			bool result = RepositoryHelper.DirectoryListNotEmpty(sourceString);

			//Assert
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void DirectoryListNotEmptyReturnTrueIf2Repos()
		{
			//Arrange
			string sourceString = "D:\\Programs\\Modelio Open Source 3.7;C:\\KAZ_KP_67_ESB";

			//Act
			bool result = RepositoryHelper.DirectoryListNotEmpty(sourceString);

			//Assert
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void DirectoryListNotEmptyReturnFalseIfNoRepos()
		{
			//Arrange
			string sourceString = "";

			//Act
			bool result = RepositoryHelper.DirectoryListNotEmpty(sourceString);

			//Assert
			Assert.IsFalse(result);
		}

		[TestMethod]
		public void DirectoryListNotEmptyReturnFalseIfWhitespace()
		{
			//Arrange
			string sourceString = "        ";

			//Act
			bool result = RepositoryHelper.DirectoryListNotEmpty(sourceString);

			//Assert
			Assert.IsFalse(result);
		}

		[TestMethod]
		public void DirectoryListNotEmptyReturnFalseIf2Whitespace()
		{
			//Arrange
			string sourceString = "        ;   ";

			//Act
			bool result = RepositoryHelper.DirectoryListNotEmpty(sourceString);

			//Assert
			Assert.IsFalse(result);
		}

		[TestMethod]
		public void DirectoryListNotEmptyReturnFalseIfNull()
		{
			//Arrange
			string sourceString = null;

			//Act
			bool result = RepositoryHelper.DirectoryListNotEmpty(sourceString);

			//Assert
			Assert.IsFalse(result);
		}

		[TestMethod]
		public void GetRepositoryListReturnOneDir()
		{
			//Arrange
			string sourceString = "D:\\Programs\\Modelio Open Source 3.7";
			string targetRepo = "D:\\Programs\\Modelio Open Source 3.7";

			//Act
			List<string> result = RepositoryHelper.GetRepositoryList(sourceString);

			//Assert
			Assert.AreEqual(1, result.Count);
			Assert.AreEqual(targetRepo, result[0]);
		}

		[TestMethod]
		public void GetRepositoryListReturnTwoDir()
		{
			//Arrange
			string sourceString = "D:\\Programs\\Modelio Open Source 3.7;C:\\KAZ_KP_67_ESB";
			string targetRepo1 = "D:\\Programs\\Modelio Open Source 3.7";
			string targetRepo2 = "C:\\KAZ_KP_67_ESB";

			//Act
			List<string> result = RepositoryHelper.GetRepositoryList(sourceString);

			//Assert
			Assert.AreEqual(2, result.Count);
			Assert.AreEqual(targetRepo1, result[0]);
			Assert.AreEqual(targetRepo2, result[1]);
		}

		[TestMethod]
		public void GetRepositoryListReturnNullIfSourceDirectoryListIsEmpty()
		{
			//Arrange
			string sourceString = "        ;   ";

			//Act
			List<string> result = RepositoryHelper.GetRepositoryList(sourceString);

			//Assert
			Assert.IsNull(result);
		}
	}
}
