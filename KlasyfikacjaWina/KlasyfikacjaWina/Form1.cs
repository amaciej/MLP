using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KlasyfikacjaWina
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }

        //                 Wczytanie z pliku loswej linii danych 
        private void button1_Click(object sender, EventArgs e)
        {
            int counter = 0;
            string line;
            //string[] data = new string[14];

            // Read the file and display it line by line.  
            System.IO.StreamReader file =
                new System.IO.StreamReader(@"C:\Users\Adam\Documents\sem. 5\Zastosowanie Sztucznej inteligencji\KlasyfikacjaWina\KlasyfikacjaWina\dane.txt");
            while ((line = file.ReadLine()) != null)
            {
                string[] dane = line.Split(',');

                txtAlcohol.Text = dane[1];
                txtMalic.Text = dane[2];
                txtAsh.Text = dane[3];
                txtAlcalinity.Text = dane[4];
                txtMagnesium.Text = dane[5];
                txtPhenols.Text = dane[6];
                txtFlavanoids.Text = dane[7];
                txtNonflavanoid.Text = dane[8];
                txtProanth.Text = dane[9];
                txtColor.Text = dane[10];
                txtHue.Text = dane[11];
                txtOD.Text = dane[12];
                txtProline.Text = dane[13];
                counter++;
            }

            file.Close();
            System.Console.WriteLine("There were {0} lines.", counter);
            // Suspend the screen.  
            System.Console.ReadLine();
        }

        private void butClear_Click(object sender, EventArgs e)
        {
            txtProline.Text = txtProanth.Text = txtPhenols.Text = txtOD.Text = 
                txtNonflavanoid.Text = txtMalic.Text = txtMagnesium.Text = txtHue.Text = 
                txtFlavanoids.Text = txtColor.Text = txtAsh.Text = txtAlcohol.Text = txtAlcalinity.Text = "";
        }

        private void butKlasa_Click(object sender, EventArgs e)
        {
            PropagacjaWPrzód();
        }



        public void PropagacjaWPrzód()
        {
            int U0 = 0;
            double U1 = double.Parse(txtAlcohol.Text, CultureInfo.InvariantCulture.NumberFormat);
            double U2 = double.Parse(txtMalic.Text, CultureInfo.InvariantCulture.NumberFormat);
            double U3 = double.Parse(txtAsh.Text, CultureInfo.InvariantCulture.NumberFormat);
            double U4 = double.Parse(txtAlcalinity.Text, CultureInfo.InvariantCulture.NumberFormat);
            double U5 = double.Parse(txtMagnesium.Text, CultureInfo.InvariantCulture.NumberFormat);
            double U6 = double.Parse(txtPhenols.Text, CultureInfo.InvariantCulture.NumberFormat);
            double U7 = double.Parse(txtFlavanoids.Text, CultureInfo.InvariantCulture.NumberFormat);
            double U8 = double.Parse(txtNonflavanoid.Text, CultureInfo.InvariantCulture.NumberFormat);
            double U9 = double.Parse(txtProanth.Text, CultureInfo.InvariantCulture.NumberFormat);
            double U10 = double.Parse(txtColor.Text, CultureInfo.InvariantCulture.NumberFormat);
            double U11 = double.Parse(txtHue.Text, CultureInfo.InvariantCulture.NumberFormat);
            double U12 = double.Parse(txtOD.Text, CultureInfo.InvariantCulture.NumberFormat);
            double U13 = double.Parse(txtProline.Text, CultureInfo.InvariantCulture.NumberFormat);

            double[] wagi = new double[112];

            Random rnd = new Random();
            //   Wagi początkowe
            for(int i = 0; i < wagi.Length; i++)
            {
                double waga = rnd.Next(1, 5);
                wagi[i] = waga;
                
            }

            for (int i = 0; i < wagi.Length; i++)
            {
                Console.WriteLine("tablica[{0}] = {1}", i, wagi[i]);
            }

            //    Warstwa ukryta 
            double S1 = U1 * wagi[0] + U2 * wagi[1] + U3 * wagi[2] + U4 * wagi[3] + U5 * wagi[4]
                        + U6 * wagi[5] + U7 * wagi[6] + U8 * wagi[7] + U9 * wagi[8] + U10 * wagi[9]
                        + U11 * wagi[10] + U12 * wagi[11] + U13 * wagi[12];
            double U14 = 1 / (1 + Math.Exp(-S1));
            Console.WriteLine("S1 = " + S1);
            Console.WriteLine("U14 = " + U14);
            double S2 = U1 * wagi[13] + U2 * wagi[14] + U3 * wagi[15] + U4 * wagi[16] + U5 * wagi[17]
                        + U6 * wagi[18] + U7 * wagi[19] + U8 * wagi[20] + U9 * wagi[21] + U10 * wagi[22]
                        + U11 * wagi[23] + U12 * wagi[24] + U13 * wagi[25];
            double U15 = 1 / (1 + Math.Exp(-S2));
            Console.WriteLine("S2 = " + S2);
            Console.WriteLine("U15 = " + U15);
            double S3 = U1 * wagi[26] + U2 * wagi[27] + U3 * wagi[28] + U4 * wagi[29] + U5 * wagi[30]
                        + U6 * wagi[31] + U7 * wagi[32] + U8 * wagi[33] + U9 * wagi[34] + U10 * wagi[35]
                        + U11 * wagi[36] + U12 * wagi[37] + U13 * wagi[38];
            double U16 = 1 / (1 + Math.Exp(-S3));
            Console.WriteLine("S3 = " + S3);
            Console.WriteLine("U16 = " + U16);
            double S4 = U1 * wagi[39] + U2 * wagi[40] + U3 * wagi[41] + U4 * wagi[42] + U5 * wagi[43]
                        + U6 * wagi[44] + U7 * wagi[45] + U8 * wagi[46] + U9 * wagi[47] + U10 * wagi[48]
                        + U11 * wagi[49] + U12 * wagi[50] + U13 * wagi[51];
            double U17 = 1 / (1 + Math.Exp(-S4));
            Console.WriteLine("S4 = " + S4);
            Console.WriteLine("U17 = " + U17);
            double S5 = U1 * wagi[52] + U2 * wagi[53] + U3 * wagi[54] + U4 * wagi[55] + U5 * wagi[56]
                        + U6 * wagi[57] + U7 * wagi[58] + U8 * wagi[59] + U9 * wagi[60] + U10 * wagi[61]
                        + U11 * wagi[62] + U12 * wagi[63] + U13 * wagi[64];
            double U18 = 1 / (1 + Math.Exp(-S5));
            Console.WriteLine("S5 = " + S5);
            Console.WriteLine("U18 = " + U18);
            double S6 = U1 * wagi[65] + U2 * wagi[66] + U3 * wagi[67] + U4 * wagi[68] + U5 * wagi[69]
                        + U6 * wagi[70] + U7 * wagi[71] + U8 * wagi[72] + U9 * wagi[73] + U10 * wagi[74]
                        + U11 * wagi[75] + U12 * wagi[76] + U13 * wagi[77];
            double U19 = 1 / (1 + Math.Exp(-S6));
            Console.WriteLine("S6 = " + S6);
            Console.WriteLine("U19 = " + U19);
            double S7 = U1 * wagi[78] + U2 * wagi[79] + U3 * wagi[80] + U4 * wagi[81] + U5 * wagi[82]
                        + U6 * wagi[83] + U7 * wagi[84] + U8 * wagi[85] + U9 * wagi[86] + U10 * wagi[87]
                        + U11 * wagi[88] + U12 * wagi[89] + U13 * wagi[90];
            double U20 = 1 / (1 + Math.Exp(-S7));
            Console.WriteLine("S7 = " + S7);
            Console.WriteLine("U20 = " + U20);

            //        Warstwa Wyjściowa
            double S8 = U14 * wagi[91] + U15 * wagi[92] + U16 * wagi[93] + U17 * wagi[94] + U18 * wagi[95]
                + U19 * wagi[96] + U20 * wagi[97];
            double U21 = 1 / (1 + Math.Exp(-S8));
            Console.WriteLine("S8 = " + S8);
            Console.WriteLine("U21 = " + U21);
            double S9 = U14 * wagi[98] + U15 * wagi[99] + U16 * wagi[100] + U17 * wagi[101] + U18 * wagi[102]
                + U19 * wagi[103] + U20 * wagi[104];
            double U22 = 1 / (1 + Math.Exp(-S9));
            Console.WriteLine("S9 = " + S9);
            Console.WriteLine("U22 = " + U22);
            double S10 = U14 * wagi[105] + U15 * wagi[106] + U16 * wagi[107] + U17 * wagi[108] + U18 * wagi[109]
                + U19 * wagi[110] + U20 * wagi[111];
            double U23 = 1 / (1 + Math.Exp(-S10));
            Console.WriteLine("S10 = " + S10);
            Console.WriteLine("U23 = " + U23);

            Console.Read();





        }
    }
}
