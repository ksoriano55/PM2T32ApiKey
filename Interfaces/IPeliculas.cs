using PeliculasGrupo5.Models;

namespace PeliculasGrupo5.Interfaces
{
    public interface IPeliculas
    {
        Task<List<Peliculas>> GetPeliculas();
        Task<Peliculas> InsertPeliculas(Peliculas data);
        Task<ApiResponse> UpdatePeliculas(Peliculas data);
        Task<ApiResponse> DeletePeliculas(int peliculaId);
    }
}
