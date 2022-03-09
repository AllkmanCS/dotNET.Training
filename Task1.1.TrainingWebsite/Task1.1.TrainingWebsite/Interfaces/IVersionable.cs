using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1._1.TrainingWebsite.Interfaces
{
    public interface IVersionable
    {
        byte[] ReadVersion();
        void SetVersion(byte[] version);
    }
}
