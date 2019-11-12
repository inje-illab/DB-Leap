using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;
using Leap;
using Microsoft.Win32;

namespace leap
{
    public partial class hidemain : Form
    {
        Controller controller;
        public hidemain()
        {
            InitializeComponent();
            controller = new Controller();
            LeapControllerListener leapListener = new LeapControllerListener(
                SystemInformation.VirtualScreen.Width,
                SystemInformation.VirtualScreen.Height);


            controller.Device += leapListener.OnConnect;
            //controller.Device += leapListener.OnDisConnect;
            controller.FrameReady += leapListener.OnFrame;

            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            this.Visible = false;
            this.bottomNotifiyIcon.Visible = true;
            bottomNotifiyIcon.ContextMenuStrip = contextMenuStrip;
            if (Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true).GetValue("DBLeap") != null)
                시작시실행ToolStripMenuItem.Checked = true;
            else
                시작시실행ToolStripMenuItem.Checked = false;

        }

        private void 시작시실행ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (시작시실행ToolStripMenuItem.Checked)
            {
                시작시실행ToolStripMenuItem.Checked = false;
                MessageBox.Show("시작시 실행 레지스트리를 제거합니다.");
                RemoveApplicationFromStartup();
            }
            else
            {
                시작시실행ToolStripMenuItem.Checked = true;
                MessageBox.Show("시작시 실행 레지스트리를 추가합니다.");
                AddApplicationToStartup();
            }
        }

        public static void AddApplicationToStartup()
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
                key.SetValue("DBLeap", "\"" + Application.ExecutablePath + "\"");
        }

        public static void RemoveApplicationFromStartup()
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
                key.DeleteValue("DBLeap", false);
        }

        private void tipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 프레젠테이션모드ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MotionFuntion.setPTmode)
            {
                프레젠테이션모드ToolStripMenuItem.Checked = false;
                MotionFuntion.setPTmode = false;
            }
            else
            {
                프레젠테이션모드ToolStripMenuItem.Checked = true;
                MotionFuntion.setPTmode = true;
            }
        }
    }
}
