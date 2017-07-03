using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using AISWrapper;
using ShipClassifierWrapper;

namespace PatrolSim
{
    [Serializable]
    public class Agent
    {
        private int _agentID;
        private readonly double _agentSpeed;
        private int _agentType;
        private readonly int _agentMMSI;

        private Position _prevPosition;

        private readonly ArrayList _wayList;
        private int _curWayIndex; // Indicate Current Waypoints

        private Position _currentPosition;
        private Position _crashedPosition;
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
        public ArrayList WaypointList { get { return _wayList; } }
        public Position PrevPosition { get { return _prevPosition; } }

        public Position SimulationPosition
        {
            get
            {
                return _currentPosition; // AIS Data
            }
        }

        public Position CurrentPosition
        {
            get
            {
                return _currentPosition; // AIS Data                
            }
        }

        public Position CrashedPosition { get { return _crashedPosition; } }

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
            Position initalWaypoint = (Position) _wayList[CurrentWayointIndex];

            _currentPosition = new Position(initalWaypoint.X, initalWaypoint.Y);
            _prevPosition = new Position(initalWaypoint.X, initalWaypoint.Y);
            _crashedPosition = null;
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

        public void AddWaypoint(double x, double y, double z)
        {
            _wayList.Add(new Position(x, y));
        }

        public void AddWaypoint(XmlNode node)
        {
            double x = Double.Parse(node.Attributes["x"].Value);
            double y = ((Double.Parse(node.Attributes["y"].Value)));
            double z = Double.Parse(node.Attributes["z"].Value);

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

        public void Move(double time)
        {
            if (_wayList.Count > _curWayIndex)
            {
                Position targetPosition;
                if (CheckPointReached())
                {
                    //_prevPosition.X = GetCurrentWaypoint().X;
                    //_prevPosition.Y = GetCurrentWaypoint().Y;
                    IncreaseWaypoint();
                }

                targetPosition = GetCurrentWaypoint();

                _prevPosition.X = _currentPosition.X;
                _prevPosition.Y = _currentPosition.Y;

                // X Move : total distance
                if ((targetPosition.X - _currentPosition.X) < 0)
                    _currentPosition.X -= AgentSpeed * time;
                else
                    _currentPosition.X += AgentSpeed * time;
                // Y Move
                if ((targetPosition.Y - _currentPosition.Y) < 0)
                    _currentPosition.Y -= AgentSpeed * time;
                else
                    _currentPosition.Y += AgentSpeed * time;
            }

        }

        private bool _abnormalEvent = false;

        public bool AbnormalEvent
        {
            get { return _abnormalEvent; }
        }

        public void EstimatedMove(double time, RouteClassifier rc)
        {

            Position targetPosition;
            string next_data = rc.GetNextPoint(AgentID);
            if (next_data != "no matching")
            {
                char[] delimiter = {','};
                string [] token = next_data.Split(delimiter);
                targetPosition = new Position(Double.Parse(token[0]), Double.Parse(token[1]));
            }
            else
            {
                targetPosition = new Position(_currentPosition.X, _currentPosition.Y);
            }
            _prevPosition.X = _currentPosition.X;
            _prevPosition.Y = _currentPosition.Y;

            // X Move : total distance
            if ((targetPosition.X - _currentPosition.X) < 0)
                _currentPosition.X -= AgentSpeed * time;
            else
                _currentPosition.X += AgentSpeed * time;
            // Y Move
            if ((targetPosition.Y - _currentPosition.Y) < 0)
                _currentPosition.Y -= AgentSpeed * time;
            else
                _currentPosition.Y += AgentSpeed * time;

            rc.SetNextWaypoint(AgentID, (int)_currentPosition.X, (int)_currentPosition.Y);
        }

        public void Move(double time, bool abnormalEvent, RouteClassifier rc)
        {
            if (abnormalEvent)
            {
                if (!_abnormalEvent)
                {
                    _abnormalEvent = true;
                    _crashedPosition = new Position(_currentPosition.X, _currentPosition.Y); ;
                }

                // TODO
                if (_agentType == 0)
                {
                    EstimatedMove(time, rc);
                }
                else
                {
                    Move(time); // Real Agent    
                }
                
                //Move(time); // Simulated Agent
            }
            else
            {
                _abnormalEvent = false;
                _crashedPosition = null;
                Move(time);
            }
        }

        public double GetLatitude(double MapSizeX)
        {
            double lat = 34.8035 + (CurrentPosition.X * (0.0313 / MapSizeX));
            return lat;
        }

        public double GetLongitude(double MapSizeY)
        {
            double lng = 128.4552 + (CurrentPosition.Y * (0.0460 / MapSizeY));
            return lng;
        }

        public Agent SimModelClone()
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();

            bf.Serialize(ms, this);

            ms.Position = 0;
            object obj = bf.Deserialize(ms);
            ms.Close();

            Agent thisObject = obj as Agent;
            thisObject._agentType = (int) PatrolSim.AgentType.SimulationModel;
            thisObject._agentID += 100;
            return thisObject;
        }
    }
}