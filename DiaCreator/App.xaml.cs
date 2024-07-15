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
        public static Reader CurrentReader {  get; set; }
        public static Builder CurrentBuilder { get; set; } = new Builder();
        public static DHolder CurrentDHolder { get; set; } = new DHolder();
        private void AppStartup(object sender, StartupEventArgs e) 
        {

        }
    }

}
