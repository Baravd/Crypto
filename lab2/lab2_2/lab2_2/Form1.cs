using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using System.Diagnostics;

namespace lab2_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            int nr1 = 111120;
            int nr2 = 120872;
           /* byte[] nrMare1 =
            {
                7, 7, 7, 6, 7, 6, 7, 7, 2, 7, 7, 7, 1, 0, 2, 3, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 5, 3, 7, 6,
                7
            };
            byte[] nrMare2 = {11, 7, 2, 7, 4, 7, 6, 7, 5};*/

            Computer computer = new Computer();

            Stopwatch sw = new Stopwatch();

            sw.Start();
            int aux = computer.gcdEuclid(nr1, nr2);
            sw.Stop();
            long microseconds1 = sw.ElapsedTicks / (Stopwatch.Frequency / (1000L * 1000L));

            sw.Start();
            aux = computer.gcdScaderi(nr1, nr2);
            label1.Text = aux.ToString();

            sw.Stop();
           

            long microseconds2 = sw.ElapsedTicks / (Stopwatch.Frequency / (1000L * 1000L));

            sw.Start();
            aux = computer.gcdFor(nr1, nr2);
            sw.Stop();
            label2.Text = aux.ToString();

            long microseconds3 = sw.ElapsedTicks / (Stopwatch.Frequency / (1000L * 1000L));

            label3.Text = aux.ToString();


            BigInteger bigInteger = BigInteger.Parse("1234567891011121314151617181920");
            this.Text = bigInteger.ToString();
            BigInteger bigInteger2 = BigInteger.Parse("9876543211011121314151617181920");

            sw.Start();
            BigInteger aux2 = computer.gcdNrMari(bigInteger, bigInteger2);
            sw.Stop();
            long microseconds4 = sw.ElapsedTicks / (Stopwatch.Frequency / (1000L * 1000L));
            label3.Text = aux2.ToString();

            chart1.Series["GCD"].Points.AddXY("Euclid", microseconds1);
            chart1.Series["GCD"].Points.AddXY("Scaderi", microseconds2);
            chart1.Series["GCD"].Points.AddXY("For SQRT", microseconds3);
            chart1.Series["GCD"].Points.AddXY("Euclid nr mari", microseconds4);
          
        }
    }
}