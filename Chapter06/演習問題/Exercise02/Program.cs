namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {

            if (int.TryParse(Console.ReadLine(), out int num)) {
                Console.WriteLine($"{num:#,0}");
            } else {
                Console.WriteLine("変換できません");
            }
        }
    }
}
