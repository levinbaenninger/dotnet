# Result Pattern

Mit dem Result Pattern müssen wir keine Exceptions für erwartete Fehler mehr werfen und somit müssen wir auch keine nervigen `try` ... `catch` 
Blöcke schreiben. 

Anstatt, dass wir einfach zum Beispiel ein `User` Objekt zurückgeben, geben wir ein Result-Objekt zurück, welches entweder den eigentlichen Wert 
beinhaltet oder der Fehler, der aufgetreten ist. Somit müssen wir noch Exceptions werfen, wenn etwas wirklich Unerwartetes passiert. 

Das:

````C#
User GetUser(Guid id = default)
{
  if (id == default)
  {
    throw new ValidationException("Id is required");
  }
  
  return new User(name: "Amichai");
}
````

````C#
try 
{
  var user = GetUser();
  Console.WriteLine(user.Name);
}
catch (Exception e)
{
  Console.WriteLine(e.Message);
}
````

Wird zu dem:

````C#
ErrorOr<User> GetUser(Guid id = default)
{
  if (id == default)
  {
    return Error.Validation("Id is required");
  }
  
  return new User(name: "Amichai");
}
````

````C#
errorOrUser.SwitchFirst(
  user => Console.WriteLine(user.Name),
  error => Console.WriteLine(error.Description));
````

## Implementierung

Wir benutzen das ErrorOr NuGet-Paket, um das Result Pattern einzubauen; dieses installieren wir im Application Layer. Nun ersetzen wir einfach in 
unserem Command und Command Handler den Rückgabewert.

````C#
public record CreateSubscriptionCommand(string SubscriptionType, Guid AdminId)
    : IRequest<ErrorOr<Guid>>;
````

````C#
public class CreateSubscriptionCommandHandler
  : IRequestHandler<CreateSubscriptionCommand, ErrorOr<Guid>>
{
  ...
}
````

Im Controller können wir nun die `Match()`-Methode verwenden um den korrekten Statuscode zurückzugeben.

````C#
var command = new CreateSubscriptionCommand(
  request.SubscriptionType.ToString(),
  request.AdminId);

var result = await _mediator.Send(command);

return result.Match(
  guid => Ok(new SubscriptionResponse(guid, request.SubscriptionType)),
  errors => Problem());
````