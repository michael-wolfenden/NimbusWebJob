using System;
using System.IO;
using System.Threading;
using NimbusWebJob.WebJob.Infrastructure;
using NimbusWebJob.WebJob.Infrastructure.Extensions;
using Serilog;

namespace NimbusWebJob.WebJob
{
    public class Program
    {
        private const int ErrorExitCode = 1;
        private static readonly ManualResetEvent Gate = new ManualResetEvent(false);

        private static void Main()
        {
            Logging.Configure();

            try
            {
                StartNimbus();
            }
            catch (Exception ex)
            {
                Log.Logger.Fatal(ex, "An Unhandled exception was thrown");
                Environment.Exit(ErrorExitCode);
            }
        }

        private static void StartNimbus()
        {
            using (new FolderWatcher(PathToWatchToDetectShutdown(), args => Gate.Open()))
            using (new DisposableAction(IoC.Shutdown))
            {
                IoC.Configure();
                Gate.BlockUntilOpened();
            }
        }

        private static string PathToWatchToDetectShutdown()
        {
            // The way Azure notifies the process it's about to be stopped is by placing 
            // (creating) a file at a path that is passed as an environment variable 
            // called WEBJOBS_SHUTDOWN_FILE. Locally, this environmental variable will not
            // exists so we set the watch folder to %TEMP%\WEBJOBS_SHUTDOWN_FILE\ directory
            // see: http://blog.amitapple.com/post/2014/05/webjobs-graceful-shutdown/

            const string webjobsShutdownFile = "WEBJOBS_SHUTDOWN_FILE";

            var pathToWatch = Environment.GetEnvironmentVariable(webjobsShutdownFile)
                              ?? Path.Combine(Path.GetTempPath(), webjobsShutdownFile + "\\");

            return pathToWatch;
        }
    }
}