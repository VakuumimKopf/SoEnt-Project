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
                case "Kreisdia": return new KreisdiaWriter();
                case "Saulendia": return new SaulendiaWriter();
                case "Liniendia": return new LiniendiaWriter();
                default: throw new Exception("Übergebener Writer Type existiert nicht");
            }
        }

        public ConfigView CreateConfigView(string type) 
        {
            switch (type)
            {
                case "Kreisdia": return new KreisdiaConfigView();
                case "Saulendia": return new SaulendiaConfigView();
                case "Liniendia": return new LiniendiaConfigView();
                default: throw new Exception("Übergebener Config Type existiert nicht");
            }
        }

        /*public Reader CreateReader(string type) 
        {
            switch (type)
            {
                case ""csv": return new CSVReader();
                default: throw new Exception("Übergebener Reader Type existiert nicht");
            }
        }  
         */ 
    }
}
