using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using LiveCharts.Wpf.Charts.Base;
using Raidillon.Client;
using Raidillon.Client.F12019;
using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Linq;
using System.Windows.Media;
using System.Collections.Generic;
using System.Diagnostics;

namespace Raidillon.Viewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        private double _axisMax;
        private double _axisMin;
        private ZoomingOptions _zoomingMode;

        public MainWindow()
        {
            InitializeComponent();

            var mapper = Mappers.Xy<ChannelPacket>()
                .X(packet => packet.Timestamp)   //use DateTime.Ticks as X
                .Y(packet => packet.Value);           //use the value property as Y

            Charting.For<ChannelPacket>(mapper);

            DateTimeFormatter = value => TimeSpan.FromSeconds(value).ToString(@"mm\:ss\:fff");

            //AxisStep forces the distance between each separator in the X axis
            AxisStep = 1;
            //AxisUnit forces lets the axis know that we are plotting seconds
            //this is not always necessary, but it can prevent wrong labeling
            AxisUnit = .01;

            ZoomingMode = ZoomingOptions.X;

            SetAxisLimits(0);

            SeriesCollection = new SeriesCollection();

            var connection = new F12019Connection();

            var stream = connection.StartConnection(20777);

            var chartValues = new Dictionary<string, ChartValues<ChannelPacket>>();
            int i = 0;
            MainChart.AxisY = new AxesCollection();

            foreach (var item in ChannelDefinitions.Channels)
            {

                MainChart.AxisY.Add(new Axis()
                {
                    MinValue = item.Range.Item1,
                    MaxValue = item.Range.Item2,
                    ShowLabels = false
                });

                var series = new LineSeries()
                {
                    PointGeometry = null,
                    LineSmoothness = 0,
                    Values = new ChartValues<ChannelPacket>(),
                    Fill = Brushes.Transparent,
                    Stroke = Brushes.Red,
                    ScalesYAt = i++,
                };
                
                chartValues[item.Name] = (ChartValues<ChannelPacket>) series.Values;

                SeriesCollection.Add(series);
            }


            stream.Subscribe(o =>
            {
                foreach (var item in o.Where(p=>p.VehicleId.Equals(0)))
                {
                    if (chartValues.TryGetValue(item.Name, out var v))
                    {
                        v.Add(item);
                        SetAxisLimits(item.Timestamp);
                    }
                }
            });

            //The next code simulates data changes every 300 ms


            DataContext = this;
        }

        public SeriesCollection SeriesCollection { get; set; }
        public Func<double, string> DateTimeFormatter { get; set; }
        public double AxisStep { get; set; }
        public double AxisUnit { get; set; }
        public CartesianChart cartesianChart { get; set; }

        public double AxisMax
        {
            get { return _axisMax; }
            set
            {
                _axisMax = value;
                OnPropertyChanged("AxisMax");
            }
        }
        public double AxisMin
        {
            get { return _axisMin; }
            set
            {
                _axisMin = value;
                OnPropertyChanged("AxisMin");
            }
        }

        private void SetAxisLimits(double now)
        {
            AxisMax = now + 1;
            AxisMin = now - 20;
        }

        private void SetAxisLimits(DateTime now)
        {
            AxisMax = now.Ticks + TimeSpan.FromSeconds(1).Ticks; // lets force the axis to be 1 second ahead
            AxisMin = now.Ticks - TimeSpan.FromSeconds(30).Ticks; // and 8 seconds behind
        }


        public ZoomingOptions ZoomingMode
        {
            get { return _zoomingMode; }
            set
            {
                _zoomingMode = value;
                OnPropertyChanged();
            }
        }

        private void InjectStopOnClick(object sender, RoutedEventArgs e)
        {

        }

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
