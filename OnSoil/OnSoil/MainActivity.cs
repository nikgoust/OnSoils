using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Widget;
using Android.OS;

namespace OnSoil
{
    [Activity(Label = "OnSoil", MainLauncher = true, Icon = "@drawable/icon", ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : Activity
    {
        public override void OnBackPressed(){
            Exit();
        }

        protected override void OnCreate(Bundle bundle){
            SetTheme(Android.Resource.Style.ThemeBlackNoTitleBarFullScreen);
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            var gameButton = FindViewById<Button>(Resource.Id.GameButton);
            var hintButton = FindViewById<Button>(Resource.Id.HintButton);
            var exitButton = FindViewById<Button>(Resource.Id.ExitButton);

            gameButton.Click += (sender, e) =>{
                var intent = new Intent(this, typeof(GameList));
                StartActivity(intent);
                OverridePendingTransition(Resource.Animation.slide_in_top, Resource.Animation.slide_out);

            };

            exitButton.Click += (sender, e) =>{
                Exit();
            };

        }

        private void Exit(){
            Finish();
            Process.KillProcess(Process.MyPid());
        }
    }
}

