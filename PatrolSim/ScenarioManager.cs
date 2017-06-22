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

        private void Initalize()
        {
            _agentList = new List<Agent>();
            _obList = new List<Obstcle>();
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
        
    }
}
