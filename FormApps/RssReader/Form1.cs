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
            lbRssTitle.Enabled = false;

        }

        private void btGet_Click(object sender, EventArgs e) {
            try {
                if (tbUrl.TextLength != 0) {
                    lbRssTitle.Items.Clear();//クリアしてから出力
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
                        lbRssTitle.Enabled = true;
                        tberror.Text = null;
                    }
                }
            } catch (System.Net.WebException) {
                tberror.Text = "正しい値を入力してください";
                tbUrl.Text = null;
            }
        }

        private void lbRssTitle_Click(object sender, EventArgs e) {
            wbBrowser.Navigate(ItemDatas[lbRssTitle.SelectedIndex].Link);
        }

        

        
    }
    }


        
    
