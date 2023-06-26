using System.Collections.Generic;
using System.IO;

namespace Test01 {
    class ScoreCounter {
        private IEnumerable<Student> _score;

        // コンストラクタ
        public ScoreCounter(string filePath) {

            _score = ReadScore(filePath);

        }


        //メソッドの概要： 
        private static IEnumerable<Student> ReadScore(string filePath) {
            var students = new List<Student>(); //集計データを格納する
            var lines = File.ReadAllLines(filePath); //ファイルからすべてのデータを読み込む

            foreach (var line in lines) { //すべての行から１行ずつトロふぁす
                var items = line.Split(','); //区切りで項目別に分ける
                var student = new Student { //Studentインスタンス生成
                    Name = items[0],
                    Subject = items[1],
                    Score = int.Parse(items[2])
                };
                students.Add(student); //Studentインスタンスをコレクションに追加
            }
            return students;
        }

        //メソッドの概要： 
        public IDictionary<string, int> GetPerStudentScore() {

            var dict = new SortedDictionary<string, int>();
            foreach (var item in _score) {
                if (dict.ContainsKey(item.Name))
                    dict[item.Name] += item.Score; //名前が既に存在する
                else
                    dict[item.Name] = item.Score; //店名が存在しない(新規格納)
            }
            return dict;




        }
    }
}
