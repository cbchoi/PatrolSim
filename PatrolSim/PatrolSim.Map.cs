﻿using System;
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

            int _dx = DrawArea.Width / 50;
            int _dy = DrawArea.Height / 50;

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

        private static Object draw_lock = new Object();

        public static void DrawBox(PictureBox pictureBox, int x, int y, int map_x, int map_y, Color clr)
        {
            lock (draw_lock)
            {
                int _dx = pictureBox.Width / 50;
                int _dy = pictureBox.Height / 50;

                float fx = x;
                float fy = y;
                int curX = ((int)(pictureBox.Width * (fx / map_x)));
                int curY = pictureBox.Image.Height - ((int)(pictureBox.Height * (fy / map_y)) );

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
            }
            //pictureBox.Invalidate();
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
