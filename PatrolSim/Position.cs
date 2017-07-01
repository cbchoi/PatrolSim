using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatrolSim
{
    [Serializable]
    public class Position
    {
        private double _x;
        private double _y;

        public double X { get { return _x; } set { _x = value; }}
        public double Y { get { return _y; } set { _y = value; } }

        public Position(double x, double y)
        {
            _x = x;
            _y = y;
        }
    }
}
