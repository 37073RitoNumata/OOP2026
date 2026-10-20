using Microsoft.Win32;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Exercise01_WPF;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
	public MainWindow()
	{
		InitializeComponent();
	}

	private async void Button_Click(object sender, RoutedEventArgs e)
	{
		var ofd = new OpenFileDialog();
		if (ofd.ShowDialog() is true)
		{
			TextArea.Text = await TextReaderSample.ReadTextAsync(ofd.FileName);
		}
	}
}

static class TextReaderSample
{
	internal static async Task<string> ReadTextAsync(string fileName)
	{
		// 非同期版：5秒待つ間もウィンドウを自由に動かせる
		//await Task.Delay(5000);

		// 同期版：5秒間ウィンドウが完全に固まる（「応答なし」になることも）
		//Thread.Sleep(5000);

		var sb = new StringBuilder();

		// 非同期でファイルを開く
		using var sr = new StreamReader(fileName);

		while (!sr.EndOfStream)
		{
			var line = await sr.ReadLineAsync();
			sb.AppendLine(line);
		}
		return sb.ToString();
	}
}