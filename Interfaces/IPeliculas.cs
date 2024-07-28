using PeliculasGrupo5.Models;

namespace PeliculasGrupo5.Interfaces
{
    public interface IPeliculas
    {
        Task<Peliculas> GetPeliculas();
    }
}
