using PeliculasGrupo5.Interfaces;

namespace PeliculasGrupo5.Views;

public partial class PeliculasPage : ContentPage
{
    private readonly IPeliculas _peliculasService;
    public PeliculasPage(IPeliculas peliculas)
	{
        _peliculasService = peliculas;
        InitializeComponent();
	}

    private void btnGuardar_Clicked(object sender, EventArgs e)
    {

    }
}