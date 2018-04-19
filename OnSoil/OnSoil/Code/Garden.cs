using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace OnSoil.Code
{
    [Activity(Label = "Garden")]
    public class Garden : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            SetTheme(Android.Resource.Style.ThemeBlackNoTitleBarFullScreen);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Garden);
            var txtview = FindViewById<TextView>(Resource.Id.GardenTextView);
            txtview.Text = "";
            using (var sr = new StreamReader(Application.Context.Assets.Open("Garden.txt"), Encoding.UTF8)){
                string line;
                while ((line = sr.ReadLine()) != null){
                    txtview.Text += "\n" + line;
                }
            }
        }
    }
}