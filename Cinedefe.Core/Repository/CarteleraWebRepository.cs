﻿using System;
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
        private List<Sucursal> sucursales = new List<Sucursal>();

        public List<Ciudad> Ciudades
        {
            get { return this.ciudades; }
        }

        public List<Sucursal> Sucursales
        {
            get
            {
                return this.sucursales;
            }
        }

        public CarteleraWebRepository()
        {
        }

        public List<Ciudad> GetCiudades()
        {
            Task.Run(() => this.GetCiudadesAsync()).Wait();
            return this.ciudades;
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

        public List<Ciudad> GetFuncionesBySucursalId(int sucursalId)
        {
            Task.Run(() => this.GetFuncionesBySucursalAsync(sucursalId)).Wait();
            return this.ciudades;
        }

        private async Task GetFuncionesBySucursalAsync(int sucursalId)
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

        public List<Sucursal> GetSucursalesByCiudad(string ciudad)
        {
            Task.Run(() => this.GetSucursalesByCiudadAsync(ciudad)).Wait();
            return this.sucursales;
        }


        private async Task GetSucursalesByCiudadAsync(string ciudad)
        {
            string apiURL = this.baseURL + "/api/v1.0/sucursales/" + ciudad;

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
                        this.sucursales = JsonConvert.DeserializeObject<List<Sucursal>>(responseJsonString);
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