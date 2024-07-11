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
        public ObservableCollection<DSet> DSetItems { get;  set; } = new ObservableCollection<DSet>();

        public Config config { get; set; } = new Config("Saulendia");
        
        public DatenWindow()
        {
            InitializeComponent();
            FillDSetItems();
        }
        
        private void FillDSetItems()
        {
            DSetItems.Add(new DSet("DSet1", 4));
            DSetItems.Add(new DSet("DSet2", 67));
            DSetItems.Add(new DSet("DSet3", 9));
        }
        private void DarstellenClick(object sender, RoutedEventArgs e) 
        {
            Thread DiagrammThread = new Thread(ThreadStartingPoint);
            DiagrammThread.SetApartmentState(ApartmentState.STA);
            DiagrammThread.IsBackground = true;
            DiagrammThread.Start();
        }

        private void ThreadStartingPoint() 
        {
            new DiagrammWindow().Show();
            System.Windows.Threading.Dispatcher.Run();
        }

    }
}
