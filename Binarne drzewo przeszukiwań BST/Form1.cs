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
            string tabs = tbInput.Text;
            int[] tab = convertInt(tabs);

            note3 root = BuildBST(tab);

            string napis = generujdrzewo(root, "");
            MessageBox.Show(napis);
        }
        private string generujdrzewo(note3 node, string prefix = "", bool isLeft = false)
        {
            if (node == null)
            {
                return "";
            }

            string napis = "";

            string side = isLeft ? "L" : "P";
            string nodeInfo = $"{prefix}Dodano: [{side}] {node.wartosc}\n";

            if (prefix == "")
            {
                napis += $"Korzeń {node.wartosc};\n";
            }
            else
            {
                napis += $"{prefix}{nodeInfo}";
            }

            if (node.leweDziecko != null || node.praweDziecko != null)
            {
                napis += generujdrzewo(node.leweDziecko, $"{prefix}Rodzic {node.wartosc};\n", true);
                napis += generujdrzewo(node.praweDziecko, $"{prefix}Rodzic {node.wartosc};\n", false);
            }

            return napis;
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
        public class note3
        {
            public int wartosc;
            public note3 leweDziecko;
            public note3 praweDziecko;
            public note3 rodzic;
            public note3(int wartosc)
            {
                this.wartosc = wartosc;
                leweDziecko = null;
                praweDziecko = null;
                rodzic = null;
            }
        }
        private note3 BuildBST(int[] values)
        {
            if (values == null || values.Length == 0)
            {
                return null;
            }

            var root = new note3(values[0]);

            for (int i = 1; i < values.Length; i++)
            {
                InsertIntoBST(root, values[i]);
            }

            return root;
        }

        private void InsertIntoBST(note3 root, int value)
        {
            var newNode = new note3(value);
            newNode.rodzic = root;

            if (value < root.wartosc)
            {
                if (root.leweDziecko == null)
                {
                    root.leweDziecko = newNode;
                }
                else
                {
                    InsertIntoBST(root.leweDziecko, value);
                }
            }
            else
            {
                if (root.praweDziecko == null)
                {
                    root.praweDziecko = newNode;
                }
                else
                {
                    InsertIntoBST(root.praweDziecko, value);
                }
            }
        }
    }
}

