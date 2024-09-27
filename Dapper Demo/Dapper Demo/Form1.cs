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

            if (cliente != null)
            {
                RellenarForm(cliente);
            }
        }

        private void RellenarForm(Customers customers)
        {
            txtCustomerId.Text = customers.CustomerID;
            txtCompanyName.Text = customers.CompanyName;
            txtContactName.Text = customers.ContactName;
            txtContactTitle.Text = customers.ContactTitle;
            txtAddress.Text = customers.Address;
        }

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

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            var clienteActualizado = CrearCliente();
            var actualizados = customerR.ActualizarCliente(clienteActualizado);
            var cliente = customerR.ObtenerPorId(clienteActualizado.CustomerID);
            dgvObtenerTodo.DataSource = new List<Customers> { cliente };
            MessageBox.Show($"Filas actualizadas {actualizados} - {clienteActualizado.CustomerID}");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var eliminadas = customerR.EliminarCliente(txtCustomerId.Text);
            MessageBox.Show($"Se ha eliminado {eliminadas} filas de manera correcta");
        }
    }
}
