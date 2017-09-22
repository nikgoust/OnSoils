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
    [Activity(Label = "Record")]
    public class Record : Activity
    {
        public override void OnBackPressed()
        {
            var intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
            OverridePendingTransition(Resource.Animation.slide_in_topBACK, Resource.Animation.slide_out_bottomBACK);
        }
        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);

            // Create your application here
        }
    }
}