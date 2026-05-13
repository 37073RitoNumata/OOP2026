
namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            PrintInchToMeterList(1, 10);
            PrintMeterToInchList(1, 10);
        }

        //インチからメートルへの対応表を出力
        static void PrintInchToMeterList(int start, int end) {
            for (int inch = start; inch <= end; inch++) {
                double meter = InchConverter.ToMeter(inch);
                Console.WriteLine($"{inch}inch = {meter:0.0000}m");
            }
        }

        //メートルからインチへの対応表を出力
        static void PrintMeterToInchList(int start, int end) {
            for (int meter = start; meter <= end; meter++) {
                double inch = InchConverter.FromMeter(meter);
                Console.WriteLine($"{meter}m = {inch:0.0000}inch");
            }
        }
    }
}
