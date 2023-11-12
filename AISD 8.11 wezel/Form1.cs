namespace AISD_8._11_wezel
{
    public partial class Form1 : Form
    {

        string napis = "";

        public Form1()
        {
            InitializeComponent();
        }
       
        private void StartBT_Click(object sender, EventArgs e)
        {
            var w1 = new węzeł(5);
            var w2 = new węzeł(3);
            var w3 = new węzeł(1);
            var w4 = new węzeł(2);
            var w5 = new węzeł(6);
            var w6 = new węzeł(4);

            w1.dzieci.Add(w2);
            w1.dzieci.Add(w3);
            w1.dzieci.Add(w4);
            w2.dzieci.Add(w5);
            w2.dzieci.Add(w6);
            A(w1);
            MessageBox.Show(napis);

        }
        void A(węzeł w)
        {   
            //najpierw wypisuje korzeń a póniej schodza do "dzieci"
            // napis += " " + w.wartosc.ToString();
            for(int i=0; i<w.dzieci.Count; i++)
            {
                A(w.dzieci[i]);
            }
            //zaznaczam najpierw to co odwiedziłem a póniej ide w strone korzenia
            napis += " " + w.wartosc.ToString();
        }
    }
    class węzeł
    {
        public int wartosc;
        public List<węzeł> dzieci = new List<węzeł>();
        
        public węzeł(int wartosc)
        {
            this.wartosc = wartosc;
            
        }
       
    }
    
    
}