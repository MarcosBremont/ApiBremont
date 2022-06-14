using Modelo.Entidades;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBremont.Models
{
    public class Menu : Conexion
    {
        public List<Modelo.Entidades.EMenu> lista_menu()
        {
            List<Modelo.Entidades.EMenu> lista_menu = new List<Modelo.Entidades.EMenu>();

            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand("SlistaMenuFastFood", GetCon());
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                var result = JsonConvert.SerializeObject(dt, Formatting.Indented);
                lista_menu = JsonConvert.DeserializeObject<List<Modelo.Entidades.EMenu>>(result, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }

            return lista_menu;
        }


        public Result AgregarProductoAlMenu(string nombre, int precio, string disponible, string foto, string descripcion)
        {
            Result result = new Result();
            try
            {
                using (GetCon())
                {
                    MySqlCommand cmd = new MySqlCommand($"IProducto_menu_FFA", GetCon());
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("prm_nombre", nombre);
                    cmd.Parameters.AddWithValue("prm_precio", precio);
                    cmd.Parameters.AddWithValue("prm_disponible", disponible);
                    cmd.Parameters.AddWithValue("prm_foto", foto);
                    cmd.Parameters.AddWithValue("prm_descripcion", descripcion);
                    Conectar();
                    result.Id = int.Parse(cmd.ExecuteScalar().ToString());
                    result.Respuesta = "OK";
                }
            }
            catch (Exception ex)
            {
                result.Respuesta = "ERROR";
                result.Mensaje = ex.Message;
            }

            return result;

        }


        public EMenu GrabarUrlFotoPerfil(int idmenu_fast_food, string foto)
        {
            EMenu emenu = new EMenu();
            try
            {
                // Actualizar Foto
                var sql = @"update menu_fast_food set foto=@foto where idmenu_fast_food = @idmenu_fast_food";
                MySqlCommand cmd = new MySqlCommand(sql, GetCon());
                cmd.Parameters.Add("@idmenu_fast_food", MySqlDbType.Int32).Value = idmenu_fast_food;
                cmd.Parameters.Add("@foto", MySqlDbType.Text).Value = foto;
                Conectar();
                cmd.ExecuteNonQuery();
                Desconectar();

                try
                {
                    sql = @"SELECT concat('C:/inetpub/wwwroot/apibremont.tecnolora.com/wwwroot','/images/',m.foto) foto FROM menu_fast_food m
                                where m.idmenu_fast_food = @idmenu_fast_food";
                    cmd = new MySqlCommand(sql, GetCon());
                    cmd.Parameters.Add("@idmenu_fast_food", MySqlDbType.Int32).Value = idmenu_fast_food;
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        var result = JsonConvert.SerializeObject(dt, Formatting.Indented).Replace("[", "").Replace("]", "");
                        emenu = JsonConvert.DeserializeObject<EMenu>(result, new JsonSerializerSettings()
                        {
                            NullValueHandling = NullValueHandling.Ignore
                        });
                        emenu.encontrado = true;
                        emenu.result = "OK";
                    }
                    else
                    {
                        emenu.result = "ERROR";
                    }

                }
                catch (Exception ex)
                {
                    emenu.result = "ERROR";
                }

                return emenu;
            }
            catch (Exception ex)
            {
                WriteException(ex);
                emenu.result = "ERROR";
            }

            return emenu;
        }




    }
}
