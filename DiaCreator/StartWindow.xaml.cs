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
        private string Dia = "Kreisdiagramm";
        public string filepath;
        public StartWindow()
        {
            InitializeComponent();
        }
        private void ClickAddFile(object sender, RoutedEventArgs e)
        {
            // Configure open file dialog box
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "Document"; // Default file name
            dialog.DefaultExt = ".csv"; // Default file extension
            dialog.Filter = "Data documents (.csv)|*.csv"; // Filter files by extension

            // Show open file dialog box
            bool? result = dialog.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                filepath = dialog.FileName;
            }
        }
        private void ClickErstelleNeuesProjekt(object sender, RoutedEventArgs e) 
        {
            App.CurrentReader = App.CurrentBuilder.CreateReader("csv",filepath);
            App.CurrentDHolder.AddDataList(App.CurrentReader.GetFileData());

            var DatenWindow = new DatenWindow(Dia, filepath);
            Close();
            DatenWindow.Show();
        }

        private void DiaSelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
           Dia = ((ComboBoxItem)Test.SelectedItem).Content.ToString();   
        }
    }
}