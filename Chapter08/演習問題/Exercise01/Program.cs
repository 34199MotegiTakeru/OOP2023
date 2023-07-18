﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Exercise01 {
    class Program {
        static void Main(string[] args) {
            //var dateTime = new DateTime(2019, 1, 15, 19, 48, 32);
            var dateTime = DateTime.Now;
            DisplayDatePattern1(dateTime);
            DisplayDatePattern2(dateTime);
            DisplayDatePattern3(dateTime);
            DisplayDatePattern3_2(dateTime);
        }

        private static void DisplayDatePattern1(DateTime dateTime) {
            //2019/1/15 19:48
            Console.WriteLine("{0}/{1}/{2} {3}:{4}",
                dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute);
        }

        private static void DisplayDatePattern2(DateTime dateTime) {
            //2019年01月15日 19時48分32秒
            var str = string.Format("{0}年{1}月{2}日 {3}時{4}分",
                dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute);
            Console.WriteLine(str);
        }

        private static void DisplayDatePattern3(DateTime dateTime) {
            //平成31年 1月15日（火曜日）
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();

            var datestr = dateTime.ToString("ggyy", culture);
            var dayOfWeek = culture.DateTimeFormat.GetDayName(dateTime.DayOfWeek);

            var str = string.Format("{0}年{1,2}月{2,2}日({3})", datestr, dateTime.Month, dateTime.Day, dayOfWeek);
            Console.WriteLine(str);
        }

        private static void DisplayDatePattern3_2(DateTime dateTime) {
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();

            var dateStr = dateTime.ToString("ggyy年MM月dd日(dddd)", culture);
            //ゼロサプレスを実施（不要なゼロを取り除く）
            var str = Regex.Replace(dateStr, @"0(\d)", " $1");
            Console.WriteLine(str);


        }
    }
}
