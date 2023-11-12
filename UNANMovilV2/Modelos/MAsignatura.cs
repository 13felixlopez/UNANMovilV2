using System;

namespace UNANMovilV2.Modelos
{
    public class MAsignatura
    {
        public string Asignatura { get; set; }
        public string Carrera { get; set; }
        public string Grupo { get; set; }
        public string Turno { get; set; }
        public string Contenido { get; set; }
        public int TotalHora { get; set; }
        public int INSS { get; set; }
        public int IdAsig { get; set; }
        public int IdTema { get; set; }
        public int Varones { get; set; }
        public int Mujeres { get; set; }
        public DateTime Fecha { get; set; }
        public int Bloques { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }
        public string Observacion { get; set; }
    }
}
