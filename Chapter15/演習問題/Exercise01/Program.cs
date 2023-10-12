﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    class Program {
        static void Main(string[] args) {
            Exercise1_2();
            Console.WriteLine();
            Exercise1_3();
            Console.WriteLine();
            Exercise1_4();
            Console.WriteLine();
            Exercise1_5();
            Console.WriteLine();
            Exercise1_6();
            Console.WriteLine();
            Exercise1_7();
            Console.WriteLine();
            Exercise1_8();

            Console.ReadLine();
        }

        private static void Exercise1_2() {
            var max = Library.Books.Max(b=> b.Price);
            var book = Library.Books.First(a => a.Price == max);
            Console.WriteLine(book);
        }

        private static void Exercise1_3() {
            var groups = Library.Books.GroupBy(b => b.PublishedYear).OrderBy(g => g.Key);
            foreach (var g in groups) {
                Console.WriteLine("{0}年 {1}冊",$"{g.Key}",g.Count());
            }
        }

        private static void Exercise1_4() {
            var groups = Library.Books.OrderByDescending(b => b.PublishedYear).ThenByDescending(g => g.Price);
            foreach (var g in groups) {
                Console.WriteLine(g);
            }    
        }

        private static void Exercise1_5() {
            var name = Library.Books.Where(b => b.PublishedYear == 2016).
                Join(Library.Categories,
                    book => book.CategoryId,
                    category => category.Id,
                    (book, category) => category.Name).Distinct();
            foreach (var item in name) {
                Console.WriteLine(item); 
            }
        }

        private static void Exercise1_6() {

        }

        private static void Exercise1_7() {

        }

        private static void Exercise1_8() {

        }
    }
}
