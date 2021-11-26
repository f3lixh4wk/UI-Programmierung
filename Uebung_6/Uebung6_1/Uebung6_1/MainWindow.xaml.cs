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

namespace Uebung6_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void OnWindow(object sender, RoutedEventArgs e)
        {
            TextBoxOutput.AppendText("Bubbling auf Window \n");

        }

        private void OnMainGrid(object sender, RoutedEventArgs e)
        {
            TextBoxOutput.AppendText("Bubbling auf MainGrid \n");

        }
        private void OnGridButtons(object sender, RoutedEventArgs e)
        {
            TextBoxOutput.AppendText("Bubbling auf GridButtons \n");

        }

        private void OnButton(object sender, RoutedEventArgs e)
        {
            TextBoxOutput.AppendText("Bubbling auf Button \n");

        }
    }
}
