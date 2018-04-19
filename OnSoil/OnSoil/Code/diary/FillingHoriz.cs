using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using OnSoil.Code.resources;

namespace OnSoil
{
    [Activity(Label = "FillingHoriz")]
    public class FillingHoriz : Activity
    {
        private Horizon _horizon;
        private bool _exist = false;
        private SoilType _type;

        private TextView _horName;
        //MultiSpinner mSpinner;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            SetTheme(Android.Resource.Style.ThemeBlackNoTitleBarFullScreen);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.FillingHoriz);
            _type = SoilsBuilder.Horizon is MineralHorizon ? SoilType.Mineral : SoilType.Organogenic;
            _horizon = SoilsBuilder.Horizon;
            _horName = FindViewById<TextView>(Resource.Id.horNameEditText);
            var saveButton = FindViewById<Button>(Resource.Id.horSaveButton);
            var delButton = FindViewById<Button>(Resource.Id.horDeleteButton);
            InitFields();
            if (!string.IsNullOrEmpty(SoilsBuilder.Horizon.Name)){
                _exist = true;
                FillingFields();
            }

            delButton.Click += (sender, e) =>{
                if (!_exist){
                    OnBackPressed();
                    return;
                }
                var alertDialog = new AlertDialog.Builder(this);
                alertDialog.SetTitle("Удаление");
                alertDialog.SetMessage("Вы уверенны что хотите удалить данный горизонт?");
                alertDialog.SetPositiveButton("Удалить", delegate {
                    var result = SoilsBuilder.Soil.Horizons.Remove(_horizon);
                    if (result){
                        Toast.MakeText(this, "Успешно удалено", ToastLength.Short).Show();
                        OnBackPressed();
                    }
                });
                alertDialog.SetNegativeButton("Отмена", delegate { });
                alertDialog.Show();
            };

            saveButton.Click += SaveHorizon;
            
        }

        private void SetSpinner(Spinner spinner, string value)
        {
            for (var i = 0; i < spinner.Adapter.Count; i++) {
            if (spinner.Adapter.GetItem(i).ToString() == value){
                spinner.SetSelection(i);
                break;
                }
            }
        }

    private void FillingFields( ){
        FindViewById<TextView>(Resource.Id.horColorEditText).Text = _horizon.Color;
        FindViewById<TextView>(Resource.Id.horCommentEditText).Text = _horizon.Commentary;
        FindViewById<TextView>(Resource.Id.horNameEditText).Text = _horizon.Name;
        SetSpinner(FindViewById<Spinner>(Resource.Id.horWetSpinner), _horizon.Wetness);
            if (_type == (int) SoilType.Organogenic){
                FindViewById<TextView>(Resource.Id.horOrgTypeEditText).Text = _horizon.OrganicHorizon.OrgType;
                return;
            }
        FindViewById<TextView>(Resource.Id.horStretchingEditText).Text = _horizon.MineralHorizon.Stretching;
        FindViewById<TextView>(Resource.Id.horKutansEditText).Text = _horizon.MineralHorizon.Kutans;
        SetSpinner(FindViewById<Spinner>(Resource.Id.horBioNeoplasmsSpinner), _horizon.MineralHorizon.BioNeoplasms);
        SetSpinner(FindViewById<Spinner>(Resource.Id.horDensitySpinner), _horizon.MineralHorizon.Density);
        SetSpinner(FindViewById<Spinner>(Resource.Id.horPoreSpinner), _horizon.MineralHorizon.Pore);
        SetSpinner(FindViewById<Spinner>(Resource.Id.horStructSpinner), _horizon.MineralHorizon.Structure);
        SetSpinner(FindViewById<Spinner>(Resource.Id.horCompositionSpinner), _horizon.MineralHorizon.Composition);
        SetSpinner(FindViewById<Spinner>(Resource.Id.horAcidSpinner), _horizon.MineralHorizon.Acid);
        }

        private void SaveHorizon(){
            if (_type == (int)SoilType.Organogenic)
            {
                _horizon.Color = FindViewById<TextView>(Resource.Id.horColorEditText).Text;
                _horizon.Commentary = FindViewById<TextView>(Resource.Id.horCommentEditText).Text;
                _horizon.Name = _horName.Text;
                _horizon.OrganicHorizon.OrgType = FindViewById<TextView>(Resource.Id.horOrgTypeEditText).Text;
                _horizon.Wetness = FindViewById<Spinner>(Resource.Id.horWetSpinner).SelectedItem.ToString() ?? "";
            }
            else{
                _horizon.Color = FindViewById<TextView>(Resource.Id.horColorEditText).Text;
                _horizon.Commentary = FindViewById<TextView>(Resource.Id.horCommentEditText).Text;
                _horizon.Name = _horName.Text;
                _horizon.Wetness = FindViewById<Spinner>(Resource.Id.horWetSpinner).SelectedItem?.ToString() ?? "";
                _horizon.MineralHorizon.BioNeoplasms = FindViewById<Spinner>(Resource.Id.horBioNeoplasmsSpinner).SelectedItem.ToString() ?? "";
                _horizon.MineralHorizon.Density = FindViewById<Spinner>(Resource.Id.horDensitySpinner).SelectedItem?.ToString() ?? "";
                _horizon.MineralHorizon.Kutans = FindViewById<TextView>(Resource.Id.horKutansEditText).Text;
                _horizon.MineralHorizon.Pore = FindViewById<Spinner>(Resource.Id.horPoreSpinner).SelectedItem?.ToString() ?? "";
                _horizon.MineralHorizon.Stretching = FindViewById<TextView>(Resource.Id.horStretchingEditText).Text;
                _horizon.MineralHorizon.Structure = FindViewById<Spinner>(Resource.Id.horStructSpinner).SelectedItem?.ToString() ?? "";
                _horizon.MineralHorizon.Composition = FindViewById<Spinner>(Resource.Id.horCompositionSpinner).SelectedItem?.ToString() ?? "";
                _horizon.MineralHorizon.Acid = FindViewById<Spinner>(Resource.Id.horAcidSpinner).SelectedItem?.ToString() ?? "";

            }
            
        }

