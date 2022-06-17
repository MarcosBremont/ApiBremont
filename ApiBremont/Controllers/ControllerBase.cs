using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBremont.Controllers
{
    public class ControlBase : ControllerBase
    {
        public int StrToInt(string valor)
        {
            int.TryParse(valor, out int temp);
            return temp;
        }
        public double StrToDbl(string valor)
        {
            double.TryParse(valor, out double temp);
            return temp;
        }
        async public Task<string> GrabarFoto(string base64)
        {
            string nombreFoto = Guid.NewGuid().ToString() + ".jpg";
            try
            {

                //var empresa = new Empresa().Get();
                var rutaFoto = "C:/inetpub/wwwroot/apibremont.tecnolora.com/wwwroot/Images";
                //if (!Directory.Exists(rutaFoto))
                //    Directory.CreateDirectory(rutaFoto);

                byte[] bytes = Convert.FromBase64String(base64);

                using (Image image = await Image.LoadAsync(new System.IO.MemoryStream(bytes)))
                {
                    image.Mutate(x => x.Resize(image.Width / 2, image.Height / 2));
                    image.Save(rutaFoto + "/" + nombreFoto);
                }
            }
            catch (Exception ex)
            {
                nombreFoto = "asasasa" + ex;
            }
            return nombreFoto;
        }
    }
}
