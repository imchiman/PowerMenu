using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Management;
using System.Resources;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace PowerMenu
{
    public partial class MainForm : Form
    {
        [DllImport("user32.dll")]
        public static extern void LockWorkStation();

        [DllImport("powrprof.dll")]
        public static extern bool IsPwrHibernateAllowed();

        [DllImport("powrprof.dll")]
        public static extern bool IsPwrSuspendAllowed();

        public enum PowerOptions
        {
            // See: http://msdn.microsoft.com/en-us/library/windows/desktop/aa394058(v=vs.85).aspx
            LOGOFF = 0,
            FORCELOGOFF = 4,
            SHUTDOWN = 1,
            FORCESHUTDOWN = 5,
            REBOOT = 2,
            FORCEREBOOT = 6,
            POWEROFF = 8,
            FORCEPOWEROFF = 12,
            LOCK = 99,
            SLEEP = 88,
            HIBERNATE = 77
        }

        ManagementBaseObject mboShutdown;
        ManagementClass mcWin32;
        ResourceManager mRM;

        public MainForm()
        {
            InitializeComponent();
            gatherAllOSInfo();
            setStatusBar();
            initWaitTimeList();
            mRM = new ResourceManager("PowerMenu.Resources.Strings", typeof(MainForm).Assembly);
            initForm();
            initToolTip();
        }

        protected void initWMI()
        {
            if (mcWin32 == null)
                mcWin32 = new ManagementClass("Win32_OperatingSystem");
        }

        protected void initWaitTimeList()
        {
            if (Utility.isNT6OrAbove(getOSInfo(OSInfo.Version)))
            {
                cbxWaitTime.Enabled = true;
                cbxWaitTime.SelectedIndex = (int)Utility.getSettingValue("waitTime");
            }
            else
            {
                cbxWaitTime.Enabled = false;
            }
        }

        protected void initForm()
        {            
            cbxShowConfirmMsg.Checked = (bool)Utility.getSettingValue("showConfirm");
            string lang = (string)Utility.getSettingValue("lang");
            if (lang.Equals("zh-HK"))
            {
                tmiZH.Checked = true;
                tmiEng.Checked = false;
            }
            else
            {
                tmiZH.Checked = false;
                tmiEng.Checked = true;
            }

            if (IsPwrHibernateAllowed())
                btnHibernate.Enabled = true;
            else
                btnHibernate.Enabled = false;

            if (IsPwrSuspendAllowed())
                btnSleep.Enabled = true;
            else
                btnSleep.Enabled = false;

            RuntimeLocalizer.ChangeCulture(this, lang);
        }

        protected void initToolTip()
        {
            toolTip.SetToolTip(btnShutDown, RuntimeLocalizer.getString(mRM, "tsShutdown"));
            toolTip.SetToolTip(btnRestart, RuntimeLocalizer.getString(mRM, "tsReboot"));
            toolTip.SetToolTip(btnLogOff, RuntimeLocalizer.getString(mRM, "tsLogoff"));
            toolTip.SetToolTip(btnSleep, RuntimeLocalizer.getString(mRM, "tsSleep"));
            toolTip.SetToolTip(btnHibernate, RuntimeLocalizer.getString(mRM, "tsHibernate"));
            toolTip.SetToolTip(btnLock, RuntimeLocalizer.getString(mRM, "tsLock"));
            toolTip.SetToolTip(cbxShowConfirmMsg, RuntimeLocalizer.getString(mRM, "tsConfirmMsg"));
            if (Utility.isNT6OrAbove(Utility.getOSInfoByKey("Version")))
            {
                toolTip.SetToolTip(cbxWaitTime, RuntimeLocalizer.getString(mRM, "tsTimeout"));
                toolTip.SetToolTip(lblWaitTime, RuntimeLocalizer.getString(mRM, "tsTimeout"));
            }
            else
            {
                toolTip.SetToolTip(cbxWaitTime, RuntimeLocalizer.getString(mRM, "tsSupportVistaAbove"));
                toolTip.SetToolTip(lblWaitTime, RuntimeLocalizer.getString(mRM, "tsSupportVistaAbove"));
            }
        }

        protected void setStatusBar()
        {
            tlblWindowsVersion.Text = String.Format("{0}", getOSInfo(OSInfo.Caption));
        }

        protected void gatherAllOSInfo()
        {
            Utility.resetOSInfoHashTable();
            initWMI();
            foreach (ManagementObject manObj in mcWin32.GetInstances())
            {
                // See: http://msdn.microsoft.com/en-us/library/windows/desktop/aa394239(v=vs.85).aspx
                Utility.addToOSInfoHashTable("Version", manObj["Version"].ToString());
                Utility.addToOSInfoHashTable("Caption", manObj["Caption"].ToString());
            }
        }

        protected string getOSInfo(string property)
        {
            Utility.initOSInfoHashTable();

            if (Utility.getOSInfoHashTableCount() == 0)
                gatherAllOSInfo();

            if (Utility.isOSInfoContainsKey(property))
                return Utility.getOSInfoByKey(property);
            return "NULL";
        }

        protected void powerManagement(int option)
        {
            if (mcWin32 == null)
                initWMI();

            mcWin32.Scope.Options.EnablePrivileges = true;
            string classPath = String.Empty;
            ManagementBaseObject mboShutdownParams = null;

            if (Utility.isNT6OrAbove(getOSInfo(OSInfo.Version)))
            {
                // See: http://msdn.microsoft.com/en-us/library/windows/desktop/aa394057(v=vs.85).aspx
                classPath = ShutdownClassPath.NT6;
                string comment = String.Empty;
                mboShutdownParams = mcWin32.GetMethodParameters(classPath);
                mboShutdownParams["Flags"] = option.ToString();
                mboShutdownParams["ReasonCode"] = "0";
                if (option == (int)PowerOptions.REBOOT)
                    comment = RuntimeLocalizer.getString(mRM, "strRebootComment");
                else if (option == (int)PowerOptions.SHUTDOWN)
                    comment = RuntimeLocalizer.getString(mRM, "strShutdownComment");
                mboShutdownParams["Comment"] = comment;
                mboShutdownParams["Timeout"] = cbxWaitTime.SelectedItem.ToString();
            }
            else
            {
                // See: http://msdn.microsoft.com/en-us/library/windows/desktop/aa394058(v=vs.85).aspx
                classPath = ShutdownClassPath.NT5;
                mboShutdownParams = mcWin32.GetMethodParameters(classPath);
                mboShutdownParams["Flags"] = option.ToString();
                mboShutdownParams["Reserved"] = "0";
            }
            
            foreach (ManagementObject manObj in mcWin32.GetInstances())
            {
                mboShutdown = manObj.InvokeMethod(classPath, mboShutdownParams, null);
            }
        }

        private void btnShutDown_Click(object sender, EventArgs e)
        {
            if (cbxShowConfirmMsg.Checked)
            {
                if (Utility.getConfirmMsgResult(mRM, (int)PowerOptions.SHUTDOWN) == DialogResult.Yes)
                {
                    powerManagement((int)PowerOptions.SHUTDOWN);
                    Application.Exit();
                }
            }
            else
            {
                powerManagement((int)PowerOptions.SHUTDOWN);
                Application.Exit();
            }
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            if (cbxShowConfirmMsg.Checked)
            {
                if (Utility.getConfirmMsgResult(mRM, (int)PowerOptions.REBOOT) == DialogResult.Yes)
                {
                    powerManagement((int)PowerOptions.REBOOT);
                    Application.Exit();
                }
            }
            else
            {
                powerManagement((int)PowerOptions.REBOOT);
                Application.Exit();
            }
        }

        private void btnLogOff_Click(object sender, EventArgs e)
        {
            if (cbxShowConfirmMsg.Checked)
            {
                if (Utility.getConfirmMsgResult(mRM, (int)PowerOptions.LOGOFF) == DialogResult.Yes)
                {
                    powerManagement((int)PowerOptions.LOGOFF);
                    Application.Exit();
                }
            }
            else
            {
                powerManagement((int)PowerOptions.LOGOFF);
                Application.Exit();
            }
        }

        private void btnHibernate_Click(object sender, EventArgs e)
        {
            if (cbxShowConfirmMsg.Checked)
            {
                if (Utility.getConfirmMsgResult(mRM, (int)PowerOptions.HIBERNATE) == DialogResult.Yes)
                {
                    Application.SetSuspendState(PowerState.Hibernate, true, false);
                    Application.Exit();
                }
            }
            else
            {
                Application.SetSuspendState(PowerState.Hibernate, true, false);
                Application.Exit();
            }            
        }

        private void btnSleep_Click(object sender, EventArgs e)
        {
            if (cbxShowConfirmMsg.Checked)
            {
                if (Utility.getConfirmMsgResult(mRM, (int)PowerOptions.SLEEP) == DialogResult.Yes)
                {
                    Application.SetSuspendState(PowerState.Suspend, true, false);
                    Application.Exit();
                }
            }
            else
            {
                Application.SetSuspendState(PowerState.Suspend, true, false);
                Application.Exit();
            } 
        }

        private void btnLock_Click(object sender, EventArgs e)
        {
            if (cbxShowConfirmMsg.Checked)
            {
                if (Utility.getConfirmMsgResult(mRM, (int)PowerOptions.LOCK) == DialogResult.Yes)
                {
                    LockWorkStation();
                    Application.Exit();
                }
            }
            else
            {
                LockWorkStation();
                Application.Exit();
            }
        }

        private void tmiZH_Click(object sender, EventArgs e)
        {
            RuntimeLocalizer.ChangeCulture(this, "zh-HK");
            Utility.updateSetting("lang", "zh-HK");

            foreach (ToolStripDropDownItem item in tmiLang.DropDownItems)
            {
                if (item.GetType() == typeof(ToolStripMenuItem))
                {
                    ((ToolStripMenuItem)item).Checked = false;
                }
            }
            initToolTip();
            tmiZH.Checked = true;
        }

        private void tmiEng_Click(object sender, EventArgs e)
        {
            RuntimeLocalizer.ChangeCulture(this, "en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            Utility.updateSetting("lang", "en-US");

            foreach (ToolStripDropDownItem item in tmiLang.DropDownItems)
            {
                if (item.GetType() == typeof(ToolStripMenuItem))
                {
                    ((ToolStripMenuItem)item).Checked = false;
                }
            }
            initToolTip();
            tmiEng.Checked = true;
        }

        private void tmiExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tmiRestoreSetting_Click(object sender, EventArgs e)
        {
            Utility.restoreDefaultSetting();
            MessageBox.Show(RuntimeLocalizer.getString(mRM, "msgDefaultSetting"), RuntimeLocalizer.getString(mRM, "strInfoTitle"), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            string[] keys = { "showConfirm", "waitTime"};
            object[] values = { cbxShowConfirmMsg.Checked, cbxWaitTime.SelectedIndex };
            Utility.saveAllSetting(keys, values);
        }

        private void tmiAbout_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.ShowDialog();
        }

        private void llbDeveloper_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/cmproducts.apps");
        }
    }
}
