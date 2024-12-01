using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZH2Konzi
{
    public class Person : INotifyPropertyChanged
    {
        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                //if (PropertyChanged != null)
                var name = nameof(FirstName);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FullName)));
            }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LastName)));
            }
        }

        public int Age { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
