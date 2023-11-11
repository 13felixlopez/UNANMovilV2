using System;
using UNANMovilV2.Funciones;
using UNANMovilV2.VistasModelos;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UNANMovilV2.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MostrarAsistencia : ContentPage
    {

        public MostrarAsistencia()
        {
            InitializeComponent();
            BindingContext = new FMostrarDetalle(Navigation);
            VerAsistencia();
        }
        private async void btnAdd_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Asistencia());
        }

        private void VerAsistencia()
        {
            int INSS = Login.INSS;

            var funcion = new DAsistencia();
            var data = funcion.MostrarAsistencia(INSS);
            lstAsis.ItemsSource = data;
        }
        protected override bool OnBackButtonPressed()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                bool respuesta = await DisplayAlert("Cerrar Sesión", "¿Desea cerrar la sesión?", "Sí", "No");

                if (respuesta) // Si el usuario presionó "Sí"
                {
                    // Realiza la navegación a la página de inicio de sesión (LoginPage)
                    App.Current.MainPage = new NavigationPage(new Login());
                }
                else
                {
                    // El usuario eligió "No", no se realiza ninguna acción adicional
                }
            });

            return true; // Evita que la página actual aparezca en la pila de navegación
        }

        private void BtnAP_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Avance());
        }

        private async void BtnSalir_Clicked(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new Login());
            bool respuesta = await DisplayAlert("Cerrar Sesión", "¿Desea cerrar la sesión?", "Sí", "No");

            if (respuesta) // Si el usuario presionó "Sí"
            {
                // Realiza la navegación a la página de inicio de sesión (LoginPage)
                App.Current.MainPage = new NavigationPage(new Login());
            }
            else
            {
                // El usuario eligió "No", no se realiza ninguna acción adicional
            }
        }

    }
}