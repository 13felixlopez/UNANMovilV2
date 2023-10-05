using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using UNANMovilV2.VistasModelos;

namespace UNANMovilV2.Modelos
{
    public class NProfes
    {
        DProfesor objd = new DProfesor();
        public DataTable Nprofe(MProfes parametros)
        {
            return objd.D_Usuarios(parametros);
        }
    }
}
