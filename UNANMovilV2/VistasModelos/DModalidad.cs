using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using UNANMovilV2.Funciones;
using Xamarin.Forms;

namespace UNANMovilV2.VistasModelos
{
    public class DModalidad
    {
        //public ObservableCollection<MModalidades> Modalidades { get; set; }
        public ObservableCollection<LModalidad> Modalidades { get; set; }
        //public ObservableCollection<string> Modalidades { get; set; }
        public ObservableCollection<string> Semestre { get; set; }
        public ObservableCollection<string> Carrera { get; set; }
        public DModalidad()
        {
            Modalidades = new ObservableCollection<LModalidad>();
            //Modalidades = new ObservableCollection<string>();
            Semestre = new ObservableCollection<string>();
            Carrera = new ObservableCollection<string>();
        }
        public class LModalidad
        {
            public int IdModalidad { get; set; }
            public string Modalidad { get; set; }
        }

        public class LSemestre
        {
            public int IdSemestre { get; set; }
            public string Semestre { get; set; }
        }
        public class LCarrera
        {
            public int IdCarrera { get; set; }
            public string Carrera { get; set; }
        }
        public void MostrarModalidades(DisplayMemberPicker combo)
        {
            try
            {
                List<LModalidad> modalidades = new List<LModalidad>();

                Conexion.Abrir();
                SqlCommand da = new SqlCommand("MostrarModalidad", Conexion.conectar);
                da.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter cb = new SqlDataAdapter(da);
                DataTable dt = new DataTable();
                cb.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int id = Convert.ToInt32(dt.Rows[i]["IdModalidad"]);
                    string nombre = dt.Rows[i]["Modalidad"].ToString();
                    modalidades.Add(new LModalidad { IdModalidad = id, Modalidad = nombre });
                }


                combo.ItemsSource = modalidades;
                combo.DisplayMemberPath = "Modalidad";
                combo.ClassId = "IdModalidad";
                combo.SelectedItem = modalidades.FirstOrDefault(); // Establece el primer elemento como seleccionado por defecto
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


        public void MostrarSemestre(Picker combo)
        {
            try
            {
                List<LSemestre> semestre = new List<LSemestre>();

                Conexion.Abrir();
                SqlCommand da = new SqlCommand("MostrarSemestre", Conexion.conectar);
                da.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter cb = new SqlDataAdapter(da);
                DataTable dt = new DataTable();
                cb.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int idsemestre = Convert.ToInt32(dt.Rows[i]["IdSemestre"]);
                    string Semestre = dt.Rows[i]["Semestre"].ToString();
                    semestre.Add(new LSemestre { IdSemestre = idsemestre, Semestre = Semestre });
                }

                combo.ItemsSource = semestre;
                combo.SelectedItem = semestre.FirstOrDefault();
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

        public void CarreraXProfesor(Picker combo, int Idprofe, string Modalidad, string Semestre)
        {
            try
            {
                List<LCarrera> carreras = new List<LCarrera>();

                Conexion.Abrir();
                SqlCommand da = new SqlCommand("CarreraXProfesor", Conexion.conectar);
                da.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter cb = new SqlDataAdapter(da);
                DataTable dt = new DataTable();
                da.Parameters.AddWithValue("@IdProfesor", Idprofe);
                da.Parameters.AddWithValue("@Modalidad", Modalidad);
                da.Parameters.AddWithValue("@Semestre", Semestre);
                cb.Fill(dt);


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int idcarrera = Convert.ToInt32(dt.Rows[i]["IdCarrera"]);
                    string Carrera = dt.Rows[i]["NombreC"].ToString();
                    carreras.Add(new LCarrera { IdCarrera = idcarrera, Carrera = Carrera });
                }

                combo.ItemsSource = carreras;
                combo.SelectedItem = carreras.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                //Cerrar la conexión a la base de datos
                Conexion.Cerrar();
            }
        }
    }
}
