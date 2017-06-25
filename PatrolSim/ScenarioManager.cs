using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PatrolSim
{
    class ScenarioManager
    {
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

            HandleShips(rootNode.SelectSingleNode("ShipList"));
            HandleObscles(rootNode.SelectSingleNode("ObstcleList"));
            HandleColors(rootNode.SelectSingleNode("ColorList"));
        }

        public void HandleShips(XmlNode node)
        {
            foreach (XmlNode ship in node.ChildNodes)
            {
                _agentList.Add(new Agent(ship));
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
