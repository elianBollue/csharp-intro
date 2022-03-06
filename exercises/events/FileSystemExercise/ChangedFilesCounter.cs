using System.Collections.Generic;

namespace FileSystemExercise
{
    public class ChangedFilesCounter
    {
        private HashSet<string> changedFiles;
        public ChangedFilesCounter(IFileSystem fs)
        {
            changedFiles = new HashSet<string>();
            fs.FileCreated += OnFileModified;
            fs.FileWritten += OnFileModified;
            fs.FileDeleted += OnFileModified;
        }

        private void OnFileModified(string path)
        {
            changedFiles.Add(path);
        }

        public int ChangeCount {
            get {
                return changedFiles.Count;
            }
        }
    }
}
