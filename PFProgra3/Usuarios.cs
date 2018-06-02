using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFProgra3
{
    class Usuarios
    {
        string nombre;
        string apellido;
        string nickname;
        string contraseña;
        string tipousuario;

        public string Nombre
        {
            set { this.nombre = value;}
            get {return this.nombre;}
        }
        public string Apellido
        {
            set { this.apellido = value; }
            get { return this.apellido; }
        }
        public string Nickname
        {
            set { this.nickname = value; }
            get { return this.nickname; }
        }
        public string Contraseña
        {
            set { this.contraseña = value; }
            get { return this.contraseña; }
        }
        public string Tipousuario
        {
            set { this.tipousuario = value; }
            get { return this.tipousuario; }
        }
    }
}
