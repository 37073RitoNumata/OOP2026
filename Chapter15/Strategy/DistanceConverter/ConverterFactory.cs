namespace DistanceConverter;

public static class ConverterFactory
{
	//あらかじめインスタンスを生成し、配列に入れておく
	private readonly static ConverterBase[] _converters =
	[
		new MeterConverter(),
		new FeetConverter(),
		new InchConverter(),
		new YardConverter(),
		new KilometerConverter(),
		new MileConverter(),
	];

	//対応している単位名の一覧（エラーメッセージ用）
	public static IEnumerable<string> UnitNames =>
		_converters.Select(x => x.UnitName);

	public static ConverterBase? GetInstance(string name) =>
		_converters.FirstOrDefault(x => x.IsMyUnit(name));
}