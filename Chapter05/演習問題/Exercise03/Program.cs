using Exercise01;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;

namespace Exercise03 {
    internal class Program {
        static void Main(string[] args) {
            var ym = new YearMonth[] {
                new YearMonth(2024, 12),
                new YearMonth(2024, 12),
            };

            if (ym[0] == ym[1]) {
                Console.WriteLine("等しい");
            }
        }
        

    }
}
