using System;
using System.Collections.Generic;
using System.Linq;
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
        private Horizon horizon;
        private SoilType _type;
        //MultiSpinner mSpinner;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            SetTheme(Android.Resource.Style.ThemeBlackNoTitleBarFullScreen);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.FillingHoriz);
            _type = Intent.GetIntExtra("Type", -1) == (int)SoilType.Organogenic ? SoilType.Organogenic:SoilType.Mineral;
            var saveButton = FindViewById<Button>(Resource.Id.horSaveButton);
            var cancelButton = FindViewById<Button>(Resource.Id.horDeleteButton);
            cancelButton.Click += Delete;
            saveButton.Click += SaveHorizon;
            InitFields();
            /*mSpinner = FindViewById<MultiSpinner>(Resource.Id.mSpinner);
            List<string> items = new List<string> {
                "Android",
                "iOS",
                "UWP"
            };
            mSpinner.SetItems(items, "AllText", null);*/
            // Create your application here
        }

        private void CreateHorizon(){
            if (_type == (int)SoilType.Organogenic){
                horizon = new OrganicHorizon(){
                    Color = FindViewById<TextView>(Resource.Id.horColorEditText).Text,
                    Commentary = FindViewById<TextView>(Resource.Id.horCommentEditText).Text,
                    Name = FindViewById<TextView>(Resource.Id.horNameEditText).Text,
                    OrgType = FindViewById<TextView>(Resource.Id.horOrgTypeEditText).Text,
                    Wetness = FindViewById<Spinner>(Resource.Id.horWetSpinner).SelectedItem.ToString() ?? ""
                };
            }
            else{
                horizon = new MineralHorizon(){
                    Color = FindViewById<TextView>(Resource.Id.horColorEditText).Text,
                    Commentary = FindViewById<TextView>(Resource.Id.horCommentEditText).Text,
                    Name = FindViewById<TextView>(Resource.Id.horNameEditText).Text,
                    Wetness = FindViewById<Spinner>(Resource.Id.horWetSpinner).SelectedItem?.ToString() ?? "",
                    BioNeoplasms = FindViewById<Spinner>(Resource.Id.horBioNeoplasmsSpinner).SelectedItem.ToString() ?? "",
                    Density = FindViewById<Spinner>(Resource.Id.horDensitySpinner).SelectedItem?.ToString() ?? "",
                    Kutans = FindViewById<TextView>(Resource.Id.horKutansEditText).Text,
                    Pore = FindViewById<Spinner>(Resource.Id.horPoreSpinner).SelectedItem?.ToString() ?? "",
                    Stretching = FindViewById<TextView>(Resource.Id.horStretchingEditText).Text,
                    Structure = FindViewById<Spinner>(Resource.Id.horStructSpinner).SelectedItem?.ToString() ?? "",
                    Сomposition = FindViewById<Spinner>(Resource.Id.horCompositionSpinner).SelectedItem?.ToString() ?? "",
                    Acid = FindViewById<Spinner>(Resource.Id.horAcidSpinner).SelectedItem?.ToString() ?? ""
                };
            }
        }

        private void SaveHorizon(object sender, EventArgs e)
        {
            CreateHorizon();
            SoilsBuilder.AddHorizon(horizon);
            Toast.MakeText(this, "Успешно добавленно", ToastLength.Short).Show();
        }

        private void Delete(object sender, EventArgs e){
            CreateHorizon();
            var result = SoilsBuilder.Delete(horizon);
            var message = result ? "Успешное удаление" : "Не удалось удалить";
            Toast.MakeText(this, message, ToastLength.Short).Show();
            OnBackPressed();
        }

        public override void OnBackPressed(){
            var intent = new Intent(this, typeof(FillingInfo));
            StartActivity(intent);
        }

        private void InitFields(){
            string[] items;
            Spinner spinner;
            if (_type == (int)SoilType.Organogenic)
            {
                var list = new List<LinearLayout>(){
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