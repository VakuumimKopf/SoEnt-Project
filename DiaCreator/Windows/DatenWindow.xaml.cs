using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DiaCreator
{
 
    public partial class DatenWindow : Window
    {
        public DatenWindow(string DiagrammTyp)
        {
            InitializeComponent();

            //Der Daten Kontext wird auf die Klasse DatenWindowViewModell gelagert, dieser wird zusätzlich die Art des benötigten Diagramms im Konstruktor übergeben
            this.DataContext = new DatenWindowViewModell(App.CurrentBuilder.CreateConfigView(DiagrammTyp));
        }
        
        private void DarstellenClick(object sender, RoutedEventArgs e) 
        {

        }
    }
}
