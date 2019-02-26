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
        string[] lines;
        int counter = 0;
        string text;
        string[] dane = new string[179];
        string[] linia = new string[15];
        double[] dlinia = new double[15];
        public Form1()
        {
            InitializeComponent();
        }

        //                 Wczytanie z pliku loswej linii danych 
        private void button1_Click(object sender, EventArgs e)
        {
            
            Random rnd = new Random();

            string[] tab = new string[counter];
            lines = System.IO.File.ReadAllLines(@"skalowaneDane.txt");
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

        public void Trenowanie()
        {
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
            double UK21 = 0;
            double UK22 = 0;
            double UK23 = 0;

            double[] wagi = new double[112];
            double[] stareWagi = new double[112];
            Random rnd = new Random();

            //   Wagi początkowe
            for(int i = 0; i < wagi.Length; i++)
            {
                double waga = rnd.NextDouble();         //przedział: 0.0 - 1.0
                wagi[i] = waga;
                stareWagi[i] = waga;
            }

            for (int i = 0; i < wagi.Length; i++)
            {
                Console.WriteLine("Waga[{0}] = {1}", i, wagi[i]);
            }
            int iter = 0;
            double e = Math.E;

            
            while(iter < 100)
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    text = lines[i];
                    linia = text.Split(',');
                    for (int k = 0; i < linia.Length; i++)
                    {
                        dlinia[i] = Double.Parse(linia[k], CultureInfo.InvariantCulture.NumberFormat);
                    }
                    //    Warstwa ukryta 
                    double S1 = dlinia[1] * wagi[0] + dlinia[2] * wagi[1] + dlinia[3] * wagi[2] + dlinia[4] * wagi[3] + dlinia[5] * wagi[4]
                                + dlinia[6] * wagi[5] + dlinia[7] * wagi[6] + dlinia[8] * wagi[7] + dlinia[9] * wagi[8] + dlinia[11] * wagi[9]
                                + dlinia[11] * wagi[10] + dlinia[12] * wagi[11] + dlinia[13] * wagi[12];
                    double U14 = 1 / (1 + Math.Pow(e, -S1));
                    Console.WriteLine("S1 = " + S1);
                    Console.WriteLine("U14 = " + U14);
                    double S2 = dlinia[1] * wagi[13] + dlinia[2] * wagi[14] + dlinia[3] * wagi[15] + dlinia[4] * wagi[16] + dlinia[5] * wagi[17]
                                + dlinia[6] * wagi[18] + dlinia[7] * wagi[19] + dlinia[8] * wagi[20] + dlinia[9] * wagi[21] + dlinia[10] * wagi[22]
                                + dlinia[11] * wagi[23] + dlinia[12] * wagi[24] + dlinia[13] * wagi[25];
                    double U15 = 1 / (1 + Math.Exp(-S2));
                    Console.WriteLine("S2 = " + S2);
                    Console.WriteLine("U15 = " + U15);
                    double S3 = dlinia[1] * wagi[26] + dlinia[2] * wagi[27] + dlinia[3] * wagi[28] + dlinia[4] * wagi[29] + dlinia[5] * wagi[30]
                                + dlinia[6] * wagi[31] + dlinia[7] * wagi[32] + dlinia[8] * wagi[33] + dlinia[9] * wagi[34] + dlinia[10] * wagi[35]
                                + dlinia[11] * wagi[36] + dlinia[12] * wagi[37] + dlinia[13] * wagi[38];
                    double U16 = 1 / (1 + Math.Exp(-S3));
                    Console.WriteLine("S3 = " + S3);
                    Console.WriteLine("U16 = " + U16);
                    double S4 = dlinia[1] * wagi[39] + dlinia[2] * wagi[40] + dlinia[3] * wagi[41] + dlinia[4] * wagi[42] + dlinia[5] * wagi[43]
                                + dlinia[6] * wagi[44] + dlinia[7] * wagi[45] + dlinia[8] * wagi[46] + dlinia[9] * wagi[47] + dlinia[10] * wagi[48]
                                + dlinia[11] * wagi[49] + dlinia[12] * wagi[50] + dlinia[13] * wagi[51];
                    double U17 = 1 / (1 + Math.Exp(-S4));
                    Console.WriteLine("S4 = " + S4);
                    Console.WriteLine("U17 = " + U17);
                    double S5 = dlinia[1] * wagi[52] + dlinia[2] * wagi[53] + dlinia[3] * wagi[54] + dlinia[4] * wagi[55] + dlinia[5] * wagi[56]
                                + dlinia[6] * wagi[57] + dlinia[7] * wagi[58] + dlinia[8] * wagi[59] + dlinia[9] * wagi[60] + dlinia[10] * wagi[61]
                                + dlinia[11] * wagi[62] + dlinia[12] * wagi[63] + dlinia[13] * wagi[64];
                    double U18 = 1 / (1 + Math.Exp(-S5));
                    Console.WriteLine("S5 = " + S5);
                    Console.WriteLine("U18 = " + U18);
                    double S6 = dlinia[1] * wagi[65] + dlinia[2] * wagi[66] + dlinia[3] * wagi[67] + dlinia[4] * wagi[68] + dlinia[5] * wagi[69]
                                + dlinia[6] * wagi[70] + dlinia[7] * wagi[71] + dlinia[8] * wagi[72] + dlinia[9] * wagi[73] + dlinia[10] * wagi[74]
                                + dlinia[11] * wagi[75] + dlinia[12] * wagi[76] + dlinia[13] * wagi[77];
                    double U19 = 1 / (1 + Math.Exp(-S6));
                    Console.WriteLine("S6 = " + S6);
                    Console.WriteLine("U19 = " + U19);
                    double S7 = dlinia[1] * wagi[78] + dlinia[2] * wagi[79] + dlinia[3] * wagi[80] + dlinia[4] * wagi[81] + dlinia[5] * wagi[82]
                                + dlinia[6] * wagi[83] + dlinia[7] * wagi[84] + dlinia[8] * wagi[85] + dlinia[9] * wagi[86] + dlinia[10] * wagi[87]
                                + dlinia[11] * wagi[88] + dlinia[12] * wagi[89] + dlinia[13] * wagi[90];
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
                    wagi[0] = wagi[0] + p * B14 * dlinia[1];
                    wagi[1] = wagi[1] + p * B14 * dlinia[2];
                    wagi[2] = wagi[2] + p * B14 * dlinia[3];
                    wagi[3] = wagi[3] + p * B14 * dlinia[4];
                    wagi[4] = wagi[4] + p * B14 * dlinia[5];
                    wagi[5] = wagi[5] + p * B14 * dlinia[6];
                    wagi[6] = wagi[6] + p * B14 * dlinia[7];
                    wagi[7] = wagi[7] + p * B14 * dlinia[8];
                    wagi[8] = wagi[8] + p * B14 * dlinia[9];
                    wagi[9] = wagi[9] + p * B14 * dlinia[10];
                    wagi[10] = wagi[10] + p * B14 * dlinia[11];
                    wagi[11] = wagi[11] + p * B14 * dlinia[12];
                    wagi[12] = wagi[12] + p * B14 * dlinia[13];
                    // 2.
                    wagi[13] = wagi[13] + p * B15 * dlinia[1];
                    wagi[14] = wagi[14] + p * B15 * dlinia[2];
                    wagi[15] = wagi[15] + p * B15 * dlinia[3];
                    wagi[16] = wagi[16] + p * B15 * dlinia[4];
                    wagi[17] = wagi[17] + p * B15 * dlinia[5];
                    wagi[18] = wagi[18] + p * B15 * dlinia[6];
                    wagi[19] = wagi[19] + p * B15 * dlinia[7];
                    wagi[20] = wagi[20] + p * B15 * dlinia[8];
                    wagi[21] = wagi[21] + p * B15 * dlinia[9];
                    wagi[22] = wagi[22] + p * B15 * dlinia[10];
                    wagi[23] = wagi[23] + p * B15 * dlinia[11];
                    wagi[24] = wagi[24] + p * B15 * dlinia[12];
                    wagi[25] = wagi[25] + p * B15 * dlinia[13];
                    // 3.
                    wagi[26] = wagi[26] + p * B16 * dlinia[1];
                    wagi[27] = wagi[27] + p * B16 * dlinia[2];
                    wagi[28] = wagi[28] + p * B16 * dlinia[3];
                    wagi[29] = wagi[29] + p * B16 * dlinia[4];
                    wagi[30] = wagi[30] + p * B16 * dlinia[5];
                    wagi[31] = wagi[31] + p * B16 * dlinia[6];
                    wagi[32] = wagi[32] + p * B16 * dlinia[7];
                    wagi[33] = wagi[33] + p * B16 * dlinia[8];
                    wagi[34] = wagi[34] + p * B16 * dlinia[9];
                    wagi[35] = wagi[35] + p * B16 * dlinia[10];
                    wagi[36] = wagi[36] + p * B16 * dlinia[11];
                    wagi[37] = wagi[37] + p * B16 * dlinia[12];
                    wagi[38] = wagi[38] + p * B16 * dlinia[13];
                    // 4.
                    wagi[39] = wagi[39] + p * B17 * dlinia[1];
                    wagi[40] = wagi[40] + p * B17 * dlinia[2];
                    wagi[41] = wagi[41] + p * B17 * dlinia[3];
                    wagi[42] = wagi[42] + p * B17 * dlinia[4];
                    wagi[43] = wagi[43] + p * B17 * dlinia[5];
                    wagi[44] = wagi[44] + p * B17 * dlinia[6];
                    wagi[45] = wagi[45] + p * B17 * dlinia[7];
                    wagi[46] = wagi[46] + p * B17 * dlinia[8];
                    wagi[47] = wagi[47] + p * B17 * dlinia[9];
                    wagi[48] = wagi[48] + p * B17 * dlinia[10];
                    wagi[49] = wagi[49] + p * B17 * dlinia[11];
                    wagi[50] = wagi[50] + p * B17 * dlinia[12];
                    wagi[51] = wagi[51] + p * B17 * dlinia[13];
                    // 5.
                    wagi[52] = wagi[52] + p * B18 * dlinia[1];
                    wagi[53] = wagi[53] + p * B18 * dlinia[2];
                    wagi[54] = wagi[54] + p * B18 * dlinia[3];
                    wagi[55] = wagi[55] + p * B18 * dlinia[4];
                    wagi[56] = wagi[56] + p * B18 * dlinia[5];
                    wagi[57] = wagi[57] + p * B18 * dlinia[6];
                    wagi[58] = wagi[58] + p * B18 * dlinia[7];
                    wagi[59] = wagi[59] + p * B18 * dlinia[8];
                    wagi[60] = wagi[60] + p * B18 * dlinia[9];
                    wagi[61] = wagi[61] + p * B18 * dlinia[10];
                    wagi[62] = wagi[62] + p * B18 * dlinia[11];
                    wagi[63] = wagi[63] + p * B18 * dlinia[12];
                    wagi[64] = wagi[64] + p * B18 * dlinia[13];
                    // 6.
                    wagi[65] = wagi[65] + p * B19 * dlinia[1];
                    wagi[66] = wagi[66] + p * B19 * dlinia[2];
                    wagi[67] = wagi[67] + p * B19 * dlinia[3];
                    wagi[68] = wagi[68] + p * B19 * dlinia[4];
                    wagi[69] = wagi[69] + p * B19 * dlinia[5];
                    wagi[70] = wagi[70] + p * B19 * dlinia[6];
                    wagi[71] = wagi[71] + p * B19 * dlinia[7];
                    wagi[72] = wagi[72] + p * B19 * dlinia[8];
                    wagi[73] = wagi[73] + p * B19 * dlinia[9];
                    wagi[74] = wagi[74] + p * B19 * dlinia[10];
                    wagi[75] = wagi[75] + p * B19 * dlinia[11];
                    wagi[76] = wagi[76] + p * B19 * dlinia[12];
                    wagi[77] = wagi[77] + p * B19 * dlinia[13];
                    // 7.
                    wagi[78] = wagi[78] + p * B20 * dlinia[1];
                    wagi[79] = wagi[79] + p * B20 * dlinia[2];
                    wagi[80] = wagi[80] + p * B20 * dlinia[3];
                    wagi[81] = wagi[81] + p * B20 * dlinia[4];
                    wagi[82] = wagi[82] + p * B20 * dlinia[5];
                    wagi[83] = wagi[83] + p * B20 * dlinia[6];
                    wagi[84] = wagi[84] + p * B20 * dlinia[7];
                    wagi[85] = wagi[85] + p * B20 * dlinia[8];
                    wagi[86] = wagi[86] + p * B20 * dlinia[9];
                    wagi[87] = wagi[87] + p * B20 * dlinia[10];
                    wagi[88] = wagi[88] + p * B20 * dlinia[11];
                    wagi[89] = wagi[89] + p * B20 * dlinia[12];
                    wagi[90] = wagi[19] + p * B20 * dlinia[13];
                    // 8.
                    wagi[91] = wagi[91] + p * B21 * U14;
                    wagi[92] = wagi[92] + p * B21 * U15;
                    wagi[93] = wagi[93] + p * B21 * U16;
                    wagi[94] = wagi[94] + p * B21 * U17;
                    wagi[95] = wagi[95] + p * B21 * U18;
                    wagi[96] = wagi[96] + p * B21 * U19;
                    wagi[97] = wagi[97] + p * B21 * U20;
                    //9.
                    wagi[98] = wagi[98] + p * B22 * U14;
                    wagi[99] = wagi[99] + p * B22 * U15;
                    wagi[100] = wagi[100] + p * B22 * U16;
                    wagi[101] = wagi[101] + p * B22 * U17;
                    wagi[102] = wagi[102] + p * B22 * U18;
                    wagi[103] = wagi[103] + p * B22 * U19;
                    wagi[104] = wagi[104] + p * B22 * U20;
                    //10.
                    wagi[105] = wagi[105] + p * B23 * U14;
                    wagi[106] = wagi[106] + p * B23 * U15;
                    wagi[107] = wagi[107] + p * B23 * U16;
                    wagi[108] = wagi[108] + p * B23 * U17;
                    wagi[109] = wagi[109] + p * B23 * U18;
                    wagi[110] = wagi[110] + p * B23 * U19;
                    wagi[111] = wagi[111] + p * B23 * U20;
                    Console.WriteLine("Linia: "+i);
                }
                iter++;
                Console.WriteLine("Iteracja:  "+iter);
            }
                //    Warstwa ukryta 
                double SK1 = U1 * stareWagi[0] + U2 * stareWagi[1] + U3 * stareWagi[2] + U4 * stareWagi[3] + U5 * stareWagi[4]
                            + U6 * stareWagi[5] + U7 * stareWagi[6] + U8 * stareWagi[7] + U9 * stareWagi[8] + U10 * stareWagi[9]
                            + U11 * stareWagi[10] + U12 * stareWagi[11] + U13 * stareWagi[12];
                double UK14 = 1 / (1 + Math.Pow(e, -SK1));
                Console.WriteLine("Sk1 = " + SK1);
                Console.WriteLine("Uk14 = " + UK14);
                double SK2 = U1 * stareWagi[13] + U2 * stareWagi[14] + U3 * stareWagi[15] + U4 * stareWagi[16] + U5 * stareWagi[17]
                            + U6 * stareWagi[18] + U7 * stareWagi[19] + U8 * stareWagi[20] + U9 * stareWagi[21] + U10 * stareWagi[22]
                            + U11 * stareWagi[23] + U12 * stareWagi[24] + U13 * stareWagi[25];
                double UK15 = 1 / (1 + Math.Exp(-SK2));
                Console.WriteLine("Sk2 = " + SK2);
                Console.WriteLine("Uk15 = " + UK15);
                double SK3 = U1 * stareWagi[26] + U2 * stareWagi[27] + U3 * stareWagi[28] + U4 * stareWagi[29] + U5 * stareWagi[30]
                            + U6 * stareWagi[31] + U7 * stareWagi[32] + U8 * stareWagi[33] + U9 * stareWagi[34] + U10 * stareWagi[35]
                            + U11 * stareWagi[36] + U12 * stareWagi[37] + U13 * stareWagi[38];
                double Uk16 = 1 / (1 + Math.Exp(-SK3));
                Console.WriteLine("Sk3 = " + SK3);
                Console.WriteLine("Uk16 = " + Uk16);
                double SK4 = U1 * stareWagi[39] + U2 * stareWagi[40] + U3 * stareWagi[41] + U4 * stareWagi[42] + U5 * stareWagi[43]
                            + U6 * stareWagi[44] + U7 * stareWagi[45] + U8 * stareWagi[46] + U9 * stareWagi[47] + U10 * stareWagi[48]
                            + U11 * stareWagi[49] + U12 * stareWagi[50] + U13 * stareWagi[51];
                double Uk17 = 1 / (1 + Math.Exp(-SK4));
                Console.WriteLine("Sk4 = " + SK4);
                Console.WriteLine("Uk17 = " + Uk17);
                double SK5 = U1 * stareWagi[52] + U2 * stareWagi[53] + U3 * stareWagi[54] + U4 * stareWagi[55] + U5 * stareWagi[56]
                            + U6 * stareWagi[57] + U7 * stareWagi[58] + U8 * stareWagi[59] + U9 * stareWagi[60] + U10 * stareWagi[61]
                            + U11 * stareWagi[62] + U12 * stareWagi[63] + U13 * stareWagi[64];
                double Uk18 = 1 / (1 + Math.Exp(-SK5));
                Console.WriteLine("S5 = " + SK5);
                Console.WriteLine("Uk18 = " + Uk18);
                double SK6 = U1 * stareWagi[65] + U2 * stareWagi[66] + U3 * stareWagi[67] + U4 * stareWagi[68] + U5 * stareWagi[69]
                            + U6 * stareWagi[70] + U7 * stareWagi[71] + U8 * stareWagi[72] + U9 * stareWagi[73] + U10 * stareWagi[74]
                            + U11 * stareWagi[75] + U12 * stareWagi[76] + U13 * stareWagi[77];
                double Uk19 = 1 / (1 + Math.Exp(-SK6));
                Console.WriteLine("SK6 = " + SK6);
                Console.WriteLine("UK19 = " + Uk19);
                double SK7 = U1 * stareWagi[78] + U2 * stareWagi[79] + U3 * stareWagi[80] + U4 * stareWagi[81] + U5 * stareWagi[82]
                            + U6 * stareWagi[83] + U7 * stareWagi[84] + U8 * stareWagi[85] + U9 * stareWagi[86] + U10 * stareWagi[87]
                            + U11 * stareWagi[88] + U12 * stareWagi[89] + U13 * stareWagi[90];
                double Uk20 = 1 / (1 + Math.Exp(-SK7));
                Console.WriteLine("SK7 = " + SK7);
                Console.WriteLine("UK20 = " + Uk20);

                //        Warstwa Wyjściowa
                double SK8 = UK14 * stareWagi[91] + UK15 * stareWagi[92] + Uk16 * stareWagi[93] + Uk17 * stareWagi[94] + Uk18 * stareWagi[95]
                    + Uk19 * stareWagi[96] + Uk20 * stareWagi[97];
                UK21 = 1 / (1 + Math.Exp(-SK8));  //docelowo 1
                Console.WriteLine("SK8 = " + SK8);
                Console.WriteLine("UK21 = " + UK21);
                double SK9 = UK14 * stareWagi[98] + UK15 * stareWagi[99] + Uk16 * stareWagi[100] + Uk17 * stareWagi[101] + Uk18 * stareWagi[102]
                    + Uk19 * stareWagi[103] + Uk20 * stareWagi[104];
                UK22 = 1 / (1 + Math.Exp(-SK9)); //docelowo 2
                Console.WriteLine("SK9 = " + SK9);
                Console.WriteLine("UK22 = " + UK22);
                double SK10 = UK14 * stareWagi[105] + UK15 * stareWagi[106] + Uk16 * stareWagi[107] + Uk17 * stareWagi[108] + Uk18 * stareWagi[109]
                    + Uk19 * stareWagi[110] + Uk20 * stareWagi[111];
                UK23 = 1 / (1 + Math.Exp(-SK10));   //docelowo 3
                Console.WriteLine("SK10 = " + SK10);
                Console.WriteLine("UK23 = " + UK23);

                Console.Read();
            

            
            if (UK21 > UK22 && UK21 > UK23)
            {
                lblKlasa.Text = "Klasa 1";
            }
            else if(UK22 > UK21 && UK22 > UK23)
            {
                lblKlasa.Text = "Klasa 2";
            }
            else
                lblKlasa.Text = "Klasa 3";
        }
    }
}
