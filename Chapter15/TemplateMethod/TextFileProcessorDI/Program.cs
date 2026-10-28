using TextFileProcessorDI;

var service = new LineCounterService();
var processor = new TextFileProcessor(service);

Console.Write("ファイルのパスを入力してください => ");
var fileName = Console.ReadLine()?.Trim().Trim('"');   //「パスのコピー」で付く " を取り除く

if (string.IsNullOrEmpty(fileName))
{
	Console.WriteLine("パスが入力されていません。");
	return;
}
if (!File.Exists(fileName))
{
	Console.WriteLine($"ファイルが見つかりません: {fileName}");
	return;
}

processor.Run(fileName);
