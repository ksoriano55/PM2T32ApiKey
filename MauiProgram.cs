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
            builder.Services.AddTransient<PeliculasPage>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
