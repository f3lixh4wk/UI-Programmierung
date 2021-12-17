using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace PersonModel
{ 
    public class Person : INotifyPropertyChanged
    {
        private string firstname;
        private string lastname;
        private string birthdate;

        public event PropertyChangedEventHandler PropertyChanged;

        public Person()
        {
        }
        public Person(string first, string last, string bdate)
        {
            this.firstname = first;
            this.lastname = last;
            this.birthdate = bdate;
        }
        
      

        public string FirstName
        {
            get { return firstname; }
            set
            {
                if (value == firstname)
                    return;
                firstname = value;
                OnPropertyChanged();
            }
        }
        public string LastName
        {
            get { return lastname; }
            set
            {
                if (value == lastname)
                    return;
                lastname = value;
                OnPropertyChanged();
            }
        }
        public string BirthDate
        {
            get { return birthdate; }
            set
            {
                if (value == birthdate)
                    return;
                birthdate = value;
                OnPropertyChanged();
            }
        }

        public void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if(PropertyChanged != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));

            }
        }
    }

    public class Personenliste : ObservableCollection<Person>
    {
        public Personenliste():base()
        {
            Add(new Person("William", "Shatner", "22.03.1931"));
            Add(new Person("Maxi", "Musterfrau", "20.01.2001"));
            Add(new Person("Leonard", "Nimoy", "26.03.1931"));
            Add(new Person("Max", "Mustermann", "20.10.2010"));
            
        }
    }
}

