using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyProxy
{
    public class CompraAgulha
    {
        public Boolean ComandoCompra { get; set; }
        public String Pergunta { get; set; }

        public DateTime InicioConversa { get; set; }

        public CompraAgulha()
        {
            this.ComandoCompra = false;
            this.Pergunta = "";
        }
    }
}
