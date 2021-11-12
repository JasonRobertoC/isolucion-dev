using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace isolucion.Classes
{
    public class ApiControl
    {
        string baseUrl = "http://localhost:50093/";

        public async Task<HttpResponseMessage> PostRequest(StringContent data, string urlApi)
        {

            try
            {
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri(baseUrl);

                    client.DefaultRequestHeaders.Clear();
                    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.PostAsync(urlApi, data);

                    return response;
                }
            }
            catch (Exception e) { throw e; }
        }


        public async Task<HttpResponseMessage> GetRequest(string urlApi)
        {

            try
            {
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri(baseUrl);

                    client.DefaultRequestHeaders.Clear();
                    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync(urlApi);


                    return response;
                }
            }
            catch (Exception e) { throw e; }
        }
    }
}