using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaCreator
{
    public interface ConfigView 
    {

    }

    public class KreisdiaConfigView : ConfigView 
    {
        public KreisdiaConfigView() { }
    }

    public class SaulendiaConfigView : ConfigView
    {
        public SaulendiaConfigView() { }
    }

    public class LiniendiaConfigView : ConfigView 
    {
        public LiniendiaConfigView() { }
    }
    
    public class Config
    {
        public ConfigView? View { get; set; }
        public Config(string type) 
        {
            switch (type)
            {
                case "Kreisdia": View = new KreisdiaConfigView(); break;
                case "Saulendia": View = new SaulendiaConfigView(); break;
                case "Liniendia": View = new LiniendiaConfigView(); break;
                default: break;
            }
        }



    }
}
