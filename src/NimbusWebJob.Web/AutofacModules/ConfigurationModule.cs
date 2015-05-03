using Autofac;
using ConfigInjector.Configuration;

namespace NimbusWebJob.Web.AutofacModules
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
                                    // seems that on deployment, azure add extra settings 
                                    // to your configuration file
                                     .AllowConfigurationEntriesThatDoNotHaveSettingsClasses(true)
                                     .DoYourThing();
        }
    }
}