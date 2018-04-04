using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Widget;


namespace OnSoil
{
    [Activity(Label = "Directory", ScreenOrientation = ScreenOrientation.Portrait)]
    public class Directory : Activity
    {
        public override void OnBackPressed(){
            var intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
            OverridePendingTransition(Resource.Animation.slide_in_topBACK, Resource.Animation.slide_out_bottomBACK);
        }

        protected override void OnCreate(Bundle savedInstanceState){
            SetTheme(Android.Resource.Style.ThemeBlackNoTitleBarFullScreen);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Directory);

            var profilesButton = FindViewById<Button>(Resource.Id.ProfilesButton);
            var horizonsButton = FindViewById<Button>(Resource.Id.HorizonsButton);

            horizonsButton.Click += (sender, e) =>{
                var intent1 = new Intent(this, typeof(SoilsInfo));
                intent1.PutExtra("Type", "Horizons");
                StartActivity(intent1);
                OverridePendingTransition(Resource.Animation.slide_in_top, Resource.Animation.slide_out);
            };

            profilesButton.Click += (sender, e) => { 
                var intent1 = new Intent(this, typeof(SoilsInfo));
                intent1.PutExtra("Type", "Profiles");
                StartActivity(intent1);
                OverridePendingTransition(Resource.Animation.slide_in_top, Resource.Animation.slide_out);
            };
        }
     }
}