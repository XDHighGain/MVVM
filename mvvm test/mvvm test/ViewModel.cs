using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace mvvm_test
{
    class ViewModel : INotifyPropertyChanged
    {
        /////////////
        ////////////some changes
        Model _model;
        public List<string> _ListOfObjects;
        public int _count;
        public string _country;
        public string _information;
        public DateTime _currentDate;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ViewModel()
        {
            _model = new Model();
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    Task.Delay(1000).Wait();
                    CurrentDate = DateTime.Now;
                    OnPropertyChanged();
                }
            });


        }

        public List<string> ListOfObjects
        {
            get
            {
                return _ListOfObjects;
            }
            set
            {
                _ListOfObjects = value;
                OnPropertyChanged();
            }
        }

        public string Country
        {
            get
            {
                return _country;
            }
            set
            {
                
                _country = value;
                ListOfObjects = new List<string>();
                if (ListOfObjects != null )
                {
                    ListOfObjects.Clear();
                    OnPropertyChanged();
                }
                else 
                { 
                    ListOfObjects = new List<string>();
                }
                ListOfObjects.Clear();
                ListOfObjects = _model.GetData(_country);
                if (ListOfObjects.Count() == 0)
                {
                    Information = "Check spelling, no result";
                    ListOfObjects.Clear();
                    OnPropertyChanged();
                }
                else
                {
                    Information = "";
                }

                Count = ListOfObjects.Count();
                OnPropertyChanged();
                
            }
        }

        public int Count
        {
            get 
            { 
                return _count;
            }
            set 
            { 
                _count = value;
                OnPropertyChanged();
            }
        }

        public string Information
        {
            get
            {
                return _information; 
            }
            set 
            { 
                _information = value;
                OnPropertyChanged();
            }
        }


















        public DateTime CurrentDate
        {
            get
            {
                return _currentDate;
            }

            set
            {
                _currentDate = value;
                OnPropertyChanged();
            }
        }


    }





}



