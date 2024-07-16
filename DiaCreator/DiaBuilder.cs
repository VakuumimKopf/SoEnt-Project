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

namespace DiaCreator
{
    public sealed class DiaBuilder
    {
        private ObservableCollection<ObservablePoint> _observablePoints = new ObservableCollection<ObservablePoint>();
        public ObservableCollection<ISeries> Series { get; set; } = new ObservableCollection<ISeries>();
        
        private Writer? writer;
        
        private static readonly Lazy<DiaBuilder> lazy = new Lazy<DiaBuilder>(GetInstance);
        
        static DiaBuilder GetInstance()
        {
            return new DiaBuilder();
        }
        public static DiaBuilder Instance() { return lazy.Value; }
        private DiaBuilder() 
        {
            Thread DiagrammThread = new Thread(ThreadStartingPoint);
            DiagrammThread.SetApartmentState(ApartmentState.STA);
            DiagrammThread.IsBackground = true;
            DiagrammThread.Start();
        }
        private void ThreadStartingPoint()
        {
            var window = new DiagrammWindow();
            window.Show();
            System.Windows.Threading.Dispatcher.Run();
        }
        public void Call(string type)
        {
            writer = App.CurrentBuilder.CreateWriter(type);
            var obj_list = writer.GenerateSeriesList(App.CurrentDHolder.GetAllData());
            foreach (var obj in obj_list) 
            {
                Series.Add(obj);
            }            
        }
        public void Call2(string type)
        {
            _observablePoints = new ObservableCollection<ObservablePoint>();
            _observablePoints.Add(new ObservablePoint(1, 2));
            _observablePoints.Add(new ObservablePoint(5, 7));
            _observablePoints.Add(new ObservablePoint(8, 4));


            Series.Add(new LineSeries<ObservablePoint> { Values= _observablePoints});
            
        }
    }
}
