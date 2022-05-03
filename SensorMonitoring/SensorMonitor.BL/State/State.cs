using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorMonitor.BL.State
{
    public abstract class SensorState
    {
        public abstract void Handle(Sensor context);
    }
}
