using System;
using System.Collections.Generic;
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
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;

namespace DiaCreator
{
    /// <summary>
    /// Interaktionslogik für Diagramm.xaml
    /// </summary>
    public partial class DiagrammWindow : Window
    {       
        public DiagrammWindow()
        {
            InitializeComponent();
            this.DataContext =  DiaBuilder.Instance();
        }
    }
}
