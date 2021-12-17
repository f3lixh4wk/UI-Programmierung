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
using System.ComponentModel;
using PersonModel;

namespace Gruppe01_Uebung10
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private Person _person = new Person();
        public MainWindow()
        {
            DataContext = new MainViewModel();
            InitializeComponent();
            ((MainViewModel)DataContext).SelectedPerson = null;


        }

        private void ButtonSort_Click(object sender, RoutedEventArgs e)
        {
            ICollectionView cv = CollectionViewSource.GetDefaultView(((MainViewModel)DataContext).Perslst);
            cv.SortDescriptions.Add(new SortDescription("LastName", ListSortDirection.Ascending));
            tb_info.Text = "Info: Listenitems sortiert!";
            ((MainViewModel)DataContext).SelectedPerson = null;

        }

        private void ButtonNew_Click(object sender, RoutedEventArgs e)
        {
            ((MainViewModel)DataContext).SelectedPerson = null;
            winBenutzerHinzufügen test = new winBenutzerHinzufügen(DataContext as MainViewModel);
            test.Show();
     
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
           
            Person pers = ((MainViewModel)DataContext).SelectedPerson;
         

            if (pers != null)
            {
                if(((MainViewModel)DataContext).Perslst.Remove(pers))
                {
                    tb_info.Text = "Info: Listenitem gelöscht!";
                    ((MainViewModel)DataContext).SelectedPerson = null;
                   
                }

            }
        }

        private void ButtonReset_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Die Liste wird unwiderruflich gelöscht! Möchten Sie fortfahren?", "*WARNUNG*", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No);

            switch (result)
            {
                case MessageBoxResult.Yes:
                    ((MainViewModel)DataContext).Perslst.Clear();
                    ((MainViewModel)DataContext).SelectedPerson = null;
                    tb_info.Text = "Info: Liste zurückgesetzt!";
                    break;
                case MessageBoxResult.No:
                    break;
            }

        }
    }
}
