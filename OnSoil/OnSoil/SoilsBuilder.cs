using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Android.Content;
using Android.Widget;

namespace OnSoil
{
    public static class SoilsBuilder
    {
        public static Soil Soil;
        public static Horizon Horizon;
        private static List<Soil> _soilsList;
        public static bool HorizonEditMode;
        private static readonly string Filepath = Path.Combine((string)Android.OS.Environment.ExternalStorageDirectory) + "/OnSoil/Soils.xml";

        public static List<Soil> GetSoils()
        {
            return _soilsList;
        }

        public static void Create()
        {
            Soil = new Soil { Horizons = new List<Horizon>() };
        }

        public static bool AddSoil()
        {
            if (!_soilsList.Any(s => s.Number == Soil.Number && s.Number == Soil.Number))
            {
                _soilsList.Add(Soil);
                return true;
            }
            return false;
            
        }

        public static void DeleteSoil()
        {
            _soilsList.Remove(Soil);
        }

        public static void SaveChanges(Context context)
        {
            try{
                var serializer = new XmlSerializer(typeof(List<Soil>));
                System.IO.Directory.CreateDirectory(Path.GetDirectoryName(Filepath)??"");
                var writer = new FileStream(Filepath, FileMode.Create);
                serializer.Serialize(writer, _soilsList);
                writer.Close();
            }
            catch (Exception e)
            {
                Toast.MakeText(context, e.Message, ToastLength.Long).Show();
            }
        }

        public static void LoadSoils(Context context){
            if (!File.Exists(Filepath))
            {
                _soilsList = new List<Soil>();
                return;
            }
            
            try
            {
                var serializer = new XmlSerializer(typeof(List<Soil>));
                var reader = new FileStream(Filepath, FileMode.Open);
                _soilsList = (List<Soil>)serializer.Deserialize(reader); 
                reader.Close();
                if (_soilsList == null)
                    _soilsList = new List<Soil>();
            }
                catch (Exception e){
                Toast.MakeText(context, e.Message, ToastLength.Long).Show();
            }
        }

        public static string GetTextView(Soil soil)
        {
            var text = "    Профиль: " + soil.Name + "\n    "
                       + soil.Date + "    \n    Географическое положение: " + soil.GeoLocation
                       + "\n    " + "Топографическая привязка: " + soil.TopogBinding
                       + "\n    " + "Рельеф: " + soil.Relief + "\n    " + "Угодье: " + soil.Site
                       + "\n    " + "Растительность: " + soil.Vegetation + "\n    " + "Гидрографии: " + soil.Hydro
                       + "\n    " + "Характер поверхности почвы: " + soil.Surface + "\n\n    ";
            if (soil.Horizons == null || soil.Horizons.Count == 0) return text;
            foreach (var horizon in soil.Horizons)
            {
                if (horizon is MineralHorizon)
                {
                    var hor = (MineralHorizon) horizon;
                    text += "Минеральный горизонт: " + hor.Name 
                        + "\n    " + "Цвет: " + hor.Color + "\n    " + "Почвенная структура: " + hor.Structure
                        + "\n    " + "Гранулический состав " + hor.Composition + "\n    " + "Влажность: " + hor.Wetness
                        + "\n    " + "Сложение " + hor.Density + "\n    " + "Форма пор: " + hor.Pore
                        + "\n    " + "Кутаны " + hor.Kutans + "\n    " + "Стяжения: " + hor.Stretching
                        + "\n    " + "Новообразования биологического происхождения: " + hor.BioNeoplasms
                        + "\n    " + "Коментарии: " + hor.Commentary + "\n    " + "Вскипание от кислоты: " + hor.Acid + "\n\n    ";
                }
                else
                {
                    var hor = (OrganicHorizon)horizon;
                    text += "Минеральный горизонт: " + hor.Name
                         + "\n    " + "Цвет: " + hor.Color + "\n    " + "Тип органических остатков: " + hor.OrgType
                        + "Влажность: " + hor.Wetness + "\n    " + "Коментарии: " + hor.Commentary + "\n\n    ";
                }                
            }
             return text;
        }

       
    }
}