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

        public class Wêze³4
        {
            public int wartoœæ;
            public int dystans;
            public Wêze³4 poprzednik;

            public Wêze³4(int wartoœæ)
            {
                this.wartoœæ = wartoœæ;
            }
        }

        public class KrawêdŸ
        {
            public Wêze³4 koniec;
            public int waga;

            public KrawêdŸ(Wêze³4 koniec, int waga)
            {
                this.koniec = koniec;
                this.waga = waga;
            }
        }


    }
}

