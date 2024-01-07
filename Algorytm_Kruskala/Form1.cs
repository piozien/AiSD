using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Algorytm_Kruskala
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Algorytm_Kruskala_Click(object sender, EventArgs e)
        {
            Graf graf = new Graf();
            graf.Dodaj(3, 0, 6);
            graf.Dodaj(5, 0, 1);
            graf.Dodaj(9, 0, 3);
            graf.Dodaj(6, 1, 5);
            graf.Dodaj(7, 1, 7);
            graf.Dodaj(8, 1, 4);
            graf.Dodaj(9, 1, 2);
            graf.Dodaj(3, 2, 7);
            graf.Dodaj(4, 2, 4);
            graf.Dodaj(5, 2, 6);
            graf.Dodaj(9, 2, 3);
            graf.Dodaj(8, 3, 6);
            graf.Dodaj(1, 4, 6);
            graf.Dodaj(2, 4, 5);
            graf.Dodaj(6, 5, 6);
            graf.Dodaj(9, 6, 7);
            Graf minimalnedrzewo = graf.Kruskal();
            minimalnedrzewo.WyswietlMinimalneDrzewo();

        }

        class Wêze³4
        {
            public int wartoœæ;

            public Wêze³4(int wartoœæ)
            {
                this.wartoœæ = wartoœæ;
            }
        }

        class Krawêdzi
        {
            public int waga;
            public Wêze³4 pocz¹tek;
            public Wêze³4 koniec;

            public Krawêdzi(int waga, Wêze³4 pocz¹tek, Wêze³4 koniec)
            {
                this.waga = waga;
                this.pocz¹tek = pocz¹tek;
                this.koniec = koniec;
            }
        }

        class Graf
        {
            List<Wêze³4> wêz³y;
            List<Krawêdzi> krawêdzie;

            public Graf()
            {
                this.wêz³y = new List<Wêze³4>();
                this.krawêdzie = new List<Krawêdzi>();
            }

            public Graf(Krawêdzi k)
            {
                wêz³y = new List<Wêze³4>();
                krawêdzie = new List<Krawêdzi>();
                this.krawêdzie.Add(k);
                this.wêz³y.Add(k.pocz¹tek);
                this.wêz³y.Add(k.koniec);
            }

            public void Dodaj(int waga, int pocz¹tek, int koniec)
            {
                Wêze³4 wPocz¹tek = ZnajdŸWêze³(pocz¹tek) ?? DodajWêze³(pocz¹tek);
                Wêze³4 wKoniec = ZnajdŸWêze³(koniec) ?? DodajWêze³(koniec);

                if (ZnajdŸKrawêdŸ(wPocz¹tek, wKoniec) == null && ZnajdŸKrawêdŸ(wKoniec, wPocz¹tek) == null)
                {
                    DodajKrawêdŸ(waga, wPocz¹tek, wKoniec);
                }
            }

            private Wêze³4 DodajWêze³(int wartoœæ)
            {
                Wêze³4 w = new Wêze³4(wartoœæ);
                wêz³y.Add(w);
                return w;
            }

            private void DodajKrawêdŸ(int waga, Wêze³4 pocz¹tek, Wêze³4 koniec)
            {
                Krawêdzi k = new Krawêdzi(waga, pocz¹tek, koniec);
                krawêdzie.Add(k);
            }

            private Krawêdzi ZnajdŸKrawêdŸ(Wêze³4 pocz¹tek, Wêze³4 koniec)
            {
                foreach (var k in krawêdzie)
                {
                    if (k.pocz¹tek == pocz¹tek && k.koniec == koniec)
                    {
                        return k;
                    }
                }
                return null;
            }

            private Wêze³4 ZnajdŸWêze³(int wartoœæ)
            {
                foreach (var w in wêz³y)
                {
                    if (w.wartoœæ == wartoœæ)
                    {
                        return w;
                    }
                }
                return null;
            }

            public Graf Kruskal()
            {
                //sortowanie ze wzglêdu na wagê krawêdzi rosn¹co
                var krawedzie = this.krawêdzie.OrderBy(k => k.waga);

                List<Graf> listagrafow = new List<Graf>();

                foreach (var krawedz in krawedzie)
                {
                    //pusta lista tworze nowy graf 
                    if (listagrafow.Count == 0)
                    {
                        listagrafow.Add(new Graf(krawedz));
                        continue;
                    }

                    Graf czyponownie = null;

                    for (int i = 0; i < listagrafow.Count; i++)
                    {
                        var g = listagrafow[i];
                        int ile = g.Sprawdz(krawedz);

                        if (ile == 0)
                        {
                            goto skok;
                        }
                        else if (ile == 1)
                        {
                            if (czyponownie == null)
                            {
                                czyponownie = g;
                            }
                            else
                            {
                                czyponownie.Po³¹cz(g);
                                listagrafow.Remove(g);
                            }
                        }
                    }

                    if (czyponownie != null)
                    {
                        czyponownie.Add(krawedz);
                    }
                    else
                    {
                        listagrafow.Add(new Graf(krawedz));
                    }

                skok:
                    continue;
                }

                
                Graf minimalnedrzewo = new Graf();
                foreach (var g in listagrafow)
                {
                    minimalnedrzewo.Po³¹cz(g);
                }

                return minimalnedrzewo;
            }


            int Sprawdz(Krawêdzi k)
            {
                int liczba = 0;
                if (!this.wêz³y.Contains(k.pocz¹tek))
                    liczba++;
                if (!this.wêz³y.Contains(k.koniec))
                    liczba++;
                return liczba;
            }

            public void Add(Krawêdzi k)
            {
                this.krawêdzie.Add(k);
                if (!this.wêz³y.Contains(k.pocz¹tek))
                    this.wêz³y.Add(k.pocz¹tek);
                if (!this.wêz³y.Contains(k.koniec))
                    this.wêz³y.Add(k.koniec);
            }

            public void Po³¹cz(Graf g)
            {
                this.wêz³y.AddRange(g.wêz³y);
                this.krawêdzie.AddRange(g.krawêdzie);
            }
            public void WyswietlMinimalneDrzewo()
            {
                string napis = "";
                 napis = "Minimalne drzewo rozpinaj¹ce:\n";
                    
                    foreach (var krawedz in krawêdzie)
                    {
                        napis += $"Waga: {krawedz.waga}, Pocz¹tek: {krawedz.pocz¹tek.wartoœæ}, Koniec: {krawedz.koniec.wartoœæ}\n";
                    }
                

                MessageBox.Show(napis);
            }
        }
    }
}
