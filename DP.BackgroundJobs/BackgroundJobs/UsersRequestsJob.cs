using DP.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;
using static DP.Core.Enums.Enums;

namespace DP.BackgroundJobs.BackgroundJobs
{
    public class UsersRequestsJob : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public UsersRequestsJob(IServiceProvider serviceProvider, ILogger<Worker> logger)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await ProcessRequests();
                await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
            }
        }

        private async Task ProcessRequests()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var _context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                var pendingRequests = await _context.UserRequests
                    .Where(r => r.RequestDateTime < DateTime.UtcNow && r.Status == RequestStatus.Draft)
                    .ToListAsync();

                foreach (var request in pendingRequests)
                {
                    try
                    {
                        Log.Information($"Processing request with Id: {request.RequestId}");

                        request.Status = RequestStatus.InReview;
                        Log.Information($"Reviewing request with Id: {request.RequestId}");

                        await _context.SaveChangesAsync();

                        var user = await _context.Users.FindAsync(request.RequestedBy);
                        if (user is null || !user.IsEnabled)
                        {
                            request.Status = RequestStatus.Rejected;
                            Log.Warning($"Rejected request with Id: {request.RequestId} ... user not found!");
                        }
                        else if (request.RequestCode % 4 == 0)
                        {
                            request.Status = RequestStatus.Rejected;
                            Log.Warning($"Rejected request with Id: {request.RequestId} ... request has false code!");
                        }
                        else
                        {
                            request.Status = RequestStatus.Approved;
                            Log.Information($"Approved request with Id: {request.RequestId}");
                        }

                        request.CompletionDateTime = DateTime.UtcNow;
                        await _context.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        Log.Error($"Error processing request with Id: {request.RequestId}: {ex.Message}");
                        request.Status = RequestStatus.Error;
                        await _context.SaveChangesAsync();
                    }
                }
            }
        }
    }
}
