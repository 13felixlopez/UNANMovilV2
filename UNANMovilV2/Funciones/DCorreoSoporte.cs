using System;
using System.Collections.Generic;
using System.Text;

namespace UNANMovilV2.Funciones
{
    public class DCorreoSoporte:Recuperacion
    {
        /* El método `public DCorreoSoporte()` es un constructor de la clase `DCorreoSoporte`. Se
        encarga de inicializar las propiedades de la clase, como `remitenteCorreo`, `contraseña`,
        `host`, `puerto` y `ssl`. */
        public DCorreoSoporte()
        {
            remitenteCorreo = "lfelixlopez732@gmail.com";
            password = "ckcfjpjydmpyiwjy";
            host = "smtp.gmail.com";
            port = 587;
            ssl = true;
            initialzeSmtpClient();
        }
    }
}
