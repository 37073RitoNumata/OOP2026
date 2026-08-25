using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReportSystem {
    public class Settings {

        private static readonly Settings _instance = new Settings();

        //メイン画面に設定した色情報
        public int MainFormBackColor { get; set; }
            = SystemColors.Control.ToArgb();

        public static Settings Instance {
            get {  return _instance; }
        }

        //外部からnewできないようにする
        private Settings() {
        }
    }
}
