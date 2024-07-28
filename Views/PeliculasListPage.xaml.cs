using PeliculasGrupo5.Interfaces;
using PeliculasGrupo5.Models;

namespace PeliculasGrupo5.Views;

public partial class PeliculasListPage : ContentPage
{
    private readonly IPeliculas _peliculasService;
    public PeliculasListPage(IPeliculas peliculas)
    {
        _peliculasService = peliculas;
        InitializeComponent();
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        var list = await _peliculasService.GetPeliculas();
        PeliculasList.ItemsSource = list;
    }

    private void PeliculasList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    private async void OnItemSelected(object sender, TappedEventArgs e)
    {
        var frame = sender as Frame;
        if (frame == null)
            return;

        var pelicula = frame.BindingContext as Peliculas;

        string action = await DisplayActionSheet("Opciones", "Cancelar", null, "Editar", "Eliminar");

        switch (action)
        {
            case "Editar":
                EditarPelicula(pelicula);
                break;
            case "Eliminar":
                EliminarPelicula(pelicula);
                break;

        }
    }

    private void EditarPelicula(Peliculas peliculas)
    {
        var peliculaService = Services.ServiceProvider.GetService<IPeliculas>();
        PeliculasPage page = new PeliculasPage(peliculaService, peliculas, false);
        Navigation.PushAsync(page);
    }

    private void EliminarPelicula(Peliculas peliculas)
    {
        var peliculaService = Services.ServiceProvider.GetService<IPeliculas>();
        PeliculasPage page = new PeliculasPage(peliculaService, peliculas, true);
        Navigation.PushAsync(page);
    }

    private void registrarNuevo(object sender, EventArgs e)
    {
        var peliculaService = Services.ServiceProvider.GetService<IPeliculas>();
        PeliculasPage page = new PeliculasPage(peliculaService);
        Navigation.PushAsync(page);
    }
}