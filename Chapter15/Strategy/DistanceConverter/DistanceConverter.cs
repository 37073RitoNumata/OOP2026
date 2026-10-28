namespace DistanceConverter;

public class DistanceConverter
{
	public ConverterBase From { get; init; }
	public ConverterBase To { get; init; }

	public DistanceConverter(ConverterBase from, ConverterBase to)
	{
		From = from;
		To = to;
	}

	public double Convert(double value)
	{
		var meter = From.ToMeter(value); //メートルに変換
		return To.FromMeter(meter); //メートルから目的の単位に変換
	}
}
