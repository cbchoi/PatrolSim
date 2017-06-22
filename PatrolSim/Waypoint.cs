using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatrolSim
{
    public class Waypoint
    {
        private int _x;
        private int _y;

        public int X { get { return _x; } }
        public int Y { get { return _y; } }

        public Waypoint(int x, int y, int z)
        {
            _x = x;
            _y = y;
        }
    }
}
