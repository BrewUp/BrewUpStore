using BrewUpStore.Modules.Store;
using BrewUpStore.ReadModel.MongoDb;
using BrewUpStore.Shared.Configuration;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace BrewUpStore.Tests;

public class AppHttpClientFixture : IDisposable
{
    public readonly HttpClient Client;

    public AppHttpClientFixture()
    {
        var app = new BrewUpStoreApplication();
        Client = app.CreateClient();
        Client.BaseAddress = new Uri("https://localhost:5001");
        
    }

    private class BrewUpStoreApplication : WebApplicationFactory<Program>
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {
            var mongoDbSettings = new MongoDbSettings
            {
                ConnectionString = "mongodb://localhost",
                DatabaseName = "BrewUp-Store"
            };

            builder.ConfigureServices(services =>
            {
                services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(dispose: true));

                services.AddMongoDb(mongoDbSettings);
                services.AddStoreModule();

            });

            return base.CreateHost(builder);
        }
    }

    #region Dispose
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposing) return;
        Client.Dispose();
    }
    #endregion
}