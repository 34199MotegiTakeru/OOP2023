using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleUnitConverter {
    //ポンド単位で表すクラス
    public class PoundUnit :DistanceUnit{
        private static List<PoundUnit> units = new List<PoundUnit> {
            new PoundUnit{Name="oz",Coefficient=1},
            new PoundUnit{Name="lbs",Coefficient=1 * 16},
        };
        public static ICollection<PoundUnit> Units { get { return units; } }

        /// <summary>
        /// メートル単位からポンド単位に変換します
        /// </summary>
        /// <param name="unit">メートル単位</param>
        /// <param name="value">値</param>
        /// <returns>ポンド単位</returns>
        /// 

        public double FromGramUnit(GramUnit unit, double value) {
            return (value * unit.Coefficient) / 28.35 / this.Coefficient;
        }
    }
}
