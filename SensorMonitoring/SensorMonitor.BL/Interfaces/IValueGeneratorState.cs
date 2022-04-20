﻿using Sensors.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SensorMonitor.BL.Interfaces
{
    public interface IValueGeneratorState
    {
        double GetMeasuredValue(int measurementInterval);
    }
}
