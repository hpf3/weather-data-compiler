﻿using System;
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
    /// note, not designed to be efficient, designed to be functional asap
    /// </summary>
    public partial class MainWindow : Window
    {

        public static string cityFile = @"C:\<YOUR PATH HERE>\data\Cities.csv"; //source:https://simplemaps.com/data/us-cities   remove all columns(via excel or editor of choice) except: city,state_id,county_name,lat,lng
        public static string stationFile = @"C:\<YOUR PATH HERE>\data\Stations.xml"; //generated by step1
        public static string endFile = @"C:\<YOUR PATH HERE>\data\WeatherData.xml"; //generated by step2
        public static string folderPath = @"C:\<YOUR PATH HERE>\weatherData";//source:https://w1.weather.gov/xml/current_obs/#XML All current XML files(or throw stations of choice into a folder), must be a folder and not a zip archive
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
