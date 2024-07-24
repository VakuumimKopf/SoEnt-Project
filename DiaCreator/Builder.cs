using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaCreator
{
    public class Builder //Generiert von Parameter abhängig verschiedene Instanzen von Klassen
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

        public ConfigViewModell CreateConfigView(string type) 
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
                case "csv": return new CSVReader(path);
                default: throw new Exception("Übergebener Reader Type existiert nicht");
            }
        }

        public DiaBuilder CreateDiaBuilder(string type) 
        {
            switch (type)
            {
                case "Kreisdiagramm": return PieDiaBuilder.Instance();
                case "Säulendiagramm": 
                case "Liniendiagramm": return CartDiaBuilder.Instance(type);
                default: throw new Exception("Übergabe DiaBuilder Type existiert nicht");
            }
        }
         
    }
}
