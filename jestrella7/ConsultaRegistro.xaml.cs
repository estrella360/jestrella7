using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace jestrella7
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultaRegistro : ContentPage
    {
        private SQLiteAsyncConnection connection;
        private ObservableCollection<Estudiante> tEstudiante;

        public ConsultaRegistro()
        {
            InitializeComponent();
            connection = DependencyService.Get<DataBase>().GetConnection();
            Listar();
        }

        public async void Listar()
        {
            var resultado = await connection.Table<Estudiante>().ToListAsync();
            tEstudiante = new ObservableCollection<Estudiante>(resultado);
            ListaEstudiantes.ItemsSource= tEstudiante;
        }

        public void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (Estudiante)e.SelectedItem;
            var item = obj.Id.ToString();
            var Id = Convert.ToInt32(item);
            var Nombre = obj.Nombre.ToString();
            var Usuario = obj.Usuario.ToString();
            var Contrasena = obj.Contrasena.ToString();
        }

        private void btnRegresar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Login());
        }
    }
}