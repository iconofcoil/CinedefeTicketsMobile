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
    public class FuncionHorariosFechasListAdapter : BaseAdapter<FuncionHorario>
    {
        List<FuncionHorario> items;
        Activity context;
        bool horarios;

        public FuncionHorariosFechasListAdapter(Activity context, List<FuncionHorario> items, bool isHorarios = false) : base()
        {
            this.context = context;
            this.items = items;
            this.horarios = isHorarios;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override FuncionHorario this[int position]
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

            convertView.FindViewById<TextView>(Android.Resource.Id.Text1).Text = this.horarios ?
                                                                                 item.Horario.ToString("HH:mm") :
                                                                                 item.Horario.Date.ToString("dd/MMM/yyyy");

            return convertView;
        }
    }
}