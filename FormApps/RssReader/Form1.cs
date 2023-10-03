using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RssReader {
    public partial class Form1 : Form {
        //管理用データ
        List<ItemData> ItemDatas = new List<ItemData>();

        public Form1() {
            InitializeComponent();

        }

        private void btGet_Click(object sender, EventArgs e) {
            using (var wc = new WebClient()) {
                var url = wc.OpenRead(tbUrl.Text);
                XDocument xdoc = XDocument.Load(url);

                //List(ItemDatas)にTitleとLinkを格納
                ItemDatas = xdoc.Root.Descendants("item")
                                          .Select(x => new ItemData {
                                              Title = (string)x.Element("title"),
                                              Link = (string)x.Element("link")
                                          }).ToList();

                //タイトル出力
                foreach (var item in ItemDatas) {
                    lbRssTitle.Items.Add(item.Title);
                }
            }
        }

        private void lbRssTitle_Click(object sender, EventArgs e) {
            wbBrowser.Navigate(ItemDatas[lbRssTitle.SelectedIndex].Link);
        }
    }
}
