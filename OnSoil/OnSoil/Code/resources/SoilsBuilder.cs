using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Xml.Serialization;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace OnSoil.Code.resources
{
    public static class SoilsBuilder
    {
        private static Soil _soil;
        public static List<Soil> SoilsList;
        private static string filepath = Path.Combine((string)Android.OS.Environment.ExternalStorageDirectory, "FolderPath") + "/Soils.xml";

        public static void Create(){
            _soil = new Soil {Horizons = new List<Horizon>()};
        }

        public static void Edit(Soil soil){
            _soil.Date = soil.Date;
            _soil.Commentary = soil.Commentary;
            _soil.GeoLocation = soil.GeoLocation;
            _soil.Hydro = soil.Hydro;
            _soil.Name = soil.Name;
            _soil.Number = soil.Number;
            _soil.Relief = soil.Relief;
            _soil.Site = soil.Site;
            _soil.Surface = soil.Surface;
            _soil.TopogBinding = soil.TopogBinding;
            _soil.Vegetation = soil.Vegetation;
        }

        public static void AddHorizon(Horizon horizon){
            _soil.Horizons.Add(horizon);
        }

        public static void SaveChnges(){
            var serializer = new XmlSerializer(typeof(List<Soil>));//initialises the serialiser
            var writer = new FileStream(filepath, FileMode.Create);//initialises the writer
            serializer.Serialize(writer, SoilsList);//Writes to the file
            writer.Close();
        }

        public static void LoadSoils()
        {
            var serializer = new XmlSerializer(typeof(List<Soil>));//initialises the serialiser
            var reader = new FileStream(filepath, FileMode.Open);//initialises the writer
            SoilsList = (List<Soil>)serializer.Deserialize(reader); //reads from the xml file and inserts it in this variable
            reader.Close(); //closes the reader
        }

        public static string GetTextView(Soil soil)
        {
            var text = "    Профиль: " + soil.Name + "\n    "
                       + soil.Date + "    \n    Географическое положение: " + soil.GeoLocation
                       + "\n    " + "Топографическая привязка: " + soil.TopogBinding
                       + "\n    " + "Рельеф: " + soil.Relief + "\n    " + "Угодье: " + soil.Site
                       + "\n    " + "Растительность: " + soil.Vegetation + "\n    " + "Гидрографии: " + soil.Hydro
                       + "\n    " + "Характер поверхности почвы: " + soil.Surface + "\n\n    ";
            foreach (var horizon in soil.Horizons){
                if (horizon is MineralHorizon){
                    var hor = (MineralHorizon) horizon;
                    text += "Минеральный горизонт: " + hor.Name 
                        + "\n    " + "Цвет: " + hor.Color + "\n    " + "Почвенная структура: " + hor.Structure
                        + "\n    " + "Гранулический состав " + hor.Сomposition + "\n    " + "Влажность: " + hor.Wetness
                        + "\n    " + "Сложение " + hor.Density + "\n    " + "Форма пор: " + hor.Pore
                        + "\n    " + "Кутаны " + hor.Kutans + "\n    " + "Стяжения: " + hor.Stretching
                        + "\n    " + "Новообразования биологического происхождения: " + hor.BioNeoplasms
                        + "\n    " + "Коментарии: " + hor.Commentary + "\n    " + "Вскипание от кислоты: " + hor.Acid + "\n\n    ";
                }
                else{
                    var hor = (OrganicHorizon)horizon;
                    text += "Минеральный горизонт: " + hor.Name
                         + "\n    " + "Цвет: " + hor.Color + "\n    " + "Тип органических остатков: " + hor.OrgType
                        + "Влажность: " + hor.Wetness + "\n    " + "Коментарии: " + hor.Commentary + "\n\n    ";
                }                
            }
             return text;
        }

        public static bool Delete(Horizon horizon){
            foreach (var hor in _soil.Horizons){
                if (hor.Equal(horizon)){
                    return _soil.Horizons.Remove(hor);
                }
            }
            return false;
        }
    }
}