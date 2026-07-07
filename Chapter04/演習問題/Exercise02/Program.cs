
namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine(" --- 4.2.1 ---");
            Exercise1();
            Console.WriteLine("\n --- 4.2.2 ---");
            Exercise2();
            Console.WriteLine("\n --- 4.2.3 ---");
            Exercise3();
        }

        private static void Exercise1() {
            //if-else文を使用
            int num = int.Parse(Console.ReadLine());
            if (num < 0) {
                Console.WriteLine(num);
            } else if (num <100) {
                Console.WriteLine(num * 2);
            } else if (num < 500) {
                Console.WriteLine(num * 3);
            } else {
                Console.WriteLine(num);
            }
        }

        private static void Exercise2() {
            //switch文を使用

        }

        private static void Exercise3() {
            //switch式を使用


        }
    }
}
