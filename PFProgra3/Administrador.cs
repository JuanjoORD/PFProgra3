using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PFProgra3
{
    public partial class Administrador : Form
    {
        public Administrador()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Ingreso ingre = new Ingreso();
            ingre.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Inventario inve = new Inventario();
            inve.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegistroVentas rven = new RegistroVentas();
            rven.Show();
            this.Hide();
        }
    }
}
