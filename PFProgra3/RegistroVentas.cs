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
    public partial class RegistroVentas : Form
    {
        public RegistroVentas()
        {
            InitializeComponent();
        }
        List<Usuarios> use = new List<Usuarios>();
        List<VentasPor> venpo = new List<VentasPor>();
        List<VentasPor> vendedor = new List<VentasPor>();
        List<DatosFac> datos1 = new List<DatosFac>();
        List<DatosFac> datos2 = new List<DatosFac>();
        List<Productos> pro1 = new List<Productos>();
        List<Productos> pro2 = new List<Productos>();
        List<DatosFac> venmes = new List<DatosFac>();
        List<int> venmes2 = new List<int>();
        List<Factura> factu = new List<Factura>();

        private void button6_Click(object sender, EventArgs e)
        {
            Administrador admin = new Administrador();
            admin.Show();
            this.Hide();
        }

        private void RegistroVentas_Load(object sender, EventArgs e)
        {
            use.Clear();
            string archivo = "usuarios.txt";
            FileStream stream = new FileStream(archivo, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                Usuarios ut = new Usuarios();
                ut.Nombre = reader.ReadLine();
                ut.Apellido = reader.ReadLine();
                ut.Nickname = reader.ReadLine();
                ut.Contraseña = reader.ReadLine();
                ut.Tipousuario = reader.ReadLine();
                use.Add(ut);
            }
            reader.Close();
            for (int x = 0; x < use.Count; x++)
            {
                if (use[x].Tipousuario == "Vendedor")
                {
                    string nombre = use[x].Nombre + " " + use[x].Apellido;
                    comboBox2.Items.Add(nombre);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //dataGridView1.Rows.Clear();
            venpo.Clear();
            vendedor.Clear();
            string archivo = "ventaspormes.txt";
            FileStream stream = new FileStream(archivo, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                VentasPor vpt = new VentasPor();
                vpt.Codigoventa = reader.ReadLine();
                vpt.Montoventa = reader.ReadLine();
                vpt.Vendedor = reader.ReadLine();
                vpt.Dia = reader.ReadLine();
                vpt.Mes = reader.ReadLine();
                vpt.Anio = reader.ReadLine();
                vpt.Hora = reader.ReadLine();
                venpo.Add(vpt);
            }
            reader.Close();

            for (int i = 0; i < venpo.Count; i++)
                if (venpo[i].Mes == comboBox1.Text)
                {
                    VentasPor vende = new VentasPor();
                    vende.Codigoventa = venpo[i].Codigoventa;
                    vende.Montoventa = venpo[i].Montoventa;
                    vende.Vendedor = venpo[i].Vendedor;
                    vende.Dia = venpo[i].Dia;
                    vende.Mes = venpo[i].Mes;
                    vende.Anio = venpo[i].Anio;
                    vende.Hora = venpo[i].Hora;
                    vendedor.Add(vende);
                }

            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            dataGridView1.DataSource = vendedor;
            dataGridView1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //dataGridView1.Rows.Clear();
            venpo.Clear();
            vendedor.Clear();
            string archivo = "ventaspormes.txt";
            FileStream stream = new FileStream(archivo, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                VentasPor vpt = new VentasPor();
                vpt.Codigoventa = reader.ReadLine();
                vpt.Montoventa = reader.ReadLine();
                vpt.Vendedor = reader.ReadLine();
                vpt.Dia = reader.ReadLine();
                vpt.Mes = reader.ReadLine();
                vpt.Anio = reader.ReadLine();
                vpt.Hora = reader.ReadLine();
                venpo.Add(vpt);
            }
            reader.Close();
            for (int i = 0; i < venpo.Count; i++)
                if (venpo[i].Vendedor == comboBox2.Text & venpo[i].Mes == comboBox1.Text)
                {
                    VentasPor vende = new VentasPor();
                    vende.Codigoventa = venpo[i].Codigoventa;
                    vende.Montoventa = venpo[i].Montoventa;
                    vende.Vendedor = venpo[i].Vendedor;
                    vende.Dia = venpo[i].Dia;
                    vende.Mes = venpo[i].Mes;
                    vende.Anio = venpo[i].Anio;
                    vende.Hora = venpo[i].Hora;
                    vendedor.Add(vende);
                }

            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            dataGridView1.DataSource = vendedor;
            dataGridView1.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            datos1.Clear();
            datos2.Clear();
            string archivo = "productomasvendido.txt";
            FileStream stream = new FileStream(archivo, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                DatosFac dt = new DatosFac();
                dt.Nombreprod = reader.ReadLine();
                dt.Cantidadprod = reader.ReadLine();
                datos1.Add(dt);
            }
            reader.Close();
            for (int i = 0; i < datos1.Count; i++)
                if (Convert.ToInt16(datos1[i].Cantidadprod) > 10)
                {
                    DatosFac dt = new DatosFac();
                    dt.Nombreprod = datos1[i].Nombreprod;
                    dt.Cantidadprod = datos1[i].Cantidadprod;
                    datos2.Add(dt);
                }
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            dataGridView1.DataSource = datos2;
            dataGridView1.Refresh();
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
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
                pro1.Add(pt);
            }
            reader.Close();
            for(int x=0; x<pro1.Count; x++)
                if (Convert.ToInt16(pro1[x].CantidadProducto) < 60)
                {
                    Productos pt = new Productos();
                    pt.NombreProducto = pro1[x].NombreProducto;
                    pt.PrecioProducto = pro1[x].PrecioProducto;
                    pt.CodigoProducto = pro1[x].CodigoProducto;
                    pt.CantidadProducto = pro1[x].CantidadProducto;
                    pro2.Add(pt);
                }
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            dataGridView1.DataSource = pro2;
            dataGridView1.Refresh();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            venpo.Clear();
            venmes.Clear();
            venmes2.Clear();
            string archivo = "ventaspormes.txt";
            FileStream stream = new FileStream(archivo, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                VentasPor vpt = new VentasPor();
                vpt.Codigoventa = reader.ReadLine();
                vpt.Montoventa = reader.ReadLine();
                vpt.Vendedor = reader.ReadLine();
                vpt.Dia = reader.ReadLine();
                vpt.Mes = reader.ReadLine();
                vpt.Anio = reader.ReadLine();
                vpt.Hora = reader.ReadLine();
                venpo.Add(vpt);
            }
            reader.Close();
            for (int i = 0; i < venpo.Count; i++)
            {
                int cont = 0;
                for (int j = 0; j < venmes.Count; j++)
                {
                    if (venpo[i].Vendedor == venmes[j].Nombreprod)
                    {
                        venmes[j].Cantidadprod = Convert.ToString(Convert.ToInt16(venmes[j].Cantidadprod) + 1);
                        cont++;
                    }
                }
                if (cont == 0)
                {
                    DatosFac dt = new DatosFac();
                    dt.Nombreprod = venpo[i].Vendedor;
                    dt.Cantidadprod = "1";
                    venmes.Add(dt);
                }
            }
            for (int k = 0; k < venmes.Count; k++)
                venmes2.Add(Convert.ToInt16(venmes[k].Cantidadprod));
            int n = venmes2.Max();
            for (int x = 0; x < venmes.Count; x++)
                if (venmes[x].Cantidadprod == Convert.ToString(n))
                    MessageBox.Show("Vendedor: "+venmes[x].Nombreprod+"\n"+"Cantidad de ventas: "+venmes[x].Cantidadprod);

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Primero ingrese el codigo de la venta que desee ver");
            }
            else
            {
                string n = textBox1.Text;
                string nn = ".txt";
                string archivo = n + nn;
                FileStream stream = new FileStream(archivo, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(stream);
                while (reader.Peek() > -1)
                {
                    Factura ft = new Factura();
                    ft.Cantidad = reader.ReadLine();
                    ft.Producto = reader.ReadLine();
                    ft.Precio = reader.ReadLine();
                    ft.Subtotal = reader.ReadLine();
                    factu.Add(ft);
                }
                reader.Close();

                DetallesFac otrofm = new DetallesFac();

                string n2 = textBox1.Text;
                string nn2 = "1.txt";
                string archivo2 = n2 + nn2;
                FileStream stream2 = new FileStream(archivo2, FileMode.Open, FileAccess.Read);
                StreamReader reader2 = new StreamReader(stream2);
                otrofm.lNit.Text = reader2.ReadLine();
                otrofm.lNombre.Text = reader2.ReadLine();
                otrofm.lDireccion.Text = reader2.ReadLine(); ;
                otrofm.lCajero.Text = reader2.ReadLine();
                otrofm.lCodigo.Text = reader2.ReadLine();
                otrofm.lTotal.Text = reader2.ReadLine();
                otrofm.lEfectivo.Text = reader2.ReadLine();
                otrofm.lVuelto.Text = reader2.ReadLine();
                string dia = reader2.ReadLine();
                string mes = reader2.ReadLine();
                string anio = reader2.ReadLine(); ;
                otrofm.lHora.Text = reader2.ReadLine();
                otrofm.lFecha.Text = dia + "-" + mes + "-" + anio;
                reader2.Close();

                otrofm.dataGridView1.DataSource = null;
                otrofm.dataGridView1.Refresh();
                otrofm.dataGridView1.DataSource = factu;
                otrofm.dataGridView1.Refresh();

                otrofm.Show();
                this.Hide();
            }
        }
    }
}
