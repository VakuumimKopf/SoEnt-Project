using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;
using DiaCreator.BaseClasses;
using static System.Collections.Specialized.NameObjectCollectionBase;
using static System.Net.Mime.MediaTypeNames;

namespace DiaCreator
{
    public abstract class ConfigViewModell : BaseViewModell
    {
        public List<int> hiddenDSets = new List<int>();
        public abstract void FillUi();
        public abstract Writer GenerateWriter();

        public void DSetEvent(object sender, int id) 
        {
            if(hiddenDSets.Contains(id)) 
            {
                hiddenDSets.Remove(id);
            } else 
            { 
                hiddenDSets.Add(id); 
            }
        }
    }

    public class KreisdiaConfigView : ConfigViewModell
    {
        private string? selectedValue = null;
        public string? SelectedValue
        {
            get => selectedValue;
            set => selectedValue = value;
        }

        private string? selectedAnzeige = null;
        public string? SelectedAnzeige
        {
            get => selectedAnzeige;
            set => selectedAnzeige = value;
        }
        private string? selectedDiagramm = null;
        public string? SelectedDiagramm
        {
            get => selectedDiagramm;
            set => selectedDiagramm = value;
        }
        
        public List<string> KreisCollection { get; set; } = new List<string>();
        public List<string> AnzeigeCollection { get; set; } = new List<string> {"Absolut","Relativ"};
        public KreisdiaConfigView() 
        {
            FillUi();   
        }

        public override void FillUi() 
        {
            foreach (string item in App.CurrentReader.GetValueHead())
            {
                KreisCollection.Add(item);
            }
        }
        public override Writer GenerateWriter()
        {
            return new KreisdiaWriter()
            {
                UsedValue = App.CurrentReader.GetDataIndex(selectedValue),
                Anzeige = selectedAnzeige,
                Pushout = App.CurrentReader.GetHeadElementIndex(selectedDiagramm)

            };
        }


    }

    public class SaulendiaConfigView : ConfigViewModell
    {
        private List<string> saucollection = new List<string>();
        public IEnumerable<string> SauCollection { get => saucollection; }
        public IEnumerable<string> XAchseCollection
        {
            get
            {
                return SauCollection.Where(x => x != SelectedyAchse);
            }
        }
        private string selectedxAchse;
        public string SelectedxAchse
        {
            get => selectedxAchse;
            set
            {
                if (selectedxAchse != value)
                {
                    selectedxAchse = value;
                    OnPropertyChanged("XAchseCollection");
                    OnPropertyChanged("YAchseCollection");
                }
            }
        }
        public IEnumerable<string> YAchseCollection
        {
            get
            {
                return SauCollection.Where(x => x != SelectedxAchse);
            }
        }
        private string selectedyAchse;
        public string SelectedyAchse
        {
            get => selectedyAchse;
            set
            {
                if (selectedyAchse != value)
                {
                    selectedyAchse = value;
                    OnPropertyChanged("XAchseCollection");
                    OnPropertyChanged("YAchseCollection");

                }
            }
        }
        public SaulendiaConfigView() 
        {
            FillUi();
        }

        public override void FillUi()
        {
            foreach (string item in App.CurrentReader.GetValueHead())
            {
                saucollection.Add(item);
            }
        }
        public override Writer GenerateWriter()
        {
            return new SaulendiaWriter()
            {
                ValuexAchse = App.CurrentReader.GetDataIndex(SelectedxAchse),
                ValueyAchse = App.CurrentReader.GetDataIndex(SelectedyAchse),
            };
        }
    }

    public class LiniendiaConfigView : ConfigViewModell 
    {

        private List<string> liniencollection = new List<string>();
        public IEnumerable<string> LinienCollection { get => liniencollection; }
        public IEnumerable<string> XAchseCollection
        {
            get
            {
                return LinienCollection.Where(x => x != SelectedyAchse);
            }
        }
        private string selectedxAchse;
        public string SelectedxAchse
        {
            get => selectedxAchse;
            set
            {
                if (selectedxAchse != value)
                {
                    selectedxAchse = value;
                    OnPropertyChanged("XAchseCollection");
                    OnPropertyChanged("YAchseCollection");
                }
            }
        }
        public IEnumerable<string> YAchseCollection
        {
            get
            {
                return LinienCollection.Where(x => x != SelectedxAchse);
            }
        }
        private string selectedyAchse;
        public string SelectedyAchse
        {
            get => selectedyAchse;
            set
            {
                if (selectedyAchse != value)
                {
                    selectedyAchse = value;
                    OnPropertyChanged("XAchseCollection");
                    OnPropertyChanged("YAchseCollection");

                }
            }
        }

        public LiniendiaConfigView() 
        {
            FillUi();
        }

        public override void FillUi()
        {
            foreach (string item in App.CurrentReader.GetValueHead())
            {
                liniencollection.Add(item);
            }
        }
        public override Writer GenerateWriter()
        {
            return new LiniendiaWriter()
            {
                ValuexAchse = App.CurrentReader.GetDataIndex(SelectedxAchse),
                ValueyAchse = App.CurrentReader.GetDataIndex(SelectedyAchse),
            };
        }
    }
}
