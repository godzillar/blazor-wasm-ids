using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Data.Configuration
{
    public class BackendDataConfiguration : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Add services.

            base.Load(builder);
        }
    }
}
