using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace UNANMovilV2.VistasModelos
{
    public class Conexion
    {
        public static string conexion = ("Data Source= 192.168.133.84; Initial Catalog=UNAN1; Integrated Security=False;User=FelixL;Password=1316");
        public static SqlConnection conectar= new SqlConnection(conexion);

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
