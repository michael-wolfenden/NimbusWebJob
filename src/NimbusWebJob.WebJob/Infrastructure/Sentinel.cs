using System;
using System.IO;
using Serilog;

namespace NimbusWebJob.WebJob.Infrastructure
{
    // see: http://blog.amitapple.com/post/2014/05/webjobs-graceful-shutdown/
    public class Sentinel : IDisposable
    {
        public const string WebjobsShutdownFile = "WEBJOBS_SHUTDOWN_FILE";

        private readonly FileSystemWatcher _shutdownFileSystemWatcher;

        public Sentinel(Action<FileSystemEventArgs> onShutdownFileChanged, string localDirectoryToWatch = @"c:\temp\")
        {
            var shutdownFile = Environment.GetEnvironmentVariable(WebjobsShutdownFile) ?? localDirectoryToWatch;

            _shutdownFileSystemWatcher = new FileSystemWatcher(Path.GetDirectoryName(shutdownFile));
            _shutdownFileSystemWatcher.Created += (sender, args) => onShutdownFileChanged(args);
            _shutdownFileSystemWatcher.NotifyFilter = NotifyFilters.CreationTime | NotifyFilters.FileName | NotifyFilters.LastWrite;
            _shutdownFileSystemWatcher.IncludeSubdirectories = false;
            _shutdownFileSystemWatcher.EnableRaisingEvents = true;
        }

        public void Dispose()
        {
            Log.Information("Disposing Sentinel");
            _shutdownFileSystemWatcher.Dispose();
        }
    }
}