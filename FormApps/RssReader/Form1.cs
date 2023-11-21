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

        Dictionary<string, string> dict = new Dictionary<string, string>();

        class favoriteSet {
            public string Key { get; set; }
            public string Value { get; set; }

            public favoriteSet(string Key, string Value) {
                this.Key = Key;
                this.Value = Value;
            }

            public override string ToString() {
                return Value;
            }
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
                else {
                    tberror.Text = "URLが入力されていません。";
                }
            } catch (System.Net.WebException) {
                tberror.Text = "正しい値を入力してください。";
                tbUrl.Text = null;
            }
        }

        private void lbRssTitle_Click(object sender, EventArgs e) {
            wbBrowser.Navigate(ItemDatas[lbRssTitle.SelectedIndex].Link);
            tbfUrl.Text = ItemDatas[lbRssTitle.SelectedIndex].Link.ToString();
            tbfName.Text = ItemDatas[lbRssTitle.SelectedIndex].Title.ToString();
        }

        private void 国内_CheckedChanged(object sender, EventArgs e) {
            tbUrl.Text = "https://news.yahoo.co.jp/rss/topics/domestic.xml";
            RadioButton("https://news.yahoo.co.jp/rss/topics/domestic.xml");
        }

        private void 国際_CheckedChanged(object sender, EventArgs e) {
            tbUrl.Text = "https://news.yahoo.co.jp/rss/topics/world.xml";
            RadioButton("https://news.yahoo.co.jp/rss/topics/domestic.xml");
        }

        private void 経済_CheckedChanged(object sender, EventArgs e) {
            tbUrl.Text = "https://news.yahoo.co.jp/rss/topics/world.xml";
            RadioButton("https://news.yahoo.co.jp/rss/topics/domestic.xml");

        }

        private void スポーツ_CheckedChanged(object sender, EventArgs e) {
            tbUrl.Text = "https://news.yahoo.co.jp/rss/topics/sports.xml";
            RadioButton("https://news.yahoo.co.jp/rss/topics/domestic.xml");
        }

        private void お気に入り_Click(object sender, EventArgs e) {
            if (dict.ContainsKey(tbfUrl.Text) || dict.ContainsKey(tbfName.Text)) {
                tberror.Text = "すでに登録されています。";
            }
            else {
                if (tbfName.Text != "" && tbfUrl.Text != "") {
                    favoriteSet f = new favoriteSet(tbfUrl.Text, tbfName.Text);
                    cbfFavorite.Items.Add(f);
                    dict.Add(tbfUrl.Text, tbfName.Text);
                    tbfName.Text = null;
                    tbfUrl.Text = null;
                    tberror.Text = null;
                }
                else {
                    tberror.Text = "登録できる項目がありません。";
                }
            }
        }

        private void cbfFavorite_SelectedIndexChanged(object sender, EventArgs e) {
            favoriteSet c = (favoriteSet)cbfFavorite.SelectedItem;
            wbBrowser.Navigate(c.Key);
        }

        private void お気に入り削除_Click(object sender, EventArgs e) {
            try {
                if (cbfFavorite.Items.Count != 0) {
                    favoriteSet favorite = (favoriteSet)cbfFavorite.SelectedItem;
                    dict.Remove(favorite.Key);
                    cbfFavorite.Items.RemoveAt(cbfFavorite.SelectedIndex);
                    wbBrowser.DocumentText = "";
                    cbfFavorite.Text = "";
                    tberror.Text = "項目が削除されました。";
                    bool b = dict.Remove(cbfFavorite.SelectedIndex.ToString());
                    //dict.Remove(ItemDatas[cbfFavorite.SelectedIndex].Link);
                }
                else {
                    tberror.Text = "削除できる項目はありません。";
                }
            }
            catch (System.ArgumentOutOfRangeException) {
                tberror.Text = "削除する項目が選択されていません。";
            }
        }

        private void RadioButton(string Url) {
            lbRssTitle.Items.Clear();//クリアしてから出力
            using (var wc = new WebClient()) {
                var url = wc.OpenRead(Url);
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
    }
}  
