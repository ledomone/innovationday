using BlazorServerSignalRApp.Constants;
using BlazorServerSignalRApp.Hubs;
using BlazorServerSignalRApp.Models;
using Microsoft.AspNetCore.SignalR;
using MongoDB.Driver;

namespace BlazorServerSignalRApp.BackgroundServices;

public class ParcelInfoChangeWatcherBackgroundService : BackgroundService
{
    private readonly IHubContext<ParcelInfoHub> _hub;
    private readonly IMongoCollection<ParcelInfoModel> _collection;

    public ParcelInfoChangeWatcherBackgroundService(IMongoDatabase database, IHubContext<ParcelInfoHub> hub)
    {
        _hub = hub;
        _collection = database.GetCollection<ParcelInfoModel>(CollectionNames.Parcels);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using var cursor = await _collection.WatchAsync(cancellationToken: stoppingToken);
            foreach (var change in cursor.ToEnumerable())
            {
                await _hub.Clients.All.SendAsync("ParcelInfoUpdatedMessage", change.FullDocument, cancellationToken: stoppingToken);
            }
        }
    }
}