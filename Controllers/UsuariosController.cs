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
    public class UsuariosController : IUsuarios
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _serializerOptions;

        public UsuariosController()
        {
            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<Usuario> insertUsuario(string usuario)
        {
            try
            {
                var result = new Usuario();
                var requestBody = new
                {
                    username = usuario
                };
                HttpResponseMessage response = await _client.PostAsJsonAsync(Endpoints.Endpoints.insertUser, requestBody);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    var res = JsonSerializer.Deserialize<UsuarioResponse>(content, _serializerOptions);
                    if (res != null)
                    {
                        result = res.data;
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                return new Usuario();
            }
        }
    }
}
