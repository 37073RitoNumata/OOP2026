namespace Sample0413
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("表示回数：");

            string? inputNum = Console.ReadLine();

            int count = int.Parse(inputNum); //整数へ変換

            int i = 0;

            while (i < count)
            {
                if ((i + 1) % 2 == 0)
                {
                    Console.Write((i + 1) + ":");
                    Console.WriteLine("Hello, World!");
                }

                i++;

            }
        }
    }
}
