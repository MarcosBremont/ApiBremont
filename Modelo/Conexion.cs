using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace Modelo
{
    public class Conexion : Utilidades
    {
        protected MySqlConnection Conn { get; }

        public Conexion()
        {
            this.Conn = new MySqlConnection("server=mysql.tecnolora.com;user=apibremont;password=apibremont;database=api_bremont;port=7100");
        }

        protected void Conectar()
        {
            if (Conn.State == System.Data.ConnectionState.Closed)
                this.Conn.Open();
        }

        protected void Desconectar()
        {
            if (Conn.State == System.Data.ConnectionState.Open)
                this.Conn.Close();
        }

        public void TestConnection()
        {
            this.Conn.Open();
            this.Conn.Close();
        }
    }
}