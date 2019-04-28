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
using Cinedefe.Core.Repository;
using Cinedefe.Droid.Adapters;

namespace Cinedefe.Droid
{
    [Activity(Label = "SeleccionaBoletosActivity")]
    public class SeleccionaBoletosActivity : Activity
    {
        private TextView ciudadTitleTextView;
        private TextView sucursalTitleTextView;
        private TextView peliculaTitleTextView;
        private TextView horarioTitleTextView;
        private EditText cantidadEditText;
        private Button substractButton;
        private Button addButton;
        private Button continuarButton;

        private CarteleraWebRepository carteleraRepository;

        private string ciudadNombre;
        private string sucursalNombre;
        private string funcionNombre;
        private DateTime horario;
        private int funcionId;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.BoletosView);

            carteleraRepository = new CarteleraWebRepository();

            ciudadNombre = Intent.Extras.GetString("selectedCiudadNombre");
            sucursalNombre = Intent.Extras.GetString("selectedSucursalNombre");
            funcionNombre = Intent.Extras.GetString("selectedFuncionNombre");
            horario = DateTime.Parse(Intent.Extras.GetString("selectedHorario"));
            funcionId = Intent.Extras.GetInt("selectedFuncionId");

            FindViews();

            BindData();

            HandleEvents();
        }

        private void BindData()
        {
            ciudadTitleTextView.Text = ciudadNombre;
            sucursalTitleTextView.Text = sucursalNombre;
            peliculaTitleTextView.Text = funcionNombre;
            horarioTitleTextView.Text = horario.ToString("dd/MMM/yyyy") + "- " + horario.ToString("HH:mm");
        }

        private void FindViews()
        {
            ciudadTitleTextView = FindViewById<TextView>(Resource.Id.ciudadTitleTextView);
            sucursalTitleTextView = FindViewById<TextView>(Resource.Id.sucursalTitleTextView);
            peliculaTitleTextView = FindViewById<TextView>(Resource.Id.peliculaTitleTextView);
            horarioTitleTextView = FindViewById<TextView>(Resource.Id.horarioTitleTextView);
            cantidadEditText = FindViewById<EditText>(Resource.Id.cantidadEditText);
            cantidadEditText.SetSelection(cantidadEditText.Text.Length);
            addButton = FindViewById<Button>(Resource.Id.addButton);
            substractButton = FindViewById<Button>(Resource.Id.substractButton);
            continuarButton = FindViewById<Button>(Resource.Id.continuarButton);
        }

        private void HandleEvents()
        {
            addButton.Click += AddButton_Click;
            substractButton.Click += SubstractButton_Click;
            continuarButton.Click += ContinueButton_Click;
        }

        #region Events
        private void AddButton_Click(object sender, EventArgs e)
        {
            var cantidad = Int32.Parse(cantidadEditText.Text);

            ++cantidad;

            cantidadEditText.Text = cantidad.ToString();
            cantidadEditText.SetSelectAllOnFocus(true);

        }

        private void SubstractButton_Click(object sender, EventArgs e)
        {
            var cantidad = Int32.Parse(cantidadEditText.Text);

            if (cantidad > 0)
            {
                --cantidad;

                cantidadEditText.Text = cantidad.ToString();
                cantidadEditText.SetSelection(cantidadEditText.Text.Length);

            }
        }

        private void ContinueButton_Click(object sender, EventArgs e)
        {
            var cantidadBoletos = Int32.Parse(cantidadEditText.Text);

            if (cantidadBoletos == 0)
            {
                var dialog = new AlertDialog.Builder(this);
                dialog.SetTitle("Aviso");
                dialog.SetMessage("No es posible continuar, sin boleto no podrás entrar a la sala");
                dialog.Show();
            }

            var intent = new Intent();
            intent.SetClass(this, typeof(SeleccionaAsientosActivity));
            intent.PutExtra("selectedCiudadNombre", ciudadNombre);
            intent.PutExtra("selectedSucursalNombre", sucursalNombre);
            intent.PutExtra("selectedFuncionNombre", funcionNombre);
            intent.PutExtra("selectedFuncionId", funcionId);
            intent.PutExtra("selectedHorario", horario.ToString("yyyy-MM-ddTHH:mm"));
            intent.PutExtra("cantidadBoletos", cantidadBoletos.ToString());

            StartActivity(intent);
        }
        #endregion Events
    }
}