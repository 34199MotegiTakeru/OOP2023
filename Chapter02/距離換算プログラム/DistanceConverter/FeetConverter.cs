using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceConverter {
    //フィートとメートルの単位変換クラス
    public static class FeetConverter {

        //フィートからメートルを求める
        public static double FromMeter(double feet) {
            return feet * 0.3048;
        }

        //メートルからフィートを求める
        public static double ToMeter(double meter) {
            return meter / 0.3048;
        }
    }
}
