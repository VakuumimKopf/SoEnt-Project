using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiaCreator.BaseClasses;
using static System.Net.Mime.MediaTypeNames;

namespace DiaCreator
{
    public abstract class ConfigViewModell : BaseViewModell
    {
        public abstract void FillUi();
        public abstract Writer GenerateWriter();
    }

    public class KreisdiaConfigView : ConfigViewModell
    {
        public List<string> NameCollection { get; set; } = new List<string>();
        public KreisdiaConfigView() 
        {
            FillUi();   
        }
        public override void FillUi() 
        {
            string[] TableHeadString = (App.CurrentReader.GetTableHead()).Split(";");
            foreach (string item in TableHeadString)
            {
                NameCollection.Add(item);
            }
        }
        public override Writer GenerateWriter()
        {
            return new KreisdiaWriter();
        }
    }

    public class SaulendiaConfigView : ConfigViewModell
    {
        public List<string> SauCollection { get; set; } = new List<string>();
        public SaulendiaConfigView() 
        {
            FillUi();
        }
        public override void FillUi()
        {
            string[] TableHeadString = (App.CurrentReader.GetTableHead()).Split(";");
            foreach (string item in TableHeadString)
            {
                SauCollection.Add(item);
            }
        }
        public override Writer GenerateWriter()
        {
            return new SaulendiaWriter();
        }
    }

    public class LiniendiaConfigView : ConfigViewModell 
    {
        public List<string> NameCollection { get; set; } = new List<string>();
        public LiniendiaConfigView() 
        {
            FillUi();
        }
        public override void FillUi()
        {
            string[] TableHeadString = (App.CurrentReader.GetTableHead()).Split(";");
            foreach (string item in TableHeadString)
            {
                NameCollection.Add(item);
            }
        }
        public override Writer GenerateWriter()
        {
            return new LiniendiaWriter();
        }
    }
}
