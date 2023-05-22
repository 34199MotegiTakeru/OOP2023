using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    //インチとメートルの単位変換クラス
    public static class InchConverter {

        //定数
        private const double ratio = 0.0254;

        //インチからメートルを求める
        public static double FromMeter(double feet) {
            return feet * ratio;
        }

        //インチからフィートを求める
        public static double ToMeter(double meter) {
            return meter / ratio;
        }
    }
}
