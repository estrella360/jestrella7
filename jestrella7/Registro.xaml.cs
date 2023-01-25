using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace jestrella7
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        private SQLiteAsyncConnection connection;
        public Registro()
        {
            InitializeComponent();
            connection = DependencyService.Get<DataBase>().GetConnection();
        }

        private void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            var datos = new Estudiante
            {
                Nombre = txtNombre.Text, Usuario = txtUsuario.Text, Contrasena = txtContrasena.Text,
            };
            connection.InsertAsync(datos);
            txtNombre.Text = "";
            txtContrasena.Text = "";
            txtUsuario.Text = "";
            Navigation.PushAsync(new Login());
            
        }
    }
}