using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace OnSoil
{
    [Activity(Label = "Diary")]
    public class Diary : Activity{
        private LinearLayout _mainLayout;
        private LinearLayout _textLayout;
        private TextView _textView;
        //private ArrayAdapter _adapter;
        private ListView _listView;

        protected override void OnCreate(Bundle savedInstanceState){
            base.OnCreate(savedInstanceState);
            SetTheme(Android.Resource.Style.ThemeBlackNoTitleBarFullScreen);
            SetContentView(Resource.Layout.Diary);
            _listView = FindViewById<ListView>(Resource.Id.listViewWithSoils);
            _mainLayout = FindViewById<LinearLayout>(Resource.Id.mainLinearLayout);
            _textLayout = FindViewById<LinearLayout>(Resource.Id.textLinearLayout);
            _textView = FindViewById<TextView>(Resource.Id.diarySoilsTextView);
            var addButton = FindViewById<Button>(Resource.Id.AddProfileButton);
            SoilsBuilder.LoadSoils(this);

            var adapter = new MyListAdapter(this, SoilsBuilder.GetSoils(), _mainLayout, _textLayout, _textView);
            _listView.Adapter = adapter;
            _listView.ItemClick += (sender, e) =>{
                adapter.ChangeVisibility(e.Position);
            };

            addButton.Click += (sender, e) =>{
                SoilsBuilder.Create();
                var intent = new Intent(this, typeof(FillingInfo));
                StartActivity(intent);
            };
        }

        public override void OnBackPressed(){
            if (_mainLayout.Visibility == ViewStates.Visible) {
                var intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);
                return;
            }
            _mainLayout.Visibility = ViewStates.Visible;
            _textLayout.Visibility = ViewStates.Gone;
        }
    }
}