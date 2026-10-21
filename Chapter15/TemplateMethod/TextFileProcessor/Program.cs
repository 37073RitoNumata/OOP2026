
namespace TextFileProcessor;
public abstract class TextFileProcessor
{
	public static void Run<T>(string fileName) where T : TextFileProcessor, new()
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

	private void Initialize(string fName)
	{
	}

	private void Execute(string line)
	{
	}

	private void Terminate()
	{
	}
}
