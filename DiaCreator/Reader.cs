using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Shapes;


namespace DiaCreator
{
    public interface Reader
    {
        public string GetTableHead();
        public List<DSet> GetFileData();
    }

    public class CSVReader : Reader
    {
        private readonly string Path;
        public int Kategorie { get; set; }

        public CSVReader(string path, int kategorie)
        {
            this.Path = path;
            this.Kategorie = kategorie;
        }


        private bool DSetExist(List<DSet> Temp, string Data) // Schaut ob die DSet Kategorie schon existiert
        {
            foreach (DSet T in Temp)
            {
                if (T.Name == Data) { return true; }
            }
            return false;
        }

        private void DSetAdd(List<DSet> Temp, string[] Data, int kategorie)//wenn ein DSet noch nicht existiert wird ein passendes neues erzeugt
        {                                                                  // und werte werden hinzugefügt
            if (DSetExist(Temp, Data[kategorie]) == false)
            {
                Temp.Add(new DSet(Data[kategorie]));
                DSetAddValues(Temp, Data, kategorie);
            }
            else
            {
                DSetAddValues(Temp, Data, kategorie);
            }
        }

        private void DSetAddValues(List<DSet> Temp, string[] Data, int kategorie) //fügt die entsprechenden Einträge dem zugehörigem DSet hinzu
        {
            foreach (DSet T in Temp)
            {
                if (T.Name == Data[kategorie])
                {
                    int kat = kategorie % 3;

                    T.AddData(Data[kat + 1], Data[kat + 2]);
                }
            }
        }

        public List<DSet> GetFileData()
        {
            string TableHead;
            var table = new List<DSet>();
            string[] lines = File.ReadAllLines(Path);

            int i = 0;       // variable to get the tablehead

            foreach (string line in lines)
            {
                if (i == 0)              //to ignore the tableHead
                {
                    TableHead = line;            
                    i++;
                }
                else
                {
                    string[] RawData = line.Split(";");
                    DSetAdd(table, RawData, Kategorie);
                }
            }
            return table;
        }
        public string GetTableHead()
        {
            string[] lines = File.ReadAllLines(Path);

            int i = 0;       // variable to get the tablehead

            foreach (string line in lines)
            {
                if (i == 0)
                {
                    string TableHead = line;             //tableHead
                    i++;
                    return TableHead;

                }
            }
            return null;
        }
    }
}
