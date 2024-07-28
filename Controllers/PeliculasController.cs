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
                //HttpResponseMessage response = await _client.GetAsync(Endpoints.Endpoints.GetPeliculas);
                //if (response.IsSuccessStatusCode)
                //{
                //string content = await response.Content.ReadAsStringAsync();
                string content = "{\r\n  \"data\": [\r\n    {\r\n      \"peliculaId\": 1,\r\n      \"generoId\": \"Terror\",\r\n      \"titulo\": \"Superbad\",\r\n      \"sinopsis\": \"Dos amigos de la infancia intentan aprovechar su última noche juntos antes de ir a la universidad, enfrentando situaciones cómicas y embarazosas.\",\r\n      \"fechaLanzamiento\": \"2024-07-28T06:00:00.000Z\",\r\n      \"activo\": 1\r\n    }\r\n  ]\r\n}\r\n\r\n";
                var res = JsonSerializer.Deserialize<PeliculasResponse>(content, _serializerOptions);
                if (res != null)
                {
                    result = res.data;
                }
                //}
                return result;
            }
            catch (Exception ex)
            {
                return new List<Peliculas>();
            }
        }

        public async Task<List<Peliculas>> InsertPeliculas(Peliculas data)
        {
            try
            {
                var result = new List<Peliculas>();
                HttpResponseMessage response = await _client.PostAsJsonAsync(Endpoints.Endpoints.insertPeliculas, data);
                response.Headers.Add("x-api-key", "0s3wd18kexawb2thx42cf95q5jf4su");
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

        public async Task<ApiResponse> UpdatePeliculas(Peliculas data)
        {
            try
            {
                var result = new ApiResponse();
                HttpResponseMessage response = await _client.PostAsJsonAsync(Endpoints.Endpoints.updatePeliculas + data.peliculaId, data);
                response.Headers.Add("x-api-key", "0s3wd18kexawb2thx42cf95q5jf4su");
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
                HttpResponseMessage response = await _client.DeleteAsync(Endpoints.Endpoints.deletePeliculas + peliculaId);
                response.Headers.Add("x-api-key", "0s3wd18kexawb2thx42cf95q5jf4su");
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
