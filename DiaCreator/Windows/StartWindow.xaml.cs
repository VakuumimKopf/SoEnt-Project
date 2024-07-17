using System.IO.Enumeration;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DiaCreator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        private string? diagrammtyp;
        private string? filepath;
        public StartWindow()
        {
            InitializeComponent();
        }
        private void ClickAddFile(object sender, RoutedEventArgs e)
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
                filepath = dialog.FileName;
            }
        }
        private void ClickErstelleNeuesProjekt(object sender, RoutedEventArgs e) 
        {
            // Ein Reader wird erzeugt passend zum Dateityp und in die golbale Property CurrentReader geschrieben, ihm wird der Pfad zur geöffneten Datei übergeben
            if (filepath == null) { throw new Exception("Keine Datei übergeben"); }
            App.CurrentReader = App.CurrentBuilder.CreateReader("csv", filepath);
            // Der Reader ließt die ihm übergebene Datei aus und speichert den gelesenen Ihnhalt in den globalen DHolder
            App.CurrentDHolder.AddDataList(App.CurrentReader.GetFileData());

            // Das Fenster DataWindow wird erzeugt und das Startfenster geschlossen
            if (diagrammtyp == null) { throw new Exception("Kein Diagrammtyp übergeben"); }
            var DatenWindow = new DatenWindow(diagrammtyp);
            Close();
            DatenWindow.Show();
            
        }

        private void DiaSelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Das ausgewählte Argument in der Combobox wird in dem Feld diagrammtyp gespeichert
            diagrammtyp = ((ComboBoxItem)Test.SelectedItem).Content.ToString();   
        }
    }
}