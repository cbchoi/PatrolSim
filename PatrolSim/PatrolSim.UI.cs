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
                //UpdateUiComponent(chartSimulation, matrixSimulation);
                UpdateUiComponent(chartRealWorld, matrixRealWorld);
            }

            chartRealWorld.Refresh();
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
                    AIS_MSG_1 asg = new AIS_MSG_1();
                    asg.message_id(1);
                    asg.repeat_indicator(0);
                    asg.mmsi(agent.AgentMMSI);
                    asg.nav_status(0);
                    asg.rot_raw(0);
                    asg.sog(0);
                    asg.position_accuracy(1);

                    double lng = 128.3731 + (agent.CurrentPosition.Y * (0.0147 / 50.0));
                    asg.pos_long(lng);

                    double lat = 34.7824 + (agent.CurrentPosition.X * (0.0113 / 50.0));
                    asg.pos_lat(lat);

                    asg.cog(219);
                    asg.true_heading(13);

                    asg.timestamp(agent.Timestamp);
                    asg.special_manoeuvre(0);
                    asg.spare(0);
                    asg.raim(0);
                    asg.sync_state(0);
                    asg.slot_timeout(agent.get_random_value(0, 5));
                    asg.received_stations(agent.get_random_value(70, 75));
                    string value = asg.get_encoded_msg();

                    simLog.Items.Add(value);
                    simLog.SelectedIndex = simLog.Items.Count - 1;

                    AIS_MSG_1 msg = new AIS_MSG_1(value);
                    string str = String.Format("MMSI:{0} Latitude:{1} Longitude:{2}", msg.mmsi(), msg.pos_lat(), msg.pos_long());
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
    }
}
