using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Controls;
using System.Windows.Input;
using DiaCreator.BaseClasses;
using System.Diagnostics;

namespace DiaCreator
{
    public class StartWindowViewModell : BaseViewModell
    {
        public List<string> DiaCollection {  get; set; } = new List<string>() {"Kreisdiagramm", "Säulendiagramm", "Liniendiagramm"};
        
        private string? diagrammtyp = null;

        public string? Diagrammtyp
        {
            get => diagrammtyp;
            set => diagrammtyp = value;
        }

        private string? filepath = null;

        public string DateiPfad
        {
            get => filepath ?? "Dateipfad...";
            set
            {
                filepath = value;
                OnPropertyChanged("DateiPfad");
            }
        }

        public ICommand ClickAddFile { get; set; }
        public ICommand ClickErstellenNeuesProjekt { get; set; }

        public event EventHandler OnRequestClose;

        public StartWindowViewModell() 
        {
            ClickAddFile = new RelayCommand(parameter => AddFile());
            ClickErstellenNeuesProjekt = new RelayCommand(parameter => ErstelleNeuesProjekt());
        }
        private void AddFile()
        {
            // Einstellung der Dialogbox zum öffnen einer Datei
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "Document"; // Default Datei Name
            dialog.DefaultExt = ".csv"; // Default Dateityp
            dialog.Filter = "Data documents (.csv)|*.csv"; // Filter für Dateityp

            // Anzeigen der Dialogbox
            bool? result = dialog.ShowDialog();

            // Speichern der geöffneten Datei als Pfad im Feld filepath
            if (result == true)
            {
                DateiPfad = dialog.FileName;
            }
        }
        private void ErstelleNeuesProjekt()
        {
            // Das Fenster DataWindow wird erzeugt und das Startfenster geschlossen
            if (diagrammtyp == null | this.filepath == null) 
            {
                MessageBox.Show("Es wurde kein Diagrammtyp oder keine Datei ausgewählt");
            } else
            {
                // Ein Reader wird erzeugt passend zum Dateityp und in die golbale Property CurrentReader geschrieben, ihm wird der Pfad zur geöffneten Datei übergeben
                App.CurrentReader = App.CurrentBuilder.CreateReader("csv", filepath);

                // Das Fenster Headfestlegung wird erzeugt und das Startfenster geschlossen
                var Headfestlegung = new Headfestlegung();
                var vm = new HeadfestlegungViewModell(diagrammtyp);
                Headfestlegung.DataContext = vm;
                vm.OnRequestClose += (sender, e) => Headfestlegung.Close();

                Headfestlegung.Show();

                OnRequestClose(this, new EventArgs());
            }
        }
    }
}
