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
    [Serializable]
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
        public Guid Id;

        public MineralHorizon MineralHorizon => (MineralHorizon) this;
        public OrganicHorizon OrganicHorizon => (OrganicHorizon) this;

    }

    public class OrganicHorizon: Horizon{
        public string OrgType;
        public OrganicHorizon(){
            Id = Guid.NewGuid();
        }
    }

    public class MineralHorizon : Horizon{
        public string Structure;
        public string Composition;
        public string Density;
        public string Pore;
        public string Kutans;
        public string Stretching;
        public string BioNeoplasms;
        public string Acid;
        public MineralHorizon(){
            Id = Guid.NewGuid();
        }
    }
}