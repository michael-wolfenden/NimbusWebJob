using System;
using Autofac;
using Nimbus;
using Nimbus.Configuration;
using Nimbus.Infrastructure;
using Nimbus.Logger.Serilog;
using NimbusWebJob.MessageContracts;
using NimbusWebJob.Web.ConfigurationSettings;

namespace NimbusWebJob.Web.AutofacModules
{
    public class BusModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var messageContactAssembly = typeof(IMessageContractsAssembly).Assembly;
            var thisAssembly = ThisAssembly;
            var handlerTypesProvider = new AssemblyScanningTypeProvider(messageContactAssembly);
            var assemblyName = thisAssembly.GetName().Name;

            builder.RegisterNimbus(handlerTypesProvider);

            builder.RegisterType<SerilogStaticLogger>()
                   .AsImplementedInterfaces()
                   .SingleInstance();

            builder.Register(context => new BusBuilder()
                        .Configure()
                        .WithConnectionString(
                            context.Resolve<ServiceBusConnectionStringSetting>()
                        )
                        .WithNames(assemblyName, Environment.MachineName)
                        .WithTypesFrom(handlerTypesProvider)
                        .WithAutofacDefaults(context)
                        .WithJsonSerializer()
                        .Build()
                    )
                   .As<IBus>()
                   .AutoActivate()
                   .OnActivated(c => c.Instance.Start())
                   .SingleInstance();
        }
    }
}