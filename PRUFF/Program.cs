namespace PRUFF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Coding code = new Coding();
            code.Action(9);
            Decoding dec = new Decoding();
            dec.Action(8);
            Console.ReadKey();
        }
    }
}