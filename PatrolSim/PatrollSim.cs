using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
        private readonly int _gridSizeX = 100;
        private readonly int _gridSizeY = 100;
        private readonly Color[] _colorTable;

        private double[][] matrixSimulation;
        private double[][] matrixRealWorld;

        public PatrolSim()
        {
            InitializeComponent();

            _colorTable = new Color[21];

            for (int i = 0; i <= 20; i++)
            {
                _colorTable[i] = InterpolateColors(Color.DeepSkyBlue, Color.Red, i / 20.0F);
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
                bar.BorderStyle.Width = new NLength(0);
            }
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

        private Tuple<int, int> UpdateMatrix(NChartControl nChartControl, double[][] matrix)
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

        private void UpdateLog(ListBox lb, String objID, String eventLog, int x, int y)
        {
            String strLog = String.Format("{0:u} {1} {2} ({3}, {4})", DateTime.Now, objID, eventLog, x, y);
            lb.Items.Add(strLog);
            lb.SelectedIndex = lb.Items.Count - 1;

        }

        private void ratio10XToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void PatrolSim_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Tuple<int, int> coordinate = UpdateMatrix(chartSimulation, matrixSimulation);
            //UpdateMap(chartSimulation, coordinate.Item2, matrixSimulation[coordinate.Item2]);
            UpdateLog(simLog, "agent1", "Moved", coordinate.Item1, coordinate.Item2);

            //value = (int)Math.Max(1, rnd.NextDouble() * 20);
            //x = rnd.Next(0, 99);
            //y = rnd.Next(0, 99);

            coordinate = UpdateMatrix(chartRealWorld,matrixRealWorld);
            //UpdateMap(chartRealWorld, coordinate.Item2, matrixRealWorld[coordinate.Item2]);
            UpdateLog(realLog, "ship1", "Moved", coordinate.Item1, coordinate.Item2);
        }
    }
}
