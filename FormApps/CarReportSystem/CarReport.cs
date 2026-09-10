using System.ComponentModel;

namespace CarReportSystem;
public sealed class CarReport
{
	//列挙型
	public enum MakerGroup
	{
		なし, トヨタ, 日産, ホンダ, スバル, 輸入車, その他,
	}
	//ID（自動採番）
	[DisplayName("ID")]
	public int Id { get; set; }

	[DisplayName("日付")]
	public DateTime Date { get; set; }

	[DisplayName("記録者")]
	public string Author { get; set; } = string.Empty;

	[DisplayName("メーカー")]
	public MakerGroup Maker { get; set; }

	[DisplayName("車名")]
	public string CarName { get; set; } = string.Empty;

	[DisplayName("レポート")]
	public string Report { get; set; } = string.Empty;

	[DisplayName("画像")]
	public Image? Picture { get; set; }
}