using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Nevron.Chart;
using Nevron.Chart.WinForm;
using Nevron.GraphicsCore;
using AISWrapper;

namespace PatrolSim
{
    partial class PatrolSim
    {
        public enum AgentType { NormalShip = 10, SimulationModel = 0, Unregistered = 5, }

        private void backWorker_RunWorkerCompleted(
            object sender,
            RunWorkerCompletedEventArgs e)
        {
            lock (thisLock)
            {
                UpdateChartComponent(chartRealWorld, matrixRealWorld);
            }

            chartRealWorld.Refresh();
            _simulateMap.Refresh();
        }

        private void backWorker_RadarRunWorkerCompleted(
            object sender,
            RunWorkerCompletedEventArgs e)
        {
            foreach (Agent agent in _scenarioManager.AgentList)
            {
                string str = String.Format("Object ID:{0} Latitude:{1} Longitude:{2}", agent.AgentID,
                    agent.GetLatitude(_gridSizeX), agent.GetLongitude(_gridSizeY));
                _radarInfoBox.Items.Add(str);
                _radarInfoBox.SelectedIndex = _radarInfoBox.Items.Count - 1;
            }

            _realMap.Refresh();
            _exclusiveMap.Refresh();

            int agent_count = 0;

            for (int i = 0; i < _gridSizeY; i++)
            {
                for (int j = 0; j < _gridSizeX; j++)
                {
                    agent_count = 0;
                    foreach (Agent agent in matrixSimAgents[i][j].Values)
                    {
                        if (agent.AgentType == (int)AgentType.SimulationModel)
                            agent_count++;
                    }

                    if (agent_count != 0 && agent_count == matrixRealAgents[i][j].Keys.Count)
                    {
                        if (matrixRealAgents[i][j].Values.Count != 0)
                        {
                            string str = String.Format("Estimation Success - Object ID:{0} Latitude:{1} Longitude:{2}",
                                matrixRealAgents[i][j].Values.ElementAt(0).AgentID,
                                matrixRealAgents[i][j].Values.ElementAt(0).GetLatitude(_gridSizeX),
                                matrixRealAgents[i][j].Values.ElementAt(0).GetLongitude(_gridSizeY));
                            _filteredInfoBox.Items.Add(str);
                            _filteredInfoBox.SelectedIndex = _filteredInfoBox.Items.Count - 1;
                        }
                    }
                    else if (agent_count != 0 && agent_count != matrixRealAgents[i][j].Keys.Count)
                    {
                        if (matrixRealAgents[i][j].Values.Count != 0)
                        {
                            string str = String.Format("Estimation Failed - Object ID:{0} Latitude:{1} Longitude:{2}", matrixRealAgents[i][j].Values.ElementAt(0).AgentID,
                                matrixRealAgents[i][j].Values.ElementAt(0).GetLatitude(_gridSizeX), matrixRealAgents[i][j].Values.ElementAt(0).GetLongitude(_gridSizeY));
                            _filteredInfoBox.Items.Add(str);
                            _filteredInfoBox.SelectedIndex = _filteredInfoBox.Items.Count - 1;
                        }
                    }
                    else if ((matrixSimAgents[i][j].Keys.Count - agent_count) != matrixRealAgents[i][j].Keys.Count)
                    {
                        if (matrixRealAgents[i][j].Values.Count != 0)
                        {
                            string str = String.Format("Abnormal Ship Detected - Object ID:{0} Latitude:{1} Longitude:{2}", matrixRealAgents[i][j].Values.ElementAt(0).AgentID,
                                matrixRealAgents[i][j].Values.ElementAt(0).GetLatitude(_gridSizeX), matrixRealAgents[i][j].Values.ElementAt(0).GetLongitude(_gridSizeY));
                            _filteredInfoBox.Items.Add(str);
                            _filteredInfoBox.SelectedIndex = _filteredInfoBox.Items.Count - 1;
                        }
                    }

                }
            }
        }

        private void backWorker_log_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = e.Argument;
        }

