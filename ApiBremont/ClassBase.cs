using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBremont
{
    public class ClassBase
    {
        public double StrToDbl(string valor)
        {
            double.TryParse(valor, out double temp);
            return temp;
        }
        public decimal StrToDec(string valor)
        {
            decimal.TryParse(valor, out decimal temp);
            return temp;
        }
        public int StrToInt(string valor)
        {
            int.TryParse(valor, out int temp);
            return temp;
        }
        public DateTime StrToDate(string valor)
        {
            DateTime.TryParse(valor, out DateTime temp);
            return temp;
        }
        public DateTime GetFechaHora()
        {
            TimeZoneInfo zona = TimeZoneInfo.FindSystemTimeZoneById("Venezuela Standard Time");
            DateTime horaRD = TimeZoneInfo.ConvertTime(DateTime.Now, zona);
            DateTime zonahorari;
            zonahorari = horaRD;
            return zonahorari;
        }
        public DateTime FechaHora()
        {
            return this.GetFechaHora();
        }
        public string GetHora()
        {
            TimeZoneInfo zona = TimeZoneInfo.FindSystemTimeZoneById("Venezuela Standard Time");
            DateTime horaRD = TimeZoneInfo.ConvertTime(DateTime.Now, zona);
            string zonahorari;
            zonahorari = horaRD.ToString("h:m:s");
            return zonahorari;
        }
        public string GetFecha()
        {
            TimeZoneInfo zona = TimeZoneInfo.FindSystemTimeZoneById("Venezuela Standard Time");
            DateTime horaRD = TimeZoneInfo.ConvertTime(DateTime.Now, zona);
            string zonahorari;
            zonahorari = horaRD.Date.ToString("dd/MM/yyyy");
            return zonahorari;

        }

        public DataTable Todos()
        {
            DataTable t = new DataTable();
            t.Columns.Add("id", typeof(int));
            t.Columns.Add("nombre", typeof(string));
            t.Columns.Add("abreviado", typeof(string));
            t.Rows.Add(1, "ENERO", "ENE");
            t.Rows.Add(2, "FEBRERO", "FEB");
            t.Rows.Add(3, "MARZO", "MAR");
            t.Rows.Add(4, "ABRIL", "ABR");
            t.Rows.Add(5, "MAYO", "MAY");
            t.Rows.Add(6, "JUNIO", "JUN");
            t.Rows.Add(7, "JULIO", "JUL");
            t.Rows.Add(8, "AGOSTO", "AGO");
            t.Rows.Add(9, "SEPTIEMBRE", "SEP");
            t.Rows.Add(10, "OCTUBRE", "OCT");
            t.Rows.Add(11, "NOVIEMBRE", "NOV");
            t.Rows.Add(12, "DICIEMBRE", "DIC");
            return t;
        }
        public string GetMesResumidoPorId(int id)
        {
            string mes = "";
            DataTable dt = Todos();

            DataRow[] row = dt.Select("id=" + id);
            mes = row[0][2].ToString();
            return mes;
        }
        public string GetMesPorId(int id)
        {
            string mes = "";
            DataTable dt = Todos();

            DataRow[] row = dt.Select("id=" + id);
            mes = row[0][1].ToString();
            return mes;
        }
        public string GetNombredelmes(int month)
        {
            DateTimeFormatInfo dtinfo = new CultureInfo("es-ES", false).DateTimeFormat;
            return dtinfo.GetMonthName(month);
        }
        public void WriteException(Exception exception)
        {
            try
            {
                DateTime fecha = DateTime.UtcNow.AddHours(-4);
                string archivo = DateTime.Now.ToString("dd-MM-yyyy");
                string rutaLog = $"C:/inetpub/wwwroot/ApiOficable/Log";

                if (!Directory.Exists(rutaLog))
                    Directory.CreateDirectory(rutaLog);
                if (!File.Exists($"{rutaLog}\\{archivo}"))
                    File.Create($"{rutaLog}\\{archivo}").Close();

                var file = File.AppendText($"{rutaLog}\\{archivo}");
                file.WriteLine($"{fecha} {exception.Message} {exception.StackTrace}");
                file.WriteLine("===========================================================================");
                file.Close();
            }
            catch (Exception)
            {
            }
        }

        public string ObtenerTelefonos(string telefonos, int cantidad)
        {
            string[] lista;

            lista = telefonos.Split(',');

            if (lista.Length > 0)
            {
                if (cantidad > lista.Length)
                {
                    cantidad = lista.Length;
                }

                return string.Join(", ", lista, 0, cantidad);
            }

            return "";
        }
    }
}
