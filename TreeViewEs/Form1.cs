using System.ComponentModel.Design.Serialization;
using Tree.Library;
namespace TreeViewEs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static void TreeViewFile1(TreeNode<string> nodo, TreeNodeCollection nodoWF)
        {
            if (nodo == null) return;
            var nuovoNodo = new TreeNode(nodo.Value);
            nodoWF.Add(nuovoNodo);
            foreach (var node in nodo.Nodes)
            {
                TreeViewFile1(node, nuovoNodo.Nodes);
            }
        }

        public static void TreeViewFile2(string percorso, TreeView treeView)
        {
            string[] righe = File.ReadAllLines(percorso);
            treeView.Nodes.Clear();
            List<TreeNode> livelli = new();
            foreach (string r in righe)
            {
                int livello = 0;
                while (livello < r.Length && r[livello] == '-')
                {
                    livello++;
                }
                string valore = r.Substring(livello).Trim();
                var nuovoNodo = new TreeNode(valore);
                if (livello == 0)
                {
                    treeView.Nodes.Add(nuovoNodo);
                }
                else
                {
                    var padre = livelli[livello - 1];
                    padre.Nodes.Add(nuovoNodo);
                }
                if (livello < livelli.Count)
                {
                    livelli[livello] = nuovoNodo;
                }
                else
                {
                    livelli.Add(nuovoNodo);
                }
            }
            treeView.ExpandAll();
        }

        private void btnCaricaFile1_Click(object sender, EventArgs e)
        {
            TreeNode<string> radice = TreeNode<string>.AlberoDaFile();
            treeView1.Nodes.Clear();
            TreeViewFile1(radice, treeView1.Nodes);
            treeView1.ExpandAll();
            lblCaricamento.Text = "Caricamento con successo";
        }

        private void btnCaricaFile2_Click(object sender, EventArgs e)
        {
            TreeViewFile2("AlberoFile2.txt", treeView1);
        }

        private void btnPulisciAlbero_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            lblCaricamento.Text = "";
        }
    }
}
