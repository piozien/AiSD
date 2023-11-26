namespace BubbleSort
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int[] bubbleSort(int[] tab)
        {
            int temp = tab[0];
            bool czyZamiana = false;

            do
            {
                czyZamiana = false;
                for (int i = 0; i < tab.Length - 1; i++)
                {
                    if (tab[i] > tab[i + 1])
                    {
                        czyZamiana = true;
                        temp = tab[i];
                        tab[i] = tab[i + 1];
                        tab[i + 1] = temp;
                    }
                }
            } while (czyZamiana == true);
            return tab;
        }


        string ToString(int[] array)
        {
            string wynik = "";
            for (int i = 0; i < array.Length; i++)
            {
                wynik += array[i].ToString() + " ";
            }
            return wynik;
        }

        int[] Covert(string napis)
        {
            var liczbyS = napis.Trim().Split(' ');
            int[] tablica = new int[liczbyS.Length];
            for (int i = 0; i < tablica.Length; i++)
            {
                tablica[i] = int.Parse(liczbyS[i]);
            }
            return tablica;
        }

        private void btn_BubbleSort_Click(object sender, EventArgs e)
        {
            //int[] tab = { 4, 1, 3, 7, 5 };
            //MessageBox.Show(ToString(tab));
            //int[] tab_1 = bubbleSort(tab);
            //MessageBox.Show(ToString(tab_1));

            string liczby = tbInput.Text;
            int[] tablica = Covert(liczby);
            int[] tablica2 = bubbleSort(tablica);
            lbl_wynik.Text = ("Wynik: " + ToString(tablica2));
        }
    }
}
