using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SitioWeb.Models;
using System.Data.SqlClient;
using System.Data;

namespace SitioWeb.Datos
{
    public class UsuarioDatos
    {
        public UsuariosModel EncontrarUsuario(string Usuario, string Clave)
        {
            UsuariosModel objeto = new UsuariosModel();

            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))

            {
                string query = "select Nombre, Usuario, Clave from Usuarios where Usuario = @pusuario and Clave = @pclave";

                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@pusuario", Usuario); //Enviar parámetro
                cmd.Parameters.AddWithValue("@pclave", Clave); //Enviar parámetro
                cmd.CommandType = CommandType.Text;

                conexion.Open();

                using (SqlDataReader dr = cmd.ExecuteReader()) //La validación de campos vacíos no está funcionando, existe código para esta validación 
                {
                    while (dr.Read())//ciclo para leer cada registro de la tabla
                    {
                        objeto = new UsuariosModel()
                        {
                            Nombre = (dr["Nombre"]).ToString(),
                            Usuario = (dr["Usuario"]).ToString(),
                            Clave = (dr["Clave"]).ToString(),
                        };
                       
                    }

                }
            }
                 return objeto;
        }


    }
}
