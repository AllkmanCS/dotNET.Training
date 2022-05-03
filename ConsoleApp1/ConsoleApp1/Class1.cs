using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Class1
    {
    }

    public class Rootobject
    {
        public Admin Admin { get; set; }
        public Team Team { get; set; }
        public Player Player { get; set; }
    }

    public class Admin
    {
        public string AdminId { get; set; }
    }

    public class Team
    {
        public string TeamId { get; set; }
    }

    public class Player
    {
        public string PlayerId { get; set; }
    }

}
