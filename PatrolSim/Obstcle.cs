using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PatrolSim
{
    class Obstcle
    {
        private int _x;
        private int _y;
        private int _z;
        private Color _clr;

        public int X { get { return _x; } }
        public int Y { get { return _y; } }
        public int Z { get { return _z; } }
        public Color ObColor { get { return _clr; } }

        private void Initalize(int x, int y, int z, Color clr)
        {
            _x = x;
            _y = y;
            _z = z;

            _clr = clr;
        }

        public Obstcle(int x, int y, int z, Color clr)
        {
            Initalize(x, y, z, clr);
        }

        public Obstcle(XmlNode node)
        {
            int x = Int32.Parse(node.Attributes["x"].Value);
            int y = Int32.Parse(node.Attributes["y"].Value);
            int z = Int32.Parse(node.Attributes["z"].Value);

            int r = Int32.Parse(node.Attributes["r"].Value);
            int g = Int32.Parse(node.Attributes["g"].Value);
            int b = Int32.Parse(node.Attributes["b"].Value);
            
            Initalize(x, y, z, Color.FromArgb(r,g,b));
        }
    }
}
