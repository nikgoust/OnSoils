using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using OnSoil.Code.resources;

namespace OnSoil
{
    [Activity(Label = "FillingInfo")]
    public class FillingInfo : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            //
            SoilsBuilder.Create();
            //
            SetTheme(Android.Resource.Style.ThemeBlackNoTitleBarFullScreen);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.FillingInfo);
            var addHorButton = FindViewById<Button>(Resource.Id.profAddHorButton);
            addHorButton.Click += AddHorButton_Click;  
        }

        private void AddHorButton_Click(object sender, EventArgs e)
        {
            UpdateSoil();
            var alertDialog = new AlertDialog.Builder(this);
            alertDialog.SetTitle("Добавление горизонта");
            alertDialog.SetNeutralButton("Органогенный гаризонт", delegate
            {
                var intent1 = new Intent(this, typeof(FillingHoriz));
                intent1.PutExtra("Type", (int)SoilType.Organogenic);
                StartActivity(intent1);
            });
            alertDialog.SetPositiveButton("Минеральный гаризонт", delegate
            {
                var intent1 = new Intent(this, typeof(FillingHoriz));
                intent1.PutExtra("Type", (int)SoilType.Mineral);
                StartActivity(intent1);
            });
            alertDialog.Show();
        }

        private void UpdateSoil()
        {
            var soil = new Soil()
            {
                Name = FindViewById<TextView>(Resource.Id.profNameEditText).Text,
                Commentary = FindViewById<TextView>(Resource.Id.profCommentaryEditText).Text,
                Date = FindViewById<DatePicker>(Resource.Id.profDatePicker).DateTime,
                GeoLocation = FindViewById<TextView>(Resource.Id.profGeoLocEditText).Text,
                Hydro = FindViewById<TextView>(Resource.Id.profHydroEditText).Text,
                Number = FindViewById<TextView>(Resource.Id.profNumberEditText).Text,
                Relief = FindViewById<TextView>(Resource.Id.profReliefEditText).Text,
                Site = FindViewById<TextView>(Resource.Id.profSiteEditText).Text,
                Surface = FindViewById<Spinner>(Resource.Id.profSurfaceSpinner).SelectedItem?.ToString() ?? "",
            TopogBinding = FindViewById<TextView>(Resource.Id.profTopBindEditText).Text,
                Vegetation = FindViewById<TextView>(Resource.Id.profVegetationEditText).Text
            };
            SoilsBuilder.Edit(soil);
        }
    }
}