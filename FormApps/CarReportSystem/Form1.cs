using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using static CarReportSystem.CarReport;

namespace CarReportSystem
{
	public partial class Form1 : Form
	{

		//カーレポート管理用リスト
		BindingList<CarReport> listCarReports = new BindingList<CarReport>();

		//設定クラスのオブジェクトを生成
		//Settings settings = Settings.Instance;

		private readonly CarReportRepository _repository = new();

		public Form1()
		{
			InitializeComponent();

			//ProductクラスのプロパティからDataGridView列を自動生成する
			dgvRecords.AutoGenerateColumns = true;

			//DataGridViewのデータ元としてBindingListを設定する
			dgvRecords.DataSource = listCarReports;

			//起動直後にDBから商品一覧を読み込む
			ReloadCarReports();

			//使用中のDBファイルの場所をステータスバーに表示する
			tsslbMessage.Text = $"DB:{Database.FilePath}";
		}

		private void Form1_Load(object sender, EventArgs e)
		{

			try
			{
				Settings.Instance.Load();
				//背景色設定
				BackColor = Color.FromArgb(Settings.Instance.MainFormBackColor);
			}
			catch (Exception ex)
			{
				tsslbMessage.Text = "設定ファイル読み込みエラー";
				MessageBox.Show(ex.Message);//←より具体的なエラーを出力         
			}
		}

		private MakerGroup GetRadioButtonMaker()
		{
			if (rbToyota.Checked)
				return MakerGroup.トヨタ;
			if (rbNissan.Checked)
				return MakerGroup.日産;
			if (rbHonda.Checked)
				return MakerGroup.ホンダ;
			if (rbSubaru.Checked)
				return MakerGroup.スバル;
			if (rbImport.Checked)
				return MakerGroup.輸入車;

			return MakerGroup.その他;
		}

		private void btPicOpen_Click(object sender, EventArgs e)
		{
			if (ofdFilOpen.ShowDialog() == DialogResult.OK)
			{
				pbPicture.Image = Image.FromFile(ofdFilOpen.FileName);
			}
		}

		private void btNewInput_Click(object sender, EventArgs e)
		{
			InputItemAllClear();
		}

		private void InputItemAllClear()
		{
			dtpDate.Value = DateTime.Today;
			cbAuthor.Text = String.Empty;
			rbOther.Checked = true;
			cbCarName.Text = String.Empty;
			tbReport.Text = String.Empty;
			pbPicture.Image = null;

			dgvRecords.ClearSelection(); //セルの選択を解除
		}

		private void SetRadioButtonMaker(MakerGroup makerGroup)
		{
			switch (makerGroup)
			{
				case MakerGroup.トヨタ:
					rbToyota.Checked = true;
					break;
				case MakerGroup.日産:
					rbNissan.Checked = true;
					break;
				case MakerGroup.ホンダ:
					rbHonda.Checked = true;
					break;
				case MakerGroup.スバル:
					rbSubaru.Checked = true;
					break;
				case MakerGroup.輸入車:
					rbImport.Checked = true;
					break;

				default:
					rbOther.Checked = true;
					break;
			}
		}

		//記録者の入力履歴をコンボボックスへ登録（重複なし）
		private void SetCbAuthor(string author)
		{
			//未登録なら登録
			if (!cbAuthor.Items.Contains(author))
			{
				cbAuthor.Items.Add(author);
			}
		}

		//車名の入力履歴をコンボボックスへ登録（重複なし）
		private void SetCbCarName(string carName)
		{
			if (!cbCarName.Items.Contains(carName))
			{
				cbCarName.Items.Add(carName);
			}
		}

		private void btDeletePicture_Click(object sender, EventArgs e)
		{
			pbPicture.Image = null;
		}


		private void InputItemsUpdate()
		{
			if (dgvRecords.CurrentRow is null || !dgvRecords.CurrentRow.Selected)
			{
				InputItemAllClear();
			}
		}

		//追加ボタンイベントハンドラ
		private void btAddRecord_Click(object sender, EventArgs e)
		{

			tsslbMessage.Text = String.Empty; //メッセージ領域のクリア

			/********************************/
			if (String.IsNullOrWhiteSpace(cbAuthor.Text) || String.IsNullOrWhiteSpace(cbCarName.Text))
			{
				tsslbMessage.Text = "記録者、または車名が未入力です。";
				return;
			}
			/********************************/

			try
			{
				var carReport = new CarReport
				{
					Date = dtpDate.Value.Date,
					Author = cbAuthor.Text.Trim(),
					Maker = GetRadioButtonMaker(),
					CarName = cbCarName.Text.Trim(),
					Report = tbReport.Text,
					Picture = pbPicture.Image,
				};

				_repository.Add(carReport);

				ReloadCarReports();
				ClearInput();

				tsslbMessage.Text = "レポートを登録しました。";
			}
			catch (Exception ex)
			{
				ShowError("登録エラー", ex);
			}


			//入力履歴の保持
			SetCbAuthor(cbAuthor.Text.Trim());
			SetCbCarName(cbCarName.Text.Trim());

			dgvRecords.ClearSelection(); //セルの選択を解除
			InputItemsUpdate(); //データグリッドビューを更新したら呼ぶメソッド
		}

