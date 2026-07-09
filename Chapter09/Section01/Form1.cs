using System.Globalization;

namespace Section01 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btGet_Click(object sender, EventArgs e) {
            DateTime date = dtpDate.Value;
            tbOut.Text = date.AddDays((double)nudDay.Value).ToString();
        }

        private void btBirthCalc_Click(object sender, EventArgs e) {
            DateTime birth = dtpBirth.Value.Date;     //¶‚Ü‚ê‚½“ú•t
            DateTime today = DateTime.Today;    //¡“ú‚Ì“ú•t

            //int age = today.Year - birth.Year;
            //if(today < birth.AddYears(age)) {
            //    age--;
            //}

            tbOut.Text = $"‚ ‚È‚½‚Í{GetAge(birth, today)}Î‚Å‚·";

            TimeSpan ts = today - birth;
            tbOut2.Text = $"¶‚Ü‚ê‚Ä‚©‚ç{ts.TotalHours}“ú–Ú‚Å‚·";

            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            var dayOfWeek = culture.DateTimeFormat.GetDayName(birth.DayOfWeek);

            tbOut3.Text = $"¶‚Ü‚ê‚½{birth.Month}Œ{birth.Day}“ú‚Í‘æ{NthWeek(birth)}T‚Ì{dayOfWeek}‚Å‚·";

            //if (ts.Days % 365 == 0) {
            //    tbOut4.Text = "¡“ú‚ª’a¶“ú‚Å‚·";

            //} else if (ts.Days < 365) {
            //    tbOut4.Text = (ts.Days).ToString();

            //} else if (ts.Days > 365) {
            //    tbOut4.Text = (ts.Days).ToString();
            //}
            //¡”N‚Ì’a¶“ú‚ğì¬
            DateTime thisYearBirthday = new DateTime(today.Year, birth.Month, birth.Day);

            //‚·‚Å‚É’a¶“ú‚ª‰ß‚¬‚Ä‚¢‚é‚©
            if(thisYearBirthday < today) {
                //—ˆ”N‚Ì’a¶“ú‚ğì¬‚·‚é
                thisYearBirthday = thisYearBirthday.AddYears(1);
            }

            var span = thisYearBirthday - today;

            if (span.Days == 0) {
                tbOut4.Text = "¡“ú‚ª’a¶“ú‚Å‚·";
            } else {
                tbOut4.Text = $"’a¶“ú‚Ü‚Å‚ ‚Æ{span.Days}“ú‚Å‚·";
            }

        }


        //”N—î‚ğ‹‚ß‚éƒƒ\ƒbƒh
        static int GetAge(DateTime birthday, DateTime targetDay) {
            var age = targetDay.Year - birthday.Year;
            if (targetDay < birthday.AddYears(age)) {
                age--;
            }
            return age;
        }
        //w’è‚µ‚½“ú‚ª‘æ‰½T‚©‹‚ß‚é
        static int NthWeek(DateTime date) {
            var firstDay = new DateTime(date.Year, date.Month, 1);
            var firstDayOfWeek = (int)(firstDay.DayOfWeek);
            return (date.Day + firstDayOfWeek - 1) / 7 + 1;
        }


    }
}
