using Autofac;
using ConfigInjector.Configuration;

namespace NimbusWebJob.WebJob.AutofacModules
{
    public class ConfigurationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            ConfigurationConfigurator.RegisterConfigurationSettings()
                                     .FromAssemblies(ThisAssembly)
                                     .RegisterWithContainer(configSetting => builder.RegisterInstance(configSetting)
                                                                                    .AsSelf()
                                                                                    .SingleInstance())
                                     .AllowConfigurationEntriesThatDoNotHaveSettingsClasses(false)
                                     .DoYourThing();
        }
    }
}