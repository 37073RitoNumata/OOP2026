namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            var numbers = new List<int> { 9, 7, 5, 4, 2, 5, 4, 0, 4, 1, 0, 4 };

            var books = Books.GetBooks();
            var priceAverage = books.Average(x => x.Price);
            var pageSum = books.Sum(x => x.Pages);
            var maxPrice = books.Max(x => x.Price);

            Console.WriteLine("平均金額：" + priceAverage);
            Console.WriteLine("合計ページ：" + pageSum);
            Console.WriteLine("高価な本:" + maxPrice);

            Console.WriteLine("--- 500円以上の本 ---");
            var fivePrices = books.Where(x => x.Price >= 500);
            foreach(var fivePrice in fivePrices) {
                Console.WriteLine(fivePrice.Title);
            }

            Console.WriteLine("--- 250ページ以上の本 ---");
            var twefivePages = books.Where(x => x.Pages >= 250).Take(3);
            foreach (var twefivePage in twefivePages) {
                Console.WriteLine(twefivePage.Title);
            }

        }
    }
}
