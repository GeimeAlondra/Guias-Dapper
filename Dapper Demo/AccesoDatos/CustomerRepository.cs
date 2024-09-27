using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class CustomerRepository
    {
        public List<Customers> ObtenerTodo()
        {
            using (var conexion = DataBase.GetSqlConnection())
            {
                String selectAll = "";
                selectAll = selectAll + "SELECT [CustomerID] " + "\n";
                selectAll = selectAll + "      ,[CompanyName] " + "\n";
                selectAll = selectAll + "      ,[ContactName] " + "\n";
                selectAll = selectAll + "      ,[ContactTitle] " + "\n";
                selectAll = selectAll + "      ,[Address] " + "\n";
                selectAll = selectAll + "      ,[City] " + "\n";
                selectAll = selectAll + "      ,[Region] " + "\n";
                selectAll = selectAll + "      ,[PostalCode] " + "\n";
                selectAll = selectAll + "      ,[Country] " + "\n";
                selectAll = selectAll + "      ,[Phone] " + "\n";
                selectAll = selectAll + "      ,[Fax] " + "\n";
                selectAll = selectAll + "  FROM [dbo].[Customers]";

                var cliente = conexion.Query<Customers>(selectAll).ToList();
                return cliente;
            }
        }

        public Customers ObtenerPorId(string id)
        {
            using (var conexion = DataBase.GetSqlConnection())
            {
                String selectForID = "";
                selectForID = selectForID + "SELECT [CustomerID] " + "\n";
                selectForID = selectForID + "      ,[CompanyName] " + "\n";
                selectForID = selectForID + "      ,[ContactName] " + "\n";
                selectForID = selectForID + "      ,[ContactTitle] " + "\n";
                selectForID = selectForID + "      ,[Address] " + "\n";
                selectForID = selectForID + "      ,[City] " + "\n";
                selectForID = selectForID + "      ,[Region] " + "\n";
                selectForID = selectForID + "      ,[PostalCode] " + "\n";
                selectForID = selectForID + "      ,[Country] " + "\n";
                selectForID = selectForID + "      ,[Phone] " + "\n";
                selectForID = selectForID + "      ,[Fax] " + "\n";
                selectForID = selectForID + "  FROM [dbo].[Customers] " + "\n";
                selectForID = selectForID + "  WHERE CustomerID = @CustomerID";

                var Cliente = conexion.QueryFirstOrDefault<Customers>(selectForID, new { CustomerID = id });
                return Cliente;
            }
        }

        public int InsertarCliente(Customers customer)
        {
            using (var conexion = DataBase.GetSqlConnection())
            {
                String Insertar = "";
                Insertar = Insertar + "INSERT INTO [dbo].[Customers] " + "\n";
                Insertar = Insertar + "           ([CustomerID] " + "\n";
                Insertar = Insertar + "           ,[CompanyName] " + "\n";
                Insertar = Insertar + "           ,[ContactName] " + "\n";
                Insertar = Insertar + "           ,[ContactTitle] " + "\n";
                Insertar = Insertar + "           ,[Address]) " + "\n";
                Insertar = Insertar + "     VALUES " + "\n";
                Insertar = Insertar + "           (@customerID " + "\n";
                Insertar = Insertar + "           ,@companyName " + "\n";
                Insertar = Insertar + "           ,@contactName " + "\n";
                Insertar = Insertar + "           ,@contactTitle " + "\n";
                Insertar = Insertar + "           ,@address)";
               
                var insertadas = conexion.Execute(Insertar, new
                {
                    customerID = customer.CustomerID,
                    companyName = customer.CompanyName,
                    contactName = customer.ContactName,
                    contactTitle = customer.ContactTitle,
                    address = customer.Address,
                });
                return insertadas;
            }
        }

        public int ActualizarCliente(Customers customers)
        {
            using (var conexion = DataBase.GetSqlConnection())
            {
                String UpdateCustomer = "";
                UpdateCustomer = UpdateCustomer + "UPDATE [dbo].[Customers] " + "\n";
                UpdateCustomer = UpdateCustomer + "   SET [CustomerID] = @CustomerID " + "\n";
                UpdateCustomer = UpdateCustomer + "      ,[CompanyName] = @CompanyName " + "\n";
                UpdateCustomer = UpdateCustomer + "      ,[ContactName] = @ContactName " + "\n";
                UpdateCustomer = UpdateCustomer + "      ,[ContactTitle] = @ContactTitle " + "\n";
                UpdateCustomer = UpdateCustomer + "      ,[Address] = @Address " + "\n";
                UpdateCustomer = UpdateCustomer + " WHERE CustomerID = @CustomerID";
                var actualizadas =
                    conexion.Execute(UpdateCustomer, new
                    {
                        customerID = customers.CustomerID,
                        companyName = customers.CompanyName,
                        contactName = customers.ContactName,
                        contactTitle = customers.ContactTitle,
                        address = customers.Address
                    });
                return actualizadas;
            }
        }

        public int EliminarCliente(string Id)
        {
            using (var conexion = DataBase.GetSqlConnection())
            {
                String Delete = "";
                Delete = Delete + "DELETE FROM [dbo].[Customers] " + "\n";
                Delete = Delete + "      WHERE CustomerID = @CustomerID";

                var eliminadas = conexion.Execute(Delete, new
                {
                    CustomerID = Id
                });
                return eliminadas;
            }
        }
    }
}