        private void backWorker_log_RunWorkerCompleted(
            object sender,
            RunWorkerCompletedEventArgs e)
        {
            lock (remove_lock)
            {
                lock (log_lock)
                {
                    List<Agent> agent_list = (List<Agent>)(e.Result);


                    foreach (Agent agent in agent_list)
                    {
                        if (!_simManager.AbnormalEvent && _scenarioManager.AIS_MSG1MAP.ContainsKey(agent.AgentID))
                        {
                            _scenarioManager.AIS_MSG1MAP[agent.AgentID].message_id(1);
                            _scenarioManager.AIS_MSG1MAP[agent.AgentID].repeat_indicator(0);
                            _scenarioManager.AIS_MSG1MAP[agent.AgentID].mmsi(agent.AgentMMSI);
                            _scenarioManager.AIS_MSG1MAP[agent.AgentID].nav_status(0);
                            _scenarioManager.AIS_MSG1MAP[agent.AgentID].rot_raw(0);
                            _scenarioManager.AIS_MSG1MAP[agent.AgentID].sog(0);
                            _scenarioManager.AIS_MSG1MAP[agent.AgentID].position_accuracy(1);
                            _scenarioManager.AIS_MSG1MAP[agent.AgentID].pos_long(agent.GetLongitude(_gridSizeY));
                            _scenarioManager.AIS_MSG1MAP[agent.AgentID].pos_lat(agent.GetLatitude(_gridSizeX));
                            _scenarioManager.AIS_MSG1MAP[agent.AgentID].cog(219);
                            _scenarioManager.AIS_MSG1MAP[agent.AgentID].true_heading(13);
                            _scenarioManager.AIS_MSG1MAP[agent.AgentID].timestamp(agent.Timestamp);
                            _scenarioManager.AIS_MSG1MAP[agent.AgentID].special_manoeuvre(0);
                            _scenarioManager.AIS_MSG1MAP[agent.AgentID].spare(0);
                            _scenarioManager.AIS_MSG1MAP[agent.AgentID].raim(0);
                            _scenarioManager.AIS_MSG1MAP[agent.AgentID].sync_state(0);
                            _scenarioManager.AIS_MSG1MAP[agent.AgentID].slot_timeout(agent.get_random_value(0, 5));
                            _scenarioManager.AIS_MSG1MAP[agent.AgentID].received_stations(agent.get_random_value(70, 75));

                            // If Simulation is in Abnormal Status, don't update the textbox
                            string value = _scenarioManager.AIS_MSG1MAP[agent.AgentID].get_encoded_msg();
                            simLog.Items.Add(value);
                            simLog.SelectedIndex = simLog.Items.Count - 1;

                            string str = String.Format("MMSI:{0} Latitude:{1} Longitude:{2}", agent.AgentMMSI,
                                agent.GetLatitude(_gridSizeX), agent.GetLongitude(_gridSizeY));
                            realLog.Items.Add(str);
                            realLog.SelectedIndex = realLog.Items.Count - 1;
                        }
                        else
                        {
                            if (agent.AgentType == (int)AgentType.SimulationModel)
                            {
                                string str = String.Format("MMSI:{0} Latitude:{1} Longitude:{2}", agent.AgentMMSI,
                                    agent.GetLatitude(_gridSizeX), agent.GetLongitude(_gridSizeY));
                                _simulationInfoBox.Items.Add(str);
                                _simulationInfoBox.SelectedIndex = _simulationInfoBox.Items.Count - 1;
                            }
                        }
                    }
                    agent_list.Clear();
                }
            }

        }

        private static void UpdateChartComponent(NChartControl nChartControl, double[][] matrix)
        {
            NCartesianChart chart = (NCartesianChart)nChartControl.Charts[0];
            for (int i = 0; i < _gridSizeY; i++)
            {
                NBarSeries bar = chart.Series[i] as NBarSeries;
                double[] barValues = matrix[i];
                int barValueCount = barValues.Length;

                if (bar.Values.Count == 0)
                {
                    bar.Values.AddRange(barValues);
                }
                else
                {
                    bar.Values.SetRange(0, barValues);
                }

                int fillStyleCount = bar.FillStyles.Count;

                for (int j = 0; j < barValueCount; j++)
                {
                    if (j >= fillStyleCount)
                    {
                        bar.FillStyles[j] = new NColorFillStyle(_scenarioManager.ColorList[(int)barValues[j]]);
                    }
                    else
                    {
                        ((NColorFillStyle)bar.FillStyles[j]).Color = _scenarioManager.ColorList[(int)barValues[j]];
                    }
                }
            }
            nChartControl.Refresh();
        }

