using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceConverter {
    public class FeetConverter {

        //メートルからフィートを求める
        public double ToMeter(int meter) {
            return meter * 0.3048;
        }
        //フィートからメートルを求める
        public double FromMeter(int feet) {
            return feet / 0.3048;
        }
    }
}
