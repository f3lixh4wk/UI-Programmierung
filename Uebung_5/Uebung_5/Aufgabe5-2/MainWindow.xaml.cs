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

namespace Aufgabe5_2
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	
//	<ListBox Width = "500" Height="500">
//		<ListBoxItem>Hallo</ListBoxItem>
//		<ListBoxItem Content = "Tschüss" />
//		< ListBoxItem >
//			< ListBoxItem.Content >
//				<Button Content = "Klick mich" />
//			</ ListBoxItem.Content >
//		</ ListBoxItem >
//		< ListBoxItem >
//			< CheckBox IsChecked="True">
//				<RadioButton>Ein Radio-Button!</RadioButton>
//			</CheckBox>
//		</ListBoxItem>
//		<Button Content = "Es muss nicht immer ein ListBoxItem sein" />
//	</ ListBox >

	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			// <ListBox Width = "500" Height="500">
			ListBox lb = new ListBox();
			lb.Width = 500;
			lb.Height = 500;

			//		<ListBoxItem>Hallo</ListBoxItem>
			ListBoxItem lbi1 = new ListBoxItem();
			lbi1.Content = "Hallo";
			lb.Items.Add(lbi1);

			//		<ListBoxItem Content = "Tschüss" />
			ListBoxItem lbi2 = new ListBoxItem();
			lbi2.Content = "Tschüss";
			lb.Items.Add(lbi2);

			//		< ListBoxItem >
			//			< ListBoxItem.Content >
			//				<Button Content = "Klick mich" />
			//			</ ListBoxItem.Content >
			//		</ ListBoxItem >
			ListBoxItem lbi3 = new ListBoxItem();
			Button btn1 = new Button();
			btn1.Content = "Klick mich";
			lbi3.Content = btn1;
			lb.Items.Add(lbi3);

			//		< ListBoxItem >
			//			< CheckBox IsChecked="True">
			//				<RadioButton>Ein Radio-Button!</RadioButton>
			//			</CheckBox>
			//		</ListBoxItem>
			ListBoxItem lbi4 = new ListBoxItem();
			CheckBox cb = new CheckBox();
			cb.IsChecked = true;
			RadioButton rb = new RadioButton();
			rb.Content = "Ein Radio-Button!";
			cb.Content = rb;
			lb.Items.Add(lbi4);

			//	<Button Content = "Es muss nicht immer ein ListBoxItem sein" />
			Button btn2 = new Button();
			btn2.Content = "Es muss nicht immer ein ListBoxItem sein";
			lb.Items.Add(btn2);
		}
	}
}
