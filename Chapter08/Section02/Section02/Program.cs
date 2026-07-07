namespace Section02 {
    internal class Program {
        static void Main(string[] args) {
            var lines = File.ReadAllLines("sample.txt");
            var we = new WordsExtractor(lines);
        }
    }
}
