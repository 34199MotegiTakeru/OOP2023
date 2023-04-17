using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp0411 {
    class Program {
        static void Main(string[] args) {


            string[] moneyString = { "一万円札", "五千円札", "千円札", "五百円", "百円", "五十円", "十円", "五円", "一円" };
            int[] moneyInteger = { 10000, 5000, 1000, 500, 100, 50, 10, 5, 1 };


            Console.Write("金額：");
            int kingaku = int.Parse(Console.ReadLine());

            Console.Write("支払い：");
            int siharai = int.Parse(Console.ReadLine());

            int oturi = siharai - kingaku;
            Console.WriteLine("お釣り：" + oturi);


            for (int i = 0; i < moneyString.Length; i++)
            {
                // Console.WriteLine(moneyString[i] + "：{0}枚", oturi / moneyInteger[i]);
                Console.Write(moneyString[i] + "：");
                astOut(oturi / moneyInteger[i]);
                oturi %= moneyInteger[i];
            }
        }

        private static void astOut(int count) {
            for (int i = 0; i < count; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();//改行
        }
    }
}







            

        
    
