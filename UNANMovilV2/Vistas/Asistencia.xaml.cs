using System;
using UNANMovilV2.Modelos;
using UNANMovilV2.VistasModelos;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace UNANMovilV2.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Asistencia : ContentPage
    {
        private DAsignatura Asignatura;
        MModalidades mod = new MModalidades();
        int INSS = Login.INSS;
        int idAsignatura;
        public Asistencia()
        {
            InitializeComponent();
            Asignatura=new DAsignatura();
            BindingContext = Asignatura;
            MostrarAsignaturaTurno();
        }
        
        private async void btnCerrar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
        private void MostrarAsignaturaTurno()
        {
            var funcion = new DAsignatura();
            var data = funcion.MostrarAsignaturaPlan(INSS);
            PcAsig.ItemsSource = data;

        }
        private void MostrarCarreraGrupo()
        {
            var funcion = new DAsignatura();
            var data =funcion.MostrarCarreraGrupo(idAsignatura,INSS);
        }

        private void PcAsig_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Supongamos que 'data' es una lista de objetos que tienen una propiedad 'idasignatura'
            var funcion = new DAsignatura();
            var data = funcion.MostrarAsignaturaPlan(INSS);
            lstid.ItemsSource = data;

            // Cuando necesites acceder a 'idasignatura' desde el objeto seleccionado en el CollectionView
            if (lstid.SelectedItem != null)
            {
                var itemSeleccionado = lstid.SelectedItem as MAsignatura; // Asegúrate de reemplazar 'TuTipoDeDato' con el tipo real de tus objetos
                if (itemSeleccionado != null)
                {
                    idAsignatura = itemSeleccionado.IdAsig;
                }
            }
            MostrarCarreraGrupo();
        }
    }
}