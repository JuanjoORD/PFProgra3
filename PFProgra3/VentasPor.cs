using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFProgra3
{
    class VentasPor
    {
        string vendedor;
        string codigoventa;
        float montoventa;

        public string Vendedor
        {
            set { this.vendedor = value; }
            get { return this.vendedor; }
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
