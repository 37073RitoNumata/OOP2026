namespace Section01 {
    internal class Program {

        static void Main(string[] args) {

            var numbers = new[] { 5, 3, 9, 6, 7, 5, 8, 1, 0, 10, 4 };

            //Judgement judge = IsEven;

            var count = Count(numbers, n => n % 4 == 0 || n % 5 == 0);
            Console.WriteLine(count);
        }

        static int Count(int[] numbers, Predicate<int> judge) {
            var count = 0;
            foreach (var n in numbers) {
                if (judge(n) == true) {
                    count++;
                }
            }
            return count;
        }
    }

}
