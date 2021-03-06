﻿namespace ModEditor
{
    partial class MainForm
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
			this.components = new System.ComponentModel.Container();
			WeifenLuo.WinFormsUI.Docking.DockPanelSkin dockPanelSkin1 = new WeifenLuo.WinFormsUI.Docking.DockPanelSkin();
			WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin autoHideStripSkin1 = new WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin();
			WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient1 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
			WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient1 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
			WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin dockPaneStripSkin1 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin();
			WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient dockPaneStripGradient1 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient();
			WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient2 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
			WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient2 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
			WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient3 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
			WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient dockPaneStripToolWindowGradient1 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient();
			WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient4 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
			WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient5 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
			WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient3 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
			WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient6 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
			WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient7 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fILEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadBaseDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.newModToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openModToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.eDITToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.vIEWToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.logViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.modExplorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.errorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tOOLSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.checkDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.checkExternalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.hELPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.statusGeneral = new System.Windows.Forms.ToolStripStatusLabel();
			this.statusModPath = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripProgress = new System.Windows.Forms.ToolStripProgressBar();
			this.GenericObjectsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.TimerCheckExternalModifications = new System.Windows.Forms.Timer(this.components);
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.workArea = new WeifenLuo.WinFormsUI.Docking.DockPanel();
			this.menuStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fILEToolStripMenuItem,
            this.eDITToolStripMenuItem,
            this.vIEWToolStripMenuItem,
            this.tOOLSToolStripMenuItem,
            this.hELPToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(706, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fILEToolStripMenuItem
			// 
			this.fILEToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadBaseDataToolStripMenuItem,
            this.toolStripSeparator3,
            this.newModToolStripMenuItem,
            this.openModToolStripMenuItem,
            this.toolStripSeparator1,
            this.saveToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
			this.fILEToolStripMenuItem.Name = "fILEToolStripMenuItem";
			this.fILEToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
			this.fILEToolStripMenuItem.Text = "FILE";
			// 
			// loadBaseDataToolStripMenuItem
			// 
			this.loadBaseDataToolStripMenuItem.Name = "loadBaseDataToolStripMenuItem";
			this.loadBaseDataToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.loadBaseDataToolStripMenuItem.Text = "Load base data";
			this.loadBaseDataToolStripMenuItem.Click += new System.EventHandler(this.loadBaseDataToolStripMenuItem_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(149, 6);
			// 
			// newModToolStripMenuItem
			// 
			this.newModToolStripMenuItem.Name = "newModToolStripMenuItem";
			this.newModToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.newModToolStripMenuItem.Text = "New Mod";
			this.newModToolStripMenuItem.Click += new System.EventHandler(this.newModToolStripMenuItem_Click);
			// 
			// openModToolStripMenuItem
			// 
			this.openModToolStripMenuItem.Name = "openModToolStripMenuItem";
			this.openModToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.openModToolStripMenuItem.Text = "Open Mod";
			this.openModToolStripMenuItem.Click += new System.EventHandler(this.openModToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.saveToolStripMenuItem.Text = "Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// eDITToolStripMenuItem
			// 
			this.eDITToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem});
			this.eDITToolStripMenuItem.Name = "eDITToolStripMenuItem";
			this.eDITToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
			this.eDITToolStripMenuItem.Text = "EDIT";
			// 
			// undoToolStripMenuItem
			// 
			this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
			this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
			this.undoToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
			this.undoToolStripMenuItem.Text = "Undo";
			// 
			// redoToolStripMenuItem
			// 
			this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
			this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
			this.redoToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
			this.redoToolStripMenuItem.Text = "Redo";
			// 
			// vIEWToolStripMenuItem
			// 
			this.vIEWToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logViewToolStripMenuItem,
            this.modExplorerToolStripMenuItem,
            this.errorsToolStripMenuItem});
			this.vIEWToolStripMenuItem.Name = "vIEWToolStripMenuItem";
			this.vIEWToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
			this.vIEWToolStripMenuItem.Text = "VIEW";
			// 
			// logViewToolStripMenuItem
			// 
			this.logViewToolStripMenuItem.CheckOnClick = true;
			this.logViewToolStripMenuItem.Name = "logViewToolStripMenuItem";
			this.logViewToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
			this.logViewToolStripMenuItem.Text = "Log";
			this.logViewToolStripMenuItem.CheckedChanged += new System.EventHandler(this.logViewToolStripMenuItem_CheckedChanged);
			// 
			// modExplorerToolStripMenuItem
			// 
			this.modExplorerToolStripMenuItem.CheckOnClick = true;
			this.modExplorerToolStripMenuItem.Name = "modExplorerToolStripMenuItem";
			this.modExplorerToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
			this.modExplorerToolStripMenuItem.Text = "Mod Explorer";
			this.modExplorerToolStripMenuItem.CheckedChanged += new System.EventHandler(this.modExplorerToolStripMenuItem_CheckedChanged);
			// 
			// errorsToolStripMenuItem
			// 
			this.errorsToolStripMenuItem.CheckOnClick = true;
			this.errorsToolStripMenuItem.Name = "errorsToolStripMenuItem";
			this.errorsToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
			this.errorsToolStripMenuItem.Text = "Errors";
			this.errorsToolStripMenuItem.CheckedChanged += new System.EventHandler(this.errorsToolStripMenuItem_CheckedChanged);
			// 
			// tOOLSToolStripMenuItem
			// 
			this.tOOLSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runToolStripMenuItem,
            this.checkDataToolStripMenuItem,
            this.checkExternalToolStripMenuItem,
            this.settingsToolStripMenuItem});
			this.tOOLSToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
			this.tOOLSToolStripMenuItem.Name = "tOOLSToolStripMenuItem";
			this.tOOLSToolStripMenuItem.ShortcutKeyDisplayString = "";
			this.tOOLSToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
			this.tOOLSToolStripMenuItem.Text = "TOOLS";
			// 
			// runToolStripMenuItem
			// 
			this.runToolStripMenuItem.Name = "runToolStripMenuItem";
			this.runToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
			this.runToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.runToolStripMenuItem.Text = "Run";
			this.runToolStripMenuItem.Click += new System.EventHandler(this.runToolStripMenuItem_Click);
			// 
			// checkDataToolStripMenuItem
			// 
			this.checkDataToolStripMenuItem.Name = "checkDataToolStripMenuItem";
			this.checkDataToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.checkDataToolStripMenuItem.Text = "Check data";
			this.checkDataToolStripMenuItem.Click += new System.EventHandler(this.checkDataToolStripMenuItem_Click);
			// 
			// checkExternalToolStripMenuItem
			// 
			this.checkExternalToolStripMenuItem.Name = "checkExternalToolStripMenuItem";
			this.checkExternalToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.checkExternalToolStripMenuItem.Text = "Check external";
			this.checkExternalToolStripMenuItem.Click += new System.EventHandler(this.checkExternalToolStripMenuItem_Click);
			// 
			// settingsToolStripMenuItem
			// 
			this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			this.settingsToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.settingsToolStripMenuItem.Text = "Settings";
			// 
			// hELPToolStripMenuItem
			// 
			this.hELPToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
			this.hELPToolStripMenuItem.Name = "hELPToolStripMenuItem";
			this.hELPToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
			this.hELPToolStripMenuItem.Text = "HELP";
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.aboutToolStripMenuItem.Text = "About";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusGeneral,
            this.statusModPath,
            this.toolStripProgress});
			this.statusStrip1.Location = new System.Drawing.Point(0, 459);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(706, 22);
			this.statusStrip1.TabIndex = 1;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// statusGeneral
			// 
			this.statusGeneral.Name = "statusGeneral";
			this.statusGeneral.Size = new System.Drawing.Size(38, 17);
			this.statusGeneral.Text = "Status";
			// 
			// statusModPath
			// 
			this.statusModPath.Name = "statusModPath";
			this.statusModPath.Size = new System.Drawing.Size(44, 17);
			this.statusModPath.Text = "no path";
			// 
			// toolStripProgress
			// 
			this.toolStripProgress.Name = "toolStripProgress";
			this.toolStripProgress.Size = new System.Drawing.Size(100, 16);
			this.toolStripProgress.Visible = false;
			// 
			// GenericObjectsMenu
			// 
			this.GenericObjectsMenu.Name = "GenericObjectsMenu";
			this.GenericObjectsMenu.Size = new System.Drawing.Size(61, 4);
			// 
			// TimerCheckExternalModifications
			// 
			this.TimerCheckExternalModifications.Enabled = true;
			this.TimerCheckExternalModifications.Interval = 5000;
			this.TimerCheckExternalModifications.Tick += new System.EventHandler(this.CheckExternalModifications_Tick);
			// 
			// workArea
			// 
			this.workArea.Dock = System.Windows.Forms.DockStyle.Fill;
			this.workArea.DockBackColor = System.Drawing.SystemColors.AppWorkspace;
			this.workArea.DockBottomPortion = 150D;
			this.workArea.DockLeftPortion = 200D;
			this.workArea.DockRightPortion = 200D;
			this.workArea.DockTopPortion = 150D;
			this.workArea.Location = new System.Drawing.Point(0, 24);
			this.workArea.Name = "workArea";
			this.workArea.Size = new System.Drawing.Size(706, 435);
			dockPanelGradient1.EndColor = System.Drawing.SystemColors.ControlLight;
			dockPanelGradient1.StartColor = System.Drawing.SystemColors.ControlLight;
			autoHideStripSkin1.DockStripGradient = dockPanelGradient1;
			tabGradient1.EndColor = System.Drawing.SystemColors.Control;
			tabGradient1.StartColor = System.Drawing.SystemColors.Control;
			tabGradient1.TextColor = System.Drawing.SystemColors.ControlDarkDark;
			autoHideStripSkin1.TabGradient = tabGradient1;
			autoHideStripSkin1.TextFont = new System.Drawing.Font("Tahoma", 8.25F);
			dockPanelSkin1.AutoHideStripSkin = autoHideStripSkin1;
			tabGradient2.EndColor = System.Drawing.SystemColors.ControlLightLight;
			tabGradient2.StartColor = System.Drawing.SystemColors.ControlLightLight;
			tabGradient2.TextColor = System.Drawing.SystemColors.ControlText;
			dockPaneStripGradient1.ActiveTabGradient = tabGradient2;
			dockPanelGradient2.EndColor = System.Drawing.SystemColors.Control;
			dockPanelGradient2.StartColor = System.Drawing.SystemColors.Control;
			dockPaneStripGradient1.DockStripGradient = dockPanelGradient2;
			tabGradient3.EndColor = System.Drawing.SystemColors.ControlLight;
			tabGradient3.StartColor = System.Drawing.SystemColors.ControlLight;
			tabGradient3.TextColor = System.Drawing.SystemColors.ControlText;
			dockPaneStripGradient1.InactiveTabGradient = tabGradient3;
			dockPaneStripSkin1.DocumentGradient = dockPaneStripGradient1;
			dockPaneStripSkin1.TextFont = new System.Drawing.Font("Tahoma", 8.25F);
			tabGradient4.EndColor = System.Drawing.SystemColors.ActiveCaption;
			tabGradient4.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			tabGradient4.StartColor = System.Drawing.SystemColors.GradientActiveCaption;
			tabGradient4.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
			dockPaneStripToolWindowGradient1.ActiveCaptionGradient = tabGradient4;
			tabGradient5.EndColor = System.Drawing.SystemColors.Control;
			tabGradient5.StartColor = System.Drawing.SystemColors.Control;
			tabGradient5.TextColor = System.Drawing.SystemColors.ControlText;
			dockPaneStripToolWindowGradient1.ActiveTabGradient = tabGradient5;
			dockPanelGradient3.EndColor = System.Drawing.SystemColors.ControlLight;
			dockPanelGradient3.StartColor = System.Drawing.SystemColors.ControlLight;
			dockPaneStripToolWindowGradient1.DockStripGradient = dockPanelGradient3;
			tabGradient6.EndColor = System.Drawing.SystemColors.GradientInactiveCaption;
			tabGradient6.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			tabGradient6.StartColor = System.Drawing.SystemColors.GradientInactiveCaption;
			tabGradient6.TextColor = System.Drawing.SystemColors.ControlText;
			dockPaneStripToolWindowGradient1.InactiveCaptionGradient = tabGradient6;
			tabGradient7.EndColor = System.Drawing.Color.Transparent;
			tabGradient7.StartColor = System.Drawing.Color.Transparent;
			tabGradient7.TextColor = System.Drawing.SystemColors.ControlDarkDark;
			dockPaneStripToolWindowGradient1.InactiveTabGradient = tabGradient7;
			dockPaneStripSkin1.ToolWindowGradient = dockPaneStripToolWindowGradient1;
			dockPanelSkin1.DockPaneStripSkin = dockPaneStripSkin1;
			this.workArea.Skin = dockPanelSkin1;
			this.workArea.TabIndex = 3;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(706, 481);
			this.Controls.Add(this.workArea);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.IsMdiContainer = true;
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.Text = "StarDrive Mod Editor";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fILEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openModToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem hELPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel statusGeneral;
        private System.Windows.Forms.ToolStripStatusLabel statusModPath;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem loadBaseDataToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip GenericObjectsMenu;
        private System.Windows.Forms.ToolStripMenuItem newModToolStripMenuItem;
        private System.Windows.Forms.Timer TimerCheckExternalModifications;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tOOLSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eDITToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private WeifenLuo.WinFormsUI.Docking.DockPanel workArea;
        private System.Windows.Forms.ToolStripMenuItem checkExternalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vIEWToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modExplorerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem errorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgress;
    }
}

