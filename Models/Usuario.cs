using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasGrupo5.Models
{
    public class Usuario
    {
        public int id { get; set; }
        public string api_key { get; set; } = string.Empty;
        public string username { get; set; } = string.Empty;
    }

    public class UsuarioPOST
    {
        public string userName { get; set; }
    }

    public class UsuarioResponse
    {
        public Usuario data { get; set; }

    }
}
