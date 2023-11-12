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
                DataTable dt = new DataTable();
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

        public void Insertaasistencias(MAsignatura parametros, List<MAsignatura> lst)
        {
            try
            {
                //Se crea el DataTable con los campos necesarios
                var dt = new DataTable();
                dt.Columns.Add("Id");
                dt.Columns.Add("IdAsignatura");
                dt.Columns.Add("IdTema");
                dt.Columns.Add("AsistenciaMujeres");
                dt.Columns.Add("AsistenciaVarones");

                int i = 1;

                //Se recorre la lista agregando los parametros que seran enviados a la base de datos
                foreach (var oElement in lst)
                {
                    dt.Rows.Add(i, oElement.IdAsig, oElement.IdTema, oElement.Mujeres, oElement.Varones);
                    i++;
                }

                //Se abre la conexión a la base de datos
                Conexion.Abrir();

                //Crear el comando para el procedimiento almacenado
                SqlCommand cmd = new SqlCommand("InsertarAsistenciaYBloques", Conexion.conectar);
                var parameterlst = new SqlParameter("@ltsAsistencia", SqlDbType.Structured)
                {
                    TypeName = "Asistencias",
                    Value = dt
                };

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(parameterlst);
                cmd.Parameters.AddWithValue("@INSS", parametros.INSS);
                cmd.Parameters.AddWithValue("@Fecha", parametros.Fecha);
                cmd.Parameters.AddWithValue("@Bloques", parametros.Bloques);
                cmd.Parameters.AddWithValue("@HoraI", parametros.HoraInicio);
                cmd.Parameters.AddWithValue("@HoraF", parametros.HoraFin);
                cmd.Parameters.AddWithValue("@Observacion", parametros.Observacion);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Application.Current.MainPage.DisplayAlert("ERROR", ex.Message, "OK");
            }
            finally
            {
                //Se cierra la conexión a la base de datos
                Conexion.Cerrar();
            }

        }
    }
}
