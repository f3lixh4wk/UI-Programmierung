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

namespace Aufgabe5_4
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			btn1.MouseEnter += new MouseEventHandler(btn1_MouseEnter);
			btn1.MouseLeave += new MouseEventHandler(btn1_MouseLeave);
			btn2.MouseEnter += new MouseEventHandler(btn2_MouseEnter);
			btn4.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(btn4_PreviewMouseLeftButtonDown);
			btn4.PreviewMouseLeftButtonUp += new MouseButtonEventHandler(btn4_PreviewMouseLeftButtonUp);
		}
		
		private void btn1_MouseEnter(object sender, System.EventArgs e)
		{
			btn3.Visibility = Visibility.Hidden;
		}
		
		private void btn1_MouseLeave(object sender, System.EventArgs e)
		{
			btn3.Visibility = Visibility.Visible;
		}
		
		private void btn2_MouseEnter(object sender, System.EventArgs e)
		{
			btn3.Visibility = Visibility.Collapsed;
		}

		private void btn3_Click(object sender, RoutedEventArgs e)
		{
			btn1.IsEnabled = !btn1.IsEnabled;
		}

		private void btn4_PreviewMouseLeftButtonDown(object sender, System.EventArgs e)
		{
			btn2.Background = Brushes.Red;
		}
		
		private void btn4_PreviewMouseLeftButtonUp(object sender, System.EventArgs e)
		{
			btn2.Background = Brushes.Green;
		}
	}
}
