using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatrolSim
{
    partial class PatrolSim
    {
        public static void DrawLineInt(PictureBox pictureBox)
        {
            Image DrawArea = pictureBox.Image;

            int _dx = DrawArea.Width / _gridSizeX;
            int _dy = DrawArea.Height / _gridSizeY;

            // Draw line to screen.
            using (var graphics = Graphics.FromImage(pictureBox.Image))
            {
                Pen blackPen = new Pen(Color.Black, 1);

                for (int i = 0; i < DrawArea.Width; i += _dx)
                {
                    for (int j = 0; j < DrawArea.Height; j += _dy)
                    {
                        graphics.DrawLine(blackPen, i, 0, i, DrawArea.Height);
                        graphics.DrawLine(blackPen, 0, j, DrawArea.Width, j);
                    }
                }
                blackPen.Dispose();
            }
        }

        //public static void DrawLineInt(PictureBox pictureBox, out Image clone)
        //{
        //    Image DrawArea;
        //    if (pictureBox.Image == null)
        //    {
        //        DrawArea = new Bitmap(pictureBox.Size.Width, pictureBox.Size.Height);
        //        pictureBox.Image = DrawArea;

        //    }
        //    else
        //    {
        //        DrawArea = pictureBox.Image;
        //    }

        //    int _dx = DrawArea.Width / _gridSizeX;
        //    int _dy = DrawArea.Height / _gridSizeY;

        //    // Draw line to screen.
        //    using (var graphics = Graphics.FromImage(pictureBox.Image))
        //    {
        //        Pen blackPen = new Pen(Color.Black, 1);

        //        for (int i = 0; i < DrawArea.Width; i += _dx)
        //        {
        //            for (int j = 0; j < DrawArea.Height; j += _dy)
        //            {
        //                graphics.DrawLine(blackPen, i, 0, i, DrawArea.Height);
        //                graphics.DrawLine(blackPen, 0, j, DrawArea.Width, j);
        //            }
        //        }
        //        blackPen.Dispose();
        //    }

        //    clone = (Image)pictureBox.Image.Clone();
        //}

        private static Object draw_lock = new Object();

        public static void DrawBox(PictureBox pictureBox, int x, int y, int map_x, int map_y, Color clr)
        {
            lock (draw_lock)
            {
                int _dx = pictureBox.Image.Width / _gridSizeX;
                int _dy = pictureBox.Image.Height / _gridSizeY;

                float fx = x;
                float fy = y;
                int curX = ((int)(pictureBox.Image.Width * (fx / map_x)));

                int curY = 0;
                if (pictureBox.Image.Height - _dy - ((int) (pictureBox.Image.Height * (fy / map_y))) >= 0)
                    curY = pictureBox.Image.Height - _dy - ((int) (pictureBox.Image.Height * (fy / map_y)));

                //Bitmap bmpImage = new Bitmap(bmp);
                
                using (var graphics = Graphics.FromImage(pictureBox.Image))
                {
                    Pen blackPen = new Pen(clr, 1);
                    Brush brush = new SolidBrush(clr);

                    graphics.FillRectangle(brush, curX, curY, _dx, _dy);  // redraws background
                    graphics.DrawRectangle(blackPen, curX, curY, _dx, _dy);
                    brush.Dispose();
                    blackPen.Dispose();
                }
                //MessageBox.Show(String.Format("pictureBox.Image: ({0},{1})", pictureBox.Image.Width, pictureBox.Image.Height));
                //MessageBox.Show(String.Format("Map Size: ({0},{1})", map_x, map_y));
                //MessageBox.Show(String.Format("current: ({0},{1})", curX, curY));
                //MessageBox.Show(String.Format("fx, fy: ({0},{1})", x, y));
            }
            //pictureBox.Invalidate();
        }

        public static void DrawBox2(PictureBox pictureBox, double[][] matrix)
        {
            int _dx = pictureBox.Image.Width / _gridSizeX;
            int _dy = pictureBox.Image.Height / _gridSizeY;

            //Bitmap bmpImage = new Bitmap(bmp);

            using (var graphics = Graphics.FromImage(pictureBox.Image))
            {
                for (int i = 0; i < _gridSizeY; i++)
                {
                    for (int j = 0; j < _gridSizeX; j++)
                    {
                        if (matrix[i][j] != 0)
                        {
                            float fx = j;
                            float fy = i;
                            int curX = ((int)(pictureBox.Image.Width * (fx / _scenarioManager.MapSizeX)));

                            int curY = 0;
                            if (pictureBox.Image.Height - _dy - ((int)(pictureBox.Image.Height * (fy / _scenarioManager.MapSizeY))) >=
                                0)
                                curY = pictureBox.Image.Height - _dy -
                                       ((int)(pictureBox.Image.Height * (fy / _scenarioManager.MapSizeY)));
                            Pen blackPen = new Pen(_scenarioManager.ColorList[(int) matrix[i][j]], 1);
                            Brush brush = new SolidBrush(_scenarioManager.ColorList[(int) matrix[i][j]]);

                            graphics.FillRectangle(brush, curX, curY, _dx, _dy); // redraws background
                            graphics.DrawRectangle(blackPen, curX, curY, _dx, _dy);
                            brush.Dispose();
                            blackPen.Dispose();
                        }
                    }
                }
            }
        }

        public static void UpdateAgentMap(Agent agent, int MapSizeX, int MapSizeY, int dx, int dy)
        {
            
        }

        public static void UpdateRadarMap(Agent agent)
        {
            
        }

        public static void DrawBox2(PictureBox pictureBox, Dictionary<int, Agent>[][] matrix)
        {
            int _dx = pictureBox.Image.Width / _gridSizeX;
            int _dy = pictureBox.Image.Height / _gridSizeY;

            //Bitmap bmpImage = new Bitmap(bmp);

            using (var graphics = Graphics.FromImage(pictureBox.Image))
            {
                for (int i = 0; i < _gridSizeY; i++)
                {
                    for (int j = 0; j < _gridSizeX; j++)
                    {
                        if (matrix[i][j].Keys.Count != 0)
                        {
                            float fx = j;
                            float fy = i;
                            int curX = ((int)(pictureBox.Image.Width * (fx / _scenarioManager.MapSizeX)));
                            int curY = 0;
                            if (pictureBox.Image.Height - _dy - ((int)(pictureBox.Image.Height * (fy / _scenarioManager.MapSizeY))) >= 0)
                                curY = pictureBox.Image.Height - _dy - ((int)(pictureBox.Image.Height * (fy / _scenarioManager.MapSizeY)));

                            Pen blackPen = new Pen(_scenarioManager.ColorList[matrix[i][j].Values.ElementAt(0).AgentID], 1);
                            Brush brush = new SolidBrush(_scenarioManager.ColorList[matrix[i][j].Values.ElementAt(0).AgentID]);

                            graphics.FillRectangle(brush, curX, curY, _dx, _dy); // redraws background
                            graphics.DrawRectangle(blackPen, curX, curY, _dx, _dy);
                            brush.Dispose();
                            blackPen.Dispose();
                        }
                    }
                }
            }
        }

        public static void DrawAgent(PaintEventArgs e, float fx, float fy, int _dx, int _dy, Color clr)
        {
            int curX = ((int)(e.ClipRectangle.Width * (fx / _scenarioManager.MapSizeX)));

            int curY = 0;
            if (e.ClipRectangle.Height - _dy - ((int)(e.ClipRectangle.Height * (fy / _scenarioManager.MapSizeY))) >=
                0)
                curY = e.ClipRectangle.Height - _dy -
                       ((int)(e.ClipRectangle.Height * (fy / _scenarioManager.MapSizeY)));

            Pen blackPen = new Pen(clr, 1);
            Brush brush = new SolidBrush(clr);

            e.Graphics.FillRectangle(brush, curX, curY, _dx, _dy); // redraws background
            e.Graphics.DrawRectangle(blackPen, curX, curY, _dx, _dy);
            brush.Dispose();
            blackPen.Dispose();
        }

        private void _simulateMap_Paint(object sender, PaintEventArgs e)
        {
            int _dx = e.ClipRectangle.Width / _gridSizeX;
            int _dy = e.ClipRectangle.Height / _gridSizeY;

            //Bitmap bmpImage = new Bitmap(bmp);

            //using (var graphics = e.Graphics)
            {
                for (int i = 0; i < _gridSizeY; i++)
                {
                    for (int j = 0; j < _gridSizeX; j++)
                    {
                        if (matrixSimAgents[i][j].Keys.Count != 0)
                        {
                            foreach (Agent agent in matrixSimAgents[i][j].Values)
                            {
                                if (agent.AgentType == (int) AgentType.NormalShip)
                                {
                                    if (agent.AbnormalEvent == true)
                                    {
                                        if (agent.CrashedPosition != null)
                                        {
                                            int crashX = (int)(agent.CrashedPosition.X * _gridSizeX / _scenarioManager.MapSizeX);
                                            int crashY = (int)(agent.CrashedPosition.Y * _gridSizeY / _scenarioManager.MapSizeY); ;
                                            //2. Draw Crashed Data 
                                            DrawAgent(e, crashX, crashY, _dx, _dy, _scenarioManager.ColorList[agent.AgentID]);
                                        }
                                    }
                                    else
                                    {
                                        DrawAgent(e, j, i, _dx, _dy, _scenarioManager.ColorList[agent.AgentID]);
                                    }
                                }
                                else
                                {
                                    if (_simManager.AbnormalEvent == true)
                                    {
                                        int simX = (int)(agent.CurrentPosition.X * _gridSizeX / _scenarioManager.MapSizeX);
                                        int simY = (int)(agent.CurrentPosition.Y * _gridSizeY / _scenarioManager.MapSizeY);

                                        DrawAgent(e, simX, simY, _dx, _dy, Color.Yellow);
                                    }
                                    else
                                    {
                                        matrixSimAgents[i][j].Remove(agent.AgentID);
                                    }
                                }

                            }
                        }
                    }
                }
            }
        }


        private void _realMap_Paint(object sender, PaintEventArgs e)
        {
            int _dx = e.ClipRectangle.Width / _gridSizeX;
            int _dy = e.ClipRectangle.Height / _gridSizeY;

            //Bitmap bmpImage = new Bitmap(bmp);

            //using (var graphics = e.Graphics)
            {
                for (int i = 0; i < _gridSizeY; i++)
                {
                    for (int j = 0; j < _gridSizeX; j++)
                    {
                        if (matrixRealAgents[i][j].Keys.Count != 0)
                        {
                            float fx = j;
                            float fy = i;
                            int curX = ((int)(e.ClipRectangle.Width * (fx / _scenarioManager.MapSizeX)));

                            int curY = 0;
                            if (e.ClipRectangle.Height - _dy - ((int)(e.ClipRectangle.Height * (fy / _scenarioManager.MapSizeY))) >= 0)
                                curY = e.ClipRectangle.Height - _dy -
                                       ((int)(e.ClipRectangle.Height * (fy / _scenarioManager.MapSizeY)));
                            Pen blackPen = new Pen(Color.Blue, 1);
                            Brush brush = new SolidBrush(Color.Blue);

                            e.Graphics.FillRectangle(brush, curX, curY, _dx, _dy); // redraws background
                            e.Graphics.DrawRectangle(blackPen, curX, curY, _dx, _dy);
                            brush.Dispose();
                            blackPen.Dispose();
                        }
                    }
                }
            }
        }

        private void DrawBoxWithMode(PaintEventArgs e, int _dx, int _dy)
        {
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
                        float fx = j;
                        float fy = i;
                        int curX = ((int)(e.ClipRectangle.Width * (fx / _scenarioManager.MapSizeX)));

                        int curY = 0;
                        if (e.ClipRectangle.Height - _dy -
                            ((int)(e.ClipRectangle.Height * (fy / _scenarioManager.MapSizeY))) >=
                            0)
                            curY = e.ClipRectangle.Height - _dy -
                                   ((int)(e.ClipRectangle.Height * (fy / _scenarioManager.MapSizeY)));

                        Pen blackPen = new Pen(Color.Purple);
                        Brush brush = new SolidBrush(Color.Purple);

                        e.Graphics.FillRectangle(brush, curX, curY, _dx, _dy); // redraws background
                        e.Graphics.DrawRectangle(blackPen, curX, curY, _dx, _dy);
                        brush.Dispose();
                        blackPen.Dispose();
                    }
                    else if (agent_count != 0 && agent_count != matrixRealAgents[i][j].Keys.Count)
                    {
                        float fx = j;
                        float fy = i;
                        int curX = ((int)(e.ClipRectangle.Width * (fx / _scenarioManager.MapSizeX)));

                        int curY = 0;
                        if (e.ClipRectangle.Height - _dy -
                            ((int)(e.ClipRectangle.Height * (fy / _scenarioManager.MapSizeY))) >=
                            0)
                            curY = e.ClipRectangle.Height - _dy -
                                   ((int)(e.ClipRectangle.Height * (fy / _scenarioManager.MapSizeY)));

                        Pen blackPen = new Pen(Color.DeepPink);
                        Brush brush = new SolidBrush(Color.DeepPink);

                        e.Graphics.FillRectangle(brush, curX, curY, _dx, _dy); // redraws background
                        e.Graphics.DrawRectangle(blackPen, curX, curY, _dx, _dy);
                        brush.Dispose();
                        blackPen.Dispose();
                    }
                    else if ((matrixSimAgents[i][j].Keys.Count - agent_count) != matrixRealAgents[i][j].Keys.Count)
                    {
                        float fx = j;
                        float fy = i;
                        int curX = ((int)(e.ClipRectangle.Width * (fx / _scenarioManager.MapSizeX)));

                        int curY = 0;
                        if (e.ClipRectangle.Height - _dy -
                            ((int)(e.ClipRectangle.Height * (fy / _scenarioManager.MapSizeY))) >=
                            0)
                            curY = e.ClipRectangle.Height - _dy -
                                   ((int)(e.ClipRectangle.Height * (fy / _scenarioManager.MapSizeY)));

                        Pen blackPen = new Pen(Color.Red);
                        Brush brush = new SolidBrush(Color.Red);

                        e.Graphics.FillRectangle(brush, curX, curY, _dx, _dy); // redraws background
                        e.Graphics.DrawRectangle(blackPen, curX, curY, _dx, _dy);
                        brush.Dispose();
                        blackPen.Dispose();
                    }

                }
            }
        }

        private void _exclusiveMap_Paint(object sender, PaintEventArgs e)
        {
            int _dx = e.ClipRectangle.Width / _gridSizeX;
            int _dy = e.ClipRectangle.Height / _gridSizeY;

            //using (var graphics = e.Graphics)
            DrawBoxWithMode(e, _dx, _dy);
        }

        public static void DrawBox(PictureBox pictureBox, double[][] matrix)
        {
            for (int i = 0; i < _gridSizeY; i++)
            {
                for (int j = 0; j < _gridSizeX; j++)
                {
                    if (matrix[i][j] != 0)
                    {
                        DrawBox(pictureBox, j, i,
                            _scenarioManager.MapSizeX, _scenarioManager.MapSizeY,
                            _scenarioManager.ColorList[(int)matrix[i][j]]);
                    }
                    
                }
            }
        }
    }
}
