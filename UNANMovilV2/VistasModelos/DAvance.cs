using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using UNANMovilV2.Modelos;
using Xamarin.Forms;

namespace UNANMovilV2.VistasModelos
{
    public class DAvance
    {
        public List<LAvance> MostrarAvance(int INSS)
        {
            var lstProg = new List<LAvance>();
            try
            {
                DataTable dt = new DataTable();
                // Se abre la conexión a la base de datos
                Conexion.Abrir();

                SqlDataAdapter da = new SqlDataAdapter("MostrarAvacesProgramatico", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@INSS", INSS);
                da.Fill(dt);
                foreach (DataRow rdr in dt.Rows)
                {
                    var parametros = new LAvance();
                    parametros.Fecha = DateTime.Parse(rdr["Fecha"].ToString()).ToString("dd/MMM/yyyy");
                    parametros.Asignatura = rdr["Asignatura"].ToString();
                    lstProg.Add(parametros);
                }
                return lstProg;
            }
            catch (Exception ex)
            {
                Application.Current.MainPage.DisplayAlert("ERROR", ex.Message, "OK");
                return lstProg;
            }
            finally
            {
                Conexion.Cerrar();
            }
        }
    }
}
