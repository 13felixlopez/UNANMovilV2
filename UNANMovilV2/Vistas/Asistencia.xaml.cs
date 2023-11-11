using System;
using System.Collections.Generic;
using System.Security.Cryptography;
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
        List<MAsignatura> datosList = new List<MAsignatura>();
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
                contenedor.BackgroundColor = Color.White;
                entrada.BackgroundColor = Color.WhiteSmoke;
            }
        }

        private void BtnBloque_Clicked(object sender, EventArgs e)
        {
            var asig = PcAsig.SelectedItem as MAsignatura;
            var Cont = PcContenido.SelectedItem as MAsignatura;
            if (validar2())
            {
                // Crea un objeto MAsignatura con el elemento seleccionado
                MAsignatura nuevaAsignatura = new MAsignatura
                {
                    Asignatura = asig.Asignatura,
                    Carrera = LblCarrera.Text,
                    Grupo = lblGrupo.Text,
                    Contenido = Cont.Contenido,
                    Mujeres = int.Parse(TxtMujeres.Text),
                    Varones = int.Parse(TxtVarones.Text)
                };
                // Agrega el nuevo objeto a la lista global
                datosList.Add(nuevaAsignatura);
                // Actualiza la fuente de datos del ListView
                Datos.ItemsSource = null; // Primero, limpia la fuente de datos existente
                Datos.ItemsSource = datosList; // Luego, asigna la lista actualizada
                limpiar();
            }
            else
            {
                DisplayAlert("ERROR", "Debe de rellenar todos los campos", "OK");
            }
        }

        private void limpiar() 
        {
            PcContenido.SelectedItem = null;
            PcAsig.SelectedItem = null;
            lblGrupo.Text = "--";
            LblCarrera.Text = "--";
            TxtMujeres.Text = "";
            TxtVarones.Text = "";
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

        private void TxtVarones_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TxtVarones.Text!="")
            {
                BtnBloque.BackgroundColor = Color.Coral;
                BtnBloque.IsEnabled = true;
            }
            else
            {
                BtnBloque.BackgroundColor = Color.Gray;
                BtnBloque.IsEnabled = false;
            }
        }

        private bool validar2()
        {
            double entero;
            if (!double.TryParse(TxtVarones.Text, out entero)|| !double.TryParse(TxtMujeres.Text,out entero))
            {
                return false;
            }
            return !(TxtMujeres.Text == ""||TxtVarones.Text=="");
        }
    }
}