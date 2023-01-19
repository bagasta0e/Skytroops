using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROYEK_PV
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Bitmap bg;
        Bitmap logo;
        int bggerak;
        int bggerak2;

        private void Form1_Load(object sender, EventArgs e)
        {
            Play.xml();
            bggerak = 0;
            bggerak2 = 729;
            bg = new Bitmap(Resource1.BG);
            logo = new Bitmap(Resource1.logo1);
            timer1.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(bg, bggerak, 0, this.Width, this.Height);
            g.DrawImage(bg, bggerak2, 0, this.Width, this.Height);

            g.DrawImage(logo, 210, 50, 329 , 166);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (bggerak<-710)
            {
                bggerak = 729;
            }
            else
            {
                bggerak-=5;
            }

            if (bggerak2 < -710)
            {
                bggerak2 = 729;
            }
            else
            {
                bggerak2 -= 5;
            }

            Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form play = new Play();
            play.Show();
            timer1.Stop();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form score = new score();
            score.Show();
            timer1.Stop();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form reaplay = new Replay();
            reaplay.Show();
            timer1.Stop();
        }
    }
}
