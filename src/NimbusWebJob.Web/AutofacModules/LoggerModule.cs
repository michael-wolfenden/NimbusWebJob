using System.Linq;
using Autofac;
using Autofac.Core;
using Serilog;

namespace NimbusWebJob.Web.AutofacModules
{
    public class LoggerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterInstance(Log.Logger)
                .As<ILogger>();
        }

        private static void AddILoggerToParameters(object sender, PreparingEventArgs e)
        {
            var type = e.Component.Activator.LimitType;

            e.Parameters = e.Parameters.Union(new[]
            {
                new ResolvedParameter(
                    (parameterInfo, _) => parameterInfo.ParameterType == typeof (ILogger),
                    (_, context) => context.Resolve<ILogger>().ForContext(type)
                )
            });
        }

        protected override void AttachToComponentRegistration(IComponentRegistry componentRegistry, IComponentRegistration registration)
        {
            registration.Preparing += AddILoggerToParameters;
        }
    }
}