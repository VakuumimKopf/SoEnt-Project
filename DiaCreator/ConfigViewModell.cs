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
        public List<string> DiagrammCollection { get; set; } = new List<string> {"Basic Pie","Pushout","Outside Labels"};
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
            return new KreisdiaWriter();
        }


    }

    public class SaulendiaConfigView : ConfigViewModell
    {
        private string? selectedKategorie = null;
        public string? SelectedKategorie
        {
            get => selectedKategorie;
            set => selectedKategorie = value;
        }
        private string? selectedxAchse = null;
        public string? SelectedxAchse
        {
            get => selectedxAchse;
            set => selectedxAchse = value;
        }
        private string? selectedyAchse = null;
        public string? SelectedyAchse
        {
            get => selectedyAchse;
            set => selectedyAchse = value;
        }
        private string? selectedDiagramm = null;
        public string? SelectedDiagramm
        {
            get => selectedDiagramm;
            set => selectedDiagramm = value;
        }
        public List<string> AnzeigeCollection { get; set; } = new List<string> { "Absolut", "Relativ" };
        public List<string> DiagrammCollection { get; set; } = new List<string> { "Basic Line", "Zooming and panning", "Line smoothness" };
        public List<string> SauCollection { get; set; } = new List<string>();
        public SaulendiaConfigView() 
        {
            FillUi();
        }

        public override void FillUi()
        {
            foreach (string item in App.CurrentReader.GetValueHead())
            {
                SauCollection.Add(item);
            }
        }
        public override Writer GenerateWriter()
        {
            return new SaulendiaWriter();
        }
    }

    public class LiniendiaConfigView : ConfigViewModell 
    {
        private string? selectedKategorie = null;
        public string? SelectedKategorie
        {
            get => selectedKategorie;
            set => selectedKategorie = value;
        }
        private string? selectedxAchse = null;
        public string? SelectedxAchse
        {
            get => selectedxAchse;
            set => selectedxAchse = value;
        }
        private string? selectedyAchse = null;
        public string? SelectedyAchse
        {
            get => selectedyAchse;
            set => selectedyAchse = value;
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
        public List<string> AnzeigeCollection { get; set; } = new List<string> { "Absolut", "Relativ" };
        public List<string> DiagrammCollection { get; set; } = new List<string> { "Basic bars", "Column width", "Dynamic visibility" };
        public List<string> LinienCollection { get; set; } = new List<string>();
        public LiniendiaConfigView() 
        {
            FillUi();
        }

        public override void FillUi()
        {
            foreach (string item in App.CurrentReader.GetValueHead())
            {
                LinienCollection.Add(item);
            }
        }
        public override Writer GenerateWriter()
        {
            return new LiniendiaWriter();
        }
    }
}
