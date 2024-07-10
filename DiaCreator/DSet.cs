using System;
using System.Collections.Generic;
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
        }

    }
}
