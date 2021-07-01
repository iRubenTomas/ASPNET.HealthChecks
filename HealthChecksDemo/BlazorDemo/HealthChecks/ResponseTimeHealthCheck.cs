using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorDemo.HealthChecks
{
    public class ResponseTimeHealthCheck : IHealthCheck
    {
        private Random rnd = new Random();
        
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            //THIS IS HARDCODED - for a real world application we should do a ping or other types of mechanism in order to get the real value of response time
            int responseTime = rnd.Next(1, 300);

            if(responseTime < 100)
            {
                return Task.FromResult(
                    HealthCheckResult.Healthy($"The response time looks good ({responseTime})."));
            }
            else if( responseTime < 200)
            {
                return Task.FromResult(
                    HealthCheckResult.Healthy($"The response time is a bit slow ({responseTime})."));
            }
            else
            {
                return Task.FromResult(
                    HealthCheckResult.Unhealthy($"The response time is unacceptable ({responseTime})."));
            }
        }
    }

    public static class HelperMethods
    {
        public static Random rnd = new Random();
    }
}
