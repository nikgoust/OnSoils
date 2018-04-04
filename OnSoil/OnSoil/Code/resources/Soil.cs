using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace OnSoil
{
    public class Soil{
        public List<Horizon> Horizons;
        public DateTime Date;
        public string Number;
        public string Name;
        public string GeoLocation;
        public string TopogBinding;
        public string Relief;
        public string Site;
        public string Vegetation;
        public string Hydro;
        public string Surface;
        public string Commentary;

    }

    public class Horizon{
        public string Name;
        public string Color;
        public string Wetness;
        public string Commentary;
        public virtual bool Equal(Horizon horizon){
            return false;
        }
    }

    class OrganicHorizon: Horizon{
        public string OrgType;
        public override bool Equal(Horizon horizon){
            if (horizon is MineralHorizon) return false;
            var hor = (OrganicHorizon) horizon;
            return hor.Commentary == Commentary && hor.Color == Color
                      && hor.Name == Name && hor.OrgType == OrgType
                      && hor.Wetness == Wetness;
        }
    }

    class MineralHorizon : Horizon{
        public string Structure;
        public string Сomposition;
        public string Density;
        public string Pore;
        public string Kutans;
        public string Stretching;
        public string BioNeoplasms;
        public override bool Equal(Horizon horizon){
            if (horizon is OrganicHorizon) return false;
            var hor = (MineralHorizon)horizon;
            return hor.Commentary == Commentary && hor.Color == Color
                                                && hor.Name == Name && hor.Wetness == Wetness
                                                && hor.BioNeoplasms == BioNeoplasms
                                                && hor.Density == Density && hor.Kutans == Kutans
                                                && hor.Pore == Pore && hor.Stretching == Stretching
                                                && hor.Structure == Structure && hor.Сomposition == Сomposition;
        }
    }
}