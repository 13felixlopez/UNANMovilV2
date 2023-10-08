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

            var funcion =new DAsistencia();
            var data = funcion.MostrarAsistencia(INSS);
            lstAsis.ItemsSource = data;
        }

    }
}