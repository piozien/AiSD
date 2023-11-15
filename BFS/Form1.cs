using System.Runtime.Intrinsics.X86;

namespace BFS
{
    public partial class Form1 : Form

    {
        string napis = "";
        int[] tab = new int[0];
        public Form1()
        {
            InitializeComponent();
        }

        private void StartBT_Click(object sender, EventArgs e)
        {
            var w1 = new wêze³(5);
            var w2 = new wêze³(3);
            var w3 = new wêze³(1);
            var w4 = new wêze³(2);
            var w5 = new wêze³(6);
            var w6 = new wêze³(4);

            w1.dzieci.Add(w2);
            w1.dzieci.Add(w3);
            w1.dzieci.Add(w4);
            w2.dzieci.Add(w5);
            w2.dzieci.Add(w6);
            //A(w1);
            //MessageBox.Show(napis);

            ////////////////////////////////////////////////////////////////////
            // BFS

            //zaczynam od wêz³a 1
            var n1 = new note2(1);
            var n2 = new note2(3);
            var n3 = new note2(3);
            var n4 = new note2(4);
            var n5 = new note2(5);
            var n6 = new note2(6);
            var n7 = new note2(7);

            /*n1.Adds(n2);
            n1.sasiad.Add(n4);
            n1.sasiad.Add(n5);
            n2.sasiad.Add(n1);
            n2.sasiad.Add(n3);
            n3.sasiad.Add(n2);
            n3.sasiad.Add(n4);
            n4.sasiad.Add(n3);
            n4.sasiad.Add(n1);
            n5.sasiad.Add(n1);
            n5.sasiad.Add(n6);
            n5.sasiad.Add(n7);
            n6.sasiad.Add(n5);
            n6.sasiad.Add(n7);
            n7.sasiad.Add(n5);
            n7.sasiad.Add(n6);*/
          

            n1.Adds(n2);
            n1.Adds(n4);
            n1.Adds(n5);
            n2.Adds(n3);
            n3.Adds(n4);
            n5.Adds(n6);
            n5.Adds(n7);
            n6.Adds(n7);

            BFS(n1);

        }
        void BFS(note2 n)
        {
           
            




        }
        void A(wêze³ w)
        {
            //najpierw wypisuje korzeñ a póniej schodza do "dzieci"
            // napis += " " + w.wartosc.ToString();
            for (int i = 0; i < w.dzieci.Count; i++)
            {
                A(w.dzieci[i]);
            }
            //zaznaczam najpierw to co odwiedzi³em a póniej ide w strone korzenia
            napis += " " + w.wartosc.ToString();
        }
    }
    class wêze³
    {
        public int wartosc;
        public List<wêze³> dzieci = new List<wêze³>();

        public wêze³(int wartosc)
        {
            this.wartosc = wartosc;

        }

    }

    class note2
    {
        public int wartosc;
        public List<note2> sasiad = new List<note2>();
        public note2(int wartosc)
        {
            this.wartosc = wartosc;
        }
        public bool Adds(note2 s)
        {
            if(this == s)
            {
                return false;
            }
            bool wynik = false;

            if ((!this.sasiad.Contains(s)))
            {
                this.sasiad.Add(s);
                 wynik = true;
            }
            if ((!s.sasiad.Contains(this)))
            {
                s.sasiad.Add(this);
                wynik = true; 
            }
            return wynik;
            
        }
    }
}
