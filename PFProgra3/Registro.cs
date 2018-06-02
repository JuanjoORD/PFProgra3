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
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Ingreso ingre = new Ingreso();
            ingre.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textContraseña.Text != "" & textConfiContraseña.Text != "" & textNombre.Text != "" & textApellido.Text != "" & textNickname.Text != "" & (radioVendedor.Checked || radioAdmin.Checked))
            {
                if (textConfiContraseña.Text != textContraseña.Text)
                    label7.Text = "No coincide con la contraseña!";
                else
                {
                    string archivo = "usuarios.txt";
                    FileStream stream = new FileStream(archivo, FileMode.Append, FileAccess.Write);
                    StreamWriter writer = new StreamWriter(stream);
                    writer.WriteLine(textNombre.Text);
                    writer.WriteLine(textApellido.Text);
                    writer.WriteLine(textNickname.Text);
                    writer.WriteLine(textContraseña.Text);
                    if (radioAdmin.Checked)
                        writer.WriteLine("Administrador");
                    else if (radioVendedor.Checked)
                        writer.WriteLine("Vendedor");
                    writer.Close();
                    label7.Text = "";
                }
            }
            else
                MessageBox.Show("Es necesario llenar todos los datos solicitados...");
        }

    }
}
