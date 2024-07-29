using PeliculasGrupo5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasGrupo5.Interfaces
{
    public interface IUsuarios
    {
        Task<Usuario> insertUsuario(string usuario);
    }
}
