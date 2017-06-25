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
    public partial class NewObject : Form
    {
        private int _agentID;
        public int AgentID
        {
            get => _agentID;
            set => _agentID = value;
        }

        private double _agentSpd;
        public double AgentSpeed
        {
            get => _agentSpd;
            set => _agentSpd = value;
        }

        public int _agentType;
        public int AgentType
        {
            get => _agentType;
            set => _agentType = value;
        }

        public NewObject()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _agentID = Int32.Parse(textBox1.Text);
            _agentSpd = Double.Parse(textBox2.Text);
            _agentType = Int32.Parse(textBox3.Text);

            this.Close();
        }
    }
}
