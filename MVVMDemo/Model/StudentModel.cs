﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;
using System.Threading.Tasks;

namespace MVVMDemo.Model
{
    
        public class Student : INotifyPropertyChanged
        {
            private string firstName;
            private string lastName;

            public string FirstName
            {
                get
                {
                    return firstName;
                }

                set
                {
                    if (firstName != value)
                    {
                        firstName = value;
                        RaisePropertyChanged("FirstName");
                        RaisePropertyChanged("FullName");
                    }
                }
            }

            public string LastName
            {
                get { return lastName; }

                set
                {
                    if (lastName != value)
                    {
                        lastName = value;
                        RaisePropertyChanged("LastName");
                        RaisePropertyChanged("FullName");
                    }
                }
            }

            public string FullName
            {
                get
                {
                    return firstName + " " + lastName;
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            private void RaisePropertyChanged(string property)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(property));
                }
            }
        }
    
}
