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
    /// <summary>
    /// Interaktionslogik für DiagrammAuswahlWindow.xaml
    /// </summary>
    public partial class DiagrammAuswahlWindow : Window
    {
        public ObservableCollection<DSet> DSetItems { get; private set; } = new ObservableCollection<DSet>();


        //private readonly CollectionViewSource listingDataView;
        public DiagrammAuswahlWindow()
        {
            InitializeComponent();
            //listingDataView = (CollectionViewSource)(Resources["Items"]);
        }
        private void TestButton(object sender, RoutedEventArgs e) 
        {
            DSetItems.Add(new DSet("Hurensohn"));
        }

    }
}
