using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;

namespace Section01 {
    internal class Program {
        static private Dictionary<string, string> prefOfficeDict = new Dictionary<string, string>();


        static void Main(string[] args) {
            string? pref, prefCaptalLocation;

            Console.WriteLine("県庁所在地の登録【入力終了：Ctrl + 'Z'】");

            while (true) {
                Console.Write("都道府県：");
                pref = Console.ReadLine();
                if (pref is null) {
                    break;

                }
                Console.Write("県庁所在地：");
                prefCaptalLocation = Console.ReadLine();

                if (prefOfficeDict.ContainsKey(pref)) {

                    Console.WriteLine("上書きしますか Y/N");
                    var yn = Console.ReadLine();

                    if (yn == "Y") {
                        //prefCaptalLocation == prefOfficeDict.
                    }
                }
                prefOfficeDict.Add(pref, prefCaptalLocation);
                Console.WriteLine();
            }

            while (true) {

                switch (menuDisp()) {
                    case (1):
                        allDisp();
                        break;

                    case (2):
                        searchPrefCaptalLocation();
                        break;

                    case (9):
                        return;
                }
            }
        }


        private static int menuDisp() {
            Console.Write("**** メニュー ****\n1:一覧表示\n2:検索\n9:終了\n>");
            int num = int.Parse(Console.ReadLine());
            return num;
        }

        private static void allDisp() {
            foreach (var item in prefOfficeDict) {
                Console.WriteLine($"{item.Key}の県庁所在地は{item.Value}です。");
            }
        }

        private static void searchPrefCaptalLocation() {
            foreach (var item in prefOfficeDict) {
                Console.Write("都道府県：");
                string search = Console.ReadLine();

                if (prefOfficeDict.ContainsKey(search)) {
                    Console.WriteLine($"{item.Key}の県庁所在地は{item.Value}です。");
                    break;
                } else {
                    Console.WriteLine("見つかりませんでした");
                    break;
                }
            }
        }
    }
}
