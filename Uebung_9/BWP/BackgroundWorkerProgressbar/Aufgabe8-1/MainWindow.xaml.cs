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

namespace Aufgabe8_1
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private enum Position
		{
			Oben,
			Mittig,
			Unten
		}

		List<KeyValuePair<Position, int[]>> questionMarkPositions;

		public MainWindow()
		{
			InitializeComponent();
			int[] oben = new int[] { 0, 1 };
			int[] mittig = new int[] { 1, 1 };
			int[] unten = new int[] { 2, 1 };

			questionMarkPositions = new List<KeyValuePair<Position, int[]>>()
			{
				new KeyValuePair<Position, int[]>(Position.Oben, oben),
				new KeyValuePair<Position, int[]>(Position.Mittig, mittig),
				new KeyValuePair<Position, int[]>(Position.Unten, unten)
			};
		}

		private void btn_Click(object sender, RoutedEventArgs e)
		{
			Button btn = (Button)sender;
			if (btn == btn_gelb)
				btn_questionMark.Background = Brushes.Yellow;
			else if (btn == btn_gruen)
				btn_questionMark.Background = Brushes.Green;
			else if (btn == btn_red)
				btn_questionMark.Background = Brushes.Red;
			else if (btn == btn_oben)
				setQuestionMarkPosition(Position.Oben);
			else if (btn == btn_mitte)
				setQuestionMarkPosition(Position.Mittig);
			else if (btn == btn_unten)
				setQuestionMarkPosition(Position.Unten);
		}

		private void setQuestionMarkPosition(Position position)
		{
			IEnumerable<int[]> questionMarkPosition = from pos in questionMarkPositions where pos.Key == position select pos.Value;
			int[][] array = questionMarkPosition.ToArray();
			int row = array[0][0];
			int column = array[0][1];
			btn_questionMark.SetValue(Grid.RowProperty, row);
			btn_questionMark.SetValue(Grid.ColumnProperty, column);
		}
	}
}
