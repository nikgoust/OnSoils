using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using OnSoil.Code.resources;

namespace OnSoil
{
    [Activity(Label = "FillingInfo")]
    public class FillingInfo : Activity{
        private TextView _name;
        private TextView _commentary;
        private DatePicker _date;
        private TextView _geoLocation;
        private TextView _hydro;
        private TextView _number;
        private TextView _relief;
        private TextView _site;
        private Spinner _surface;
        private TextView _topogBinding;
        private TextView _vegetation;
        private Spinner _horizones;
        private bool _exist = false;

        protected override void OnCreate(Bundle savedInstanceState){
            SetTheme(Android.Resource.Style.ThemeBlackNoTitleBarFullScreen);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.FillingInfo);
            _name = FindViewById<TextView>(Resource.Id.profNameEditText);
            _commentary = FindViewById<TextView>(Resource.Id.profCommentaryEditText);
            _date = FindViewById<DatePicker>(Resource.Id.profDatePicker);
            _geoLocation = FindViewById<TextView>(Resource.Id.profGeoLocEditText);
            _hydro = FindViewById<TextView>(Resource.Id.profHydroEditText);
            _number = FindViewById<TextView>(Resource.Id.profNumberEditText);
            _relief = FindViewById<TextView>(Resource.Id.profReliefEditText);
            _site = FindViewById<TextView>(Resource.Id.profSiteEditText);
            _surface = FindViewById<Spinner>(Resource.Id.profSurfaceSpinner);
            _topogBinding = FindViewById<TextView>(Resource.Id.profTopBindEditText);
            _vegetation = FindViewById<TextView>(Resource.Id.profVegetationEditText);
            _horizones = FindViewById<Spinner>(Resource.Id.profHorSpinner);
            var items = new List<string> { "", "Ровная поверхность", "Волнистая поверхность", "Каменистая поверхность",
                "Завалуненная поверхность", "Скальные выходы"};
            _surface.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, items);

            var addHorButton = FindViewById<Button>(Resource.Id.profAddHorButton);
            var editHorButton = FindViewById<Button>(Resource.Id.profEditHorButton);
            var deleteHorButton = FindViewById<Button>(Resource.Id.profDelHorButton);
            var saveProileButton = FindViewById<Button>(Resource.Id.saveProfButton);
            var delProileButton = FindViewById<Button>(Resource.Id.delProfButton);
            
            if (!string.IsNullOrEmpty(SoilsBuilder.Soil.Name)){
                FillFields();
                _exist = true;
            }
            editHorButton.Click += EditHorButton_Click;
            addHorButton.Click += AddHorButton_Click;
            deleteHorButton.Click += DeleteHorButton_Click;

            saveProileButton.Click += (sender, e) =>{
                if (string.IsNullOrEmpty(_name.Text)){
                    Toast.MakeText(this, "Введите название профиля", ToastLength.Short).Show();
                    return;
                }
                UpdateSoil();
                SoilsBuilder.AddSoil();
                SoilsBuilder.SaveChanges(this);
                Toast.MakeText(this, "Успешно добавленно", ToastLength.Short).Show();
            };

