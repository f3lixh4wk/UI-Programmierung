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

namespace UIP_Übung_6._2
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void OnWindowPrev(object sender, RoutedEventArgs e)
        {
            TextBoxOutput.AppendText("Tunneling auf WindowPreview \n");

        }

        private void OnMainGridPrev(object sender, RoutedEventArgs e)
        {
            TextBoxOutput.AppendText("Tunneling auf MainGridPreview \n");

        }
        private void OnGridButtonsPrev(object sender, RoutedEventArgs e)
        {
            TextBoxOutput.AppendText("Tunneling auf GridButtonPriew \n");

        }

        private void OnButtonPrev(object sender, RoutedEventArgs e)
        {
            TextBoxOutput.AppendText("Tunneling auf ButtonPreview \n");

        }
    }
}
