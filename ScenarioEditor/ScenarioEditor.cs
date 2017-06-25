using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScenarioEditor
{
    public partial class ScenarioEditor : Form
    {
        public ScenarioEditor()
        {
            InitializeComponent();
            _dx = pictRealWorld.Image.Width / 50;
            _dy = pictRealWorld.Image.Height / 50;

            DrawLineInt(pictRealWorld.Image);
            DrawBox(pictRealWorld.Image, 0, 0);
        }

        private void pictRealWorld_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Point coordinates = me.Location;

            dataGridView1.Rows.Add(_curAgentID, _curAgentSpd, _curAgentType, coordinates.X, coordinates.Y, 0);
            DrawBox(pictRealWorld.Image, coordinates.X, coordinates.Y);
            pictRealWorld.Refresh();
        }

        public void DrawLineInt(Image bmp)
        {
            Pen blackPen = new Pen(Color.Black, 3);

            // Draw line to screen.
            using (var graphics = Graphics.FromImage(bmp))
            {
                for (int i = 0; i < bmp.Width; i += _dx)
                {
                    for (int j = 0; j < bmp.Height; j += _dy)
                    {
                        graphics.DrawLine(blackPen, i, 0, i, bmp.Height);
                        graphics.DrawLine(blackPen, 0, j, bmp.Width, j);
                    }
                }
                
            }
        }

        public void DrawBox(Image bmp, int x, int y)
        {
            float fx = x;
            float fy = y;
            int curX = ((int)(bmp.Width * (fx / pictRealWorld.Width))/_dx)*_dx;
            int curY = ((int)(bmp.Height * (fy / pictRealWorld.Height))/_dy)*_dy;

            //Bitmap bmpImage = new Bitmap(bmp);
            using (var graphics = Graphics.FromImage(pictRealWorld.Image))
            {
                Pen blackPen = new Pen(Color.Red, 3);
                Brush brush = new SolidBrush(Color.Red);

                graphics.FillRectangle(brush, curX, curY, _dx, _dy);  // redraws background
                graphics.DrawRectangle(blackPen, curX, curY, _dx, _dy);
                brush.Dispose();
                blackPen.Dispose();
            } 
        }

        private int _curAgentID = 1;
        private double _curAgentSpd = 0.5;
        private int _curAgentType = 1;
        private int _dx;
        private int _dy;

        private void button1_Click(object sender, EventArgs e)
        {
            NewObject form = new NewObject();
            form.ShowDialog();
            _curAgentID = form.AgentID;
            _curAgentSpd = form.AgentSpeed;
            _curAgentType = form.AgentType;
        }
    }
}
