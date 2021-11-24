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
using System.Windows.Shapes;

namespace Aufgabe7_1
{
	/// <summary>
	/// Interaktionslogik für SuchenWindow.xaml
	/// </summary>
	public partial class SuchenWindow : Window
	{
		public SuchenWindow()
		{
			InitializeComponent();
			btnSuchen.IsEnabled = false;

			tbSuchen.Focus();
			tbSuchen.TextChanged += new TextChangedEventHandler(tbSuchen_textChanged);
		}

		private void tbSuchen_textChanged(object sender, System.EventArgs e)
		{
			btnSuchen.IsEnabled = tbSuchen.Text.Length != 0;
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			DialogResult = true;
			Suchbegriff = tbSuchen.Text;
		}

		public string Suchbegriff { get; set; }
	}
}
