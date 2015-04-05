using System;
using System.Threading.Tasks;
using ConfigInjector.QuickAndDirty;
using NimbusWebJob.WebJobHost.ConfigurationSettings;
using Serilog;
using Serilog.Events;

namespace NimbusWebJob.WebJobHost
{
    public static class Logging
    {
        public static void Configure()
        {
            var thisAssembly = typeof (Logging).Assembly;

            var assemblyName = thisAssembly.GetName().Name;
            var assemblyVersion = thisAssembly.GetName().Version;
            var seqUri = DefaultSettingsReader.Get<SeqUriSetting>();

            var loggerConfig = new LoggerConfiguration()
                                .MinimumLevel.Is(LogEventLevel.Debug)
                                .Enrich.FromLogContext()
                                .Enrich.WithMachineName()
                                .Enrich.WithThreadId()
                                .Enrich.WithProperty("ApplicationName", assemblyName)
                                .Enrich.WithProperty("ApplicationVersion", assemblyVersion)
                                .WriteTo.Seq(seqUri.ToString())
                                .WriteTo.Trace();

            Log.Logger = loggerConfig.CreateLogger();

           AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
           TaskScheduler.UnobservedTaskException += LogUnobservedTaskException;
        }

        private static void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Log.Logger.Fatal(e.ExceptionObject as Exception, "An unobserved exception was thrown.");
        }

        private static void LogUnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            Log.Logger.Fatal(e.Exception, "An unobserved exception was thrown on a TaskScheduler thread.");
        }
    }
}