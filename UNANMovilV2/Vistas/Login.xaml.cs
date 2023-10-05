using System;
using System.Data;
using System.Threading.Tasks;
using UNANMovilV2.Modelos;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UNANMovilV2.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        MProfes mprofes = new MProfes();
        NProfes nprofes= new NProfes();
        public static string nombreprofe;
        public static byte[] Icono;
        public static int idprofesor;
        public static string correo;
        public static string Tusuario;
        public static int INSS;
        public Login()
        {
            InitializeComponent();
        }

        private async void BtnIniciarSesion_Clicked(object sender, EventArgs e)
        {
            await Logueo();
        }

        private async Task Logueo()
        {
            DataTable dt=new DataTable();
            mprofes.INSS = int.Parse(txtINSS.Text);
            mprofes.Password = Encrip.Encriptar(Encrip.Encriptar(txtPass.Text));
            try
            {
                dt = nprofes.Nprofe(mprofes);
                if (dt.Rows.Count>0)
                {
                    idprofesor = Convert.ToInt32(dt.Rows[0][0]);
                    nombreprofe = dt.Rows[0][1].ToString();
                    Icono = (byte[])dt.Rows[0][3];
                    correo = dt.Rows[0][5].ToString();
                    Tusuario = dt.Rows[0][6].ToString();
                    INSS = int.Parse(dt.Rows[0][2].ToString());
                    await Navigation.PushAsync(new Menu());
                    txtINSS.Text = "";
                    txtPass.Text = "";
                }
                else
                {
                    await DisplayAlert("ERROR", "Usuario o Contraseña Incorrectos", "Ok");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("ERROR", ex.Message, "OK");
            }
        }
    }
}