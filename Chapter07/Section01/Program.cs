using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    class Program {
        static void Main(string[] args) {

            var kenntyou = new Dictionary<string, CityInfo>();

            string city;
            int population;

            Console.Write("県名：");
            var ken = Console.ReadLine();
            while (ken != "999") {
                if (kenntyou.ContainsKey(ken)) {
                    Console.WriteLine("上書きしますか？y/n");
                    var yn = Console.ReadLine();
                    if (yn == "y") {
                        Console.Write("所在地：");
                        city = Console.ReadLine();
                        Console.Write("人口：");
                        population = int.Parse(Console.ReadLine());
                        //登録処理
                        kenntyou[ken] = new CityInfo {
                            City = city,
                            Population = population,
                        };
                    }
                }
                else {
                    Console.Write("所在地：");
                    city = Console.ReadLine();
                    Console.Write("人口：");
                    population = int.Parse(Console.ReadLine());
                    //登録処理
                    kenntyou[ken] = new CityInfo {
                        City = city,
                        Population = population,
                    };
                }
                Console.Write("県名：");
                ken = Console.ReadLine();
            }
            

            Console.WriteLine("１：一覧表示 , ２：県名指定");
            var hyouzi = int.Parse(Console.ReadLine());
            if(hyouzi == 1) {
                //一覧表示処理(人口高い順)
                foreach (var item in kenntyou.OrderByDescending(p => p.Value.Population)) {
                    Console.WriteLine("{0}({1} 【人口：{2}人】)", item.Key, item.Value.City,item.Value.Population);
                }
            }
            else {
                //県名指定処理
                Console.Write("県名を入力：");
                ken = Console.ReadLine();
                Console.WriteLine("{0}の県庁所在地は{1}、人口は{2}人", ken, kenntyou[ken].City,kenntyou[ken].Population);
            }
        }

        class CityInfo{
            public string City { get; set; }//都市
            public int Population { get; set; }//人口
        }
    }
}



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
