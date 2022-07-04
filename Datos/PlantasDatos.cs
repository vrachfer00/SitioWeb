using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SitioWeb.Models;
using System.Data.SqlClient;
using System.Data;

namespace SitioWeb.Datos
{
    public class PlantasDatos
    {
        //Guardar info de planta con imagen :)
        public bool GuardarConImagen(PlantasTotalModel objs)
        {
            try
            {
                var cn = new Conexion();
                int ID = 0;
                try
                {
                    string querySelect = "SELECT MAX(ID) as maxId FROM PlantasTotal";
                    using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                    {
                        conexion.Open();
                        SqlCommand cmd = new SqlCommand(querySelect, conexion);
                        using (var dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())//ciclo para leer cada registro de la tabla
                            {
                                ID = Convert.ToInt32(dr["maxId"])+1;
                            }
                        }
                    }

                }
                catch { 
                    
                }
                byte[] img = Convert.FromBase64String(objs.Imagen);
                string query = "INSERT INTO PlantasTotal(";
                string fields = "NombreCientifico," +
                    "GeneroHosp," +
                    "NombreComun," +
                    "Subfamilia," +
                    "TipoHojas," +
                    "MorfoHojas," +
                    "PosHojas," +
                    "PosFoliolos," +
                    "ColorFlor," +
                    "TipoFlor," +
                    "Petalos," +
                    "Espinas," +
                    "Amenazado," +
                    "ColorRaiz," +
                    "Nodula," +
                    "tipoImagen," +
                    "Imagen) ";
                string values = "values (";
                if (ID > 0){
                    fields = "ID," + fields;
                    values = values + ID + ",";
                }
                values = values + "N'" + objs.NombreCientifico + "'," +
                    "N'" + objs.GeneroHosp + "'," +
                    "N'" + objs.NombreComun + "'," +
                    "N'" + objs.Subfamilia + "'," +
                    "N'" + objs.TipoHojas + "'," +
                    "N'" + objs.MorfoHojas + "'," +
                    "N'" + objs.PosHojas + "'," +
                    "N'" + objs.PosFoliolos + "'," +
                    "N'" + objs.ColorFlor + "'," +
                    "N'" + objs.TipoFlor + "'," +
                    objs.Petalos + "," +
                    "N'" + objs.Espinas + "'," +
                    "N'" + objs.Amenazado + "'," +
                    "N'" + objs.ColorRaiz + "'," +
                    "N'" + objs.Nodula + "'," +
                    "N'" + objs.tipoImagen + "'," +
                    "@Imagen)";
                query = query + fields + values;
                

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand(query, conexion); //Llamar con el query creado arriba
                    cmd.Parameters.AddWithValue("@Imagen", img);
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                return false;
            }

        }

