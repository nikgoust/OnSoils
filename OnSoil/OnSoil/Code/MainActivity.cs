using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Widget;
using OnSoil.Code;


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
            DataStorage.Init();
            var gameButton = FindViewById<Button>(Resource.Id.GameButton);
            var diaryButton = FindViewById<Button>(Resource.Id.DiaryButton);
            var hintButton = FindViewById<Button>(Resource.Id.HintButton);
            var exitButton = FindViewById<Button>(Resource.Id.ExitButton);
            var garden = FindViewById<Button>(Resource.Id.myGarden);

            gameButton.Click += (sender, e) =>{
                var intent = new Intent(this, typeof(GameList));
                StartActivity(intent);
                OverridePendingTransition(Resource.Animation.slide_in_top, Resource.Animation.slide_out);

            };

            diaryButton.Click += (sender, e) => {
                var intent = new Intent(this, typeof(Diary));
                StartActivity(intent);
                OverridePendingTransition(Resource.Animation.slide_in_top, Resource.Animation.slide_out);

            };

            hintButton.Click += (sender, e) => {
                var intent = new Intent(this, typeof(Directory));
                StartActivity(intent);
                OverridePendingTransition(Resource.Animation.slide_in_top, Resource.Animation.slide_out);

            };

            garden.Click += (sender, e) => {
                var intent = new Intent(this, typeof(Garden));
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

