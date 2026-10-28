namespace DistanceConverter;

//基底クラス
public abstract class ConverterBase
{
	//この単位かどうかを判定する
	public abstract bool IsMyUnit(string name);

	//メートルとの比率（この比率を使って変換する）
	protected abstract double Ratio { get; }

	//距離の単位名
	public abstract string UnitName { get; }

	//メートルからの変換
	public double FromMeter(double meter) => meter / Ratio;

	//メートルへの変換
	public double ToMeter(double value) => value * Ratio;
}