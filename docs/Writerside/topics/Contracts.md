# Contracts

Das Contracts-Projekt in einer Softwarearchitektur dient dazu, Schnittstellen und Datenübertragungsobjekte (DTOs) zu definieren, die zwischen verschiedenen Schichten oder Diensten der Anwendung ausgetauscht werden. Es stellt sicher, dass alle beteiligten Komponenten eine gemeinsame Sprache sprechen und erleichtert die Wartung und Erweiterung der Anwendung, indem es klare Verträge für die Interaktion definiert.

## Beispiele

Ein Contract ist immer ein Record. Das könnte dann beispielsweise so aussehen:

````C#
public record CreateSubscriptionRequest(
    SubscriptionType SubscriptionType, Guid AdminId);
````

Wenn wir also eine Subscription erstellen wollen, müssen wir also den SubscriptionType und eine AdminId mitgeben. Die Response könnte dann so 
aussehen:

````C#
public record SubscriptionResponse(
    Guid Id,
    SubscriptionType SubscriptionType);
````

Hier geben wir die Id und der Typ einer Subscription zurück.