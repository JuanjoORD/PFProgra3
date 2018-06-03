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
    public partial class Vendedor : Form
    {
        public Vendedor()
        {
            InitializeComponent();
        }
        List<Cliente> custumer = new List<Cliente>();
        List<Productos> produc = new List<Productos>();

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                custumer.Clear();
                string archivo = "clientes.txt";
                FileStream stream = new FileStream(archivo, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(stream);
                while (reader.Peek() > -1)
                {
                    Cliente ct = new Cliente();
                    ct.Nit = reader.ReadLine();
                    ct.Nombre = reader.ReadLine();
                    ct.Direccion = reader.ReadLine();
                    custumer.Add(ct);
                }
                reader.Close();
                int cont = 0;
                for (int x = 0; x < custumer.Count; x++)
                    if (custumer[x].Nit == tNit.Text)
                    {
                        tNombreCliente.Text = custumer[x].Nombre;
                        tDirCliente.Text = custumer[x].Direccion;
                        cont++;
                    }
                if (cont == 0)
                    MessageBox.Show("Cliente no registrado");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Ingreso ingre = new Ingreso();
            ingre.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string archivo = "clientes.txt";
            FileStream stream = new FileStream(archivo, FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            writer.WriteLine(tNit.Text);
            writer.WriteLine(tNombreCliente.Text);
            writer.WriteLine(tDirCliente.Text);
            writer.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string archi = "inventario.txt";
            FileStream stream2 = new FileStream(archi, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream2);
            while (reader.Peek() > -1)
            {
                Productos pt = new Productos();
                pt.NombreProducto = reader.ReadLine();
            }


            string archivo = texVentaCodigo.Text + ".txt";
            FileStream stream = new FileStream(archivo, FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            writer.WriteLine(texProducCantidad.Text);
            writer.WriteLine(texProducto.Text);
        }
    }
}
