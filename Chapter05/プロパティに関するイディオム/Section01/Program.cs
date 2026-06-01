using System.Collections.Immutable;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            //var obj = new PasswordPolicy("aaaaa", " bbbbb");
            //var data = obj.Name;

            var ms = new MySample();
            var newList = ms.MyList.Add(6).RemoveAt(0);
            ms.MyList.ForEach(n=> Console.WriteLine($"{n}"));
            Console.WriteLine();

            newList.ForEach(n => Console.WriteLine($"{n}"));
            Console.WriteLine();

            foreach (var n in ms.MyList) {
                Console.WriteLine(n);
            }
        }

        class MySample {
            public ImmutableList<int> MyList { get; private set; }

            public MySample() {
                var list = new List<int>() { 1, 2, 3, 4, 5 };
                MyList = list.ToImmutableList();
            }
        }

        class PasswordPolicy {
            public int MinimumLength { get; set; } = 8;

            //読み取り専用プロパティ
            public string GivenName { get; init; } = null!;
            public string FamilyName { get; init; } = null!;

            //getアクセサーのみを定義した読み取り専用プロパティ
            //public string Name {
            //  get { return FamilyName + " " + GivenName; }
            //}

            public string Name => FamilyName + " " + GivenName;

            public PasswordPolicy(string familyName, string givenName) {
                FamilyName = familyName;
                GivenName = givenName;
            }

            //public void abc() {
            //    GivenName = "ffffff";
            //}
        }
    }
}
