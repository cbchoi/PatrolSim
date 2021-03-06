﻿namespace PatrolSim
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
            this.openScenarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aisCrashlStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this._simulationInfoBox = new System.Windows.Forms.ListBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this._radarInfoBox = new System.Windows.Forms.ListBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this._filteredInfoBox = new System.Windows.Forms.ListBox();
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
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox10.SuspendLayout();
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
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1917, 40);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openScenarioToolStripMenuItem,
            this.aisCrashlStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(64, 36);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openScenarioToolStripMenuItem
            // 
            this.openScenarioToolStripMenuItem.Name = "openScenarioToolStripMenuItem";
            this.openScenarioToolStripMenuItem.Size = new System.Drawing.Size(271, 38);
            this.openScenarioToolStripMenuItem.Text = "Open Scenario";
            this.openScenarioToolStripMenuItem.Click += new System.EventHandler(this.openScenarioToolStripMenuItem_Click);
            // 
            // aisCrashlStripMenuItem
            // 
            this.aisCrashlStripMenuItem.Name = "aisCrashlStripMenuItem";
            this.aisCrashlStripMenuItem.Size = new System.Drawing.Size(271, 38);
            this.aisCrashlStripMenuItem.Text = "AIS Crash";
            this.aisCrashlStripMenuItem.Click += new System.EventHandler(this.aisCrashlStripMenuItem_Click);
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
            this.realLog.Location = new System.Drawing.Point(27, 46);
            this.realLog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.realLog.Name = "realLog";
            this.realLog.Size = new System.Drawing.Size(700, 279);
            this.realLog.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.realLog);
            this.groupBox1.Location = new System.Drawing.Point(1541, 444);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(749, 350);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Interpreted AIVDM Messagers";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.simLog);
            this.groupBox2.Location = new System.Drawing.Point(1541, 44);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(749, 350);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "AIVDM Messages";
            // 
            // simLog
            // 
            this.simLog.FormattingEnabled = true;
            this.simLog.HorizontalScrollbar = true;
            this.simLog.ItemHeight = 25;
            this.simLog.Location = new System.Drawing.Point(27, 42);
            this.simLog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.simLog.Name = "simLog";
            this.simLog.Size = new System.Drawing.Size(700, 279);
            this.simLog.TabIndex = 4;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chartRealWorld);
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Location = new System.Drawing.Point(773, 44);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Size = new System.Drawing.Size(749, 750);
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
            this.chartRealWorld.Location = new System.Drawing.Point(36, 29);
            this.chartRealWorld.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chartRealWorld.Name = "chartRealWorld";
            this.chartRealWorld.Size = new System.Drawing.Size(699, 700);
            this.chartRealWorld.State = ((Nevron.Chart.WinForm.NState)(resources.GetObject("chartRealWorld.State")));
            this.chartRealWorld.TabIndex = 1;
            this.chartRealWorld.Text = "SimulationMap";
            this.chartRealWorld.Click += new System.EventHandler(this.chartRealWorld_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Location = new System.Drawing.Point(0, 808);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox5.Size = new System.Drawing.Size(943, 833);
            this.groupBox5.TabIndex = 10;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "groupBox5";
            // 
            // pictRealWorld
            // 
            this.pictRealWorld.Image = ((System.Drawing.Image)(resources.GetObject("pictRealWorld.Image")));
            this.pictRealWorld.Location = new System.Drawing.Point(29, 52);
            this.pictRealWorld.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictRealWorld.Name = "pictRealWorld";
            this.pictRealWorld.Size = new System.Drawing.Size(723, 721);
            this.pictRealWorld.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictRealWorld.TabIndex = 2;
            this.pictRealWorld.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this._simulateMap);
            this.groupBox3.Location = new System.Drawing.Point(29, 810);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(749, 750);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "AIS + Simulated Data (Cellularized)";
            // 
            // _simulateMap
            // 
            this._simulateMap.BackColor = System.Drawing.Color.White;
            this._simulateMap.Location = new System.Drawing.Point(24, 29);
            this._simulateMap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._simulateMap.Name = "_simulateMap";
            this._simulateMap.Size = new System.Drawing.Size(699, 700);
            this._simulateMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this._simulateMap.TabIndex = 0;
            this._simulateMap.TabStop = false;
            this._simulateMap.Paint += new System.Windows.Forms.PaintEventHandler(this._simulateMap_Paint);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this._realMap);
            this.groupBox7.Location = new System.Drawing.Point(785, 810);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox7.Size = new System.Drawing.Size(749, 750);
            this.groupBox7.TabIndex = 9;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Radar Data (Cellularized)";
            // 
            // _realMap
            // 
            this._realMap.BackColor = System.Drawing.Color.White;
            this._realMap.Location = new System.Drawing.Point(24, 29);
            this._realMap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._realMap.Name = "_realMap";
            this._realMap.Size = new System.Drawing.Size(699, 700);
            this._realMap.TabIndex = 0;
            this._realMap.TabStop = false;
            this._realMap.Paint += new System.Windows.Forms.PaintEventHandler(this._realMap_Paint);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this._exclusiveMap);
            this.groupBox6.Location = new System.Drawing.Point(1541, 810);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox6.Size = new System.Drawing.Size(749, 750);
            this.groupBox6.TabIndex = 10;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Exclusive Data (Cellularized)";
            // 
            // _exclusiveMap
            // 
            this._exclusiveMap.BackColor = System.Drawing.Color.White;
            this._exclusiveMap.Location = new System.Drawing.Point(27, 29);
            this._exclusiveMap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._exclusiveMap.Name = "_exclusiveMap";
            this._exclusiveMap.Size = new System.Drawing.Size(699, 700);
            this._exclusiveMap.TabIndex = 0;
            this._exclusiveMap.TabStop = false;
            this._exclusiveMap.Paint += new System.Windows.Forms.PaintEventHandler(this._exclusiveMap_Paint);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this._simulationInfoBox);
            this.groupBox8.Location = new System.Drawing.Point(29, 1567);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox8.Size = new System.Drawing.Size(749, 171);
            this.groupBox8.TabIndex = 11;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Simulation Model Infomation";
            // 
            // _simulationInfoBox
            // 
            this._simulationInfoBox.FormattingEnabled = true;
            this._simulationInfoBox.HorizontalScrollbar = true;
            this._simulationInfoBox.ItemHeight = 25;
            this._simulationInfoBox.Location = new System.Drawing.Point(24, 40);
            this._simulationInfoBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._simulationInfoBox.Name = "_simulationInfoBox";
            this._simulationInfoBox.Size = new System.Drawing.Size(700, 104);
            this._simulationInfoBox.TabIndex = 4;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this._radarInfoBox);
            this.groupBox9.Location = new System.Drawing.Point(785, 1567);
            this.groupBox9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox9.Size = new System.Drawing.Size(749, 171);
            this.groupBox9.TabIndex = 12;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Radar Information";
            // 
            // _radarInfoBox
            // 
            this._radarInfoBox.FormattingEnabled = true;
            this._radarInfoBox.HorizontalScrollbar = true;
            this._radarInfoBox.ItemHeight = 25;
            this._radarInfoBox.Location = new System.Drawing.Point(24, 40);
            this._radarInfoBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._radarInfoBox.Name = "_radarInfoBox";
            this._radarInfoBox.Size = new System.Drawing.Size(700, 104);
            this._radarInfoBox.TabIndex = 4;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this._filteredInfoBox);
            this.groupBox10.Location = new System.Drawing.Point(1541, 1567);
            this.groupBox10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox10.Size = new System.Drawing.Size(749, 171);
            this.groupBox10.TabIndex = 13;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Filtered Information";
            // 
            // _filteredInfoBox
            // 
            this._filteredInfoBox.FormattingEnabled = true;
            this._filteredInfoBox.HorizontalScrollbar = true;
            this._filteredInfoBox.ItemHeight = 25;
            this._filteredInfoBox.Location = new System.Drawing.Point(27, 40);
            this._filteredInfoBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._filteredInfoBox.Name = "_filteredInfoBox";
            this._filteredInfoBox.Size = new System.Drawing.Size(700, 104);
            this._filteredInfoBox.TabIndex = 4;
            // 
            // PatrolSim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1917, 1750);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.pictRealWorld);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.groupBox8.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openScenarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aisCrashlStripMenuItem;
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
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.ListBox _simulationInfoBox;
        private System.Windows.Forms.ListBox _radarInfoBox;
        private System.Windows.Forms.ListBox _filteredInfoBox;
        private System.Windows.Forms.PictureBox _simulateMap;
        private System.Windows.Forms.PictureBox _realMap;
        private System.Windows.Forms.PictureBox _exclusiveMap;
    }
}

