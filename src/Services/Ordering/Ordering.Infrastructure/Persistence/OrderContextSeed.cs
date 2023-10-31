using Microsoft.Extensions.Logging;
using Ordering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Persistence
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContext context, ILogger<OrderContextSeed> logger)
        {
            if (!context.Orders.Any())
            {
                context.Orders.AddRange(GetPreconfiguredOrders());

                await context.SaveChangesAsync();

                logger.LogInformation("Seed database with {DbContextName}", typeof(OrderContext).Name);
            }
        }

        private static IEnumerable<Order> GetPreconfiguredOrders()
        {
            return new List<Order>
            {
                new Order()
                { 
                    Username = "Ali",
                    FirstName = "Ali",
                    LastName = "Atyabi",
                    EmailAddress = "a@b.com",
                    AddressLine = "Tehran",
                    Country = "Iran",
                    TotalPrice = 500,
                    LastModifiedBy = "Ali",
                }
            };
        }
    }
}
