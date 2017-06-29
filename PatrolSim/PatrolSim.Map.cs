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
            Image DrawArea;
            if (pictureBox.Image == null)
            {
                DrawArea = new Bitmap(pictureBox.Size.Width, pictureBox.Size.Height);
                pictureBox.Image = DrawArea;

            }
            else
            {
                DrawArea = pictureBox.Image;
            }

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

        public static void DrawLineInt(PictureBox pictureBox, out Image clone)
        {
            Image DrawArea;
            if (pictureBox.Image == null)
            {
                DrawArea = new Bitmap(pictureBox.Size.Width, pictureBox.Size.Height);
                pictureBox.Image = DrawArea;

            }
            else
            {
                DrawArea = pictureBox.Image;
            }

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

            clone = (Image)pictureBox.Image.Clone();
        }

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
