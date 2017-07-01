using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PatrolSim
{
    class Configuration
    {
        private int _cellSizeX;
        private int _cellSizeY;

        public int CellSizeX { get { return _cellSizeX; } }
        public int CellSizeY { get { return _cellSizeY; } }

        private int _boxSizeX;
        private int _boxSizeY;

        public int BoxSizeX { get { return _boxSizeX; } }
        public int BoxSizeY { get { return _boxSizeY; } }

        private int _radarFrequency;
        public int RadarDetectFrequency { get { return _radarFrequency; } }

        public Configuration(string path)
        {
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(path);
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message + " Xml Load Error: There is no file that you want to load.");
            }

            XmlNode rootNode = xmlDoc.SelectSingleNode("Configuration");
            
            ProcessCellSize(rootNode.SelectSingleNode("CellSize"));
            ProcessBoxSize(rootNode.SelectSingleNode("BoxSize"));
            ProcessRadarFrequency(rootNode.SelectSingleNode("RadarFrequency"));
        }

        private void ProcessCellSize(XmlNode node)
        {
            if (node != null)
            {
                _cellSizeX = Int32.Parse(node.Attributes["CellSizeX"].Value);
                _cellSizeY = Int32.Parse(node.Attributes["CellSizeY"].Value);
            }
            
        }

        private void ProcessBoxSize(XmlNode node)
        {
            if (node != null)
            {
                _boxSizeX = Int32.Parse(node.Attributes["BoxSizeX"].Value);
                _boxSizeY = Int32.Parse(node.Attributes["BoxSizeY"].Value);
            }
            
        }

        private void ProcessRadarFrequency(XmlNode node)
        {
            if (node != null)
            {
                _radarFrequency = Int32.Parse(node.Attributes["Frequency"].Value);
            }
        }
    }
}
