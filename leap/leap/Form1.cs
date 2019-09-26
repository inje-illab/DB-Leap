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

    public partial class DbLeapForm : Form
    {
        Controller controller;
        SampleListener sampleListener;
        

        bool is_registered;

        class SampleListener
        {
            int grab_integer;
            bool grab_ready = false;
            public void OnFrame(object sender, FrameEventArgs args)
            {
                Frame frame = args.frame;
                foreach (Hand hand in frame.Hands)
                {
                    grab_integer= (int)frame.Hands[0].GrabStrength;
                    if (grab_integer == 1 && !grab_ready)
                        grab_ready = true;
                    else if (grab_integer == 0 && grab_ready)
                    {
                        grab_ready = false;
                        MessageBox.Show("Grab 동작");
                    }
//                    Console.WriteLine("{0}", (int)hand.PalmPosition[0]);
                }
            }
        }
        public DbLeapForm()
        {
            InitializeComponent();
            
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            this.Visible = false;
            this.bottomNotifiyIcon.Visible = true;
            bottomNotifiyIcon.ContextMenuStrip = contextMenuStrip;

        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DbLeapForm_Load(object sender, EventArgs e)
        {
            //MessageBox.Show("로드 테스트");
            controller = new Controller();
            sampleListener = new SampleListener();
            controller.FrameReady += sampleListener.OnFrame;
        }

        private void onDoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("아이콘 더블 클릭 테스트");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true).GetValue("DBLeap") != null)
            {
                is_registered = true;
                MessageBox.Show(is_registered.ToString() + " => 레지스트리를 제거합니다.");
                RemoveApplicationFromStartup();
            }
            else
            {
                is_registered = false;
                MessageBox.Show(is_registered.ToString() + " => 레지스트리를 추가합니다.");
                AddApplicationToStartup();
            }
            try
            {
                label1.Text = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true).GetValue("DBLeap").ToString();
            }
            catch
            {
                label1.Text = "Empty";
            }
        }

        public static void AddApplicationToStartup()
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
                {
                    key.SetValue("DBLeap", "\"" + Application.ExecutablePath + "\"");
                }
            }
            catch
            {
                MessageBox.Show("오류발생");
            }
            
        }

        public static void RemoveApplicationFromStartup()
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
                {
                    key.DeleteValue("DBLeap", false);
                }
            }
            catch
            {
                MessageBox.Show("오류발생");
            }
        }
    }
}
