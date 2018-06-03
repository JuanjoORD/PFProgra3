using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFProgra3
{
    class DatosFac
    {
        string nombreprod;
        string cantidadprod;

        public string Nombreprod
        {
            set { this.nombreprod = value; }
            get { return this.nombreprod; }
        }
        public string Cantidadprod
        {
            set { this.cantidadprod = value; }
            get { return this.cantidadprod; }
        }
        
    }
}
