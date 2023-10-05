using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UNANMovilV2.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalleAsistencia : ContentPage
    {
        public DetalleAsistencia()
        {
            InitializeComponent();
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