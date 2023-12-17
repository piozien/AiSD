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
            public int liczbaKrawêdzi;
            

            public Wêze³4(int wartoœæ)
            {
                this.wartoœæ = wartoœæ;
                this.liczbaKrawêdzi = 0;
                
            }
            
        }
        class KrawêdŸ
        {
            public int waga;
            public Wêze³4 pocz¹tek;
            public Wêze³4 koniec;

            public KrawêdŸ(Wêze³4 pocz¹tek, Wêze³4 koniec, int waga)
            {
                this.waga = waga;
                this.pocz¹tek = pocz¹tek;
                this.koniec = koniec;
                pocz¹tek.liczbaKrawêdzi++;
       
            }

        }
        class Graf
        {
            public static List<Wêze³4> wêz³y = new List<Wêze³4>();
            public static List<KrawêdŸ> krawêdzie = new List<KrawêdŸ>();
            public Graf(Wêze³4 s)
            {
                wêz³y.Add(s);
            }
            public void Add(Wêze³4 s, Wêze³4 k, int waga)
            {
                if (!wêz³y.Contains(s))
                {
                    wêz³y.Add(s);
                }
                if (!wêz³y.Contains(k))
                {
                    wêz³y.Add(k);
                }
                var temp = new KrawêdŸ(s, k, waga);
                if (!krawêdzie.Contains(temp))
                {
                    krawêdzie.Add(temp);
                }
               
            }
            public void Dijkstry(Wêze³4 start)
            {
                List<int> odleg³oœci = new List<int>(wêz³y.Count);
                List<Wêze³4> poprzednicy = new List<Wêze³4>(wêz³y.Count);
                List<Wêze³4> nieodwiedzone = new List<Wêze³4>(wêz³y);

                foreach (var w in wêz³y)
                {
                    odleg³oœci.Add(int.MaxValue);
                    poprzednicy.Add(null);
                }

                odleg³oœci[wêz³y.IndexOf(start)] = 0;

                while (nieodwiedzone.Count > 0)
                {
                    Wêze³4 aktualny = null;
                    foreach (var w in nieodwiedzone)
                    {
                        if (aktualny == null || odleg³oœci[wêz³y.IndexOf(w)] < odleg³oœci[wêz³y.IndexOf(aktualny)])
                        {
                            aktualny = w;
                        }
                    }

                    nieodwiedzone.Remove(aktualny);

                    foreach (var krawêdŸ in krawêdzie)
                    {
                        if (krawêdŸ.pocz¹tek == aktualny)
                        {
                            int nowaOdleg³oœæ = odleg³oœci[wêz³y.IndexOf(aktualny)] + krawêdŸ.waga;
                            if (nowaOdleg³oœæ < odleg³oœci[wêz³y.IndexOf(krawêdŸ.koniec)])
                            {
                                odleg³oœci[wêz³y.IndexOf(krawêdŸ.koniec)] = nowaOdleg³oœæ;
                                poprzednicy[wêz³y.IndexOf(krawêdŸ.koniec)] = aktualny;
                            }
                        }
                    }
                }

            }

        }



        private void Dijkstry_Click(object sender, EventArgs e)
        {
            var w0 = new Wêze³4(0);
            var w1 = new Wêze³4(1);
            var w2 = new Wêze³4(2);
            var w3 = new Wêze³4(3);
            var w4 = new Wêze³4(4);
            var w5 = new Wêze³4(5);
            var d = new Graf(w0);
            d.Add(w0, w1, 3);
            d.Add(w0, w4, 3);
            d.Add(w0, w5, 6);
            d.Add(w1, w2, 1);
            d.Add(w1, w3, 3);
            d.Add(w2, w3, 3);
            d.Add(w2, w5, 7);
            d.Add(w5, w3, 1);
            d.Add(w4, w5, 2);
            d.Dijkstry(w0);
        }
    }
}
