using WebsiteStatus;
using Serilog;
using Serilog.Formatting.Compact;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .WriteTo.File(@"C:\temp\workerservice\LogFile.txt")
    .CreateLogger();

try
{
    Log.Information("Starting up the service");
    IHost host = Host.CreateDefaultBuilder(args)
        .UseWindowsService()
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
    }).UseSerilog()
    .Build();

    await host.RunAsync();
    return;
}
catch (Exception ex)
{
    Log.Fatal(ex, "There was a problem starting this service");
    return;
}
finally
{
    Log.CloseAndFlush();
}