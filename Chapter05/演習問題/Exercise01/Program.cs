using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    class Program {
        static void Main(string[] args) {
            Console.Write("文字列１：");
            var s1 = Console.ReadLine();
            Console.Write("文字列２：");
            var s2 = Console.ReadLine();
            var cultureInfo = new CultureInfo("ja-JP");
            if (string.Compare(s1, s2,ignoreCase:true) == 0) {
                Console.WriteLine("一致しています");
            }
            else {
                Console.WriteLine("一致していません");
            }
        }
    }
}
