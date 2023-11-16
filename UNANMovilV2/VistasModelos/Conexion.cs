using System.Data;
using System.Data.SqlClient;

namespace UNANMovilV2.VistasModelos
{
    public class Conexion
    {
        //public static string conexion = ("Data Source= 192.168.246.84; Initial Catalog=UNAN1; Integrated Security=False;User=Dixon;Password=1311");
        public static string conexion = ("Data Source=  192.168.16.84; Initial Catalog=UNAN1; Integrated Security=False;User=FelixL;Password=1316");
        public static SqlConnection conectar = new SqlConnection(conexion);

        public static void Abrir()
        {
            if (conectar.State == ConnectionState.Closed)
            {
                conectar.Open();
            }
        }

        public static void Cerrar()
        {
            if (conectar.State == ConnectionState.Open)
            {
                conectar.Close();
            }
        }
    }
}
