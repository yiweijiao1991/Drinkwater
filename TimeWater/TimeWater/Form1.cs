using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeWater
{
    public partial class Form1 : Form
    {
        int timeSeconds;
        int timerelay = -1;
        string showRelayTime;
      
        public Form1()
        {
            InitializeComponent();
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            timer2.Start();
            label5.Text = "您还没有开始哦!";
            button1.Enabled = true;
            button2.Enabled = false;
            textBox1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timeSeconds = int.Parse(textBox1.Text) * 60;
            timerelay = timeSeconds;
            timer1.Start();
            button1.Enabled = false;
            button2.Enabled = true;
            textBox1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timerelay = -1;
            label5.Text = "您还没有开始哦!";
            button1.Enabled = true;
            button2.Enabled = false;
            textBox1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int hour = 0;
            int min = 0;
            int seconds = 0;
            timerelay--;
            if (timerelay < 0)
            {
                showRelayTime = "您还没有开始哦!";
            }
            else if (timerelay == 0)
            {
                Form2 form2 = new Form2(ref this.timer1);
                timer1.Stop();
                showRelayTime = "时间到了!";
                timerelay = timeSeconds;
                form2.ShowDialog();
            }
            else if (timerelay > 0 && timerelay < 60)
            {
                showRelayTime = timerelay.ToString() + "秒";
            }
            else if (timerelay >= 60 && timerelay < 3600)
            {
                min = timerelay / 60;
                seconds = timerelay % 60;
                showRelayTime = min.ToString() + "分" + seconds.ToString() + "秒";
            }
            else if (timerelay > 3600)
            {
                
                hour = timerelay / 3600;
                min = (timerelay / 60) % 60;
                seconds = timerelay % 60;
                showRelayTime = hour.ToString() + "时" + min.ToString() + "分" + seconds.ToString() + "秒";
            }
            label5.Text = showRelayTime;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label4.Text = DateTime.Now.ToString();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && (e.KeyChar != 8))
                e.Handled = true;
        }

    

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            this.Visible = true;

            this.WindowState = FormWindowState.Normal;

            this.notifyIcon1.Visible = false;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            this.notifyIcon1.Visible = true;
            notifyIcon1.ShowBalloonTip(5000, "小雪糕", "我在这里！", ToolTipIcon.Info);
        }
    }
}
