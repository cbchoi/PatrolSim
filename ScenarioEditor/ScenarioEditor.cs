using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace ScenarioEditor
{
    public partial class ScenarioEditor : Form
    {
        public ScenarioEditor()
        {
            InitializeComponent();
            _dx = pictRealWorld.Image.Width / 100;
            _dy = pictRealWorld.Image.Height / 100;

            DrawLineInt(pictRealWorld.Image);
            DrawBox(pictRealWorld.Image, 0, 0);
        }

        private void pictRealWorld_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Point coordinates = me.Location;

            dataGridView1.Rows.Add(_curAgentID, 0, _curAgentSpd, _curAgentType, ((float)coordinates.X/pictRealWorld.Width) *100, ((float)(pictRealWorld.Height - coordinates.Y))/ pictRealWorld.Height *100, 0);
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

        private void btExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                XmlDocument newXmlDoc = new XmlDocument();
                try
                { // load existed file
                    newXmlDoc.Load(sfd.FileName);
                }
                catch (System.IO.FileNotFoundException ex)
                { // if file don't exist, make new file
                    XmlNode NCD = newXmlDoc.CreateElement("ObjectList");

                    newXmlDoc.AppendChild(NCD);
                    newXmlDoc.Save(sfd.FileName);
                }

                XmlNode SelectedData = newXmlDoc.SelectSingleNode("ObjectList");
                SelectedData.RemoveAll();

                if (SelectedData is XmlElement)
                {
                    XmlElement elem = (XmlElement) SelectedData;
                    elem.SetAttribute("MapSizeX", pictRealWorld.Width.ToString());
                    elem.SetAttribute("MapSizeY", pictRealWorld.Height.ToString());
                }

                XmlElement shipListElement = newXmlDoc.CreateElement("ShipList");
                SelectedData.AppendChild(shipListElement);
                HandleShipList(shipListElement, newXmlDoc);

                XmlElement obstcleListElement = newXmlDoc.CreateElement("ObstcleList");
                SelectedData.AppendChild(obstcleListElement);
                HandleObstcleList(obstcleListElement, newXmlDoc);

                XmlElement colorListElement = newXmlDoc.CreateElement("ColorList");
                SelectedData.AppendChild(colorListElement);
                HandleColorList(colorListElement, newXmlDoc);

                newXmlDoc.Save(sfd.FileName);
                MessageBox.Show("Export Completed!");
            }  
        }

        private void HandleShipList(XmlElement shipList, XmlDocument doc)
        {
            int curID = -1;
            XmlElement curElement;
            XmlElement waypointElement = doc.CreateElement("Waypoints");
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (curID != (int)dataGridView1.Rows[i].Cells[0].Value)
                {
                    curID = (int) dataGridView1.Rows[i].Cells[0].Value;
                    curElement = doc.CreateElement("Ship");
                    curElement.SetAttribute("id", dataGridView1.Rows[i].Cells[0].Value.ToString());
                    curElement.SetAttribute("mmsi", dataGridView1.Rows[i].Cells[1].Value.ToString());
                    curElement.SetAttribute("spd", dataGridView1.Rows[i].Cells[2].Value.ToString());
                    curElement.SetAttribute("type", dataGridView1.Rows[i].Cells[3].Value.ToString());
                    
                    shipList.AppendChild(curElement);
                    waypointElement = doc.CreateElement("Waypoints");
                    curElement.AppendChild(waypointElement);
                }

                XmlElement wayElement = doc.CreateElement("Waypoint");
                wayElement.SetAttribute("x", dataGridView1.Rows[i].Cells[4].Value.ToString());
                wayElement.SetAttribute("y", dataGridView1.Rows[i].Cells[5].Value.ToString());
                wayElement.SetAttribute("z", dataGridView1.Rows[i].Cells[6].Value.ToString());
                waypointElement.AppendChild(wayElement);
            }
        }

        private void HandleObstcleList(XmlElement obList, XmlDocument doc)
        {
            
        }

        private void HandleColorList(XmlElement crList, XmlDocument doc)
        {
            
        }
    }
}
