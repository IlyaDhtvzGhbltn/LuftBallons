using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Media;
namespace WindowsFormsApplication5
{

   
   public class CreatorColor : Form1
    {
       public int CC=0;

       private Form1 _f;
       public CreatorColor(Form1 f1)
       {
           _f = f1;
       }

      //Значения с обоих обьектов класса записываються в ОДИН массив!!!

          public int[] arrTags = new int[]{};
          public string[] arrNames = new string[]{};

         

          public  int rightCount ;

           public void Create(Form form1, int boxValue, int startX, int startY, int litleX, int littleY,  int rio) {
           int yy = littleY;
           CC = rio;
           Random R = new Random();
           int[] arrNumbersTag = new int[boxValue+1];
           string[] arrColorsNames = new string[boxValue+1];

           Image Red = Properties.Resources.balls_R;
           Image Green = Properties.Resources.balls_G;
           Image Blue = Properties.Resources.balls_B;
           Image littleRed = Properties.Resources.balls_L_R;
           Image littleGreen = Properties.Resources.balls_L_G;
           Image littleBlue = Properties.Resources.balls_L_B;


           for (int i = 0; i < boxValue; i++)
           {

              System.Windows.Forms.PictureBox[] PB = new System.Windows.Forms.PictureBox[boxValue];
               PB[i] = new System.Windows.Forms.PictureBox();
               PB[i].Location = new System.Drawing.Point(startX, startY);
               PB[i].Size = new System.Drawing.Size(60,60);
               PB[i].Tag = i;
               arrNumbersTag[i] = i;



               int colorThis = R.Next(0, 3);
               if (colorThis == 0)
               {
                   //PB[i].BackColor = System.Drawing.Color.Red;
                   PB[i].BackgroundImage = Red;
                   PB[i].Name = "R";
                   arrColorsNames[i] = PB[i].Name;

               }

                else if (colorThis == 1)
               {

                   //PB[i].BackColor = System.Drawing.Color.Green;
                   PB[i].BackgroundImage = Green;
                   PB[i].Name = "G";
                   arrColorsNames[i] = PB[i].Name;

               }

               else if (colorThis == 2 ) 
               {

                   //PB[i].BackColor = System.Drawing.Color.Blue;
                   PB[i].BackgroundImage = Blue;
                   PB[i].Name = "B";
                   arrColorsNames[i] = PB[i].Name;

               }

              

               form1.Controls.Add(PB[i]);
               arrNames = arrColorsNames;
               arrTags = arrNumbersTag;

               int color=0;

               for (int ii =0;  ii <= 2; ii++) {
                    System.Windows.Forms.PictureBox[] PP = new System.Windows.Forms.PictureBox[3];
                    PP[ii] = new System.Windows.Forms.PictureBox();
                    PP[ii].Location = new System.Drawing.Point(litleX,littleY);
                    PP[ii].Size = new System.Drawing.Size(30,30);
                    PP[ii].Tag = i;

                   if (color == 0 ){
                  //  PP[ii].BackColor = System.Drawing.Color.Red;
                    PP[ii].BackgroundImage = littleRed;
                    PP[ii].Name = "R";

                   }
                   else if (color == 1) {
                  //     PP[ii].BackColor = System.Drawing.Color.Green;
                       PP[ii].BackgroundImage = littleGreen;
                       PP[ii].Name = "G";

                   }
                   else if (color == 2) {
                    //   PP[ii].BackColor = System.Drawing.Color.Blue;
                       PP[ii].BackgroundImage = littleBlue;
                       PP[ii].Name = "B";

                   }
                    littleY = littleY + 35;
                    color++;
                    form1.Controls.Add(PP[ii]);

                    PP[ii].MouseClick += new MouseEventHandler(Click);
               }
               
               littleY = yy;
               litleX = litleX + 110;
               startX = startX + 110;

              
           }

           
       }
      


       public void Click(object sender, EventArgs e) {
           TagSearch(sender as Control);
           
           
       }

       public void TagSearch(Control cc) {
           SoundPlayer S = new SoundPlayer(Properties.Resources.ok);
           SoundPlayer F = new SoundPlayer(Properties.Resources.n);
           object d = cc.Tag;
           object n = cc.Name;
           int x = Convert.ToInt16(d);
           string y = Convert.ToString(n);
           cc.Visible = false;
           

           if (arrTags[x] == x && arrNames[x] == y)
           {
               CC++;
               S.Play();
              
           }
           else
           {
               CC--;
               F.Play();
           }
           text(CC);

       }


       public void text(int x) 
       {
           _f.label1.Text = x.ToString();

       }
       

       public void visibleColors(Form form1)
       {
           foreach (PictureBox PPB in form1.Controls.OfType<PictureBox>())
           {
               PPB.Visible = false;
           }
    


       }

       private void InitializeComponent()
       {
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.Size = new System.Drawing.Size(87, 24);
            this.label10.Text = "Gamer03";
            // 
            // label11
            // 
            this.label11.Size = new System.Drawing.Size(20, 24);
            this.label11.Text = "0";
            // 
            // label8
            // 
            this.label8.Size = new System.Drawing.Size(87, 24);
            this.label8.Text = "Gamer02";
            // 
            // label9
            // 
            this.label9.Size = new System.Drawing.Size(20, 24);
            this.label9.Text = "0";
            // 
            // label7
            // 
            this.label7.Size = new System.Drawing.Size(87, 24);
            this.label7.Text = "Gamer01";
            // 
            // label6
            // 
            this.label6.Size = new System.Drawing.Size(20, 24);
            this.label6.Text = "0";
            // 
            // CreatorColor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(900, 500);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "CreatorColor";
            this.ResumeLayout(false);
            this.PerformLayout();

       }

      

     
   
   }


}
