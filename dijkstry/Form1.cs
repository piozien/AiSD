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
       
        class W�ze�4
        {
            public int warto��;
            public int liczbaKraw�dzi;
        }
        class Kraw�d�
        {
            public int waga;
            public W�ze�4 pocz�tek;
            public W�ze�4 koniec;

            public Kraw�d�(int waga, W�ze�4 pocz�tek, W�ze�4 koniec)
            {
                this.waga = waga;
                this.pocz�tek = pocz�tek;
                this.koniec = koniec;
            }
        }
        class Graf
        {
            List<W�ze�4> w�z�y;
            List<Kraw�d�> listaKraw�dzi;
            public List<int> Wagi;
            List<int> s�siedzi;

            public Graf()
            {
                w�z�y = new List<W�ze�4>();
                listaKraw�dzi = new List<Kraw�d�>();
                Wagi = new List<int>();
            }
            public void Zawiera(W�ze�4 w)
            {
                var x = this.w�z�y.ToList();
                
            }


            

            private List<int> S�siad(W�ze�4 w, List<int> s�siedzi)
            {
                
                foreach (var k in listaKraw�dzi)
                {
                    if (k.pocz�tek == w && k.koniec != null)
                    {
                        s�siedzi.Add(k.koniec.warto��);
                    }
                }
                return s�siedzi;
            }
        }
        

    }
}
