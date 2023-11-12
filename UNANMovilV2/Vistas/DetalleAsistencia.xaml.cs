using System;
using UNANMovilV2.VistasModelos;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UNANMovilV2.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalleAsistencia : ContentPage
    {
        DAsistencia Asis = new DAsistencia();
        public DetalleAsistencia(int IdAsis, string horai, string horaf, string fecha)
        {
            InitializeComponent();
            var data = Asis.MostrarDetalleAsistencia(IdAsis);
            lstAsis.ItemsSource = data;
            LblFecha.Text = fecha.ToString();
            LblHoraI.Text = horai.ToString();
            LblHoraF.Text = horaf.ToString();
        }

        private async void btnCerrar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void btnHSalida_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditarAsistencia());
        }

    }
}