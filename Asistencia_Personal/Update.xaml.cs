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
        public Update( string codigo, string nombre, string apellido, string edad)
        {
            InitializeComponent();
            obtener(codigo, nombre, apellido, edad);
        }
        public  void obtener(string codigo, string nombre, string apellido, string edad)
        {
      
            txtCodigo.Text = codigo;
            txtNombre.Text = nombre;
            txtApellido.Text = apellido;
            txtEdad.Text = edad;
         
        }
        private void btnRegresar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }

        private void btnUpdate_Clicked(object sender, EventArgs e)
        {

            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("codigo", txtCodigo.Text);
                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("apellido", txtApellido.Text);
                parametros.Add("edad", txtEdad.Text);

                cliente.UploadValues(" http://192.168.100.71:8095/moviles/1/post.php?codigo=" + Int16.Parse(txtCodigo.Text) + "&nombre=" + txtNombre.Text + "&apellido=" + txtApellido.Text + "&edad=" + txtEdad.Text, "PUT", parametros);

                txtCodigo.Text = txtCodigo.Text;
                txtNombre.Text = txtCodigo.Text;
                txtApellido.Text = txtApellido.Text;
                txtEdad.Text = txtEdad.Text;


                DisplayAlert("ALERT", "Dato actualizado correctamente", "salir");
            }
            catch (Exception ex)
            {
                DisplayAlert("ALERTA", ex.Message, "cerrar");
            }
        }

        private void btnInsertar_Clicked_1(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
 
                cliente.UploadValues(" http://192.168.100.71:8095/moviles/1/post.php?codigo=" + Int16.Parse(txtCodigo.Text), "DELETE", parametros);

                DisplayAlert("ALERT", "Dato eliminado correctamente", "salir");
            }
            catch (Exception ex)
            {
                DisplayAlert("ALERTA", ex.Message, "cerrar");
            }
        }
    }
}