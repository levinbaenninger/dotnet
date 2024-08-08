# Implementierung des Unit of Work Patterns

Im Application Layer haben wir bereits das Interface für das Unit of Work Pattern definiert. Nun implementieren wir dieses Interface im 
Infrastructure Layer.

Dafür gehen wir in unseren Datenbankkontext und implementieren dort das Interface:

````C#
public class GymManagementDbContext : DbContext, IUnitOfWork
{
    ...

    public async Task CommitChangesAsync()
    {
        await base.SaveChangesAsync();
    }
    
    ...
}
````

Nun müssen wir in unsere Repository-Methoden gehen und dort die `SaveChangesAsync()`-Methode austauschen:

````C#
public class SubscriptionRepository : ISubscriptionRepository
{
    ...
    
    public async Task AddAsync(Subscription subscription)
    {
        await _dbContext.Subscriptions.AddAsync(subscription);
        await _dbContext.CommitChangesAsync();
    }
    
    ...
}
````

Wir können die Methode aber auch zum Beispiel in einem Command Handler aufrufen, anstatt sie direkt in der Repository Methode aufzurufen. 

Nun müssen wir noch das Interface und die Implementierung registrieren:

````C#
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        ...
        
        services.AddScoped<IUnitOfWork>(serviceProvider =>
            serviceProvider.GetRequiredService<GymManagementDbContext>());
            
        ...

        return services;
    }
}
````