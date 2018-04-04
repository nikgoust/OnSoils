using System;
using System.Collections.Generic;

namespace OnSoil
{
    public static class GameSoil{
        private static string _difficult;
        public static Item CurrentSoil;
        private static readonly List<int> Indices = new List<int>();
        private static readonly List<int> Agroindices = new List<int>();
        private static string[] _horrizonts;
        private static List<Item> _profilesList;
        private static List<Item> _agroProfilesList;


        public static void Init(string difficult){
            ClearIndeces();
            _profilesList = DataStorage.ProfilesList;
            _agroProfilesList = DataStorage.AgroProfilesList;
            _difficult = difficult;
            _horrizonts = DataStorage.HorizontsInit();
            for (var i = 0; i < _profilesList.Count; i++){
                Indices.Add(i);
            }
            if (difficult == "Легко") return;
            for (var i = 0; i < _agroProfilesList.Count; i++){
                Agroindices.Add(i);
            }
            
        }

        public static string[] FillArray(){
            var horrizontsToUse = new string[11];
            var rnd = new Random();
            horrizontsToUse[0] = "";
            if (_difficult != "Легко"){
                var random = rnd.Next(9);
                if (random > 3){
                    FillingMainPart(horrizontsToUse, _agroProfilesList, Agroindices);
                }
                else{
                    FillingMainPart(horrizontsToUse, _profilesList, Indices);
                }
            }
            else{
                FillingMainPart(horrizontsToUse, _profilesList, Indices);
            }
            return FillingOther(horrizontsToUse);
        }

        private static void FillingMainPart(string[] horrizontsToUse, List<Item> itemsList, List<int> indecses){
            var rnd = new Random();
            var randomSoil = 0;
            var arrayIndices = new List<int>();
            for (var i = 1; i < 11; i++){
                arrayIndices.Add(i);
            }
            var random = rnd.Next(indecses.Count);
            randomSoil = indecses[random];
            indecses.RemoveAt(random);
            CurrentSoil = itemsList[randomSoil];
            foreach (var horizon in CurrentSoil.Items){
                random = rnd.Next(arrayIndices.Count);
                horrizontsToUse[arrayIndices[random]] = horizon;
                arrayIndices.RemoveAt(random);
            }
        }

        private static void ClearIndeces(){
            Indices.Clear();
            Agroindices.Clear();
        }

        private static string[] FillingOther(string[] horrizontsToUse){
            var rnd = new Random();
            for (var i = 1; i < 11; i++){
                if (!string.IsNullOrEmpty(horrizontsToUse[i])) continue;
                while (true){
                    var randomString = _horrizonts[rnd.Next(_horrizonts.Length)];
                    if (Array.Exists(horrizontsToUse, element => element == randomString)) continue;
                    horrizontsToUse[i] = randomString;
                    break;
                }
            }
            return horrizontsToUse;
        }
   }
}