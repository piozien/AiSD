
using BST_by_cw_29._11;

namespace BST_by_cw_29._11
{
    public partial class Form1 : Form
    {
        private W�ze�3 korze�;

        public Form1()
        {
            InitializeComponent();
        }

        private void StartBST_Click(object sender, EventArgs e)
        {
            var w1 = new W�ze�3(8);
            w2.Add()


        }
    }
    class W�ze�3
    {
        public int warto��;
        public W�ze�3 rodzic;
        public W�ze�3 leweDziecko;
        public W�ze�3 praweDziecko;

        public W�ze�3(int warto��)
        {
            this.warto�� = warto��;
        }

        public override string ToString()
        {
            return base.ToString();
        }
        //mo�na spr�bowa� TreeView w form1;

        internal void Add(int liczba)
        {
            var dziecko = new W�ze�3(liczba);
            dziecko.rodzic = this;
            if (liczba < this.warto��)
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
        public W�ze�3 korze�;
        public int liczbaW�z��w = 0;

        void Add(int liczba)
        {
            var rodzic = this.znajd�Rodzica(liczba);
            rodzic.Add(liczba);
        }

        private W�ze�3 znajd�Rodzica(int liczba)
        {
            var w = this.korze�;
            while (true)
            {
                if (liczba < w.warto��)
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
    
        