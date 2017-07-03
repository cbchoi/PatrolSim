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
using AISWrapper;
using Nevron;
using Nevron.Chart;
using Nevron.Chart.Windows;
using Nevron.Chart.WinForm;
using Nevron.Dom;
using Nevron.GraphicsCore;
using ShipClassifierWrapper;

namespace PatrolSim
{
    public partial class PatrolSim : Form
    {
        private static int _gridSizeX = 100;
        private static int _gridSizeY = 100;

        //private static Color[] _colorTable;

        private static double[][] matrixSimulation;
        private static double[][] matrixRealWorld;

        private static Dictionary<int, Agent>[][] matrixRealAgents;
        private static Dictionary<int, Agent>[][] matrixSimAgents;

        private static ScenarioManager _scenarioManager;
        private static SimulationManager _simManager;

        enum ThreadState{ Run, Pause, Stop,}

        private ThreadState _threadState = ThreadState.Stop;
        private Thread _worker;
        private Thread _radarWorker;

        private BackgroundWorker backWorker_map;
        private BackgroundWorker backWorker_radar;
        private static BackgroundWorker backWorker_log;

        private static Object thisLock = new Object();
        private static Object log_lock = new Object();
        private static Object remove_lock = new Object();

        //private Image _cloneSim;
        //private Image _cloneReal;
        //private Image _cloneExclusive;

        private Configuration _config;

