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

	private async Task Button_Click(object sender, RoutedEventArgs e)
	{
		OpenFileDialog ofd = new OpenFileDialog();
		if (ofd.ShowDialog() == true)
		{
			TextArea.Text = await TextReaderSample.ReadTextAsync(ofd.FileName);
		}
	}
}

static class TextReaderSample
{
	internal static async Task<string> ReadTextAsync(string fileName)
	{
		var sb = new StringBuilder();

		// 非同期でファイルを開く

		return sb.ToString();
	}
}