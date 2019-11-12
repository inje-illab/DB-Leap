namespace leap
{
    partial class hidemain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(hidemain));
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.시작시실행ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bottomNotifiyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.프레젠테이션모드ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tipToolStripMenuItem,
            this.프레젠테이션모드ToolStripMenuItem,
            this.시작시실행ToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip1";
            this.contextMenuStrip.Size = new System.Drawing.Size(235, 124);
            // 
            // tipToolStripMenuItem
            // 
            this.tipToolStripMenuItem.Name = "tipToolStripMenuItem";
            this.tipToolStripMenuItem.Size = new System.Drawing.Size(234, 30);
            this.tipToolStripMenuItem.Text = "도움말";
            this.tipToolStripMenuItem.Click += new System.EventHandler(this.tipToolStripMenuItem_Click);
            // 
            // 시작시실행ToolStripMenuItem
            // 
            this.시작시실행ToolStripMenuItem.Name = "시작시실행ToolStripMenuItem";
            this.시작시실행ToolStripMenuItem.Size = new System.Drawing.Size(234, 30);
            this.시작시실행ToolStripMenuItem.Text = "시작 시 실행";
            this.시작시실행ToolStripMenuItem.Click += new System.EventHandler(this.시작시실행ToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(234, 30);
            this.exitToolStripMenuItem.Text = "종료";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // bottomNotifiyIcon
            // 
            this.bottomNotifiyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("bottomNotifiyIcon.Icon")));
            this.bottomNotifiyIcon.Text = "DBLeap";
            this.bottomNotifiyIcon.Visible = true;
            // 
            // 프레젠테이션모드ToolStripMenuItem
            // 
            this.프레젠테이션모드ToolStripMenuItem.Name = "프레젠테이션모드ToolStripMenuItem";
            this.프레젠테이션모드ToolStripMenuItem.Size = new System.Drawing.Size(234, 30);
            this.프레젠테이션모드ToolStripMenuItem.Text = "프레젠테이션 모드";
            this.프레젠테이션모드ToolStripMenuItem.Click += new System.EventHandler(this.프레젠테이션모드ToolStripMenuItem_Click);
            // 
            // hidemain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 378);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "hidemain";
            this.Text = "hidemain";
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem tipToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon bottomNotifiyIcon;
        private System.Windows.Forms.ToolStripMenuItem 시작시실행ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 프레젠테이션모드ToolStripMenuItem;
    }
}