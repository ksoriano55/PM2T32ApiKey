using PeliculasGrupo5.Interfaces;
using PeliculasGrupo5.Models;

namespace PeliculasGrupo5.Views;

public partial class PeliculasPage : ContentPage
{
    private readonly IPeliculas _peliculasService;
    bool _delete = false;
    Peliculas? _peliculaSelect;
    public PeliculasPage(IPeliculas peliculas, Peliculas? peliculaSelect = null, bool delete = false)
    {
        _peliculasService = peliculas;
        _delete = delete;
        _peliculaSelect = peliculaSelect;
        InitializeComponent();

        if (peliculaSelect != null)
        {
            if (delete)
            {
                btnGuardar.Text = "Borrar";
                btnGuardar.Background = Colors.DarkRed;
            }
            else
            {
                btnGuardar.Text = "Editar";
                btnGuardar.Background = Colors.DarkOrange;
            }
            loadData();
        }
    }

    private void loadData()
    {
        txtTitulo.Text = _peliculaSelect.titulo;
        txtGenero.Text = _peliculaSelect.generoId;
        txtFecha.Date = Convert.ToDateTime(_peliculaSelect.fechaLanzamiento);
        txtSinopsis.Text = _peliculaSelect.sinopsis;
    }

    private async void btnGuardar_Clicked(object sender, EventArgs e)
    {
        Peliculas peliculas = new Peliculas();
        peliculas.titulo = txtTitulo.Text;
        peliculas.generoId = txtGenero.Text;
        peliculas.fechaLanzamiento = txtFecha.Date.ToString("yyyy-MM-dd");
        peliculas.sinopsis = txtSinopsis.Text;
        peliculas.activo = 1;

        if (_peliculaSelect != null)
        {
            if (_delete)
            {
                bool isYes = await DisplayAlert("¿Seguro desea eliminar esta pelicula?", "No se podra revertir", "Si", "No");
                if (isYes)
                {
                    var result = await _peliculasService.DeletePeliculas(_peliculaSelect.peliculaId);
                    if (result != null)
                    {
                        await DisplayAlert("Exito", "¡Pelicula Eliminada exitosamente!", "OK");
                    }
                }
            }
            else
            {
                peliculas.peliculaId = _peliculaSelect.peliculaId;
                var result = await _peliculasService.UpdatePeliculas(peliculas);
                if (result != null)
                {
                    await DisplayAlert("Exito", "¡Pelicula Actualizada exitosamente!", "OK");
                }
            }
        }
        else
        {
            peliculas.peliculaId = 0;

            var result = await _peliculasService.InsertPeliculas(peliculas);
            if (result != null)
            {
                await DisplayAlert("Exito", "¡Pelicula guardada exitosamente!", "OK");
            }
        }

        var peliculaService = Services.ServiceProvider.GetService<IPeliculas>();
        PeliculasListPage page = new PeliculasListPage(peliculaService);
        await Navigation.PushAsync(page);
    }
}