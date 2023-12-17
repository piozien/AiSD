
using BST_by_cw_29._11;

namespace BST_by_cw_29._11
{
    public partial class Form1 : Form
    {
        private Wêze³3 korzeñ;

        public Form1()
        {
            InitializeComponent();
        }

        private void StartBST_Click(object sender, EventArgs e)
        {
            var w1 = new Wêze³3(8);
            w2.Add()


        }
    }
    class Wêze³3
    {
        public int wartoœæ;
        public Wêze³3 rodzic;
        public Wêze³3 leweDziecko;
        public Wêze³3 praweDziecko;

        public Wêze³3(int wartoœæ)
        {
            this.wartoœæ = wartoœæ;
        }

        public override string ToString()
        {
            return base.ToString();
        }
        //mo¿na spróbowaæ TreeView w form1;

        internal void Add(int liczba)
        {
            var dziecko = new Wêze³3(liczba);
            dziecko.rodzic = this;
            if (liczba < this.wartoœæ)
            {
                this.leweDziecko = dziecko;
            }
            else
            {
                this.praweDziecko = dziecko;
            }
        }

    }

    class drzewoBinarne
    {
        public Wêze³3 korzeñ;
        public int liczbaWêz³ów = 0;

        void Add(int liczba)
        {
            var rodzic = this.znajdŸRodzica(liczba);
            rodzic.Add(liczba);
        }

        private Wêze³3 znajdŸRodzica(int liczba)
        {
            var w = this.korzeñ;
            while (true)
            {
                if (liczba < w.wartoœæ)
                {
                    if (w.leweDziecko != null)
                    {
                        w = w.leweDziecko;
                    }
                    else
                    {
                        return w;
                    }

                }
                else
                {
                    if (w.leweDziecko != null)
                    {
                        w = w.praweDziecko;
                    }
                    else
                    {
                        return w;
                    }
                }
            }

        }
    }
}
    
        