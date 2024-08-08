# CQRS und Mediator Patterns

## CQRS Pattern

CQRS steht für **Command Query Responsibility Segregation** und kurz zusammengefasst kann man sagen, dass es die Leseaktionen von den 
Schreibaktionen trennt.

Beispiele für Commands sind zum Beispiel das **Erstellen eines Gyms oder eines Raumes**, aber auch das **Löschen**. Alle Räume, a**lle Gyms, etc. holen** sind 
Beispiele für Queries. Commands ändern also den Status in unserem System, während Queries nur lesen und nichts ändern.

Die Interfaces für die jeweiligen Services könnten so aussehen:

````C#
public interface IGymWriteService
{
  Gym CreateGym(string name);
  void DeleteGym();
}

public interface IGymReadService
{
  List<Gym> GetGyms()
}
````

## Mediator Pattern

Ohne das Mediator Pattern kommunizieren Objekte direkt miteinander. Mit dem Mediator Pattern wird ein Mediator zwischen die Objekte eingeschoben 
und dieser kommuniziert nun jeweils mit den Objekten.

![WithoutMediator.png](WithoutMediator.png) { width="300" }

![WithMediator.png](WithMediator.png) { width="500" }

Anhand dieser Grafiken erkennen wir ganz gut was der Unterschied ist. Der Mediator nimmt also die Anfrage von `A` an und leitet sie weiter and `B`. `B` 
antwortet dann dem Mediator und auch hier leitet der Mediator die Antwort weiter an `A`.

So sind die beiden Klassen `A` und `B` unabhängig voneinander und wir können ganz einfach die Implementierung ändern. Zudem können im Mediator 
beispielsweise Validatoren ausgeführt werden.

### Implementierung

Als Erstes müssen wir das NuGet-Paket **MediatR** in unserem Application Layer installieren. Zudem brauchen wir jetzt keine Services mehr, sondern 
wir teilen unsere Use-Cases nach CQRS auf. Das sieht dann so aus:

![ApplicationLayer.png](ApplicationLayer.png) { thumbnail="true" width="400" }

Mit MediatR können wir Requests und Request Handler definieren. Dann können wir im Controller eine solche MediatR-Request senden und ruft dann den entsprechenden Request Handler auf.

#### Beispiel

**<path>CreateSubscriptionCommand.cs</path>**

````C#
public record CreateSubscriptionCommand(string SubscriptionType, Guid AdminId) : IRequest<Guid>;
````

Hier erstellen wir einfach einen Record mit den benötigten Parametern. Zudem soll dieser Record von `IRequest<TResponse>` erben; dabei ist 
`TResponse` der Rückgabewert-Datentyp unseres Commands.

**<path>CreateSubscriptionCommandHandler.cs</path>**

````C#
public class CreateSubscriptionCommandHandler : IRequestHandler<CreateSubscriptionCommand, Guid>
{
    public Task<Guid> Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
    {
        ...
    }
}
````

Der Handler selbst erbt dieses Mal vom `IRequestHandler<TRequest, TResponse>` Interface; `TRequest` ist die Request welche behandelt werden soll 
und `TResponse` der Datentyp des Rückgabewertes. 

Nun müssen wir nur noch das Interface implementieren. 

**<path>SubscriptionsController.cs</path>**

````C#
[ApiController]
[Route("subscriptions")]
public class SubscriptionsController : ControllerBase
{
    private readonly ISender _mediator;

    public SubscriptionsController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateSubscription(CreateSubscriptionRequest request)
    {
        var command = new CreateSubscriptionCommand(
            request.SubscriptionType.ToString(),
            request.AdminId);

        var subscriptionId = await _mediator.Send(command);

        var response = new SubscriptionResponse(subscriptionId, request.SubscriptionType);

        return Ok(response);
    }
}
````

Hier injecten wir dann noch das `ISender` Interface von MediatR um die Request schlussendlich senden zu können. Zudem erstellen wir im Body 
unserer Methode eine Command Variable welche unseren Command beinhaltet. Danach senden wir mit der `Send()`-Methode den Command oder Query zum 
Handler.

**<path>DependencyInjection.cs</path>**

````C#
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(options =>
            options.RegisterServicesFromAssemblyContaining(typeof(DependencyInjection)));

        return services;
    }
}
````

Als Letztes müssen wir noch MediatR registrieren.