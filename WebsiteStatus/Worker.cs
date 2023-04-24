namespace WebsiteStatus
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private HttpClient client;
        private string webUrl = "https://www.victormadu.tech";

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            client = new HttpClient();
            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            client.Dispose();
            _logger.LogInformation("The service has been stopped...");
            return base.StopAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                var result = await client.GetAsync(webUrl);
                _logger.LogInformation("Getting result completed");

                if (result.IsSuccessStatusCode)
                {
                    _logger.LogInformation("Website is up and running at {statusCode}", result.StatusCode);
                }
                else
                {
                    _logger.LogError("Website is down. SOS! Status code: {statusCode}", result.StatusCode);
                }
                await Task.Delay(5000, stoppingToken);
            }
        }
    }
}