using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

//namespace OnSoil.Code.resources
//{
//    public interface IMultiSpinnerListener
//    {
//        void OnItemsSelected(bool[] selected);
//    }
//    public class MultiSpinner : Spinner, IDialogInterfaceOnMultiChoiceClickListener, IDialogInterfaceOnCancelListener
//    {
//        readonly Context _context;

//        private List<String> items;
//        private bool[] _selected;
//        private String _defaultText;
//        private IMultiSpinnerListener listener;

//        public MultiSpinner(Context context) : base(context)
//        {
//            _context = context;
//        }

//        public MultiSpinner(Context context, IAttributeSet arg1) : base(context, arg1)
//        {
//            _context = context;
//        }

//        public MultiSpinner(Context context, IAttributeSet arg1, int arg2) : base(context, arg1, arg2)
//        {
//            _context = context;
//        }


//        public void OnClick(IDialogInterface dialog, int which, bool isChecked)
//        {
//            if (isChecked)
//                _selected[which] = true;
//            else
//                _selected[which] = false;
//        }

//        public override void OnClick(IDialogInterface dialog, int which)
//        {
//            dialog.Cancel();
//        }


//        public override bool PerformClick()
//        {
//            AlertDialog.Builder builder = new AlertDialog.Builder(_context);
//            builder.SetMultiChoiceItems(
//                    items.ToArray(), _selected, this);

//            builder.SetPositiveButton("OK", this);
//            builder.SetOnCancelListener(this);
//            builder.Show();
//            return true;
//        }


//        public void SetItems(List<String> items, String allText,
//            IMultiSpinnerListener listener)
//        {

//            this.items = items;
//            this._defaultText = allText;
//            this.listener = listener;

//            // all selected by default
//            _selected = new bool[items.Count];
//            for (int i = 0; i < _selected.Length; i++)
//                _selected[i] = true;
//            ArrayAdapter<string> adapter = new ArrayAdapter<string>(_context, Resource.Layout.simple_spinner_item, Resource.Id.tv_item, new string[] { allText });
//            // all text on the spinner
//            //ArrayAdapter<String> adapter = new ArrayAdapter<String>(_context,Resource.Layout.simple_spinner_item, new String[] { allText });
//            Adapter = adapter;
//        }

//        public void OnCancel(IDialogInterface dialog)
//        {
//            Java.Lang.StringBuffer spinnerBuffer = new Java.Lang.StringBuffer();
//            bool someUnselected = false;
//            for (int i = 0; i < items.Count; i++)
//            {
//                if (_selected[i] == true)
//                {
//                    spinnerBuffer.Append(items[i]);
//                    spinnerBuffer.Append(", ");
//                }
//                else
//                {
//                    someUnselected = true;
//                }
//            }
//            String spinnerText;
//            if (someUnselected)
//            {
//                spinnerText = spinnerBuffer.ToString();
//                if (spinnerText.Length > 2)
//                    spinnerText = spinnerText.Substring(0, spinnerText.Length - 2);
//            }
//            else
//            {
//                spinnerText = _defaultText;
//            }
//            ArrayAdapter<String> adapter = new ArrayAdapter<String>(_context, Resource.Layout.simple_spinner_item, Resource.Id.tv_item, new string[] { spinnerText });
//            Adapter = adapter;
//            listener?.OnItemsSelected(_selected);

//        }


//    }
//}

