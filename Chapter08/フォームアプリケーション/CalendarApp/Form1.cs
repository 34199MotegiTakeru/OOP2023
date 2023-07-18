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

namespace CalendarApp {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) {

        }

        private void btDayCalc_Click(object sender, EventArgs e) {
            var dtp = dtpDate.Value;
            var now = DateTime.Now;
            var sa = now - dtp;

            tbMessage.Text = sa.Days.ToString() + "日";
        }

        

        private void btAge_Click(object sender, EventArgs e) {
            var dtp = dtpDate.Value;
            var now = DateTime.Now;
            var age = now.Year - dtp.Year;
            if (now < dtp.AddYears(age)) {
                age--;
            }
            tbMessage.Text = age.ToString() + "歳";

        }

        private void TimeNow_TextChanged(object sender, EventArgs e) {
            

        }

        //実行時に一度だけ呼び出されるメソッド
        private void Form1_Load(object sender, EventArgs e) {
            var now = DateTime.Now;
            TimeNow.Text = now.ToString("yyyy年MM月dd日(dddd) 　HH時mm分ss秒");
            tmTimeDisp.Start();//タイマースタート
        }

        //タイマーイベントハンドラー
        private void tmTimeDisp_Tick(object sender, EventArgs e) {
            var now = DateTime.Now;
            TimeNow.Text = now.ToString("yyyy年MM月dd日(dddd) 　HH時mm分ss秒");

        }
    }
}
