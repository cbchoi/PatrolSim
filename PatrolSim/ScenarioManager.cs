using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using AISWrapper;
using ShipClassifierWrapper;

namespace PatrolSim
{
    class ScenarioManager
    {
        private Dictionary<int, AIS_MSG_1> _aisList = new Dictionary<int, AIS_MSG_1>();
        public Dictionary<int, AIS_MSG_1> AIS_MSG1MAP
        {
            get { return _aisList; }
        }

        private RouteClassifier _rc;
        public RouteClassifier RouteManager
        {
            get { return _rc; }
        }

        private List<Agent> _agentList;
        public List<Agent> AgentList
        {
            get { return _agentList; }
        }

        public List<Obstcle> _obList;
        public List<Obstcle> ObstcleList
        {
            get { return _obList; }
        }

        public Dictionary<int, Color> _colorList;
        public Dictionary<int, Color> ColorList
        {
            get { return _colorList; }
        }

        public int MapSizeX { get; }
        public int MapSizeY { get; }

        private void Initalize()
        {
            _agentList = new List<Agent>();
            _obList = new List<Obstcle>();
            _colorList = new Dictionary<int, Color>();
        }

        public ScenarioManager(string xmlFilePath)
        {
            Initalize();

            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(xmlFilePath);
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message + " Xml Load Error: There is no file that you want to load.");
            }

            XmlNode rootNode = xmlDoc.SelectSingleNode("ObjectList");
            MapSizeX = Int32.Parse(rootNode.Attributes["MapSizeX"].Value);
            MapSizeY = Int32.Parse(rootNode.Attributes["MapSizeY"].Value);

            HandleShips(rootNode.SelectSingleNode("ShipList"));
            HandleObscles(rootNode.SelectSingleNode("ObstcleList"));
            HandleColors(rootNode.SelectSingleNode("ColorList"));

            // TODO
            //Initalize RouteClassifier
            _rc = new RouteClassifier(xmlFilePath);
        }

        public void HandleShips(XmlNode node)
        {
            foreach (XmlNode ship in node.ChildNodes)
            {
                Agent agent = new Agent(ship);
                _agentList.Add(agent);
                _aisList.Add(agent.AgentID, new AIS_MSG_1());
            }
        }

        public void HandleObscles(XmlNode node)
        {
            foreach (XmlNode obstcle in node.ChildNodes)
            {
                _obList.Add(new Obstcle(obstcle));
            }
        }

        public void HandleColors(XmlNode node)
        {
            foreach (XmlNode color in node.ChildNodes)
            {
                int id = Int32.Parse(color.Attributes["id"].Value);
                int r = Int32.Parse(color.Attributes["r"].Value);
                int g = Int32.Parse(color.Attributes["g"].Value);
                int b = Int32.Parse(color.Attributes["b"].Value);

                _colorList[id] = Color.FromArgb(r, g, b);
            }
        }

    }
}
