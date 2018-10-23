using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeleteBinAndObjFolders
{
    public class FolderManager
    {
        public void DeleteFolders(DeleteFoldersArgs args)
        {
            foreach (string path in Directory.EnumerateDirectories(args.StartingFolder, "*", SearchOption.AllDirectories))
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


        private void Log(string message)
        {
            Console.WriteLine(
                "{0} | FolderManager.DeleteFolders | {1}", 
                DateTime.Now.ToString("o"), 
                message);
        }
    }
}
