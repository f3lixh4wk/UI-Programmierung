using PersonModel;
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

namespace Gruppe01_Uebung10
{
    /// <summary>
    /// Interaktionslogik für winBenutzerHinzufügen.xaml
    /// </summary>
    public partial class winBenutzerHinzufügen : Window
    {
        MainViewModel _mainViewModel;
        public winBenutzerHinzufügen(MainViewModel mainviewmodel)
        {
            DataContext = mainviewmodel;
            _mainViewModel = mainviewmodel;
            InitializeComponent();

        }

        private void btn_Anlegen_Click(object sender, RoutedEventArgs e)
        {
            if (DateTime.TryParse(_mainViewModel.PersonHinzufügenGeburtsdatum, out DateTime dDate))
            {
                String.Format("{0:dd.MM.yyyy}", dDate);

                Person newpers = new Person(_mainViewModel.PersonHinzufügenVorname, _mainViewModel.PersonHinzufügenNachname, _mainViewModel.PersonHinzufügenGeburtsdatum);
                _mainViewModel.Perslst.Add(newpers);
                this.Close();
                _mainViewModel.PersonHinzufügenVorname = string.Empty;
                _mainViewModel.PersonHinzufügenNachname = string.Empty;
                _mainViewModel.PersonHinzufügenGeburtsdatum = string.Empty;
            }
            else
            {
                MessageBox.Show("Bitte beachten Sie das korrekte Format des Datums [dd.MM.yyyy]", "Information", MessageBoxButton.OK, MessageBoxImage.Error);
              
            }
        }

        private void btn_Abbruch_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            _mainViewModel.PersonHinzufügenVorname = string.Empty;
            _mainViewModel.PersonHinzufügenNachname = string.Empty;
            _mainViewModel.PersonHinzufügenGeburtsdatum = string.Empty;
        }
    }
}
