using PeliculasGrupo5.Interfaces;

namespace PeliculasGrupo5.Views;

public partial class InicioPage : ContentPage
{
    IUsuarios _usuarioService;

    public InicioPage(IUsuarios usuarios)
	{
        _usuarioService = usuarios;
        InitializeComponent();
	}

    private async void btnInicio_Clicked(object sender, EventArgs e)
    {
        var usuario = txtUsuario.Text;
        var response = await _usuarioService.insertUsuario(usuario);
        if (response != null)
        {
            Preferences.Set("apikey", response.api_key);

            var peliculaService = Services.ServiceProvider.GetService<IPeliculas>();
            PeliculasListPage page = new PeliculasListPage(peliculaService);
            await Navigation.PushAsync(page);
        }
    }
}