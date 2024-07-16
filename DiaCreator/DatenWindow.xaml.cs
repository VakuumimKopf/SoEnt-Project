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
        public DatenWindow(string DiagrammArt, string path)
        {
            InitializeComponent();
            var config = new Config(DiagrammArt, new Builder());
            this.DataContext = new DataWinViewModell(config);
        }
        
        private void DarstellenClick(object sender, RoutedEventArgs e) 
        {
            var diabuilder = DiaBuilder.Instance();
            diabuilder.Call("Liniendiagramm");
        }
    }
}
