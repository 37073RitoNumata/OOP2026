namespace Section01 {
    internal class Program {
        static private Dictionary<string, string> prefOfficeDict = new Dictionary<string, string>();


        static void Main(string[] args) {
            string? pref, prefCaptalLocation;

            Console.WriteLine("県庁所在地の登録【入力終了：Ctrl + 'Z'】");

            while (true) {
                //都道府県の入力
                Console.Write("都道府県：");
                pref = Console.ReadLine();
                if (pref is null) {
                    break;

                }
                //県庁所在地の入力
                Console.Write("県庁所在地：");
                prefCaptalLocation = Console.ReadLine();

                if (prefOfficeDict.ContainsKey(pref)) {

                    Console.WriteLine("上書きしますか Y/N");
                    var yn = Console.ReadLine();

                    if (yn == "Y") {
                        prefOfficeDict[pref] = prefCaptalLocation;
                    }
                } else {
                    prefOfficeDict.Add(pref, prefCaptalLocation);
                    Console.WriteLine();
                }
            }

            Boolean endFlag = false;
            while (true) {

                switch (menuDisp()) {
                    case (1)://一覧表示
                        allDisp();
                        break;

                    case (2)://検索
                        searchPrefCaptalLocation();
                        break;

                    case (9)://終了
                        endFlag = true;
                        return;
                }
            }
        }

        private static int menuDisp() {
            Console.Write("**** メニュー ****\n1:一覧表示\n2:検索\n9:終了\n>");

            if (int.TryParse(Console.ReadLine(), out int num)) {
                return num;
            }

            return 0;
        }

        private static void allDisp() {
            foreach (var item in prefOfficeDict) {
                Console.WriteLine($"{item.Key}の県庁所在地は{item.Value}です。");
            }
        }

        private static void searchPrefCaptalLocation() {

            Console.Write("都道府県：");
            string? search = Console.ReadLine();

            if (prefOfficeDict.ContainsKey(search)) {
                Console.WriteLine($"{search}の県庁所在地は{prefOfficeDict[search]}です。");
            } else {
                Console.WriteLine("見つかりませんでした");
            }
        }
    }
}