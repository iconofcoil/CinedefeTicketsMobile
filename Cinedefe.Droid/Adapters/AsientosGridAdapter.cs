using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Cinedefe.Droid.Adapters
{
    public class AsientosGridAdapter : BaseAdapter
    {
        Context context;
        private string[] _texts;

        public AsientosGridAdapter(Context c, string[] textos)
        {
            context = c;
            _texts = textos;
        }

        public override int Count
        {
            get { return _texts.Length; }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return 0;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            TextView tv;
            if (convertView == null)
            {
                tv = new TextView(context);
                tv.LayoutParameters = new GridView.LayoutParams(85, 85);
            }
            else
            {
                tv = (TextView)convertView;
            }

            tv.Text = _texts[position];
            return tv;
        }
    }
}