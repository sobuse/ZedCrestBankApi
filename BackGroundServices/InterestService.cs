using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace ZedCrestBankApi.BackGroundServices
{
    public class InterestService : BackgroundService
    {
        private UdpClient client;

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            client = new UdpClient(9000);
            throw new NotImplementedException();
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var currentTime = DateTime.UtcNow;
                if(currentTime.Hour == 12 && currentTime.Minute == 0 && currentTime.Second == 0)
                {
                    PayInterest();
                }
            }
            return Task.CompletedTask;
        }

        public decimal PayInterest()
        {
            decimal amount = Convert.ToDecimal(1000);


           
            return amount;
        }
    }
}
