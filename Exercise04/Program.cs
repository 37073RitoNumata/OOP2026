using static System.Net.Mime.MediaTypeNames;

namespace Exercise04 {
    internal class Program {
        static void Main(string[] args) {
            var line = "Novelist=谷崎潤一郎;BestWork=春琴抄;Born=1886";

            var words = line.Split(';', '=');

            for (int i = 0; i < words.Length; i++) {
                if (i % 2 == 0) {
                    words[i] = ToJapanese(words[i]);
                    Console.Write(words[i]+':');
                } else {
                    Console.WriteLine(words[i]);
                }
            }

        }
        static string ToJapanese(string key) {
            return key switch {
                "Novelist" => "作家",
                "BestWork" => "代表作",
                "Born" => "誕生年",
                _ => "引数keyは、正しい値ではありません"
            };
        }
    }
}
