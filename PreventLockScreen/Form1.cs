using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PreventLockScreen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            WindowState = FormWindowState.Minimized;
            ChangeMode();
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern uint SetThreadExecutionState(uint esFlags);
        public const uint ES_CONTINUOUS = 0x80000000;
        public const uint ES_SYSTEM_REQUIRED = 0x00000001;
        public const uint ES_AWAYMODE_REQUIRED = 0x00000040;

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            ChangeMode();
        }

        private void ChangeMode()
        {
            switch (checkBox1.Checked)
            {
                // True means prevent screen auto-lock
                case true:
                    // Try this for vista, it will fail on XP
                    if (SetThreadExecutionState(ES_CONTINUOUS | ES_SYSTEM_REQUIRED | ES_AWAYMODE_REQUIRED) == 0)
                    {
                        // Try XP variant as well just to make sure 
                        SetThreadExecutionState(ES_CONTINUOUS | ES_SYSTEM_REQUIRED);
                    }

                    notifyIcon1.Icon = Properties.Resources.unlocked;
                    notifyIcon1.Text = "Screen auto-lock is disabled.";

                    break;
                default:
                    // Set state back to normal
                    SetThreadExecutionState(ES_CONTINUOUS);

                    notifyIcon1.Icon = Properties.Resources.locked;
                    notifyIcon1.Text = "Screen auto-lock is enabled.";
                    break;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            checkBox1.Checked = !checkBox1.Checked;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
