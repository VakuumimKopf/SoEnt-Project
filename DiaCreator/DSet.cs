using DiaCreator.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;

namespace DiaCreator
{
    public class DSet
    {
        private static int InstanceId = 0;
        private string name;
        public string Name
        {
            get => name;
            set => name = value;
        }
        private int id;
        public int Id
        {
            get => id;
            set => id = value;
        }

        private List<string[]> data = new List<string[]>();
        public List<string[]> Data
        {
            get => data;
        }

        public DSet(string name_n)
        {
            this.name = name_n;
            Id = InstanceId;
            InstanceId = InstanceId + 1;
        }

        public void AddData(string value1, string value2)
        {
            data.Add([value1, value2]);
        }

    }

    public class DSetViewModell : BaseViewModell
    {
        private bool visible = true;

        public string Visibility 
        {
            get
            {
                if (visible) return "Hide";
                else return "Show";
            }
        }
        public string FontStyle 
        {
            get
            {
                if (visible) return "Normal";
                else return "Italic";
            }
        } 
        public bool Visible 
        {
            get => visible;
            set
            {
                visible = value;
                OnPropertyChanged("Visibility");
                OnPropertyChanged("FontStyle");
            }
        }

        private string name;
        public string Name
        {
            get => name;
        }
        private int id;
        public int Id
        {
            get => id;
        }

        private List<string[]> data = new List<string[]>();
        public List<string[]> Data
        {
            get => data;
        }

        public event EventHandler<int> DataChanged;
        public ICommand ClickHide {  get; set; }
        public DSetViewModell(string name_n, int id_n, List<string[]> data_n, ConfigViewModell config) 
        {
            ClickHide = new RelayCommand(parameter => ChangeVisibility());
            this.name = name_n;
            this.id = id_n;
            this.data = data_n;
            DataChanged += config.DSetEvent;
        }
        public void ChangeVisibility()
        {
            Visible = !Visible;
            DataChanged(this, this.Id);
        }
    }
}
