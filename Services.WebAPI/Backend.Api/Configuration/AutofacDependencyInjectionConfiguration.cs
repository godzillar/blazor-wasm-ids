using Autofac;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Api.Configuration
{
    public class AutofacDependencyInjectionConfiguration : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
        }
    }
}
