using System;
using System.IO;
using Serilog;

namespace NimbusWebJob.WebJob.Infrastructure
{
    public class FolderWatcher : IDisposable
    {
        private readonly FileSystemWatcher _watcher;

        public FolderWatcher(string folderToWatch, Action<FileSystemEventArgs> onCreateOrChange)
        {
            Log.Information("FolderWatcher watching {FolderToWatch}", folderToWatch);

            _watcher = new FileSystemWatcher(Path.GetDirectoryName(folderToWatch));

            _watcher.Created += (sender, args) =>
            {
                Log.Information("FolderWatcher detected 'Created' event {@FileSystemEventArgs}", args);
                onCreateOrChange(args);
            };

            _watcher.NotifyFilter = NotifyFilters.CreationTime | NotifyFilters.FileName | NotifyFilters.LastWrite;
            _watcher.IncludeSubdirectories = false;
            _watcher.EnableRaisingEvents = true;
        }

        public void Dispose()
        {
            Log.Information("FolderWatcher disposing");

            _watcher.Dispose();
        }
    }
}