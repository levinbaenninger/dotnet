# Repository und Unit of Work Patterns

## Repository Pattern

Das Repository Pattern vermittelt uns die Illusion, dass wir mit Objekten im Arbeitsspeicher arbeiten. Jedoch wird hinter den Kulissen mit einem persistenten System gearbeitet.

Ein Repository könnte bspw. so aussehen:

````C#
public interface IGymRepository
{
  Task AddGymAsync(Gym gym);
  Task<Gym?> GetByIdAsync(Guid id);
  Task<bool> ExistsAsync(Guid id);
  Task<List<Gym>> ListBySubscriptionIdAsync(Guid subscriptionId);
  Task UpdateGymAsync(Gym gym);
  Task RemoveGymAsync(Gym gym);
  Task RemoveRangeAsync(List<Gym> gyms);
}
````

### Warum?

Zum einen erlaubt es uns einfacher Unit-Tests zu schreiben, das heisst, dass wir z.B. für Unit-Tests eine In-Memory Database benutzen können.

Zum anderen können wir leichter den Datenbank-Provider wechseln, z.B. von Microsoft SQL Server zu Postgres oder gleich ein ganz anderes System wie 
eine NoSQL- oder Document-Datenbank.

### Implementierung - Repository Pattern

Im Application Layer erstellen wir nur das Interface, die eigentliche Implementierung ist im [**Infrastructure Layer**](Infrastructure-Layer.md). 

Die Interfaces erstellen wir unter <path>Common/Interfaces</path>. Ein solches Interface kann beispielsweise so aussehen:

````C#
public interface ISubscriptionRepository
{
    void Add(Subscription subscription);
}
````

Nun können wir in unserem Command Handler dieses Interface nutzen, dafür injizieren wir es:

````C#
private readonly ISubscriptionRepository _subscriptionRepository;

public CreateSubscriptionCommandHandler(ISubscriptionRepository subscriptionRepository)
{
    _subscriptionRepository = subscriptionRepository;
}

public async Task<ErrorOr<Subscription>> Handle(
    CreateSubscriptionCommand request,
    CancellationToken cancellationToken)
{
    await Task.CompletedTask;

    var subscription = new Subscription
    {
        Id = Guid.NewGuid()
    };

    _subscriptionRepository.Add(subscription);

    return subscription;
}
````

## Unit of Work Pattern

Am besten schauen wir uns ein Beispiel an, welches Problematisch sein könnte:

````C#
public class CreateGymCommandHandler : IRequestHandler<CreateGymCommand, ErrorOr<Gym>>
{
    private readonly ISubscriptionRepository _subscriptionRepository;
    private readonly IGymRepository _gymRepository;

    public CreateGymCommandHandler(
        IGymRepository gymRepository,
        ISubscriptionRepository subscriptionRepository)
    {
        _gymRepository = gymRepository;
        _subscriptionRepository = subscriptionRepository;
    }

    public async Task<ErrorOr<Gym>> Handle(CreateGymCommand request, CancellationToken cancellationToken)
    {
        var subscription = await _subscriptionRepository.GetByIdAsync(request.SubscriptionId);

        var gym = new Gym(
            name: request.Name,
            maxRooms: subscription.GetMaxRooms(),
            subscriptionId: subscription.Id);

        subscription.AddGym(gym);

        await _subscriptionRepository.UpdateAsync(subscription);
        await _gymRepository.AddAsync(gym);

        return gym;
    }
}
````

Was jetzt hier passieren kann ist, dass die `UpdateAsync()`-Methode erfolgreich ist, aber die `AddAsync()`-Methode fehlschlägt. Jetzt haben wir 
inkonsistente bzw. widersprüchliche Daten. 

Damit das nicht passiert können wir das Unit of Work Pattern nutzen. Mit ihm sagen wir, dass die Änderungen erst gespeichert werden sollen, wenn 
die alle oberen Anweisungen funktioniert haben, ähnlich wie eine Transaktion in SQL.

````C#
public class CreateGymCommandHandler : IRequestHandler<CreateGymCommand, ErrorOr<Gym>>
{
    private readonly ISubscriptionRepository _subscriptionRepository;
    private readonly IGymRepository _gymRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateGymCommandHandler(
        IGymRepository gymRepository,
        ISubscriptionRepository subscriptionRepository)
    {
        _gymRepository = gymRepository;
        _subscriptionRepository = subscriptionRepository;
    }

    public async Task<ErrorOr<Gym>> Handle(CreateGymCommand request, CancellationToken cancellationToken)
    {
        var subscription = await _subscriptionRepository.GetByIdAsync(request.SubscriptionId);

        var gym = new Gym(
            name: request.Name,
            maxRooms: subscription.GetMaxRooms(),
            subscriptionId: subscription.Id);

        subscription.AddGym(gym);

        await _subscriptionRepository.UpdateAsync(subscription);
        await _gymRepository.AddAsync(gym);
        await _unitOfWork.CommitAsync();

        return gym;
    }
}
````

### Implementierung - Unit of Work Pattern

Gleich wie schon beim Repository Pattern, definieren wir im Application Layer nur das Interface. Später werden wir es dann mit dem 
Infrastructure-Layer implementieren.

````C#
public interface IUnitOfWork
{
    Task CommitChangesAsync();
}
````