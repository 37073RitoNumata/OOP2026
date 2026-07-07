
namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            var text = "Cozy lummox gives smart squid who asks for job pen";

            Console.WriteLine("問題8.1.1");
            Exercise1(text);
            Console.WriteLine();
            Console.WriteLine("問題8.1.2");
            Exercise2(text);

        }

        private static void Exercise1(string text) {

            var dict = new Dictionary<char, int>();
            var replaced = text.Replace(" ", "");
            Console.WriteLine(replaced);

            foreach (var ch in text.ToUpper()) {
                if ('A' <= ch && ch <= 'Z') {
                    if (dict.ContainsKey(ch))
                        dict[ch]++;
                    else
                        dict[ch] = 1;
                }
            }
            //foreach (char c in replaced) {
            //    for (char key = 'A'; key <= 'Z'; key++) {
            //        if ('A' <= c && c <= 'Z') {
            //            //dict[] ++;
            //        }
            //    }
            //}
        }

        private static void Exercise2(string text) {
            //コミットのコメント（問題8.1.2完成）
            var dict = new SortedDictionary<char, int>();

            foreach (var ch in text.ToUpper()) {
                if ('A' <= ch && ch <= 'Z') {
                    if (dict.ContainsKey(ch))
                        dict[ch]++;
                    else
                        dict[ch] = 1;
                }
            }

            foreach (var item in dict) {
                Console.WriteLine("{0}:{1}", item.Key, item.Value);
            }
        }
    }
}
