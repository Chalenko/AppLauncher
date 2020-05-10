using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaktika.AppLauncher
{
	public class RepositoryHelper
	{
		public static bool DirectoryListNotEmpty(string source)
		{
			if (string.IsNullOrWhiteSpace(source)) return false;
			string[] srcDirsList = source.Split(';');
			if (srcDirsList.Count() == 0) return false;
			return srcDirsList.All(x => !string.IsNullOrWhiteSpace(x));
		}

		public static List<string> GetRepositoryList(string source)
		{
			if (DirectoryListNotEmpty(source))
				return source.Split(';').ToList();
			else
				return null;
		}
	}
}
