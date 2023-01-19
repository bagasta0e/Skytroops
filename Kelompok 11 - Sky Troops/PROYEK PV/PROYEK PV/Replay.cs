using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace PROYEK_PV
{
    public partial class Replay : Form
    {
        public Replay()
        {
            InitializeComponent();
        }

        Bitmap bg;

        int bggerak;
        int bggerak2;
        int ctr;

        // KARAKTER 
        Bitmap[] chr;
        Rectangle frameChr;
        static List<int> SchrTMR = new List<int>();
        static List<int> Sx = new List<int>();
        static List<int> Sy = new List<int>();

        int x, y, idx;

        //gun
        Bitmap[] tembak;
        static List<int> SgunTMR = new List<int>();
        static List<int> xpeluru = new List<int>();
        static List<int> ypeluru = new List<int>();
        static List<Rectangle> framePeluru = new List<Rectangle>();
        List<int> xg = new List<int>();
        List<int> yg = new List<int>();
        int Ntembak;

        // Musuh
        Bitmap musuh;
        static List<int> SmshTMR = new List<int>();
        static List<int> xmusuh = new List<int>();
        static List<int> ymusuh = new List<int>();
        static List<Rectangle> frameMusuh = new List<Rectangle>();
        List<int> xm = new List<int>();
        List<int> ym = new List<int>();


        // Batu
        Bitmap[] obstacle;
        int batu;
        static List<int> SobsTMR = new List<int>();
        static List<int> xobstacle = new List<int>();
        static List<int> yobstacle = new List<int>();
        static List<Rectangle> frameBatu = new List<Rectangle>();
        List<int> nb = new List<int>();
        List<int> xb = new List<int>();
        List<int> yb = new List<int>();

        //Coin
        Bitmap coin;
        static List<int> ScnTMR = new List<int>();
        static List<int> xCOIN = new List<int>();
        static List<int> yCOIN = new List<int>();
        static List<Rectangle> frameCoin = new List<Rectangle>();
        List<int> xc = new List<int>();
        List<int> yc = new List<int>();

        //Shiled
        Bitmap tameng;
        static List<int> SshldTMR = new List<int>();
        static List<int> xtameng = new List<int>();
        static List<int> ytameng = new List<int>();
        static List<Rectangle> frameTameng = new List<Rectangle>();
        List<int> xs = new List<int>();
        List<int> ys = new List<int>();

        //gambar power up
        bool boolPowerup;
        Bitmap powerup;
        Rectangle framePoweup;

        static Random rnd = new Random();

        bool game = true;
            
        private void Replay_Load(object sender, EventArgs e)
        {
            x = 0;
            y = 0;
            bg = new Bitmap(Resource1.BG);
            bggerak = 0;
            bggerak2 = 729;
            timer1.Start();

            musuh = new Bitmap(Resource1.plane_3_red);

            obstacle = new Bitmap[3];
            obstacle[0] = new Bitmap(Resource1.obstacle_11);
            obstacle[1] = new Bitmap(Resource1.obstacle_2);
            obstacle[2] = new Bitmap(Resource1.obstacle_3);

            chr = new Bitmap[5];
            chr[0] = new Bitmap(Resource1.Fly_1);
            chr[1] = new Bitmap(Resource1.Fly_2);
            chr[2] = new Bitmap(Resource1.Fly_1);
            chr[3] = new Bitmap(Resource1.Fly_2);
            chr[4] = new Bitmap(Resource1.Fly_1);

            tembak = new Bitmap[5];
            tembak[0] = new Bitmap(Resource1.Bullet__1_);
            tembak[1] = new Bitmap(Resource1.Bullet__2_);
            tembak[2] = new Bitmap(Resource1.Bullet__3_);
            tembak[3] = new Bitmap(Resource1.Bullet__4_);
            tembak[4] = new Bitmap(Resource1.Bullet__1_);
            Ntembak = 0;
            idx = 0;

            ctr = 0;

            tameng = new Bitmap(Resource1.Tameng);

            coin = new Bitmap(Resource1.Coin);

            boolPowerup = false;
            powerup = new Bitmap(Resource1.frameshield);

            /////
            xmlmasuk();
            ////
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (game == true)
            {
                ctr++;
                if (ctr == Sx.Count)
                {
                    timer1.Stop();
                    MessageBox.Show("Selesai");
                }
                else
                {
                    gerakBG();
                    x = Sx[ctr];
                    y = Sy[ctr];



                    frame();
                    muncul();

                    gerak();
                }

                Invalidate();
            }
        }


        private void Replay_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;


            g.DrawImage(bg, bggerak, 0, this.Width, this.Height);
            g.DrawImage(bg, bggerak2, 0, this.Width, this.Height);

            //karakter
            if (boolPowerup == true)
            {
                g.DrawImage(powerup, x - 10, y - 10, 100, 80);
                framePoweup = new Rectangle(x - 10, y - 10, 100, 80);
            }
            g.DrawImage(chr[idx], x, y, 77, 53);
            frameChr = new Rectangle(x, y, 77, 53);

            //obstacle
            for (int i = 0; i < xb.Count; i++)
            {
                g.DrawImage(obstacle[nb[i]], xb[i], yb[i], 40, 35);
                
            }

            //pesawat musuh
            for (int i = 0; i < xm.Count; i++)
            {
               g.DrawImage(musuh, xm[i], ym[i], 75, 50);
            }

            //gun
            for (int i = 0; i < xg.Count; i++)
            {
                g.DrawImage(tembak[Ntembak], xg[i], yg[i], 15, 20);
                
            }

            //coin
            for (int i = 0; i < xc.Count; i++)
            {
                g.DrawImage(coin, xc[i], yc[i], 50, 50);
                
            }

            //tameng
            for (int i = 0; i < xs.Count; i++)
            {
               g.DrawImage(tameng, xs[i], ys[i], 60, 55);
             
            }

        }

        void gerakBG()
        {
            if (bggerak < -710)
            {
                bggerak = 729;
            }
            else
            {
                bggerak -= 5;
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

        void xmlmasuk()
        {
            try
            {
                string nodeName = "";
                XmlTextReader xReader = new XmlTextReader(Application.StartupPath + "\\Replay.xml");
                while (xReader.Read())
                {
                    switch (xReader.NodeType)
                    {
                        case XmlNodeType.Element:
                            nodeName = xReader.Name;
                            break;
                        case XmlNodeType.Text:

                            //Character
                            if (nodeName == "SchrTMR")
                            {
                                SchrTMR.Add(Convert.ToInt32(xReader.Value));
                            }
                            else if (nodeName == "Sx")
                            {
                                Sx.Add(Convert.ToInt32(xReader.Value));
                            }
                            else if (nodeName == "Sy")
                            {
                                Sy.Add(Convert.ToInt32(xReader.Value));
                            }

                            //batu
                            else if (nodeName == "SobsTMR")
                            {
                                SobsTMR.Add(Convert.ToInt32(xReader.Value));
                            }
                            else if (nodeName == "SobsX")
                            {
                                xobstacle.Add(Convert.ToInt32(xReader.Value));
                            }
                            else if (nodeName == "SobsY")
                            {
                                yobstacle.Add(Convert.ToInt32(xReader.Value));
                            }

                            //musuh
                            else if (nodeName == "SmshTMR")
                            {
                                SmshTMR.Add(Convert.ToInt32(xReader.Value));
                            }
                            else if (nodeName == "SmshX")
                            {
                                xmusuh.Add(Convert.ToInt32(xReader.Value));
                            }
                            else if (nodeName == "SmshY")
                            {
                                ymusuh.Add(Convert.ToInt32(xReader.Value));
                            }

                            //coin
                            else if (nodeName == "ScnTMR")
                            {
                                ScnTMR.Add(Convert.ToInt32(xReader.Value));
                            }
                            else if (nodeName == "ScnX")
                            {
                                xCOIN.Add(Convert.ToInt32(xReader.Value));
                            }
                            else if (nodeName == "ScnY")
                            {
                                yCOIN.Add(Convert.ToInt32(xReader.Value));
                            }

                            //tameng
                            else if (nodeName == "SshldTMR")
                            {
                                SshldTMR.Add(Convert.ToInt32(xReader.Value));
                            }
                            else if (nodeName == "SshldX")
                            {
                                xtameng.Add(Convert.ToInt32(xReader.Value));
                            }
                            else if (nodeName == "SshldY")
                            {
                                ytameng.Add(Convert.ToInt32(xReader.Value));
                            }

                            //gun
                            else if (nodeName == "SgunTMR")
                            {
                                SgunTMR.Add(Convert.ToInt32(xReader.Value));
                            }
                            else if (nodeName == "SgunX")
                            {
                                xpeluru.Add(Convert.ToInt32(xReader.Value));
                            }
                            else if (nodeName == "SgunY")
                            {
                                ypeluru.Add(Convert.ToInt32(xReader.Value));
                            }

                            //

                            break;
                    }
                }
                xReader.Close();
            }
            catch (XmlException exc)
            {
                MessageBox.Show(exc + "");
            }
        }

        int nOBS = 0;
        int nMSH = 0;
        int nCN = 0;
        int nSHLD = 0;
        int nGUN = 0;


        void muncul()
        {
            // batu
            if (SobsTMR[nOBS] == ctr)
            {
                batu = rnd.Next(0, 3);
                nb.Add(batu);
                xb.Add(xobstacle[nOBS]);
                yb.Add(yobstacle[nOBS]);

                nOBS++;
            }

            // musuh
            if (SmshTMR[nMSH] == ctr)
            {  
                xm.Add(xmusuh[nMSH]);
                ym.Add(ymusuh[nMSH]);

                nMSH++;
            }

            // coin 
            if (ScnTMR[nCN]==ctr)
            {
                xc.Add(xCOIN[nCN]);
                yc.Add(yCOIN[nCN]);

                nCN++;
            }
            
            // Shiled 
            if (SshldTMR[nSHLD] == ctr)
            {
                xs.Add(xCOIN[nSHLD]);
                ys.Add(yCOIN[nSHLD]);

                nSHLD++;
            }

            //// gun  
            //if (SgunTMR[nGUN] == ctr)
            //{
            //    xg.Add(xCOIN[nGUN]);
            //    yg.Add(yCOIN[nGUN]);

            //    nGUN++;
            //}
        }

        void frame()
        {
            for (int i = 0; i < xm.Count; i++)
            {
                frameMusuh.Add(new Rectangle(xm[i], ym[i], 75, 50));
            }

            for (int i = 0; i < xb.Count; i++)
            {

                if (nb[i] == 0)
                {
                    frameBatu.Add(new Rectangle(xb[i], yb[i], 40, 35));
                }
                else if (nb[i] == 1)
                {
                    frameBatu.Add(new Rectangle(xb[i], yb[i], 30, 20));
                }
                else if (nb[i] == 2)
                {
                    frameBatu.Add(new Rectangle(xb[i], yb[i], 35, 25));
                }
            }

            for (int i = 0; i < xg.Count; i++)
            {
                framePeluru.Add(new Rectangle(xg[i], yg[i], 15, 20));
            }

            for (int i = 0; i < xc.Count; i++)
            {
                frameCoin.Add(new Rectangle(xc[i], yc[i], 50, 50));
            }

            for (int i = 0; i < xs.Count; i++)
            {
                frameTameng.Add(new Rectangle(xs[i], ys[i], 60, 55));
            }

        }

        void gerak()
        {
            //tameng
            if (xs.Count > 0)
            {
                for (int i = 0; i < xs.Count; i++)
                {
                    //frameTameng[i] = new Rectangle(xs[i], ys[i], 60, 55);
                    if (xs[i] < 10)
                    {
                        xs.RemoveAt(i);
                        ys.RemoveAt(i);
                    }
                    else
                    {
                        xs[i] -= 7;
                    }

                    if (frameTameng.Count > 0)
                    {
                        if (frameChr.IntersectsWith(frameTameng[i]))
                        {
                            boolPowerup = true;
                            xs.RemoveAt(i);
                            ys.RemoveAt(i);
                            frameTameng.RemoveAt(i);
                        }
                    }
                }
            }

            // coin
            if (xc.Count > 0)
            {
                for (int i = 0; i < xc.Count; i++)
                {
                    //frameCoin[i] = new Rectangle(xc[i], yc[i], 50, 50);
                    if (xc[i] < 10)
                    {
                        xc.RemoveAt(i);
                        yc.RemoveAt(i);
                    }
                    else
                    {
                        xc[i] -= 10;
                    }
                    if (frameCoin.Count > 0)
                    {
                        if (frameChr.IntersectsWith(frameCoin[i]))
                        {
                            xc.RemoveAt(i);
                            yc.RemoveAt(i);
                            frameCoin.RemoveAt(i);
                        }
                    }

                }
            }
            // musuh
            if (xm.Count > 0)
            {
                for (int i = 0; i < xm.Count; i++)
                {
                    //frameMusuh[i] = new Rectangle(xm[i], ym[i], 75, 50);
                    if (xm[i] == 10)
                    {
                        xm.RemoveAt(i);
                        ym.RemoveAt(i);
                        frameMusuh.RemoveAt(i);
                    }
                    else
                    {
                        xm[i] -= 9;
                    }
                    if (frameMusuh.Count > 0)
                    {
                        for (int j = 0; j < xm.Count; j++)
                        {
                            if (frameChr.IntersectsWith(frameMusuh[j]))
                            {
                                xm.RemoveAt(j);
                                ym.RemoveAt(j);
                                frameMusuh.RemoveAt(j);
                            }
                        }
                    }
                }
            }

            // peluru
            if (xg.Count > 0)
            {
                for (int i = 0; i < xg.Count; i++)
                {
                    //framePeluru[i] = new Rectangle(xg[i], yg[i], 15, 20);
                    if (xpeluru[i] >= 730)
                    {
                        xg.RemoveAt(i);
                        yg.RemoveAt(i);
                        framePeluru.RemoveAt(i);
                    }
                    else
                    {
                        xpeluru[i] += 9;
                    }
                    if (framePeluru.Count > 0)
                    {
                        for (int j = 0; j < xg.Count; j++)
                        {
                            for (int k = 0; k < xm.Count; k++)
                            {
                                if (framePeluru[j].IntersectsWith(frameMusuh[k]))
                                {
                                    xg.RemoveAt(j);
                                    yg.RemoveAt(j);
                                    framePeluru.RemoveAt(j);

                                    xm.RemoveAt(k);
                                    ym.RemoveAt(k);
                                    frameMusuh.RemoveAt(k);
                                    
                                }
                            }
                        }
                    }
                }
            }
            // batu
            if (nb.Count > 0)
            {
                for (int i = 0; i < nb.Count; i++)
                {
                    //if (nb[i] == 0)
                    //{
                    //    frameBatu[i] = new Rectangle(xb[i], yb[i], 40, 35);
                    //}
                    //else if (nb[i] == 1)
                    //{
                    //    frameBatu[i] = new Rectangle(xb[i], yb[i], 30, 20);
                    //}
                    //else if (nb[i] == 2)
                    //{
                    //    frameBatu[i] = new Rectangle(xb[i], yb[i], 35, 25);
                    //}
                    if (xb[i] < 0)
                    {
                        xb.RemoveAt(i);
                        yb.RemoveAt(i);
                        nb.RemoveAt(i);
                        frameBatu.RemoveAt(i);
                    }
                    else
                    {
                        xb[i] -= 7;
                    }

                    if (frameBatu.Count > 0)
                    {
                        for (int j = 0; j < nb.Count; j++)
                        {
                            if (frameChr.IntersectsWith(frameBatu[j]))
                            {
                                xb.RemoveAt(j);
                                yb.RemoveAt(j);
                                nb.RemoveAt(j);
                                frameBatu.RemoveAt(j);
                            }
                        }
                    }
                }
            }
        }

    }
}
