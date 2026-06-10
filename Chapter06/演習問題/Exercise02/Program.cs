namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {

            bool Bool = int.TryParse(Console.ReadLine(), out int num);

            if (Bool) {
                Console.WriteLine($"{num:#,0}");
            } else {
                Console.WriteLine("変換できません");
            }
        }
    }
}
