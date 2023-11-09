using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SampleUnitConverter {
    public class MainWindowViewModel :ViewModel{
        private double /*metricValue, imperialValue,*/gramValue,poundValue;

        //プロパティ
        //public double MetricValue {
        //    get { return this.metricValue; }
        //    set {
        //        this.metricValue = value;
        //        this.OnPropertyChanged();
        //    }
        //}
        //public double ImperialValue {
        //    get { return this.imperialValue; }
        //    set {
        //        this.imperialValue = value;
        //        this.OnPropertyChanged();
        //    }
        //}
        public double GramValue {
            get { return this.gramValue; }
            set {
                this.gramValue = value;
                this.OnPropertyChanged();
            }
        }
        public double PoundValue {
            get { return this.poundValue; }
            set {
                this.poundValue = value;
                this.OnPropertyChanged();
            }
        }

        ////上のComboBoxで選択されている値（単位）
        //public MetricUnit CurrentMetricUnit { get; set; }

        ////下のComboBoxで選択されている値（単位）
        //public ImperialUnit CurrentImperialUnit { get; set; }
        ////▲ボタンで呼ばれるコマンド
        //public ICommand ImperialUnitToMetric { get; private set; }

        ////▼ボタンで呼ばれるコマンド
        //public ICommand MetricUnitToImperial { get; private set; }


        
        //上のComboBoxで選択されている値（単位）
        public GramUnit CurrentGramUnit { get; set; }
        //上のComboBoxで選択されている値（単位）
        public PoundUnit CurrentPoundUnit { get; set; }

        //▲ボタンで呼ばれるコマンド
        public ICommand PoundUnitToGram { get; private set; }

        //▼ボタンで呼ばれるコマンド
        public ICommand GramUnitToPound { get; private set; }

        //コンストラクタ
        public MainWindowViewModel() {
            //this.CurrentMetricUnit = MetricUnit.Units.First();
            //this.CurrentImperialUnit = ImperialUnit.Units.First();

         
            this.CurrentGramUnit = GramUnit.Units.First();
            this.CurrentPoundUnit = PoundUnit.Units.First();


            //this.MetricUnitToImperial = new DelegateCommand (
            //    () => this.ImperialValue = this.CurrentImperialUnit.FromMetricUnit(
            //    this.CurrentMetricUnit, this.MetricValue));

            //this.ImperialUnitToMetric = new DelegateCommand(
            //    () => this.MetricValue = this.CurrentImperialUnit.FromMetricUnit(
            //    this.CurrentMetricUnit, this.MetricValue));

            this.PoundUnitToGram = new DelegateCommand(
                () => this.GramValue = this.CurrentGramUnit.FromPoundUnit(
                    this.CurrentPoundUnit, this.PoundValue));

            this.GramUnitToPound = new DelegateCommand(
                () => this.PoundValue = this.CurrentPoundUnit.FromGramUnit(
                    this.CurrentGramUnit, this.GramValue));
        }
    }
}
