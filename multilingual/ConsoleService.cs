using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiLingualConsoleDB
{
    /// <summary>
    /// https://snede.net/get-started-with-net-generic-host/
    /// </summary>
    public class ConsoleService : IHostedService
    {
        private readonly MultiLingualDbContext context;

        private ILogger<ConsoleService> Logger { get; }
        private CancellationTokenSource CancellationTokenSource { get; } = new CancellationTokenSource();
        private TaskCompletionSource<bool> TaskCompletionSource { get; } = new TaskCompletionSource<bool>();

        public ConsoleService(ILogger<ConsoleService> logger, MultiLingualDbContext context)
        {
            Logger = logger;
            this.context = context;
        }


        public Task StartAsync(CancellationToken cancellationToken)
        {
            //var l = context.Languages.ToList();
            //var c = context.Courses
            //               .Include(course=> course.Course_Ts.Where(t=> t.Language.Id == l.First().Id));



            Task.Run(() => DoWork(CancellationTokenSource.Token));
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            CancellationTokenSource.Cancel();

            // Defer completion promise, until our application has reported it is done.
            return TaskCompletionSource.Task;
        }

        private async Task DoWork(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                Logger.LogInformation("Hello World");
                await Task.Delay(1000);
            }

            await Task.CompletedTask;
        }
    }
}
