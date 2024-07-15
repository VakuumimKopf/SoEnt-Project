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

namespace DiaCreator
{
    /// <summary>
    /// Interaktionslogik für Diagramm.xaml
    /// </summary>
    public partial class DiagrammWindow : Window
    {
        private static DiagrammWindow diagrammwininstance;   
        public static DiagrammWindow getInstance() 
        {
            if (diagrammwininstance == null) 
            {
                diagrammwininstance = new DiagrammWindow();
            }
            return diagrammwininstance;
        }
        
        private DiagrammWindow()
        {
            InitializeComponent();
        }

    }
}
