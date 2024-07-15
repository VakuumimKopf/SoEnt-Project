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
        
        public static DHolder CurrentDHolder {  get; } = new DHolder();

        public static DiaBuilder? CurrentDiaBuilder { get; set; }
        
        private void AppStartup(object sender, StartupEventArgs e) 
        {

        }
    }

}
