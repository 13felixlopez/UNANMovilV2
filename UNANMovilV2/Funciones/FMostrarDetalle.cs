using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UNANMovilV2.Vistas;
using UNANMovilV2.VistasModelos;
using Xamarin.Forms;

namespace UNANMovilV2.Funciones
{
    public class FMostrarDetalle:BaseViewModel
    {
        public FMostrarDetalle(INavigation navigation)
        {
            Navigation = navigation;
            DetalleCommand = new Command(async () => await Detalle());
        }
        private async Task Detalle()
        {
            await Navigation.PushAsync(new DetalleAsistencia());
        }
        public ICommand DetalleCommand { get; }
    }
}
