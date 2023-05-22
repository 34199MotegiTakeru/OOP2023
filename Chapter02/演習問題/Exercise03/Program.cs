using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03 {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("**売上集計**");
            Console.WriteLine("１：店舗別売上");
            Console.WriteLine("２：商品カテゴリー別売上");
            Console.Write(">");
            int senntaku = int.Parse(Console.ReadLine());
            var sales = new SalesCounter(@"data\sales.csv");
            if (senntaku == 1) {
                Console.WriteLine("**店舗別売上**");
                var amountPerStore = sales.GetPerStoreSales();
                foreach (var obj in amountPerStore) {
                    Console.WriteLine("{0}  {1:C}", obj.Key, obj.Value);
                }
            }
            else {
                Console.WriteLine("**商品カテゴリー別売上**");
                var amountPerStore = sales.GetPerCategorySales();
                foreach (var obj in amountPerStore) {
                    Console.WriteLine("{0}  {1:C}", obj.Key, obj.Value);
                }
            }
        }
    }
}
