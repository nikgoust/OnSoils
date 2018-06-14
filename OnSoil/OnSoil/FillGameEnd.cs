using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Widget;

namespace OnSoil
{
    [Activity(Label = "FillGameEnd", ScreenOrientation = ScreenOrientation.Portrait)]
    public class FillGameEnd : Activity
    {
        public static string ErrorTitle;

        public override void OnBackPressed()
        {
            var intent = new Intent(this, typeof(GameList));
            StartActivity(intent);
            OverridePendingTransition(Resource.Animation.slide_in_topBACK, OnSoil.Resource.Animation.slide_out_bottomBACK);
        }

        protected override void OnCreate(Bundle savedInstanceState){

            SetTheme(Android.Resource.Style.ThemeBlackNoTitleBarFullScreen);
            base.OnCreate(savedInstanceState);
            SetContentView(OnSoil.Resource.Layout.FillGameEnd);

            var horizonts = new TextView[7];

            horizonts[0] = FindViewById<TextView>(OnSoil.Resource.Id.HorizontName1);
            horizonts[1] = FindViewById<TextView>(OnSoil.Resource.Id.HorizontName2);
            horizonts[2] = FindViewById<TextView>(OnSoil.Resource.Id.HorizontName3);
            horizonts[3] = FindViewById<TextView>(OnSoil.Resource.Id.HorizontName4);
            horizonts[4] = FindViewById<TextView>(OnSoil.Resource.Id.HorizontName5);
            horizonts[5] = FindViewById<TextView>(OnSoil.Resource.Id.HorizontName6);
            horizonts[6] = FindViewById<TextView>(OnSoil.Resource.Id.HorizontName7);
            var title= FindViewById<TextView>(OnSoil.Resource.Id.textView1);
            var soilName = FindViewById<TextView>(OnSoil.Resource.Id.SoilName);

            title.Text = ErrorTitle;
            soilName.Text = GameSoil.CurrentSoil.Name;
            var i = 0;
            foreach (var horizon in GameSoil.CurrentSoil.Items){
                horizonts[i].Text = horizon;
                i++;
            }
        }
    }
}