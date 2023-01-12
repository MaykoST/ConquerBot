using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyProxy
{
    public class EntradaMina
    {
        public Boolean ComandoEntrada { get; set; }        
        public String Pergunta { get; set; }

        public DateTime InicioConversa { get; set; }

        public EntradaMina()
        {
            ComandoEntrada = false;
            Pergunta = "";
        }
    }
}
