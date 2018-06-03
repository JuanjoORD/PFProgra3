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
            MessageBox.Show("Registrado...!");
        }
        decimal totalfac = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            produc.Clear();
            string archi = "inventario.txt";
            FileStream stream2 = new FileStream(archi, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream2);
            while (reader.Peek() > -1)
            {
                Productos pt = new Productos();
                pt.NombreProducto = reader.ReadLine();
                pt.PrecioProducto = Convert.ToDecimal(reader.ReadLine());
                pt.CodigoProducto = reader.ReadLine();
                pt.CantidadProducto = Convert.ToInt16(reader.ReadLine());
                produc.Add(pt);
            }
            reader.Close();
            int contador = 0, existe=0;
            decimal precio = 0;
            for (int i = 0; i < produc.Count; i++)
            {
                if (produc[i].NombreProducto == texProducto.Text.ToUpper())
                {
                    existe++;
                    if (produc[i].CantidadProducto > Convert.ToInt16(texProducCantidad.Text))
                    {
                        produc[i].CantidadProducto = produc[i].CantidadProducto - Convert.ToInt16(texProducCantidad.Text);
                        contador++;
                        precio = produc[i].PrecioProducto;
                    }
                }
            }
            if (existe > 0)
            {
                if (contador == 1)
                {
                    FileStream stream3 = new FileStream(archi, FileMode.Open, FileAccess.Write);
                    StreamWriter writer3 = new StreamWriter(stream3);
                    for (int x = 0; x < produc.Count; x++)
                    {
                        writer3.WriteLine(produc[x].NombreProducto);
                        writer3.WriteLine(Convert.ToString(produc[x].PrecioProducto));
                        writer3.WriteLine(produc[x].CodigoProducto);
                        writer3.WriteLine(Convert.ToString(produc[x].CantidadProducto));
                    }
                    writer3.Close();

                    decimal subto = precio * Convert.ToDecimal(texProducCantidad.Text);
                    //guardo los datos de la factura con el codigo de compra
                    string archivo = texVentaCodigo.Text + ".txt";
                    FileStream stream = new FileStream(archivo, FileMode.Append, FileAccess.Write);
                    StreamWriter writer = new StreamWriter(stream);
                    writer.WriteLine(texProducCantidad.Text);
                    writer.WriteLine(texProducto.Text);
                    writer.WriteLine(Convert.ToString(precio));
                    writer.WriteLine(Convert.ToString(subto));
                    writer.Close();
                    dataGridView1.Rows.Add(texProducCantidad.Text, texProducto.Text, precio, subto);

                    string archivo4 = "productomasvendido.txt";
                    FileStream stream4 = new FileStream(archivo4, FileMode.Append, FileAccess.Write);
                    StreamWriter writer4 = new StreamWriter(stream4);
                    writer4.WriteLine(texProducto.Text.ToUpper());
                    writer4.WriteLine(texProducCantidad.Text);
                    writer4.Close();
                    totalfac = totalfac + subto;
                    ltotal.Text = Convert.ToString(totalfac);
                    texProducto.Text = "";
                    texProducCantidad.Text = "";
                }
                else
                    MessageBox.Show("Cantidad insuficiente");
            }
            else
                MessageBox.Show("Producto inexistente");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            decimal total = Convert.ToDecimal(ltotal.Text);
            decimal efectivo = Convert.ToDecimal(texEfectivo.Text);
            decimal vuelto = efectivo - total;
            texVuelto.Text = Convert.ToString(vuelto);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string archivo1 = "ventaspormes.txt";
            FileStream stream = new FileStream(archivo1, FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            writer.WriteLine(texVentaCodigo.Text);
            writer.WriteLine(ltotal.Text);
            writer.WriteLine(lNombreVen.Text);
            writer.Close();

            string archivo2 = texVentaCodigo+"1"+".txt";
            FileStream stream2 = new FileStream(archivo2, FileMode.Append, FileAccess.Write);
            StreamWriter writer2 = new StreamWriter(stream2);
            writer2.WriteLine(tNit.Text);
            writer2.WriteLine(tNombreCliente.Text);
            writer2.WriteLine(tDirCliente.Text);
            writer2.WriteLine(lNombreVen.Text);
            writer2.WriteLine(texVentaCodigo.Text);
            writer2.WriteLine(ltotal.Text);
            writer2.WriteLine(texEfectivo.Text);
            writer2.WriteLine(texVuelto.Text);
            writer2.Close();

            dataGridView1.Rows.Clear();
            totalfac = 0;
            tNit.Text = "";
            tNombreCliente.Text = "";
            tDirCliente.Text = "";
            texProducCantidad.Text = "";
            texProducto.Text = "";
            texVentaCodigo.Text = "";
            texEfectivo.Text = "";
            texVuelto.Text = "";
            ltotal.Text = "";

        }
    }
}
