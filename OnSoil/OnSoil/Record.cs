using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;


namespace OnSoil
{
    [Activity(Label = "Record", ScreenOrientation = ScreenOrientation.Portrait)]
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