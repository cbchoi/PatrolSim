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
        public void DrawLineInt(PictureBox pictureBox)
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

        public void DrawBox(PictureBox pictureBox, int x, int y, Color clr)
        {
            Image DrawArea = pictureBox.Image;
            int _dx = DrawArea.Width / 50;
            int _dy = DrawArea.Height / 50;

            float fx = x;
            float fy = y;
            int curX = ((int)(pictureBox.Image.Width * (fx / pictureBox.Width)) / _dx) * _dx;
            int curY = ((int)(pictureBox.Image.Height * (fy / pictureBox.Height)) / _dy) * _dy;

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
    }
}
