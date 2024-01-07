namespace Algorytm_Dijkstry
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
            public List<int> WagiKrok;
            public string komunikat;

            public Graf()
            {
                wêz³y = new List<Wêze³4>();
                krawêdzie = new List<Krawêdzi>();
                WagiKrok = new List<int>();
                komunikat = "";
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
            public void Dijkstra1(int startowy)
            {
                int iloœæWêz³ów = wêz³y.Count;
                int[] kosztyDojœcia = new int[iloœæWêz³ów];
                int[] poprzednicy = new int[iloœæWêz³ów];
                bool[] odwiedzone = new bool[iloœæWêz³ów];

                // Inicjalizacja tablic kosztów i poprzedników
                for (int i = 0; i < iloœæWêz³ów; i++)
                {
                    kosztyDojœcia[i] = int.MaxValue; // Ustawienie pocz¹tkowych kosztów na "nieskoñczonoœæ"
                    poprzednicy[i] = -1; // Brak poprzednika dla ka¿dego wêz³a
                }

                // Koszt dojœcia do startowego wêz³a ustawiony na 0
                kosztyDojœcia[startowy] = 0;

                // G³ówna pêtla algorytmu Dijkstry
                for (int i = 0; i < iloœæWêz³ów - 1; i++)
                {
                    // ZnajdŸ wêze³ o najmniejszym koszcie dojœcia
                    int aktualnyWêze³ = ZnajdŸMinimumWagê(kosztyDojœcia, odwiedzone);
                    odwiedzone[aktualnyWêze³] = true;

                    // Aktualizuj koszty dojœcia s¹siadów aktualnego wêz³a
                    foreach (var krawêdŸ in krawêdzie)
                    {
                        if (krawêdŸ.pocz¹tek.wartoœæ == aktualnyWêze³)
                        {
                            int s¹siedniWêze³ = krawêdŸ.koniec.wartoœæ;
                            int nowyKoszt = kosztyDojœcia[aktualnyWêze³] + krawêdŸ.waga;

                            if (nowyKoszt < kosztyDojœcia[s¹siedniWêze³])
                            {
                                kosztyDojœcia[s¹siedniWêze³] = nowyKoszt;
                                poprzednicy[s¹siedniWêze³] = aktualnyWêze³;
                            }
                        }
                    }
                }

                // Wyœwietl najkrótsz¹ œcie¿kê z wêz³a startowego do pozosta³ych wêz³ów
                for (int i = 0; i < iloœæWêz³ów; i++)
                {
                    if (i != startowy)
                    {
                        WyœwietlNajkrótsz¹Œcie¿kê(startowy, i, poprzednicy, kosztyDojœcia);
                    }
                }
            }
            private void WyœwietlNajkrótsz¹Œcie¿kê(int wierzcho³ekStartowy, int wierzcho³ekKoñcowy, int[] poprzednicy, int[] kosztyDojœcia)
            {
                // Konstruuj komunikat dotycz¹cy najkrótszej œcie¿ki
                komunikat += $"\nDojœcie do wierzcho³ka {wierzcho³ekKoñcowy}: ";

                List<int> œcie¿ka = new List<int>();
                int bie¿¹cy = wierzcho³ekKoñcowy;

                // Rekonstrukcja œcie¿ki z poprzedników
                while (bie¿¹cy != -1)
                {
                    œcie¿ka.Insert(0, bie¿¹cy);
                    bie¿¹cy = poprzednicy[bie¿¹cy];
                }

                // Wyœwietlanie œcie¿ki lub informacji o jej braku
                if (œcie¿ka.Count == 0 || œcie¿ka[0] != wierzcho³ekStartowy)
                {
                    komunikat += "Brak œcie¿ki.";
                }
                else
                {
                    for (int i = 0; i < œcie¿ka.Count - 1; i++)
                    {
                        komunikat += $"{œcie¿ka[i]}–";
                    }

                    komunikat += $"{œcie¿ka[œcie¿ka.Count - 1]}, koszt {kosztyDojœcia[wierzcho³ekKoñcowy]}";
                }
            }

            private int ZnajdŸMinimumWagê(int[] kosztyDojœcia, bool[] odwiedzone)
            {
                // ZnajdŸ indeks wêz³a o najmniejszym koszcie dojœcia
                int minimum = int.MaxValue;
                int indeksMinimum = -1;

                for (int i = 0; i < wêz³y.Count; i++)
                {
                    if (!odwiedzone[i] && kosztyDojœcia[i] < minimum)
                    {
                        minimum = kosztyDojœcia[i];
                        indeksMinimum = i;
                    }
                }

                return indeksMinimum;
            }
        }
        class Element
        {
            public int dystans;
            public Wêze³4 poprzednik;
        }
        class GrafZ
        {
            List<Wêze³4> wêz³y;
            List<Krawêdzi> krawêdzie;
            private string komunikat;

            public GrafZ()
            {
                wêz³y = new List<Wêze³4>();
                krawêdzie = new List<Krawêdzi>();
                komunikat = "";
            }

            public String DostañKomunikat()
            {
                return komunikat;
            }

            public Wêze³4 DostañWêze³(int indeks)
            {
                return wêz³y[indeks];
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

            /*ZnajdŸMin(Dictionary<Wêze³4, Element> tabela, Label<Wêze³4> Q)
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

            public void Dijkstra2(Wêze³4 start)
            {
                Dictionary<Wêze³4, Element> tabela = new Dictionary<Wêze³4, Element>();
                foreach (var wêze³ in wêz³y)
                {
                    tabela[wêze³] = new Element { dystans = int.MaxValue, poprzednik = null };
                }

                tabela[start].dystans = 0;

                List<Wêze³4> Q = new List<Wêze³4>(wêz³y);

                while (Q.Count > 0)
                {
                    var u = ZnajdŸMin(tabela, Q);
                    Q.Remove(u);

                    foreach (var krawêdŸ in krawêdzie)
                    {
                        if (krawêdŸ.pocz¹tek == u && Q.Contains(krawêdŸ.koniec))
                        {
                            var alt = tabela[u].dystans + krawêdŸ.waga;
                            if (alt < tabela[krawêdŸ.koniec].dystans)
                            {
                                tabela[krawêdŸ.koniec].dystans = alt;
                                tabela[krawêdŸ.koniec].poprzednik = u;
                            }
                        }
                    }
                }

                foreach (var wêze³ in wêz³y)
                {
                    WyœwietlNajkrótsz¹Œcie¿kê(start, wêze³, tabela);
                }
            }

            private Wêze³4 ZnajdŸMin(Dictionary<Wêze³4, Element> tabela, List<Wêze³4> Q)
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

            private void WyœwietlNajkrótsz¹Œcie¿kê(Wêze³4 wierzcho³ekStartowy, Wêze³4 wierzcho³ekKoñcowy, Dictionary<Wêze³4, Element> tabela)
            {
                // Konstruuj komunikat dotycz¹cy najkrótszej œcie¿ki
                komunikat += $"\nDojœcie do wierzcho³ka {wierzcho³ekKoñcowy.wartoœæ}: ";

                List<Wêze³4> œcie¿ka = new List<Wêze³4>();
                Wêze³4 bie¿¹cy = wierzcho³ekKoñcowy;

                // Rekonstrukcja œcie¿ki z poprzedników
                while (bie¿¹cy != null)
                {
                    œcie¿ka.Insert(0, bie¿¹cy);
                    bie¿¹cy = tabela[bie¿¹cy].poprzednik;
                }


                // Wyœwietlanie œcie¿ki lub informacji o jej braku
                if (œcie¿ka.Count == 0 || œcie¿ka[0] != wierzcho³ekStartowy)
                {
                    komunikat += "Brak œcie¿ki.";
                }
                else
                {
                    for (int i = 0; i < œcie¿ka.Count - 1; i++)
                    {
                        komunikat += $"{œcie¿ka[i].wartoœæ}–";
                    }

                    komunikat += $"{œcie¿ka[œcie¿ka.Count - 1].wartoœæ}, koszt {tabela[wierzcho³ekKoñcowy].dystans}";
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

            graf2.Dijkstra2(graf2.DostañWêze³(0));
           //MessageBox.Show(graf2.DostañKomunikat());
           string napis = graf.komunikat + "\n--------------------\n" + graf2.DostañKomunikat();
            MessageBox.Show(napis);
        }
    }
}
