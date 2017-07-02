namespace ScenarioEditor
{
    partial class ScenarioEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScenarioEditor));
            this.pictRealWorld = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mmsi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Speed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.posX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.posY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.posZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictRealWorld)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictRealWorld
            // 
            this.pictRealWorld.Image = ((System.Drawing.Image)(resources.GetObject("pictRealWorld.Image")));
            this.pictRealWorld.Location = new System.Drawing.Point(10, 9);
            this.pictRealWorld.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.pictRealWorld.Name = "pictRealWorld";
            this.pictRealWorld.Size = new System.Drawing.Size(559, 460);
            this.pictRealWorld.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictRealWorld.TabIndex = 3;
            this.pictRealWorld.TabStop = false;
            this.pictRealWorld.Click += new System.EventHandler(this.pictRealWorld_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.mmsi,
            this.Speed,
            this.Type,
            this.posX,
            this.posY,
            this.posZ});
            this.dataGridView1.Location = new System.Drawing.Point(587, 9);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(499, 408);
            this.dataGridView1.TabIndex = 4;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // mmsi
            // 
            this.mmsi.HeaderText = "mmsi";
            this.mmsi.Name = "mmsi";
            // 
            // Speed
            // 
            this.Speed.HeaderText = "Speed";
            this.Speed.Name = "Speed";
            // 
            // Type
            // 
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            // 
            // posX
            // 
            this.posX.HeaderText = "posX";
            this.posX.Name = "posX";
            // 
            // posY
            // 
            this.posY.HeaderText = "posY";
            this.posY.Name = "posY";
            // 
            // posZ
            // 
            this.posZ.HeaderText = "posZ";
            this.posZ.Name = "posZ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btExport);
            this.panel1.Controls.Add(this.pictRealWorld);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(7, 6);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1101, 479);
            this.panel1.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(742, 429);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(152, 39);
            this.button2.TabIndex = 7;
            this.button2.Text = "Load Object";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(587, 429);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 39);
            this.button1.TabIndex = 6;
            this.button1.Text = "New Object";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btExport
            // 
            this.btExport.Location = new System.Drawing.Point(897, 429);
            this.btExport.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btExport.Name = "btExport";
            this.btExport.Size = new System.Drawing.Size(188, 39);
            this.btExport.TabIndex = 5;
            this.btExport.Text = "Export";
            this.btExport.UseVisualStyleBackColor = true;
            this.btExport.Click += new System.EventHandler(this.btExport_Click);
            // 
            // ScenarioEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1113, 491);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Name = "ScenarioEditor";
            this.Text = "Scenario Editor";
            ((System.ComponentModel.ISupportInitialize)(this.pictRealWorld)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictRealWorld;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btExport;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn mmsi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Speed;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn posX;
        private System.Windows.Forms.DataGridViewTextBoxColumn posY;
        private System.Windows.Forms.DataGridViewTextBoxColumn posZ;
    }
}

