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

        class W�ze�4
        {
            public int warto��;

            public W�ze�4(int warto��)
            {
                this.warto�� = warto��;
            }
        }

        class Kraw�dzi
        {
            public int waga;
            public W�ze�4 pocz�tek;
            public W�ze�4 koniec;

            public Kraw�dzi(int waga, W�ze�4 pocz�tek, W�ze�4 koniec)
            {
                this.waga = waga;
                this.pocz�tek = pocz�tek;
                this.koniec = koniec;
            }
        }

        class Graf
        {
            List<W�ze�4> w�z�y;
            List<Kraw�dzi> kraw�dzie;

            public Graf()
            {
                this.w�z�y = new List<W�ze�4>();
                this.kraw�dzie = new List<Kraw�dzi>();
            }

            public Graf(Kraw�dzi k)
            {
                w�z�y = new List<W�ze�4>();
                kraw�dzie = new List<Kraw�dzi>();
                this.kraw�dzie.Add(k);
                this.w�z�y.Add(k.pocz�tek);
                this.w�z�y.Add(k.koniec);
            }

            public void Dodaj(int waga, int pocz�tek, int koniec)
            {
                W�ze�4 wPocz�tek = Znajd�W�ze�(pocz�tek) ?? DodajW�ze�(pocz�tek);
                W�ze�4 wKoniec = Znajd�W�ze�(koniec) ?? DodajW�ze�(koniec);

                if (Znajd�Kraw�d�(wPocz�tek, wKoniec) == null && Znajd�Kraw�d�(wKoniec, wPocz�tek) == null)
                {
                    DodajKraw�d�(waga, wPocz�tek, wKoniec);
                }
            }

            private W�ze�4 DodajW�ze�(int warto��)
            {
                W�ze�4 w = new W�ze�4(warto��);
                w�z�y.Add(w);
                return w;
            }

            private void DodajKraw�d�(int waga, W�ze�4 pocz�tek, W�ze�4 koniec)
            {
                Kraw�dzi k = new Kraw�dzi(waga, pocz�tek, koniec);
                kraw�dzie.Add(k);
            }

            private Kraw�dzi Znajd�Kraw�d�(W�ze�4 pocz�tek, W�ze�4 koniec)
            {
                foreach (var k in kraw�dzie)
                {
                    if (k.pocz�tek == pocz�tek && k.koniec == koniec)
                    {
                        return k;
                    }
                }
                return null;
            }

            private W�ze�4 Znajd�W�ze�(int warto��)
            {
                foreach (var w in w�z�y)
                {
                    if (w.warto�� == warto��)
                    {
                        return w;
                    }
                }
                return null;
            }

            public Graf Kruskal()
            {
                //sortowanie ze wzgl�du na wag� kraw�dzi rosn�co
                var krawedzie = this.kraw�dzie.OrderBy(k => k.waga);

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
                                czyponownie.Po��cz(g);
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
                    minimalnedrzewo.Po��cz(g);
                }

                return minimalnedrzewo;
            }


            int Sprawdz(Kraw�dzi k)
            {
                int liczba = 0;
                if (!this.w�z�y.Contains(k.pocz�tek))
                    liczba++;
                if (!this.w�z�y.Contains(k.koniec))
                    liczba++;
                return liczba;
            }

            public void Add(Kraw�dzi k)
            {
                this.kraw�dzie.Add(k);
                if (!this.w�z�y.Contains(k.pocz�tek))
                    this.w�z�y.Add(k.pocz�tek);
                if (!this.w�z�y.Contains(k.koniec))
                    this.w�z�y.Add(k.koniec);
            }

            public void Po��cz(Graf g)
            {
                this.w�z�y.AddRange(g.w�z�y);
                this.kraw�dzie.AddRange(g.kraw�dzie);
            }
            public void WyswietlMinimalneDrzewo()
            {
                string napis = "";
                 napis = "Minimalne drzewo rozpinaj�ce:\n";
                    
                    foreach (var krawedz in kraw�dzie)
                    {
                        napis += $"Waga: {krawedz.waga}, Pocz�tek: {krawedz.pocz�tek.warto��}, Koniec: {krawedz.koniec.warto��}\n";
                    }
                

                MessageBox.Show(napis);
            }
        }
    }
}
