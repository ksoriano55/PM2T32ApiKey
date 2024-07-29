using PeliculasGrupo5.Endpoints;
using PeliculasGrupo5.Interfaces;
using PeliculasGrupo5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PeliculasGrupo5.Controllers
{
    public class PeliculasController : IPeliculas
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _serializerOptions;

        public PeliculasController()
        {
            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

        }

        public async Task<List<Peliculas>> GetPeliculas()
        {
            try
            {
                var result = new List<Peliculas>();
                string apiKey = Preferences.Get("apikey", "0s3wd18kexawb2thx42cf95q5jf4su");
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, Endpoints.Endpoints.GetPeliculas);
                request.Headers.Add("x-api-key", apiKey);
                HttpResponseMessage response = await _client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var res = JsonSerializer.Deserialize<PeliculasResponse>(content, _serializerOptions);
                    if (res != null)
                    {
                        result = res.data;
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                return new List<Peliculas>();
            }
        }

        public async Task<Peliculas> InsertPeliculas(Peliculas data)
        {
            try
            {
                var result = new Peliculas();
                string apiKey = Preferences.Get("apikey", "0s3wd18kexawb2thx42cf95q5jf4su");

                var jsonContent = JsonSerializer.Serialize(data, _serializerOptions);
                var body = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, Endpoints.Endpoints.GetPeliculas);
                request.Headers.Add("x-api-key", apiKey);
                request.Content = body;

                HttpResponseMessage response = await _client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var res = JsonSerializer.Deserialize<PeliculasResp>(content, _serializerOptions);
                    if (res != null)
                    {
                        result = res.data;
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                return new Peliculas();
            }
        }

        public async Task<ApiResponse> UpdatePeliculas(Peliculas data)
        {
            try
            {
                var result = new ApiResponse();
                string apiKey = Preferences.Get("apikey", "0s3wd18kexawb2thx42cf95q5jf4su");

                var jsonContent = JsonSerializer.Serialize(data, _serializerOptions);
                var body = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, Endpoints.Endpoints.GetPeliculas + "/" + data.peliculaId);
                request.Headers.Add("x-api-key", apiKey);
                request.Content = body;
                HttpResponseMessage response = await _client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var res = JsonSerializer.Deserialize<ApiResponse>(content, _serializerOptions);
                    if (res != null)
                    {
                        result = res;
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                return new ApiResponse();
            }
        }

        public async Task<ApiResponse> DeletePeliculas(int peliculaId)
        {
            try
            {
                var result = new ApiResponse();
                string apiKey = Preferences.Get("apikey", "0s3wd18kexawb2thx42cf95q5jf4su");

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, Endpoints.Endpoints.GetPeliculas + "/" + peliculaId);
                request.Headers.Add("x-api-key", apiKey);
                HttpResponseMessage response = await _client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var res = JsonSerializer.Deserialize<ApiResponse>(content, _serializerOptions);
                    if (res != null)
                    {
                        result = res;
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                return new ApiResponse();
            }
        }
    }
}
