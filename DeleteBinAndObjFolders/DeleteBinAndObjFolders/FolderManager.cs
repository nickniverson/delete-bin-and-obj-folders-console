using System;
using System.IO;
using System.Linq;

namespace DeleteBinAndObjFolders
{
	public class FolderManager
	{
		public void DeleteFolders(DeleteFoldersArgs args)
		{
			foreach (string path in Directory.EnumerateDirectories(GetStartingFolder(args), "*", SearchOption.AllDirectories))
			{
				var directory = new DirectoryInfo(path);

				if (args.FoldersToExclude.Any() && args.FoldersToExclude.Any(folder => directory.FullName.ToLower().Contains(folder.ToLower())))
				{
					Log("Excluding Directory:  " + directory.FullName);

					continue;
				}

				if (args.FoldersToDelete.Any(folder => folder.ToLower() == directory.Name.ToLower()))
				{
					Log("Deleting Directory:  " + directory.FullName);

					directory.Delete(recursive: true);
				}
			}
		}


		private string GetStartingFolder(DeleteFoldersArgs args)
		{
			var path = Path.Combine(
				Environment.CurrentDirectory, 
				args.StartingFolder);

			return path;
		}


		private void Log(string message)
		{
			Console.WriteLine(
					"{0} | {1}",
					DateTime.Now.ToString("o"),
					message);
		}
	}
}
