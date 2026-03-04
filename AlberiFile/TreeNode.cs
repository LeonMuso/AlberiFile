using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlberiFile
{
    internal class TreeNode<T>
    {
        public T Value { get; set; }
        public List<TreeNode<T>> Nodes { get; set; } = new List<TreeNode<T>>();
        public TreeNode(T value)
        {
            Value = value;
        }
        public void StampaAlbero(TreeNode<T> node)
        {
            Console.WriteLine(node.Value);
            foreach (var nodes in node.Nodes)
            {
                StampaAlbero(nodes);
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
            string[] righe = File.ReadAllLines("C:\\Users\\pinos\\OneDrive\\Desktop\\AlberoFile.txt");
            foreach (var r in righe)
            {
                string[] parti = r.Split(' ');
                string child = parti[0];
                string father = parti[1];

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
                File.AppendAllText("C:\\Users\\pinos\\OneDrive\\Desktop\\FileAlbero.txt", $"{n.Value} {root.Value}\n");
                FileDaAlbero(n);
            }
            return true;
        }

        public static TreeNode<T> AlberoDaFile2()
        {

        }
    }
}
