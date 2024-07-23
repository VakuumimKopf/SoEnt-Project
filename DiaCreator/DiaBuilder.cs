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
using System.Diagnostics;

namespace DiaCreator
{
    
    public interface DiaBuilder 
    {
        public void Call(ConfigViewModell config);
    }
    public class CartDiaBuilder : DiaBuilder
    {
        private static string? _type;        
        public ObservableCollection<ISeries> Series { get; set; } = new ObservableCollection<ISeries>();
        private Window? window { get; set; }
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
        }

        public void Call(ConfigViewModell config)
        {
            if (Application.Current.Windows.OfType<DiagrammWindow>().Any() == false)
            {
                window = null;
                Series = new ObservableCollection<ISeries>();
            }
            
            if (this.window == null)
            {
                window = new DiagrammWindow();
                window.DataContext = this;
                window.Show();
               
                writer = App.CurrentBuilder.CreateWriter(_type);

                var obj_list = writer.GenerateSeriesList(App.CurrentDHolder.GetAllExept(config.hiddenDSets.ToArray<int>()));
                foreach (var obj in obj_list)
                {
                    Series.Add(obj);
                }
            }   
        }
    }
    public class PieDiaBuilder : DiaBuilder 
    {
        public ObservableCollection<ISeries> Series { get; set; } = new ObservableCollection<ISeries>();

        private Window? window { get; set; }

        private Writer? writer;

        private static readonly Lazy<PieDiaBuilder> lazy = new Lazy<PieDiaBuilder>(GetInstance);

        static PieDiaBuilder GetInstance()
        {
            return new PieDiaBuilder();
        }
        public static PieDiaBuilder Instance()
        {
            return lazy.Value;
        }
        private PieDiaBuilder()
        {
        }  
        public void Call(ConfigViewModell config)
        {
            if (Application.Current.Windows.OfType<DiagrammWindow>().Any() == false)
            {
                window = null;
                Series = new ObservableCollection<ISeries>();
            }

            if (window == null)
            {
                window = new DiagrammWindow();
                window.DataContext = this;
                window.Show();

                writer = App.CurrentBuilder.CreateWriter("Kreisdiagramm");
                var obj_list = writer.GenerateSeriesList(App.CurrentDHolder.GetAllExept(config.hiddenDSets.ToArray<int>()));
                foreach (var obj in obj_list)
                {
                    Series.Add(obj);
                }
            }
        }
    }
}
