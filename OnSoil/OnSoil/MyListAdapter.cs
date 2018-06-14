using System.Collections.Generic;
using System.Collections.ObjectModel;
using Android.App;
using Android.Content;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace OnSoil
{
    class MyListAdapter : BaseAdapter
    {
        private Activity _activity;
        private ObservableCollection<ListItem> _data;
        private TextView _textView;
        private LinearLayout _mainLayout;
        private LinearLayout _textLayout;
        private ListItem _prev;

        public MyListAdapter(Activity activity, 
            List<Soil> data, 
            LinearLayout mainLayout, 
            LinearLayout textLayout,
            TextView textView)
        {
            _mainLayout = mainLayout;
            _textView = textView;
            _textLayout = textLayout;
            _activity = activity;
            _data = new ObservableCollection<ListItem>();
            foreach (var soil in data ?? new List<Soil>()){
                _data.Add(new ListItem(){Soil = soil});
            }
        }

        public override Object GetItem(int position){
            return position;
        }

        public Soil GetSoil(int position){
            return _data[position].Soil;
        }

        public void ChangeVisibility(int position){
            var soil = _data[position];
            if (_prev == soil){
                soil.ChangeVisibility();
            }
            else{
                _prev?.ChangeVisibility();
                soil.ChangeVisibility();
            }
            _prev = soil;
            NotifyDataSetChanged();
        }

        public override long GetItemId(int position){
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
            if (convertView == null){
                view = _activity.LayoutInflater.Inflate(Resource.Layout.MyListItem, parent, false);
            }
            var txtView = view.FindViewById<TextView>(Resource.Id.ListItemName);
            var btnLayout = view.FindViewById<LinearLayout>(Resource.Id.ListItemButtonsLayout);
            var editbtn = view.FindViewById<Button>(Resource.Id.ListItemEdit);
            var delbnt = view.FindViewById<Button>(Resource.Id.ListItemDelete);
            var readbnt = view.FindViewById<Button>(Resource.Id.ListItemRead);
            btnLayout.Visibility = _data[position].Visibility;
            editbtn.Click += (sender, e) =>{
                SoilsBuilder.Soil = GetSoil(position);
                var intent = new Intent(_activity, typeof(FillingInfo));
                _activity.StartActivity(intent);
            };
            delbnt.Click += (sender, e) => {
                var alertDialog = new AlertDialog.Builder(_activity);
                alertDialog.SetTitle("Удаление");
                alertDialog.SetMessage("Вы уверенны что хотите удалить данный профиль?");
                alertDialog.SetPositiveButton("Удалить", delegate {
                    SoilsBuilder.Soil = GetSoil(position);
                    SoilsBuilder.DeleteSoil();
                    SoilsBuilder.SaveChanges(_activity);
                    NotifyDataSetChanged();
                });
                alertDialog.SetNegativeButton("Отмена", delegate {});
                alertDialog.Show();
            };
            readbnt.Click += (sender, e) => {
                _textView.Text = SoilsBuilder.GetTextView(GetSoil(position));
                _mainLayout.Visibility = ViewStates.Gone;
                _textLayout.Visibility = ViewStates.Visible;
            };
            txtView.Text = "№"+ GetSoil(position).Number +" "+ GetSoil(position).Name;
            return view;
        }

        public override int Count => _data.Count;
    }

    class ListItem{
        public Soil Soil;
        public ViewStates Visibility = ViewStates.Gone;

        public void ChangeVisibility(){
            Visibility = Visibility == ViewStates.Gone ? ViewStates.Visible : ViewStates.Gone;
        }
    }
}