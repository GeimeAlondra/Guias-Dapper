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
                String selectForId = "";
                selectForId = selectForId + "SELECT [CustomerID] " + "\n";
                selectForId = selectForId + "      ,[CompanyName] " + "\n";
                selectForId = selectForId + "      ,[ContactName] " + "\n";
                selectForId = selectForId + "      ,[ContactTitle] " + "\n";
                selectForId = selectForId + "      ,[Address] " + "\n";
                selectForId = selectForId + "      ,[City] " + "\n";
                selectForId = selectForId + "      ,[Region] " + "\n";
                selectForId = selectForId + "      ,[PostalCode] " + "\n";
                selectForId = selectForId + "      ,[Country] " + "\n";
                selectForId = selectForId + "      ,[Phone] " + "\n";
                selectForId = selectForId + "      ,[Fax] " + "\n";
                selectForId = selectForId + "  FROM [dbo].[Customers] " + "\n";
                selectForId = selectForId + "  WHERE CustomerID = @CustomerID]";

                var cliente = conexion.QueryFirstOrDefault<Customers>(selectForId, new { CustomerID = id });
                return cliente;
            }
        }
    }
}
