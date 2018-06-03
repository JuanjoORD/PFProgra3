using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFProgra3
{
    class Factura
    {
        decimal cantidad;
        string producto;
        decimal precio;
        decimal subtotal;

        public decimal Cantidad
        {
            set { this.cantidad = value; }
            get { return this.cantidad; }
        }
        public string Producto
        {
            set { this.producto = value; }
            get { return this.producto; }
        }
        public decimal Precio
        {
            set { this.precio = value; }
            get { return this.precio; }
        }
        public decimal Subtotal
        {
            set { this.subtotal = value; }
            get { return this.subtotal; }
        }
    }
}
