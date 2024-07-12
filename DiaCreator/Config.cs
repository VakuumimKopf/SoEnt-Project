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
        private ConfigView? view;
        public ConfigView? View { get; set; }
        public Config(string type, Builder builder) 
        {
            View = builder.CreateConfigView(type);
        }

        public static implicit operator ConfigViewModell(Config config)
        {
            return new ConfigViewModell
            {
                View = config.View,
            };
        }


    }
    public class ConfigViewModell : BaseViewModell
    {
        private ConfigView? view;
        public ConfigView? View { get; set; }
    }
}
