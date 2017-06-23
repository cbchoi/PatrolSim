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
            this.chartSimulation = new Nevron.Chart.WinForm.NChartControl();
            this.realLog = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.simLog = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chartRealWorld = new Nevron.Chart.WinForm.NChartControl();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
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
            this.menuStrip1.Size = new System.Drawing.Size(2022, 40);
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
            // 
            // simulationResumeToolStripMenuItem
            // 
            this.simulationResumeToolStripMenuItem.Name = "simulationResumeToolStripMenuItem";
            this.simulationResumeToolStripMenuItem.Size = new System.Drawing.Size(319, 38);
            this.simulationResumeToolStripMenuItem.Text = "Simulation Resume";
            // 
            // simulationStopToolStripMenuItem
            // 
            this.simulationStopToolStripMenuItem.Name = "simulationStopToolStripMenuItem";
            this.simulationStopToolStripMenuItem.Size = new System.Drawing.Size(319, 38);
            this.simulationStopToolStripMenuItem.Text = "Simulation Stop";
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
            this.ratio05XToolStripMenuItem.Click += new System.EventHandler(this.ratio10XToolStripMenuItem_Click);
            // 
            // ratio50XToolStripMenuItem1
            // 
            this.ratio50XToolStripMenuItem1.Name = "ratio50XToolStripMenuItem1";
            this.ratio50XToolStripMenuItem1.Size = new System.Drawing.Size(231, 38);
            this.ratio50XToolStripMenuItem1.Text = "Ratio:5.0X";
            // 
            // ratio100XToolStripMenuItem
            // 
            this.ratio100XToolStripMenuItem.Name = "ratio100XToolStripMenuItem";
            this.ratio100XToolStripMenuItem.Size = new System.Drawing.Size(231, 38);
            this.ratio100XToolStripMenuItem.Text = "Ratio:10.0X";
            // 
            // bestEffortToolStripMenuItem
            // 
            this.bestEffortToolStripMenuItem.Name = "bestEffortToolStripMenuItem";
            this.bestEffortToolStripMenuItem.Size = new System.Drawing.Size(231, 38);
            this.bestEffortToolStripMenuItem.Text = "Best Effort";
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
            // chartSimulation
            // 
            this.chartSimulation.AutoRefresh = false;
            this.chartSimulation.BackColor = System.Drawing.SystemColors.Control;
            this.chartSimulation.InputKeys = new System.Windows.Forms.Keys[0];
            this.chartSimulation.Location = new System.Drawing.Point(41, 42);
            this.chartSimulation.Name = "chartSimulation";
            this.chartSimulation.Size = new System.Drawing.Size(900, 900);
            this.chartSimulation.State = ((Nevron.Chart.WinForm.NState)(resources.GetObject("chartSimulation.State")));
            this.chartSimulation.TabIndex = 1;
            this.chartSimulation.Text = "SimulationMap";
            this.chartSimulation.Click += new System.EventHandler(this.chartSimulation_Click);
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
            this.groupBox1.Location = new System.Drawing.Point(1012, 1040);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(987, 391);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Real World Log";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.simLog);
            this.groupBox2.Location = new System.Drawing.Point(17, 1040);
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chartSimulation);
            this.groupBox3.Location = new System.Drawing.Point(17, 43);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(987, 975);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Simulation Map";
            this.groupBox3.UseCompatibleTextRendering = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chartRealWorld);
            this.groupBox4.Location = new System.Drawing.Point(1012, 43);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(987, 975);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Real World Map";
            this.groupBox4.UseCompatibleTextRendering = true;
            // 
            // chartRealWorld
            // 
            this.chartRealWorld.AutoRefresh = false;
            this.chartRealWorld.BackColor = System.Drawing.SystemColors.Control;
            this.chartRealWorld.InputKeys = new System.Windows.Forms.Keys[0];
            this.chartRealWorld.Location = new System.Drawing.Point(41, 42);
            this.chartRealWorld.Name = "chartRealWorld";
            this.chartRealWorld.Size = new System.Drawing.Size(900, 900);
            this.chartRealWorld.State = ((Nevron.Chart.WinForm.NState)(resources.GetObject("chartRealWorld.State")));
            this.chartRealWorld.TabIndex = 1;
            this.chartRealWorld.Text = "SimulationMap";
            this.chartRealWorld.Click += new System.EventHandler(this.chartRealWorld_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(948, 1437);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 32);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PatrolSim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(2022, 1481);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PatrolSim";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "PatrolSim";
            this.Load += new System.EventHandler(this.PatrolSim_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem bestEffortToolStripMenuItem;
        private Nevron.Chart.WinForm.NChartControl chartSimulation;
        private System.Windows.Forms.ListBox realLog;
        private System.Windows.Forms.ListBox simLog;
        private Nevron.Chart.WinForm.NChartControl chartRealWorld;
    }
}

