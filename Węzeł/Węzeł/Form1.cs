using System.Diagnostics.Eventing.Reader;

namespace Węzeł
{
    public partial class Form1 : Form
    {
        string napis = "";
        List<Węzeł2> odwiedzone = new();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var w1 = new Węzeł(5);

            var w2 = new Węzeł(3);
            var w3 = new Węzeł(1);
            var w4 = new Węzeł(2);
            var w5 = new Węzeł(6);
            var w6 = new Węzeł(4);

            w1.dzieci.Add(w2);
            w1.dzieci.Add(w3);
            w1.dzieci.Add(w4);
            w2.dzieci.Add(w5);
            w2.dzieci.Add(w6);

            napis = "";
            //DFS - Przeszukiwanie w głąb
            A(w1);
            MessageBox.Show(napis);
        }

        void A(Węzeł w)
        {
            for (int i = 0; i < w.dzieci.Count; i++)
            {
                A(w.dzieci[i]);
            }
            napis += " " + w.wartość.ToString();
        }
        class Węzeł
        {
            public int wartość;
            public List<Węzeł> dzieci = new List<Węzeł>();

            public Węzeł(int liczba)
            {
                this.wartość = liczba;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var w1 = new Węzeł2(1);
            var w2 = new Węzeł2(2);
            var w3 = new Węzeł2(3);
            var w4 = new Węzeł2(4);
            var w5 = new Węzeł2(5);
            var w6 = new Węzeł2(6);
            var w7 = new Węzeł2(7);


            w1.Add(w2);
            w1.Add(w4);
            w1.Add(w5);
            w2.Add(w3);
            w3.Add(w4);
            w5.Add(w6);
            w5.Add(w7);
            w6.Add(w7);

            napis = "";
            odwiedzone.Clear();
            //DFS - Przeszukiwanie w głąb z cyklem
            B(w1);
            MessageBox.Show(napis);
        }



        void B(Węzeł2 w)
        {
            odwiedzone.Add(w);
            napis += w.wartość.ToString() + " ";
            foreach (var sąsiad in w.sąsiedzi)
            {
                if (!odwiedzone.Contains(sąsiad))
                    B(sąsiad);
            }
        }



        private void button3_Click(object sender, EventArgs e)
        {
            var w1 = new Węzeł2(1);
            var w2 = new Węzeł2(2);
            var w3 = new Węzeł2(3);
            var w4 = new Węzeł2(4);
            var w5 = new Węzeł2(5);
            var w6 = new Węzeł2(6);
            var w7 = new Węzeł2(7);


            w1.Add(w2);
            w1.Add(w4);
            w1.Add(w5);
            w2.Add(w3);
            w3.Add(w4);
            w5.Add(w6);
            w5.Add(w7);
            w6.Add(w7);

            napis = "";
            odwiedzone.Clear();
            //BFS - Przeszukiwanie wszerz
            BFS(w1);
            MessageBox.Show(napis);
        }

        void BFS(Węzeł2 w)
        {
            if (w != null && !odwiedzone.Contains(w))
            {
                napis += w.wartość.ToString() + " ";
                odwiedzone.Add(w);
                foreach (var sąsiad in w.sąsiedzi)
                {
                    BFS(sąsiad);
                }
            }
        }
        class Węzeł2
        {
            public int wartość;
            public List<Węzeł2> sąsiedzi = new List<Węzeł2>();

            public Węzeł2(int liczba)
            {
                this.wartość = liczba;
            }

