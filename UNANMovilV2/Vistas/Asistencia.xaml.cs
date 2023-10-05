using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNANMovilV2.Modelos;
using UNANMovilV2.VistasModelos;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static UNANMovilV2.VistasModelos.DModalidad;

namespace UNANMovilV2.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Asistencia : ContentPage
    {
        private DModalidad viewModel;
        MModalidades mod = new MModalidades();
        public Asistencia()
        {
            InitializeComponent();
            viewModel=new DModalidad();
            BindingContext = viewModel;

            viewModel.MostrarModalidades(PcModalidades);
            viewModel.MostrarSemestre(PcSemestre);
            //viewModel.CarreraXProfesor(PcCarrera, Login.idprofesor, Modalidad, Semestre);
        }
        
        private async void btnCerrar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void PcModalidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void PcSemestre_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}