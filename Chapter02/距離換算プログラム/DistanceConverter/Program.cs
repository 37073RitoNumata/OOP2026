

namespace DistanceConverter {
    internal class Program {
        static void Main(string[] args) {

            int.TryParse(args[1], out int x);
            int.TryParse(args[2], out int y);

            if (args.Length >= 3 && args[0] == "-tom") {
                PrintFeetToMeterList(x, y);

            } else if (args.Length >= 3 && args[0] == "-tof") {
                PrintMeterToFeetList(x, y);

            } else {
                Console.WriteLine("引数エラー");
            }

            for (int i = 0; i < args.Length; i++) {
                Console.WriteLine(args[i]);

            }
        }


        static void PrintFeetToMeterList(int start, int stop) {
            //フィートからメートルへの対応表を出力
            for (int feet = start; feet <= stop; feet++) {
                double meter = FeetToMeter(feet);
                Console.WriteLine($"{feet}ft = {meter:0.0000}m");
            }
        }
        private static void PrintMeterToFeetList(int start, int stop) {

            //メートルからフィートへの対応表を出力
            for (int meter = start; meter <= stop; meter++) {
                double feet = MeterToFeet(meter);
                Console.WriteLine($"{meter}m = {feet:0.0000}ft");
            }
        }
        //フィートからメートルを求める
        static double FeetToMeter(int feet) {
            return feet * 0.3048;
        }

        //メートルからフィートを求める
        static double MeterToFeet(int meter) {
            return meter / 0.3048;
        }
    }

}

