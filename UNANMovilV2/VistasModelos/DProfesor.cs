using System;
using System.Data;
using System.Data.SqlClient;
using UNANMovilV2.Modelos;

namespace UNANMovilV2.VistasModelos
{
    public class DProfesor
    {
        #region Validar Usuarios para Login
        public DataTable D_Usuarios(MProfes parametros)
        {
            try
            {
                Conexion.Abrir();
                SqlCommand cmd = new SqlCommand("Login", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@INSS", parametros.INSS);
                cmd.Parameters.AddWithValue("Password", parametros.Password);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Conexion.Cerrar();
            }
        }
        #endregion
    }
}
