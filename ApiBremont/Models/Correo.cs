using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ApiBremont.Models
{
    public class Correo
    {
        #region Propiedades
        private string Servidor { get; set; } = "smtp.gmail.com";
        private string CorreoEnvia { get; set; } = "simplerentcarapp@gmail.com";
        private string ClaveEnvia { get; set; } = "simple2022@";
        private int Puerto { get; set; } = 25;

        #endregion

        SmtpClient smtp = new SmtpClient();
        MailMessage email = new MailMessage();
        public Correo()
        {
            smtp.Host = this.Servidor;
            smtp.Port = this.Puerto;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = new NetworkCredential(this.CorreoEnvia, this.ClaveEnvia);
            email.From = new MailAddress(this.CorreoEnvia);
            email.IsBodyHtml = true;
            email.Priority = MailPriority.Normal;
        }

        public void EnviarResetearClave(string correo, string nuevaClave)
        {
            Task.Run(() =>
            {
                email.To.Add(new MailAddress(correo));
                email.Subject = $"Restablecer su contraseña SimpleRentCar";
                email.Body = PlantillaResetarClave(nuevaClave);
                smtp.Send(email);
                email.Dispose();
            });
        }
        public void EnviarRegistroNuevoUsuario(string correo, string nombre)
        {
            Task.Run(() =>
            {
                email.To.Add(new MailAddress(correo));
                email.Subject = $"Bienvenido a SimpleRentCar";
                email.Body = PlantillaRegistroNuevoCliente(nombre);
                smtp.Send(email);
                email.Dispose();
            });
        }
        private string PlantillaResetarClave(string nuevaClave)
        {
            return @"
<!DOCTYPE html>
<html lang='en'>
<head>
    <meta charset='UTF-8'>
    <meta http-equiv='X-UA-Compatible' content='IE=edge'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
</head>
<body>
    <div style='width: 550px;display: block; margin:auto;background-color:#f9f8f8;color: black;padding: 15px;border-radius: 12px;' >
        <h3>Su contraseña a sido reestablecida con éxito. </h3>
        <p></p>  
        <p>Su nueva contraseña es  <strong>" + nuevaClave + @"</strong></p>
       
    </div>
 
</body>
</html>

                ";
        }
        private string PlantillaRegistroNuevoCliente(string nombre)
        {
            return @"
<!DOCTYPE html>
<html lang='en'>
<head>
    <meta charset='UTF-8'>
    <meta http-equiv='X-UA-Compatible' content='IE=edge'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
</head>
<body>
    <div style='width: 550px;display: block; margin:auto;background-color:#f9f8f8;color: black;padding: 15px;border-radius: 12px;' >
        <h2>Bienvenido  " + nombre + @"</h2>
        <p>Bienvenido a la plataforma SimpleRentCar, aquí podrás alquilar vehículos, si tienes vehículos también puedes rentarlo. </p>
        <h6>Gracias por registrarte.</h6>
    </div>
 
</body>
</html>

                ";
        }
    }
}
