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
    [Activity(Label = "Diary")]
    public class Diary : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetTheme(Android.Resource.Style.ThemeBlackNoTitleBarFullScreen);
            SetContentView(Resource.Layout.Diary);
            var list = FindViewById<ListView>(Resource.Id.ListViewWithSoils);

            // Create your application here
        }
    }
}