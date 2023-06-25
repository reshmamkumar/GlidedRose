using GlidedRose.Domain.BusinessLogic.Factory;
using GlidedRose.Domain.BusinessLogic.Policies;
using GlidedRose.Domain.BusinessLogic.Policies.Interface;
using GlidedRose.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using static System.Net.Mime.MediaTypeNames;

using IHost host = CreateHostBuilder(args).Build();
using var scope = host.Services.CreateScope();

var services = scope.ServiceProvider;

try
{
    services.GetRequiredService<App>().Run(args);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

IHostBuilder CreateHostBuilder(string[] strings)
{
    return Host.CreateDefaultBuilder()
        .ConfigureServices((_, services) =>
        {
            services.AddSingleton<IUpdateItemPolicy, UpdateItemPolicy>();
            services.AddTransient<IStockItemUpdatePolicy, AgedBrieUpdatePolicy>();
            services.AddTransient<IStockItemUpdatePolicy, BackStagePassesUpdatePolicy>();
            services.AddTransient<IStockItemUpdatePolicy, ConjuredUpdatePolicy>();
            services.AddTransient<IStockItemUpdatePolicy, StandardItemsUpdatePolicy>();
            services.AddTransient<IStockItemUpdatePolicy, SulurasUpdatePolicy>();
            services.AddSingleton<App>();
        });
}