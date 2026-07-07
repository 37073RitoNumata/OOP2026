using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Section01 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) {

        }

        private void btGet_Click(object sender, EventArgs e) {
            DateTime dt1 = dtpDate.Value;
            tbAgeOut.Text = dt1.AddDays((double)nudDay.Value).ToString();

            //if (DateTime.IsLeapYear(dt1.Year)) {
            //    tbOut.Text = "うるう年です";
            //} else {
            //    tbOut.Text = "うるう年ではありません";
            //}

            //switch (dt1.DayOfWeek) {
            //    case DayOfWeek.Sunday:
            //        Console.WriteLine("日曜日です"); break;
            //    case DayOfWeek.Monday:
            //        Console.WriteLine("月曜日です"); break;
            //    case DayOfWeek.Tuesday:
            //        Console.WriteLine("火曜日です"); break;
            //    case DayOfWeek.Wednesday:
            //        Console.WriteLine("水曜日です"); break;
            //    case DayOfWeek.Thursday:
            //        Console.WriteLine("木曜日です"); break;
            //    case DayOfWeek.Friday:
            //        Console.WriteLine("金曜日です"); break;
            //    case DayOfWeek.Saturday:
            //        Console.WriteLine("土曜日です"); break;
            //}
        }

        private void btBirthCalc_Click(object sender, EventArgs e) {
            DateTime birth = dtpBirth.Value; //生まれた日付
            DateTime today = DateTime.Today; //今日の日付
           
            tbAgeOut.Text = $"あなたは{GetAge(birth, today)}歳です";

            TimeSpan ts = today.Date - birth.Date;
            tbDateOut.Text = $"生まれてから{ts.Days}日です";
        }

        static int GetAge(DateTime birthday, DateTime targetDay) {
            var age = targetDay.Year - birthday.Year;
            if (targetDay < birthday.AddYears(age)) {
                age--;
            }
            return age;
        }

        private void dtpBirth_ValueChanged(object sender, EventArgs e) {

        }


        private void label1_Click(object sender, EventArgs e) {

        }

        private void label2_Click(object sender, EventArgs e) {

        }

    }
}
