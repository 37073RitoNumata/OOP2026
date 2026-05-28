
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
            var num = Console.ReadLine();
            if (int.TryParse(num, out var result)) {

                if (result < 0 || 500 <= result) {
                    Console.WriteLine(result);
                } else if (result < 100) {
                    Console.WriteLine(result * 2);
                } else if (result < 500) {
                    Console.WriteLine(result * 3);
                }
            } else {
                Console.WriteLine("入力値に誤りがあります");
            }
        }

        private static void Exercise2() {
            //switch文を使用
            var num = Console.ReadLine();
            if (int.TryParse(num, out var result)) {

                switch (result) {
                    case < 0:
                        Console.WriteLine(result);
                        break;
                    case < 100:
                        Console.WriteLine(result * 2);
                        break;

                    case < 500:
                        Console.WriteLine(result * 3);
                        break;

                    case >= 500:
                        Console.WriteLine(result);
                        break;
                }
            } else {
                Console.WriteLine("入力値に誤りがあります");
            }
        }

        private static void Exercise3() {
            //switch式を使用
            var num = Console.ReadLine();
            if (int.TryParse(num, out var result)) {
                var siki = result switch {
                    < 0 => result,
                    < 100 => result * 2,
                    < 500 => result * 3,
                    _ => result
                };
            } else {
                Console.WriteLine("入力値に誤りがあります");
            }
        }
    }
}
