using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceConverter {
    public static class FeetConverter {
        private static readonly double ratio = 0.3048; //定数

        //メートルからフィートを求める
        public static double ToMeter(int meter) {
            return meter * ratio;
        }
        //フィートからメートルを求める
        public static double FromMeter(int feet) {
            return feet / ratio;
        }
    }
}
