﻿using System;
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
    }
}
