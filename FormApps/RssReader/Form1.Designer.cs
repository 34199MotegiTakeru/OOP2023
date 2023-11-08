
namespace RssReader {
    partial class Form1 {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            this.tbUrl = new System.Windows.Forms.TextBox();
            this.btGet = new System.Windows.Forms.Button();
            this.lbRssTitle = new System.Windows.Forms.ListBox();
            this.wbBrowser = new System.Windows.Forms.WebBrowser();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.経済 = new System.Windows.Forms.RadioButton();
            this.国際 = new System.Windows.Forms.RadioButton();
            this.国内 = new System.Windows.Forms.RadioButton();
            this.スポーツ = new System.Windows.Forms.RadioButton();
            this.tberror = new System.Windows.Forms.TextBox();
            this.お気に入り = new System.Windows.Forms.Button();
            this.lb = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbUrl
            // 
            this.tbUrl.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tbUrl.Location = new System.Drawing.Point(12, 12);
            this.tbUrl.Name = "tbUrl";
            this.tbUrl.Size = new System.Drawing.Size(530, 31);
            this.tbUrl.TabIndex = 0;
            // 
            // btGet
            // 
            this.btGet.Location = new System.Drawing.Point(587, 12);
            this.btGet.Name = "btGet";
            this.btGet.Size = new System.Drawing.Size(59, 31);
            this.btGet.TabIndex = 1;
            this.btGet.Text = "取得";
            this.btGet.UseVisualStyleBackColor = true;
            this.btGet.Click += new System.EventHandler(this.btGet_Click);
            // 
            // lbRssTitle
            // 
            this.lbRssTitle.FormattingEnabled = true;
            this.lbRssTitle.ItemHeight = 12;
            this.lbRssTitle.Location = new System.Drawing.Point(58, 141);
            this.lbRssTitle.Name = "lbRssTitle";
            this.lbRssTitle.Size = new System.Drawing.Size(257, 256);
            this.lbRssTitle.TabIndex = 2;
            this.lbRssTitle.Click += new System.EventHandler(this.lbRssTitle_Click);
            // 
            // wbBrowser
            // 
            this.wbBrowser.Location = new System.Drawing.Point(437, 80);
            this.wbBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbBrowser.Name = "wbBrowser";
            this.wbBrowser.ScriptErrorsSuppressed = true;
            this.wbBrowser.Size = new System.Drawing.Size(560, 592);
            this.wbBrowser.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.経済);
            this.groupBox1.Controls.Add(this.国際);
            this.groupBox1.Controls.Add(this.国内);
            this.groupBox1.Controls.Add(this.スポーツ);
            this.groupBox1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox1.Location = new System.Drawing.Point(58, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(257, 86);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "タイトル一覧";
            // 
            // 経済
            // 
            this.経済.AutoSize = true;
            this.経済.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.経済.Location = new System.Drawing.Point(37, 48);
            this.経済.Name = "経済";
            this.経済.Size = new System.Drawing.Size(67, 23);
            this.経済.TabIndex = 3;
            this.経済.TabStop = true;
            this.経済.Text = "経済";
            this.経済.UseVisualStyleBackColor = true;
            this.経済.CheckedChanged += new System.EventHandler(this.経済_CheckedChanged);
            // 
            // 国際
            // 
            this.国際.AutoSize = true;
            this.国際.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.国際.Location = new System.Drawing.Point(143, 19);
            this.国際.Name = "国際";
            this.国際.Size = new System.Drawing.Size(67, 23);
            this.国際.TabIndex = 2;
            this.国際.TabStop = true;
            this.国際.Text = "国際";
            this.国際.UseVisualStyleBackColor = true;
            this.国際.CheckedChanged += new System.EventHandler(this.国際_CheckedChanged);
            // 
            // 国内
            // 
            this.国内.AutoSize = true;
            this.国内.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.国内.Location = new System.Drawing.Point(37, 19);
            this.国内.Name = "国内";
            this.国内.Size = new System.Drawing.Size(67, 23);
            this.国内.TabIndex = 1;
            this.国内.TabStop = true;
            this.国内.Text = "国内";
            this.国内.UseVisualStyleBackColor = true;
            this.国内.CheckedChanged += new System.EventHandler(this.国内_CheckedChanged);
            // 
            // スポーツ
            // 
            this.スポーツ.AutoSize = true;
            this.スポーツ.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.スポーツ.Location = new System.Drawing.Point(143, 48);
            this.スポーツ.Name = "スポーツ";
            this.スポーツ.Size = new System.Drawing.Size(92, 23);
            this.スポーツ.TabIndex = 0;
            this.スポーツ.TabStop = true;
            this.スポーツ.Text = "スポーツ";
            this.スポーツ.UseVisualStyleBackColor = true;
            this.スポーツ.CheckedChanged += new System.EventHandler(this.スポーツ_CheckedChanged);
            // 
            // tberror
            // 
            this.tberror.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tberror.Location = new System.Drawing.Point(700, 34);
            this.tberror.Name = "tberror";
            this.tberror.Size = new System.Drawing.Size(297, 23);
            this.tberror.TabIndex = 6;
            // 
            // お気に入り
            // 
            this.お気に入り.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.お気に入り.Location = new System.Drawing.Point(342, 446);
            this.お気に入り.Name = "お気に入り";
            this.お気に入り.Size = new System.Drawing.Size(69, 34);
            this.お気に入り.TabIndex = 7;
            this.お気に入り.Text = "登録";
            this.お気に入り.UseVisualStyleBackColor = true;
            // 
            // lb
            // 
            this.lb.FormattingEnabled = true;
            this.lb.ItemHeight = 12;
            this.lb.Location = new System.Drawing.Point(53, 437);
            this.lb.Name = "lb";
            this.lb.Size = new System.Drawing.Size(262, 232);
            this.lb.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 718);
            this.Controls.Add(this.lb);
            this.Controls.Add(this.お気に入り);
            this.Controls.Add(this.tberror);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.wbBrowser);
            this.Controls.Add(this.lbRssTitle);
            this.Controls.Add(this.btGet);
            this.Controls.Add(this.tbUrl);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbUrl;
        private System.Windows.Forms.Button btGet;
        private System.Windows.Forms.ListBox lbRssTitle;
        private System.Windows.Forms.WebBrowser wbBrowser;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton スポーツ;
        private System.Windows.Forms.RadioButton 経済;
        private System.Windows.Forms.RadioButton 国際;
        private System.Windows.Forms.RadioButton 国内;
        private System.Windows.Forms.TextBox tberror;
        private System.Windows.Forms.Button お気に入り;
        private System.Windows.Forms.ListBox lb;
    }
}

