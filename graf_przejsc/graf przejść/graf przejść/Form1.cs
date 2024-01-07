using System.Text;

namespace graf_przejść
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

		private void button1_Click(object sender, EventArgs e)
		{
			Graf graf = new Graf();
			graf.Dodaj(3, 0, 1);
			graf.Dodaj(6, 0, 5);
			graf.Dodaj(3, 0, 4);
			graf.Dodaj(2, 4, 5);
			graf.Dodaj(1, 1, 2);
			graf.Dodaj(1, 2, 5);
			graf.Dodaj(3, 1, 3);
			graf.Dodaj(3, 2, 3);
			graf.Dodaj(1, 5, 3);

			graf.Dijkstra(0);
			MessageBox.Show(graf.komunikat);
		}
	}

	class Węzeł4
	{
		public int wartość;

		public Węzeł4(int wartość)
		{
			this.wartość = wartość;
		}	
	}

	class Krawędzi
	{
		public int waga;
		public Węzeł4 początek;
		public Węzeł4 koniec;

		public Krawędzi(int waga, Węzeł4 początek, Węzeł4 koniec)
		{
			this.waga = waga;
			this.początek = początek;
			this.koniec = koniec;
		}
	}

	class Graf
	{
		List<Węzeł4> węzły;
		List<Krawędzi> krawędzie;
		public List<int> WagiKrok;
		public string komunikat;

		public Graf()
		{
			węzły = new List<Węzeł4>();
			krawędzie = new List<Krawędzi>();
			WagiKrok = new List<int>();
			komunikat = "";
		}
		
		public void Dodaj(int waga, int początek, int koniec)
		{
			Węzeł4 wPoczątek = ZnajdźWęzeł(początek) ?? DodajWęzeł(początek);
			Węzeł4 wKoniec = ZnajdźWęzeł(koniec) ?? DodajWęzeł(koniec);

			if (ZnajdźKrawędź(wPoczątek, wKoniec) == null && ZnajdźKrawędź(wKoniec, wPoczątek) == null)
			{
				DodajKrawędź(waga, wPoczątek, wKoniec);
			}
		}

		private Węzeł4 DodajWęzeł(int wartość)
		{
			Węzeł4 w = new Węzeł4(wartość);
			węzły.Add(w);
			return w;
		}

		private void DodajKrawędź(int waga, Węzeł4 początek, Węzeł4 koniec)
		{
			Krawędzi k = new Krawędzi(waga, początek, koniec);
			krawędzie.Add(k);
		}

		private Krawędzi ZnajdźKrawędź(Węzeł4 początek, Węzeł4 koniec)
		{
			foreach (var k in krawędzie)
			{
				if (k.początek == początek && k.koniec == koniec)
				{
					return k;
				}
			}
			return null;
		}

		private Węzeł4 ZnajdźWęzeł(int wartość)
		{
			foreach (var w in węzły)
			{
				if (w.wartość == wartość)
				{
					return w;
				}
			}
			return null;
		}
		public void Dijkstra(int startowy)
		{
			int ilośćWęzłów = węzły.Count;
			int[] kosztyDojścia = new int[ilośćWęzłów];
			int[] poprzednicy = new int[ilośćWęzłów];
			bool[] odwiedzone = new bool[ilośćWęzłów];

			// Inicjalizacja tablic kosztów i poprzedników
			for (int i = 0; i < ilośćWęzłów; i++)
			{
				kosztyDojścia[i] = int.MaxValue; // Ustawienie początkowych kosztów na "nieskończoność"
				poprzednicy[i] = -1; // Brak poprzednika dla każdego węzła
			}

			// Koszt dojścia do startowego węzła ustawiony na 0
			kosztyDojścia[startowy] = 0;

			// Główna pętla algorytmu Dijkstry
			for (int i = 0; i < ilośćWęzłów - 1; i++)
			{
				// Znajdź węzeł o najmniejszym koszcie dojścia
				int aktualnyWęzeł = ZnajdźMinimumWagę(kosztyDojścia, odwiedzone);
				odwiedzone[aktualnyWęzeł] = true;

				// Aktualizuj koszty dojścia sąsiadów aktualnego węzła
				foreach (var krawędź in krawędzie)
				{
					if (krawędź.początek.wartość == aktualnyWęzeł)
					{
						int sąsiedniWęzeł = krawędź.koniec.wartość;
						int nowyKoszt = kosztyDojścia[aktualnyWęzeł] + krawędź.waga;

						if (nowyKoszt < kosztyDojścia[sąsiedniWęzeł])
						{
							kosztyDojścia[sąsiedniWęzeł] = nowyKoszt;
							poprzednicy[sąsiedniWęzeł] = aktualnyWęzeł;
						}
					}
				}
			}

			// Wyświetl najkrótszą ścieżkę z węzła startowego do pozostałych węzłów
			for (int i = 0; i < ilośćWęzłów; i++)
			{
				if (i != startowy)
				{
					WyświetlNajkrótsząŚcieżkę(startowy, i, poprzednicy, kosztyDojścia);
				}
			}
		}
		private void WyświetlNajkrótsząŚcieżkę(int wierzchołekStartowy, int wierzchołekKońcowy, int[] poprzednicy, int[] kosztyDojścia)
		{
			// Konstruuj komunikat dotyczący najkrótszej ścieżki
			komunikat += $"\nDojście do wierzchołka {wierzchołekKońcowy}: ";

			List<int> ścieżka = new List<int>();
			int bieżący = wierzchołekKońcowy;

			// Rekonstrukcja ścieżki z poprzedników
			while (bieżący != -1)
			{
				ścieżka.Insert(0, bieżący);
				bieżący = poprzednicy[bieżący];
			}

			// Wyświetlanie ścieżki lub informacji o jej braku
			if (ścieżka.Count == 0 || ścieżka[0] != wierzchołekStartowy)
			{
				komunikat += "Brak ścieżki.";
			}
			else
			{
				for (int i = 0; i < ścieżka.Count - 1; i++)
				{
					komunikat += $"{ścieżka[i]}–";
				}

				komunikat += $"{ścieżka[ścieżka.Count - 1]}, koszt {kosztyDojścia[wierzchołekKońcowy]}";
			}
		}

		private int ZnajdźMinimumWagę(int[] kosztyDojścia, bool[] odwiedzone)
		{
			// Znajdź indeks węzła o najmniejszym koszcie dojścia
			int minimum = int.MaxValue;
			int indeksMinimum = -1;

			for (int i = 0; i < węzły.Count; i++)
			{
				if (!odwiedzone[i] && kosztyDojścia[i] < minimum)
				{
					minimum = kosztyDojścia[i];
					indeksMinimum = i;
				}
			}

			return indeksMinimum;
		}
	}

	
}