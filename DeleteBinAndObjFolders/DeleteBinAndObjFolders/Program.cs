using System;
using DeleteBinAndObjFolders.Properties;

namespace DeleteBinAndObjFolders
{
	class Program
	{
		static void Main(string[] args)
		{
			if (args.Length == 0)
			{
				PrintUsage();

				return;
			}

			var folderManager = new FolderManager();

			try
			{
				folderManager.DeleteFolders(
						new DeleteFoldersArgs(
								startingFolder: args[0],
								foldersToExclude: Settings
									.Default
									.FoldersToExclude
									.ConvertToList(),
								foldersToDelete: Settings
									.Default
									.FoldersToDelete
									.ConvertToList()
						));
			}
			catch (Exception ex)
			{
				Display(ex);
			}
		}


		private static void Display(Exception ex)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine($"Error:  {ex}");
			Console.ResetColor();
		}

		private static void PressAnyKeyToContinue()
		{
			Console.WriteLine("Press any key to continue...");
			Console.ReadKey();
		}

		private static void PrintUsage()
		{
			Console.WriteLine(@"usage example:  DeleteBinAndObjFolders.exe ""c:\temp\some-folder""");
			Console.WriteLine(@"usage example:  DeleteBinAndObjFolders.exe ""..\..\some-folder""");
		}
	}
}
