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

using Cinedefe.Core.Model;

namespace Cinedefe.Droid.Adapters
{
    public class PeliculasSalasListAdapter : BaseAdapter<SucursalPeliculas>
    {
        List<SucursalPeliculas> items;
        Activity context;

        public PeliculasSalasListAdapter(Activity context, List<SucursalPeliculas> items) : base()
        {
            this.context = context;
            this.items = items;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override SucursalPeliculas this[int position]
        {
            get
            {
                return items[position];
            }
        }

        public override int Count
        {
            get
            {
                return items.Count;
            }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];

            if (convertView == null)
            {
                convertView = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
            }

            string peliculaSalaText = item.PeliculaTitulo + " " + item.PeliculaDuracion + " - Sala " + item.SalaNombre;
            convertView.FindViewById<TextView>(Android.Resource.Id.Text1).Text = peliculaSalaText;

            return convertView;
        }
    }
}