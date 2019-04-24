using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using Cinedefe.Core.Model;

namespace Cinedefe.Core.Repository
{
    public class CarteleraWebRepository
    {
        string baseURL = "http://192.168.100.139/CinedefeBackend";
        private List<Ciudad> ciudades = new List<Ciudad>();

        public List<Ciudad> Ciudades
        {
            get { return this.ciudades; }
        }

        public CarteleraWebRepository()
        {
            Task.Run(() => this.GetCiudadesAsync()).Wait();
        }

        private async Task GetCiudadesAsync()
        {
            string apiURL = this.baseURL + "/api/v1.0/ciudades";

            var uri = new Uri(apiURL);

            string responseJsonString = null;

            using (var httpClient = new HttpClient())
            {
                try
                {
                    var getResponse = await httpClient.GetAsync(uri);
                    if (getResponse.IsSuccessStatusCode)
                    {
                        responseJsonString = await getResponse.Content.ReadAsStringAsync();
                        this.ciudades = JsonConvert.DeserializeObject<List<Ciudad>>(responseJsonString);
                    }
                }
                catch (Exception ex)
                {
                    //handle any errors here, not part of the sample app
                    string message = ex.Message;
                }
            }
        }
    }
}