using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaCreator
{
    public class Builder
    {
        public Builder() 
        { 

        }

        public Writer CreateWriter(string type) 
        {
            switch (type)
            {
                case "Kreisdiagramm": return new KreisdiaWriter();
                case "Säulendiagramm": return new SaulendiaWriter();
                case "Liniendiagramm": return new LiniendiaWriter();
                default: throw new Exception("Übergebener Writer Type existiert nicht");
            }
        }

        public ConfigView CreateConfigView(string type) 
        {
            switch (type)
            {
                case "Kreisdiagramm": return new KreisdiaConfigView();
                case "Säulendiagramm": return new SaulendiaConfigView();
                case "Liniendiagramm": return new LiniendiaConfigView();
                default: throw new Exception("Übergebener Config Type existiert nicht");
            }
        }

        public Reader CreateReader(string type, string path) 
        {
            switch (type)
            {
                case "csv": return new CSVReader(path, 0);
                default: throw new Exception("Übergebener Reader Type existiert nicht");
            }
        }  
         
    }
}
