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
        private readonly int _agentMMSI;

        private Position _curPosition;
        private Position _prevPosition;

        private readonly ArrayList _wayList;
        private int _curWayIndex; // Indicate Current Waypoints

        private Position _currentPosition;
        private int _timestamp = 0;

        public int Timestamp
        {
            get
            {
                Random rnd = new Random();
                _timestamp += rnd.Next(15);
                if (_timestamp > 60)
                    _timestamp -= 60;

                return _timestamp;
            }
        }

        public int get_random_value(int min, int max)
        {
            Random rnd = new Random();
            return rnd.Next(min, max);
        }

        public int AgentID { get { return _agentID; } }
        public double AgentSpeed { get { return _agentSpeed; } }
        public int AgentType { get { return _agentType; } }
        public int AgentMMSI { get { return _agentMMSI; } }

        public int CurrentWayointIndex { get { return _curWayIndex; } }

        public Position PrevPosition { get { return _prevPosition; } }
        public Position CurrentPosition { get { return _currentPosition; }}

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
            
            // Current Position Setting
            _currentPosition = new Position(((Position)_wayList[CurrentWayointIndex]).X, ((Position)_wayList[CurrentWayointIndex]).Y) ;
            _prevPosition = new Position(((Position)_wayList[CurrentWayointIndex]).X, ((Position)_wayList[CurrentWayointIndex]).Y);
        }

        public Agent(XmlNode node)
        {
            _agentID = Int32.Parse(node.Attributes["id"].Value);
            _agentSpeed = Double.Parse(node.Attributes["spd"].Value);
            _agentType = Int32.Parse(node.Attributes["type"].Value);
            _agentMMSI = Int32.Parse(node.Attributes["mmsi"].Value);

            _curWayIndex = 0;
            _wayList = new ArrayList();

            XmlNode waypoints = node.SelectSingleNode("Waypoints");
            foreach (XmlNode way in waypoints.ChildNodes)
            {
                AddWaypoint(way);
            }
            
            // Update Logic 
            _sim += PatrolSim.UpdateSimulation;

            // Current Position Setting
            _currentPosition = (Position)_wayList[CurrentWayointIndex];
            _prevPosition = (Position)_wayList[CurrentWayointIndex];
        }

        public Position GetCurrentWaypoint()
        {
            return (Position)_wayList[_curWayIndex];
        }

        public Position GetNextWaypoint()
        {
            if(_curWayIndex+1 < _wayList.Count)
                return (Position) _wayList[_curWayIndex+1];
            else
            {
                return (Position) _wayList[_curWayIndex];
            }
        }

        public void IncreaseWaypoint()
        {
            if (_curWayIndex+1 < _wayList.Count)
                _curWayIndex++;
        }

        public void AddWaypoint(int x, int y, int z)
        {
            _wayList.Add(new Position(x, y));
        }

        public void AddWaypoint(XmlNode node)
        {
            int x = Int32.Parse(node.Attributes["x"].Value);
            int y = ((Int32.Parse(node.Attributes["y"].Value)));
            int z = Int32.Parse(node.Attributes["z"].Value);

            AddWaypoint(x, y, z);
        }

        double CalculateDistance(Position currentPosition, Position targetPosition)
        {
            double distance = Math.Sqrt(Math.Pow(targetPosition.X - _currentPosition.X, 2) + Math.Pow(targetPosition.Y - _currentPosition.Y, 2));

            return distance;
        }

        bool CheckPointReached()
        {
            if (_wayList.Count > _curWayIndex)
            {
                Position targetPosition = GetCurrentWaypoint();
                if (CalculateDistance(_currentPosition, targetPosition) < 1)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public Tuple<int, Position> Move(double time)
        {
            if (_wayList.Count > _curWayIndex)
            {
                Position targetPosition;
                if (CheckPointReached())
                {
                    _prevPosition.X = GetCurrentWaypoint().X;
                    _prevPosition.Y = GetCurrentWaypoint().Y;
                    IncreaseWaypoint();
                }
                
                targetPosition = GetCurrentWaypoint();

                // X Move : total distance
                if((targetPosition.X - _currentPosition.X) < 0)
                    _currentPosition.X -= AgentSpeed * time;
                else
                    _currentPosition.X += AgentSpeed * time;
                // Y Move
                if ((targetPosition.Y - _currentPosition.Y) < 0)
                    _currentPosition.Y -= AgentSpeed * time;
                else
                    _currentPosition.Y += AgentSpeed * time;
            }
            _sim();
            return new Tuple<int, Position>(0, new Position(0,0));
        }
    }
}