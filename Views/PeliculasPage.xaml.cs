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
        txtFecha.Date = _peliculaSelect.fechaLanzamiento;
        txtSinopsis.Text = _peliculaSelect.sinopsis;
    }

    private async void btnGuardar_Clicked(object sender, EventArgs e)
    {
        if(_peliculaSelect != null)
        {
            if (_delete)
            {
                bool isYes = await DisplayAlert("¿Seguro desea eliminar esta pelicula?", "No se podra revertir", "Si", "No");
                if (isYes)
                {
                    //if (await App.DataBase.DeleteSitio(currentSitio) > 0)
                    //{
                    //    await DisplayAlert("Aviso", "Registros Eliminado con Éxito...!", "OK");
                    //    PageSitiosList page = new PageSitiosList();
                    //    Navigation.PushAsync(page);
                    //    Limpiar();
                    //}
                }
                return;
            }
            else
            {

            }
        }
        else
        {
            Peliculas peliculas = new Peliculas();
            peliculas.titulo = txtTitulo.Text;
            peliculas.generoId = txtGenero.Text;
            peliculas.fechaLanzamiento = txtFecha.Date;
            peliculas.sinopsis = txtSinopsis.Text;
            peliculas.activo = 1;
            peliculas.peliculaId = 0;
        }
    }
}