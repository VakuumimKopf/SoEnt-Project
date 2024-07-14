using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DiaCreator
{
    public interface ConfigView 
    {
        public void FillUi();
    }

    public class KreisdiaConfigView : ConfigView
    {
        public List<string> NameCollection { get; set; } = new List<string>();
        public KreisdiaConfigView() 
        {
            FillUi();   
        }
        public void FillUi() 
        {
            string[] TableHeadString = (App.CurrentReader.GetTableHead()).Split(";");
            foreach (string item in TableHeadString)
            {
                NameCollection.Add(item);
            }
        }
    }

    public class SaulendiaConfigView : ConfigView
    {
        public List<string> SauCollection { get; set; }
        public SaulendiaConfigView() 
        {

            SauCollection = new List<string>()
            {
                "TestSau1",
                "TestSau",
                "{0}"
            };
        }
        public void FillUi()
        {
            string[] TableHeadString = (App.CurrentReader.GetTableHead()).Split(";");
            foreach (string item in TableHeadString)
            {
                //NameCollection.Add(item);
            }
        }
    }

    public class LiniendiaConfigView : ConfigView 
    {
        public LiniendiaConfigView() { }
        public void FillUi()
        {
            string[] TableHeadString = (App.CurrentReader.GetTableHead()).Split(";");
            foreach (string item in TableHeadString)
            {
                //NameCollection.Add(item);
            }
        }
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
