using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.OS;
using Android.Text.Method;
using Android.Widget;


namespace OnSoil
{
    [Activity(Label = "SoilsInfo", ScreenOrientation = ScreenOrientation.Portrait)]
    public class SoilsInfo : Activity
    {
        private string _type;
        private int _state = 0;
        private ListView _listView;
        private TextView _textView;
        private List<string> _listOfClassifications;
        private List<Item> _listOfSItems;
        

        private int _id;

        public override void OnBackPressed(){
            switch (_state){
                case 1:
                    ListOfMain();
                    _state--;
                    break;
                case 2:
                    ListOfSub();
                    _textView.Text = "";
                    _state--;
                    break;
                default:
                    var intent = new Intent(this, typeof(Directory));
                    StartActivity(intent);
                    OverridePendingTransition(Resource.Animation.slide_in_topBACK, Resource.Animation.slide_out_bottomBACK);
                    break;
            }
        }

        private void ListOfMain(){
                var items = _listOfClassifications;
                RefreshListView(items);
        }

        private void ListOfSub(){
                var items = _listOfSItems.Where(l => l.Group == _listOfClassifications[_id]).Select(l => l.Name).ToList();
                RefreshListView(items);
        }

        private void RefreshListView(List<string> items){
            var adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, items);
            _listView.Adapter = adapter;
        }

        protected override void OnCreate(Bundle savedInstanceState){
            _type = Intent.GetStringExtra("Type");
            _listOfClassifications = _type == "Profiles" ? DataStorage.ProfilesGroupList : DataStorage.HorizonsGroupList;
            _listOfSItems = _type == "Profiles" ? DataStorage.ProfilesList : DataStorage.HorizonsList;
            SetTheme(Android.Resource.Style.ThemeBlackNoTitleBarFullScreen);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.SoilsInfo);
            _listView = FindViewById<ListView>(Resource.Id.ListView);
            _textView = FindViewById<TextView>(Resource.Id.TextView);
            _textView.SetTypeface(Typeface.Serif, TypefaceStyle.Normal);
            _textView.MovementMethod = new LinkMovementMethod();
            
            ListOfMain();
            
            _listView.ItemClick += _listView_ItemClick;
        }

        private void _listView_ItemClick(object sender, AdapterView.ItemClickEventArgs e){
            var text = ((TextView)e.View).Text;
            if (_state == 0){
                _state++;
                _id = e.Position;
                ListOfSub();
            }
            else{
                _textView.Text = "     " + _listOfSItems.First(l => l.Name == text).Name + "\n     ";
                foreach (var paragraph in _listOfSItems.First(l => l.Name == text).Items){
                    _textView.Text += paragraph + "\n     ";
                    }
                _state++;
                RefreshListView(new List<string>());
            }
        }
    }
}