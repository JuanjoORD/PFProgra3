using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFProgra3
{
    class VentasPor
    {
        string cliente;
        string codigoventa;
        float montoventa;

        public string Cliente
        {
            set { this.cliente = value; }
            get { return this.cliente; }
        }
        public string Codigoventa
        {
            set { this.codigoventa = value; }
            get { return this.codigoventa; }
        }
        public float Montoventa
        {
            set { this.montoventa = value; }
            get { return this.montoventa; }
        }
    }
}
