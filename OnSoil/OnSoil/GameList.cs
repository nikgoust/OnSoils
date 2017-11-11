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
            var difficulty = new[]{"Легко","Сложно"};
            var year = new[] { "2004", "1977" };

            SetTheme(Android.Resource.Style.ThemeBlackNoTitleBarFullScreen);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.GameList);

            var newClassifButton = FindViewById<Button>(Resource.Id.NewClassifButton);
            var oldClassifButton = FindViewById<Button>(Resource.Id.OldClassifButton);
            var difficultyCheckBox= FindViewById<CheckBox>(Resource.Id.DifficultyCheckBox);

            newClassifButton.Click += (sender, e) =>{
                var intent1 = new Intent(this, typeof(FillGame));
                intent1.PutExtra("Difficulty", Difficulty(difficulty, difficultyCheckBox));
                intent1.PutExtra("Year", year[0]);
                StartActivity(intent1);
                OverridePendingTransition(Resource.Animation.slide_in_top, Resource.Animation.slide_out);
            };

            oldClassifButton.Click += (sender, e) => {
                var intent1 = new Intent(this, typeof(FillGame));
                intent1.PutExtra("Difficulty", Difficulty(difficulty,difficultyCheckBox));
                intent1.PutExtra("Year", year[1]);
                StartActivity(intent1);
                OverridePendingTransition(Resource.Animation.slide_in_top, Resource.Animation.slide_out);
            };
        }

        private string Difficulty(string[] difficulty, CheckBox difficultyCheckBox){
            return difficultyCheckBox.Checked ? difficulty[1] : difficulty[0];
        }
    }
}