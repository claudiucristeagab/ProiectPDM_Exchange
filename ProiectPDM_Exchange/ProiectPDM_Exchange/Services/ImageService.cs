using ProiectPDM_Exchange.Constants;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProiectPDM_Exchange.Services
{
    public class ImageService
    {
        private readonly HttpClient httpClient;

        public ImageService()
        {
            httpClient = new HttpClient();
        }

        public string GetImageUri(string currencyName)
        {
            var uri = ApiStrings.Image + currencyName.ToLower() + ".png";
            return uri;
        }
    }
}
