using Autofac;
using Serilog;

namespace NimbusWebJob.Web
{
    public static class IoC
    {
        public static IContainer Container { get; private set; }

        public static void Configure()
        {
            var thisAssembly = typeof(IoC).Assembly;

            var builder = new ContainerBuilder();
            builder.RegisterAssemblyModules(thisAssembly);

            Container = builder.Build();
        }

        public static void Shutdown()
        {
            Log.Information("Disposing IoC Container");

            if (Container == null) return;
            Container.Dispose();
        }
    }
}