using System;
using System.Collections;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Provider;
using Android.Views;
using Android.Widget;
using Object = Java.Lang.Object;

//namespace OnSoil
//{
//    public class CustomAdapter : BaseAdapter
//    {
//        private readonly Activity _activity;
//        private const int SpinnerType = 0;
//        private const int TextType = 1;
//        private const int DataType = 2;
//        private List<int> itemTypeList;
//        private List<object> itemList;
        
//        public CustomAdapter(Activity activity)
//        {
//            itemTypeList = new List<int>();
//            itemList = new List<object>();
//            _activity = activity;
//        }

//        public override Object GetItem(int position)
//        {
//            return (TextView)itemList[position];
//        }

//        public void AddItem(object item, int type){
//            itemList.Add(item);
//            switch (type){
//                case SpinnerType:
//                    itemTypeList.Add(SpinnerType);
//                    break;
//                case TextType:
//                    itemTypeList.Add(TextType);
//                    break;
//                case DataType:
//                    itemTypeList.Add(DataType);
//                    break;
//            }
//        }


//        public override long GetItemId(int position)
//        {
//            return position;
//        }

//        //public override View GetView(int position, View convertView, ViewGroup parent)
//        //{
//        //    var view = convertView;
//        //    if (view == null)
//        //    {
//        //        var type = itemTypeList[position];
//        //        int layout;
//        //        switch (type)
//        //        {
//        //            case TextType:
//        //                layout = Resource.Layout.MyTextView;
//        //                view = _activity.LayoutInflater.Inflate(layout, parent, false);
//        //                var txtv = view.FindViewById<TextView>(Resource.Id.myTextView);
//        //                //txtv.Tag = new TextView(_activity){Text = (string)itemList[position]}.Tag;
//        //                /*var holder = new TextViewHolder();
//        //                holder.textView = convertView.FindViewById<TextView>(Resource.Id.myTextView);
//        //                holder.textView.Text = (string)itemList[position];*/
//        //                break;
//        //            case DataType:
//        //                layout = Resource.Layout.MyDataPicker;
//        //                view = _activity.LayoutInflater.Inflate(layout, parent, false);
//        //                //var holder1 = new DatePickerViewHolder();
//        //                var dtp = view.FindViewById<DatePicker>(Resource.Id.myDatePicker);
//        //                //dtp.Tag = new Date(_activity) { Text = (string)itemList[position] }.Tag;
//        //                break;
//        //            default:
//        //                layout = Resource.Layout.MySpiner;
//        //                view = _activity.LayoutInflater.Inflate(layout, parent, false);
//        //                //var holder2 = new SpinnerViewHolder();
//        //                var spn = view.FindViewById<Spinner>(Resource.Id.mySpinner);
//        //                spn.Adapter = (ArrayAdapter)itemList[position];
//        //                //holder2.spinner = convertView.FindViewById<Spinner>(Resource.Id.mySpinner);
//        //                //holder2.spinner.Adapter = (ArrayAdapter)itemList[position];
//        //                break;
//        //        }
//        //    }
//        //    return view;
//        //}

//        public override int Count => itemList.Count;
//    }

//    public class TextViewHolder{
//        public TextView textView;
//    }
//    public class SpinnerViewHolder
//    {
//        public Spinner spinner;
//    }
//    public class DatePickerViewHolder
//    {
//        public DatePicker datePicker;
//    }
//}