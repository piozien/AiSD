namespace Algorytm_Dijkstry
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
            public List<int> WagiKrok;
            public string komunikat;

            public Graf()
            {
                w�z�y = new List<W�ze�4>();
                kraw�dzie = new List<Kraw�dzi>();
                WagiKrok = new List<int>();
                komunikat = "";
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
            public void Dijkstra1(int startowy)
            {
                int ilo��W�z��w = w�z�y.Count;
                int[] kosztyDoj�cia = new int[ilo��W�z��w];
                int[] poprzednicy = new int[ilo��W�z��w];
                bool[] odwiedzone = new bool[ilo��W�z��w];

                // Inicjalizacja tablic koszt�w i poprzednik�w
                for (int i = 0; i < ilo��W�z��w; i++)
                {
                    kosztyDoj�cia[i] = int.MaxValue; // Ustawienie pocz�tkowych koszt�w na "niesko�czono��"
                    poprzednicy[i] = -1; // Brak poprzednika dla ka�dego w�z�a
                }

                // Koszt doj�cia do startowego w�z�a ustawiony na 0
                kosztyDoj�cia[startowy] = 0;

                // G��wna p�tla algorytmu Dijkstry
                for (int i = 0; i < ilo��W�z��w - 1; i++)
                {
                    // Znajd� w�ze� o najmniejszym koszcie doj�cia
                    int aktualnyW�ze� = Znajd�MinimumWag�(kosztyDoj�cia, odwiedzone);
                    odwiedzone[aktualnyW�ze�] = true;

                    // Aktualizuj koszty doj�cia s�siad�w aktualnego w�z�a
                    foreach (var kraw�d� in kraw�dzie)
                    {
                        if (kraw�d�.pocz�tek.warto�� == aktualnyW�ze�)
                        {
                            int s�siedniW�ze� = kraw�d�.koniec.warto��;
                            int nowyKoszt = kosztyDoj�cia[aktualnyW�ze�] + kraw�d�.waga;

                            if (nowyKoszt < kosztyDoj�cia[s�siedniW�ze�])
                            {
                                kosztyDoj�cia[s�siedniW�ze�] = nowyKoszt;
                                poprzednicy[s�siedniW�ze�] = aktualnyW�ze�;
                            }
                        }
                    }
                }

                // Wy�wietl najkr�tsz� �cie�k� z w�z�a startowego do pozosta�ych w�z��w
                for (int i = 0; i < ilo��W�z��w; i++)
                {
                    if (i != startowy)
                    {
                        Wy�wietlNajkr�tsz��cie�k�(startowy, i, poprzednicy, kosztyDoj�cia);
                    }
                }
            }
            private void Wy�wietlNajkr�tsz��cie�k�(int wierzcho�ekStartowy, int wierzcho�ekKo�cowy, int[] poprzednicy, int[] kosztyDoj�cia)
            {
                // Konstruuj komunikat dotycz�cy najkr�tszej �cie�ki
                komunikat += $"\nDoj�cie do wierzcho�ka {wierzcho�ekKo�cowy}: ";

                List<int> �cie�ka = new List<int>();
                int bie��cy = wierzcho�ekKo�cowy;

                // Rekonstrukcja �cie�ki z poprzednik�w
                while (bie��cy != -1)
                {
                    �cie�ka.Insert(0, bie��cy);
                    bie��cy = poprzednicy[bie��cy];
                }

                // Wy�wietlanie �cie�ki lub informacji o jej braku
                if (�cie�ka.Count == 0 || �cie�ka[0] != wierzcho�ekStartowy)
                {
                    komunikat += "Brak �cie�ki.";
                }
                else
                {
                    for (int i = 0; i < �cie�ka.Count - 1; i++)
                    {
                        komunikat += $"{�cie�ka[i]}�";
                    }

                    komunikat += $"{�cie�ka[�cie�ka.Count - 1]}, koszt {kosztyDoj�cia[wierzcho�ekKo�cowy]}";
                }
            }

            private int Znajd�MinimumWag�(int[] kosztyDoj�cia, bool[] odwiedzone)
            {
                // Znajd� indeks w�z�a o najmniejszym koszcie doj�cia
                int minimum = int.MaxValue;
                int indeksMinimum = -1;

                for (int i = 0; i < w�z�y.Count; i++)
                {
                    if (!odwiedzone[i] && kosztyDoj�cia[i] < minimum)
                    {
                        minimum = kosztyDoj�cia[i];
                        indeksMinimum = i;
                    }
                }

                return indeksMinimum;
            }
        }
        class Element
        {
            public int dystans;
            public W�ze�4 poprzednik;
        }
        class GrafZ
        {
            List<W�ze�4> w�z�y;
            List<Kraw�dzi> kraw�dzie;
            private string komunikat;

            public GrafZ()
            {
                w�z�y = new List<W�ze�4>();
                kraw�dzie = new List<Kraw�dzi>();
                komunikat = "";
            }

            public String Dosta�Komunikat()
            {
                return komunikat;
            }

            public W�ze�4 Dosta�W�ze�(int indeks)
            {
                return w�z�y[indeks];
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

            /*Znajd�Min(Dictionary<W�ze�4, Element> tabela, Label<W�ze�4> Q)
            {
                var min = tabelka[Q[object]];
                for(var w in Q)
                {
                    if (tabelka[w].dystans < min.dystans)
                    {
                        min.tabelka[w];
                    }
                }
                return min;
            }*/

            public void Dijkstra2(W�ze�4 start)
            {
                Dictionary<W�ze�4, Element> tabela = new Dictionary<W�ze�4, Element>();
                foreach (var w�ze� in w�z�y)
                {
                    tabela[w�ze�] = new Element { dystans = int.MaxValue, poprzednik = null };
                }

                tabela[start].dystans = 0;

                List<W�ze�4> Q = new List<W�ze�4>(w�z�y);

                while (Q.Count > 0)
                {
                    var u = Znajd�Min(tabela, Q);
                    Q.Remove(u);

                    foreach (var kraw�d� in kraw�dzie)
                    {
                        if (kraw�d�.pocz�tek == u && Q.Contains(kraw�d�.koniec))
                        {
                            var alt = tabela[u].dystans + kraw�d�.waga;
                            if (alt < tabela[kraw�d�.koniec].dystans)
                            {
                                tabela[kraw�d�.koniec].dystans = alt;
                                tabela[kraw�d�.koniec].poprzednik = u;
                            }
                        }
                    }
                }

                foreach (var w�ze� in w�z�y)
                {
                    Wy�wietlNajkr�tsz��cie�k�(start, w�ze�, tabela);
                }
            }

            private W�ze�4 Znajd�Min(Dictionary<W�ze�4, Element> tabela, List<W�ze�4> Q)
            {
                var min = Q[0];
                foreach (var w in Q)
                {
                    if (tabela[w].dystans < tabela[min].dystans)
                    {
                        min = w;
                    }
                }
                return min;
            }

            private void Wy�wietlNajkr�tsz��cie�k�(W�ze�4 wierzcho�ekStartowy, W�ze�4 wierzcho�ekKo�cowy, Dictionary<W�ze�4, Element> tabela)
            {
                // Konstruuj komunikat dotycz�cy najkr�tszej �cie�ki
                komunikat += $"\nDoj�cie do wierzcho�ka {wierzcho�ekKo�cowy.warto��}: ";

                List<W�ze�4> �cie�ka = new List<W�ze�4>();
                W�ze�4 bie��cy = wierzcho�ekKo�cowy;

                // Rekonstrukcja �cie�ki z poprzednik�w
                while (bie��cy != null)
                {
                    �cie�ka.Insert(0, bie��cy);
                    bie��cy = tabela[bie��cy].poprzednik;
                }


                // Wy�wietlanie �cie�ki lub informacji o jej braku
                if (�cie�ka.Count == 0 || �cie�ka[0] != wierzcho�ekStartowy)
                {
                    komunikat += "Brak �cie�ki.";
                }
                else
                {
                    for (int i = 0; i < �cie�ka.Count - 1; i++)
                    {
                        komunikat += $"{�cie�ka[i].warto��}�";
                    }

                    komunikat += $"{�cie�ka[�cie�ka.Count - 1].warto��}, koszt {tabela[wierzcho�ekKo�cowy].dystans}";
                }
            }

        }



        private void Dijkstry_Click(object sender, EventArgs e)
        {
            
            Graf graf = new Graf();
            graf.Dodaj(3, 0, 1);
            graf.Dodaj(6, 0, 5);
            graf.Dodaj(3, 0, 4);
            graf.Dodaj(2, 4, 5);
            graf.Dodaj(1, 1, 2);
            graf.Dodaj(1, 2, 5);
            graf.Dodaj(3, 1, 3);
            graf.Dodaj(3, 2, 3);
            graf.Dodaj(1, 5, 3);

            graf.Dijkstra1(0);
            //MessageBox.Show(graf.komunikat);
            

            GrafZ graf2 = new GrafZ();
            graf2.Dodaj(3, 0, 1);
            graf2.Dodaj(6, 0, 5);
            graf2.Dodaj(3, 0, 4);
            graf2.Dodaj(2, 4, 5);
            graf2.Dodaj(1, 1, 2);
            graf2.Dodaj(1, 2, 5);
            graf2.Dodaj(3, 1, 3);
            graf2.Dodaj(3, 2, 3);
            graf2.Dodaj(1, 5, 3);

            graf2.Dijkstra2(graf2.Dosta�W�ze�(0));
           //MessageBox.Show(graf2.Dosta�Komunikat());
           string napis = graf.komunikat + "\n--------------------\n" + graf2.Dosta�Komunikat();
            MessageBox.Show(napis);
        }
    }
}
