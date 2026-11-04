using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03;
internal class Take20Processor : ITextFileService
{
	private int _count;

	public void Initialize(string fName) => _count = 0;

	public bool Execute(string line)
	{
		Console.WriteLine(line);
		_count++;

		return _count < 20; // 20行表示したら false を返す
	}

	public void Terminate() => Console.WriteLine($"（{_count}行を表示しました）");
}