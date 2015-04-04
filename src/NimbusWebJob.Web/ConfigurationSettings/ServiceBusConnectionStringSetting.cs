using System;
using ConfigInjector;

namespace NimbusWebJob.Web.ConfigurationSettings
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