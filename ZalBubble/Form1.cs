namespace ZalBubble
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        int[] bubbleSort(int[] array)
        {
            int temp = 0;
            bool sort = false;
            do
            {
                sort = false;

                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                    }
                }
            }
            while (sort);
            return array;
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

        private void btn_BubbleSort(object sender, EventArgs e)
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