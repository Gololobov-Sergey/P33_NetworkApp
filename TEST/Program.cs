namespace TEST
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TEST tEST = null;
            Console.WriteLine(tEST.isTest);
        }
    }

    class TEST
    {
        public bool isTest { get; set; } = true;
    }
}
