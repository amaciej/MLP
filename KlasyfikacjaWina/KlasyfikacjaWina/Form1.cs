using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
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
            string text;
            string[] dane = new string[179];
            string[] linia = new string[15];
            Random rnd = new Random();

            string[] tab = new string[counter];
            string[] lines = System.IO.File.ReadAllLines(@"skalowaneDane.txt");
            foreach (string linia1 in lines)
            {
                // Use a tab to indent each line of the file.
                Console.WriteLine("\t" + linia1);
            }

            int l = rnd.Next(179);
            text = lines[l];
            linia = text.Split(',');
            System.Console.WriteLine("wylosowana linia {0}: " + text, l);

            txtAlcohol.Text = linia[1];
            txtMalic.Text = linia[2];
            txtAsh.Text = linia[3];
            txtAlcalinity.Text = linia[4];
            txtMagnesium.Text = linia[5];
            txtPhenols.Text = linia[6];
            txtFlavanoids.Text = linia[7];
            txtNonflavanoid.Text = linia[8];
            txtProanth.Text = linia[9];
            txtColor.Text = linia[10];
            txtHue.Text = linia[11];
            txtOD.Text = linia[12];
            txtProline.Text = linia[13];
            
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

            double U21 = 0;
            double U22 = 0;
            double U23 = 0;

            double[] wagi = new double[112];
            double[] noweWagi = new double[112];
            Random rnd = new Random();

            //   Wagi początkowe
            for(int i = 0; i < wagi.Length; i++)
            {
                double waga = rnd.NextDouble();         //przedział: 0.0 - 1.0
                wagi[i] = waga;                
            }

            for (int i = 0; i < wagi.Length; i++)
            {
                Console.WriteLine("Waga[{0}] = {1}", i, wagi[i]);
            }
            int iter = 0;
            double e = Math.E;
            while (iter<5000)
            {
                //    Warstwa ukryta 
                double S1 = U1 * wagi[0] + U2 * wagi[1] + U3 * wagi[2] + U4 * wagi[3] + U5 * wagi[4]
                            + U6 * wagi[5] + U7 * wagi[6] + U8 * wagi[7] + U9 * wagi[8] + U10 * wagi[9]
                            + U11 * wagi[10] + U12 * wagi[11] + U13 * wagi[12];
                double U14 = 1 / (1 + Math.Pow(e, -S1));
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
                U21 = 1 / (1 + Math.Exp(-S8));  //docelowo 1
                Console.WriteLine("S8 = " + S8);
                Console.WriteLine("U21 = " + U21);
                double S9 = U14 * wagi[98] + U15 * wagi[99] + U16 * wagi[100] + U17 * wagi[101] + U18 * wagi[102]
                    + U19 * wagi[103] + U20 * wagi[104];
                U22 = 1 / (1 + Math.Exp(-S9)); //docelowo 2
                Console.WriteLine("S9 = " + S9);
                Console.WriteLine("U22 = " + U22);
                double S10 = U14 * wagi[105] + U15 * wagi[106] + U16 * wagi[107] + U17 * wagi[108] + U18 * wagi[109]
                    + U19 * wagi[110] + U20 * wagi[111];
                U23 = 1 / (1 + Math.Exp(-S10));   //docelowo 3
                Console.WriteLine("S10 = " + S10);
                Console.WriteLine("U23 = " + U23);

                Console.Read();

                double bł1 = 1 - U21;
                double bł2 = 2 - U23;
                double bł3 = 3 - U23;
                Console.WriteLine("Błąd 1 = " + bł1);
                Console.WriteLine("Błąd 2 = " + bł3);
                Console.WriteLine("Błąd 3 = " + bł2);

                //      Faza sygnałów propagacji wstecz
                double B21 = (1 - U21) * (U21 * (1 - U21));
                double B22 = (2 - U22) * (U22 * (1 - U22));
                double B23 = (3 - U23) * (U23 * (1 - U23));
                Console.WriteLine("B21 = " + B21);
                Console.WriteLine("B22 = " + B22);
                Console.WriteLine("B23 = " + B23);

                double B20 = (B21 * wagi[97] + B22 * wagi[104] + B23 * wagi[111]) * (U20 * (1 - U20));
                double B19 = (B21 * wagi[96] + B22 * wagi[103] + B23 * wagi[110]) * (U19 * (1 - U19));
                double B18 = (B21 * wagi[95] + B22 * wagi[102] + B23 * wagi[109]) * (U18 * (1 - U18));
                double B17 = (B21 * wagi[94] + B22 * wagi[101] + B23 * wagi[108]) * (U17 * (1 - U17));
                double B16 = (B21 * wagi[93] + B22 * wagi[100] + B23 * wagi[107]) * (U16 * (1 - U16));
                double B15 = (B21 * wagi[92] + B22 * wagi[99] + B23 * wagi[106]) * (U15 * (1 - U15));
                double B14 = (B21 * wagi[91] + B22 * wagi[98] + B23 * wagi[105]) * (U14 * (1 - U14));
                Console.WriteLine("B20 = " + B20);
                Console.WriteLine("B19 = " + B19);
                Console.WriteLine("B18 = " + B18);
                Console.WriteLine("B17 = " + B17);
                Console.WriteLine("B16 = " + B16);
                Console.WriteLine("B15 = " + B15);
                Console.WriteLine("B14 = " + B14);

                //          Modyfikacja  wag
                double p = 0.5;                     //współczynnik uczenia
                                                    // 1.
                noweWagi[0] = wagi[0] + p * B14 * U1;
                noweWagi[1] = wagi[1] + p * B14 * U2;
                noweWagi[2] = wagi[2] + p * B14 * U3;
                noweWagi[3] = wagi[3] + p * B14 * U4;
                noweWagi[4] = wagi[4] + p * B14 * U5;
                noweWagi[5] = wagi[5] + p * B14 * U6;
                noweWagi[6] = wagi[6] + p * B14 * U7;
                noweWagi[7] = wagi[7] + p * B14 * U8;
                noweWagi[8] = wagi[8] + p * B14 * U9;
                noweWagi[9] = wagi[9] + p * B14 * U10;
                noweWagi[10] = wagi[10] + p * B14 * U11;
                noweWagi[11] = wagi[11] + p * B14 * U12;
                noweWagi[12] = wagi[12] + p * B14 * U13;
                // 2.
                noweWagi[13] = wagi[13] + p * B15 * U1;
                noweWagi[14] = wagi[14] + p * B15 * U2;
                noweWagi[15] = wagi[15] + p * B15 * U3;
                noweWagi[16] = wagi[16] + p * B15 * U4;
                noweWagi[17] = wagi[17] + p * B15 * U5;
                noweWagi[18] = wagi[18] + p * B15 * U6;
                noweWagi[19] = wagi[19] + p * B15 * U7;
                noweWagi[20] = wagi[20] + p * B15 * U8;
                noweWagi[21] = wagi[21] + p * B15 * U9;
                noweWagi[22] = wagi[22] + p * B15 * U10;
                noweWagi[23] = wagi[23] + p * B15 * U11;
                noweWagi[24] = wagi[24] + p * B15 * U12;
                noweWagi[25] = wagi[25] + p * B15 * U13;
                // 3.
                noweWagi[26] = wagi[26] + p * B16 * U1;
                noweWagi[27] = wagi[27] + p * B16 * U2;
                noweWagi[28] = wagi[28] + p * B16 * U3;
                noweWagi[29] = wagi[29] + p * B16 * U4;
                noweWagi[30] = wagi[30] + p * B16 * U5;
                noweWagi[31] = wagi[31] + p * B16 * U6;
                noweWagi[32] = wagi[32] + p * B16 * U7;
                noweWagi[33] = wagi[33] + p * B16 * U8;
                noweWagi[34] = wagi[34] + p * B16 * U9;
                noweWagi[35] = wagi[35] + p * B16 * U10;
                noweWagi[36] = wagi[36] + p * B16 * U11;
                noweWagi[37] = wagi[37] + p * B16 * U12;
                noweWagi[38] = wagi[38] + p * B16 * U13;
                // 4.
                noweWagi[39] = wagi[39] + p * B17 * U1;
                noweWagi[40] = wagi[40] + p * B17 * U2;
                noweWagi[41] = wagi[41] + p * B17 * U3;
                noweWagi[42] = wagi[42] + p * B17 * U4;
                noweWagi[43] = wagi[43] + p * B17 * U5;
                noweWagi[44] = wagi[44] + p * B17 * U6;
                noweWagi[45] = wagi[45] + p * B17 * U7;
                noweWagi[46] = wagi[46] + p * B17 * U8;
                noweWagi[47] = wagi[47] + p * B17 * U9;
                noweWagi[48] = wagi[48] + p * B17 * U10;
                noweWagi[49] = wagi[49] + p * B17 * U11;
                noweWagi[50] = wagi[50] + p * B17 * U12;
                noweWagi[51] = wagi[51] + p * B17 * U13;
                // 5.
                noweWagi[52] = wagi[52] + p * B18 * U1;
                noweWagi[53] = wagi[53] + p * B18 * U2;
                noweWagi[54] = wagi[54] + p * B18 * U3;
                noweWagi[55] = wagi[55] + p * B18 * U4;
                noweWagi[56] = wagi[56] + p * B18 * U5;
                noweWagi[57] = wagi[57] + p * B18 * U6;
                noweWagi[58] = wagi[58] + p * B18 * U7;
                noweWagi[59] = wagi[59] + p * B18 * U8;
                noweWagi[60] = wagi[60] + p * B18 * U9;
                noweWagi[61] = wagi[61] + p * B18 * U10;
                noweWagi[62] = wagi[62] + p * B18 * U11;
                noweWagi[63] = wagi[63] + p * B18 * U12;
                noweWagi[64] = wagi[64] + p * B18 * U13;
                // 6.
                noweWagi[65] = wagi[65] + p * B19 * U1;
                noweWagi[66] = wagi[66] + p * B19 * U2;
                noweWagi[67] = wagi[67] + p * B19 * U3;
                noweWagi[68] = wagi[68] + p * B19 * U4;
                noweWagi[69] = wagi[69] + p * B19 * U5;
                noweWagi[70] = wagi[70] + p * B19 * U6;
                noweWagi[71] = wagi[71] + p * B19 * U7;
                noweWagi[72] = wagi[72] + p * B19 * U8;
                noweWagi[73] = wagi[73] + p * B19 * U9;
                noweWagi[74] = wagi[74] + p * B19 * U10;
                noweWagi[75] = wagi[75] + p * B19 * U11;
                noweWagi[76] = wagi[76] + p * B19 * U12;
                noweWagi[77] = wagi[77] + p * B19 * U13;
                // 7.
                noweWagi[78] = wagi[78] + p * B20 * U1;
                noweWagi[79] = wagi[79] + p * B20 * U2;
                noweWagi[80] = wagi[80] + p * B20 * U3;
                noweWagi[81] = wagi[81] + p * B20 * U4;
                noweWagi[82] = wagi[82] + p * B20 * U5;
                noweWagi[83] = wagi[83] + p * B20 * U6;
                noweWagi[84] = wagi[84] + p * B20 * U7;
                noweWagi[85] = wagi[85] + p * B20 * U8;
                noweWagi[86] = wagi[86] + p * B20 * U9;
                noweWagi[87] = wagi[87] + p * B20 * U10;
                noweWagi[88] = wagi[88] + p * B20 * U11;
                noweWagi[89] = wagi[89] + p * B20 * U12;
                noweWagi[90] = wagi[19] + p * B20 * U13;
                // 8.
                noweWagi[91] = wagi[91] + p * B21 * U14;
                noweWagi[92] = wagi[92] + p * B21 * U15;
                noweWagi[93] = wagi[93] + p * B21 * U16;
                noweWagi[94] = wagi[94] + p * B21 * U17;
                noweWagi[95] = wagi[95] + p * B21 * U18;
                noweWagi[96] = wagi[96] + p * B21 * U19;
                noweWagi[97] = wagi[97] + p * B21 * U20;
                //9.
                noweWagi[98] = wagi[98] + p * B22 * U14;
                noweWagi[99] = wagi[99] + p * B22 * U15;
                noweWagi[100] = wagi[100] + p * B22 * U16;
                noweWagi[101] = wagi[101] + p * B22 * U17;
                noweWagi[102] = wagi[102] + p * B22 * U18;
                noweWagi[103] = wagi[103] + p * B22 * U19;
                noweWagi[104] = wagi[104] + p * B22 * U20;
                //10.
                noweWagi[105] = wagi[105] + p * B23 * U14;
                noweWagi[106] = wagi[106] + p * B23 * U15;
                noweWagi[107] = wagi[107] + p * B23 * U16;
                noweWagi[108] = wagi[108] + p * B23 * U17;
                noweWagi[109] = wagi[109] + p * B23 * U18;
                noweWagi[110] = wagi[110] + p * B23 * U19;
                noweWagi[111] = wagi[111] + p * B23 * U20;

                for (int i = 0; i < noweWagi.Length; i++)
                {
                    Console.WriteLine("Nowa waga[{0}] = {1}", i, noweWagi[i]);
                }
                iter++;
            }
            if (U21 > U22 && U21 > U23)
            {
                lblKlasa.Text = "Klasa 1";
            }
            else if(U22 > U21 && U22 > U23)
            {
                lblKlasa.Text = "Klasa 2";
            }
            else
                lblKlasa.Text = "Klasa 3";
        }
    }
}
