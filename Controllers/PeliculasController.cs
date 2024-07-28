using PeliculasGrupo5.Endpoints;
using PeliculasGrupo5.Interfaces;
using PeliculasGrupo5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<Peliculas> GetPeliculas()
        {
            try
            {
                var result = new Peliculas();
                HttpResponseMessage response = await _client.GetAsync(Endpoints.Endpoints.GetPeliculas);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    var res = JsonSerializer.Deserialize<Peliculas>(content, _serializerOptions);
                    if (res != null)
                    {
                        result = res;
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                return new Peliculas();
            }
        }
    }
}
