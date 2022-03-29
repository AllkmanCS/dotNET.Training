using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringApplication.Configurations
{
    internal class WebsiteConfigurations
    {
        public int CheckInterval { get; set; }
        public int ResponseTime { get; set; } //or MaxResponseTime
        public string PageUrl { get; set; }
        public string AdminEmail { get; set; }

    }
}
