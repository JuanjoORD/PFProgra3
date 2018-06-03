using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFProgra3
{
    class VentasPor
    {
        string codigoventa;
        string montoventa;
        string vendedor;
        string dia;
        string mes;
        string anio;
        string hora;

        public string Codigoventa
        {
            set { this.codigoventa = value; }
            get { return this.codigoventa; }
        }
        public string Montoventa
        {
            set { this.montoventa = value; }
            get { return this.montoventa; }
        }
        public string Vendedor
        {
            set { this.vendedor = value; }
            get { return this.vendedor; }
        }
        public string Dia
        {
            set { this.dia = value; }
            get { return this.dia; }
        }
        public string Mes
        {
            set { this.mes = value; }
            get { return this.mes; }
        }
        public string Anio
        {
            set { this.anio = value; }
            get { return this.anio; }
        }
        public string Hora
        {
            set { this.hora = value; }
            get { return this.hora; }
        }
    }
}
