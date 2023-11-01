using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static ColorChecker.MainWindow;

namespace ColorChecker {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            DataContext = GetColorList();
        }

        //private void setColor() {
        //    var r = byte.Parse(rValue.);
        //    var g = byte.Parse(gValue.);
        //    var b = byte.Parse(bValue.);
        //}

        private void rgbSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            Color c = Color.FromRgb((byte)rSlider.Value, (byte)gSlider.Value, (byte)bSlider.Value);
            colorArea.Background = new SolidColorBrush(c);
        }

        private MyColor[] GetColorList() {
            return typeof(Colors).GetProperties(BindingFlags.Public | BindingFlags.Static)
                .Select(i => new MyColor() { Color = (Color)i.GetValue(null), Name = i.Name }).ToArray();
        }

        public class MyColor {
            public Color Color { get; set; }
            public string Name { get; set; }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var selectColor = (MyColor)((ComboBox)sender).SelectedItem;
            var color = selectColor.Color;
            var name = selectColor.Name;
            colorArea.Background = new SolidColorBrush(color);
            rSlider.Value = (double)color.R;
            gSlider.Value = (double)color.G;
            bSlider.Value = (double)color.B;
        }
        private void stockButton_Click(object sender, RoutedEventArgs e) {

        }

    }
}
