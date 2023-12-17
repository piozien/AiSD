using System.IO.Pipes;

namespace Binarne_drzewo_przeszukiwań_BST
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var w1 = new Węzeł3(8);
            var drzewo = new drzewoBinarne(w1);
            drzewo.Add(3);
            drzewo.Add(10);
            drzewo.Add(14);
            drzewo.Add(13);
            drzewo.Add(1);
            drzewo.Add(6);
            drzewo.Add(7);
            drzewo.Add(4);
            var x = drzewo.następnik(drzewo.korzeń.praweDziecko.praweDziecko.leweDziecko);
        }



        class Węzeł3
        {
            public int wartość;
            public Węzeł3 rodzic;
            public Węzeł3 leweDziecko;
            public Węzeł3 praweDziecko;

            public Węzeł3(int wartość)
            {
                this.wartość = wartość;
            }

            internal void Add(int liczba)
            {
                var dziecko = new Węzeł3(liczba);
                dziecko.rodzic = this;
                if (liczba < this.wartość)
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
            public Węzeł3 korzeń;


            public drzewoBinarne(Węzeł3 korzeń)
            {
                this.korzeń = korzeń;
            }

            public void Add(int liczba)
            {
                var rodzic = this.znajdźRodzica(liczba);
                rodzic.Add(liczba);
            }

            private Węzeł3 znajdźRodzica(int liczba)
            {
                var w = this.korzeń;
                while (true)
                {
                    if (liczba < w.wartość)
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
                        if (w.praweDziecko != null)
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
            public Węzeł3 znajdź(int liczba)
            {
                var w = this.korzeń;
                if (w.wartość == liczba)
                {
                    return w;
                }
                while (true)
                {
                    if (liczba < w.wartość)
                    {
                        if (w.leweDziecko != null)
                        {
                            w = w.leweDziecko;
                            if (w.wartość == liczba)
                            {
                                return w;
                            }
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        if (w.praweDziecko != null)
                        {
                            w = w.praweDziecko;
                            if (w.wartość == liczba)
                            {
                                return w;
                            }

                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
            public Węzeł3 znajdźNajmniejszy(Węzeł3 w)
            {
                //wezeł 3 z najmniejsza wartoscia
                while (w.leweDziecko != null)
                {
                    w = w.leweDziecko;
                }
                return w;
            }
            public Węzeł3 znajdźNajwiększy(Węzeł3 w)
            {
                //wezeł3 z największą wartościa
                while (w.praweDziecko != null)
                {
                    w = w.praweDziecko;
                }
                return w;

            }
            public Węzeł3 następnik(Węzeł3 w)
            {
                //1: Jest prawe dziecko znajdź najmniejszy dla górnego dziecka
                //2: Idę w górę tak długo aż wyjdę jako lewe dziecko rodzica, następnik to rodzic
                //3: Gdy nie znajdę (2) i nie mogę iść do góry nie ma następnika
                if (w.praweDziecko != null)
                {
                    return znajdźNajmniejszy(w.praweDziecko);
                }
                if (w.rodzic == null) return null;

                while (w == w.rodzic.praweDziecko)
                {
                    w = w.rodzic;
                    if (w.rodzic == null) return null;
                }
                return w.rodzic;

            }
        }
    }
}

