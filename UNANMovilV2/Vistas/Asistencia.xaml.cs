using System;
using UNANMovilV2.Modelos;
using UNANMovilV2.VistasModelos;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UNANMovilV2.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Asistencia : ContentPage
    {
        private DAsignatura Asignatura;
        MModalidades mod = new MModalidades();
        int INSS = Login.INSS;
        int idAsignatura, cant;
        public Asistencia()
        {
            InitializeComponent();
            Asignatura = new DAsignatura();
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

        private void PcAsig_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PcAsig.SelectedItem != null)
            {
                var asignaturaSeleccionada = PcAsig.SelectedItem as MAsignatura;

                if (asignaturaSeleccionada != null)
                {
                    var parametros = new MAsignatura();
                    parametros.IdAsig = asignaturaSeleccionada.IdAsig;

                    // Llamar al método para mostrar la carrera y grupo
                    var funcion = new DAsignatura();
                    funcion.MostrarCarreraGrupo(parametros, Login.INSS);
                    // Mostrar la carrera en la etiqueta LblCarrera
                    LblCarrera.Text = funcion.carrera;
                    lblGrupo.Text = funcion.grupo;
                    string gr = lblGrupo.Text;
                    var data = funcion.MostrarContenidos(asignaturaSeleccionada.IdAsig, gr, Login.INSS);
                    PcContenido.ItemsSource = data;
                }
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (!validar())
            {
                DisplayAlert("ERROR", "Los bloques no pueden tener un valor menor a 1", "OK");
                nudBloque.Text = "1";
            }
            else
            {
                cant = int.Parse(nudBloque.Text.ToString());
                entrada.IsEnabled = false;
                contenedor.IsEnabled = true;
            }
        }
        private bool validar()
        {
            double entero;
            if (!double.TryParse(nudBloque.Text, out entero))
            {
                return false;
            }
            return !(nudBloque.Text == "");
        }
    }
}