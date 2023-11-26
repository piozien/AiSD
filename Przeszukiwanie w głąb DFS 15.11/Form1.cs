namespace wezly_i_kolejki_15._11
{
    using System.Runtime.Intrinsics.X86;
    using System.Windows.Forms;
    using System.Collections.Generic;


    public partial class Form1 : Form

    {
        string napis = "";
        List<note2> odwiedzone = new();
        public Form1()
        {
            InitializeComponent();
        }

        private void StartBT_Click(object sender, EventArgs e)
        {
            var n1 = new note2(1);
            var n2 = new note2(2);
            var n3 = new note2(3);
            var n4 = new note2(4);
            var n5 = new note2(5);
            var n6 = new note2(6);
            var n7 = new note2(7);

            n1.Adds(n2);
            n1.Adds(n3);
            n1.Adds(n4);
            n2.Adds(n6);
            n2.Adds(n7);
            n3.Adds(n5);
            n7.Adds(n4);

            //czyszczenie listy i napisu zeby nie wywalic ramu
            odwiedzone.Clear();
            napis = "";
            DFS(n1);
            MessageBox.Show(napis);

        }
        void DFS(note2 w)
        {
            odwiedzone.Add(w);
            napis += w.wartosc.ToString() + " ";
            foreach (var sasiad in w.sasiad)
            {
                if (!odwiedzone.Contains(sasiad))
                {
                    DFS(sasiad);
                }
            }

        }

        public class note2
        {
            public int wartosc;
            public List<note2> sasiad = new List<note2>();
            public note2(int wartosc)
            {
                this.wartosc = wartosc;
            }
            public bool Adds(note2 s)
            {
                if (this == s)
                {
                    return false;
                }
                bool wynik = false;

                if ((!this.sasiad.Contains(s)))
                {
                    this.sasiad.Add(s);
                    wynik = true;
                }
                if ((!s.sasiad.Contains(this)))
                {
                    s.sasiad.Add(this);
                    wynik = true;
                }
                return wynik;

            }
        }
    }
}
