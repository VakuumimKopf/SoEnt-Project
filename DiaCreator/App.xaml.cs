using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Windows;

namespace DiaCreator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // Dies sind Propertys die global verfügbar sein müssen, sie beinhalten Objekte mit zentraler Funktionalität
        public static Reader? CurrentReader {  get; set; }
        public static Builder CurrentBuilder { get; } = new Builder();
        public static DHolder CurrentDHolder { get; } = new DHolder();
        public static DiaBuilder? CurrentDiaBuilder { get; set; }
        private void AppStartup(object sender, StartupEventArgs e) 
        {

        }
    }

}