		//修正ボタンイベントハンドラ
		private void btModifyRecord_Click(object sender, EventArgs e)
		{

			if (dgvRecords.SelectedRows.Count == 0)
			{
				tsslbMessage.Text = "修正するレポートを選択してください";
				return;
			}

			if (String.IsNullOrWhiteSpace(cbAuthor.Text) || String.IsNullOrWhiteSpace(cbCarName.Text))
			{
				tsslbMessage.Text = "記録者、または車名が未入力です";
				return;
			}

			if (dgvRecords.CurrentRow?.DataBoundItem is not CarReport selectedCarReport)
			{
				tsslbMessage.Text = "修正するレポートを選択してください";
				return;
			}

			try
			{
				var updatedCarReport = new CarReport
				{
					Id = selectedCarReport.Id,
					Date = dtpDate.Value.Date,
					Author = cbAuthor.Text.Trim(),
					Maker = GetRadioButtonMaker(),
					CarName = cbCarName.Text.Trim(),
					Report = tbReport.Text,
					Picture = pbPicture.Image,
				};

				_repository.Update(updatedCarReport);

				ReloadCarReports();
				ClearInput();

				SetCbAuthor(cbAuthor.Text.Trim());
				SetCbCarName(cbCarName.Text.Trim());

				tsslbMessage.Text = "レポートを修正しました。";
			}
			catch (Exception ex)
			{
				ShowError("修正エラー", ex);
			}
		}

		//削除ボタンイベントハンドラ
		private void btDeleteRecord_Click(object sender, EventArgs e)
		{
			if ((dgvRecords.CurrentRow is null)
				|| (!dgvRecords.CurrentRow.Selected)) return;

			//削除したいインデックスを指定してリストから削除
			if (dgvRecords.CurrentRow?.DataBoundItem is not CarReport selectedcarReport)
			{
				tsslbMessage.Text = "削除するレポートを選択してください";
				return;
			}

			if (MessageBox.Show($"「{selectedcarReport.CarName}」を削除しますか？",
			"削除確認",
			MessageBoxButtons.YesNo,
			MessageBoxIcon.Question) != DialogResult.Yes)
			{
				return;
			}

			try
			{
				_repository.Delete(selectedcarReport.Id);

				ReloadCarReports();
				ClearInput();

				tsslbMessage.Text = "レポートを削除しました。";
			}
			catch (Exception ex)
			{
				ShowError("削除エラー", ex);
			}
			InputItemsUpdate(); //データグリッドビューを更新したら呼ぶメソッド
		}

		private void ReloadCarReports()
		{
			listCarReports.Clear();
			foreach (var carReport in _repository.GetAll())
			{
				listCarReports.Add(carReport);
			}
			dgvRecords.ClearSelection(); //セルの選択を解除
		}

		private void ClearInput()
		{
			tbReport.Clear();
		}

		private void dgvRecord_SelectionChanged(object sender, EventArgs e)
		{

			if ((dgvRecords.CurrentRow?.DataBoundItem is not CarReport carReport)
				|| (!dgvRecords.CurrentRow.Selected)) return;

			dtpDate.Value = carReport.Date;
			cbAuthor.Text = carReport.Author;
			SetRadioButtonMaker(carReport.Maker);
			cbCarName.Text = carReport.CarName;
			tbReport.Text = carReport.Report;
			pbPicture.Image = carReport.Picture;

			InputItemsUpdate();//データグリッドビューを更新したら呼ぶメソッド
		}

		//
		private void 終了ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void 色設定ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (cdColor.ShowDialog() == DialogResult.OK)
			{
				BackColor = cdColor.Color;
				// 選択された色をフォームに反映
				Settings.Instance.MainFormBackColor = cdColor.Color.ToArgb();
			}
		}

		//フォームが閉じたら呼ばれるイベントハンドラ
		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{

			Settings.Instance.Save();
		}

		private void 保存ToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			reportSaveFile();
		}

		private void 開くToolStripMenuItem_Click(object sender, EventArgs e)
		{
			reportOpenFile();
		}

		//ファイルセーブ処理
		private void reportSaveFile()
		{
			if (sfdReportFileSave.ShowDialog() == DialogResult.OK)
			{
				try
				{
					//バイナリ形式でシリアル化
#pragma warning disable SYSLIB0011
					var bf = new BinaryFormatter();
#pragma warning restore SYSLIB0011
					using (FileStream fs = File.Open(sfdReportFileSave.FileName, FileMode.Create))
					{
						bf.Serialize(fs, listCarReports);
					}
				}

				catch (Exception ex)
				{
					tsslbMessage.Text = "ファイル書き出しエラー";
					MessageBox.Show(ex.Message);
				}
			}
		}

		//ファイルオープン処理
		private void reportOpenFile()
		{
			if (ofdReportFileOpen.ShowDialog() == DialogResult.OK)
			{
				try
				{
					//逆シリアル化でバイナリ形式を取り込む
#pragma warning disable SYSLIB0011
					var bf = new BinaryFormatter();
#pragma warning restore SYSLIB0011
					using (FileStream fs = File.Open(ofdReportFileOpen.FileName, //ファイル名
						FileMode.Open, //ファイルモード
						FileAccess.Read //アクセス
						))
					{

						listCarReports = (BindingList<CarReport>)bf.Deserialize(fs);
						dgvRecords.DataSource = listCarReports;
					}
					//コンボボックスの履歴をすべて消す
					cbAuthor.Items.Clear();
					cbCarName.Items.Clear();

					//コンボボックスの履歴を再登録
					foreach (var report in listCarReports)
					{
						SetCbAuthor(report.Author);
						SetCbCarName(report.CarName);
					}
				}
				catch (Exception ex)
				{
					tsslbMessage.Text = "ファイル読み出しエラー";
					MessageBox.Show(ex.Message);
				}
			}
		}

		private void ShowError(string title, Exception ex)
		{
			tsslbMessage.Text = title;
			MessageBox.Show(
				ex.Message,
				title,
				MessageBoxButtons.OK,
				MessageBoxIcon.Error);
		}
	}
}