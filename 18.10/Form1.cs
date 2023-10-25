namespace _18._10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] tab = { 10, 9, 6, 5, 3, 1 };
            MessageBox.Show(wypisz(tab), "Pierwsza tablica");
            int[] tab2 = bubblesort(tab);
            MessageBox.Show(wypisz(tab2), "Posortowane");

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

//sortowanie przez wybieranie select sort