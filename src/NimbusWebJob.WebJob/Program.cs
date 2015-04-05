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
            // http://blog.amitapple.com/post/2014/05/webjobs-graceful-shutdown/
            const string webjobsShutdownFile = "WEBJOBS_SHUTDOWN_FILE";

            var pathToWatch = Environment.GetEnvironmentVariable(webjobsShutdownFile)
                              ?? Path.Combine(Path.GetTempPath(), webjobsShutdownFile);

            return pathToWatch;
        }
    }
}