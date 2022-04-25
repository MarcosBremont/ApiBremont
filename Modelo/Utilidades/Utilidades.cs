
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Reflection;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
namespace Modelo
{
    public class Utilidades
    {
        protected const string MsgG = "¡Registro grabado con éxito!";
        protected const string MsgM = "¡Registro modificado con éxito!";
        protected const string MsgE = "¡Registro eliminado con éxito!";
        protected const string MsgEr = "No se pudo realizar la operación solicitada";

        protected void MsgGrabar()
        {
            //MessageBox.Show(MsgG, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        protected void MsgModificar()
        {
            //MessageBox.Show(MsgM, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        protected void MsgEliminar()
        {
            //MessageBox.Show(MsgE, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        protected void MsgError()
        {
            //MessageBox.Show(MsgEr, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        protected double StrToDbl(string valor)
        {
            double temp;
            double.TryParse(valor, out temp);
            return temp;
        }

        protected int StrToInt(string valor)
        {
            int temp;
            int.TryParse(valor, out temp);
            return temp;
        }

        protected DateTime StrToDateTime(string valor)
        {
            DateTime temp;
            DateTime.TryParse(valor, out temp);
            return temp;
        }

        public List<T> LlenarLista<T>(MySqlCommand cmd)
        {
            var listado = new List<T>();
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable table = new DataTable();
            da.Fill(table);
            if (table.Rows.Count > 0)
            {
                var json = JsonConvert.SerializeObject(table);
                listado = JsonConvert.DeserializeObject<List<T>>(json, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
            }
            return listado;
        }

        public T LlenarObjeto<T>(MySqlCommand cmd)
        {
            var obj = Activator.CreateInstance<T>();
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable table = new DataTable();
            da.Fill(table);
            if (table.Rows.Count > 0)
            {
                var json = JsonConvert.SerializeObject(table).ToString().Replace('[', ' ').Replace(']', ' ');
                obj = JsonConvert.DeserializeObject<T>(json, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
            }
            return obj;
        }

    }
}
