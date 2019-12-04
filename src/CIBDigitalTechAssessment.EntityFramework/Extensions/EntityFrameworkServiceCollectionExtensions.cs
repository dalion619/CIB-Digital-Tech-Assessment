using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CIBDigitalTechAssessment.EntityFramework.Extensions
{
    public static partial class EntityFrameworkServiceCollectionExtensions
    {
        public static IServiceCollection AddPhoneBookDbContext<TContext>( this IServiceCollection serviceCollection, string connectionString, ServiceLifetime contextLifetime = ServiceLifetime.Scoped, ServiceLifetime optionsLifetime = ServiceLifetime.Scoped) where TContext : DbContext
        {
            return serviceCollection.AddDbContextPool<TContext, TContext>(options =>
                options.UseSqlServer(connectionString));
        }
    }
}