using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.AspNetCore.TestHost;
using Xunit;

namespace BlazorServerSignalRApp.test.Integration;

public class MessagingTest
{
    [Fact]
    public async Task reply_with_the_same_message_when_invoke_send_method()
    {
        TestServer server = null;
        var message = "Integration Testing in Microsoft AspNetCore SignalR";
        var echo = string.Empty;
        var webHostBuilder = new WebHostBuilder()
            .ConfigureServices(services =>
            {
                //services.AddSignalR();
            })
            .Configure(app =>
            {
                //app.UseSignalR(routes => routes.MapHub<EchoHub>("/parcel-info-hub"));
            });

        server = new TestServer(webHostBuilder);
        var connection = new HubConnectionBuilder().WithUrl("http://localhost/parcel-info-hub").Build();

        connection.On<string>("ReceiveParcelInfoUpdatedMessage", msg =>
        {
            echo = msg;
        });

        echo.Should().Be(message);
    }
}