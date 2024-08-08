# Implementierung des Repository Pattern

Im Infrastructure Layer implementieren wir die eigentlichen Repositories. Ein solches implementiertes Repository kann so aussehen:

````C#
public class SubscriptionRepository : ISubscriptionRepository
{
    private readonly GymManagementDbContext _dbContext;

    public SubscriptionRepository(GymManagementDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Subscription subscription)
    {
        await _dbContext.Subscriptions.AddAsync(subscription);
        await _dbContext.SaveChangesAsync();
    }
}
````

Hier injizieren wir bereits den Datenbankenkontext, um direkt mit der Datenbank über Entity Framework Core zu interagieren.

## Entity Framework Core einrichten

### NuGet-Pakete

Als Erstes müssen wir einige NuGet-Pakete installieren. Im Infrastructure Layer wären das **Microsoft.EntityFrameworkCore**, **Microsoft.
Extensions.Configuration.Binder** und das Entity Framework Paket für deinen Database-Provider, z.B. SQL Server.

Im Presentation Layer im API Projekt kommt das Paket **Microsoft.EntityFrameworkCore.Design** dazu, welches es uns erlaubt Migrationen zu erstellen.

### Connection String

Ebenfalls im API Projekt unter <path>appsettings.json</path> bzw. <path>appsettings.Development.json</path> fügen wir den Connection String zu 
unserer Datenbank hinzu. Bei einer SQL Server Datenbank sieht das so aus:

````json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=GymManagement;Trusted_Connection=True;TrustServerCertificate=True;"
}
````

In der <path>appsettings.json</path> Datei lassen wir einfach alles leer, da diese Datei erst für das Production Environment gebraucht wird. 

````json
"ConnectionStrings": {
  "DefaultConnection": ""
}
````

Dazu erstellen wir noch eine `ConnectionString` Klasse, damit wir nachher auf diese Einstellungen zugreifen können.

````C#
public class ConnectionString
{
    public const string Section = "ConnectionStrings";
    public string DefaultConnection { get; set; } = null!;
}
````

### Datenbankkontext erstellen

Der Datenbankkontext ist die Klasse, mit welcher wir nachher in unseren Repositories kommunizieren werden. Es ist eigentlich eine Abstraktion von 
EF Core für unsere Datenbank.

````C#
public class GymManagementDbContext : DbContext
{
    public GymManagementDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Subscription> Subscriptions { get; set; } = null!;
}
````

Hier registrieren wir dann auch alle Tabellen unserer Datenbank, hier zum Beispiel die Subscriptions.

### Datenbank registrieren 

Nun müssen wir noch unsere Datenbank im <path>DependencyInjection.cs</path> im Infrastructure Layer registrieren.

````C#
public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
{
    var connectionString = new ConnectionString();
    configuration.Bind(ConnectionString.Section, connectionString);

    services.AddSingleton(connectionString);

    services.AddDbContext<GymManagementDbContext>(options =>
        options.UseSqlServer(connectionString.DefaultConnection));

    services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();

    return services;
}
````

Hier erstellen wir also einen neuen Connection String und geben ihm die Daten aus der <path>appsettings.json</path> Datei. Schlussendlich 
registrieren wir diesen als Singleton.

Nun können wir den Datenbankkontext registrieren und schon haben wir unsere Applikation mit einer Datenbank verbunden.

### Migration erstellen

Als Letztes müssen wir noch eine Migration erstellen. Migrations sind eine Funktion von EF Core, die es Entwicklern ermöglicht, das Datenbankschema im Laufe der Zeit in einer versionierten Weise weiterzuentwickeln, wenn sich die Anwendung weiterentwickelt.

- Mit Migrationen kann man Datenbankänderungen einfach anwenden oder rückgängig machen, wenn sich die Anwendung weiterentwickelt, ohne dass bestehende Daten verloren gehen.
- Migrationen generieren automatisch die notwendigen SQL-Skripte für die Aktualisierung des Datenbankschemas und führt sie aus, sodass man keine 
  manuellen Skripte schreiben muss und sich keine Sorgen über Datenverluste machen muss.

Eine Migration erstellen wir mit:

````Shell
dotnet ef migrations add [name]
````

Um sie dann auf die Datenbank anzuwenden, nutzen wir folgenden Command:

````Shell
dotnet ef database update
````

Falls etwas schiefgeht, können wir die letzte Migration entfernen oder die Datenbank löschen und neu erstellen:

````Shell
dotnet ef migration remove
dotnet ef database drop
````