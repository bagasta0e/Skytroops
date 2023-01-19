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
    public partial class Play : Form
    {
        public Play()
        {
            InitializeComponent();
        }
        bool game;
        string nama, difficulty;
        int nyawa, score;

        public static List<string> LNama = new List<string>();
        public static List<string> Ldifficulty = new List<string>();
        public static List<int> Lscore = new List<int>();

        

        int tambahCoin;
        int gerakTameng, gerakCoin, gerakMusuh, gerakBatu;
        int munculTameng, munculCoin, munculMusuh, munculBatu;
        int n = 0;

        // KARAKTER 
        Bitmap[] chr;
        Rectangle frameChr;
        int x, y, ctr, idx;

        public static List<int> SchrTMR = new List<int>();
        public static List<int> Sx = new List<int>();
        public static List<int> Sy = new List<int>();

        //gun
        Bitmap[] tembak;
        List<int> jumlahpeluru = new List<int>();
        List<int> xpeluru = new List<int>();
        List<int> ypeluru = new List<int>();
        List<Rectangle> framePeluru = new List<Rectangle>();
        int Ntembak;

        public static List<int> SgunTMR = new List<int>();
        public static List<int> SgunX = new List<int>();
        public static List<int> SgunY = new List<int>();

        // Backgorund
        Bitmap bg;
        int bggerak, bggerak2;

        
        // Musuh
        Bitmap musuh;
        List<int> jumlahMusuh = new List<int>();
        List<int> xmusuh = new List<int>();
        List<int> ymusuh = new List<int>();
        List<Rectangle> frameMusuh = new List<Rectangle>();

        public static List<int> SmshTMR = new List<int>();
        public static List<int> SmshX = new List<int>();
        public static List<int> SmshY = new List<int>();


        // Batu
        Bitmap[] obstacle;
        int batu;
        List<int> bentukObstalce = new List<int>();
        List<int> xobstacle = new List<int>();
        List<int> yobstacle = new List<int>();
        List<Rectangle> frameBatu = new List<Rectangle>();

        public static List<int> SobsTMR = new List<int>();
        public static List<int> SobsX = new List<int>();
        public static List<int> SobsY = new List<int>();

        //Coin
        Bitmap coin;
        List<int> xCOIN = new List<int>();
        List<int> yCOIN = new List<int>();
        List<Rectangle> frameCoin = new List<Rectangle>();

        public static List<int> ScnTMR = new List<int>();
        public static List<int> ScnX = new List<int>();
        public static List<int> ScnY = new List<int>();
        

        //Shiled
        Bitmap tameng;
        List<int> xtameng = new List<int>();
        List<int> ytameng = new List<int>();
        List<Rectangle> frameTameng = new List<Rectangle>();

        public static List<int> SshldTMR = new List<int>();
        public static List<int> SshldX = new List<int>();
        public static List<int> SshldY = new List<int>();


        //gambar power up
        bool boolPowerup;
        Bitmap powerup;
        Rectangle framePoweup;

        Random rnd = new Random();

        

        private void Play_Load(object sender, EventArgs e)
        {
            xml();

            game = false;
            nama = textBoxNama.Text;
            score = 0;
            nyawa = 3;

            nama = "";
            difficulty = "";
            bggerak = 0;
            bggerak2 = 729;

            bg = new Bitmap(Resource1.BG);

            musuh = new Bitmap(Resource1.plane_3_red);

            obstacle = new Bitmap[3];
            obstacle[0] = new Bitmap(Resource1.obstacle_11);
            obstacle[1] = new Bitmap(Resource1.obstacle_2);
            obstacle[2] = new Bitmap(Resource1.obstacle_3);

            chr = new Bitmap[5];

            chr[0] = new Bitmap(Resource1.Fly_1);
            x = 100;
            y = 100;

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

            //////////////////////////////////
            textBoxNama.Text = "Player";
            

        }

        private void Play_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar("w") || e.KeyChar == Convert.ToChar("a") || e.KeyChar == Convert.ToChar("s") || e.KeyChar == Convert.ToChar("d") || e.KeyChar == Convert.ToChar(Keys.Space))
            {
                if (e.KeyChar == Convert.ToChar("w"))
                {
                    if (nyawa==3)
                    {
                        chr[0] = new Bitmap(Resource1.Fly_1);
                        chr[1] = new Bitmap(Resource1.Fly_1);
                        chr[2] = new Bitmap(Resource1.Fly_2);
                        chr[3] = new Bitmap(Resource1.Fly_2);
                        chr[4] = new Bitmap(Resource1.Fly_1);
                    }
                    else if (nyawa<3)
                    {
                        chr[0] = new Bitmap(Resource1.Dead_1);
                        chr[1] = new Bitmap(Resource1.Dead_1);
                        chr[2] = new Bitmap(Resource1.Fly_1);
                        chr[3] = new Bitmap(Resource1.Fly_2);
                        chr[4] = new Bitmap(Resource1.Fly_1);
                    }
                    y -= 10;
                }
                else if (e.KeyChar == Convert.ToChar("a"))
                {
                    if (nyawa == 3)
                    {
                        chr[0] = new Bitmap(Resource1.Fly_1);
                        chr[1] = new Bitmap(Resource1.Fly_1);
                        chr[2] = new Bitmap(Resource1.Fly_2);
                        chr[3] = new Bitmap(Resource1.Fly_2);
                        chr[4] = new Bitmap(Resource1.Fly_1);
                    }
                    else if (nyawa < 3)
                    {
                        chr[0] = new Bitmap(Resource1.Dead_1);
                        chr[1] = new Bitmap(Resource1.Dead_1);
                        chr[2] = new Bitmap(Resource1.Fly_1);
                        chr[3] = new Bitmap(Resource1.Fly_2);
                        chr[4] = new Bitmap(Resource1.Fly_1);
                    }
                    x -= 10;
                }
                else if (e.KeyChar == Convert.ToChar("s"))
                {
                    if (nyawa == 3)
                    {
                        chr[0] = new Bitmap(Resource1.Fly_1);
                        chr[1] = new Bitmap(Resource1.Fly_1);
                        chr[2] = new Bitmap(Resource1.Fly_2);
                        chr[3] = new Bitmap(Resource1.Fly_2);
                        chr[4] = new Bitmap(Resource1.Fly_1);
                    }
                    else if (nyawa < 3)
                    {
                        chr[0] = new Bitmap(Resource1.Dead_1);
                        chr[1] = new Bitmap(Resource1.Dead_1);
                        chr[2] = new Bitmap(Resource1.Fly_1);
                        chr[3] = new Bitmap(Resource1.Fly_2);
                        chr[4] = new Bitmap(Resource1.Fly_1);
                    }
                    y += 10;
                }
                else if (e.KeyChar == Convert.ToChar("d"))
                {
                    if (nyawa == 3)
                    {
                        chr[0] = new Bitmap(Resource1.Fly_1);
                        chr[1] = new Bitmap(Resource1.Fly_1);
                        chr[2] = new Bitmap(Resource1.Fly_2);
                        chr[3] = new Bitmap(Resource1.Fly_2);
                        chr[4] = new Bitmap(Resource1.Fly_1);
                    }
                    else if (nyawa < 3)
                    {

                        chr[0] = new Bitmap(Resource1.Dead_1);
                        chr[1] = new Bitmap(Resource1.Dead_1);
                        chr[2] = new Bitmap(Resource1.Fly_1);
                        chr[3] = new Bitmap(Resource1.Fly_2);
                        chr[4] = new Bitmap(Resource1.Fly_1);
                    }
                    x += 5;
                }

                else if (e.KeyChar == Convert.ToChar(Keys.Space))
                {
                    chr[0] = new Bitmap(Resource1.Shoot_1);
                    chr[1] = new Bitmap(Resource1.Shoot_2);
                    chr[2] = new Bitmap(Resource1.Shoot_3);
                    chr[3] = new Bitmap(Resource1.Shoot_4);
                    chr[4] = new Bitmap(Resource1.Shoot_5);
                    n++;
                    xpeluru.Add(x+77);
                    ypeluru.Add(y+26);
                    jumlahpeluru.Add(n);

                    SgunTMR.Add(ctr);
                    SgunX.Add(x + 77);
                    SgunY.Add(y + 26);

                }
            }
            
            idx++;

            if (idx > 4)
            {
                idx = 0;
            }
            Invalidate();
            
        }

        private void Play_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            //bg
            g.DrawImage(bg, bggerak, 0, this.Width, this.Height);
            g.DrawImage(bg, bggerak2, 0, this.Width, this.Height);
            
            //karakter
            if (boolPowerup==true)
            {
                g.DrawImage(powerup, x-10, y-10, 100, 80);
                framePoweup = new Rectangle(x-10, y-10, 100, 80);
            }
            g.DrawImage(chr[idx], x, y, 77, 53);
            frameChr = new Rectangle(x, y, 77, 53);
            

            //Batu
            for (int i = 0; i < bentukObstalce.Count; i++)
            {
                if (bentukObstalce[i]==0)
                {
                    g.DrawImage(obstacle[bentukObstalce[i]], xobstacle[i], yobstacle[i], 40, 35);
                }
                else if (bentukObstalce[i] == 1)
                {
                    g.DrawImage(obstacle[bentukObstalce[i]], xobstacle[i], yobstacle[i], 30, 20);
                }
                else if (bentukObstalce[i] == 2)
                {
                    g.DrawImage(obstacle[bentukObstalce[i]], xobstacle[i], yobstacle[i], 35, 25);
                }
            }
            //pesawat musuh
            for (int i = 0; i < jumlahMusuh.Count; i++)
            {
                g.DrawImage(musuh, xmusuh[i], ymusuh[i], 75, 50);

            }
            //gun
            for (int i = 0; i < jumlahpeluru.Count; i++)
            {
                g.DrawImage(tembak[Ntembak],xpeluru[i],ypeluru[i],15,20);
            }
            //coin
            for (int i = 0; i < xCOIN.Count; i++)
            {
                g.DrawImage(coin, xCOIN[i], yCOIN[i], 50, 50);
            }
            //tameng
            for (int i = 0; i < xtameng.Count; i++)
            {
                g.DrawImage(tameng, xtameng[i], ytameng[i], 60, 55);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            nama = textBoxNama.Text;
            if (radioButtonEasy.Checked)
            {
                difficulty = "Easy";
                tambahCoin = 2;

                gerakTameng = 9;
                gerakCoin = 9;
                gerakBatu = 5;
                gerakMusuh = 7;

                munculBatu = 30;
                munculMusuh = 50;
                munculCoin = 20;
                munculTameng = 60;
            }
            else if (radioButtonNormal.Checked)
            {
                difficulty = "Normal";
                tambahCoin = 4;

                gerakTameng = 9;
                gerakCoin = 9;
                gerakBatu = 8;
                gerakMusuh = 10;


                munculBatu = 20;
                munculMusuh = 30;
                munculCoin = 10;
                munculTameng = 60;
            }
            else if (radioButtonHard.Checked)
            {
                difficulty = "Hard";
                tambahCoin = 6;

                gerakTameng = 6;
                gerakCoin = 8;
                gerakBatu = 10;
                gerakMusuh = 14;
                
                munculBatu = 15;
                munculMusuh = 20;
                munculCoin = 10;
                munculTameng = 50;
            }

            if (nama == "" || difficulty == "")
            {
                MessageBox.Show("Nama masih kosong atau Level belum di isi");
            }
            else
            {
                groupBox1.Enabled = false;
                groupBox1.Visible = false;
                textBoxNama.Enabled = false;
                textBoxNama.Visible = false;
                game = true;

                timerbg.Start();
                timergame.Start();

                this.BringToFront();
                this.Focus();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            
            if (Ntembak<4)
            {
                Ntembak++;
            }
            else
            {
                Ntembak = 0;
            }

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

            labelNama.Text=nama;
            labelNyawa.Text = nyawa.ToString();
            labelScore.Text = score.ToString();
        }

        private void timergame_Tick(object sender, EventArgs e)
        {
            if (game==true)
            {
                ctr++;

                SchrTMR.Add(ctr);
                Sx.Add(x);
                Sy.Add(y);

                muncul();
                frame();
                gerak();
                

                if (nyawa<0)
                {
                    kalah();
                    savegameplay();
                }

                Invalidate();

            }
        }

        void gerak()
        {

            // tameng
            if (xtameng.Count > 0)
            {
                for (int i = 0; i < xtameng.Count; i++)
                {
                    frameTameng[i] = new Rectangle(xtameng[i], ytameng[i], 60, 55);
                    if (xtameng[i] < 10)
                    {
                        xtameng.RemoveAt(i);
                        ytameng.RemoveAt(i);
                    }
                    else
                    {
                        xtameng[i] -= gerakTameng;
                    }
                    if (frameTameng.Count>0)
                    {
                        if (frameChr.IntersectsWith(frameTameng[i]))
                        {
                            boolPowerup = true;
                            xtameng.RemoveAt(i);
                            ytameng.RemoveAt(i);
                            frameTameng.RemoveAt(i);
                        }
                    }
                }
            }

            if (boolPowerup==true)
            {
                for (int i = 0; i < xobstacle.Count; i++)
                {
                    if (framePoweup.IntersectsWith(frameMusuh[i]))
                    {
                        jumlahMusuh.RemoveAt(i);
                        xmusuh.RemoveAt(i);
                        ymusuh.RemoveAt(i);
                        frameMusuh.RemoveAt(i);
                        boolPowerup = false;
                    }
                }
                for (int i = 0; i < xobstacle.Count; i++)
                {
                    if (framePoweup.IntersectsWith(frameBatu[i]))
                    {
                        xobstacle.RemoveAt(i);
                        yobstacle.RemoveAt(i);
                        bentukObstalce.RemoveAt(i);
                        frameBatu.RemoveAt(i);
                        boolPowerup = false;
                    }
                }
            }

            // coin
            if (xCOIN.Count > 0)
            {
                for (int i = 0; i < xCOIN.Count; i++)
                {
                    frameCoin[i] = new Rectangle(xCOIN[i], yCOIN[i], 50, 50);
                    if (xCOIN[i] < 10)
                    {
                        xCOIN.RemoveAt(i);
                        yCOIN.RemoveAt(i);
                    }
                    else
                    {
                        xCOIN[i] -= gerakCoin;
                    }
                    if (frameCoin.Count > 0)
                    {
                        if (frameChr.IntersectsWith(frameCoin[i]))
                        {
                            score += tambahCoin;
                            xCOIN.RemoveAt(i);
                            yCOIN.RemoveAt(i);
                            frameCoin.RemoveAt(i);
                        }
                    }

                }
            }

            // batu
            if (bentukObstalce.Count > 0)
            {
                for (int i = 0; i < bentukObstalce.Count; i++)
                {
                    if (bentukObstalce[i] == 0)
                    {
                        frameBatu[i] = new Rectangle(xobstacle[i], yobstacle[i], 40, 35);
                    }
                    else if (bentukObstalce[i] == 1)
                    {
                        frameBatu[i] = new Rectangle(xobstacle[i], yobstacle[i], 30, 20);
                    }
                    else if (bentukObstalce[i] == 2)
                    {
                        frameBatu[i] = new Rectangle(xobstacle[i], yobstacle[i], 35, 25);
                    }
                    if (xobstacle[i] < 0)
                    {
                        xobstacle.RemoveAt(i);
                        yobstacle.RemoveAt(i);
                        bentukObstalce.RemoveAt(i);
                        frameBatu.RemoveAt(i);
                    }
                    else
                    {
                        xobstacle[i] -= gerakBatu;
                    }

                    if (frameBatu.Count > 0)
                    {
                        for (int j = 0; j < bentukObstalce.Count; j++)
                        {
                            if (frameChr.IntersectsWith(frameBatu[j]))
                            {
                                nyawa -= 1;
                                xobstacle.RemoveAt(j);
                                yobstacle.RemoveAt(j);
                                bentukObstalce.RemoveAt(j);
                                frameBatu.RemoveAt(j);
                            }
                        }
                    }
                }
            }

            // musuh
            if (xmusuh.Count > 0)
            {
                for (int i = 0; i < xmusuh.Count; i++)
                {
                    frameMusuh[i] = new Rectangle(xmusuh[i], ymusuh[i], 75, 50);
                    if (xmusuh[i] == 10)
                    {
                        jumlahMusuh.RemoveAt(i);
                        xmusuh.RemoveAt(i);
                        ymusuh.RemoveAt(i);
                        frameMusuh.RemoveAt(i);
                    }
                    else
                    {
                        xmusuh[i] -= gerakMusuh;
                    }
                    if (frameMusuh.Count > 0)
                    {
                        for (int j = 0; j < xmusuh.Count; j++)
                        {
                            if (frameChr.IntersectsWith(frameMusuh[j]))
                            {
                                nyawa -= 1;
                                jumlahMusuh.RemoveAt(j);
                                xmusuh.RemoveAt(j);
                                ymusuh.RemoveAt(j);
                                frameMusuh.RemoveAt(j);
                            }
                        }
                    }
                }
            }

            // peluru
            if (jumlahpeluru.Count > 0)
            {
                for (int i = 0; i < jumlahpeluru.Count; i++)
                {
                    framePeluru[i] = new Rectangle(xpeluru[i], ypeluru[i], 15, 20);
                    if (xpeluru[i] >= 730)
                    {
                        jumlahpeluru.RemoveAt(i);
                        xpeluru.RemoveAt(i);
                        ypeluru.RemoveAt(i);
                        framePeluru.RemoveAt(i);
                    }
                    else
                    {
                        xpeluru[i] += 9;
                    }
                    if (framePeluru.Count>0)
                    {
                        for (int j = 0; j < jumlahpeluru.Count ; j++)
                        {
                            for (int k = 0; k < jumlahMusuh.Count ; k++)
                            {
                                if (framePeluru[j].IntersectsWith(frameMusuh[k]))
                                {
                                    jumlahpeluru.RemoveAt(j);
                                    xpeluru.RemoveAt(j);
                                    ypeluru.RemoveAt(j);
                                    framePeluru.RemoveAt(j);

                                    jumlahMusuh.RemoveAt(k);
                                    xmusuh.RemoveAt(k);
                                    ymusuh.RemoveAt(k);
                                    frameMusuh.RemoveAt(k);

                                    score += 1;
                                }
                            }
                        }

                        for (int j = 0; j < jumlahpeluru.Count; j++)
                        {
                            for (int k = 0; k < frameBatu.Count; k++)
                            {
                                if (framePeluru[j].IntersectsWith(frameBatu[k]))
                                {
                                    jumlahpeluru.RemoveAt(j);
                                    xpeluru.RemoveAt(j);
                                    ypeluru.RemoveAt(j);
                                    framePeluru.RemoveAt(j);
                                }
                            }

                        }
                    }
                }
            }
        }

        public static void xml()
        {
            LNama.Clear();
            Lscore.Clear();
            Ldifficulty.Clear();
            try
            {
                string nodeName = "";
                XmlTextReader xReader = new XmlTextReader(Application.StartupPath + "\\Score.xml");
                while (xReader.Read())
                {
                    switch (xReader.NodeType)
                    {
                        case XmlNodeType.Element:
                            nodeName = xReader.Name;
                            break;
                        case XmlNodeType.Text:

                            if (nodeName == "Name")
                            {
                                LNama.Add(xReader.Value);
                            }
                            else if (nodeName == "Difficulty")
                            {
                                Ldifficulty.Add(xReader.Value);
                            }
                            else if (nodeName == "Score")
                            {
                                Lscore.Add(Convert.ToInt32(xReader.Value));
                            }
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

        void frame()
        {
            for (int i = 0; i < xmusuh.Count; i++)
            {
                frameMusuh.Add(new Rectangle(xmusuh[i], ymusuh[i], 75, 50));
            }

            for (int i = 0; i < xobstacle.Count; i++)
            {

                if (bentukObstalce[i] == 0)
                {
                    frameBatu.Add(new Rectangle(xobstacle[i], yobstacle[i], 40, 35));
                }
                else if (bentukObstalce[i] == 1)
                {
                    frameBatu.Add(new Rectangle(xobstacle[i], yobstacle[i], 30, 20));
                }
                else if (bentukObstalce[i] == 2)
                {
                    frameBatu.Add(new Rectangle(xobstacle[i], yobstacle[i], 35, 25));
                }
            }

            for (int i = 0; i < jumlahpeluru.Count; i++)
            {
                framePeluru.Add(new Rectangle(xpeluru[i], ypeluru[i], 15, 20));
            }

            for (int i = 0; i < xCOIN.Count; i++)
            {
                frameCoin.Add(new Rectangle(xCOIN[i], yCOIN[i], 50, 50));
            }

            for (int i = 0; i < xtameng.Count; i++)
            {
                frameTameng.Add(new Rectangle(xtameng[i], ytameng[i], 60, 55));
            }

        }

        void muncul()
        {
            // batu
            if (ctr % munculBatu == 0)
            {
                batu = rnd.Next(0, 3);
                bentukObstalce.Add(batu);
                int yobs = rnd.Next(0, this.Height - 20);

                xobstacle.Add(720);
                yobstacle.Add(yobs);

                SobsTMR.Add(ctr);
                SobsX.Add(720);
                SobsY.Add(yobs);
               
            }

            //musuh
            if (ctr % munculMusuh == 0)
            {
                jumlahMusuh.Add(1);
                xmusuh.Add(750);
                int ymsh = rnd.Next(0, 480);
                ymusuh.Add(ymsh);

                SmshTMR.Add(ctr);
                SmshX.Add(750);
                SmshY.Add(ymsh);

            }

            //tameng
            if (ctr % munculTameng == 0)
            {
                xtameng.Add(750);
                int rndytameng = rnd.Next(0, 480);
                ytameng.Add(rndytameng);

                SshldTMR.Add(ctr);
                SshldX.Add(750);
                SshldY.Add(rndytameng);

            }

            //coin
            if (ctr % munculCoin == 0)
            {
                xCOIN.Add(750);
                int ycoin = rnd.Next(0, 480);
                yCOIN.Add(ycoin);

                ScnTMR.Add(ctr);
                ScnX.Add(750);
                ScnY.Add(ycoin);

            }
        }

        string a,b,c,d,e;

        void kalah()
        {
            LNama.Add(nama);
            Ldifficulty.Add(difficulty);
            Lscore.Add(score);

            savegameplay();

            game = false;
            timergame.Stop();
            timerbg.Stop();

            XmlWriterSettings xSetting = new XmlWriterSettings();
            xSetting.Indent = true;
            XmlWriter xWriter = XmlWriter.Create(Application.StartupPath +  "\\Score.xml",xSetting);

            xWriter.WriteStartDocument();
            xWriter.WriteStartElement("Game");
                for (int i = 0; i < LNama.Count; i++)
                {
                    xWriter.WriteStartElement("Player");
                    xWriter.WriteElementString("Name", LNama[i]);
                    xWriter.WriteElementString("Difficulty", Ldifficulty[i]);
                    xWriter.WriteElementString("Score", Lscore[i].ToString());
                    xWriter.WriteEndElement();
                }
            xWriter.WriteEndElement();
            xWriter.WriteEndDocument();

            xWriter.Close();


            DialogResult dialogResult = MessageBox.Show("Hai " + nama + " anda telah kalah" + "\n Apakah anda ingin main kembali ?", "Game over", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                mainlagi();
            }
            else if (dialogResult == DialogResult.No)
            {
                this.Close();
            }
        }

        void savegameplay()
        {
            XmlWriterSettings xSetting = new XmlWriterSettings();
            xSetting.Indent = true;
            XmlWriter xWriter = XmlWriter.Create(Application.StartupPath + "\\Replay.xml", xSetting);

            xWriter.WriteStartDocument();
            xWriter.WriteStartElement("Repalay");
            //chr
                for (int i = 0; i < SchrTMR.Count; i++)
                {
                    xWriter.WriteStartElement("Character");
                    xWriter.WriteElementString("SchrTMR", SchrTMR[i].ToString());
                    xWriter.WriteElementString("Sx", Sx[i].ToString());
                    xWriter.WriteElementString("Sy", Sy[i].ToString());
                    xWriter.WriteEndElement();
                }
            //batu
                for (int i = 0; i < SobsTMR.Count; i++)
                {
                    xWriter.WriteStartElement("Obstacle");
                    xWriter.WriteElementString("SobsTMR", SobsTMR[i].ToString());
                    xWriter.WriteElementString("SobsX", SobsX[i].ToString());
                    xWriter.WriteElementString("SobsY", SobsY[i].ToString());
                    xWriter.WriteEndElement();
                }
            //musuh
                for (int i = 0; i < SmshTMR.Count; i++)
                {
                    xWriter.WriteStartElement("Musuh");
                    xWriter.WriteElementString("SmshTMR", SmshTMR[i].ToString());
                    xWriter.WriteElementString("SmshX", SmshX[i].ToString());
                    xWriter.WriteElementString("SmshY", SmshY[i].ToString());
                    xWriter.WriteEndElement();
                }
            //coin
                for (int i = 0; i < ScnTMR.Count; i++)
                {
                    xWriter.WriteStartElement("Coin");
                    xWriter.WriteElementString("ScnTMR", ScnTMR[i].ToString());
                    xWriter.WriteElementString("ScnX", ScnX[i].ToString());
                    xWriter.WriteElementString("ScnY", ScnY[i].ToString());
                    xWriter.WriteEndElement();
                }
            //Tameng
                for (int i = 0; i < SshldTMR.Count; i++)
                {
                    xWriter.WriteStartElement("Tameng");
                    xWriter.WriteElementString("SshldTMR", SshldTMR[i].ToString());
                    xWriter.WriteElementString("SshldX", SshldX[i].ToString());
                    xWriter.WriteElementString("SshldY", SshldY[i].ToString());
                    xWriter.WriteEndElement();
                }
            //Gun
                for (int i = 0; i < SgunTMR.Count; i++)
                {
                    xWriter.WriteStartElement("Gun");
                    xWriter.WriteElementString("SgunTMR", SgunTMR[i].ToString());
                    xWriter.WriteElementString("SgunX", SgunX[i].ToString());
                    xWriter.WriteElementString("SgunY", SgunY[i].ToString());
                    xWriter.WriteEndElement();
                }
            xWriter.WriteEndElement();
            xWriter.WriteEndDocument();

            xWriter.Close();
        }
        
        void Hapus()
        {
            LNama.Clear();
            Ldifficulty.Clear();
            Lscore.Clear();

            SchrTMR.Clear();
            Sx.Clear();
            Sy.Clear();

            jumlahpeluru.Clear();
            xpeluru.Clear();
            ypeluru.Clear();
            framePeluru.Clear();
            SgunTMR.Clear();
            SgunX.Clear();
            SgunY.Clear();

            jumlahMusuh.Clear();
            xmusuh.Clear();
            ymusuh.Clear();
            frameMusuh.Clear();
            SmshTMR.Clear();
            SmshX.Clear();
            SmshY.Clear();

            bentukObstalce.Clear();
            xobstacle.Clear();
            yobstacle.Clear();
            frameBatu.Clear();
            SobsTMR.Clear();
            SobsX.Clear();
            SobsY.Clear();

            xCOIN.Clear();
            yCOIN.Clear();
            frameCoin.Clear();
            ScnTMR.Clear();
            ScnX.Clear();
            ScnY.Clear();

            xtameng.Clear();
            ytameng.Clear();
            frameTameng.Clear();
            SshldTMR.Clear();
            SshldX.Clear();
            SshldY.Clear();

            boolPowerup = false;
        }

        void mainlagi()
        {
            Hapus();

            idx = 0;
            ctr = 0;
            x = 100;
            y = 100;
            score = 0;
            nyawa = 3;
            ctr = 0;

            timerbg.Start();
            timergame.Start();
            game = true;
        }

        //////
    }
}
//for (int i = 0; i<LNama.Count; i++)
//                    {
//                        xWriter.WriteStartElement("Player");
//                            xWriter.WriteElementString("Name", LNama[i]);
//                            xWriter.WriteElementString("Difficulty", Ldifficulty[i]);
//                            xWriter.WriteElementString("Score", Lscore[i].ToString());
//                        xWriter.WriteEndElement();
//                    }

//xWriter.WriteStartElement("Nama");
//    xWriter.WriteString(nama);

//    xWriter.WriteElementString("Difficulty", difficulty);
//    xWriter.WriteEndElement();

//    xWriter.WriteElementString("Score",score.ToString());
//    xWriter.WriteEndElement();

//xWriter.WriteEndElement();

////xWriter.WriteAttributeString("Nama",nama);
////xWriter.WriteAttributeString("Difficulty", difficulty);
////xWriter.WriteAttributeString("Score", score.ToString());