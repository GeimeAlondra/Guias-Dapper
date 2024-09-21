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

            //if (cliente != null)
            //{
            //    RellenarForm(cliente);
            //}
        }

        //private void RellenarForm(Customers cliente)
        //{
        //    throw new NotImplementedException();
        //}

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            var nuevoCliente = CrearCliente();
            var insertado = customerR.InsertarCliente(nuevoCliente);
            MessageBox.Show($"{insertado} registros insertados");
        }

        private Customers CrearCliente()
        {
            var nuevo = new Customers
            {
                CustomerID = txtCustomerId.Text,
                CompanyName = txtCompanyName.Text,
                ContactName = txtContactName.Text,
                ContactTitle = txtContactTitle.Text,
                Address = txtAddress.Text,
            };
            return nuevo;
        }
    }
}
