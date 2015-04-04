using System;
using System.Diagnostics;
using System.Threading;
using Autofac;
using NimbusWebJob.WebJob.Infrastructure;
using NimbusWebJob.WebJob.Infrastructure.Extensions;
using Serilog;

namespace NimbusWebJob.WebJob
{
    public class Program
    {
        private static readonly ManualResetEvent Gate = new ManualResetEvent(false);
        private const int ErrorExitCode = 1;

        private static void Main()
        {
            Logging.Configure();

            try
            {
                DoWork();
            }
            catch (Exception ex)
            {
                Log.Logger.Fatal(ex, "An Unhandled exception was thrown");
                Environment.Exit(ErrorExitCode);
            }
        }

        private static void DoWork()
        {
            using (new Sentinel(args => Gate.Open()))
            using (new DisposableAction(IoC.Shutdown))
            {
                IoC.Configure();

                Gate.BlockUntilOpened();
            }
        }
    }
}