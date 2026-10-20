using System.Diagnostics;

namespace Section03;

public partial class Form1 : Form
{
	public Form1()
	{
		InitializeComponent();
	}

	private async void button1_Click(object sender, EventArgs e)
	{
		//Thread.Sleep(5000);
		//MessageBox.Show("Š®—¹");

		//await Task.Delay(5000);
		//MessageBox.Show("Š®—¹");

		await Task.Run(() => DoLongTimeWork(5000));
		MessageBox.Show("Š®—¹");

	}

	private async Task DoLongTimeWork()
	{
		await Task.Delay(5000);
	}

	private async Task<long> DoLongTimeWork(int milliseconds)
	{
		var sw = Stopwatch.StartNew();
		await Task.Run(() => Thread.Sleep(milliseconds));
		sw.Stop();
		return sw.ElapsedMilliseconds;
	}
}
