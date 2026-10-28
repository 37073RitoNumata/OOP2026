namespace TextFileProcessorDI;

// public なクラスの public なコンストラクタで使うので、インターフェースも public にする
public interface ITextFileService
{
	void Initialize(string fName);
	void Execute(string line);
	void Terminate();
}
