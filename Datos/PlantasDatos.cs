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
                string query = "SET IDENTITY_INSERT PlantasTotal ON; INSERT INTO PlantasTotal(";
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
                    "Simbionte," +
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
                     "N'" + objs.Simbionte + "'," +
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


        //Guardar info de nodulo con imagen :)
        public bool GuardarNoduloConImagen(PlantasNodulan objs)
        {
            try
            {
                var cn = new Conexion();

                    using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                    conexion.Open();                                    
    
           
                byte[] img = Convert.FromBase64String(objs.FotoNodulo);
                string query = "INSERT INTO PlantasNodulan(";
                string fields = "IdNodulo," +
                    "Indiv," +
                    "NombreCientificoPlanta," +
                    "CantidadNodos," +
                    "FormaNodo," +
                    "TipoNodo," +
                    "TamanoNodo," +
                    "Fecha," +
                    "Proyecto," +
                    "Permiso," +
                    "FiloBacteria," +
                    "GeneroBacteria," +
                    "Rhizobio," +
                    "Gram," +
                    "Secuencia," +
                    "IDPlanta," +
                    "tipoFoto," +
                    "FotoNodulo) ";
                string values = "values (";
               
                values = values + "N'" + objs.IdNodulo + "'," +
                    objs.Indiv + "," +
                    "N'" + objs.NombreCientificoPlanta + "'," +
                    objs.CantidadNodos + "," +
                    "N'" + objs.FormaNodo + "'," +
                    "N'" + objs.TipoNodo + "'," +
                    objs.TamanoNodo + "," +
                    "N'" + objs.Fecha.ToString() + "'," +
                    "N'" + objs.Proyecto + "'," +
                    "N'" + objs.Permiso + "'," +
                    "N'" + objs.FiloBacteria + "'," +
                    "N'" + objs.GeneroBacteria+ "'," +
                    "N'" + objs.Rhizobio + "'," +
                    "N'" + objs.Gram + "'," +
                    "N'" + objs.Secuencia + "'," +
                    objs.IDPlanta+ "," +
                    "N'" + objs.TipoFoto + "'," +
                    "@FotoNodulo)";
                query = query + fields + values;


                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand(query, conexion); //Llamar con el query creado arriba
                    cmd.Parameters.AddWithValue("@FotoNodulo", img);
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


        //Procedimiento para guardar info de una nueva planta, ya no lo estoy usando
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
                            Simbionte = (dr["Simbionte"]).ToString(),
                            Nodula = (dr["Nodula"]).ToString(),
                           // tipoImagen = (dr["tipoImagen"]).ToString(),
                           // Imagen = Convert.ToBase64String((byte[])dr["Imagen"]) //no está funcionando
                         });

                    }
                }
            }

            return oLista;
        }


        //Procedimiento que permite obtener info de una planta específica según el ID, incluye la foto de la planta
        public PlantasTotalModel ObtenerPlantaConFoto(int ID)
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
                        oContacto.Simbionte = (dr["Simbionte"]).ToString();
                        oContacto.Nodula = (dr["Nodula"]).ToString();
                        oContacto.tipoImagen = (dr["tipoImagen"]).ToString();

                        if (!Convert.IsDBNull(dr["Imagen"])) //Si el campo Imagen no está vacío hace la conversión
                        {
                            oContacto.Imagen = Convert.ToBase64String((byte[])dr["Imagen"]);               
                        }
                        else
                        {
                            // do something else
                        }
                        
                    }
                }
            }

            return oContacto;
        }

        //Procedimiento que permite obtener info de una planta específica según el ID, no incluye la foto de la planta
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



        //Procedimiento que permite obtener info de una planta específica según el ID, incluye la foto de la planta
        public PlantasNodulan ObtenerNodoConFoto(string IdNodo)
        {
            var oContacto = new PlantasNodulan();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("ObtenerNodo", conexion);
                cmd.Parameters.AddWithValue("IdNodo", IdNodo); //Enviar parámetro
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())//ciclo para leer cada registro de la tabla
                    {
                        oContacto.IdNodulo = (dr["IdNodulo"]).ToString();
                        oContacto.Indiv = Convert.ToInt32(dr["Indiv"]);
                        oContacto.NombreCientificoPlanta = (dr["NombreCientificoPlanta"]).ToString();
                        oContacto.CantidadNodos = Convert.ToInt32(dr["CantidadNodos"]);
                        oContacto.FormaNodo = (dr["FormaNodo"]).ToString();
                        oContacto.TipoNodo = (dr["TipoNodo"]).ToString();
                        oContacto.TamanoNodo = Convert.ToInt32(dr["TamanoNodo"]);
                        oContacto.Fecha = (dr["Fecha"]).ToString();
                        oContacto.Proyecto = (dr["Proyecto"]).ToString();
                        oContacto.Permiso = (dr["Permiso"]).ToString();
                        oContacto.FiloBacteria = (dr["FiloBacteria"]).ToString();
                        oContacto.GeneroBacteria = (dr["GeneroBacteria"]).ToString();
                        oContacto.Rhizobio = (dr["Rhizobio"]).ToString();
                        oContacto.Gram = (dr["Gram"]).ToString();
                        oContacto.Secuencia = (dr["Secuencia"]).ToString();
                        oContacto.IDPlanta = Convert.ToInt32(dr["IDPlanta"]);
                        oContacto.TipoFoto = (dr["TipoFoto"]).ToString();

                        if (!Convert.IsDBNull(dr["FotoNodulo"])) //Si el campo Imagen no está vacío hace la conversión
                        {
                            oContacto.FotoNodulo = Convert.ToBase64String((byte[])dr["FotoNodulo"]);
                        }
                        else
                        {
                            // do something else
                        }

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


        //Procedimiento para editar info de una planta CON FOTO NO SIRVE y siempre retorna falso
        public bool EditarConFoto(PlantasTotalModel ocontacto)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("EditarPlantaFoto", conexion);
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
                    cmd.Parameters.AddWithValue("Simbionte", ocontacto.Simbionte);
                    cmd.Parameters.AddWithValue("Nodula", ocontacto.Nodula);

                    cmd.Parameters.AddWithValue("tipoImagen", ocontacto.tipoImagen);
                    byte[] img = Convert.FromBase64String(ocontacto.Imagen);
                    cmd.Parameters.AddWithValue("Imagen", img);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta=true;

            }
            catch (Exception e) //No devuelve ningún mensaje de error
            {
                string error = e.Message;
                rpta=false;
            }

            return rpta;

        }

        //Procedimiento para eliminar info de una planta
        public bool Eliminar(int ID) //Eliminar todos los registros de nódulos que tenga la planta y luego eliminar la planta para que funcione
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
                            NombreComun = dr["NombreComun"].ToString(),
                            tipoImagen = dr["tipoImagen"].ToString(),
                            Imagen = Convert.ToBase64String((byte[])dr["Imagen"]),
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

        //Procedimiento para listar subfamilias e incluir imagen de cada una
        public List<Subfamilias> ListaDeSubfamilias()
        {

            var resultado = new List<Subfamilias>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("ListaDeSubfamilias", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())//ciclo para leer cada registro de la tabla
                    {
                        resultado.Add(new Subfamilias()
                        {
                            Subfamilia = dr["Subfamilia"].ToString(),
                            Foto = Convert.ToBase64String((byte[])dr["Foto"]),
                            Tipo = dr["Tipo"].ToString(),
                        });
                    }
                }


            }

            return resultado;
        }


        //Procedimiento que permite obtener la lista de nódulo según el ID de la planta
        public List<PlantasNodulan> ListarNodosPorID(int ID)
        {

            var resultado = new List<PlantasNodulan>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("ListarNodosPorID", conexion);
                cmd.Parameters.AddWithValue("IDPlanta", ID); //Enviar parámetro
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())//ciclo para leer cada registro de la tabla
                    {
                        resultado.Add(new PlantasNodulan()
                        {
                            IdNodulo = dr["IdNodulo"].ToString(),
                            FiloBacteria = dr["FiloBacteria"].ToString(),
                            GeneroBacteria = dr["GeneroBacteria"].ToString(),
                        });
                    }
                }


            }

            return resultado;
        }


    }
}
