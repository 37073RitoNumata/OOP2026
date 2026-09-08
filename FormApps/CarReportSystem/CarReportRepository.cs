using CarReportSystem;
using Microsoft.Data.Sqlite;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Xml.Linq;
using static CarReportSystem.CarReport;

namespace CarReportSystem;

internal class CarReportRepository
{
	public List<CarReport> GetAll()
	{

		var carReports = new List<CarReport>();

		//接続オブジェクトを生成する
		using var connection = Database.GetConnection();

		//DBを開く
		connection.Open();

		//SQLを実行するためのコマンドオブジェクトを作る
		using var command = connection.CreateCommand();

		command.CommandText =
			"""
            SELECT Id, Date, Author, Maker, CarName, Report, Picture
            FROM CarReports
            ORDER BY Id;
            """;

		//SELECTを実行し、複数行の検索結果を読み取る
		using var reader = command.ExecuteReader();

		while (reader.Read())
		{
			carReports.Add(new CarReport
			{
				Id = reader.GetInt32(0),
				Date = reader.GetDateTime(1),
				Author = reader.GetString(2),
				Maker = (MakerGroup)reader.GetInt32(3),
				CarName = reader.GetString(4),
				Report = reader.GetString(5),
				Picture = reader.IsDBNull(6) ? null : BytesToImage(reader.GetFieldValue<byte[]>(6))
			});
		}
		return carReports;
	}

	//カーレポートを1件追加する Create(INSERT)に相当する
	//戻り値として自動採番されたIdを返す
	public int Add(CarReport carReport)
	{

		//接続オブジェクトを生成する
		using var connection = Database.GetConnection();

		//DBを開く
		connection.Open();

		//SQLを実行するためのコマンドオブジェクトを作る
		using var command = connection.CreateCommand();

		command.CommandText =
			"""
            INSERT INTO CarReports(Date, Author, Maker, CarName, Report, Picture)
            VALUES($date, $author, $maker, $carName, $report, $picture);

            SELECT last_insert_rowid();
            """;

		command.Parameters.AddWithValue("$date", carReport.Date);
		command.Parameters.AddWithValue("$author", carReport.Author);
		command.Parameters.AddWithValue("$maker", carReport.Maker);
		command.Parameters.AddWithValue("$carName", carReport.CarName);
		command.Parameters.AddWithValue("$report", carReport.Report);
		command.Parameters.AddWithValue("$picture", carReport.Picture);

		//結果行を返さないSQLを実行する
		var result = command.ExecuteScalar();

		if (result is null)
			throw new InvalidOperationException("登録したカーレポートのIDを取得できませんでした。");

		//SQLiteのINTEGERはlongとして返るため、intに変換する
		return Convert.ToInt32((long)result);
	}

	public void Update(CarReport carReport)
	{

		//接続オブジェクトを生成する
		using var connection = Database.GetConnection();

		//DBを開く
		connection.Open();

		//SQLを実行するためのコマンドオブジェクトを作る
		using var command = connection.CreateCommand();

		command.CommandText =
			"""
            UPDATE CarReports
            SET Date =	$date,
                Author = $author,
                Maker = $maker,
                CarName = $carName,
                Report = $report,
                Picture = $picture
            WHERE Id = $id;
            """;

		command.Parameters.AddWithValue("$date", carReport.Date);
		command.Parameters.AddWithValue("$author", carReport.Author);
		command.Parameters.AddWithValue("$maker", carReport.Maker);
		command.Parameters.AddWithValue("$carName", carReport.CarName);
		command.Parameters.AddWithValue("$report", carReport.Report);
		command.Parameters.AddWithValue("$picture", ImageToBytes(carReport.Picture));
		command.Parameters.AddWithValue("$id", carReport.Id);

		//更新件数が0なら対象が存在しない
		if (command.ExecuteNonQuery() == 0)
			throw new InvalidOperationException("修正対象のカーレポートが見つかりませんでした。");
	}

	public void Delete(int id)
	{
		//接続オブジェクトを生成する
		using var connection = Database.GetConnection();

		//DBを開く
		connection.Open();

		//SQLを実行するためのコマンドオブジェクトを作る
		using var command = connection.CreateCommand();

		command.CommandText =
			"""
            DELETE FROM CarReports
            WHERE Id = $id;
            """;

		command.Parameters.AddWithValue("$id", id);
		command.ExecuteNonQuery();
	}

	// ImageをSQLiteへ保存できるbyte[]へ変換する
	private static byte[]? ImageToBytes(Image? image)
	{
		if (image is null) return null;

		using var stream = new MemoryStream();
		// DBへはPNG形式で保存
		image.Save(stream, ImageFormat.Png);
		return stream.ToArray();
	}

	// SQLiteのBLOB（byte[]）をImageへ変換する
	private static Image BytesToImage(byte[] data)
	{
		using var stream = new MemoryStream(data);
		using var image = Image.FromStream(stream);
		// MemoryStream破棄後も利用できるようBitmapとしてコピーする。
		return new Bitmap(image);
	}
}

