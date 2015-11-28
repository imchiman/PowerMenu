namespace PowerMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.sbrInformation = new System.Windows.Forms.StatusStrip();
            this.tlblWindowsVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnShutDown = new System.Windows.Forms.Button();
            this.btnRestart = new System.Windows.Forms.Button();
            this.btnLogOff = new System.Windows.Forms.Button();
            this.btnLock = new System.Windows.Forms.Button();
            this.gbxOption = new System.Windows.Forms.GroupBox();
            this.lblWaitTime = new System.Windows.Forms.Label();
            this.cbxWaitTime = new System.Windows.Forms.ComboBox();
            this.cbxShowConfirmMsg = new System.Windows.Forms.CheckBox();
            this.mspMenu = new System.Windows.Forms.MenuStrip();
            this.tmiControl = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiLang = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiEng = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiZH = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiRestoreSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiViewHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSleep = new System.Windows.Forms.Button();
            this.btnHibernate = new System.Windows.Forms.Button();
            this.llbDeveloper = new System.Windows.Forms.LinkLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.sbrInformation.SuspendLayout();
            this.gbxOption.SuspendLayout();
            this.mspMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // sbrInformation
            // 
            this.sbrInformation.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.sbrInformation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlblWindowsVersion});
            resources.ApplyResources(this.sbrInformation, "sbrInformation");
            this.sbrInformation.Name = "sbrInformation";
            this.sbrInformation.SizingGrip = false;
            // 
            // tlblWindowsVersion
            // 
            this.tlblWindowsVersion.Name = "tlblWindowsVersion";
            resources.ApplyResources(this.tlblWindowsVersion, "tlblWindowsVersion");
            // 
            // btnShutDown
            // 
            resources.ApplyResources(this.btnShutDown, "btnShutDown");
            this.btnShutDown.Name = "btnShutDown";
            this.btnShutDown.UseVisualStyleBackColor = true;
            this.btnShutDown.Click += new System.EventHandler(this.btnShutDown_Click);
            // 
            // btnRestart
            // 
            resources.ApplyResources(this.btnRestart, "btnRestart");
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // btnLogOff
            // 
            resources.ApplyResources(this.btnLogOff, "btnLogOff");
            this.btnLogOff.Name = "btnLogOff";
            this.btnLogOff.UseVisualStyleBackColor = true;
            this.btnLogOff.Click += new System.EventHandler(this.btnLogOff_Click);
            // 
            // btnLock
            // 
            resources.ApplyResources(this.btnLock, "btnLock");
            this.btnLock.Name = "btnLock";
            this.btnLock.UseVisualStyleBackColor = true;
            this.btnLock.Click += new System.EventHandler(this.btnLock_Click);
            // 
            // gbxOption
            // 
            this.gbxOption.Controls.Add(this.lblWaitTime);
            this.gbxOption.Controls.Add(this.cbxWaitTime);
            this.gbxOption.Controls.Add(this.cbxShowConfirmMsg);
            resources.ApplyResources(this.gbxOption, "gbxOption");
            this.gbxOption.Name = "gbxOption";
            this.gbxOption.TabStop = false;
            // 
            // lblWaitTime
            // 
            resources.ApplyResources(this.lblWaitTime, "lblWaitTime");
            this.lblWaitTime.Name = "lblWaitTime";
            // 
            // cbxWaitTime
            // 
            this.cbxWaitTime.Cursor = System.Windows.Forms.Cursors.Default;
            this.cbxWaitTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxWaitTime.Items.AddRange(new object[] {
            resources.GetString("cbxWaitTime.Items"),
            resources.GetString("cbxWaitTime.Items1"),
            resources.GetString("cbxWaitTime.Items2"),
            resources.GetString("cbxWaitTime.Items3"),
            resources.GetString("cbxWaitTime.Items4"),
            resources.GetString("cbxWaitTime.Items5"),
            resources.GetString("cbxWaitTime.Items6"),
            resources.GetString("cbxWaitTime.Items7")});
            resources.ApplyResources(this.cbxWaitTime, "cbxWaitTime");
            this.cbxWaitTime.Name = "cbxWaitTime";
            // 
            // cbxShowConfirmMsg
            // 
            resources.ApplyResources(this.cbxShowConfirmMsg, "cbxShowConfirmMsg");
            this.cbxShowConfirmMsg.Name = "cbxShowConfirmMsg";
            this.cbxShowConfirmMsg.UseVisualStyleBackColor = true;
            // 
            // mspMenu
            // 
            this.mspMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mspMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiControl,
            this.tmiHelp});
            resources.ApplyResources(this.mspMenu, "mspMenu");
            this.mspMenu.Name = "mspMenu";
            // 
            // tmiControl
            // 
            this.tmiControl.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tmiControl.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiLang,
            this.tmiRestoreSetting,
            this.tmiExit});
            this.tmiControl.Name = "tmiControl";
            resources.ApplyResources(this.tmiControl, "tmiControl");
            // 
            // tmiLang
            // 
            this.tmiLang.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tmiLang.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiEng,
            this.tmiZH});
            this.tmiLang.Name = "tmiLang";
            resources.ApplyResources(this.tmiLang, "tmiLang");
            // 
            // tmiEng
            // 
            this.tmiEng.Name = "tmiEng";
            resources.ApplyResources(this.tmiEng, "tmiEng");
            this.tmiEng.Click += new System.EventHandler(this.tmiEng_Click);
            // 
            // tmiZH
            // 
            this.tmiZH.Name = "tmiZH";
            resources.ApplyResources(this.tmiZH, "tmiZH");
            this.tmiZH.Click += new System.EventHandler(this.tmiZH_Click);
            // 
            // tmiRestoreSetting
            // 
            this.tmiRestoreSetting.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tmiRestoreSetting.Name = "tmiRestoreSetting";
            resources.ApplyResources(this.tmiRestoreSetting, "tmiRestoreSetting");
            this.tmiRestoreSetting.Click += new System.EventHandler(this.tmiRestoreSetting_Click);
            // 
            // tmiExit
            // 
            this.tmiExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tmiExit.Name = "tmiExit";
            resources.ApplyResources(this.tmiExit, "tmiExit");
            this.tmiExit.Click += new System.EventHandler(this.tmiExit_Click);
            // 
            // tmiHelp
            // 
            this.tmiHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiViewHelp,
            this.tmiAbout});
            this.tmiHelp.Name = "tmiHelp";
            resources.ApplyResources(this.tmiHelp, "tmiHelp");
            // 
            // tmiViewHelp
            // 
            resources.ApplyResources(this.tmiViewHelp, "tmiViewHelp");
            this.tmiViewHelp.Name = "tmiViewHelp";
            // 
            // tmiAbout
            // 
            this.tmiAbout.Name = "tmiAbout";
            resources.ApplyResources(this.tmiAbout, "tmiAbout");
            this.tmiAbout.Click += new System.EventHandler(this.tmiAbout_Click);
            // 
            // btnSleep
            // 
            resources.ApplyResources(this.btnSleep, "btnSleep");
            this.btnSleep.Name = "btnSleep";
            this.btnSleep.UseVisualStyleBackColor = true;
            this.btnSleep.Click += new System.EventHandler(this.btnSleep_Click);
            // 
            // btnHibernate
            // 
            resources.ApplyResources(this.btnHibernate, "btnHibernate");
            this.btnHibernate.Name = "btnHibernate";
            this.btnHibernate.UseVisualStyleBackColor = true;
            this.btnHibernate.Click += new System.EventHandler(this.btnHibernate_Click);
            // 
            // llbDeveloper
            // 
            resources.ApplyResources(this.llbDeveloper, "llbDeveloper");
            this.llbDeveloper.Name = "llbDeveloper";
            this.llbDeveloper.TabStop = true;
            this.llbDeveloper.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbDeveloper_LinkClicked);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.llbDeveloper);
            this.Controls.Add(this.btnHibernate);
            this.Controls.Add(this.btnSleep);
            this.Controls.Add(this.gbxOption);
            this.Controls.Add(this.btnLock);
            this.Controls.Add(this.sbrInformation);
            this.Controls.Add(this.mspMenu);
            this.Controls.Add(this.btnLogOff);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.btnShutDown);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.mspMenu;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Opacity = 0.9D;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.sbrInformation.ResumeLayout(false);
            this.sbrInformation.PerformLayout();
            this.gbxOption.ResumeLayout(false);
            this.gbxOption.PerformLayout();
            this.mspMenu.ResumeLayout(false);
            this.mspMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip sbrInformation;
        private System.Windows.Forms.ToolStripStatusLabel tlblWindowsVersion;
        private System.Windows.Forms.Button btnShutDown;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Button btnLogOff;
        private System.Windows.Forms.Button btnLock;
        private System.Windows.Forms.GroupBox gbxOption;
        private System.Windows.Forms.CheckBox cbxShowConfirmMsg;
        private System.Windows.Forms.ComboBox cbxWaitTime;
        private System.Windows.Forms.Label lblWaitTime;
        private System.Windows.Forms.MenuStrip mspMenu;
        private System.Windows.Forms.ToolStripMenuItem tmiControl;
        private System.Windows.Forms.ToolStripMenuItem tmiLang;
        private System.Windows.Forms.ToolStripMenuItem tmiEng;
        private System.Windows.Forms.ToolStripMenuItem tmiZH;
        private System.Windows.Forms.ToolStripMenuItem tmiExit;
        private System.Windows.Forms.ToolStripMenuItem tmiHelp;
        private System.Windows.Forms.ToolStripMenuItem tmiViewHelp;
        private System.Windows.Forms.ToolStripMenuItem tmiAbout;
        private System.Windows.Forms.ToolStripMenuItem tmiRestoreSetting;
        private System.Windows.Forms.Button btnSleep;
        private System.Windows.Forms.Button btnHibernate;
        private System.Windows.Forms.LinkLabel llbDeveloper;
        private System.Windows.Forms.ToolTip toolTip;
    }
}

