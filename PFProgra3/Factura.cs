using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFProgra3
{
    class Factura
    {
        string cantidad;
        string producto;
        string precio;
        string subtotal;

        public string Cantidad
        {
            set { this.cantidad = value; }
            get { return this.cantidad; }
        }
        public string Producto
        {
            set { this.producto = value; }
            get { return this.producto; }
        }
        public string Precio
        {
            set { this.precio = value; }
            get { return this.precio; }
        }
        public string Subtotal
        {
            set { this.subtotal = value; }
            get { return this.subtotal; }
        }
    }
}
