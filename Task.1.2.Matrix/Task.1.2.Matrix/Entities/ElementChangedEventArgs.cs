﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task._1._2.Matrix.Entities
{
    internal class ElementChangedEventArgs<T> : EventArgs
    {
        public ElementChangedEventArgs(int index, T? oldValue)
        {
            Index = index;
            OldValue = oldValue;
        }
        public ElementChangedEventArgs()
        {

        }
        public int Index { get; set; }
        public T? OldValue { get; set; }
    }
}
