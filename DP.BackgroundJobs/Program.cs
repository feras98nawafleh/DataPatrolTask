using DP.BackgroundJobs.BackgroundJobs;
using DP.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = Host.CreateDefaultBuilder(args);

builder.UseSerilog((context, configuration) =>
configuration.ReadFrom.Configuration(context.Configuration));

builder.ConfigureServices((context, services) =>
{
    services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(context.Configuration.GetConnectionString("DefaultConnection")));

    services.AddHostedService<UsersRequestsJob>();
});

var host = builder.Build();
host.Run();
