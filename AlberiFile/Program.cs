namespace AlberiFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TreeNode<string> albero = TreeNode<string>.AlberoDaFile();
            albero.StampaAlbero(albero);
        }
    }
}