        private void SaveHorizon(object sender, EventArgs e){
            if (string.IsNullOrEmpty(_horName.Text)){
                Toast.MakeText(this, "Введите название профиля", ToastLength.Short).Show();
                return;
            }
            Horizon horizonToReplace = null;
            if(SoilsBuilder.Soil.Horizons == null) SoilsBuilder.Soil.Horizons = new List<Horizon>();
            foreach (var horizon in SoilsBuilder.Soil.Horizons){
                if (horizon.Name == _horName.Text && _horizon.Id != horizon.Id){
                    horizonToReplace = horizon;
                    break;
                }
            }
            if (horizonToReplace != null){
                var alertDialog = new AlertDialog.Builder(this);
                alertDialog.SetTitle("Заменить горизонт?");
                alertDialog.SetMessage("Горизонт с таким названием уже существует. Заменить?");
                alertDialog.SetPositiveButton("Заменить", delegate{
                    SoilsBuilder.Soil.Horizons.Remove(horizonToReplace);
                    SaveHorizon();
                    if(!_exist) SoilsBuilder.Soil.Horizons.Add(_horizon);
                    _exist = true;
                    Toast.MakeText(this, "Успешно добавленно", ToastLength.Short).Show();
                });
                alertDialog.SetNegativeButton("Отменить", delegate { });
                alertDialog.Show();
            }else if (_exist){
                SaveHorizon();
                Toast.MakeText(this, "Успешно добавленно", ToastLength.Short).Show();
            }
            else{
                SoilsBuilder.Soil.Horizons.Add(_horizon);
                _exist = true;
                Toast.MakeText(this, "Успешно добавленно", ToastLength.Short).Show();
            }
        }

        public override void OnBackPressed(){
            var intent = new Intent(this, typeof(FillingInfo));
            StartActivity(intent);
        }

        private void InitFields(){
            string[] items;
            Spinner spinner;
            if (_type == (int)SoilType.Organogenic){
                var list = new List<LinearLayout>{
                    FindViewById<LinearLayout>(Resource.Id.horAcidLinearLayout),
                    FindViewById<LinearLayout>(Resource.Id.horStructLinearLayout),
                    FindViewById<LinearLayout>(Resource.Id.horDensityLinearLayout),
                    FindViewById<LinearLayout>(Resource.Id.horCompositionLinearLayout),
                    FindViewById<LinearLayout>(Resource.Id.horPoreLinearLayout),
                    FindViewById<LinearLayout>(Resource.Id.horIncludeLinearLayout),
                    FindViewById<LinearLayout>(Resource.Id.horKutansLinearLayout),
                    FindViewById<LinearLayout>(Resource.Id.horBioNeoplasmsLinearLayout),
                    FindViewById<LinearLayout>(Resource.Id.horStretchingLinearLayout)
                };
                foreach (var layout in list){
                    layout.Visibility = ViewStates.Gone;
                }
            }
            else
            {
                var orgLayout = FindViewById<LinearLayout>(Resource.Id.horOrgTypeLinearLayout);
                orgLayout.Visibility = ViewStates.Gone;
                //гранулометрический состав 
                items = new[] {"", "песок", "супесь", "легкий суглинок", "средний суглинок",
                    "тяжелый суглинок", "глина"
                };
                spinner = FindViewById<Spinner>(Resource.Id.horCompositionSpinner);
                spinner.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, items);
                //сложения
                items = new[] { "", "очень плотный", "плотный", "плотноватый", "рыхлый", "рассыпчатый"};
                spinner = FindViewById<Spinner>(Resource.Id.horDensitySpinner);
                spinner.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, items);
                //поры
                items = new[] { "", "округлые", "трубковидные", "щелевидные", "клиновидные", "камерные", "неправильные" };
                spinner = FindViewById<Spinner>(Resource.Id.horPoreSpinner);
                spinner.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, items);
                //поры
                items = new[] { "", "черноточины", "капролиты", "щелевидные", "кротовины", "корневины", "дендриты" };
                spinner = FindViewById<Spinner>(Resource.Id.horBioNeoplasmsSpinner);
                spinner.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, items);
                //вскипание от кислоты
                items = new[] { "", "вскипание отсутствует ", "слабое вскипание", "среднее вскипание", "сильное вскипание"};
                spinner = FindViewById<Spinner>(Resource.Id.horAcidSpinner);
                spinner.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, items);
            }
            items = new[] {"", "сухой", "свежий", "влажноватый", "влажный",
                "сырой", "мокрый"
            };
            spinner = FindViewById<Spinner>(Resource.Id.horWetSpinner);
            spinner.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, items);
        }
    }

    public enum SoilType{
        Organogenic, Mineral
    }
}