using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Shapes;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;


namespace DiaCreator
{
    public interface Reader
    {
        public int GetHeadElementIndex(string key);
        public string[] GetTableHead();
        public List<DSet> GetFileData();
        public string[] GetValueHead();
        public void SetBalancedTabelHead(List<KeyValuePair<string, int>> list);
        public int GetDataIndex(string key);

    }

    public class CSVReader : Reader
    {
        private readonly string Path;

        private int katindex;
        private int[] valueindex;

        private List<KeyValuePair<string, int>> DSetMap = new List<KeyValuePair<string, int>>();

        private List<KeyValuePair<string, int>> BalancedTabelHead;
        /*{
            new KeyValuePair<string, int>("Prüfung", 2),
            new KeyValuePair<string, int>("Jahr", 1),
            new KeyValuePair<string, int>("Durchgefallen", 1),
            new KeyValuePair<string, int>("Egal", 0)
        };*/

        public CSVReader(string path)
        {
            this.Path = path;
        }
        public void SetBalancedTabelHead(List<KeyValuePair<string, int>> list)
        {
            BalancedTabelHead = list;
        }

        private bool DSetExist(List<DSet> DSets, string Data) // Schaut ob die DSet Kategorie schon existiert
        {
            foreach (DSet T in DSets)
            {
                if (T.Name == Data) { return true; }
            }
            return false;
        }

        private void DSetAdd(List<DSet> DSets, string[] Data)//wenn ein DSet noch nicht existiert wird ein passendes neues erzeugt
        {                                                                  // und werte werden hinzugefügt
            if(katindex == -1) 
            {
                if (DSetExist(DSets, "Alle") == false) 
                {
                    DSets.Add(new DSet("Alle"));
                }
                this.DSetAddValues(DSets, Data);
            } else 
            {
                if (DSetExist(DSets, Data[katindex]) == false)
                {
                    DSets.Add(new DSet(Data[katindex]));
                }
                DSetAddValues(DSets, Data);
            }
        }

        private void DSetAddValues(List<DSet> DSets, string[] Data) //fügt die entsprechenden Einträge dem zugehörigem DSet hinzu
        {                  
            if(katindex == -1) 
            {
                DSet dset = DSets.Find(DSet => DSet.Name == "Alle");
                switch (this.valueindex.Length)
                {
                    case 1:
                        dset.AddData(Data[valueindex[0]]);
                        break;
                    case 2:
                        dset.AddData(Data[valueindex[0]], Data[valueindex[1]]);
                        break;
                    case 3:
                        dset.AddData(Data[valueindex[0]], Data[valueindex[1]], Data[valueindex[2]]);
                        break;
                    default: throw new Exception("Fehler bei der Datenübergabe an DSet: " + dset.Name);
                }
            } else 
            {
                foreach (DSet T in DSets)
                {
                    if (T.Name == Data[katindex])
                    {
                        switch (this.valueindex.Length)
                        {
                            case 1:
                                T.AddData(Data[valueindex[0]]);
                                break;
                            case 2:
                                T.AddData(Data[valueindex[0]], Data[valueindex[1]]);
                                break;
                            case 3:
                                T.AddData(Data[valueindex[0]], Data[valueindex[1]], Data[valueindex[2]]);
                                break;
                            default: throw new Exception("Fehler bei der Datenübergabe an DSet: " + T.Name);
                        }
                    }
                }
            }
        }

        private int GetKatIndex() 
        {
            string[] headelements = GetTableHead();
            string kat = "";
            foreach (var item in BalancedTabelHead)
            {
                if (item.Value == 2) { kat = item.Key; break; }
            }
            if(kat == "Nicht Gruppieren") return -1;
            else return this.GetHeadElementIndex(kat);
        }

        private List<int> GetValueIndex()
        {
            string[] headelements = GetTableHead();
            var ids = new List<int>();
            int i = 0;
            foreach (var item in BalancedTabelHead)
            {
                if (item.Value == 1) 
                {
                    ids.Add(this.GetHeadElementIndex(item.Key));
                    DSetMap.Add(new KeyValuePair<string, int>(item.Key, i));
                    i++;
                }
            }
            return ids;

        }

        public int GetHeadElementIndex(string key)
        {
            var headelements = this.GetTableHead();            
            for (int i = 0; i < headelements.Length; i++)
            {
                if (headelements[i] == key) { return i; }
            }
            throw new Exception("Das Gesuchte Tabelelement wurde nicht gefunden");
        }

        public List<DSet> GetFileData()
        {
            var DSets = new List<DSet>();
            string[] lines = File.ReadAllLines(Path);

            this.katindex = this.GetKatIndex();
            this.valueindex = this.GetValueIndex().ToArray<int>();

            for(int i = 1; i < lines.Length; i++)
            {
                string[] RawData = lines[i].Split(";");
                this.DSetAdd(DSets, RawData);
                
            }
            return DSets;
        }
        public string[] GetTableHead()
        {
            string[] lines = File.ReadAllLines(Path);
            int i = 0;    
            return lines[i].Split(";");            
        }

        public string[] GetValueHead()
        {
            var s = new string[valueindex.Length];
            int i = 0;
            foreach(var item in BalancedTabelHead) 
            {
                if(item.Value == 1)
                {
                    s[i] = item.Key;
                    i++;
                }
            }
            return s;
        }

        public int GetDataIndex(string key)
        {
            foreach(var item in DSetMap) 
            {
                if(key == item.Key) { return item.Value; }
            }
            throw new Exception("Gesuchter Datenpunkt nicht vorhanden in DSets");
        }
    }
}
