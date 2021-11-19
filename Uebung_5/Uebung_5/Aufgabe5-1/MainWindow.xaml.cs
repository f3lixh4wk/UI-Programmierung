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

namespace Aufgabe5_1
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			tb_rechnung.IsEnabled = false;
			operatorEingegeben = false;
			ergebnisBerechnet = false;
		}

		public bool operatorEingegeben;
		public bool ergebnisBerechnet;
		public char currentOperator;

		private void pb_null_Click(object sender, RoutedEventArgs e)
		{
			tb_rechnung.Text = ergebnisBerechnet ? "0" : tb_rechnung.Text + '0';
			ergebnisBerechnet = false;
		}

		private void pb_eins_Click(object sender, RoutedEventArgs e)
		{
			tb_rechnung.Text = ergebnisBerechnet ? "1" : tb_rechnung.Text + '1';
			ergebnisBerechnet = false;
		}

		private void pb_zwei_Click(object sender, RoutedEventArgs e)
		{
			tb_rechnung.Text = ergebnisBerechnet ? "2" : tb_rechnung.Text + '2';
			ergebnisBerechnet = false;
		}

		private void pb_drei_Click(object sender, RoutedEventArgs e)
		{
			tb_rechnung.Text = ergebnisBerechnet ? "3" : tb_rechnung.Text + '3';
			ergebnisBerechnet = false;
		}

		private void pb_vier_Click(object sender, RoutedEventArgs e)
		{
			tb_rechnung.Text = ergebnisBerechnet ? "4" : tb_rechnung.Text + '4';
			ergebnisBerechnet = false;
		}

		private void pb_fuenf_Click(object sender, RoutedEventArgs e)
		{
			tb_rechnung.Text = ergebnisBerechnet ? "5" : tb_rechnung.Text + '5';
			ergebnisBerechnet = false;
		}

		private void pb_sechs_Click(object sender, RoutedEventArgs e)
		{
			tb_rechnung.Text = ergebnisBerechnet ? "6" : tb_rechnung.Text + '6';
			ergebnisBerechnet = false;
		}

		private void pb_sieben_Click(object sender, RoutedEventArgs e)
		{
			tb_rechnung.Text = ergebnisBerechnet ? "7" : tb_rechnung.Text + '7';
			ergebnisBerechnet = false;
		}

		private void pb_acht_Click(object sender, RoutedEventArgs e)
		{
			tb_rechnung.Text = ergebnisBerechnet ? "8" : tb_rechnung.Text + '8';
			ergebnisBerechnet = false;
		}

		private void pb_neun_Click(object sender, RoutedEventArgs e)
		{
			tb_rechnung.Text = ergebnisBerechnet ? "9" : tb_rechnung.Text + '9';
			ergebnisBerechnet = false;
		}

		private void pb_geteilt_Click(object sender, RoutedEventArgs e)
		{
			tb_rechnung.Text = operatorEingegeben ? tb_rechnung.Text : tb_rechnung.Text + '/';
			tb_rechnung.Text = ergebnisBerechnet ? "/" : tb_rechnung.Text;
			currentOperator = operatorEingegeben ? currentOperator : '/';
			operatorEingegeben = true;
			ergebnisBerechnet = false;
		}

		private void pb_mal_Click(object sender, RoutedEventArgs e)
		{
			tb_rechnung.Text = operatorEingegeben ? tb_rechnung.Text : tb_rechnung.Text + '*';
			tb_rechnung.Text = ergebnisBerechnet ? "*" : tb_rechnung.Text;
			currentOperator = operatorEingegeben ? currentOperator : '*';
			operatorEingegeben = true;
			ergebnisBerechnet = false;
		}

		private void pb_minus_Click(object sender, RoutedEventArgs e)
		{
			// Prüfung, ob es sich um ein Vorzeichen und kein Operator handelt
			bool vorzeichen = tb_rechnung.Text == "" 
				|| ergebnisBerechnet 
				|| (tb_rechnung.Text.EndsWith(currentOperator) && !tb_rechnung.Text.EndsWith("--"));
			
			tb_rechnung.Text = operatorEingegeben && !vorzeichen ? tb_rechnung.Text : tb_rechnung.Text + '-';
			tb_rechnung.Text = ergebnisBerechnet ? "-" : tb_rechnung.Text;
			currentOperator = operatorEingegeben ? currentOperator : '-';
			operatorEingegeben = !vorzeichen;
			if(tb_rechnung.Text == "--")
			{
				// Verhindern dass das Minuszeichen zweimal (am Anfang!) eingegeben wird
				tb_rechnung.Text = "-";
				operatorEingegeben = false;
			}
			ergebnisBerechnet = false;
		}
		private void pb_plus_Click(object sender, RoutedEventArgs e)
		{
			tb_rechnung.Text = operatorEingegeben ? tb_rechnung.Text : tb_rechnung.Text + '+';
			tb_rechnung.Text = ergebnisBerechnet ? "+" : tb_rechnung.Text;
			currentOperator = operatorEingegeben ? currentOperator : '+';
			operatorEingegeben = true;
			ergebnisBerechnet = false;
		}

		private void pb_komma_Click(object sender, RoutedEventArgs e)
		{
			tb_rechnung.Text = ergebnisBerechnet ? "," : tb_rechnung.Text + ',';
			ergebnisBerechnet = false;
		}

		private void pb_gleich_Click(object sender, RoutedEventArgs e)
		{
			operatorEingegeben = false;
			ergebnisBerechnet = true;
			string calculationText = tb_rechnung.Text;
			if ((calculationText.StartsWith(currentOperator) && currentOperator != '-') || calculationText.EndsWith(currentOperator))
			{
				tb_rechnung.Text = "Syntaxfehler";
				return;
			}

			string[] subs = calculationText.Split(currentOperator);
			double zahl1 = 0;
			double zahl2 = 0;
			if(subs.Length == 4 && calculationText.StartsWith(currentOperator))
			{
				// zwei Minuszeichen hintereinander eingegeben
				currentOperator = '+';
				zahl1 = Convert.ToDouble(subs.ElementAt(1)) * -1;
				zahl2 = Convert.ToDouble(subs.ElementAt(3));
			}
			else if (subs.Length == 3 && calculationText.StartsWith(currentOperator))
			{
				zahl1 = Convert.ToDouble("-" + subs.ElementAt(1));
				zahl2 = Convert.ToDouble(subs.ElementAt(2));
			}
			else if(subs.Length == 3 && subs.ElementAt(1) == "")
			{
				// zwei Minuszeichen hintereinander eingegeben
				currentOperator = '+';
				zahl1 = Convert.ToDouble(subs.ElementAt(0));
				zahl2 = Convert.ToDouble(subs.ElementAt(2));
			}
			else if(subs.Length == 2 && calculationText.StartsWith(currentOperator))
			{
				tb_rechnung.Text = "Syntaxfehler";
				return;
			}
			else
			{
				subs = subs.Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();
				zahl1 = Convert.ToDouble(subs.First());
				zahl2 = Convert.ToDouble(subs.Last());
			}

			if(currentOperator == '/' && zahl2 == 0)
			{
				tb_rechnung.Text = "Mathem. Fehler";
				return;
			}
				
			double ergebnis = 0;
			switch (currentOperator)
			{
				case '/':
					ergebnis = zahl1 / zahl2;
					break;
				case '*':
					ergebnis = zahl1 * zahl2;
					break;
				case '-':
					ergebnis = zahl1 - zahl2;
					break;
				case '+':
					ergebnis = zahl1 + zahl2;
					break;
				default:
					break;
			}

			tb_rechnung.Text = Convert.ToString(ergebnis);
		}
	}
}
