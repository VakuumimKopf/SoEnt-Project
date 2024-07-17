using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using LiveChartsCore.Defaults;
using Accessibility;
using LiveChartsCore.SkiaSharpView.Extensions;
using System.Windows;

namespace DiaCreator
{
    
    public interface DiaBuilder 
    {
        public void Call();
    }
    public class CartDiaBuilder : DiaBuilder
    {
        private static string? _type;        
        public ObservableCollection<ISeries> Series { get; set; } = new ObservableCollection<ISeries>();
        
        private Writer? writer;
        
        private static readonly Lazy<CartDiaBuilder> lazy = new Lazy<CartDiaBuilder>(GetInstance);
        
        static CartDiaBuilder GetInstance()
        {
            return new CartDiaBuilder();
        }
        public static CartDiaBuilder Instance(string type) 
        {
            _type = type;
            return lazy.Value; 
        }
        private CartDiaBuilder() 
        {
            Thread DiagrammThread = new Thread(ThreadStartingPoint);
            DiagrammThread.SetApartmentState(ApartmentState.STA);
            DiagrammThread.IsBackground = true;
            DiagrammThread.Start();
        }
        private void ThreadStartingPoint()
        {
            var window = new DiagrammWindow();
            window.DataContext = this;
            window.Show();
            System.Windows.Threading.Dispatcher.Run();
        }
        public void Call()
        {
            writer = App.CurrentBuilder.CreateWriter(_type);
            var obj_list = writer.GenerateSeriesList(App.CurrentDHolder.GetAllData());
            foreach (var obj in obj_list) 
            {
                Series.Add(obj);
            }            
        }
    }
    public class PieDiaBuilder : DiaBuilder 
    {
        public ObservableCollection<ISeries> Series { get; set; } = new ObservableCollection<ISeries>();

        private static Window? window { get; set; }

        private static Thread? thread { get; set; }

        private Writer? writer;

        private static readonly Lazy<PieDiaBuilder> lazy = new Lazy<PieDiaBuilder>(GetInstance);

        static PieDiaBuilder GetInstance()
        {
            return new PieDiaBuilder();
        }
        public static PieDiaBuilder Instance()
        {
            if (thread != null) 
            {
                thread.Start();
            }
            return lazy.Value;
        }
        private PieDiaBuilder()
        {
            thread = new Thread(ThreadStartingPoint);
            thread.SetApartmentState(ApartmentState.STA);
            thread.IsBackground = true;
            thread.Start();
        }
        private void ThreadStartingPoint()
        {
            window = new DiagrammWindow();
            window.DataContext = this;
            window.Show();
            System.Windows.Threading.Dispatcher.Run();
        }
        public void Call()
        {
            writer = App.CurrentBuilder.CreateWriter("Kreisdiagramm");
            var obj_list = writer.GenerateSeriesList(App.CurrentDHolder.GetAllData());
            foreach (var obj in obj_list) 
            {
                Series.Add(obj);
            }
        }
    }
}
