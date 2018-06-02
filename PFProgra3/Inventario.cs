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
    public partial class Inventario : Form
    {
        public Inventario()
        {
            InitializeComponent();
        }
        List<Productos> producto = new List<Productos>();
        private void button4_Click(object sender, EventArgs e)
        {
            Administrador admin = new Administrador();
            admin.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombre = tNombreProducto.Text;
            string archivo = "inventario.txt";
            FileStream stream = new FileStream(archivo, FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            writer.WriteLine(nombre.ToUpper());
            writer.WriteLine(tPrecio.Text);
            writer.WriteLine(tCodigoProducto.Text);
            writer.WriteLine(tCantidadProducto.Text);
            writer.Close();
            tNombreProducto.Text = "";
            tPrecio.Text = "";
            tCodigoProducto.Text = "";
            tCantidadProducto.Text = "";
            tNombreProducto.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tNombreProducto.Text != "" || tCodigoProducto.Text != "")
            {
                producto.Clear();
                string archivo = "inventario.txt";
                FileStream stream = new FileStream(archivo, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(stream);
                while (reader.Peek() > -1)
                {
                    Productos pt = new Productos();
                    pt.NombreProducto = reader.ReadLine();
                    pt.PrecioProducto = Convert.ToDecimal(reader.ReadLine());
                    pt.CodigoProducto = reader.ReadLine();
                    pt.CantidadProducto = Convert.ToInt16(reader.ReadLine());
                    producto.Add(pt);
                }
                reader.Close();
                int val = 0;
                for (int x = 0; x < producto.Count; x++)
                {
                    if (producto[x].NombreProducto == tNombreProducto.Text.ToUpper() || producto[x].CodigoProducto == tCodigoProducto.Text)
                    {
                        val++;
                        MessageBox.Show("Nombre del produto: " + producto[x].NombreProducto + "\n" + "Precio: " + producto[x].PrecioProducto
                                        + "\n" + "Código: " + producto[x].CodigoProducto + "\n" + "Cantidad: " + producto[x].CantidadProducto);
                    }
                }
                if (val == 0)
                    MessageBox.Show("Producto inexistente!");
            }
            else
                MessageBox.Show("Llene los espacios necesarios para hacer la busqueda");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (tNombreProducto.Text != "" || tCodigoProducto.Text != "")
            {
                producto.Clear();
                string archivo = "inventario.txt";
                FileStream stream = new FileStream(archivo, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(stream);
                while (reader.Peek() > -1)
                {
                    Productos pt = new Productos();
                    pt.NombreProducto = reader.ReadLine();
                    pt.PrecioProducto = Convert.ToDecimal(reader.ReadLine());
                    pt.CodigoProducto = reader.ReadLine();
                    pt.CantidadProducto = Convert.ToInt16(reader.ReadLine());
                    producto.Add(pt);
                }
                reader.Close();
                int v = 0;
                for (int i = 0; i < producto.Count; i++)
                {
                    if (producto[i].NombreProducto == tNombreProducto.Text.ToUpper() || producto[i].CodigoProducto == tCodigoProducto.Text)
                    {
                        v++;
                        if(tPrecio.Text != "")
                            producto[i].PrecioProducto = Convert.ToDecimal(tPrecio.Text);
                        if(tCantidadProducto.Text != "")
                            producto[i].CantidadProducto = Convert.ToInt16(tCantidadProducto.Text);
                    }
                }
                if (v == 0)
                    MessageBox.Show("Producto inexistente");
                if (v > 0)
                {
                    string archivo2 = "inventario.txt";
                    FileStream stream2 = new FileStream(archivo2, FileMode.Open, FileAccess.Write);
                    StreamWriter writer = new StreamWriter(stream2);
                    for (int x = 0; x < producto.Count; x++)
                    {
                        writer.WriteLine(producto[x].NombreProducto);
                        writer.WriteLine(Convert.ToString(producto[x].PrecioProducto));
                        writer.WriteLine((producto[x].CodigoProducto));
                        writer.WriteLine(Convert.ToString(producto[x].CantidadProducto));
                    }
                    writer.Close();
                    tNombreProducto.Text = "";
                    tPrecio.Text = "";
                    tCodigoProducto.Text = "";
                    tCantidadProducto.Text = "";
                    tNombreProducto.Focus();
                }
            }
            else
                MessageBox.Show("Llene los espacios necesarios");
        }
    }
}
