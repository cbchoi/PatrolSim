using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nevron.Chart;
using Nevron.Chart.WinForm;
using Nevron.Dom;
using Nevron.GraphicsCore;

namespace PatrolSim
{
    public partial class PatrolSim : Form
    {
        private static int _gridSizeX = 100;
        private static int _gridSizeY = 100;
        private static Color[] _colorTable;

        private static double[][] matrixSimulation;
        private static double[][] matrixRealWorld;

        private static ScenarioManager _scenarioManager;
        private static SimulationManager _simManager;

        enum ThreadState{ Run, Pause, Stop,}

        private ThreadState _threadState = ThreadState.Stop;
        private Thread _worker;

        private BackgroundWorker backWorker;

        private void backWorker_RunWorkerCompleted(
            object sender,
            RunWorkerCompletedEventArgs e)
        {
            TestUIComponent(chartSimulation, matrixSimulation);
            TestUIComponent(chartRealWorld, matrixRealWorld);
            chartSimulation.Refresh();
        }

        public void UpdateSimulationMap()
        {
            while (_threadState == ThreadState.Run || _threadState == ThreadState.Pause)
            {
                if (_threadState == ThreadState.Run)
                {
                    backWorker.RunWorkerAsync();
                }
                Thread.Sleep(1000);
            }
        }

        public static void UpdateSimulation()
        {
            foreach (Agent agent in _scenarioManager.AgentList)
            {
                UpdateMatrixThreadTest(matrixSimulation);
                UpdateMatrixThreadTest(matrixRealWorld);
            }
        }

        public PatrolSim()
        {
            InitializeComponent();

            _colorTable = new Color[21];

            for (int i = 0; i <= 20; i++)
            {
                _colorTable[i] = InterpolateColors(Color.AliceBlue, Color.Red, i / 20.0F);
            }

            InitMap(chartSimulation);
            InitMap(chartRealWorld);

            matrixRealWorld = new double[_gridSizeY][];
            matrixSimulation = new double[_gridSizeX][];

            for (int i = 0; i < _gridSizeY; i++)
            {
                matrixRealWorld[i] = new double[_gridSizeX];
                matrixSimulation[i] = new double[_gridSizeX];
            }

            _simManager = new SimulationManager();
            _worker = new Thread(UpdateSimulationMap);

            backWorker = new BackgroundWorker();
            this.backWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backWorker_RunWorkerCompleted);
        }

        public static Color InterpolateColors(Color color1, Color color2, float factor)
        {
            int num1 = ((int)color1.R);
            int num2 = ((int)color1.G);
            int num3 = ((int)color1.B);

            int num4 = ((int)color2.R);
            int num5 = ((int)color2.G);
            int num6 = ((int)color2.B);

            byte num7 = (byte)((((float)num1) + (((float)(num4 - num1)) * factor)));
            byte num8 = (byte)((((float)num2) + (((float)(num5 - num2)) * factor)));
            byte num9 = (byte)((((float)num3) + (((float)(num6 - num3)) * factor)));

            return Color.FromArgb(num7, num8, num9);
        }

        private void InitMap(NChartControl nChartControl)
        {
            // configure the chart
            NCartesianChart chart = (NCartesianChart)nChartControl.Charts[0];
            chart.Projection.SetPredefinedProjection(PredefinedProjection.OrthogonalTop);
            chart.BoundsMode = BoundsMode.Fit;
            chart.Enable3D = true;
            chart.Fit3DAxisContent = false;

            // No Legend & No Update
            nChartControl.Legends.Clear();
            nChartControl.ServiceManager.LegendUpdateService.UpdateAutoLegends();
            nChartControl.ServiceManager.LegendUpdateService.Stop();

            chart.Width = _gridSizeX;
            chart.Height = 20;
            chart.Depth = _gridSizeY;

            // Wall Setup
            NChartWall backWall = chart.Wall(ChartWallType.Back);
            backWall.Visible = false;

            NChartWall leftWall = chart.Wall(ChartWallType.Left);
            leftWall.Visible = false;

            // setup axes
            NOrdinalScaleConfigurator ordinalScale = (NOrdinalScaleConfigurator)chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;
            ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
            ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
            ordinalScale.DisplayDataPointsBetweenTicks = false;

            ordinalScale = (NOrdinalScaleConfigurator)chart.Axis(StandardAxis.Depth).ScaleConfigurator;
            ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
            ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, true);
            ordinalScale.DisplayDataPointsBetweenTicks = false;

            chart.Axis(StandardAxis.SecondaryY).Anchor = new NDockAxisAnchor(AxisDockZone.FrontLeft, false, 100.0f, 100.0f);
            chart.Axis(StandardAxis.SecondaryY).Visible = false;

