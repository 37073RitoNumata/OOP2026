namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            bool Bool = int.TryParse(Console.ReadLine(), out int num);

            var str = num.ToString("#,0");

            Console.WriteLine(str);
        }
    }
}