            public bool Add(Węzeł2 s)
            {
                if (this == s)
                {
                    return false;
                }

                bool wynik = false;

                if (!this.sąsiedzi.Contains(s))
                {
                    this.sąsiedzi.Add(s);
                    wynik = true;
                }

                if (!s.sąsiedzi.Contains(this))
                {
                    s.sąsiedzi.Add(this);
                    wynik = true;
                }

                return wynik;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //BST - drzewo przeszukiwań binarnych
            var w1 = new Węzeł3(5);

            w1.Add(4);
            w1.Add(3);
            w1.Add(3);
            w1.Add(4);
            w1.Add(3);
            w1.Add(8);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            var w = new Węzeł3(5);
            var d = new drzewoBinarne(w);
            d.Add(4);
            d.Add(3);
            d.Add(8);
            d.Add(7);
            d.Add(9);
            d.Add(2);
            d.Add(2);

            var x = d.ZnajdźNajmniejszy(d.korzeń);
            while (x != null)
            {
                x = d.Następnik(x);
            }
            var nast = d.Następnik(w);

            /* d.Wyswietl();
             d.Usuń(5);
             d.Wyswietl();
             var z = new Węzeł3(5);
             var d2 = new drzewoBinarne(z);
              d2.Wyswietl();
              d2.Usuń(5);
              d2.Wyswietl();*/
            d.Wyswietl();
            d.Usuń(7);
            d.Wyswietl();

        }
    }

    class Węzeł3
    {
        public int wartość;
        public Węzeł3 rodzic;
        public Węzeł3 leweDziecko;
        public Węzeł3? praweDziecko;

        public Węzeł3(int wartość)
        {
            this.wartość = wartość;
        }

        public override string ToString()
        {
            return wartość.ToString();
        }
        //można spróbować TreeView w form1;

        internal void Add(int liczba)
        {
            var dziecko = new Węzeł3(liczba);
            dziecko.rodzic = this;
            if (liczba < this.wartość)
            {
                this.leweDziecko = dziecko;
            }
            else
            {
                this.praweDziecko = dziecko;
            }
        }
        public int ileDzieci()
        {
            int wynik = 0;
            if (this.leweDziecko != null)
            {
                wynik++;
            }
            if (this.praweDziecko != null)
            {
                wynik++;
            }
            return wynik;
        }

    }

    class drzewoBinarne
    {
        string napis;
        public Węzeł3 korzeń;
        public int liczbaWęzłów = 0;


        public drzewoBinarne(Węzeł3 korzeń)
        {
            this.korzeń = korzeń;
        }
        public override string ToString()
        {
            return korzeń.ToString();
        }

        public void Add(int liczba)
        {
            var rodzic = this.znajdźRodzica(liczba);
            rodzic.Add(liczba);
            liczbaWęzłów++;
        }
        public void Wyswietl()
        {
            napis = "";
            przejścieSzczegółowo(korzeń, null);
            MessageBox.Show(napis);
        }

        private void przejścieSzczegółowo(Węzeł3 w, Węzeł3 rodzic)
        {
            if (w != null)
            {
                przejścieSzczegółowo(w.leweDziecko, w);
                napis += $"Wartość: {w.wartość}, Rodzic: {rodzic?.wartość ?? -1}, Lewe dziecko: {(w.leweDziecko != null ? w.leweDziecko.wartość.ToString() : "brak")}, Prawe dziecko: {(w.praweDziecko != null ? w.praweDziecko.wartość.ToString() : "brak")}\n";
                przejścieSzczegółowo(w.praweDziecko, w);
            }
        }

