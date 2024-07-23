using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveChartsCore.Defaults;
using System.Security.Policy;
using System.Collections.ObjectModel;
using System.CodeDom.Compiler;
using LiveChartsCore.SkiaSharpView.Extensions;

namespace DiaCreator
{
    public interface Writer
    {
        public List<ISeries> GenerateSeriesList(List<DSet> sets);
    }

    public class KreisdiaWriter : Writer
    {
        private int UsedValue {  get; set; }
        public KreisdiaWriter() 
        {
            UsedValue = 1;
        }
        
        private double TotalValueofDSet(DSet set) 
        {
            double count = 0;
            foreach (var i in set.Data)
            {
                count += double.Parse(i[UsedValue]);
            }
            return count;
        }
        private ISeries GenerateSeriesObj(DSet set)
        {
            double[] totallist = [];
            var Pie = new PieSeries<double> { Values = new[] { TotalValueofDSet(set) }, Name=set.Name };
            return Pie;
        }
        public List<ISeries> GenerateSeriesList(List<DSet> sets)
        {
            var list = new List<ISeries>();
            foreach (var set in sets)
            {
                list.Add(GenerateSeriesObj(set));
            }
            return list;
        }

    }

    public class SaulendiaWriter : Writer 
    {
        private ObservableCollection<ObservablePoint> _observablePoints;
        private ISeries GenerateSeriesObj(DSet set)
        {
            _observablePoints = new ObservableCollection<ObservablePoint>();
            foreach (var d in set.Data)
            {
                _observablePoints.Add(new ObservablePoint(Double.Parse(d[0]), Double.Parse(d[1])));
            }
            var obj = new ColumnSeries<ObservablePoint>() { Values = _observablePoints, Name = set.Name };
            return obj;
        }
        public List<ISeries> GenerateSeriesList(List<DSet> sets)
        {
            var list = new List<ISeries>();
            foreach (DSet set in sets)
            {
                list.Add(this.GenerateSeriesObj(set));
            }
            return list;
        }

    }

    public class LiniendiaWriter : Writer
    {
        private ObservableCollection<ObservablePoint> _observablePoints;
        private List<string[]> SortDSet(DSet set) 
        {
            var data = set.Data.OrderBy(r => r[0])
                .ToList();
            return data;
        }
        private ISeries GenerateSeriesObj(DSet set) 
        {
            var data = this.SortDSet(set);
            _observablePoints = new ObservableCollection<ObservablePoint>();
            foreach (var d in data) 
            {
                _observablePoints.Add(new ObservablePoint(Double.Parse(d[0]), Double.Parse(d[1])));
            }
            var obj = new LineSeries<ObservablePoint>() { Values=_observablePoints, Name=set.Name };
            return obj;
        }
        public List<ISeries> GenerateSeriesList(List<DSet> sets) 
        {
            var list = new List<ISeries>();
            foreach (DSet set in sets) 
            {
                list.Add(this.GenerateSeriesObj(set));
            }
            return list;
        }
    }
}
