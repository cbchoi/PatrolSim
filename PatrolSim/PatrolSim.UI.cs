using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private void backWorker_RunWorkerCompleted(
            object sender,
            RunWorkerCompletedEventArgs e)
        {
            lock (thisLock)
            {
                UpdateUiComponent(chartRealWorld, matrixRealWorld);
                DrawBox(_realMap, matrixRealWorld);
            }

            chartRealWorld.Refresh();
            _realMap.Refresh();
        }

        private void backWorker_log_DoWork(object sender, DoWorkEventArgs e)
        {
            

            e.Result = e.Argument;
        }

        private void backWorker_log_RunWorkerCompleted(
            object sender,
            RunWorkerCompletedEventArgs e)
        {
            lock (log_lock)
            {
                List<Agent> agent_list = (List<Agent>)(e.Result);

                foreach (Agent agent in agent_list)
                {
                    
                    agent.AIS_MSG1.message_id(1);
                    agent.AIS_MSG1.repeat_indicator(0);
                    agent.AIS_MSG1.mmsi(agent.AgentMMSI);
                    agent.AIS_MSG1.nav_status(0);
                    agent.AIS_MSG1.rot_raw(0);
                    agent.AIS_MSG1.sog(0);
                    agent.AIS_MSG1.position_accuracy(1);

                    double lng = 128.4552 + (agent.CurrentPosition.Y * (0.0460 / 100.0));
                    agent.AIS_MSG1.pos_long(lng);

                    double lat = 34.8035 + (agent.CurrentPosition.X * (0.0313 / 100.0));
                    agent.AIS_MSG1.pos_lat(lat);

                    agent.AIS_MSG1.cog(219);
                    agent.AIS_MSG1.true_heading(13);

                    agent.AIS_MSG1.timestamp(agent.Timestamp);
                    agent.AIS_MSG1.special_manoeuvre(0);
                    agent.AIS_MSG1.spare(0);
                    agent.AIS_MSG1.raim(0);
                    agent.AIS_MSG1.sync_state(0);
                    agent.AIS_MSG1.slot_timeout(agent.get_random_value(0, 5));
                    agent.AIS_MSG1.received_stations(agent.get_random_value(70, 75));

                    string value = agent.AIS_MSG1.get_encoded_msg();

                    simLog.Items.Add(value);
                    simLog.SelectedIndex = simLog.Items.Count - 1;

                    //AIS_MSG_1 msg = new AIS_MSG_1(value);
                    string str = String.Format("MMSI:{0} Latitude:{1} Longitude:{2}", agent.AgentMMSI, lat, lng);
                    realLog.Items.Add(str);
                    realLog.SelectedIndex = realLog.Items.Count - 1;
                }

                agent_list.Clear();
            }

        }

        private static void UpdateUiComponent(NChartControl nChartControl, double[][] matrix)
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

        public static void UpdateSimulation()
        {
            lock (thisLock)
            {
                foreach (Agent agent in _scenarioManager.AgentList)
                {
                    UpdateMatrix(agent, matrixSimulation);
                    
                    UpdateMatrix(agent, matrixRealWorld);
                }
            }
        }

        private static void UpdateMatrix(Agent agent, double[][] matrix)
        {
            matrix[(int)(agent.CurrentPosition.Y *_gridSizeY/ _scenarioManager.MapSizeY)][(int)(agent.CurrentPosition.X * _gridSizeX / _scenarioManager.MapSizeX)] = agent.AgentID;

            lock (log_lock)
            {
                agent_list.Add(agent);
            }

            if (!backWorker_log.IsBusy)
            {
                backWorker_log.RunWorkerAsync(agent_list);
            }
        }
    }
}
