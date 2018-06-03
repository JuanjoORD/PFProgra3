using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFProgra3
{
    class Cliente
    {
        string nit;
        string nombre;
        string direccion;

        public string Nit
        {
            set { this.nit = value; }
            get { return this.nit; }
        }
        public string Nombre
        {
            set { this.nombre = value; }
            get { return this.nombre; }
        }
        public string Direccion
        {
            set { this.direccion = value; }
            get { return this.direccion; }
        }
    }
}
