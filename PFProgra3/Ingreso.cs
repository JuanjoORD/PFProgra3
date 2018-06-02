using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PFProgra3
{
    public partial class Ingreso : Form
    {
        public Ingreso()
        {
            InitializeComponent();
        }
        List<Usuarios> user = new List<Usuarios>();
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                tContraseña.PasswordChar = Convert.ToChar('\0');
            else if(checkBox1.Checked == false)
                tContraseña.PasswordChar = Convert.ToChar("*");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registro register = new Registro();
            register.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tNickname.Text != "" & tContraseña.Text != "")
            {
                user.Clear();
                string archivo = "usuarios.txt";
                FileStream stream = new FileStream(archivo, FileMode.Open, FileAccess.Read);
                StreamReader lector = new StreamReader(stream);
                while(lector.Peek() > -1)
                {
                    Usuarios utemp = new Usuarios();
                    utemp.Nombre = lector.ReadLine();
                    utemp.Apellido = lector.ReadLine();
                    utemp.Nickname = lector.ReadLine();
                    utemp.Contraseña = lector.ReadLine();
                    utemp.Tipousuario = lector.ReadLine();
                    user.Add(utemp);
                }
                lector.Close();
                for (int x = 0; x < user.Count; x++)
                {
                    if (user[x].Nickname == tNickname.Text & user[x].Contraseña == tContraseña.Text)
                    {
                        if (user[x].Tipousuario == "Administrador")
                        {
                            Administrador ad = new Administrador();
                            ad.Show();
                            this.Hide();
                        }
                        else if (user[x].Tipousuario == "Vendedor")
                        {
                            Vendedor vende = new Vendedor();
                            vende.Show();
                            this.Hide();
                        }
                    }
                }
            }
            else
                MessageBox.Show("Llene todas las casillas...");
        }

    }
}
