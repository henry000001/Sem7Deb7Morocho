using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sem7Deb7Morocho.Models;
using SQLite;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sem7Deb7Morocho
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        private SQLiteAsyncConnection con;
        public Login()
        {
            InitializeComponent();
            con = DependencyService.Get<Database>().GetConnection();
        }
        public static IEnumerable<Estudiante> Select_Where(SQLiteConnection db, string usuario, string contrasena)
        {
            return db.Query<Estudiante>("SELECT * FROM Estudiante where Usuario = ? and Contrasena", usuario, contrasena);

        }
        private void btnIniciar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(databasePath);
                db.CreateTable<Estudiante>();
                IEnumerable<Estudiante> resultado = Select_Where(db,txtUsuario.Text,txtcontrasena.Text);
                if (resultado.Count() > 0)
                {
                    Navigation.PushAsync(new ConsultaRegistro());
                }
                else
                {
                    DisplayAlert("alerta", "Usuario o Contraseña Incorrecta", "OK");
                }

            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "OK");
                
            }
        }

        private void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Registro());
        }
    }
}