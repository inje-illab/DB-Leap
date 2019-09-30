using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace leap
{
    public partial class Form1 : MetroForm
    {
        Timer timer = new Timer();
        int pictureBox_ID = 0;
        int timer_cnt = 1;

        public Form1() {
            InitializeComponent();
            Initialization();
        }

        void Initialization() {
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
        }

        void PictureBox_Check() {
            switch (pictureBox_ID) {
                case 0: pictureBox1.Visible = true; break;
                case 1: pictureBox2.Visible = true; break;
                case 2: pictureBox3.Visible = true; break;
                case 3: pictureBox4.Visible = true; break;
                case 4: pictureBox5.Visible = true; break;
                case 5: pictureBox6.Visible = true; break;
                case 6: pictureBox7.Visible = true; break;
                default:
                    timer.Stop();
                    break;
            }
        }

        void RadioButton_Check() {
            switch (pictureBox_ID) {
                case 0: radioButton1.Checked = true; break;
                case 1: radioButton2.Checked = true; break;
                case 2: radioButton3.Checked = true; break;
                case 3: radioButton4.Checked = true; break;
                case 4: radioButton5.Checked = true; break;
                case 5: radioButton6.Checked = true; break;
                case 6: radioButton7.Checked = true; break;
                default:
                    timer.Stop();
                    break;
            }
        }

        void timer_Tick(object sender, EventArgs e) {
            switch (timer_cnt) {
                case 0: pictureBox_ID = 0; break;
                case 1: pictureBox_ID = 1; break;
                case 2: pictureBox_ID = 2; break;
                case 3: pictureBox_ID = 3; break;
                case 4: pictureBox_ID = 4; break;
                case 5: pictureBox_ID = 5; break;
                case 6: pictureBox_ID = 6; break;
                default:
                    timer.Stop();
                    break;
            }

            timer_cnt++;
            Initialization();
            PictureBox_Check();
            RadioButton_Check();
        }

        private void Form1_Load(object sender, EventArgs e) {
            timer.Interval = 3000; // 1000 = 1초
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
            PictureBox_Check();
            RadioButton_Check();
        }

        private void RadioButton_Click(object sender, EventArgs e) {
            if (radioButton1.Checked == true)
                pictureBox_ID = 0;
            else if (radioButton2.Checked == true)
                pictureBox_ID = 1;
            else if (radioButton3.Checked == true)
                pictureBox_ID = 2;
            else if (radioButton4.Checked == true)
                pictureBox_ID = 3;
            else if (radioButton5.Checked == true)
                pictureBox_ID = 4;
            else if (radioButton6.Checked == true)
                pictureBox_ID = 5;
            else if (radioButton7.Checked == true)
                pictureBox_ID = 6;

            Initialization();
            PictureBox_Check();
            RadioButton_Check();
        }
    }
}
