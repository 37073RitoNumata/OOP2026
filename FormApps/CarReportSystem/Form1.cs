using System.ComponentModel;
using static CarReportSystem.CarReport;

namespace CarReportSystem {
    public partial class Form1 : Form {

        //カーレポート管理用リスト
        BindingList<CarReport> listCarReports = new BindingList<CarReport>();

        public Form1() {
            InitializeComponent();
            dgvRecords.DataSource = listCarReports;
        }
        private void Form1_Load(object sender, EventArgs e) {

        }
        //追加ボタンイベントハンドラ
        private void btAddRecord_Click(object sender, EventArgs e) {

            tsslbMessage.Text = String.Empty; //メッセージ領域のクリア

            /********************************/
            //if (cbAuthor.Text == String.Empty || cbCarName.Text == String.Empty) {
            if (String.IsNullOrWhiteSpace(cbAuthor.Text) || String.IsNullOrWhiteSpace(cbCarName.Text)) {
                tsslbMessage.Text = "記録者、または車名が未入力です。";
                return;
            }
            /********************************/

            var carReport = new CarReport {
                Date = dtpDate.Value,
                Author = cbAuthor.Text,
                Maker = GetRadioButtonMaker(),
                CarName = cbCarName.Text,
                Report = tbReport.Text,
                Picture = pbPicture.Image,
            };
            listCarReports.Add(carReport);


            //入力履歴の保持
            SetCbAuthor(carReport.Author);
            SetCarName(carReport.CarName);

            InputItemAllClear();
        }

        private MakerGroup GetRadioButtonMaker() {
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

        private void btPicOpen_Click(object sender, EventArgs e) {
            if (ofdFilOpen.ShowDialog() == DialogResult.OK) {
                pbPicture.Image = Image.FromFile(ofdFilOpen.FileName);
            }
        }

        private void btNewInput_Click(object sender, EventArgs e) {
            InputItemAllClear();
        }

        private void InputItemAllClear() {
            dtpDate.Value = DateTime.Now;
            cbAuthor.Text = String.Empty;
            rbOther.Checked = true;
            cbCarName.Text = String.Empty;
            tbReport.Text = String.Empty;
            pbPicture.Image = null;
        }

        private void dgvRecords_Click(object sender, EventArgs e) {
            if (dgvRecords.CurrentRow is null
                || !dgvRecords.CurrentRow.Selected) return;

            dtpDate.Value = (DateTime)dgvRecords.CurrentRow.Cells["Date"].Value;
            cbAuthor.Text = (string)dgvRecords.CurrentRow.Cells["Author"].Value;
            SetRadioButtonMaker((MakerGroup)dgvRecords.CurrentRow.Cells["Maker"].Value);
            cbCarName.Text = (string)dgvRecords.CurrentRow.Cells["CarName"].Value;
            tbReport.Text = (string)dgvRecords.CurrentRow.Cells["Report"].Value;
            pbPicture.Image = (Image)dgvRecords.CurrentRow.Cells["Picture"].Value;

        }

        private void SetRadioButtonMaker(MakerGroup makerGroup) {
            switch (makerGroup) {
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
        private void SetCbAuthor(string author) {
            //未登録なら登録
            if (!author.Contains(cbAuthor.Text)) {
                cbAuthor.Items.Add(author);
            }
        }

        //車名の入力履歴をコンボボックスへ登録（重複なし）
        private void SetCarName(string carName) {
            if (!carName.Contains(cbCarName.Text)) {
                cbCarName.Items.Add(carName);
            }
        }

        private void btDeletePicture_Click(object sender, EventArgs e) {
            pbPicture.Image = null;
        }

        private void btDeleteRecord_Click(object sender, EventArgs e) {
            if ((dgvRecords.CurrentRow is null)
                || (!dgvRecords.CurrentRow.Selected)) return;

            //選択されているリストを消去
            listCarReports.RemoveAt(dgvRecords.CurrentRow.Index);
            InputItemUpdate();
        }

        private void InputItemUpdate() {
            if (!dgvRecords.CurrentRow.Selected) {
                InputItemAllClear();
            }
        }

        private void btModifyRecord_Click(object sender, EventArgs e) {
            //カーレポート管理用リストの該当する要素のデータを書き換える
            listCarReports[dgvRecords.CurrentRow.Index].Date = dtpDate.Value;
            listCarReports[dgvRecords.CurrentRow.Index].Author = cbAuthor.Text;
            listCarReports[dgvRecords.CurrentRow.Index].Maker = GetRadioButtonMaker();
            listCarReports[dgvRecords.CurrentRow.Index].CarName = cbCarName.Text;
            listCarReports[dgvRecords.CurrentRow.Index].Report = tbReport.Text;
            listCarReports[dgvRecords.CurrentRow.Index].Picture = pbPicture.Image;

            dgvRecords.Refresh(); //データグリッドビューの更新
        }
    }
}