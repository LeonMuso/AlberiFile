namespace AlberiFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TreeNode<string> albero = TreeNode<string>.AlberoDaFile();
            albero.StampaAlbero(albero, 0);
            if (albero.FileDaAlbero(albero))
            {
                Console.WriteLine("funziona yippie");
            }
            TreeNode<string> albero2 = TreeNode<string>.AlberoDaFile2();
            albero2.StampaAlbero(albero2, 0);
            
            if (albero2.FileDaAlbero2(albero2))
            {
                Console.WriteLine("funziona yippie");
            }
        }
    }
}
