namespace SelectSort
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void StartBT_Click(object sender, EventArgs e)
        {
          
            string sizeInput = Microsoft.VisualBasic.Interaction.InputBox("Podaj rozmiar tablicy: ", "WprowadŸ rozmiar", "0");

            if (int.TryParse(sizeInput, out int arraySize) && arraySize > 0)
            {
                
                int[] myArray = GetIntArrayFromUser(arraySize);


                string arrayString = string.Join(", ", myArray);
                MessageBox.Show("Wczytana tablica: " + arrayString);

                SelectSort(myArray);

                string sortedArrayString = string.Join(", ", myArray);
                MessageBox.Show("Posortowana tablica: " + sortedArrayString);
            }
            else
            {
                MessageBox.Show("Podaj poprawny rozmiar tablicy (liczbê ca³kowit¹ wiêksz¹ od zera).");
            }
        }

        private int[] GetIntArrayFromUser(int size)
        {
            int[] array = new int[size];

            for (int i = 0; i < size; i++)
            {
                string input = Microsoft.VisualBasic.Interaction.InputBox("Podaj element tablicy o indeksie " + i.ToString() + ": ", "Wczytaj element", "0");
                if (int.TryParse(input, out int element))
                {
                    array[i] = element;
                }
                else
                {
                    MessageBox.Show("To nie jest liczba ca³kowita. WprowadŸ poprawn¹ liczbê.");
                    i--;
                }
            }

            return array;
        }
        private void SelectSort(int[] array)
        {
            int min;
            int temp;
            for(int i=0; i < array.Length - 1; i++) {
                min = i;
                for(int j = i; j < array.Length; j++)
                {
                    if (array[j] < array[min])
                    {
                        min = j;
                    }
                }
                temp = array[i];
                array[i] = array[min];
                array[min] = temp;
            }
        }
    }
}
