using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
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
                    MySqlCommand cmd = new MySqlCommand($"IProducto_menu_FFA(?,?,?,?,?)", GetCon());
                    cmd.Parameters.Add("prm_nombre", MySqlDbType.VarChar).Value = nombre;
                    cmd.Parameters.Add("prm_precio", MySqlDbType.Int32).Value = precio;
                    cmd.Parameters.Add("prm_disponible", MySqlDbType.VarChar).Value = disponible;
                    cmd.Parameters.Add("prm_foto", MySqlDbType.VarChar).Value = foto;
                    cmd.Parameters.Add("prm_descripcion", MySqlDbType.VarChar).Value = descripcion;
                    Conectar();
                    cmd.ExecuteNonQuery();
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

    }
}
