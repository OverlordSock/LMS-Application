using Microsoft.Extensions.Logging;

namespace LMS_Task_4
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

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            // Register the following services
            builder.Services.AddSingleton<MainViewModel>();//add this
            builder.Services.AddTransient<InventoryPage>();//add this
            builder.Services.AddTransient<StatisticsPage>();//add this
            builder.Services.AddTransient<ManagementPage>();//add this
            return builder.Build();
        }
    }
}
