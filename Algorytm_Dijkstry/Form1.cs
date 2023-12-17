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
            public int liczbaKraw�dzi;
            

            public W�ze�4(int warto��)
            {
                this.warto�� = warto��;
                this.liczbaKraw�dzi = 0;
                
            }
            
        }
        class Kraw�d�
        {
            public int waga;
            public W�ze�4 pocz�tek;
            public W�ze�4 koniec;

            public Kraw�d�(W�ze�4 pocz�tek, W�ze�4 koniec, int waga)
            {
                this.waga = waga;
                this.pocz�tek = pocz�tek;
                this.koniec = koniec;
                pocz�tek.liczbaKraw�dzi++;
       
            }

        }
        class Graf
        {
            public static List<W�ze�4> w�z�y = new List<W�ze�4>();
            public static List<Kraw�d�> kraw�dzie = new List<Kraw�d�>();
            public Graf(W�ze�4 s)
            {
                w�z�y.Add(s);
            }
            public void Add(W�ze�4 s, W�ze�4 k, int waga)
            {
                if (!w�z�y.Contains(s))
                {
                    w�z�y.Add(s);
                }
                if (!w�z�y.Contains(k))
                {
                    w�z�y.Add(k);
                }
                var temp = new Kraw�d�(s, k, waga);
                if (!kraw�dzie.Contains(temp))
                {
                    kraw�dzie.Add(temp);
                }
               
            }
            public void Dijkstry(W�ze�4 start)
            {
                List<int> odleg�o�ci = new List<int>(w�z�y.Count);
                List<W�ze�4> poprzednicy = new List<W�ze�4>(w�z�y.Count);
                List<W�ze�4> nieodwiedzone = new List<W�ze�4>(w�z�y);

                foreach (var w in w�z�y)
                {
                    odleg�o�ci.Add(int.MaxValue);
                    poprzednicy.Add(null);
                }

                odleg�o�ci[w�z�y.IndexOf(start)] = 0;

                while (nieodwiedzone.Count > 0)
                {
                    W�ze�4 aktualny = null;
                    foreach (var w in nieodwiedzone)
                    {
                        if (aktualny == null || odleg�o�ci[w�z�y.IndexOf(w)] < odleg�o�ci[w�z�y.IndexOf(aktualny)])
                        {
                            aktualny = w;
                        }
                    }

                    nieodwiedzone.Remove(aktualny);

                    foreach (var kraw�d� in kraw�dzie)
                    {
                        if (kraw�d�.pocz�tek == aktualny)
                        {
                            int nowaOdleg�o�� = odleg�o�ci[w�z�y.IndexOf(aktualny)] + kraw�d�.waga;
                            if (nowaOdleg�o�� < odleg�o�ci[w�z�y.IndexOf(kraw�d�.koniec)])
                            {
                                odleg�o�ci[w�z�y.IndexOf(kraw�d�.koniec)] = nowaOdleg�o��;
                                poprzednicy[w�z�y.IndexOf(kraw�d�.koniec)] = aktualny;
                            }
                        }
                    }
                }

            }

        }



        private void Dijkstry_Click(object sender, EventArgs e)
        {
            var w0 = new W�ze�4(0);
            var w1 = new W�ze�4(1);
            var w2 = new W�ze�4(2);
            var w3 = new W�ze�4(3);
            var w4 = new W�ze�4(4);
            var w5 = new W�ze�4(5);
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
