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
    public partial class DetallesFac : Form
    {
        public DetallesFac()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegistroVentas r = new RegistroVentas();
            r.Show();
            this.Hide();
        }
        
    }
}
