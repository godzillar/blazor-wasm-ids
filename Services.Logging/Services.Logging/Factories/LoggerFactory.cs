using Services.Logging.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Logging.Factories
{
    internal class LoggerFactory
    {
        public virtual ILogService Create() {
            return null;
        }
    }
}
