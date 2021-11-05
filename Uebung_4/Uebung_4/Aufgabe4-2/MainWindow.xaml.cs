using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Threading;

namespace Aufgabe4_2
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			dispatcherTimer.Tick += dispatcherTimer_Tick;
			cb_WeckerGestellt.IsEnabled = false;
		}

		public DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				if (dispatcherTimer.IsEnabled)
				{
					string message = "Möchten Sie den Wecker neu starten?";
					string caption = "Wecker läuft bereits";
					MessageBoxButton buttons = MessageBoxButton.YesNo;

					MessageBoxResult result = MessageBox.Show(message, caption, buttons);
					if (result == MessageBoxResult.Yes)
					{
						dispatcherTimer.Stop();
						dispatcherTimer.IsEnabled = false;
						cb_WeckerGestellt.IsChecked = false;
					}
					return;
				}

				int sekunde = Convert.ToInt32(tb_Sekunde.Text);
				int minute = Convert.ToInt32(tb_Minute.Text);
				int stunde = Convert.ToInt32(tb_Stunde.Text);

				dispatcherTimer.Interval = new TimeSpan(stunde, minute, sekunde);
				dispatcherTimer.Start();

				cb_WeckerGestellt.IsChecked = true;
			}
			catch (SystemException ex)
			{
				// Initializes the variables to pass to the MessageBox.Show method.
				string message = "Geben sie bitte ganzzahlige Werte über 0 an.";
				string caption = "Ungültige Eingabe";
				MessageBoxButton buttons = MessageBoxButton.OK;
				// Displays the MessageBox.
				MessageBox.Show(message, caption, buttons);
			}
		}

		// Quelle:
		//https://docs.microsoft.com/de-de/dotnet/api/system.windows.threading.dispatchertimer?view=windowsdesktop-5.0

		//  System.Windows.Threading.DispatcherTimer.Tick handler
		//
		//  Updates the current seconds display and calls
		//  InvalidateRequerySuggested on the CommandManager to force 
		//  the Command to raise the CanExecuteChanged event.
		private void dispatcherTimer_Tick(object sender, EventArgs e)
		{
			dispatcherTimer.IsEnabled = false;
			cb_WeckerGestellt.IsChecked = false;
			MessageBox.Show("Wecker klingelt", "beep beep beep");
			dispatcherTimer.Stop();
		}

		private void mainWindow_Closing(object sender, CancelEventArgs e)
		{
			if(dispatcherTimer.IsEnabled)
			{
				string message = "Möchten Sie das Programm wirklich beenden?";
				string caption = "Programm beenden?";
				MessageBoxButton buttons = MessageBoxButton.YesNo;

				MessageBoxResult result = MessageBox.Show(message, caption, buttons);
				if (result == MessageBoxResult.No)
				{
					e.Cancel = true;
				}
			}
		}
	}
}
