namespace Section02 {
    internal class Program {
        static void Main(string[] args) {

            Dosomething(100);
                    }

        public static void Dosomething(int num, string message= "エラー", int retryCount = 5) {
            //仮のコード
            Console.WriteLine($"{num} {message} {retryCount}");
        }
    }
}
