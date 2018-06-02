using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFProgra3
{
    class Productos
    {
        string nombreProducto;
        decimal precioProducto;
        string codigoProducto;
        int cantidadProducto;

        public string NombreProducto
        {
            set { this.nombreProducto = value; }
            get { return this.nombreProducto; }
        }
        public decimal PrecioProducto
        {
            set { this.precioProducto = value; }
            get { return this.precioProducto; }
        }
        public string CodigoProducto
        {
            set { this.codigoProducto = value; }
            get { return this.codigoProducto; }
        }
        public int CantidadProducto
        {
            set { this.cantidadProducto = value; }
            get { return this.cantidadProducto; }
        }
    }
}
