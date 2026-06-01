using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    //5.1.1
    public class YearMonth {
        private int year { get; init; }
        private int month { get; init; }
        public bool Is21Century => 2001 <= year && year <= 2100;
     

        public YearMonth(int year, int month) {
            this.year = year;
            this.month = month;
        }
    }
}
