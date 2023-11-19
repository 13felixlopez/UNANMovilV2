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
        int ID;
        public DetalleAsistencia(int IdAsis, string horai, string horaf, string fecha)
        {
            InitializeComponent();
            var data = Asis.MostrarDetalleAsistencia(IdAsis);
            lstAsis.ItemsSource = data;
            LblFecha.Text = fecha.ToString();
            LblHoraI.Text = horai.ToString();
            LblHoraF.Text = horaf.ToString();
            ID = IdAsis;
        }

        private async void btnCerrar_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PopAsync()
            var HoraI = LblHoraI.Text;
            var HoraF = LblHoraF.Text;
            var Fecha = LblFecha.Text;
            Editar(ID, HoraI, HoraF, Fecha);
        }

        private async void Editar(int IdAsis, string horai, string horaf, string fecha)
        {
            await Navigation.PushAsync(new EditarAsistencia(IdAsis, horai, horaf, fecha));
        }
        private async void btnHSalida_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new EditarAsistencia(int IdAsis, string horai, string horaf, string fecha));
        }

    }
}