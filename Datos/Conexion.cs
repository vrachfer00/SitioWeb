using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SitioWeb.Datos
{
    public class Conexion
    {
        private string cadenaSQL = string.Empty;

        //Método constructor
        public Conexion() {  
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            cadenaSQL = builder.GetSection("ConnectionStrings:CadenaSQL").Value;
        }

        //Este método devuelve la cadena SQL
        public string getCadenaSQL() {
            return cadenaSQL;
        }

    }
    
}
