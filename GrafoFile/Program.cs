using Tree.Library;
namespace GrafoFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Grafo<string> grafo = Grafo<string>.GrafoDaFile();
            grafo.StampaGrafo();
            Console.WriteLine();
            Console.WriteLine("BFS:");
            if (grafo.BFS_Mangiare(new List<string> { "Pizzeria", "Sushi", "Paninoteca" },
                    out string ristorante, out HashSet<Grafo<string>> visitati))
            {
                foreach (var visitatoGrafo in visitati)
                {
                    Console.WriteLine($"Visitato: {visitatoGrafo.Value}");
                }
                Console.WriteLine($"Puoi mangiare da: {ristorante}");
            }
            Console.WriteLine();
            Console.WriteLine("DFS:");
            grafo.DFS_Mangiare(new List<string> { "Pizzeria", "Sushi", "Paninoteca" }, new HashSet<Grafo<string>>());

        }
    }
}
