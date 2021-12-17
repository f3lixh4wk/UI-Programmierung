using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonModel
{
    public class MainViewModel : Person
    {
        private Personenliste _perslst;

        public Personenliste Perslst
        {
            get { return _perslst; }
            set
            {
                _perslst = value;
                OnPropertyChanged();
            }
        }

        private Person _selectedPerson;

        public Person SelectedPerson
        {
            get { return _selectedPerson; }
            set
            {
                _selectedPerson = value;
                OnPropertyChanged();

            }
        }

        private string _personHinzufügenVorname;

        public string PersonHinzufügenVorname
        {
            get { return _personHinzufügenVorname; }
            set 
            {
                _personHinzufügenVorname = value;
                OnPropertyChanged();
            }
        }

        private string _personHinzufügenNachname;

        public string PersonHinzufügenNachname
        {
            get { return _personHinzufügenNachname; }
            set 
            { 
                _personHinzufügenNachname = value;
                OnPropertyChanged();
            }
            
        }

        private string _personHinzufügenGeburtsdatum;

        public string PersonHinzufügenGeburtsdatum
        {
            get { return _personHinzufügenGeburtsdatum; }
            set 
            {
                _personHinzufügenGeburtsdatum = value;
                OnPropertyChanged();
            }
        }


        public MainViewModel()
        {
            _perslst = new Personenliste();
        }


    }
}
