using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaCreator
{
    public class DHolder
    {
        private List<DSet> data = new List<DSet> ();
        public DHolder() {}

        public void AddDataList(List<DSet> data_n)
        {
            data.AddRange(data_n);
        }

        public void AddData(DSet d) 
        {
            data.Add(d);
        }

        public List<DSet> GetDataList(int[] ids)
        {
            var liste = new List<DSet>();
            foreach (var d in data)
            {
                foreach (var i in ids)
                {
                    if(d.Id == i) liste.Add(d);
                }
            }
            return liste;
        }
        public List<DSet> GetAllData() 
        {
            return data;
        }
    }
}
