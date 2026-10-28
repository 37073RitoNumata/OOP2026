namespace DistanceConverter;

public class MeterConverter : ConverterBase
{
	public override bool IsMyUnit(string name) =>
		string.Equals(name, "meter", StringComparison.OrdinalIgnoreCase) || name == UnitName;

	protected override double Ratio => 1;
	public override string UnitName => "メートル";
}

public class FeetConverter : ConverterBase
{
	public override bool IsMyUnit(string name) =>
		string.Equals(name, "feet", StringComparison.OrdinalIgnoreCase) || name == UnitName;

	protected override double Ratio => 0.3048;
	public override string UnitName => "フィート";
}

public class InchConverter : ConverterBase
{
	public override bool IsMyUnit(string name) =>
		string.Equals(name, "inch", StringComparison.OrdinalIgnoreCase) || name == UnitName;

	protected override double Ratio => 0.0254;
	public override string UnitName => "インチ";
}

public class YardConverter : ConverterBase
{
	public override bool IsMyUnit(string name) =>
		string.Equals(name, "yard", StringComparison.OrdinalIgnoreCase) || name == UnitName;

	protected override double Ratio => 0.9144;
	public override string UnitName => "ヤード";
}

public class KilometerConverter : ConverterBase
{
	public override bool IsMyUnit(string name) =>
		string.Equals(name, "kilometer", StringComparison.OrdinalIgnoreCase) || name == UnitName;

	protected override double Ratio => 1000;
	public override string UnitName => "キロメートル";
}

public class MileConverter : ConverterBase
{
	public override bool IsMyUnit(string name) =>
		string.Equals(name, "mile", StringComparison.OrdinalIgnoreCase) || name == UnitName;

	protected override double Ratio => 1609.344;   //国際マイル（正確な値）
	public override string UnitName => "マイル";
}