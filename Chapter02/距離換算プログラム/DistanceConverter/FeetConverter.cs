﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceConverter {
    //フィートとメートルの単位変換クラス
    public static class FeetConverter {

        //定数
        private const double ratio = 0.3048;

        //フィートからメートルを求める
        public static double FromMeter(double feet) {
            return feet * ratio;
        }

        //メートルからフィートを求める
        public static double ToMeter(double meter) {
            return meter / ratio;
        }
    }
}
