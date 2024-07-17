using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaCreator
{
    public class DatenWindowViewModell : BaseViewModell
    {
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

        public DatenWindowViewModell(ConfigViewModell Config_n) 
        {
            var DSets = App.CurrentDHolder.GetAllData();
            var DSetViewModells = DSets.Select(m => new DSetViewModell(m.Name, m.Id, m.Data));
            DSetItems = new ObservableCollection<DSetViewModell>(DSetViewModells);

            Config = Config_n;

        }

    }
}
