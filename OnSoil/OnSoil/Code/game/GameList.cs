using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Widget;

namespace OnSoil
{
    [Activity(Label = "GameList", ScreenOrientation = ScreenOrientation.Portrait)]
    public class GameList : Activity
    {
        public override void OnBackPressed()
        {
            var intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
            OverridePendingTransition(Resource.Animation.slide_in_topBACK, Resource.Animation.slide_out_bottomBACK);
        }



        protected override void OnCreate(Bundle savedInstanceState)
        {
            var difficulty = new[]{"Легко","Сложно"};

            SetTheme(Android.Resource.Style.ThemeBlackNoTitleBarFullScreen);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.GameList);

            var hardGameButton = FindViewById<Button>(Resource.Id.HardGameButton);
            var easyGameButton = FindViewById<Button>(Resource.Id.EasyGameButton);


            hardGameButton.Click += (sender, e) =>{
                var intent1 = new Intent(this, typeof(FillGame));
                intent1.PutExtra("Difficulty", difficulty[1]);
                StartActivity(intent1);
                OverridePendingTransition(Resource.Animation.slide_in_top, Resource.Animation.slide_out);
            };

            easyGameButton.Click += (sender, e) => {
                var intent1 = new Intent(this, typeof(FillGame));
                intent1.PutExtra("Difficulty", difficulty[0]);
                StartActivity(intent1);
                OverridePendingTransition(Resource.Animation.slide_in_top, Resource.Animation.slide_out);
            };
        }
       
    }
}