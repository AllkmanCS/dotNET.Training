using Sensors.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorMonitor.BL.Interfaces
{
    public interface IValueGenerator
    {
        double GetMeasuredValue(double value);
    }
}
