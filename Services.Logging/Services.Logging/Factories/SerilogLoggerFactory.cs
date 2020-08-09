using Serilog;
using Services.Logging.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Logging.Factories
{
    internal class SerilogLoggerFactory : LoggerFactory
    {
        public override ILogService Create()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();


            return base.Create();
        }
    }
}
