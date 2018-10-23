using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeleteBinAndObjFolders
{
    public class DeleteFoldersArgs
    {
        public DeleteFoldersArgs(
            string startingFolder, 
            List<string> foldersToExclude, 
            List<string> foldersToDelete)
        {
            if (string.IsNullOrWhiteSpace(startingFolder))
            {
                throw new ArgumentNullException("startingFolder", "'startingFolder' must be a valid non-empty string");
            }

            if (foldersToDelete == null)
            {
                throw new ArgumentNullException("foldersToDelete", "'foldersToDelete' cannot be null");
            }

            if (foldersToDelete.Count <= 0)
            {
                throw new ArgumentNullException("foldersToDelete", "'foldersToDelete' is required and cannot be an empty list");
            }

            StartingFolder = startingFolder.Trim().TrimEnd('\\');
            FoldersToExclude = foldersToExclude == null ? new List<string>() : foldersToExclude;
            FoldersToDelete = foldersToDelete;

            if (!Directory.Exists(StartingFolder))
            {
                throw new ArgumentException("'startingFolder' must be a valid directory", "startingFolder");
            }
        }

        public string StartingFolder { get; private set; }

        public List<string> FoldersToExclude { get; private set; }

        public List<string> FoldersToDelete { get; private set; }
    }
}
