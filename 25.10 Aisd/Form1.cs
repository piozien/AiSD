namespace _25._10_Aisd
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btnBubbleSort_Click(object sender, EventArgs e)
        {
            string tekst = tbInput.Text;
            int[] tablica = bubblesort(Convert(tekst));
            lblWynik.Text = ("Posortowana tablica: " + wypisz(tablica));
        }

        int[] Convert(string napis)
        {
            var liczbyS = napis.Trim().Split(' ');
            int[] liczby = new int[liczbyS.Length];
            for (int i = 0; i < liczbyS.Length; i++)
            {
                liczby[i] = int.Parse(liczbyS[i]);
            }
            return liczby;
        }
        int[] bubblesort(int[] tab)
        {

            int size = tab.Length - 1;
            Boolean przenies;

            for (int i = 0; i < size; i++)
            {
                przenies = false;
                for (int j = 0; j < size; j++)
                {
                    if (tab[j] > tab[j + 1])
                    {
                        int temp = tab[j];
                        tab[j] = tab[j + 1];
                        tab[j + 1] = temp;
                        przenies = true;
                    }
                }
                if (przenies == false) break;
            }
            return tab;
        }
        string wypisz(int[] tab)
        {
            string wynik = "";
            for (int i = 0; i < tab.Length; i++)
            {
                wynik += tab[i].ToString() + " ";
            }
            return wynik;
        }

   
    }
}