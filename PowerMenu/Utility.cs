using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Resources;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace PowerMenu
{
    static class Utility
    {
        private static Hashtable osInfo;

        public static void initOSInfoHashTable()
        {
            if (osInfo == null)
                osInfo = new Hashtable();
        }

        public static void resetOSInfoHashTable()
        {
            initOSInfoHashTable();
            if (osInfo.Count > 0)
                osInfo.Clear();
        }

        public static void addToOSInfoHashTable(string key, object o)
        {
            osInfo.Add(key, o);
        }

        public static long getOSInfoHashTableCount()
        {
            return osInfo.Count;
        }

        public static bool isOSInfoContainsKey(string key)
        {
            return osInfo[key] != null;
        }

        public static string getOSInfoByKey(string key)
        {
            return osInfo[key].ToString();
        }

        public static bool isNT6OrAbove(string versionCode)
        {
            if (Int32.Parse(versionCode.Substring(0, 1)) >= WindowsVersion.WINDOWSVISTA)
                return true;
            return false;
        }

        public static object getSettingValue(string key)
        {
            return Properties.Settings.Default[key];
        }

        public static void restoreDefaultSetting()
        {
            Properties.Settings.Default["waitTime"] = 0;
            Properties.Settings.Default["showConfirm"] = true;
            Properties.Settings.Default["lang"] = "en-US";
        }

        public static void updateSetting()
        {
            Properties.Settings.Default.Save();
        }

        public static void updateSetting(string key, object value)
        {
            Properties.Settings.Default[key] = value;
            Properties.Settings.Default.Save();
        }

        public static void saveAllSetting(string[] keys, object[] values)
        {
            for (int i = 0; i < keys.Length && i < values.Length; i++)
            {
                Properties.Settings.Default[keys[i]] = values[i];
            }
            Properties.Settings.Default.Save();
        }

        public static DialogResult getConfirmMsgResult(ResourceManager res, int mode)
        {
            string msg = String.Empty;
            string title = RuntimeLocalizer.getString(res, "strWarningTitle");
            if (mode == (int)MainForm.PowerOptions.SHUTDOWN)
            {
                msg = RuntimeLocalizer.getString(res, "strConfirmShutdown");
            }
            else if (mode == (int)MainForm.PowerOptions.REBOOT)
            {
                msg = RuntimeLocalizer.getString(res, "strConfirmReboot");
            }
            else if (mode == (int)MainForm.PowerOptions.LOGOFF)
            {
                msg = RuntimeLocalizer.getString(res, "strConfirmLogoff");
            }
            else if (mode == (int)MainForm.PowerOptions.LOCK)
            {
                msg = RuntimeLocalizer.getString(res, "strConfirmLock");
            }
            else if (mode == (int)MainForm.PowerOptions.SLEEP)
            {
                msg = RuntimeLocalizer.getString(res, "strConfirmSleep");
            }
            else if (mode == (int)MainForm.PowerOptions.HIBERNATE)
            {
                msg = RuntimeLocalizer.getString(res, "strConfirmHibernate");
            }
            return MessageBox.Show(msg, title,MessageBoxButtons.YesNo, MessageBoxIcon.Question) ;
        }
    }

    public static class WindowsVersion
    {
        public static double WINDOWS2000 = 5.0;
        public static double WINDOWSXP = 5.1;
        public static double WINDOWSXP64BIT = 5.2;
        public static double WINDOWSSERVER2003 = 5.2;
        public static double WINDOWSSERVER2003R2 = 5.2;
        public static double WINDOWSVISTA = 6.0;
        public static double WINDOWSSERVER2008 = 6.0;
        public static double WINDOWS7 = 6.1;
        public static double WINDOWSSERVER2008R2 = 6.1;
        public static double WINDOWS8 = 6.2;
        public static double WINDOWSSERVER2012 = 6.2;
        public static double WINDOWS81 = 6.3;
        public static double WINDOWSSERVER2012R2 = 6.3;
        public static double WINDOWS10 = 10;
        public static double WINDOWSSERVER2016 = 10;
    }

    public static class ShutdownClassPath
    {
        public static string NT5 = "Win32Shutdown";
        public static string NT6 = "Win32ShutdownTracker";
    }

    public static class OSInfo
    {
        public static string Version = "Version";
        public static string Caption = "Caption";
    }

    public static class RuntimeLocalizer
    {
        private static CultureInfo culture;

        public static void ChangeCulture(Form frm, string cultureCode)
        {
            culture = CultureInfo.GetCultureInfo(cultureCode);

            Thread.CurrentThread.CurrentUICulture = culture;

            ComponentResourceManager resources = new ComponentResourceManager(frm.GetType());

            ApplyResourceToControl(resources, frm, culture);
            resources.ApplyResources(frm, "$this", culture);
        }

        public static string getString(ResourceManager res, string key)
        {
            if (culture == null)
                return res.GetString(key);
            return res.GetString(key, culture);
        }

        private static void ApplyResourceToControl(ComponentResourceManager res, Control control, CultureInfo lang)
        {
            if (control.GetType() == typeof(MenuStrip))  // See if this is a menuStrip
            {
                MenuStrip strip = (MenuStrip)control;

                ApplyResourceToToolStripItemCollection(strip.Items, res, lang);
            }

            foreach (Control c in control.Controls) // Apply to all sub-controls
            {
                ApplyResourceToControl(res, c, lang);
                res.ApplyResources(c, c.Name, lang);
            }

            // Apply to self
            res.ApplyResources(control, control.Name, lang);
        }

        private static void ApplyResourceToToolStripItemCollection(ToolStripItemCollection col, ComponentResourceManager res, CultureInfo lang)
        {
            for (int i = 0; i < col.Count; i++)     // Apply to all sub items
            {
                ToolStripItem item = (ToolStripMenuItem)col[i];

                if (item.GetType() == typeof(ToolStripMenuItem))
                {
                    ToolStripMenuItem menuitem = (ToolStripMenuItem)item;
                    ApplyResourceToToolStripItemCollection(menuitem.DropDownItems, res, lang);
                }

                res.ApplyResources(item, item.Name, lang);
            }
        }
    }
}
