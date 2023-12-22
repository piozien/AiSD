namespace dijkstry
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void DijkstryBT_Click(object sender, EventArgs e)
        {

        }
       
        class Wêze³4
        {
            public int wartoœæ;
            public int liczbaKrawêdzi;
        }
        class KrawêdŸ
        {
            public int waga;
            public Wêze³4 pocz¹tek;
            public Wêze³4 koniec;

            public KrawêdŸ(int waga, Wêze³4 pocz¹tek, Wêze³4 koniec)
            {
                this.waga = waga;
                this.pocz¹tek = pocz¹tek;
                this.koniec = koniec;
            }
        }
        class Graf
        {
            List<Wêze³4> wêz³y;
            List<KrawêdŸ> listaKrawêdzi;
            public List<int> Wagi;
            List<int> s¹siedzi;

            public Graf()
            {
                wêz³y = new List<Wêze³4>();
                listaKrawêdzi = new List<KrawêdŸ>();
                Wagi = new List<int>();
            }
            public void Zawiera(Wêze³4 w)
            {
                var x = this.wêz³y.ToList();
                
            }


            

            private List<int> S¹siad(Wêze³4 w, List<int> s¹siedzi)
            {
                
                foreach (var k in listaKrawêdzi)
                {
                    if (k.pocz¹tek == w && k.koniec != null)
                    {
                        s¹siedzi.Add(k.koniec.wartoœæ);
                    }
                }
                return s¹siedzi;
            }
        }
        

    }
}
