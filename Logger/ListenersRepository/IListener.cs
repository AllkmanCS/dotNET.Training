using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListenersRepository
{
    public interface IListener
    {
        void Write(string message);
        //string MinLogLevel { get; }
    }
}
