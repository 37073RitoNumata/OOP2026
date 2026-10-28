namespace DistanceConverter;

internal class Program
{
	static void Main(string[] args)
	{
		var from = GetConverter("変換元の単位を入力してください");
		if (from is null) return;   //入力が終了した（Ctrl+Z など）

		var to = GetConverter("変換先の単位を入力してください");
		if (to is null) return;

		var distance = GetDistance(from);
		if (distance is null) return;

		var converter = new DistanceConverter(from, to);
		var result = converter.Convert(distance.Value);
		var text = $"{distance.Value}{from.UnitName}は、{result:0.000}{to.UnitName}です\n";
		Console.WriteLine(text);
	}

	//距離を入力させる（入力が終了したら null を返す）
	static double? GetDistance(ConverterBase from)
	{
		while (true)
		{
			Console.Write($"変換したい距離(単位:{from.UnitName})を入力してください => ");
			var line = Console.ReadLine();
			if (line is null) return null;

			if (double.TryParse(line, out var value))
				return value;

			Console.WriteLine("数値を入力してください。");
		}
	}

	//単位を入力させ、対応するコンバーターを返す（入力が終了したら null を返す）
	static ConverterBase? GetConverter(string msg)
	{
		while (true)
		{
			Console.Write(msg + " => ");
			var unit = Console.ReadLine();
			if (unit is null) return null;

			var converter = ConverterFactory.GetInstance(unit.Trim());
			if (converter is not null)
				return converter;

			Console.WriteLine($"「{unit}」には対応していません。対応している単位: {string.Join("、", ConverterFactory.UnitNames)}");
		}
	}
}