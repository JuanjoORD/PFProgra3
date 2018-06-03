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
    }
}
