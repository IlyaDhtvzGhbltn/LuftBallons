using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace WindowsFormsApplication5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            foreach (PictureBox PBM in this.groupBox2.Controls.OfType<PictureBox>()) {
                PBM.MouseHover += new EventHandler(HoverMenu);
            }
            foreach (PictureBox PBM in this.groupBox5.Controls.OfType<PictureBox>()) {
                PBM.MouseHover += new EventHandler(HoverMenu2);
                PBM.MouseLeave += new EventHandler(LeaveMenu2);

            }

            foreach (PictureBox PMusic in this.groupBox2.Controls.OfType<PictureBox>())
            {
                PMusic.MouseClick += new MouseEventHandler(Music);
            }

            foreach (PictureBox PMusic in this.groupBox5.Controls.OfType<PictureBox>())
            {
                PMusic.MouseClick += new MouseEventHandler(Music);
            }
            foreach (PictureBox PMusic in this.groupBox1.Controls.OfType<PictureBox>())
            {
                PMusic.MouseClick += new MouseEventHandler(Music);
            }


        }

        private void Music(object sender, EventArgs e)
        {
            SoundPlayer C = new SoundPlayer(Properties.Resources.click);
            C.Play();

        }
        int xst = 50;
        int yst = 210;
        int xx = 119;
        int yy = 192;
        public int t = 20;
        int rebrowsBigColors = 8;
        int rebrowsLittleColors = 6;
        int lTimer = 0;

        public int rightCounts;
        public int valueLevel = 3;

       
        private void HoverMenu2(object sender, EventArgs e) {
            pictureBox10.Visible = true;
            pictureBox9.Visible = true;
        }
        private void LeaveMenu2(object sender, EventArgs e)
        {
            pictureBox10.Visible = false;
            pictureBox9.Visible = false;
        }

        private void HoverMenu(object sender, EventArgs e) {
            SizeBig(sender as PictureBox);
        }
        private void SizeBig(PictureBox forBig) {
            pictureBox5.Visible = true;
            pictureBox6.Visible = true;
            if (forBig.Size.Width >30){
            pictureBox5.Location = new Point(forBig.Location.X - 40, forBig.Location.Y);
            pictureBox6.Location = new Point(forBig.Location.X + 210, forBig.Location.Y);
            }
        }
        private void leaveMainMenu(Control P) {
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            

        }


        int r = 1;

        private void timer1_Tick(object sender, EventArgs e)
        {
            

            t--;
            if (t % rebrowsBigColors == 0 && valueLevel <= 6)
            {
                valueLevel++;
            }

            else if (t % 4 == 0 && valueLevel == 6)
            {
                valueLevel = 7;
            }

            lTimer++;

            if (t < 10)
            {
                label4.Text = "00:" + "0" + t.ToString();
            }
            else if (t >= 10 && t < 60)
            {
                label4.Text = "00:" + t.ToString();
            }
            else if (t >= 60 && t < 360)
            {
                int y = t / 60;
                label4.Text = "0" + y + ":" + (t - (y * 60)).ToString();
            }
            if (t<=0){
                timer1.Enabled = false;
                valueLevel = 3;
                lTimer = 0;
                CreatorColor RR = new CreatorColor(this);
                RR.visibleColors(this);

                BestRecords BB = new BestRecords();
                BB.labelRecordsCreate(this,Convert.ToInt32(label1.Text), label3.Text);
                
                groupBox4.Visible = true;
                groupBox4.Location = new Point(140, 76);
                pictureBox12.Visible = true;
                t = 60;
                pictureBox14.Visible = true;
                pictureBox13.Visible = false;
                this.BackgroundImage = Properties.Resources.window2;
            }



            if (lTimer == rebrowsLittleColors)
            {
                foreach (PictureBox PBV in this.Controls.OfType<PictureBox>())
                {
                    object tag = PBV.Tag;

                    if (Convert.ToInt32(tag) >= 0 && PBV.Size.Equals(new Size(60, 60)))
                    {
                        PBV.Visible = false;
                    }

                }

            }

            if (lTimer == rebrowsBigColors && valueLevel < 7)
            {


                int rrt = Convert.ToInt32(label1.Text);

                CreatorColor RR = new CreatorColor(this);

                RR.visibleColors(this);
                RR.Create(this, valueLevel, xst, yst, xx, yy, rrt);
                lTimer = 0;
            }


            if (lTimer == rebrowsBigColors && valueLevel == 7)
            {
                int rrt = Convert.ToInt32(label1.Text);
                CreatorColor RR = new CreatorColor(this);

                RR.visibleColors(this);
                RR.Create(this, valueLevel, xst, yst, xx, yy, rrt);

                CreatorColor RR2 = new CreatorColor(this);
                RR2.Create(this, r, xst, yst + 110, xx, yy + 110, rrt);

                lTimer = 0;

                if (r < 7)
                {
                    r++;
                }
                if (t >= 60) 
                { Records(rrt); 
                }

            }


            int x = Convert.ToInt32(label1.Text);
            if (x < 0)
            {
                timer1.Enabled = false;
                t = 0;
                label1.Text = rightCounts.ToString();
                CreatorColor RR = new CreatorColor(this);
                RR.visibleColors(this);
                valueLevel = 3;
                MessageBox.Show("Вы проиграли "+ " Начните новую игру");
                groupBox1.Visible = false;
                groupBox2.Visible = true;
                Image Back = Properties.Resources.window2;
                this.BackgroundImage = Back;
                pictureBox13.Visible = false;
                pictureBox14.Visible = true;
                pictureBox12.Visible = true;



            }


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(""+"Данная опция недоступна в Демо версии");
            //groupBox3.Visible = true;
            //groupBox3.Location = new Point(229, 57);
        }
                private void Records(int value ) { }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            groupBox5.Visible = true;
            groupBox1.Visible = false;
            groupBox1.Location= new Point(232, 6);
            groupBox5.Location = new Point(327,6);
            groupBox2.Visible = false;
            valueLevel = 3;
            t = 60;

        }

    
        private void Form1_Load(object sender, EventArgs e)
        {
            BestRecords.firstVin = Properties.Settings.Default.countFirst;
            BestRecords.secondVin = Properties.Settings.Default.countSecond;
            BestRecords.thirdVin = Properties.Settings.Default.countThird;

            BestRecords.firstVint = Properties.Settings.Default.firstVin;
            BestRecords.secondVint = Properties.Settings.Default.secondVin;
            BestRecords.thirdVint = Properties.Settings.Default.thirdVin;

            label6.Text = BestRecords.firstVin.ToString();
            label9.Text = BestRecords.secondVin.ToString();
            label11.Text = BestRecords.thirdVin.ToString();

            label7.Text = BestRecords.firstVint;
            label8.Text = BestRecords.secondVint;
            label10.Text = BestRecords.thirdVint;

            //axWindowsMediaPlayer1.URL = "track1.wav";
            //axWindowsMediaPlayer1.Ctlcontrols.play();
            //axWindowsMediaPlayer1.settings.setMode("loop", true);
         

            groupBox2.Location = new Point(272, 58);
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = false;
            groupBox2.Visible = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

            Properties.Settings.Default.countFirst = BestRecords.firstVin;
            Properties.Settings.Default.countSecond = BestRecords.secondVin;
            Properties.Settings.Default.countThird = BestRecords.thirdVin;

            Properties.Settings.Default.firstVin = BestRecords.firstVint;
            Properties.Settings.Default.secondVin = BestRecords.secondVint;
            Properties.Settings.Default.thirdVin = BestRecords.thirdVint;

            Properties.Settings.Default.Save();
            this.Close();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length >=3 && textBox1.Text.Length <=8){
            groupBox5.Visible = false;
            label3.Text = textBox1.Text.ToString();
            groupBox1.Visible = true;
            label4.Text = "3:00";
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("" + "Данная опция недоступна в Демо версии");

            //groupBox4.Visible = true;
            //groupBox4.Location = new Point(137, 77);
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox11_Click_1(object sender, EventArgs e)
        {
            groupBox4.Visible = false;

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            pictureBox13.Visible = true;
            pictureBox14.Visible = false;

            Image BC = Properties.Resources.window3;
            this.BackgroundImage = BC;

            int trrt = Convert.ToInt32(label1.Text);

            CreatorColor RR = new CreatorColor(this);

            RR.Create(this, valueLevel, xst, yst, xx, yy, trrt);

            timer1.Enabled = true;
            pictureBox12.Visible = false;
            valueLevel = 3;
            t = 180;
            lTimer = 0;
            rightCounts = 0;
            label1.Text = "0";
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            //groupBox4.Visible = true;
            //groupBox4.Location = new Point(137, 77);
            pictureBox14.Visible = true;
            pictureBox13.Visible = false;
            label4.Text = "0:00";
            pictureBox12.Visible = true;
            Image BC = Properties.Resources.window2;
            this.BackgroundImage = BC;
            CreatorColor cc = new CreatorColor(this);
            valueLevel = 3;
            cc.visibleColors(this);
            Controls.Remove(cc);
            timer1.Enabled = false;
            rightCounts = 0;
            t = 180;
            lTimer = 0;
            label1.Text = rightCounts.ToString();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            pictureBox12.Visible = true;

            Image BC = Properties.Resources.window2;
            this.BackgroundImage = BC;

            timer1.Enabled = false;
            t = 0;
            label1.Text = rightCounts.ToString();
            CreatorColor RR = new CreatorColor(this);
            RR.visibleColors(this);
            label4.Text = "0";
            valueLevel = 3;

            groupBox1.Visible = false;
            groupBox2.Visible = true;
            groupBox2.Location = new Point(272, 58);
        }



    }
}


