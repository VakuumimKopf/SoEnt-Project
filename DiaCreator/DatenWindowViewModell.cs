using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DiaCreator.BaseClasses;

namespace DiaCreator
{
    public class DatenWindowViewModell : BaseViewModell
    {
        private readonly string diagrammtyp; 
        
        private ObservableCollection<DSetViewModell>? dsetitems;
        public ObservableCollection<DSetViewModell>? DSetItems
        {
            get => dsetitems; 
            set 
            {
                if (dsetitems != value)
                {
                    dsetitems = value;
                    OnPropertyChanged("DSetItems");
                }
            } 
        }

        private ConfigViewModell? config;
        public ConfigViewModell? Config
        {
            get => config;
            set
            {
                if (config != value)
                {
                    config = value;
                    OnPropertyChanged("Config");
                }
            }
        }

        public ICommand Darstellen {  get; set; }

        public DatenWindowViewModell(string Diagrammtyp) 
        {
            diagrammtyp = Diagrammtyp;
            Config = App.CurrentBuilder.CreateConfigView(Diagrammtyp);

            var DSets = App.CurrentDHolder.GetAllData();
            var DSetViewModells = DSets.Select(m => new DSetViewModell(m.Name, m.Id, m.Data, Config));
            DSetItems = new ObservableCollection<DSetViewModell>(DSetViewModells);

            Darstellen = new RelayCommand(parameter => DiaDarstellen());
        }

        private void DiaDarstellen() 
        {
            var diabuilder = App.CurrentBuilder.CreateDiaBuilder(diagrammtyp);
            diabuilder.Call(config);
        }
    }
}
