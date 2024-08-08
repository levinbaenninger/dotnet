# HTTP-Requests

Um in Visual Studio Code HTTP-Requests zu machen, gibt es eine Extension: **REST Client**. Installiere diese Erweiterung.

Wenn wir nun ein <path>.http</path> File öffnen können wir eine Request schicken. Solch eine Datei sieht zum Beispiel so aus:

````HTTP
@host=https://localhost:7251

POST {{host}}/auth/register
Content-Type: application/json

{
  "firstName": "Levin",
  "lastName": "Bänninger",
  "email": "levin@baenninger.com",
  "password": "Levin1232!"
}
````

Ganz oben definieren wir eine Variable in unserem Fall ist das der Port, auf welchem unsere API Requests entgegennimmt.

Danach bestimmten wir die Art von Request (GET, POST, PUT, DELETE) und die URI. Dann können wir noch Header-Informationen mitgeben wie hier den
Content-Type, aber auch z.B. einen JWT Token für die Authentifizierung.

Schliesslich geben wir noch bei POST oder PUT Requests einen Body mit. 

> Alternativ kann auch Postman genutzt werden.