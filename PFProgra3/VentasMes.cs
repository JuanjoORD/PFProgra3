using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFProgra3
{
    class VentasMes:VentasPor
    {
        string vendedor;

        public string Vendedor
        {
            set { this.vendedor = value; }
            get { return this.vendedor; }
        }
    }
}
