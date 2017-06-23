using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

namespace PatrolSim
{
    public class Agent
    {
        private readonly int _agentID;
        private readonly double _agentSpeed;
        private readonly int _agentType;

        private readonly ArrayList _wayList;
        private int _curWayIndex; // Indicate Current Waypoints

        public int AgentID { get { return _agentID; } }
        public double AgentSpeed { get { return _agentSpeed; } }
        public int AgentType { get { return _agentType; } }
        public int CurrentWayointIndex { get { return _curWayIndex; } }

        delegate void UpdateMap();

        private UpdateMap _sim;
        public Agent(int id, double spd, int type)
        {
            _agentID = id;
            _agentSpeed = spd;
            _agentType = type;

            _curWayIndex = 0;
            _wayList = new ArrayList();
            _sim += PatrolSim.UpdateSimulation;
        }

        public Agent(XmlNode node)
        {
            _agentID = Int32.Parse(node.Attributes["id"].Value);
            _agentSpeed = Double.Parse(node.Attributes["spd"].Value);
            _agentType = Int32.Parse(node.Attributes["type"].Value);

            _curWayIndex = 0;
            _wayList = new ArrayList();

            XmlNode waypoints = node.SelectSingleNode("Waypoints");
            foreach (XmlNode way in waypoints.ChildNodes)
            {
                AddWaypoint(way);
            }
            _sim += PatrolSim.UpdateSimulation;
        }

        public Waypoint GetCurrentWaypoint()
        {
            return (Waypoint)_wayList[_curWayIndex];
        }

        public Waypoint GetNextWaypoint()
        {
            _curWayIndex++;
            return (Waypoint) _wayList[_curWayIndex];
        }

        public void AddWaypoint(int x, int y, int z)
        {
            _wayList.Add(new Waypoint(x, y, z));
        }

        public void AddWaypoint(XmlNode node)
        {
            int x = Int32.Parse(node.Attributes["x"].Value);
            int y = Int32.Parse(node.Attributes["y"].Value);
            int z = Int32.Parse(node.Attributes["z"].Value);

            AddWaypoint(x, y, z);
        }

        public Tuple<int, Waypoint> Move(float time)
        {
            _sim();
            return new Tuple<int, Waypoint>(0, new Waypoint(0,0,0));
        }
    }
}