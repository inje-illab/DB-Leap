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

namespace leap
{
    public partial class DbLeapForm : Form
    {
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
            MessageBox.Show("로드 테스트");
        }

        private void onDoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("아이콘 더블 클릭 테스트");
        }
    }
}
