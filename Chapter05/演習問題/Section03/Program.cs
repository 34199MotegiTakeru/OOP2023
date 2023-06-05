using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03 {
    class Program {
        static void Main(string[] args) {
            var text = "Jackdaws love my big sphinx of quartz";

            Exercise3_1(text);
            Console.WriteLine("-----");

            Exercise3_2(text);
            Console.WriteLine("-----");

            Exercise3_3(text);
            Console.WriteLine("-----");

            Exercise3_4(text);
            Console.WriteLine("-----");

            Exercise3_5(text);
            //{\rtf1}
        }

        private static void Exercise3_1(string text) {
            int target = text.Count(c => c == ' ');
            Console.WriteLine(target);
        }

        private static void Exercise3_2(string text) {
            var replaced = text.Replace("big", "small");
            Console.WriteLine(replaced);
        }

        private static void Exercise3_3(string text) {
            var tango = text.Split(' ').Length;
            Console.WriteLine(tango);
        }

        private static void Exercise3_4(string text) {
            var ika = text.Split(' ').Where(n => n.Length <= 4);
            foreach (var item in ika) {
                Console.WriteLine(item);
            }
        }

        private static void Exercise3_5(string text) {
            var array = text.Split(' ').ToArray();
            if(array.Length > 0) {
                var sb = new StringBuilder();
                sb.Append(array[0]);
                foreach (var item in array.Skip(1)) {
                    sb.Append(' ');
                    sb.Append(item);
                }
                var createWords = sb.ToString();
                Console.WriteLine(createWords);
            }
            
        }
    }
}
