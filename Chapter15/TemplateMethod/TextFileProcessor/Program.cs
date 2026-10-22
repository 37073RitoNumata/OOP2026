namespace TextFileProcessor;
public abstract class TextProcessor
{
	public static void Run<T>(string fileName) where T : TextProcessor, new()
	{
		var self = new T();
		self.Process(fileName);
	}

	private void Process(string fileName)
	{
		Initialize(fileName);
		var lines = File.ReadLines(fileName);
		foreach (var line in lines)
		{
			Execute(line);
		}
		Terminate();
	}

	protected virtual void Initialize(string fName) { }   // 必要なときだけ override
	protected virtual void Execute(string line) { }         // 派生クラスで必ず実装
	protected virtual void Terminate() { }                // 必要なときだけ override
}
