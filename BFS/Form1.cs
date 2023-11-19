using System.Runtime.Intrinsics.X86;
using System.Windows.Forms;
using System.Collections.Generic;

namespace BFS
{
    public partial class Form1 : Form

    {
        string napis = "";
        int[] tab = new int[0];
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
            n1.Adds(n4);
            n1.Adds(n5);
            n2.Adds(n3);
            n3.Adds(n4);
            n5.Adds(n6);
            n5.Adds(n7);
            n6.Adds(n7);

            BFS(n1);
           

        }
        void BFS(note2 start)
        {
            Queue<note2> kolejka = new Queue<note2>();
            List<note2> usuniete = new List<note2>();
            usuniete.Add(start);
            string napis2 = "";

            kolejka.Enqueue(start);

            while (kolejka.Count > 0)
            {
                note2 aktualny = kolejka.Dequeue();
                napis2 += aktualny.wartosc;

                foreach (var sasiad in aktualny.sasiad)
                {
                    if (!usuniete.Contains(sasiad))
                    {
                        kolejka.Enqueue(sasiad);
                        usuniete.Add(sasiad);
                    }
                }
            }

            MessageBox.Show(napis2);
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
            if(this == s)
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
