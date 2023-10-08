using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using UNANMovilV2.Modelos;
using Xamarin.Forms;

namespace UNANMovilV2.VistasModelos
{
    public class DAsistencia
    {
        public List<LAsistencia> MostrarAsistencia(int INSS)
        {
            var LstAsis = new List<LAsistencia>();
            try
            {
                DataTable dt =new DataTable();
                // Se abre la conexión a la base de datos
                Conexion.Abrir();

                SqlDataAdapter da = new SqlDataAdapter("MostrarAsistencia", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@INSS", INSS);
                da.Fill(dt);
                foreach (DataRow rdr in dt.Rows)
                {
                    var parametros = new LAsistencia();
                    parametros.Fecha = DateTime.Parse(rdr["Fecha"].ToString()).ToString("dd/MM/yyyy");
                    parametros.HoraInicio = DateTime.Parse(rdr["Hora de Entrada"].ToString()).ToString("HH:mm");
                    parametros.HoraFin = DateTime.Parse(rdr["Hora de Salida"].ToString()).ToString("HH:mm");
                    parametros.Bloques = int.Parse(rdr["Bloques"].ToString());
                    LstAsis.Add(parametros);
                }
                return LstAsis;
            }
            catch (Exception ex)
            {
                Application.Current.MainPage.DisplayAlert("ERROR", ex.Message, "OK");
                return LstAsis;
            }
            finally
            {
                Conexion.Cerrar();
            }
        }


    }
}
