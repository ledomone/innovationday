using BlazorServerSignalRApp.Constants;
using MongoDB.Driver;

namespace BlazorServerSignalRApp.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMongoDatabase(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(ConfigurationKeys.ConnectionStrings.MongoDb);
        var url = new MongoUrl(connectionString);
        var settings = MongoClientSettings.FromUrl(url);

        var client = new MongoClient(settings);
        var database = client.GetDatabase(url.DatabaseName);

        services.AddSingleton(client);
        services.AddSingleton(database);

        return services;
    }
}