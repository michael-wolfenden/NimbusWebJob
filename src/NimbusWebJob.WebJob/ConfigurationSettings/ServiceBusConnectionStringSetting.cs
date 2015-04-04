using System;
using ConfigInjector;

namespace NimbusWebJob.WebJob.ConfigurationSettings
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