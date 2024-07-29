using Microsoft.Extensions.Logging;
using PeliculasGrupo5.Controllers;
using PeliculasGrupo5.Interfaces;
using PeliculasGrupo5.Views;

namespace PeliculasGrupo5
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddSingleton<IPeliculas, PeliculasController>();
            builder.Services.AddSingleton<IUsuarios, UsuariosController>();
            builder.Services.AddTransient<PeliculasPage>();
            builder.Services.AddTransient<PeliculasListPage>();
            builder.Services.AddTransient<InicioPage>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            var app = builder.Build();

            Services.ServiceProvider.Initialize(app.Services);

            return app;

        }
    }
}
