using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Cinedefe.Core.Model;
using Cinedefe.Droid.Utility;

namespace Cinedefe.Droid.Adapters
{
    public class FuncionesListAdapter : BaseAdapter<FuncionDisponible>
    {
        List<FuncionDisponible> items;
        Activity context;

        public FuncionesListAdapter(Activity context, List<FuncionDisponible> items) : base()
        {
            this.context = context;
            this.items = items;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override FuncionDisponible this[int position]
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

            Bitmap posterPelicula = BitmapFactory.DecodeByteArray(item.PeliculaPoster, 0, item.PeliculaPoster.Length);

            if (convertView == null)
            {
                convertView = context.LayoutInflater.Inflate(Resource.Layout.FuncionRowView, null);
            }

            string peliculaSubtitulo = item.PeliculaDuracion + " min | Clasif. " + item.PeliculaClasificacion;
            string sala = "Sala " + item.SalaNombre + " " + item.SalaTipo;

            convertView.FindViewById<TextView>(Resource.Id.peliculaTituloTextView).Text = item.PeliculaTitulo;
            convertView.FindViewById<TextView>(Resource.Id.peliculaSubtituloTextView).Text = peliculaSubtitulo;
            convertView.FindViewById<TextView>(Resource.Id.salaTextView).Text = sala;
            convertView.FindViewById<ImageView>(Resource.Id.peliculaPosterView).SetImageBitmap(posterPelicula);

            return convertView;
        }
    }
}