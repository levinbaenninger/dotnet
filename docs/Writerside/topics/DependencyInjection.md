# Dependency Injection

In unserer Applikation müssen wir oftmals eine Abhängigkeit zum Beispiel einen Service registrieren:

````C#
builder.Services.AddScoped<ISubscriptionService, SubscriptionService>
````

So können wir nun den Service beispielsweise in unserem Controller verwenden und ihn injizieren.

Normalerweise macht man das im <path>Program.cs</path>, also beim Startpunkt unserer Applikation. 

In einer grösseren Applikation wird irgendwann jeder Layer eine Menge an Dependencies haben, wenn wir diese alle im <path>Program.cs</path> 
registrieren, wird die Skalierung auf lange Sicht nicht funktionieren.

## Die Lösung

In jedem unserer Layer erstellen wir eine statische Klasse, die so aussieht:

````C#
public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        
        return services;
    }
}
````

> NuGet-Paket `Microsoft.Extensions.DependencyInjection.Abstractions` muss noch hinzugefügt werden.

In der Methode können wir dann unsere Abhängigkeiten registrieren.

Nun müssen wir nur noch im <path>Program.cs</path> diese Methode aufrufen und schon haben wir die Registrierung der Abhängigkeiten zu ihren 
jeweiligen Layern verschoben.

````C#
var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
      .AddPresentation()
      .AddApplication()
      .AddInfrastructure();
}
````

> **Wichtig:** Damit wir in unserem Presentation Layer auf die <path>DependencyInjection.cs</path> Datei im Infrastructure Projekt zugreifen 
> können müssen wir eine Referenz hinzufügen, welche Clean Architecture eigentlich verletzt. 
> 
> Um das wiedergutzumachen, gibt es einige Ansätze. Der einfachste wäre es alle Klassen in Infrastructure als `internal` zu markieren.