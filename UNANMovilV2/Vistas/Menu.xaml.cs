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
    public partial class Menu : ContentPage
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnCerrar_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private async void btnAsistencia_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MostrarAsistencia());
        }

        private async void btnAvance_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Avance());
        }
    }
}