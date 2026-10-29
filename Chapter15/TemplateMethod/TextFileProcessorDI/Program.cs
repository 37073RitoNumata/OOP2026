using TextFileProcessorDI;

var service = new LineCounterService();
var processor = new TextFileProcessor(service);

Console.Write("ファイルのパスを入力してください => ");
processor.Run(Console.ReadLine()?.Trim().Trim('"'));
