﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace CarReportSystem {
    public partial class Form1 : Form {
        //管理用データ
        BindingList<CarReport> CarReports = new BindingList<CarReport>();
        private uint mode;

        //設定情報保存用オブジェクト
        Settings settings = Settings.getInstance();

        public Form1() {
            InitializeComponent();
            //dgvCarReports.DataSource = CarReports;
        }

        //ステータスラベルのテキスト表示・非表示（引数なしはメッセージ非表示）
        private void StatasLabelDisp(string msg = "") {
            tsInfoText.Text = msg;
        }

        //追加ボタンがクリックされた時のイベントハンドラー
        private void btAddReport_Click(object sender, EventArgs e) {
            StatasLabelDisp();//ステータスラベルのテキスト非表示
            if (cbAuthor.Text == "") {
                StatasLabelDisp("記録者を入力してください");
                return;
            }
            else if (cbCarName.Text == "") {
                StatasLabelDisp("車名を入力してください");
                return;
            }

            DataRow newRow = infosys202321DataSet.CarReportTable.NewRow();
            newRow[1] = dtpDate.Value;
            newRow[2] = cbAuthor.Text;
            newRow[3] = getSelectedMaker();
            newRow[4] = cbCarName.Text;
            newRow[5] = tbReport.Text;
            newRow[6] = ImageToByteArray(pbCarImage.Image);
            infosys202321DataSet.CarReportTable.Rows.Add(newRow);
            this.carReportTableTableAdapter.Update(infosys202321DataSet.CarReportTable);

            //var carReport = new CarReport                            //Saleインスタンスを生成
            //{
            //    Date = dtpDate.Value,
            //    Author = cbAuthor.Text,
            //    Maker = getSelectedMaker(),
            //    CarName = cbCarName.Text,
            //    Report = tbReport.Text,
            //    CarImage = pbCarImage.Image,
            //};
            //CarReports.Add(carReport);
            btModifyReport.Enabled = true;
            btDeleteReport.Enabled = true;
            setCbAuther(cbAuthor.Text);
            setCbCarName(cbCarName.Text);
            sakuzyo();
        }

        private void setCbAuther(string auther) {
            if (!cbAuthor.Items.Contains(auther)) {//コンボボックスに重複があるか
                cbAuthor.Items.Add(auther);
            }
        }

        private void setCbCarName(string carname) {
            if (!cbCarName.Items.Contains(carname)) {//コンボボックスに重複があるか
                cbCarName.Items.Add(carname);
            }
        }

        //ラジオボタンで選択されているメーカーを返却
        private CarReport.MakerGroup getSelectedMaker() {
            foreach (var item in gbMaker.Controls) {
                if (((RadioButton)item).Checked) {
                    return (CarReport.MakerGroup)int.Parse(((RadioButton)item).Tag.ToString());
                }
            }
            return CarReport.MakerGroup.その他;
        }

        //指定したメーカーのラジオボタンをセット
        private void setSelectedMaker(string makerGroup) {
            switch (makerGroup) {
                case "トヨタ":
                    rbToyota.Checked = true;
                    break;
                case "日産":
                    rbNissan.Checked = true;
                    break;
                case "ホンダ":
                    rbHonda.Checked = true;
                    break;
                case "スバル":
                    rbSubaru.Checked = true;
                    break;
                case "スズキ":
                    rbSuzuki.Checked = true;
                    break;
                case "ダイハツ":
                    rbDaihatsu.Checked = true;
                    break;
                case "輸入車":
                    rbImported.Checked = true;
                    break;
                case "その他":
                    rbOther.Checked = true;
                    break;
            }
        }

        private void btImageOpen_Click(object sender, EventArgs e) {
            if (ofdImageFileOpen.ShowDialog() == DialogResult.OK) {
                pbCarImage.Image = Image.FromFile(ofdImageFileOpen.FileName);
            }
        }

        private void Form1_Load(object sender, EventArgs e) {

            dgvCarReports.Columns[6].Visible = false;   //画像項目非表示
            dgvCarReports.Columns[0].Visible = false;   //画像項目非表示

            btModifyReport.Enabled = false; //マスクする
            btDeleteReport.Enabled = false; //マスクする

            try {
                //設定ファイルを逆シリアル化して背景を設定
                using (var reader = XmlReader.Create("settings.xml")) {
                    var serializer = new XmlSerializer(typeof(Settings));
                    settings = serializer.Deserialize(reader) as Settings;
                    BackColor = Color.FromArgb(settings.MainFormColor);
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }

            toolStripStatusLabel2.Text = "";//情報表示領域のテキストを初期化
            tsTimeDisp.Text = DateTime.Now.ToString("HH時mm分ss秒");
            timer1.Start();

            dgvCarReports.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;//奇数行のみ色設定
        }

        //削除ボタンイベントハンドラ
        private void btDeleteReport_Click(object sender, EventArgs e) {
            dgvCarReports.Rows.RemoveAt(dgvCarReports.CurrentRow.Index);
            sakuzyo();
            this.carReportTableTableAdapter.Update(infosys202321DataSet.CarReportTable);//更新
            //if (dgvCarReports.Rows.Count != 0) {
            //    CarReports.RemoveAt(dgvCarReports.CurrentRow.Index);
            //    //if (dgvCarReports.Rows.Count == 0) {
            //    sakuzyo();
            //    //}
            //}
        }

        //レコードの選択時
        /* private void dgvCarReports_Click(object sender, EventArgs e) {
              if (dgvCarReports.Rows.Count != 0) {
                  dtpDate.Value = (DateTime)dgvCarReports.CurrentRow.Cells[0].Value;
                  cbAuthor.Text = dgvCarReports.CurrentRow.Cells[1].Value.ToString();
                  setSelectedMaker((CarReport.MakerGroup)dgvCarReports.CurrentRow.Cells[2].Value);
                  cbCarName.Text = dgvCarReports.CurrentRow.Cells[3].Value.ToString();
                  tbReport.Text = dgvCarReports.CurrentRow.Cells[4].Value.ToString();
                  pbCarImage.Image = (Image)dgvCarReports.CurrentRow.Cells[5].Value;
                  btModifyReport.Enabled = true; //修正ボタン有効
                  btDeleteReport.Enabled = true; //削除ボタン有効
              }
          }*/

        //修正ボタンイベントハンドラ
        private void btModifyReport_Click_1(object sender, EventArgs e) {
            //if (dgvCarReports.Rows.Count != 0) {
            dgvCarReports.CurrentRow.Cells[1].Value = dtpDate.Value;
            dgvCarReports.CurrentRow.Cells[2].Value = cbAuthor.Text;
            dgvCarReports.CurrentRow.Cells[3].Value = getSelectedMaker();
            dgvCarReports.CurrentRow.Cells[4].Value = cbCarName.Text;
            dgvCarReports.CurrentRow.Cells[5].Value = tbReport.Text;
            dgvCarReports.CurrentRow.Cells[6].Value = pbCarImage.Image;

            //    CarReports[dgvCarReports.CurrentRow.Index].Date = dtpDate.Value;
            //    CarReports[dgvCarReports.CurrentRow.Index].Author = cbAuthor.Text;
            //    CarReports[dgvCarReports.CurrentRow.Index].Maker = getSelectedMaker();
            //    CarReports[dgvCarReports.CurrentRow.Index].CarName = cbCarName.Text;
            //    CarReports[dgvCarReports.CurrentRow.Index].Report = tbReport.Text;

            //    dgvCarReports.Refresh();    //一覧更新
            //    sakuzyo();

            this.Validate();
            this.carReportTableBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.infosys202321DataSet);
        }
        

        private void sakuzyo() {
            cbAuthor.Text = "";
            cbCarName.Text = "";
            setSelectedMaker("トヨタ");
            pbCarImage.Image = null;
            tbReport.Text = "";
            dgvCarReports.ClearSelection();//選択解除
            btModifyReport.Enabled = false; //修正ボタン無効
            btDeleteReport.Enabled = false; //削除ボタン無効
        }

        //終了メニュー
        private void 終了XToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void バージョン情報ToolStripMenuItem_Click(object sender, EventArgs e) {
            var vf = new VersionForm();
            vf.ShowDialog();//モーダルダイヤログとして表示
        }

        private void btImageDelete_Click(object sender, EventArgs e) {
            pbCarImage.Image = null;
        }

        private void 色設定ToolStripMenuItem_Click(object sender, EventArgs e) {
            if (cdColor.ShowDialog() == DialogResult.OK) {
                BackColor = cdColor.Color;
                settings.MainFormColor = cdColor.Color.ToArgb();
            }
        }
        
        private void btScaleChange_Click(object sender, EventArgs e) {
            //mode++;
            //if (mode > 4)
              //  mode = 0;
            //pbCarImage.SizeMode = (PictureBoxSizeMode)mode;

            mode = mode < 4 ? ((mode == 1) ? 3 : ++mode) : 0;//AutoSize(2)を除外
            pbCarImage.SizeMode = (PictureBoxSizeMode)mode;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            //設定ファイルのシリアル化
            using(var writer = XmlWriter.Create("settings.xml")) {
                var serialize = new XmlSerializer(settings.GetType());
                 serialize.Serialize(writer,settings);
            }
        }

        private void timer1_Tick(object sender, EventArgs e) {
            tsTimeDisp.Text = DateTime.Now.ToString("HH時mm分ss秒");
        }

        //レコードの選択時
        private void dgvCarReports_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (dgvCarReports.Rows.Count != 0) {
               dtpDate.Value = (DateTime)dgvCarReports.CurrentRow.Cells[1].Value;
                cbAuthor.Text = dgvCarReports.CurrentRow.Cells[2].Value.ToString();
                setSelectedMaker(dgvCarReports.CurrentRow.Cells[3].Value.ToString());
                cbCarName.Text = dgvCarReports.CurrentRow.Cells[4].Value.ToString();
                tbReport.Text = dgvCarReports.CurrentRow.Cells[5].Value.ToString();
                pbCarImage.Image = !dgvCarReports.CurrentRow.Cells[6].Value.Equals(DBNull.Value) 
                    && ((Byte[])dgvCarReports.CurrentRow.Cells[6].Value).Length != 0 ?
                    ByteArrayToImage((Byte[])dgvCarReports.CurrentRow.Cells[6].Value) : null;
                //if (!dgvCarReports.CurrentRow.Cells[6].Value.Equals(DBNull.Value)) {
                //    pbCarImage.Image = ByteArrayToImage((Byte[])dgvCarReports.CurrentRow.Cells[6].Value);
                //}
                //else {
                //    pbCarImage.Image = null;
                //}
                btModifyReport.Enabled = true; //修正ボタン有効
                btDeleteReport.Enabled = true; //削除ボタン有効
            }
        }

        // バイト配列をImageオブジェクトに変換
        public static Image ByteArrayToImage(byte[] b) {
            ImageConverter imgconv = new ImageConverter();
            Image img = (Image)imgconv.ConvertFrom(b);
            return img;
        }

        // Imageオブジェクトをバイト配列に変換
        public static byte[] ImageToByteArray(Image img) {
            ImageConverter imgconv = new ImageConverter();
            byte[] b = (byte[])imgconv.ConvertTo(img, typeof(byte[]));
            return b;
        }

        private void carReportTableBindingNavigatorSaveItem_Click(object sender, EventArgs e) {
            this.Validate();
            this.carReportTableBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.infosys202321DataSet);

        }

        private void dbConnection() {
            // TODO: このコード行はデータを 'infosys202321DataSet.CarReportTable' テーブルに読み込みます。必要に応じて移動、または削除をしてください。
            this.carReportTableTableAdapter.Fill(this.infosys202321DataSet.CarReportTable);
            dgvCarReports.ClearSelection();//選択解除

            foreach (var item in infosys202321DataSet.CarReportTable) {
                setCbAuther(item.Auther);
                setCbCarName(item.CarName);
            }
        }

        private void 接続OToolStripMenuItem_Click(object sender, EventArgs e) {
            dbConnection();
        }

        private void btAutherBottan_Click(object sender, EventArgs e) {
            carReportTableTableAdapter.FillByAuther(this.infosys202321DataSet.CarReportTable, tbAutherSarch.Text);
        }

        private void btCarNameBottan_Click(object sender, EventArgs e) {
            carReportTableTableAdapter.FillByCarName(this.infosys202321DataSet.CarReportTable, tbCarNameSarch.Text);
        }

        private void btDayBottan_Click(object sender, EventArgs e) {
            carReportTableTableAdapter.FillByDate2(this.infosys202321DataSet.CarReportTable ,tbDaySarch.Text,tbDaySarch2.Text);
        }

        private void btReset_Click(object sender, EventArgs e) {
            carReportTableTableAdapter.Fill(this.infosys202321DataSet.CarReportTable);
        }
    }
}
