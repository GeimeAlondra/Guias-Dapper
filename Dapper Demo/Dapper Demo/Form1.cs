using AccesoDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dapper_Demo
{
    public partial class Form1 : Form
    {
        CustomerRepository customerR = new CustomerRepository();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnObtenerTodo_Click(object sender, EventArgs e)
        {
            var cliente = customerR.ObtenerTodo();
            dgvObtenerTodo.DataSource = cliente;
        }

        private void btnObtenerPorId_Click(object sender, EventArgs e)
        {
            var cliente = customerR.ObtenerPorId(txtObtenerId.Text);
            dgvObtenerTodo.DataSource = new List<Customers> { cliente };

            
        }
    }
}