        public PatrolSim()
        {
            //NLicense license = new NLicense("XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX");
            //NLicenseManager.Instance.SetLicense(license);
            //NLicenseManager.Instance.LockLicense = true;            //NLicense license = new NLicense("XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX");
            //NLicenseManager.Instance.SetLicense(license);
            //NLicenseManager.Instance.LockLicense = true;


            _config = new Configuration(@"configure.xml");
            _gridSizeX = _config.CellSizeX;
            _gridSizeY = _config.CellSizeY;

            matrixRealWorld = new double[_config.CellSizeY][];
            matrixSimulation = new double[_config.CellSizeY][];

            matrixRealAgents = new Dictionary<int, Agent>[_gridSizeY][];
            matrixSimAgents = new Dictionary<int, Agent>[_gridSizeY][];

            for (int i = 0; i < _gridSizeY; i++)
            {
                matrixRealWorld[i] = new double[_config.CellSizeX];
                matrixSimulation[i] = new double[_config.CellSizeX];

                matrixRealAgents[i] = new Dictionary<int, Agent>[_config.CellSizeX];
                matrixSimAgents[i] = new Dictionary<int, Agent>[_config.CellSizeX];
            }

            for (int i = 0; i < _config.CellSizeY; i++)
            {
                for (int j = 0; j < _config.CellSizeX; j++)
                {
                    matrixRealAgents[i][j] = new Dictionary<int, Agent>();
                    matrixSimAgents[i][j] = new Dictionary<int, Agent>();
                }
            }

            InitializeComponent();
           
            // Initalize Image
            pictRealWorld.Load(@".\RealMap.png");
            pictRealWorld.SizeMode = PictureBoxSizeMode.StretchImage;

            _simulateMap.Load(@".\SimMap2.png");
            _simulateMap.SizeMode = PictureBoxSizeMode.StretchImage;

            _realMap.Load(@".\SimMap2.png");
            _realMap.SizeMode = PictureBoxSizeMode.StretchImage;

            //_exclusiveMap.Image = new Bitmap(_simulateMap.Image.Width, _simulateMap.Image.Height);
            _exclusiveMap.Load(@".\SimMap2.png");
            _exclusiveMap.SizeMode = PictureBoxSizeMode.StretchImage;

            InitMap(chartRealWorld);
            DrawLineInt(_simulateMap);
            DrawLineInt(_realMap);
            DrawLineInt(_exclusiveMap);

            _simManager = new SimulationManager();
            _worker = new Thread(UpdateSimulationMap);
            _radarWorker = new Thread(UpdateRadarMap);

            backWorker_map = new BackgroundWorker();
            backWorker_log = new BackgroundWorker();
            backWorker_radar = new BackgroundWorker();

            this.backWorker_map.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backWorker_RunWorkerCompleted);
            this.backWorker_radar.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backWorker_RadarRunWorkerCompleted);
            backWorker_log.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backWorker_log_RunWorkerCompleted);
            backWorker_log.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backWorker_log_DoWork);
        }

        private void InitMap(NChartControl nChartControl)
        {
            // configure the chart
            NCartesianChart chart = (NCartesianChart)nChartControl.Charts[0];
            chart.Projection.SetPredefinedProjection(PredefinedProjection.OrthogonalTop);
            chart.BoundsMode = BoundsMode.Stretch;
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
            //NOrdinalScaleConfigurator ordinalScale = (NOrdinalScaleConfigurator)chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;
            //ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
            //ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
            //ordinalScale.DisplayDataPointsBetweenTicks = false;

            //ordinalScale = (NOrdinalScaleConfigurator)chart.Axis(StandardAxis.Depth).ScaleConfigurator;
            //ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
            //ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, true);
            //ordinalScale.DisplayDataPointsBetweenTicks = false;

            NLinearScaleConfigurator linearScale = new NLinearScaleConfigurator();
            chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale;
            linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
            linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
            linearScale.RoundToTickMax = false;
            linearScale.RoundToTickMin = false;

            linearScale = new NLinearScaleConfigurator();
            chart.Axis(StandardAxis.Depth).ScaleConfigurator = linearScale;
            linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
            linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScale.RoundToTickMax = false;
            linearScale.RoundToTickMin = false;

            linearScale = new NLinearScaleConfigurator();
            chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale;
            linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
            linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScale.RoundToTickMax = false;
            linearScale.RoundToTickMin = false;

            chart.Axis(StandardAxis.SecondaryY).Anchor = new NDockAxisAnchor(AxisDockZone.FrontLeft, false, 50.0f, 50.0f);

            // Axis Visable Setup.
            //chart.Axis(StandardAxis.PrimaryX).Visible = false;
            chart.Axis(StandardAxis.PrimaryY).Visible = false;
            //chart.Axis(StandardAxis.Depth).Visible = false;

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

            nChartControl.Controller.Tools.Add(new NPanelSelectorTool());
            nChartControl.Controller.Tools.Add(new NTrackballTool());

        }

        private static List<Agent> agent_list = new List<Agent>();
        

        private void chartRealWorld_Click(object sender, EventArgs e)
        {

        }

        private void realTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _simManager.TimeMode = TimeModeStruct.X10;
        }

        private void PatrolSim_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_worker.IsAlive)
            {
                _worker.Abort();
                _threadState = ThreadState.Stop;
               _simManager.Terminate();
            }

            if (_radarWorker.IsAlive)
            {
                _radarWorker.Abort();
            }
        }

        private void openScenarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Scenario File (.sce)|*.sce|All Files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //StreamReader sr = new StreamReader(ofd.FileName);
                _scenarioManager = new ScenarioManager(ofd.FileName);
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
            if (_scenarioManager == null)
            {
                MessageBox.Show("You should select the scenario first.");
                return;
            }
            _simManager.Run(_scenarioManager.AgentList, _scenarioManager.RouteManager);

            _threadState = ThreadState.Run;
            if (!_worker.IsAlive)
            {
                _worker.Start();
            }

            if (!_radarWorker.IsAlive)
            {
                _radarWorker.Start();
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

            if (!_radarWorker.IsAlive)
            {
                _radarWorker.Abort();
            }
        }

        private void aisCrashlStripMenuItem_Click(object sender, EventArgs e)
        {
            _simManager.SetAbnormalEvent(!_simManager.AbnormalEvent);

            lock (remove_lock)
            {
                List<Agent> temp_agentList = new List<Agent>();
                if (_simManager.AbnormalEvent == true)
                {
                    // Clone Agents
                    foreach (Agent agent in _scenarioManager.AgentList)
                    {
                        if (agent.AgentType == (int)AgentType.NormalShip)
                        {
                            Agent sim_agent = agent.SimModelClone();
                            temp_agentList.Add(sim_agent);

                            // TODO
                            //Partial Trajectory Initalize
                            for (int i = 0; i < sim_agent.CurrentWayointIndex - 1; i++)
                            {
                                _scenarioManager.RouteManager.SetWaypoints(sim_agent.AgentID, (int)((Position)sim_agent.WaypointList[i]).X, (int)((Position)sim_agent.WaypointList[i]).Y);
                            }
                            _scenarioManager.RouteManager.SetWaypoints(sim_agent.AgentID, (int)agent.CurrentPosition.X, (int)agent.CurrentPosition.Y);
                        }
                    }

                    foreach (Agent agent in temp_agentList)
                    {
                        _simManager.InsertAgentAtRuntime(agent);
                    }
                }
                else
                {
                    foreach (Agent agent in _simManager.AgentList)
                    {
                        if (agent.AgentType == (int)AgentType.SimulationModel)
                        {
                            temp_agentList.Add(agent);
                        }
                    }

                    foreach (Agent agent in temp_agentList)
                    {
                        _simManager.RemoveAgentAtRuntime(agent);
                    }
                }
            }

            if (_simManager.AbnormalEvent == true)
            {
                aisCrashlStripMenuItem.Text = "AIS Restored";
            }
            else
            {
                aisCrashlStripMenuItem.Text = "AIS Crashed";
            }
        }
    }
}