        public void UpdateSimulationMap()
        {
            while (_threadState == ThreadState.Run || _threadState == ThreadState.Pause)
            {
                if (_threadState == ThreadState.Run)
                {
                    if(!backWorker_map.IsBusy)
                        backWorker_map.RunWorkerAsync();
                }
                Thread.Sleep(1000);
            }
        }

        public void UpdateRadarMap()
        {
            while (_threadState == ThreadState.Run || _threadState == ThreadState.Pause)
            {
                if (_threadState == ThreadState.Run)
                {
                    if (!backWorker_map.IsBusy)
                        backWorker_radar.RunWorkerAsync();
                }
                Thread.Sleep(2000);
            }
        }

        public static void UpdateSimulation()
        {
            lock (thisLock)
            {
                foreach (Agent agent in _scenarioManager.AgentList)
                {
                    if (agent.AgentType == (int) AgentType.NormalShip)
                    {
                        UpdateMatrix(agent, matrixRealWorld, matrixRealAgents);
                        UpdateMatrix(agent, matrixSimulation, matrixSimAgents);
                    }
                    else if (agent.AgentType == (int)AgentType.Unregistered)
                    {
                        UpdateMatrix(agent, matrixRealWorld, matrixRealAgents);
                    }
                    else if (agent.AgentType == (int) AgentType.SimulationModel)
                    {
                        UpdateMatrix(agent, matrixSimulation, matrixSimAgents);
                    }
                }
            }
        }

        //private static void UpdateMatrix(Agent agent, double[][] matrix)
        //{
        //    matrix[(int)(agent.CurrentPosition.Y *_gridSizeY/ _scenarioManager.MapSizeY)][(int)(agent.CurrentPosition.X * _gridSizeX / _scenarioManager.MapSizeX)] = agent.AgentID;

        //    lock (log_lock)
        //    {
        //        agent_list.Add(agent);
        //    }

        //    if (!backWorker_log.IsBusy)
        //    {
        //        backWorker_log.RunWorkerAsync(agent_list);
        //    }
        //}

        private static void UpdateMatrix(Agent agent, double[][] matrix_chart, Dictionary<int, Agent>[][] matrix)
        {
            int normalizedX = (int)(agent.CurrentPosition.X * _gridSizeX / _scenarioManager.MapSizeX);
            int normalizedY = (int)(agent.CurrentPosition.Y * _gridSizeY / _scenarioManager.MapSizeY);

            if (normalizedY < _gridSizeY && normalizedX < _gridSizeX && normalizedY >= 0 && normalizedX >= 0)
            {
                matrix_chart[normalizedY][normalizedX] = agent.AgentID;

                if (normalizedY == (int)(agent.PrevPosition.Y * _gridSizeY / _scenarioManager.MapSizeY)
                    && normalizedX == (int)(agent.PrevPosition.X * _gridSizeX / _scenarioManager.MapSizeX))
                {
                    if (!matrix[normalizedY][normalizedX].ContainsKey(agent.AgentID))
                        matrix[normalizedY][normalizedX].Add(agent.AgentID, agent);
                }
                else
                {
                    int normalizedPrevX = (int)(agent.PrevPosition.X * _gridSizeX / _scenarioManager.MapSizeX);
                    int normalizedPrevY = (int)(agent.PrevPosition.Y * _gridSizeY / _scenarioManager.MapSizeY);

                    if (normalizedPrevY < _gridSizeY && normalizedPrevX < _gridSizeX && normalizedPrevY >= 0 && normalizedPrevX >= 0)
                    {
                        matrix[(int)(agent.PrevPosition.Y * _gridSizeY / _scenarioManager.MapSizeY)][(int)(agent.PrevPosition.X * _gridSizeX / _scenarioManager.MapSizeX)].Remove(agent.AgentID);
                        matrix[normalizedY][normalizedX].Add(agent.AgentID, agent);
                    }
                    
                }


                lock (log_lock)
                {
                    agent_list.Add(agent);
                }

                if (!backWorker_log.IsBusy)
                {
                    backWorker_log.RunWorkerAsync(agent_list);
                }
            }
            else
            {
                matrix[(int)(agent.PrevPosition.Y * _gridSizeY / _scenarioManager.MapSizeY)][(int)(agent.PrevPosition.X * _gridSizeX / _scenarioManager.MapSizeX)].Remove(agent.AgentID);
            }

        }
    }
}
