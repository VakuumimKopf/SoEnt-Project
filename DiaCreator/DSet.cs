using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace DiaCreator
{
    public class DSet
    {
        private string name;
        public string Name
        {
            get => name;
            set => name = value;
        }
        private int id;
        public int Id
        {
            get => id;
            set => id = value;
        }

        private List<string[]>? data = new List<string[]>();
        public List<string[]>? Data
        {
            get => data;
        }

        public DSet(string name_n, int id_n)
        {
            this.name = name_n;
            this.id = id_n;
        }

        public void AddData(string value1, string value2)
        {
            data.Add([value1, value2]);
        }

    }
}
