using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeleteBinAndObjFolders
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            { 
                PrintUsage();
                PressAnyKeyToContinue();

                return;
            }

            var folderManager = new FolderManager();

            folderManager.DeleteFolders(
                new DeleteFoldersArgs(
                    startingFolder: args[0],
                    foldersToExclude: new List<string>
                    {
                        "packages",
                        "node_modules",
                    },
                    foldersToDelete: new List<string>
                    {
                        "bin",
                        "obj"
                    }
                ));

            PressAnyKeyToContinue();
        }

        private static void PressAnyKeyToContinue()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static void PrintUsage()
        {
            Console.WriteLine(@"usage example:  DeleteBinAndObjFolders.exe ""c:\temp\some-folder""");
        }
    }
}
