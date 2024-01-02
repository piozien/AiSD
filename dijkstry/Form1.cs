using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace dijkstry
{
    public partial class Form1 : Form
    {
        static List<W�ze�4> w�z�y = new List<W�ze�4>();

        public Form1()
        {
            InitializeComponent();
        }

        private void DijkstryBT_Click(object sender, EventArgs e)
        {
            Graf graf = new Graf();

            W�ze�4 w0 = new W�ze�4(0);
            W�ze�4 w1 = new W�ze�4(1);
            W�ze�4 w2 = new W�ze�4(2);
            W�ze�4 w3 = new W�ze�4(3);
            W�ze�4 w4 = new W�ze�4(4);
            W�ze�4 w5 = new W�ze�4(5);

            graf.DodajW�ze�(w0);
            graf.DodajW�ze�(w1);
            graf.DodajW�ze�(w2);
            graf.DodajW�ze�(w3);
            graf.DodajW�ze�(w4);
            graf.DodajW�ze�(w5);

            graf.DodajKraw�d�(w0, w1, 3);
            graf.DodajKraw�d�(w0, w4, 3);
            graf.DodajKraw�d�(w0, w5, 6);
            graf.DodajKraw�d�(w1, w2, 1);
            graf.DodajKraw�d�(w1, w3, 4);
            graf.DodajKraw�d�(w2, w3, 3);
            graf.DodajKraw�d�(w2, w5, 1);
            graf.DodajKraw�d�(w4, w5, 2);

            Dijkstra(graf, w0);

            string message = "Najkr�tsze �cie�ki od w�z�a " + w0.warto�� + ":\n";
            foreach (var w�ze� in w�z�y)
            {
                message += $"Do w�z�a {w�ze�.warto��} dystans: {w�ze�.dystans}, poprzednik: {w�ze�.poprzednik?.warto�� ?? -1}\n";
            }

            MessageBox.Show(message, "Wyniki Dijkstry");
        }

        public class W�ze�4
        {
            public int warto��;
            public int liczbaKraw�dzi;
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

        public class Graf
        {
            Dictionary<W�ze�4, List<Kraw�d�>> grafDictionary;

            public Graf()
            {
                grafDictionary = new Dictionary<W�ze�4, List<Kraw�d�>>();
            }

            public void DodajW�ze�(W�ze�4 w)
            {
                if (!grafDictionary.ContainsKey(w))
                    grafDictionary[w] = new List<Kraw�d�>();
            }

            public void DodajKraw�d�(W�ze�4 pocz�tek, W�ze�4 koniec, int waga)
            {
                DodajW�ze�(pocz�tek);
                DodajW�ze�(koniec);

                grafDictionary[pocz�tek].Add(new Kraw�d�(koniec, waga));
            }

            public List<W�ze�4> W�z�y()
            {
                return new List<W�ze�4>(grafDictionary.Keys);
            }

            public List<Kraw�d�> Kraw�dzie(W�ze�4 w)
            {
                return grafDictionary[w];
            }
        }

        class Element
        {
            public int dystans;
            public W�ze�4 poprzednik;
        }

        public static void Dijkstra(Graf graf, W�ze�4 start)
        {
            Dictionary<W�ze�4, Element> tabela = new Dictionary<W�ze�4, Element>();
            foreach (var w�ze� in graf.W�z�y())
            {
                tabela[w�ze�] = new Element { dystans = int.MaxValue, poprzednik = null };
            }

            tabela[start].dystans = 0;

            while (tabela.Count > 0)
            {
                var aktualny = Znajd�Najbli�szyW�ze�(tabela);
                tabela.Remove(aktualny);

                foreach (var kraw�d� in graf.Kraw�dzie(aktualny))
                {
                    var s�siad = kraw�d�.koniec;
                    var alternatywnyDystans = tabela[aktualny].dystans + kraw�d�.waga;

                    if (alternatywnyDystans < tabela[s�siad].dystans)
                    {
                        tabela[s�siad].dystans = alternatywnyDystans;
                        tabela[s�siad].poprzednik = aktualny;
                    }
                }
            }
        }

        private static W�ze�4 Znajd�Najbli�szyW�ze�(Dictionary<W�ze�4, Element> tabela)
        {
            W�ze�4 najbli�szy = null;
            int najmniejszyDystans = int.MaxValue;

            foreach (var x in tabela)
            {
                if (x.Value.dystans < najmniejszyDystans)
                {
                    najmniejszyDystans = x.Value.dystans;
                    najbli�szy = x.Key;
                }
            }

            return najbli�szy;
        }
    }
}
