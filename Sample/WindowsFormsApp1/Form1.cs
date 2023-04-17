using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            
        }

        private void btButton_Click(object sender, EventArgs e) {
            //int ans = int.Parse(tbNum1.Text) + int.Parse(tbNum2.Text)
            //tbAns.Text = ans.ToString();

            int num1 = int.Parse(tbNum1.Text);
            int num2 = int.Parse(tbNum2.Text);
            int sum = num1 + num2;
            tbAns.Text = sum.ToString();

        }

        private void textBox2_TextChanged(object sender, EventArgs e) {

        }

        private void label1_Click(object sender, EventArgs e) {

        }

        private void tbNum1_TextChanged(object sender, EventArgs e) {

        }

        private void tbNum2_TextChanged(object sender, EventArgs e) {
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e) {

        }
        //イベントハンドラ
        private void btpow_Click_1(object sender, EventArgs e) {
            int x = decimal.ToInt32(nudX.Value);
            int y = decimal.ToInt32(nudY.Value);
            int i = 0;
            int ans = 1;
            while (y > i)
            {
                ans = ans * x;
                i += 1;
            }
            tbResult.Text = ans.ToString();
        }
    }
}
