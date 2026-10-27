using TextFileProcessor;

string path = @"C:\Users\infosys\source\repos\OOP2026\Chapter14\Section04\Program.cs";
TextProcessor.Run<WordCounterProcessor>(path);

public class WordCounterProcessor : TextProcessor
{
	private int _count = 0;
	private string word = "await";
	private static readonly char[] _separators =
{
	' ', '\t',                      // 空白・タブ
	'.', ',', ';', ':', '!', '?',   // 区切り・句読点
	'(', ')', '[', ']', '{', '}',   // カッコ類
	'<', '>',                       // ジェネリック・比較
	'=', '+', '-', '*', '/', '%',   // 演算子(/ はコメント // も兼ねる)
	'&', '|', '^', '~',             // 論理・ビット演算子
	'"', '\'',                      // 文字列・文字リテラル
	'@', '$', '#'                   // @"..." $"..." #region など
};
	protected virtual void Initialize(string fName) =>
		_count = 0;
	protected virtual void Execute(string line) =>
		_count += line.Split(_separators, StringSplitOptions.RemoveEmptyEntries).Count(w => w == word);
	protected virtual void Terminate() =>
		Console.WriteLine($"{word}は{_count}回出現します。 ");
}