            for (int i = 0; i < _gridSizeY; i++)
            {
                // add the first line
                NBarSeries bar = new NBarSeries();
                chart.Series.Add(bar);

                bar.WidthPercent = 100.0f;
                bar.DepthPercent = 100.0f;

                bar.EnableDepthSort = false;
                bar.DataLabelStyle.Visible = false;

                //bar.Values.ValueFormatter = new NNumericValueFormatter("0.0");
                bar.Values.EmptyDataPoints.ValueMode = EmptyDataPointsValueMode.Skip;

                //bar.Values.Clear();
                bar.FillStyles.StorageType = IndexedStorageType.Array;
                bar.DataPointOriginIndex = 0;

                // turn off bar border to improve performance
                bar.BorderStyle.Width = new NLength(0.5f);
            }
            nChartControl.Settings.RenderSurface = RenderSurface.Window;

        }

        private void UpdateMap(NChartControl nChartControl, int gridY, double[] valList)
        {
            NCartesianChart chart = (NCartesianChart)nChartControl.Charts[0];
            // fill grid to bars
            //for (int i = 0; i < 100; i++)
            {
                NBarSeries bar = chart.Series[gridY] as NBarSeries;
                double[] barValues = valList;
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
                        bar.FillStyles[j] = new NColorFillStyle(_colorTable[(int)barValues[j]]);
                    }
                    else
                    {
                        ((NColorFillStyle)bar.FillStyles[j]).Color = _colorTable[(int)barValues[j]];
                    }
                }
            }

            nChartControl.Refresh();
        }

        private static Tuple<int, int> UpdateMatrixThreadTest(double[][] matrix)
        {
            Random rnd = new Random();
            int value = (int) Math.Max(1, rnd.NextDouble() * 20);
            int x = rnd.Next(0, 99);
            int y = rnd.Next(0, 99);

            matrix[y][x] = value;

            return Tuple.Create(x, y);
        }

        private static void TestUIComponent(NChartControl nChartControl, double[][] matrix)
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
                        bar.FillStyles[j] = new NColorFillStyle(_colorTable[(int)barValues[j]]);
                    }
                    else
                    {
                        ((NColorFillStyle)bar.FillStyles[j]).Color = _colorTable[(int)barValues[j]];
                    }
                }
            }
            nChartControl.Refresh();
        }

        private static Tuple<int, int> UpdateMatrix(NChartControl nChartControl, double[][] matrix)
        {
            Random rnd = new Random();
            int value = (int)Math.Max(1, rnd.NextDouble() * 20);
            int x = rnd.Next(0, 99);
            int y = rnd.Next(0, 99);

            matrix[y][x] = value;

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
                        bar.FillStyles[j] = new NColorFillStyle(_colorTable[(int)barValues[j]]);
                    }
                    else
                    {
                        ((NColorFillStyle)bar.FillStyles[j]).Color = _colorTable[(int)barValues[j]];
                    }
                }
            }
            nChartControl.Refresh();

            return Tuple.Create(x, y);
        }

        private static void UpdateLog(ListBox lb, String objID, String eventLog, int x, int y)
        {
            String strLog = $"{DateTime.Now:s} {objID} {eventLog} ({x}, {y})";
            lb.Items.Add(strLog);
            lb.SelectedIndex = lb.Items.Count - 1;

        }

        private void openScenarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //StreamReader sr = new StreamReader(ofd.FileName);
                _scenarioManager = new ScenarioManager(ofd.FileName);
            }
        }

        private void realTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _simManager.TimeMode = TimeModeStruct.X10;
        }

        private void chartSimulation_Click(object sender, EventArgs e)
        {

        }

        private void chartRealWorld_Click(object sender, EventArgs e)
        {

        }

        private void PatrolSim_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_worker.IsAlive)
            {
                _worker.Abort();
                _threadState = ThreadState.Stop;
               _simManager.Terminate();
            }
        }

        private void ratio100XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _simManager.TimeMode = TimeModeStruct.X100;
        }

        private void bestEffortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _simManager.TimeMode = TimeModeStruct.BestEffort;
        }

        private void ratio50XToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _simManager.TimeMode = TimeModeStruct.X50;
        }

        private void ratio05XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _simManager.TimeMode = TimeModeStruct.X05;
        }

        private void simulationStartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _simManager.Run(_scenarioManager.AgentList);

            _threadState = ThreadState.Run;
            if (!_worker.IsAlive)
            {
                _worker.Start();
            }

        }

        private void simulaitionPauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _simManager.Pause();
            _threadState = ThreadState.Pause;
        }

        private void simulationResumeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _simManager.Resume();
            _threadState = ThreadState.Run;
        }

        private void simulationStopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _simManager.Terminate();
            _threadState = ThreadState.Stop;
            if (_worker.IsAlive)
            {
                _worker.Abort();
            }
        }
    }
}
