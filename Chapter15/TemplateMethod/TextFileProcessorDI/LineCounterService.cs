namespace TextFileProcessorDI;

public class LineCounterService : ITextFileService
{
	private int _lineCount;

	public void Initialize(string fName)
	{
		_lineCount = 0;
	}

	public void Execute(string line)
	{
		_lineCount++;
	}

	public void Terminate()
	{
		Console.WriteLine($"Total lines: {_lineCount}");
	}
}
