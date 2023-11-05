using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}