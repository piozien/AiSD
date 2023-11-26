namespace SelectSort
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void SelectSort_Click(object sender, EventArgs e)
        {
            string tabs = tbInput.Text;
            int[] tab = convertInt(tabs);
            int[] tab2 = selectSort(tab);
            string wyn = convertString(tab2);
            lblWynik.Text = ("Wyn: " + wyn);
        }
        int[] convertInt(string napis)
        {
            var liczbyS = napis.Trim().Split(' ');
            int[] liczby = new int[liczbyS.Length];
            for (int i = 0; i < liczbyS.Length; i++)
            {
                liczby[i] = int.Parse(liczbyS[i]);
            }
            return liczby;
        }
        string convertString(int[] tab)
        {
            string wynik = "";
            for (int i = 0; i < tab.Length; i++)
            {
                wynik += tab[i].ToString() + " ";
            }
            return wynik;
        }
        int[] selectSort(int[] tab)
        {
            int minI, temp;
            for (int i = 0; i < tab.Length - 1; i++)
            {
                minI = i;
                for (int j = i; j < tab.Length; j++)
                {
                    if (tab[j] < tab[minI])
                    {
                        minI = j;
                    }
                }
                temp = tab[i];
                tab[i] = tab[minI];
                tab[minI] = temp;
            }
            return tab;
        }

    }
}
