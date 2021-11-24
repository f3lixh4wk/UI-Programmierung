using Microsoft.Win32; // Für SaveFileDialog und OpenFileDialog
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Aufgabe7_1
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			setzeMarkierungZurueck();
			tb.Focus();
		}

		private void OnSpeichern(object sender, RoutedEventArgs e)
		{
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.FileName = "Document"; // Default file name
			dlg.DefaultExt = ".txt";
			dlg.Filter = "Text Dokumente|*.txt";

			bool? result = dlg.ShowDialog();
			if(result == true)
			{
				using (StreamWriter writer = new StreamWriter(new FileStream(dlg.FileName, FileMode.OpenOrCreate), Encoding.UTF8))
				{
					writer.Write(tb.Text);
				}
			}
		}

		private void OnLaden(object sender, RoutedEventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = "Text Dokumente|*.txt";

			bool? result = dlg.ShowDialog();
			if (result == true)
			{
				using (StreamReader reader = new StreamReader(new FileStream(dlg.FileName, FileMode.Open), Encoding.UTF8))
				{
					tb.Text = reader.ReadToEnd();
					setzeMarkierungZurueck();
				}
			}
		}

		private void OnSuchen(object sender, RoutedEventArgs e)
		{
			SuchenWindow suchenDialog = new SuchenWindow();
			suchenDialog.Owner = this;
			suchenDialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
			setzeMarkierungZurueck();

			if (suchenDialog.ShowDialog() == true)
			{
				// Suchen ausführen
				string suchbegriff = suchenDialog.Suchbegriff;
				int pos = tb.Text.IndexOf(suchbegriff);
				if (pos != -1)
				{
					tb.SelectionStart = pos;
					tb.SelectionLength = suchbegriff.Length;
				}
			}
		}

		private void setzeMarkierungZurueck()
		{
			tb.SelectionStart = tb.Text.Length;
			tb.SelectionLength = 0;
		}

		private void OnBeenden(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
	}
}
