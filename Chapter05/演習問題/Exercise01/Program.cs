namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            YearMonth ym1 = new YearMonth(2025, 5);

            Console.WriteLine("元の年月");
            Console.WriteLine($"{ym1.Year}年{ym1.Month}月");

            YearMonth ym2 = ym1.AddOneMonth();

            Console.WriteLine("1か月後");
            Console.WriteLine($"{ym2.Year}年{ym2.Month}月");
        }

    }
}
