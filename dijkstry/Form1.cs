using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace dijkstry
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void DijkstryBT_Click(object sender, EventArgs e)
        {

        }

        public class W�ze�4
        {
            public int warto��;
            public int dystans;
            public W�ze�4 poprzednik;

            public W�ze�4(int warto��)
            {
                this.warto�� = warto��;
            }
        }

        public class Kraw�d�
        {
            public W�ze�4 koniec;
            public int waga;

            public Kraw�d�(W�ze�4 koniec, int waga)
            {
                this.koniec = koniec;
                this.waga = waga;
            }
        }


    }
}

