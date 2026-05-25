
namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            List<string> langs = [
          "C#", "Java", "Ruby", "PHP", "Python", "TypeScript",
                "JavaScript", "Swift", "Go",
            ];

            Exercise1(langs);
            Console.WriteLine("---");
            Exercise2(langs);
            Console.WriteLine("---");
            Exercise3(langs);
        }

        private static void Exercise1(List<string> langs) {
            Console.WriteLine("--- 4.1.1 ---");
            //foreach文
            Console.WriteLine("foreach文で出力");
            var fore = langs.Where(s => s.Contains('S'));
            foreach (var s in fore) {
                Console.WriteLine(s);
            }


            //for文
            Console.WriteLine("for文で出力");


            //while文
            Console.WriteLine("while文で出力");
        }

        private static void Exercise2(List<string> langs) {
            Console.WriteLine("--- 4.1.2 ---");
            //LINQを使用する(Where)
        }

        private static void Exercise3(List<string> langs) {
            Console.WriteLine("--- 4.1.3 ---");
            //throw new NotImplementedException();
        }
    }
}
