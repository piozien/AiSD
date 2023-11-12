using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dodatkowe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
private void Form1_Load(object sender, EventArgs e)
        {

        }
        

        private void start_Click(object sender, EventArgs e)
        {
            int a = (int)NumericA.Value;
            int b = (int)NumericB.Value;
            string suma = dodawanie(a, b);
            MessageBox.Show(suma);
            
        }
        string dodawanie(int a, int b){
            string aa = a.ToString();
            string bb = b.ToString();
            int maxLen = Math.Max(aa.Length, bb.Length);
            int next = 0;

            string wynik = "";
            for (int i = 0; i < maxLen; i++)
            {
                int cyfra1 = 0;
                int cyfra2 = 0;
                if (i < aa.Length) cyfra1 = aa[aa.Length - 1 - i] - '0';
                if (i < bb.Length) cyfra2 = bb[bb.Length - 1 - i] - '0';
                int suma = cyfra1 + cyfra2 + next;

                next = suma / 10;
                if (aa.Length > 1 || bb.Length > 1)
                {
                    wynik = (suma % 10) + wynik;
                }
                else
                {
                    wynik = suma.ToString();
                }

            }
            return wynik;

        }
        private void NumericA_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
