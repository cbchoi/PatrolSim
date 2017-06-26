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
            Bitmap DrawArea = new Bitmap(pictureBox.Size.Width, pictureBox.Size.Height);
            pictureBox.Image = DrawArea;

            int _dx = pictureBox.Width / 50;
            int _dy = pictureBox.Height / 50;

            // Draw line to screen.
            using (var graphics = Graphics.FromImage(pictureBox.Image))
            {
                Pen blackPen = new Pen(Color.Black, 1);

                for (int i = 0; i < pictureBox.Width; i += _dx)
                {
                    for (int j = 0; j < pictureBox.Height; j += _dy)
                    {
                        graphics.DrawLine(blackPen, i, 0, i, pictureBox.Height);
                        graphics.DrawLine(blackPen, 0, j, pictureBox.Width, j);
                    }
                }
                blackPen.Dispose();
            }
        }

        public void DrawBox(PictureBox pictureBox, int x, int y, Color clr)
        {
            int _dx = pictureBox.Width / 50;
            int _dy = pictureBox.Height / 50;

            float fx = x;
            float fy = y;
            int curX = ((int)(pictureBox.Image.Width * (fx / pictRealWorld.Width)) / _dx) * _dx;
            int curY = ((int)(pictureBox.Image.Height * (fy / pictRealWorld.Height)) / _dy) * _dy;

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
