using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasGrupo5.Models
{
    public class Peliculas
    {
        public int peliculaId { get; set; }
        public string generoId { get; set; } = string.Empty;
        public string titulo { get; set; } = string.Empty;
        public string sinopsis { get; set; } = string.Empty;
        public string fechaLanzamiento { get; set; } = string.Empty;
        public int activo { get; set; }
    }
    public class PeliculasResponse
    {
        public List<Peliculas> data { get; set; }
    }

    public class PeliculasResp
    {
        public Peliculas data { get; set; }
    }

    public class ApiResponse
    {
        public string message { get; set; }
    }
}
