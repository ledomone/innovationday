using BlazorServerSignalRApp.Models;
using Microsoft.AspNetCore.SignalR;

namespace BlazorServerSignalRApp.Hubs
{
    public class ParcelInfoHub : Hub
    {
        public async Task SendParcelInfoUpdatedMessage(ParcelInfoModel parcelInfoModel)
        {
            await Clients.All.SendAsync("ReceiveParcelInfoUpdatedMessage", parcelInfoModel);
        }
    }
}
