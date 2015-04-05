using Autofac;
using ConfigInjector.Configuration;

namespace NimbusWebJob.WebJobHost.AutofacModules
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
                                     .ExcludeSettingKeys(
                                        "webpages:Version",
                                        "webpages:Enabled",
                                        "ClientValidationEnabled",
                                        "UnobtrusiveJavaScriptEnabled"
                                      )
                                     .DoYourThing();
        }
    }
}