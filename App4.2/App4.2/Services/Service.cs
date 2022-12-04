using App4_2.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace App4_2.Services
{
    public class Service
    {
        HttpClient client;

        string url = "http://10.0.2.2:44399/";
        //string url = "http://zeus.apolosoftware.com.ec/Test/";
        public Service()
        {
            HttpClientHandler insecureHandler = GetInsecureHandler();
            client = new HttpClient(insecureHandler); 
        }

        public HttpClientHandler GetInsecureHandler()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
            {
                if (cert.Issuer.Equals("CN=localhost"))
                    return true;
                return errors == System.Net.Security.SslPolicyErrors.None;
            };
            return handler;
        }

        public async Task<List<Marca>> MarcaQueryAsync()
        {
            Uri uri = new Uri(url + "api/Marca/Query");

            HttpResponseMessage response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions { WriteIndented = true };

                return JsonSerializer.Deserialize<List<Marca>>(content, options);
            }

            return new List<Marca>();
        }

        public async Task<List<Producto>> ProductoQueryAsync()
        {
            Uri uri = new Uri(url + "api/Producto/Query");

            HttpResponseMessage response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions { WriteIndented = true };

                return JsonSerializer.Deserialize<List<Producto>>(content, options);
            }

            return new List<Producto>();
        }


        public async Task<Producto> ProductoGetAsync(int IdProducto)
        {
            Uri uri = new Uri(url + "api/Producto/Get?IdProducto=" + IdProducto);
            HttpResponseMessage response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions { WriteIndented = true };

                return JsonSerializer.Deserialize<Producto>(content, options);
            }

            return null;
        }

        public async Task<bool> ProductoInsertAsync(Producto model)
        {
            Uri uri = new Uri(url + "api/Producto/Insert");

            string json = JsonSerializer.Serialize(model);

            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(uri, httpContent);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> ProductoUpdateAsync(Producto model)
        {
            try
            {
                Uri uri = new Uri(url + "api/Producto/Update");

                string json = JsonSerializer.Serialize(model);

                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PutAsync(uri, httpContent);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }

                return false;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }

        public async Task<bool> ProductoDeleteAsync(Producto model)
        {
            Uri uri = new Uri(url + "api/Producto/Delete");

            string json = JsonSerializer.Serialize(model);

            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(uri, httpContent);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }
    }
}
