using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;

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

        public static string GetTextView(Soil soil)
        {
            var text = "    Профиль: " + soil.Name + "\n    "
                       + soil.Date + "    \n    Географическое положение: " + soil.GeoLocation
                       + "\n    " + "Топографическая привязка: " + soil.TopogBinding
                       + "\n    " + "Рельеф: " + soil.Relief + "\n    " + "Угодье: " + soil.Site
                       + "\n    " + "Растительность: " + soil.Vegetation + "\n    " + "Гидрографии: " + soil.Hydro
                       + "\n    " + "Характер поверхности почвы: " + soil.Surface;
            foreach (var horizon in soil.Horizons){
                text += "smth";
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