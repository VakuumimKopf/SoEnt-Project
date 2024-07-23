using DiaCreator.BaseClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace DiaCreator
{
    public class HeadfestlegungViewModell : BaseViewModell
    {
        private string diagrammtyp;

        private List<string> comboboxitems = new List<string>();
        public IEnumerable<string> ComboboxItems { get { return comboboxitems; } }

        public IEnumerable<string> ComboboxItems1
        {
            get
            {
                return ComboboxItems.Where(x => x != SelectedItem2 && x != SelectedItem3 && x != SelectedItemKat);
            }
        }
        private string _selectedItem1;
        public string SelectedItem1
        {
            get { return _selectedItem1; }
            set
            {
                if (_selectedItem1 != value)
                {
                    _selectedItem1 = value;
                    OnPropertyChanged("SelectedItem1");
                    OnPropertyChanged("ComboboxItems2"); //raise propertychanged to refresh GUI 
                    OnPropertyChanged("ComboboxItems3");
                    OnPropertyChanged("ComboboxItemsKat");

                }
            }
        }

        public IEnumerable<string> ComboboxItems2
        {
            get
            {
                return ComboboxItems.Where(x => x != SelectedItem1 && x != SelectedItem3 && x != SelectedItemKat);
            }
        }
        private string _selectedItem2;
        public string SelectedItem2
        {
            get { return _selectedItem2; }
            set
            {
                if (_selectedItem2 != value)
                {
                    _selectedItem2 = value;
                    OnPropertyChanged("SelectedItem2");
                    OnPropertyChanged("ComboboxItems1"); //raise propertychanged to refresh GUI
                    OnPropertyChanged("ComboboxItems3");
                    OnPropertyChanged("ComboboxItemsKat");

                }
            }
        }
        private string _selectedItem3;
        public string SelectedItem3
        {
            get { return _selectedItem3; }
            set
            {
                if (_selectedItem3 != value)
                {
                    _selectedItem3 = value;
                    OnPropertyChanged("SelectedItem3");
                    OnPropertyChanged("ComboboxItems1"); //raise propertychanged to refresh GUI
                    OnPropertyChanged("ComboboxItems2");
                    OnPropertyChanged("ComboboxItemsKat");

                }
            }
        }

        public IEnumerable<string> ComboboxItems3
        {
            get
            {
                return ComboboxItems.Where(x => x != SelectedItem1 && x != SelectedItem2 && x != SelectedItemKat);
            }
        }

        private string _selectedItemKat;
        public string SelectedItemKat
        {
            get { return _selectedItemKat; }
            set
            {
                if (_selectedItemKat != value)
                {
                    _selectedItemKat = value;
                    OnPropertyChanged("SelectedItemKat");
                    OnPropertyChanged("ComboboxItems1"); //raise propertychanged to refresh GUI
                    OnPropertyChanged("ComboboxItems2");
                    OnPropertyChanged("ComboboxItems3");

                }
            }
        }

        public IEnumerable<string> ComboboxItemsKat
        {
            get
            {
                return ComboboxItems.Where(x => x != SelectedItem1 && x != SelectedItem2 && x != SelectedItem3);
            }
        }
        public event EventHandler OnRequestClose;
        public ICommand ClickBestatigen { get; set; }
        public HeadfestlegungViewModell(string Diagrammtyp)
        {
            diagrammtyp = Diagrammtyp;
            ClickBestatigen = new RelayCommand(parameter => Bestatigen());
      
            foreach(var item in App.CurrentReader.GetTableHead()) 
            {
                comboboxitems.Add(item);
            }
        }
        public void Bestatigen() 
        {
            var list = new List<KeyValuePair<string, int>>();
            if (_selectedItem1 != null)
            {
                list.Add(new KeyValuePair<string, int>(_selectedItem1, 1));
            }
            if (_selectedItem2 != null)
            {
                list.Add(new KeyValuePair<string, int>(_selectedItem2, 1));
            }
            if (_selectedItem3 != null) 
            {
                list.Add(new KeyValuePair<string, int>(_selectedItem3, 1));                
            }
            list.Add(new KeyValuePair<string, int>(_selectedItemKat, 2));

            

            App.CurrentReader.SetBalancedTabelHead(list);
            App.CurrentDHolder.AddDataList(App.CurrentReader.GetFileData());
            var DatenWindow = new DatenWindow();
            DatenWindow.DataContext = new DatenWindowViewModell(diagrammtyp);
            DatenWindow.Show();

            OnRequestClose(this, new EventArgs());
        }
    }
}
