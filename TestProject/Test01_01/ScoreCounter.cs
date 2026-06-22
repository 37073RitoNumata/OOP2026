namespace Test01_01 {
    public class ScoreCounter {
        private IEnumerable<Student> _score;

        // コンストラクタ
        public ScoreCounter(string filePath) {
            _score = ReadScore(filePath);
        }

        //メソッドの概要：
        private static IEnumerable<Student> ReadScore(string filePath) {
            var sales = new List<Student>();
            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines) {
                var items = line.Split(',');
                Student student = new Student {
                    Name = items[0],
                    Subject = items[1],
                    Score = int.Parse(items[2])
                };

                sales.Add(student);
            }

            return sales;
        }

        //メソッドの概要：
        public IDictionary<string, int> GetPerStudentScore() {
            var dict = new Dictionary<string, int>();
            foreach (var student in _score) {

                if (dict.ContainsKey(student.Subject))
                    //登録されている場合
                    dict[student.Subject] += student.Score; //点数を加算                                                           
                else
                    //登録されていない場合
                    dict[student.Subject] = student.Score; //新規に点数を登録
            }





            return dict;
        }
    }
}
