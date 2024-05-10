using HealthCareApp.Services;
using HealthCareApp.View;
using Microsoft.Extensions.Logging;

namespace HealthCareApp
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

            builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
            builder.Services.AddSingleton<IGeolocation>(Geolocation.Default);
            builder.Services.AddSingleton<IMap>(Map.Default);

            builder.Services.AddSingleton<MedicineService>();
            builder.Services.AddSingleton<HospitalService>();
            builder.Services.AddSingleton<ExerciseService>();

            builder.Services.AddSingleton<MedicinesViewModel>();
            builder.Services.AddTransient<MedicineDetailsViewModel>();

            builder.Services.AddSingleton<HospitalsViewModel>();
            builder.Services.AddTransient<HospitalDetailsViewModel>();

            builder.Services.AddSingleton<ExercisesViewModel>();
            builder.Services.AddTransient<ExerciseDetailsViewModel>();


            builder.Services.AddSingleton<MedicinesPage>();
            builder.Services.AddTransient<MedicineDetailsPage>();

            builder.Services.AddSingleton<HospitalsPage>();
            builder.Services.AddTransient<HospitalDetailsPage>();

            builder.Services.AddSingleton<ExercisesPage>();
            builder.Services.AddTransient<ExerciseDetailsPage>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
