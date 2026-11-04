using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03;
// public なクラスの public なコンストラクタで使うので、インターフェースも public にする
public interface ITextFileService
{
	void Initialize(string fName);
	bool Execute(string line);
	void Terminate();
}
