using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Web.Mvc;
using DatosMaestros.Models;
using System.Net.Http;
using System.Text;
using System.Net.Http.Headers;

namespace DatosMaestros.App_Data
{
    public class ConnectionDataBase
    {
        public class Apis
        {
            public string urlApi { get; set; } = "https://localhost:44324/";

            public DataTable ObtenerDataApi(string api)
            {
                var url = urlApi + api ;
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "application/json";
                request.Accept = "application/json";
                string responseBody = "";


                try
                {
                    using (WebResponse response = request.GetResponse())
                    {
                        using (Stream strReader = response.GetResponseStream())
                        {
                            if (strReader == null) ;
                            using (StreamReader objReader = new StreamReader(strReader))
                            {
                                responseBody = objReader.ReadToEnd();
                                // Do something with responseBody

                                DataTable dt = (DataTable)JsonConvert.DeserializeObject(responseBody, typeof(DataTable));

                                return dt;
                            }
                        }
                    }
                }
                catch (WebException ex)
                {
                    // Handle error

                    string sas = ex.Message;
                    throw;
                }
            }

            public async Task<int> SaveDataAutor(Autor autor)
            {

                var res = 0;

                HttpClient _httpClient = new HttpClient();
                string ignored = JsonConvert.SerializeObject(autor, Formatting.Indented,
                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                var content = new StringContent(ignored, Encoding.UTF8, "application/json");

                string url = urlApi + $"createAuthor";
                var request = new HttpRequestMessage(HttpMethod.Post, url);
                request.Headers.Clear();
                request.Headers.ConnectionClose = false;
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                request.Content = content;
                var response = await _httpClient.SendAsync(request);


                using (var stream = await response.Content.ReadAsStreamAsync())
                {
                    
                    if (response.IsSuccessStatusCode)
                    {

                        res = 1;
                       
                    }
                    else if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        res = 2;
                    }
                    else
                    {
                        res = 3;

                    }

                }

                return res;

            }


            public async Task<int> SaveDataLibro(Libros libro)
            {

                var res = 0;

                HttpClient _httpClient = new HttpClient();
                string ignored = JsonConvert.SerializeObject(libro, Formatting.Indented,
                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                var content = new StringContent(ignored, Encoding.UTF8, "application/json");

                string url = urlApi + $"createBook";
                var request = new HttpRequestMessage(HttpMethod.Post, url);
                request.Headers.Clear();
                request.Headers.ConnectionClose = false;
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                request.Content = content;
                var response = await _httpClient.SendAsync(request);


                using (var stream = await response.Content.ReadAsStreamAsync())
                {

                    if (response.IsSuccessStatusCode)
                    {

                        res = 4;

                    }
                    else if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        res = 5;
                    }
                    else
                    {
                        res = 6;

                    }

                }

                return res;

            }


        }
    }
}

