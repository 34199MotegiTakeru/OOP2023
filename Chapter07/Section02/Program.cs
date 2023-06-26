using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section02 {
    class Program {
        static void Main(string[] args) {

            //var CityInfo = new Dictionary<string, int>();
            var kenntyou = new Dictionary<string,List<CityInfo>>();

            string city;
            int population;

            Console.WriteLine("都市の登録");
            Console.Write("県名：");
            var ken = Console.ReadLine();
            while (ken != "999") {
                Console.Write("都市：");
                city = Console.ReadLine();
                Console.Write("人口：");
                population = int.Parse(Console.ReadLine());
                var cityinfo = new CityInfo {
                    City = city,
                    Population = population,
                };
                if (kenntyou.ContainsKey(ken)) {
                    //List<CityInfo>が存在するためaddで市町村を追加
                    //登録処理
                    kenntyou[ken].Add(cityinfo);
                }
                else {
                    //List<CityInfo>が存在しないため、Listを作成して市町村を追加
                    //登録処理
                    kenntyou[ken] = new List<CityInfo> { cityinfo };
                }
                Console.Write("県名：");
                ken = Console.ReadLine();
            }


            Console.WriteLine("１：一覧表示 , ２：県名指定");
            var hyouzi = int.Parse(Console.ReadLine());
            if (hyouzi == 1) {
                //一覧表示処理(人口高い順)
                foreach (var item in kenntyou) {
                    foreach (var term in item.Value) {
                        Console.WriteLine("{0}({1} 【人口：{2}人】)", item.Key, term.City,term.Population);

                    }
                }
            }
            else {
                //県名指定処理
                Console.Write("県名を入力：");
                ken = Console.ReadLine();
                foreach (var item in kenntyou[ken]) {
                    Console.WriteLine("{0}の県庁所在地は{1}、人口は{2}人", ken, item.City, item.Population);
                }
            }
        }

        class CityInfo {
            public string City { get; set; }//都市
            public int Population { get; set; }//人口
        }
    }
}
