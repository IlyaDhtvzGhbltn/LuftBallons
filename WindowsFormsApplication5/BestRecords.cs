using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication5
{
    class BestRecords
    {
        public static int firstVin = Properties.Settings.Default.countFirst;
        public static int secondVin = Properties.Settings.Default.countSecond;
        public static int thirdVin = Properties.Settings.Default.countThird;

        public static string firstVint = Properties.Settings.Default.firstVin;
        public static string secondVint = Properties.Settings.Default.secondVin;
        public static string thirdVint = Properties.Settings.Default.thirdVin;

        

        public void labelRecordsCreate(Form1 f, int value, string Name)
        {

            if (value > firstVin) { firstVin = value; firstVint = Name; }
            if (value > secondVin && value < firstVin) { secondVin = value; secondVint = Name; }
            if (value > thirdVin && value < secondVin) { thirdVin = value; thirdVint = Name; }

                f.label6.Text = firstVin.ToString();
                f.label9.Text= secondVin.ToString();
                f.label11.Text = thirdVin.ToString();

                f.label7.Text = firstVint;
                f.label8.Text = secondVint;
                f.label10.Text = thirdVint;
            


        }
    }
}