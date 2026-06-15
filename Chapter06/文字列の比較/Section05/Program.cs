using System.Text;

namespace Section05 {
    internal class Program {
        static void Main(string[] args) {

            var result = String.Join(",", GetWords());
            Console.WriteLine(result);
        }

        private static IEnumerable<object> GetWords() {
            return ["Orenge", "Lemon", "Strawberry"];
        }
    }
}
