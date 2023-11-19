using System;
using UNANMovilV2.VistasModelos;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UNANMovilV2.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Avance : ContentPage
    {
        public Avance()
        {
            InitializeComponent();
            MostrarAP();
        }

        private async void btnCerrar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
        private void MostrarAP()
        {
            int INSS = Login.INSS;

            var funcion = new DAvance();
            var data = funcion.MostrarAvance(INSS);
            lstProg.ItemsSource = data;
        }

        private void BtnAsistencia_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MostrarAsistencia());
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

        private async void btnAdd_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddAvanceP());
        }
    }
}