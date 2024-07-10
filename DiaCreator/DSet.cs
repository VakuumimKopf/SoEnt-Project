using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaCreator
{
    public class DSet
    {
        private string text;
        public string Text 
        {
            get { return text; } 
            set
            {
                text = value;
            } 
        }

        public DSet(string text_n)
        {
            text = text_n;
=======
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace DiaCreator
{
    class DSet
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
>>>>>>> 3fdccfde70e7cd27115e2aefcacde237430240ac
        }

    }
}