            delProileButton.Click += (sender, e) =>{
                var alertDialog = new AlertDialog.Builder(this);
                alertDialog.SetTitle("Удаление профиля");
                alertDialog.SetMessage("Вы уверенны что хотите удалить данный профиль?");
                alertDialog.SetPositiveButton("Удалить", delegate{
                    if (!_exist){
                        var intent = new Intent(this, typeof(Diary));
                        StartActivity(intent);
                    }
                    SoilsBuilder.DeleteSoil();
                    SoilsBuilder.SaveChanges(this);
                    
                });
                alertDialog.SetPositiveButton("Отмена", delegate{});
            };
        }

        private void AddHorButton_Click(object sender, EventArgs e){
            UpdateSoil();
            var alertDialog = new AlertDialog.Builder(this);
            alertDialog.SetTitle("Добавление горизонта");
            alertDialog.SetNeutralButton("Органогенный гаризонт", delegate{
                SoilsBuilder.Horizon = new OrganicHorizon();
                var intent = new Intent(this, typeof(FillingHoriz));
                StartActivity(intent);
            });
            alertDialog.SetPositiveButton("Минеральный гаризонт", delegate{
                SoilsBuilder.Horizon = new MineralHorizon();
                var intent = new Intent(this, typeof(FillingHoriz));
                StartActivity(intent);
            });
            alertDialog.Show();
        }

        private void DeleteHorButton_Click(object sender, EventArgs e){
            UpdateSoil();
            var horizon = FindHor(_horizones.SelectedItem.ToString());
            if (horizon == null){
                Toast.MakeText(this, "Не удалось удалить", ToastLength.Short).Show();
                return;
            }
            var alertDialog = new AlertDialog.Builder(this);
            alertDialog.SetTitle("Удаление");
            alertDialog.SetMessage("Вы уверенны что хотите удалить данный горизонт?");
            alertDialog.SetPositiveButton("Удалить", delegate {
                SoilsBuilder.Soil.Horizons.Remove(horizon);
                Toast.MakeText(this, "Успешно удалено", ToastLength.Short).Show();
            });
            alertDialog.SetNegativeButton("Отмена", delegate { });
            alertDialog.Show();
        }

        private void EditHorButton_Click(object sender, EventArgs e){
            UpdateSoil();
            var horizon = FindHor(_horizones.SelectedItem.ToString());
            if(horizon == null) return;
            SoilsBuilder.Horizon = horizon;
            var intent = new Intent(this, typeof(FillingHoriz));
            StartActivity(intent);
        }

        private Horizon FindHor(string name){
            foreach (var horizon in SoilsBuilder.Soil.Horizons){
                if (horizon.Name == name){
                    return horizon;
                }
            }
            return null;
        }

        private void FillFields(){
            _name.Text = SoilsBuilder.Soil.Name;
            _commentary.Text = SoilsBuilder.Soil.Commentary;
            _date.DateTime = SoilsBuilder.Soil.Date;
            _geoLocation.Text = SoilsBuilder.Soil.GeoLocation;
            _hydro.Text = SoilsBuilder.Soil.Hydro;
            _number.Text = SoilsBuilder.Soil.Number;
            _relief.Text = SoilsBuilder.Soil.Relief;
            _site.Text = SoilsBuilder.Soil.Site;
            for (var i = 0; i < _surface.Adapter.Count; i++){
                if (_surface.Adapter.GetItem(i).ToString() == SoilsBuilder.Soil.Surface){
                    _surface.SetSelection(i);
                    break;
                }
            }
            _topogBinding.Text = SoilsBuilder.Soil.TopogBinding;
            _vegetation.Text = SoilsBuilder.Soil.Hydro;
            if (SoilsBuilder.Soil.Horizons == null || SoilsBuilder.Soil.Horizons.Count < 1) return;
            var items = new List<string>();
            foreach (var horizon in SoilsBuilder.Soil.Horizons){
                items.Add(horizon.Name);
            }
            _horizones.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, items);
            _horizones.SetSelection(0);

        }

        private void UpdateSoil(){
            SoilsBuilder.Soil.Name = _name.Text; 
            SoilsBuilder.Soil.Commentary = _commentary.Text;
            SoilsBuilder.Soil.Date = _date.DateTime;
            SoilsBuilder.Soil.GeoLocation = _geoLocation.Text;
            SoilsBuilder.Soil.Hydro = _hydro.Text;
            SoilsBuilder.Soil.Number = _number.Text;
            SoilsBuilder.Soil.Relief = _relief.Text;
            SoilsBuilder.Soil.Site = _site.Text;
            SoilsBuilder.Soil.Surface = _surface.SelectedItem?.ToString() ?? "";
            SoilsBuilder.Soil.TopogBinding = _topogBinding.Text;
            SoilsBuilder.Soil.Vegetation = _vegetation.Text;
        }

        public override void OnBackPressed(){
            var alertDialog = new AlertDialog.Builder(this);
            alertDialog.SetTitle("Выход");
            alertDialog.SetMessage("Несохраненные данные будут утеряны");
            alertDialog.SetPositiveButton("Выйти", delegate {
                SoilsBuilder.SaveChanges(this);
                var intent = new Intent(this, typeof(Diary));
                StartActivity(intent);
            });
            alertDialog.SetNegativeButton("Отмена", delegate { });
            alertDialog.Show();
        }
    }
}