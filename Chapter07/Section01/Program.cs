using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    class Program {
        static void Main(string[] args) {

            var kenntyou = new Dictionary<string, string>();
            Console.Write("県名：");
            var ken = Console.ReadLine();
            while (ken != "999") {
                if (kenntyou.ContainsKey(ken)) {
                    Console.WriteLine("上書きしますか？y/n");
                    var yn = Console.ReadLine();
                    if (yn == "y") {
                        Console.Write("所在地：");
                        var si = Console.ReadLine();
                        kenntyou[ken] = si;
                    }
                }
                else {
                    Console.Write("所在地：");
                    var si = Console.ReadLine();
                    kenntyou[ken] = si;
                }
                Console.Write("県名：");
                ken = Console.ReadLine();
            }


            Console.Write("県名を入力：");
            ken = Console.ReadLine();
            Console.WriteLine("{0}の県庁所在地は{1}", ken, kenntyou[ken]);










        //    var flowerDict = new Dictionary<string, int>() {
        //        ["sunflower"] = 400,
        //        ["pansy"] = 300,
        //        ["tulip"] = 350,
        //        ["rose"] = 500,
        //        ["dahlia"] = 450,
        //};

        //    //morning glory(あさがお) 250円を追加
        //    flowerDict["morning glory"] = 250;

        //    Console.WriteLine("ひまわりの価格は{0}円です", flowerDict["sunflower"]);
        //    Console.WriteLine("チューリップの価格は{0}円です", flowerDict["tulip"]);
        //    Console.WriteLine("あさがおの価格は{0}円です",flowerDict["morning glory"]);


        }
    }
}
