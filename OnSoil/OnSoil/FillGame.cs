using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using System.Timers;

namespace OnSoil
{
    [Activity(Label = "FillGame")]
    public class FillGame : Activity
    {
        private string[] _horrizontsToUse = new string[11];
        private int _lvlCount = 0;
        private int _lvlRecord;
        private bool[] _horizontsСheck;
        private const int Time = 20;
        private Timer _timer;
        private ProgressBar _progressBar;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            SetTheme(Android.Resource.Style.ThemeBlackNoTitleBarFullScreen);

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.FillGame);
            var difficult = Intent.GetStringExtra("Difficulty");
            var year = Intent.GetStringExtra("Year");
            _horizontsСheck = new bool[7];
            var confirmButton = FindViewById<Button>(Resource.Id.ConfirmButton);

            var spinners = new[]{
                FindViewById<Spinner>(Resource.Id.spinner1),
                FindViewById<Spinner>(Resource.Id.spinner2),
                FindViewById<Spinner>(Resource.Id.spinner3),
                FindViewById<Spinner>(Resource.Id.spinner4),
                FindViewById<Spinner>(Resource.Id.spinner5),
                FindViewById<Spinner>(Resource.Id.spinner6),
                FindViewById<Spinner>(Resource.Id.spinner7)
            };

            _progressBar= FindViewById<ProgressBar>(Resource.Id.progressBar1);
            _progressBar.Progress = 100;

            Soil.Init(difficult); 

            var soilName = FindViewById<TextView>(Resource.Id.SoilName);
            var level = FindViewById<TextView>(Resource.Id.CounterText);
            var record = FindViewById<TextView>(Resource.Id.recordText);
            var soilVersion = FindViewById<TextView>(Resource.Id.SoilVersion);
            soilVersion.Text = year;
            var pref = Application.Context.GetSharedPreferences("record", FileCreationMode.Private);
            InitRecordValue(record, pref,difficult);


            _horrizontsToUse = Soil.FillArray();
            soilName.Text = Soil.SoilAndHorizontsName[0];

            for (var i = 0; i < spinners.Length; i++){
                spinners[i].Alpha = 0.4f;
                spinners[i].Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem,
                _horrizontsToUse);
                var i1 = i;
                spinners[i].ItemSelected += (s, e) => {
                    _horizontsСheck[i1] = e.Parent.GetItemAtPosition(e.Position).ToString() == Soil.SoilAndHorizontsName[i1+1];
                };
            }
            
            confirmButton.Click += (sender, e) =>{
                if (!Array.Exists(_horizontsСheck, element => !element))
                {
                    _progressBar.Progress = 100;
                    _lvlCount++;
                    if (_lvlCount > _lvlRecord){
                       NewRecord(difficult, pref,record);
                    }
                    level.Text = " Cчет: "+_lvlCount;
                    _horrizontsToUse = Soil.FillArray();
                    soilName.Text = Soil.SoilAndHorizontsName[0];
                    foreach (var spiner in spinners){
                        spiner.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem,
                            _horrizontsToUse);
                    }
                }
                else{
                    _timer?.Stop();
                    FillGameEnd.ErrorTitle = "Ошибка";
                    var intent = new Intent(this, typeof(FillGameEnd));
                    StartActivity(intent);
                    OverridePendingTransition(Resource.Animation.slide_in_topBACK, Resource.Animation.slide_out_bottomBACK);
                }
            };
        }

        private void InitRecordValue(TextView record, ISharedPreferences pref, string difficult)
        {
            
            if (difficult == "Сложно")
            {
                record.Text = " Рекорд: " + pref.GetInt("RecordHard", 0);
                _lvlRecord = pref.GetInt("RecordHard", 0);
                _progressBar.Visibility = ViewStates.Visible;
                _timer = new Timer { Interval = 500 };
                _timer.Elapsed += ProgressBarChenging;
                _timer.Start();
            }
            else
            {
                record.Text = " Рекорд: " + pref.GetInt("Record", 0);
                _lvlRecord = pref.GetInt("Record", 0);
                _progressBar.Visibility = ViewStates.Invisible;
            }
        }

        private void NewRecord(string difficult,ISharedPreferences pref,TextView record){
            if (difficult == "Легко"){
                pref = Application.Context.GetSharedPreferences("record", FileCreationMode.Private);
                var edit = pref.Edit();
                edit.PutInt("Record", _lvlCount);
                edit.Commit();
                record.Text = " Рекорд: " + _lvlCount;
            }
            else{
                pref = Application.Context.GetSharedPreferences("record", FileCreationMode.Private);
                var edit = pref.Edit();
                edit.PutInt("RecordHard", _lvlCount);
                edit.Commit();
                record.Text = " Рекорд: " + _lvlCount;
            }
        }

        public override void OnBackPressed()
        {
            _timer?.Stop();
            var intent = new Intent(this, typeof(GameList));
            StartActivity(intent);
            OverridePendingTransition(Resource.Animation.slide_in_topBACK, Resource.Animation.slide_out_bottomBACK);
        }

        private void ProgressBarChenging(object sender, ElapsedEventArgs e)
        {
            RunOnUiThread(() => { 
            _progressBar.IncrementProgressBy(-(100 / Time) / 2);
        });
            if (_progressBar.Progress <= 1)
            {
                _timer.Stop();
                FillGameEnd.ErrorTitle = "Время вышло";
                    var intentEnd = new Intent(this, typeof(FillGameEnd));
                    StartActivity(intentEnd);
                    OverridePendingTransition(Resource.Animation.slide_in_topBACK,
                    Resource.Animation.slide_out_bottomBACK);
            }
        }
    }
}