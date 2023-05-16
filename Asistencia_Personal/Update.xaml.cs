using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


using System.ComponentModel;

using System.Net.Http;
using System.Net;

using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace Asistencia_Personal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Update : ContentPage
    {
        private ObservableCollection<Asistencia_Personal.MainPage.DemoAPI> _post;
        public Update()
        {
            InitializeComponent();
            obtener();
        }
        public async void obtener()
        {
            var url = "http://192.168.100.71:8095/moviles/1/post.php";
            var client = new HttpClient();
            var content = await client.GetStringAsync(url);
            List<Asistencia_Personal.MainPage.DemoAPI> posts = JsonConvert.DeserializeObject<List<Asistencia_Personal.MainPage.DemoAPI>>(content);
            _post = new ObservableCollection<Asistencia_Personal.MainPage.DemoAPI>(posts);

            txtCodigo.Text = "36";

           // MyListView.ItemsSource = _post;
        }
        private void btnRegresar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }

        private void btnInsertar_Clicked(object sender, EventArgs e)
        {
         
        }
    }
}