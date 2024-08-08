# Programm erstellen

Unser erstes Programm wird eine Konsolen-Applikation sein. Wir können direkt über eine Vorlage solch eine Applikation erstellen, dafür klicken wir 
auf <ui-path>New Project | Console App</ui-path>. Du kannst diese Vorlage auch suchen. 

Wie du siehst, gibt es zig weitere Vorlagen. Manche davon werden wir noch genauer unter die Lupe nehmen.

> **Wichtig:** Es gibt mehrere Vorlagen für eine Konsolen-Applikation; jeweils eine für jede Sprache des .NET Frameworks, also C#, F# und Visual Basic.
>
> **Wähle hier C# aus.**

Benenne nun deine Applikation, wähle dafür einen möglichst treffenden Namen. Wie du sehen kannst, gibt es auch eine sogenannte _**Solution**_, die du 
benennen kannst. Eine Solution ist nichts anderes als ein einfacher **Container** für mehrere ähnliche bzw. **zusammenhängende** Projekte. In unserem 
Fall gibt es nur ein Projekt in unserer Solution, deshalb können wir dort einfach den vorgeschlagenen Namen stehen lassen.

Auf der nächsten Seite können wir noch weitere Einstellungen treffen, wie die Version des Frameworks, aktuell **.NET 8.0**, und andere Einstellungen. 
Hier lassen wir alles so stehen wie es ist und erstellen nun unser Projekt.

In unserem Projekt wurde eine Datei <path>Program.cs</path> erstellt mit den folgenden zwei Zeilen Code: 

```C#
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
```

Wenn wir dieses Programm nun einfach mit dem grünen Play-Button laufen lassen, werden wir sehen, dass sich die Konsole mit den Worten **Hello, 
World!** öffnet.

Im nächsten Schritt werden wir erfahren, was jetzt hier genau passiert ist:[](Struktur-eines-Programms.md).