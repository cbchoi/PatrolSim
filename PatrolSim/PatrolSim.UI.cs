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
            string value = (string)e.Result;
            simLog.Items.Add(value);
            simLog.SelectedIndex = simLog.Items.Count - 1;

            AIS_MSG_1 msg = new AIS_MSG_1(value);
            string str = String.Format("MMSI:{0} Latitude:{1} Longitude:{2}", msg.mmsi(), msg.pos_lat(), msg.pos_long());
            realLog.Items.Add(str);
            realLog.SelectedIndex = realLog.Items.Count - 1;
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
