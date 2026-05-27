
using System.Linq;

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
            Console.WriteLine(" --- 4.1.1 ---");

            //foreach
            Console.WriteLine("\nforeach");
            var f0re = langs.Where(s => s.Contains('S'));
            foreach (var s in f0re) {
                Console.WriteLine(s);
            }



            //for
            Console.WriteLine("\nfor");
            for (int i = 0; i < langs.Count; i++) {
                if (langs[i].Contains('S')) {
                    Console.WriteLine(langs[i]);
                }
            }






            //while  
            Console.WriteLine("\nwhile");
            int count = 0;
            while (count < langs.Count) {
                if (langs[count].Contains('S')) {
                    Console.WriteLine(langs[count]);
                }
                count++;
            }
        }

        private static void Exercise2(List<string> langs) {
            Console.WriteLine("\n --- 4.1.2 ---");
            var selected = langs.Where(s => s.Contains('S'));
            foreach (var lang in selected) {
                Console.WriteLine(lang);
            }


        }

        private static void Exercise3(List<string> langs) {
            Console.WriteLine("\n --- 4.1.3 ---");
            Console.WriteLine(langs.Find(s => s.Length == 10) ?? "unknown");
        }

    }
}
