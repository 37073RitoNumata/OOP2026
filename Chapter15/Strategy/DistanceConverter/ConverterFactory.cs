using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceConverter;
public class ConverterFactory
{
	//あらかじめ、すべてのコンバーターを生成し、配列に格納しておく
	private readonly static ConverterBase[] _converters = new ConverterBase[]
	{
		new MeterConverter(),
		new FeetConverter(),
		new InchConverter(),
		new YardConverter()
	};

	public static ConverterBase? GetInstance(string name) =>
		_converters.FirstOrDefault(x => x.IsMyUnit(name));
}