        //Procedimiento para guardar info de una nueva planta
        public bool Guardar(PlantasTotalModel ocontacto)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("GuardarPlanta", conexion); //Lamar procedimiento almacenado
                    cmd.Parameters.AddWithValue("NombreCientifico", ocontacto.NombreCientifico); //Enviar parámetros
                    cmd.Parameters.AddWithValue("GeneroHosp", ocontacto.GeneroHosp);
                    cmd.Parameters.AddWithValue("NombreComun", ocontacto.NombreComun);
                    cmd.Parameters.AddWithValue("Subfamilia", ocontacto.Subfamilia);
                    cmd.Parameters.AddWithValue("TipoHojas", ocontacto.TipoHojas);
                    cmd.Parameters.AddWithValue("MorfoHojas", ocontacto.MorfoHojas);
                    cmd.Parameters.AddWithValue("PosHojas", ocontacto.PosHojas);
                    cmd.Parameters.AddWithValue("PosFoliolos", ocontacto.PosFoliolos);
                    cmd.Parameters.AddWithValue("ColorFlor", ocontacto.ColorFlor);
                    cmd.Parameters.AddWithValue("TipoFlor", ocontacto.TipoFlor);
                    cmd.Parameters.AddWithValue("Petalos", ocontacto.Petalos);
                    cmd.Parameters.AddWithValue("Espinas", ocontacto.Espinas);
                    cmd.Parameters.AddWithValue("Amenazado", ocontacto.Amenazado);
                    cmd.Parameters.AddWithValue("ColorRaiz", ocontacto.ColorRaiz);
                    cmd.Parameters.AddWithValue("Nodula", ocontacto.Nodula);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;

            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }

            return rpta;
        }


        //Procedimiento que permite obtener la lista de todas las plantas registradas en la BD
        public List<PlantasTotalModel> Listar()
        {

            var oLista = new List<PlantasTotalModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("listarTotal", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())//ciclo para leer cada registro de la tabla
                    {
                        oLista.Add(new PlantasTotalModel()
                        {
                            ID = Convert.ToInt32(dr["ID"]),
                            NombreCientifico = (dr["NombreCientifico"]).ToString(),
                            GeneroHosp = (dr["GeneroHosp"]).ToString(),
                            NombreComun = (dr["NombreComun"]).ToString(),
                            Subfamilia = (dr["Subfamilia"]).ToString(),
                            TipoHojas = (dr["TipoHojas"]).ToString(),
                            MorfoHojas = (dr["MorfoHojas"]).ToString(),
                            PosHojas = (dr["PosHojas"]).ToString(),
                            PosFoliolos = (dr["PosFoliolos"]).ToString(),
                            ColorFlor = (dr["ColorFlor"]).ToString(),
                            TipoFlor = (dr["TipoFlor"]).ToString(),
                            Petalos = Convert.ToInt32(dr["Petalos"]),
                            Espinas = (dr["Espinas"]).ToString(),
                            Amenazado = (dr["Amenazado"]).ToString(),
                            ColorRaiz = (dr["ColorRaiz"]).ToString(),
                            Nodula = (dr["Nodula"]).ToString(),
                        });
                    }
                }
            }

            return oLista;
        }


        //Procedimiento que permite obtener info de una planta específica según el ID
        public PlantasTotalModel ObtenerPlanta(int ID)
        {
            var oContacto = new PlantasTotalModel();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("ObtenerPlanta", conexion);
                cmd.Parameters.AddWithValue("ID", ID); //Enviar parámetro
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())//ciclo para leer cada registro de la tabla
                    {
                        oContacto.ID = Convert.ToInt32(dr["ID"]);
                        oContacto.NombreCientifico = (dr["NombreCientifico"]).ToString();
                        oContacto.GeneroHosp = (dr["GeneroHosp"]).ToString();
                        oContacto.NombreComun = (dr["NombreComun"]).ToString();
                        oContacto.Subfamilia = (dr["Subfamilia"]).ToString();
                        oContacto.TipoHojas = (dr["TipoHojas"]).ToString();
                        oContacto.MorfoHojas = (dr["MorfoHojas"]).ToString();
                        oContacto.PosHojas = (dr["PosHojas"]).ToString();
                        oContacto.PosFoliolos = (dr["PosFoliolos"]).ToString();
                        oContacto.ColorFlor = (dr["ColorFlor"]).ToString();
                        oContacto.TipoFlor = (dr["TipoFlor"]).ToString();
                        oContacto.Petalos = Convert.ToInt32(dr["Petalos"]);
                        oContacto.Espinas = (dr["Espinas"]).ToString();
                        oContacto.Amenazado = (dr["Amenazado"]).ToString();
                        oContacto.ColorRaiz = (dr["ColorRaiz"]).ToString();
                        oContacto.Nodula = (dr["Nodula"]).ToString();
                    }
                }
            }

            return oContacto;
        }


        //Procedimiento para editar info de una planta
        public bool Editar(PlantasTotalModel ocontacto)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("EditarPlanta", conexion);
                    cmd.Parameters.AddWithValue("ID", ocontacto.ID);
                    cmd.Parameters.AddWithValue("NombreCientifico", ocontacto.NombreCientifico); //Enviar parámetro
                    cmd.Parameters.AddWithValue("GeneroHosp", ocontacto.GeneroHosp);
                    cmd.Parameters.AddWithValue("NombreComun", ocontacto.NombreComun);
                    cmd.Parameters.AddWithValue("Subfamilia", ocontacto.Subfamilia);
                    cmd.Parameters.AddWithValue("TipoHojas", ocontacto.TipoHojas);
                    cmd.Parameters.AddWithValue("MorfoHojas", ocontacto.MorfoHojas);
                    cmd.Parameters.AddWithValue("PosHojas", ocontacto.PosHojas);
                    cmd.Parameters.AddWithValue("PosFoliolos", ocontacto.PosFoliolos);
                    cmd.Parameters.AddWithValue("ColorFlor", ocontacto.ColorFlor);
                    cmd.Parameters.AddWithValue("TipoFlor", ocontacto.TipoFlor);
                    cmd.Parameters.AddWithValue("Petalos", ocontacto.Petalos);
                    cmd.Parameters.AddWithValue("Espinas", ocontacto.Espinas);
                    cmd.Parameters.AddWithValue("Amenazado", ocontacto.Amenazado);
                    cmd.Parameters.AddWithValue("ColorRaiz", ocontacto.ColorRaiz);
                    cmd.Parameters.AddWithValue("Nodula", ocontacto.Nodula);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;

            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }

            return rpta;
        }


        //Procedimiento para eliminar info de una planta
        public bool Eliminar(int ID)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("Eliminar", conexion);
                    cmd.Parameters.AddWithValue("ID", ID); //Enviar parámetro
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;

            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }

            return rpta;
        }


        //Procedimiento que permite obtener la lista de plantas de una subfamilia específica según el Nombre
        public PlantasPorSubfamilia ListarPlantasPorSubfamilia(string Subfamilia)
        {
            PlantasPorSubfamilia resultado = new PlantasPorSubfamilia();
            resultado.Subfamilia = Subfamilia;
            resultado.Plantas = new List<InfoPlantaSubfamilia>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("ListarPlantasPorSubfamilia", conexion);
                cmd.Parameters.AddWithValue("subfamilia", Subfamilia); //Enviar parámetro
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())//ciclo para leer cada registro de la tabla
                    {
                        resultado.Plantas.Add(new InfoPlantaSubfamilia()
                        {
                            ID = Convert.ToInt32(dr["ID"]),
                            NombreCientifico = dr["NombreCientifico"].ToString(),
                            NombreComun = dr["NombreComun"].ToString()
                        });
                    }
                }
            }

            return resultado;
        }

        //Procedimiento que permite obtener la lista de plantas de una subfamilia específica según el Nombre
        public List<string> ListarSubfamilias()
        {
            var subfamilias = new List<string>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("ListarSubfamilias", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())//ciclo para leer cada registro de la tabla
                    {
                        subfamilias.Add(dr["Subfamilia"].ToString());
                    }
                }
            }

            return subfamilias;
        }


    }
}
