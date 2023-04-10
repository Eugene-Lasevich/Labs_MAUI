namespace MauiApp1;
using MauiApp1.Lab3.Services;
using MauiApp1.Lab4;
using MauiApp1.Lab4.Services;

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
        builder.Services.AddTransient<IDbService, SQLiteService>();
        builder.Services.AddSingleton<SQLlitePage>();
        builder.Services.AddTransient<IRateService, RateService>();
        builder.Services.AddHttpClient<IRateService, RateService>(opt => opt.BaseAddress = new Uri("https://www.nbrb.by/api/exrates/rates"));
        builder.Services.AddSingleton<Conventor>();
        return builder.Build();
	}
}
