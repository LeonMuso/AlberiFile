using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace Tree.Library
{
    public class TreeNode<T>
    {
        public T Value { get; set; }
        public List<TreeNode<T>> Nodes { get; set; } = new List<TreeNode<T>>();
        public TreeNode(T value)
        {
            Value = value;
        }
        public void StampaAlbero(TreeNode<T> node, int level)
        {
            Console.WriteLine(new string('-', level) + node.Value);
            foreach (var nodes in node.Nodes)
            {
                StampaAlbero(nodes, level + 1);
            }
        }
        public static TreeNode<T> CercaNodo(TreeNode<T> node, T value)
        {
            if (EqualityComparer<T>.Default.Equals(node.Value, value))
            {
                return node;
            }
            foreach (var n in node.Nodes)
            {
                var nodoTrovato = CercaNodo(n, value);
                if (nodoTrovato != null) return nodoTrovato;
            }
            return null;
        }

        public static TreeNode<T> AlberoDaFile()
        {
            TreeNode<T> root = null;
            string[] righe = File.ReadAllLines("AlberoFile.txt");
            foreach (var r in righe)
            {
                string[] parti = r.Split(' ');
                string child = parti[0].Trim();
                string father = parti[1].Trim();

                if (father == child)
                {
                    root = new TreeNode<T>((T)Convert.ChangeType(father, typeof(T)));
                    continue;
                }
                if (root != null)
                {
                    TreeNode<T> nodoPadre = CercaNodo(root, (T)Convert.ChangeType(father, typeof(T)));
                    if (nodoPadre != null)
                    {
                        nodoPadre.Nodes.Add(new TreeNode<T>((T)Convert.ChangeType(child, typeof(T))));
                    }
                }
            }
            return root;
        }

        public bool FileDaAlbero(TreeNode<T> root)
        {
            if (root == null) return false;
            foreach (var n in root.Nodes)
            {
                File.AppendAllText("FileAlbero.txt", $"{n.Value} {root.Value}\n");
                FileDaAlbero(n);
            }
            return true;
        }

        public static TreeNode<T> AlberoDaFile2()
        {
            string[] righe = File.ReadAllLines("AlberoFile2.txt");
            string valoreRadice = righe[0].Trim();
            TreeNode<T> root = new TreeNode<T>((T)Convert.ChangeType(valoreRadice, typeof(T)));

            List<TreeNode<T>> ultimiNodiPerLivello = new List<TreeNode<T>>();
            ultimiNodiPerLivello.Add(root);

            foreach (var r in righe)
            {

                int livello = 0;
                while (livello < r.Length && r[livello] == '-')
                {
                    livello++;
                }

                string valore = r.Substring(livello).Trim();
                TreeNode<T> nodo = new TreeNode<T>((T)Convert.ChangeType(valore, typeof(T)));

                if (livello > 0 && livello <= ultimiNodiPerLivello.Count)
                {
                    TreeNode<T> padre = ultimiNodiPerLivello[livello - 1];
                    padre.Nodes.Add(nodo);

                    if (livello < ultimiNodiPerLivello.Count)
                    {
                        ultimiNodiPerLivello[livello] = nodo;
                    }
                    else
                    {
                        ultimiNodiPerLivello.Add(nodo);
                    }
                }
            }
            return root;
        }

        public bool FileDaAlbero2(TreeNode<T> root)
        {
            if (root == null) return false;
            List<string> righe = new List<string>();
            CreaLivelli(root, 0, righe);
            File.WriteAllLines("FileAlbero2.txt", righe);
            return true;
        }
        public void CreaLivelli(TreeNode<T> nodo, int livello, List<string> righe)
        {
            if (nodo == null) return;
            string trattini = new string('-', livello);
            righe.Add(trattini + nodo.Value.ToString());
            foreach (var n in nodo.Nodes)
            {
                CreaLivelli(n, livello + 1, righe);
            }
        }
    }
}
