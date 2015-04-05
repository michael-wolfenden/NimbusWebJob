using System;
using ConfigInjector;

namespace NimbusWebJob.WebJobHost.ConfigurationSettings
{
    public class ServiceBusConnectionStringSetting : ConfigurationSetting<string>
    {
        public override string Value
        {
            get { return base.Value.Replace("{MachineName}", Environment.MachineName); }
            set { base.Value = value; }
        }
    }
}