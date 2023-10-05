using System;
using System.Threading.Tasks;
using System.Windows.Input;
using UNANMovilV2.Funciones;
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
        }
        private async void btnAdd_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Asistencia());
        }

        
    }
}