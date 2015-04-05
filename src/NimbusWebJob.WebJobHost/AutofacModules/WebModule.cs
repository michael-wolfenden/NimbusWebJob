﻿using Autofac;
using Autofac.Integration.Mvc;

namespace NimbusWebJob.WebJobHost.AutofacModules
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterControllers(ThisAssembly);
        }
    }
}