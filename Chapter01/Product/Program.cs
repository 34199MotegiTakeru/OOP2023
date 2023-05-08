﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSample {
    class Program {
        static void Main(string[] args) {

            #region P26のサンプルプログラム
            //インスタンス生成
            //Product karinto = new Product(123, "かりんとう", 180);
            //Product daifuku = new Product(235, "大福もち", 160);

            //Console.WriteLine("かりんとうの税込み価格：" + karinto.GetPriceIncludingTax());
            //Console.WriteLine("大福もちの税込み価格：" + daifuku.GetPriceIncludingTax());
            #endregion

            DateTime date = new DateTime(2023, 5, 8);
            //DateTime date = DateTime.Today;

            Console.WriteLine("今日は" + date.Year + "年" + date.Month + "月" + date.Day + "日");


            //10日後を求める
            DateTime daysAfter10 = date.AddDays(10);
            Console.WriteLine("10日後は" + daysAfter10.Year + "年" + daysAfter10.Month + "月" + daysAfter10.Day + "日");

            //10日前を求める
            DateTime daysBefore10 = date.AddDays(-10);
            Console.WriteLine("10日前は" + daysBefore10.Year + "年" + daysBefore10.Month + "月" + daysBefore10.Day + "日");



        }
    }
}