using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;

namespace OnSoil
{
    [Activity(Label = "OnSoil", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
       
        protected override void OnCreate(Bundle bundle)
        {
            SetTheme(Android.Resource.Style.ThemeBlackNoTitleBarFullScreen);
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            Button gameButton = FindViewById<Button>(Resource.Id.GameButton);
            Button hintButton = FindViewById<Button>(Resource.Id.HintButton);
            Button exitButton = FindViewById<Button>(Resource.Id.ExitButton);

            gameButton.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(GameList));
                StartActivity(intent);
                OverridePendingTransition(Resource.Animation.slide_in_top, Resource.Animation.slide_out);

            };
        }
    }
}

