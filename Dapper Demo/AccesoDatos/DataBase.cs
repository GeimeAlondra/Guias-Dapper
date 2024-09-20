﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class DataBase
    {
        public static string Connection 
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["NWConnection"].ConnectionString;
            }
        }

        public static SqlConnection GetSqlConnection()
        {
            SqlConnection conexion = new SqlConnection(Connection);
            conexion.Open();
            return conexion;
        }
    }
}
