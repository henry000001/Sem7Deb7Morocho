using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using Sem7Deb7Morocho.Models;

namespace Sem7Deb7Morocho
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        private SQLiteAsyncConnection con;
        public Registro()
        {
            InitializeComponent();
            con = DependencyService.Get<Database>().GetConnection();
        }

        private void btnRegistro_Clicked(object sender, EventArgs e)
        {
            try
            {
                var datosRegistro = new Estudiante { Nombre = txtNombre.Text, Usuario = txtUsuario.Text, Contrasena = txtContrasena.Text };
                con.InsertAsync(datosRegistro);
                LimpiarFormulario();

            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "Ok");
                
            }
        }

        void LimpiarFormulario()
        {

            txtNombre.Text = "";
            txtUsuario.Text = "";
            txtContrasena.Text = "";
            DisplayAlert("Alerta", "Se Agrego Correctamente", "OK");
        }

        private async void btnRegresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Login());
        }
    }
}