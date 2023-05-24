using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    class Program {
        static void Main(string[] args) {
            var names = new List<string> {
                 "Tokyo", "New Delhi", "Bangkok", "London", "Paris", "Berlin", "Canberra", "Hong Kong",
            };
            Exercise2_1(names);
            Console.WriteLine("---------");
            Exercise2_2(names);
            Console.WriteLine("---------");
            Exercise2_3(names);
            Console.WriteLine("---------");
            Exercise2_4(names);
        }

        private static void Exercise2_1(List<string> names) {
            Console.WriteLine("都市名を入力。空行終了");
            do {
                var line = Console.ReadLine();
                if (line == "") {
                    break;
                }
                var tosi = names.FindIndex(n => line == n);
                Console.WriteLine(tosi);
            } while (true);
        }

        private static void Exercise2_2(List<string> names) {
            var cnt = names.Count(n => n.ToString().Contains('o'));
            Console.WriteLine(cnt);
        }

        private static void Exercise2_3(List<string> names) {
            var cnt = names.Where(n => n.ToString().Contains('o'));
            foreach (var item in cnt) {
                Console.WriteLine(item);
            }
        }

        private static void Exercise2_4(List<string> names) {
            var cnt = names.Where(n => n[0] == 'B').Select(n => n);
            foreach (var item in cnt) {
                Console.WriteLine(item + item.Length);

            }
        }
    }
}
