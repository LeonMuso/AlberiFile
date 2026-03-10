using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree.Library
{
    public class Grafo<T>
    {
        public T Value { get; set; }
        public List<Grafo<T>> Nodes { get; set; } = new List<Grafo<T>>();
        public Grafo(T value)
        {
            Value = value;
        }

        public static Grafo<T> GrafoDaFile()
        {
            List<Grafo<T>> tuttiINodi = new List<Grafo<T>>();
            Grafo<T> nodo = null;

            string[] righe = File.ReadAllLines("GrafoFile.txt");

            foreach (var r in righe)
            {
                string[] parti = r.Split(' ');
                T valNodoDaAggiungere = (T)Convert.ChangeType(parti[0].Trim(), typeof(T));
                T valNodoACuiCollegare = (T)Convert.ChangeType(parti[1].Trim(), typeof(T));

                Grafo<T> nodoCollegamento = CercaNodo(tuttiINodi, valNodoACuiCollegare);
                if (nodoCollegamento == null)
                {
                    nodoCollegamento = new Grafo<T>(valNodoACuiCollegare);
                    tuttiINodi.Add(nodoCollegamento);
                }

                Grafo<T> nodoDaCollegare = CercaNodo(tuttiINodi, valNodoDaAggiungere);
                if (nodoDaCollegare == null)
                {
                    nodoDaCollegare = new Grafo<T>(valNodoDaAggiungere);
                    tuttiINodi.Add(nodoDaCollegare);
                }

                if (valNodoDaAggiungere.Equals(valNodoACuiCollegare) && nodo == null)
                {
                    nodo = nodoCollegamento;
                }
                else if (!nodoCollegamento.Nodes.Contains(nodoDaCollegare))
                {
                    nodoCollegamento.Nodes.Add(nodoDaCollegare);
                }
            }
            return nodo;
        }
        public static Grafo<T> CercaNodo(List<Grafo<T>> lista, T valore)
        {
            foreach (var nodo in lista)
            {
                if (EqualityComparer<T>.Default.Equals(nodo.Value, valore))
                    return nodo;
            }
            return null;
        }

        public void StampaGrafo()
        {
            var visited = new HashSet<Grafo<T>>();
            var queue = new Queue<Grafo<T>>();
            queue.Enqueue(this);
            visited.Add(this);

            Console.WriteLine("--- Struttura del Grafo ---");

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                Console.WriteLine($"{current.Value}");


                foreach (var neighbor in current.Nodes)
                {
                    if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        queue.Enqueue(neighbor);
                    }
                }
            }
        }

        public bool BFS_Mangiare(List<string> luoghiCibo, out string trovato, out HashSet<Grafo<T>> visitati)
        {
            var visited = new HashSet<Grafo<T>>();
            var queue = new Queue<Grafo<T>>();
            var visited2 = new HashSet<Grafo<T>>();

            queue.Enqueue(this);
            visited.Add(this);
            visited2.Add(this);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                visited2.Add(current);

                if (luoghiCibo.Contains(current.Value.ToString()))
                {
                    visitati = visited2;
                    trovato = current.Value.ToString();
                    return true;
                }

                foreach (var neighbor in current.Nodes)
                {
                    if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        queue.Enqueue(neighbor);
                    }
                }
            }
            visitati = visited2;
            trovato = null;
            return false;
        }
        public bool DFS_Mangiare(List<string> luoghiCibo, HashSet<Grafo<T>> visited)
        {
            if (visited.Contains(this))
            {
                return false;
            }

            Console.WriteLine("Visitato: " + this.Value);
            visited.Add(this);

            if (luoghiCibo.Contains(this.Value.ToString()))
            {
                Console.WriteLine("Puoi mangiare da: " + this.Value);
                return true;
            }

            foreach (var neighbor in Nodes)
            {
                if (neighbor.DFS_Mangiare(luoghiCibo, visited)) return true;
            }
            return false;
        }
    }
}