        private Węzeł3 znajdźRodzica(int liczba)
        {
            var w = this.korzeń;
            while (true)
            {
                if (liczba < w.wartość)
                {
                    if (w.leweDziecko != null)
                    {
                        w = w.leweDziecko;
                    }
                    else
                    {
                        return w;
                    }
                }
                else
                {
                    if (w.praweDziecko != null)
                    {
                        w = w.praweDziecko;
                    }
                    else
                    {
                        return w;
                    }
                }
            }

        }
        public Węzeł3 znajdź(int liczba)
        {
            var w = this.korzeń;
            if (w.wartość == liczba)
            {
                return w;
            }
            while (true)
            {
                if (liczba == w.wartość)
                {
                    return w;
                }
                if (liczba < w.wartość)
                {
                    if (w.leweDziecko != null)
                    {
                        w = w.leweDziecko;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    if (w.praweDziecko != null)
                    {
                        w = w.praweDziecko;
                        if (w.wartość == liczba)
                        {
                            return w;
                        }

                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }
        public Węzeł3 ZnajdźNajmniejszy(Węzeł3 w)
        {
            //wezeł3 z najmniejsza wartoscia
            while (w.leweDziecko != null)
            {
                w = w.leweDziecko;
            }
            return w;
            // for(w.leweDziecko != null, w = w.leweDziecko);
            // return w;
        }
        public Węzeł3 ZnajdźNajwiększy(Węzeł3 w)
        {
            //wezeł3 z największą wartościa
            while (w.praweDziecko != null)
            {
                w = w.praweDziecko;
            }
            return w;

        }
        public Węzeł3 Następnik(Węzeł3 w)
        {
            //1: Jest prawe dziecko znajdź najmniejszy dla górnego dziecka
            //2: Idę w górę tak długo aż wyjdę jako lewe dziecko rodzica, następnik to rodzic
            //3: Gdy nie znajdę (2) i nie mogę iść do góry nie ma następnika
            if (w.praweDziecko != null)
            {
                return this.ZnajdźNajmniejszy(w.praweDziecko);
            }
            while (w.rodzic != null)
            {

                if (w.rodzic.leweDziecko == w)
                {
                    return w.rodzic;
                }
                w = w.rodzic;
            }

            return null;

        }
        public Węzeł3 Poprzednik(Węzeł3 w)
        {
            if (w.leweDziecko != null)
            {
                return ZnajdźNajwiększy(w.leweDziecko);
            }
            if (w.rodzic == null) return null;
            while (w == w.rodzic.leweDziecko)
            {
                w = w.rodzic;
                if (w.rodzic == null) return null;
            }
            return w.rodzic;
        }
        public void Usuń(int liczba)
        {
            Węzeł3 w = znajdź(liczba);
            if (w != null)
            {
                Usuń(w);
            }
           
        }
        public Węzeł3 Usuń(Węzeł3 w)
        {
            var liczbaDzieci = w.ileDzieci();
            switch (liczbaDzieci)
            {
                case 0:
                    return this.UsuńGdy0Dzieci(w);

                case 1:
                    return this.UsuńGdy1Dziecko(w);

                case 2:
                    return this.UsuńGdy2Dzieci(w);
                    
            }
            return w;

        }

        Węzeł3 UsuńGdy0Dzieci(Węzeł3 w)
        {
            if (w.rodzic == null)
            {
                this.korzeń = null;
                return w;

            }
            if (w.rodzic.leweDziecko == w)
            {
                w.rodzic.leweDziecko = null;
            }
            else
            {
                w.rodzic.praweDziecko = null;
            }
            w.rodzic = null;

            return w;
        }
        Węzeł3 UsuńGdy1Dziecko(Węzeł3 w)
        {
            Węzeł3 dziecko = null;
            if (w.leweDziecko != null)
            {
                dziecko = w.leweDziecko;
                w.leweDziecko = null;
            }
            else
            {
                dziecko = w.praweDziecko;
                w.praweDziecko = null;
            }
            dziecko.rodzic = w.rodzic;

            if (w.rodzic.leweDziecko == w)
            {
                w.rodzic.leweDziecko = dziecko;
            }
            else
            {
                w.rodzic.praweDziecko = dziecko;
            }
            w.rodzic = null;

            return w;
        }
        Węzeł3 UsuńGdy2Dzieci(Węzeł3 w)
        {
            var zamiennik = this.Następnik(w);
            zamiennik = this.Usuń(zamiennik);
            if (w.rodzic != null)
            {
                if (w.rodzic.leweDziecko == w)
                {
                    w.rodzic.leweDziecko = zamiennik;
                }
                else
                {
                    w.rodzic.praweDziecko = zamiennik;
                }
            }
            zamiennik.rodzic = w.rodzic;
            w.rodzic = null;
            zamiennik.leweDziecko = w.leweDziecko;
            zamiennik.leweDziecko.rodzic = zamiennik;
            w.leweDziecko = null;
            zamiennik.praweDziecko = w.praweDziecko;
            zamiennik.praweDziecko.rodzic = zamiennik;
            w.praweDziecko = null;
            return w;
        }
        

    }
    class Węzeł4
    {
        public int wartość;
        public int liczbaKrawędzi;
    }
    class Krawędź
    {
        public int waga;
        public Węzęł4 początek;
        public Węzeł4 koniec;
    }
    class Graf
    {
        List<Węzeł4> węzły;
        List<Krawędzie> krawędzie;
    }


    /* public void Usuń(int liczba)
     {
         Węzeł3 w = znajdź(liczba);
         if (w != null)
         {
             Usuń(w);
             liczbaWęzłów--;
         }
     }*/
    /*private void Usuń(Węzeł3 w)
    {
        //1: Gdy nie ma dzieci to odwiązujemy Węzeł
        //2: Gdy jest jedno dziecko, to wchodzi na miejsce rodzica
        //3: Gdy dwoje dzieci, to sprawdzam następnik rekurencyjnie aż będę miał krok 1 lub 2
        if (w.leweDziecko == null && w.praweDziecko == null)
        {
            // przypadek dla samego korzenia
            if (w.rodzic == null)
            {
                korzeń = null;
            }
            else
            { //odwiązywanie wezła jak nie ma dzieci
                if (w.rodzic.leweDziecko == w)
                {
                    w.rodzic.leweDziecko = null;
                }
                else
                {
                    w.rodzic.praweDziecko = null;
                }
            }

        }
        else if (w.leweDziecko != null && w.praweDziecko == null)
        {
            //jak jest tylko lewe dziecko to staje sie ono rodzicem
            Zamień(w, w.leweDziecko);
        }
        else if (w.leweDziecko == null && w.praweDziecko != null)
        {
            // jak jest tylko prawe dziecko
            Zamień(w, w.praweDziecko);
        }
        else
        {
            // Przypadek dla 2 dzieci
            //Węzeł3 dzieckoprawe = Następnik(w);
            //Usuń(dzieckoprawe);
            //Usuń(w);
            Węzeł3 nas = Następnik(w);
           // w.wartość = nas.wartość;
            Usuń(nas);
        }

    }
    public void Zamień(Węzeł3 stary, Węzeł3 nowy)
    {


        if (stary.rodzic == null)
        {
            //sytuacja gdy mam korzeń i 1 dziecko, dziecko staje sie korzeniem
            korzeń = nowy;
            if (nowy != null)
            {
                nowy.rodzic = null; //jeżeli węzeł jest to usuwam rodzica
            }
        }
        else
        {
            if (stary.rodzic.leweDziecko == stary)
            {
                // zamiana starego na nowy jak był lewym dzieckiem
                stary.rodzic.leweDziecko = nowy;
            }
            else
            {
                // zamiana starego na nowy jak był prawym dzieckiem
                stary.rodzic.praweDziecko = nowy;
            }

            if (nowy != null)
            {
                nowy.rodzic = stary.rodzic; //nowemu daje rodzica którego miał stary węzeł
            }
        }
    }*/

}

/*void B(Węzeł2 w)
		{
			bool[] odwiedzone = new bool[100];

			Bfunkcja(w, odwiedzone);
		}

		void Bfunkcja(Węzeł2 node, bool[] odwiedzone)
		{
			odwiedzone[node.wartość] = true;
			napis += node.wartość + " ";

			foreach (var sąsiad in node.sąsiedzi)
			{
				if (node != null && !odwiedzone[sąsiad.wartość])
				{
					Bfunkcja(sąsiad, odwiedzone);
				}
			}
		}*/