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
    public partial class RestablecerPass : ContentPage
    {
        public RestablecerPass()
        {
            InitializeComponent();
        }

        private void btnCerrar_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}