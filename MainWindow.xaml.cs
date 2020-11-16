using System;
using System.Collections.Generic;
using System.Linq;
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
using System.IO;

namespace weather_data_compiler
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static string cityFile = @"C:\<YOUR PATH HERE>\data\Cities.csv";
        public static string stationFile = @"C:\<YOUR PATH HERE>\data\Stations.xml";
        public static string endFile = @"C:\<YOUR PATH HERE>\data\WeatherData.xml";
        public static string folderPath = @"C:\<YOUR PATH HERE>\weatherData";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            steps.Step1.Start();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            steps.Step2.Run();
        }

        

    }
}
