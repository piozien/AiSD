using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace dijkstry
{
    public partial class Form1 : Form
    {
        static List<Wêze³4> wêz³y = new List<Wêze³4>();

        public Form1()
        {
            InitializeComponent();
        }

        private void DijkstryBT_Click(object sender, EventArgs e)
        {
            Graf graf = new Graf();

            Wêze³4 w0 = new Wêze³4(0);
            Wêze³4 w1 = new Wêze³4(1);
            Wêze³4 w2 = new Wêze³4(2);
            Wêze³4 w3 = new Wêze³4(3);
            Wêze³4 w4 = new Wêze³4(4);
            Wêze³4 w5 = new Wêze³4(5);

            graf.DodajWêze³(w0);
            graf.DodajWêze³(w1);
            graf.DodajWêze³(w2);
            graf.DodajWêze³(w3);
            graf.DodajWêze³(w4);
            graf.DodajWêze³(w5);

            graf.DodajKrawêdŸ(w0, w1, 3);
            graf.DodajKrawêdŸ(w0, w4, 3);
            graf.DodajKrawêdŸ(w0, w5, 6);
            graf.DodajKrawêdŸ(w1, w2, 1);
            graf.DodajKrawêdŸ(w1, w3, 4);
            graf.DodajKrawêdŸ(w2, w3, 3);
            graf.DodajKrawêdŸ(w2, w5, 1);
            graf.DodajKrawêdŸ(w4, w5, 2);

            Dijkstra(graf, w0);

            string message = "Najkrótsze œcie¿ki od wêz³a " + w0.wartoœæ + ":\n";
            foreach (var wêze³ in wêz³y)
            {
                message += $"Do wêz³a {wêze³.wartoœæ} dystans: {wêze³.dystans}, poprzednik: {wêze³.poprzednik?.wartoœæ ?? -1}\n";
            }

            MessageBox.Show(message, "Wyniki Dijkstry");
        }

        public class Wêze³4
        {
            public int wartoœæ;
            public int liczbaKrawêdzi;
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

        public class Graf
        {
            Dictionary<Wêze³4, List<KrawêdŸ>> grafDictionary;

            public Graf()
            {
                grafDictionary = new Dictionary<Wêze³4, List<KrawêdŸ>>();
            }

            public void DodajWêze³(Wêze³4 w)
            {
                if (!grafDictionary.ContainsKey(w))
                    grafDictionary[w] = new List<KrawêdŸ>();
            }

            public void DodajKrawêdŸ(Wêze³4 pocz¹tek, Wêze³4 koniec, int waga)
            {
                DodajWêze³(pocz¹tek);
                DodajWêze³(koniec);

                grafDictionary[pocz¹tek].Add(new KrawêdŸ(koniec, waga));
            }

            public List<Wêze³4> Wêz³y()
            {
                return new List<Wêze³4>(grafDictionary.Keys);
            }

            public List<KrawêdŸ> Krawêdzie(Wêze³4 w)
            {
                return grafDictionary[w];
            }
        }

        class Element
        {
            public int dystans;
            public Wêze³4 poprzednik;
        }

        public static void Dijkstra(Graf graf, Wêze³4 start)
        {
            Dictionary<Wêze³4, Element> tabela = new Dictionary<Wêze³4, Element>();
            foreach (var wêze³ in graf.Wêz³y())
            {
                tabela[wêze³] = new Element { dystans = int.MaxValue, poprzednik = null };
            }

            tabela[start].dystans = 0;

            while (tabela.Count > 0)
            {
                var aktualny = ZnajdŸNajbli¿szyWêze³(tabela);
                tabela.Remove(aktualny);

                foreach (var krawêdŸ in graf.Krawêdzie(aktualny))
                {
                    var s¹siad = krawêdŸ.koniec;
                    var alternatywnyDystans = tabela[aktualny].dystans + krawêdŸ.waga;

                    if (alternatywnyDystans < tabela[s¹siad].dystans)
                    {
                        tabela[s¹siad].dystans = alternatywnyDystans;
                        tabela[s¹siad].poprzednik = aktualny;
                    }
                }
            }
        }

        private static Wêze³4 ZnajdŸNajbli¿szyWêze³(Dictionary<Wêze³4, Element> tabela)
        {
            Wêze³4 najbli¿szy = null;
            int najmniejszyDystans = int.MaxValue;

            foreach (var x in tabela)
            {
                if (x.Value.dystans < najmniejszyDystans)
                {
                    najmniejszyDystans = x.Value.dystans;
                    najbli¿szy = x.Key;
                }
            }

            return najbli¿szy;
        }
    }
}
