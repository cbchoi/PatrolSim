namespace PatrolSim
{
    partial class PatrolSim
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PatrolSim));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newScenarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openScenarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveScenarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simulationControlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simulationStartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simulaitionPauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simulationResumeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simulationStopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simulationRatioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.realTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ratio05XToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ratio50XToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ratio100XToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bestEffortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analysisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timedAnaysisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.realLog = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.simLog = new System.Windows.Forms.ListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chartRealWorld = new Nevron.Chart.WinForm.NChartControl();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.pictRealWorld = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this._simulateMap = new System.Windows.Forms.PictureBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this._realMap = new System.Windows.Forms.PictureBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this._exclusiveMap = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictRealWorld)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._simulateMap)).BeginInit();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._realMap)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._exclusiveMap)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.simulationControlToolStripMenuItem,
            this.simulationRatioToolStripMenuItem,
            this.analysisToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(2976, 40);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newScenarioToolStripMenuItem,
            this.openScenarioToolStripMenuItem,
            this.saveScenarioToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(64, 36);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newScenarioToolStripMenuItem
            // 
            this.newScenarioToolStripMenuItem.Name = "newScenarioToolStripMenuItem";
            this.newScenarioToolStripMenuItem.Size = new System.Drawing.Size(271, 38);
            this.newScenarioToolStripMenuItem.Text = "New Scenario";
            // 
            // openScenarioToolStripMenuItem
            // 
            this.openScenarioToolStripMenuItem.Name = "openScenarioToolStripMenuItem";
            this.openScenarioToolStripMenuItem.Size = new System.Drawing.Size(271, 38);
            this.openScenarioToolStripMenuItem.Text = "Open Scenario";
            this.openScenarioToolStripMenuItem.Click += new System.EventHandler(this.openScenarioToolStripMenuItem_Click);
            // 
            // saveScenarioToolStripMenuItem
            // 
            this.saveScenarioToolStripMenuItem.Name = "saveScenarioToolStripMenuItem";
            this.saveScenarioToolStripMenuItem.Size = new System.Drawing.Size(271, 38);
            this.saveScenarioToolStripMenuItem.Text = "Save Scenario";
            // 
            // simulationControlToolStripMenuItem
            // 
            this.simulationControlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.simulationStartToolStripMenuItem,
            this.simulaitionPauseToolStripMenuItem,
            this.simulationResumeToolStripMenuItem,
            this.simulationStopToolStripMenuItem});
            this.simulationControlToolStripMenuItem.Name = "simulationControlToolStripMenuItem";
            this.simulationControlToolStripMenuItem.Size = new System.Drawing.Size(227, 36);
            this.simulationControlToolStripMenuItem.Text = "Simulation Control";
            // 
            // simulationStartToolStripMenuItem
            // 
            this.simulationStartToolStripMenuItem.Name = "simulationStartToolStripMenuItem";
            this.simulationStartToolStripMenuItem.Size = new System.Drawing.Size(319, 38);
            this.simulationStartToolStripMenuItem.Text = "Simulation Run";
            this.simulationStartToolStripMenuItem.Click += new System.EventHandler(this.simulationStartToolStripMenuItem_Click);
            // 
            // simulaitionPauseToolStripMenuItem
            // 
            this.simulaitionPauseToolStripMenuItem.Name = "simulaitionPauseToolStripMenuItem";
            this.simulaitionPauseToolStripMenuItem.Size = new System.Drawing.Size(319, 38);
            this.simulaitionPauseToolStripMenuItem.Text = "Simulaition Pause";
            this.simulaitionPauseToolStripMenuItem.Click += new System.EventHandler(this.simulaitionPauseToolStripMenuItem_Click);
            // 
            // simulationResumeToolStripMenuItem
            // 
            this.simulationResumeToolStripMenuItem.Name = "simulationResumeToolStripMenuItem";
            this.simulationResumeToolStripMenuItem.Size = new System.Drawing.Size(319, 38);
            this.simulationResumeToolStripMenuItem.Text = "Simulation Resume";
            this.simulationResumeToolStripMenuItem.Click += new System.EventHandler(this.simulationResumeToolStripMenuItem_Click);
            // 
            // simulationStopToolStripMenuItem
            // 
            this.simulationStopToolStripMenuItem.Name = "simulationStopToolStripMenuItem";
            this.simulationStopToolStripMenuItem.Size = new System.Drawing.Size(319, 38);
            this.simulationStopToolStripMenuItem.Text = "Simulation Stop";
            this.simulationStopToolStripMenuItem.Click += new System.EventHandler(this.simulationStopToolStripMenuItem_Click);
            // 
            // simulationRatioToolStripMenuItem
            // 
            this.simulationRatioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.realTimeToolStripMenuItem,
            this.ratio05XToolStripMenuItem,
            this.ratio50XToolStripMenuItem1,
            this.ratio100XToolStripMenuItem,
            this.bestEffortToolStripMenuItem});
            this.simulationRatioToolStripMenuItem.Name = "simulationRatioToolStripMenuItem";
            this.simulationRatioToolStripMenuItem.Size = new System.Drawing.Size(202, 36);
            this.simulationRatioToolStripMenuItem.Text = "Simulation Ratio";
            // 
            // realTimeToolStripMenuItem
            // 
            this.realTimeToolStripMenuItem.Name = "realTimeToolStripMenuItem";
            this.realTimeToolStripMenuItem.Size = new System.Drawing.Size(231, 38);
            this.realTimeToolStripMenuItem.Text = "Real Time";
            this.realTimeToolStripMenuItem.Click += new System.EventHandler(this.realTimeToolStripMenuItem_Click);
            // 
            // ratio05XToolStripMenuItem
            // 
            this.ratio05XToolStripMenuItem.Name = "ratio05XToolStripMenuItem";
            this.ratio05XToolStripMenuItem.Size = new System.Drawing.Size(231, 38);
            this.ratio05XToolStripMenuItem.Text = "Ratio:0.5X";
            this.ratio05XToolStripMenuItem.Click += new System.EventHandler(this.ratio05XToolStripMenuItem_Click);
            // 
            // ratio50XToolStripMenuItem1
            // 
            this.ratio50XToolStripMenuItem1.Name = "ratio50XToolStripMenuItem1";
            this.ratio50XToolStripMenuItem1.Size = new System.Drawing.Size(231, 38);
            this.ratio50XToolStripMenuItem1.Text = "Ratio:5.0X";
            this.ratio50XToolStripMenuItem1.Click += new System.EventHandler(this.ratio50XToolStripMenuItem1_Click);
            // 
            // ratio100XToolStripMenuItem
            // 
            this.ratio100XToolStripMenuItem.Name = "ratio100XToolStripMenuItem";
            this.ratio100XToolStripMenuItem.Size = new System.Drawing.Size(231, 38);
            this.ratio100XToolStripMenuItem.Text = "Ratio:10.0X";
            this.ratio100XToolStripMenuItem.Click += new System.EventHandler(this.ratio100XToolStripMenuItem_Click);
            // 
            // bestEffortToolStripMenuItem
            // 
            this.bestEffortToolStripMenuItem.Name = "bestEffortToolStripMenuItem";
            this.bestEffortToolStripMenuItem.Size = new System.Drawing.Size(231, 38);
            this.bestEffortToolStripMenuItem.Text = "Best Effort";
            this.bestEffortToolStripMenuItem.Click += new System.EventHandler(this.bestEffortToolStripMenuItem_Click);
            // 
            // analysisToolStripMenuItem
            // 
            this.analysisToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.timedAnaysisToolStripMenuItem});
            this.analysisToolStripMenuItem.Name = "analysisToolStripMenuItem";
            this.analysisToolStripMenuItem.Size = new System.Drawing.Size(112, 36);
            this.analysisToolStripMenuItem.Text = "Analysis";
            // 
            // timedAnaysisToolStripMenuItem
            // 
            this.timedAnaysisToolStripMenuItem.Name = "timedAnaysisToolStripMenuItem";
            this.timedAnaysisToolStripMenuItem.Size = new System.Drawing.Size(267, 38);
            this.timedAnaysisToolStripMenuItem.Text = "Timed Anaysis";
            // 
            // realLog
            // 
            this.realLog.FormattingEnabled = true;
            this.realLog.HorizontalScrollbar = true;
            this.realLog.ItemHeight = 25;
            this.realLog.Location = new System.Drawing.Point(17, 45);
            this.realLog.Name = "realLog";
            this.realLog.Size = new System.Drawing.Size(956, 329);
            this.realLog.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.realLog);
            this.groupBox1.Location = new System.Drawing.Point(1965, 471);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(987, 391);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Real World Log";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.simLog);
            this.groupBox2.Location = new System.Drawing.Point(1965, 59);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(987, 391);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Simulation Log";
            // 
            // simLog
            // 
            this.simLog.FormattingEnabled = true;
            this.simLog.HorizontalScrollbar = true;
            this.simLog.ItemHeight = 25;
            this.simLog.Location = new System.Drawing.Point(17, 45);
            this.simLog.Name = "simLog";
            this.simLog.Size = new System.Drawing.Size(956, 329);
            this.simLog.TabIndex = 4;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chartRealWorld);
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Location = new System.Drawing.Point(963, 59);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(987, 803);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Visualization";
            this.groupBox4.UseCompatibleTextRendering = true;
            // 
            // chartRealWorld
            // 
            this.chartRealWorld.AutoRefresh = false;
            this.chartRealWorld.BackColor = System.Drawing.SystemColors.Control;
            this.chartRealWorld.InputKeys = new System.Windows.Forms.Keys[0];
            this.chartRealWorld.Location = new System.Drawing.Point(22, 42);
            this.chartRealWorld.Name = "chartRealWorld";
            this.chartRealWorld.Size = new System.Drawing.Size(941, 744);
            this.chartRealWorld.State = ((Nevron.Chart.WinForm.NState)(resources.GetObject("chartRealWorld.State")));
            this.chartRealWorld.TabIndex = 1;
            this.chartRealWorld.Text = "SimulationMap";
            this.chartRealWorld.Click += new System.EventHandler(this.chartRealWorld_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Location = new System.Drawing.Point(0, 809);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(943, 833);
            this.groupBox5.TabIndex = 10;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "groupBox5";
            // 
            // pictRealWorld
            // 
            this.pictRealWorld.Image = ((System.Drawing.Image)(resources.GetObject("pictRealWorld.Image")));
            this.pictRealWorld.Location = new System.Drawing.Point(29, 76);
            this.pictRealWorld.Name = "pictRealWorld";
            this.pictRealWorld.Size = new System.Drawing.Size(912, 769);
            this.pictRealWorld.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictRealWorld.TabIndex = 2;
            this.pictRealWorld.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this._simulateMap);
            this.groupBox3.Location = new System.Drawing.Point(29, 868);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(928, 833);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Simulated Data (Cellularized)";
            // 
            // _simulateMap
            // 
            this._simulateMap.BackColor = System.Drawing.Color.White;
            this._simulateMap.Location = new System.Drawing.Point(19, 41);
            this._simulateMap.Name = "_simulateMap";
            this._simulateMap.Size = new System.Drawing.Size(893, 772);
            this._simulateMap.TabIndex = 0;
            this._simulateMap.TabStop = false;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this._realMap);
            this.groupBox7.Location = new System.Drawing.Point(998, 868);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(952, 833);
            this.groupBox7.TabIndex = 9;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Real World Data (Cellularized)";
            // 
            // _realMap
            // 
            this._realMap.BackColor = System.Drawing.Color.White;
            this._realMap.Location = new System.Drawing.Point(35, 41);
            this._realMap.Name = "_realMap";
            this._realMap.Size = new System.Drawing.Size(893, 772);
            this._realMap.TabIndex = 0;
            this._realMap.TabStop = false;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this._exclusiveMap);
            this.groupBox6.Location = new System.Drawing.Point(1965, 868);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(987, 833);
            this.groupBox6.TabIndex = 10;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Exclusive Data (Cellularized)";
            // 
            // _exclusiveMap
            // 
            this._exclusiveMap.BackColor = System.Drawing.Color.White;
            this._exclusiveMap.Location = new System.Drawing.Point(45, 41);
            this._exclusiveMap.Name = "_exclusiveMap";
            this._exclusiveMap.Size = new System.Drawing.Size(893, 772);
            this._exclusiveMap.TabIndex = 0;
            this._exclusiveMap.TabStop = false;
            // 
            // PatrolSim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(2976, 1723);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.pictRealWorld);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PatrolSim";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "PatrolSim";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PatrolSim_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictRealWorld)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._simulateMap)).EndInit();
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._realMap)).EndInit();
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._exclusiveMap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newScenarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openScenarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveScenarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simulationControlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simulationStartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simulaitionPauseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simulationResumeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simulationStopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simulationRatioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem analysisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem realTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ratio05XToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ratio50XToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ratio100XToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem timedAnaysisToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ToolStripMenuItem bestEffortToolStripMenuItem;
        private System.Windows.Forms.ListBox realLog;
        private System.Windows.Forms.ListBox simLog;
        private Nevron.Chart.WinForm.NChartControl chartRealWorld;
        private System.Windows.Forms.PictureBox pictRealWorld;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.PictureBox _simulateMap;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.PictureBox _realMap;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.PictureBox _exclusiveMap;
    }
}

