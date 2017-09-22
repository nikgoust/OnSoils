using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace OnSoil
{
    [Activity(Label = "GameList")]
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
            var difficult = new[]{"Легко","Сложно"};
            var year = new[] { "2004", "1977" };

            SetTheme(Android.Resource.Style.ThemeBlackNoTitleBarFullScreen);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.GameList);

            Button fillGameButton = FindViewById<Button>(Resource.Id.FillProfileButton);
            var spinner1 = FindViewById<Spinner>(Resource.Id.spinner1);
            var spinner2 = FindViewById<Spinner>(Resource.Id.spinner2);

            spinner1.Adapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleSpinnerItem, difficult);
            spinner2.Adapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleSpinnerItem, year);

            fillGameButton.Click += (sender, e) =>{
                var intent1 = new Intent(this, typeof(FillGame));
                StartActivity(intent1);
                OverridePendingTransition(Resource.Animation.slide_in_top, Resource.Animation.slide_out);
            };

            spinner1.ItemSelected += (s, e) => {
                if (e.Parent.GetItemAtPosition(e.Position).ToString() == "Легко"){
                    FillGame.difficult = "Легко";
                }
                else {
                    FillGame.difficult = "Сложно";
                }
            };

            spinner2.ItemSelected += (s, e) => {
                if (e.Parent.GetItemAtPosition(e.Position).ToString() == "2004"){
                    FillGame.year = "2004";
                }
                else{
                    FillGame.year = "1977";
                }
            };
        }
    }
}