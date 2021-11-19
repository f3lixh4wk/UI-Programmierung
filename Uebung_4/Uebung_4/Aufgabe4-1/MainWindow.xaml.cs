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
using System.Drawing;

namespace Aufgabe4_1
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			textBlock.Text = "Hier könnte ihre Werbung stehen";
		}

		private void rb_Schwarz_Checked(object sender, RoutedEventArgs e)
		{
			textBlock.Foreground = Brushes.Black;
		}

		private void rb_Rot_Checked(object sender, RoutedEventArgs e)
		{
			textBlock.Foreground = Brushes.Red;
		}

		private void rb_Gruen_Checked(object sender, RoutedEventArgs e)
		{
			textBlock.Foreground = Brushes.Green;
		}

		private void rb_TimesNewRoman_Checked(object sender, RoutedEventArgs e)
		{
			textBlock.FontFamily = new FontFamily("Times New Roman");
		}

		private void rb_ComicSansMS_Checked(object sender, RoutedEventArgs e)
		{
			textBlock.FontFamily = new FontFamily("Comic Sans MS");
		}

		private void rb_Arial_Checked(object sender, RoutedEventArgs e)
		{
			textBlock.FontFamily = new FontFamily("Arial");
		}

		private void pb_Übertragen_Click(object sender, RoutedEventArgs e)
		{
			string text = textBox.Text;
			if((bool)cb_Rückwarts.IsChecked)
			{
				char[] charArray = text.ToCharArray();
				Array.Reverse(charArray);
				text = new string(charArray);
			}
			textBlock.Text = text;
		}
	}
}
