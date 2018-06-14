using System.Collections.Generic;
using System.IO;
using System.Text;
using Android.App;

namespace OnSoil
{
   static class DataStorage{
        public static List<Item> HorizonsList = new List<Item>();
        public static List<string> HorizonsGroupList = new List<string>();
        public static List<Item> ProfilesList = new List<Item>();
        public static List<string> ProfilesGroupList = new List<string>();
        public static List<Item> AgroProfilesList = new List<Item>();
        public static List<string> AgroProfilesGroupList = new List<string>();
        private static bool _firstLaunch = true;

        public static string[] HorizontsInit(){
            var horrizonts = new[]{
                "AEL", "AH", "AJ", "AK", "AO", "ASN", "AU", "AV", "AY", "[ABC]", "Gs", "CGs"
                , "BAN", "BCA", "BSN", "BEL", "BELg", "BFM", "BHF", "BI", "BM", "BMK", "BPL"
                , "BT", "BTg", "CAT", "CR", "CRM", "E", "EL", "ELg", "F", "G", "ML", "O", "P"
                , "PB", "PT", "PTR", "PU", "Q", "RJ", "RU", "RY", "S", "SEL", "SS", "T", "TE"
                , "TO", "TT", "TJ", "TUR", "V", "W", "X", "ТПО"
            };
            return horrizonts;
        }

        public static void Init(){
            if(!_firstLaunch) return;
            _firstLaunch = false;
            InitLists("horizons.csv",HorizonsGroupList, HorizonsList);
            InitLists("soils.csv",ProfilesGroupList, ProfilesList);
            InitLists("agroSoils.csv", AgroProfilesGroupList, AgroProfilesList);
        }

        public static void InitLists(string csv,List<string> list,List<Item> listForFill)
        {
            using (var sr = new StreamReader(Application.Context.Assets.Open(csv), Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var soil = new Item(line, list);
                    listForFill.Add(soil);
                }
            }
        }
    }


    public class Item{
        public string Group { get; }
        public string Name { get; }
        public List<string> Items { get; }
        public Item(string line, List<string> list){
            var parts = line.Split('/');
            Group = parts[0];
            if (!list.Contains(Group)) list.Add(Group);
            Name = parts[1];
            var info = parts[2].Split('$');
            Items = new List<string>();
            Items.AddRange(info);
        }
    }
}