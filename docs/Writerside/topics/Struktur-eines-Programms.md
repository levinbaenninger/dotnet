# Struktur eines Programms

Als Beispiel schauen wir uns das erstellte Programm vom Kapitel [Programm erstellen](Programm-erstellen.md) an:

```C#
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
```

Generell wird ein Programm von **oben nach unten** ausgeführt. Später wird dies manchmal nicht der Fall sein, so kann zum Beispiel wieder zu einem 
höheren Punkt im Programm gesprungen werden.

## Kommentare

In der ersten Zeile sehen wir einen Kommentar. Kommentare sind ein Weg um unseren Code zu kommentieren, um ihn vielleicht besser zu verstehen oder 
den Grund für eine bestimmte Zeile Code zu erklären.

> Ein Kommentar wird vom Compiler komplett ignoriert.

In C# gibt es drei verschiedene Arten von Kommentaren: einzeilige, mehrzeilige und XML-Kommentare. 

### Einzeilige Kommentare

Ein einzeiliger Kommentar, wie es der Name schon verrät, nimmt nur eine Zeile ein: 

```C#
// Ich bin ein einzeiliger Kommentar
```

### Mehrzeilige Kommentare

Ein mehrzeiliger Kommentar, wie es der Name ebenfalls schon verrät, nimmt mehrere Zeilen ein:

```C#
/*
  Ich bin ein
  mehrzeiliger
  Kommentar
*/
```

### XML-Kommentare

XML-Kommentare werden benutzt, um beispielsweise eine Klasse oder eine Methode zu dokumentieren:

```C#
/// <summary>
/// Represents the base class that all events derive from.
/// </summary>
public abstract class Event
{
  /// <summary>
  /// Cancels the event and returns the respective result.
  /// </summary>
  /// <param name="utcNow">The current date and time in UTC format.</param>
  /// <returns>The result of the operation.</returns>
  public virtual Result Cancel(DateTime utcNow)
  {
  }
}
```

Wenn wir nun über die Klasse oder Methode hovern, sehen wir die Zusammenfassung, die Parameter und den Rückgabewert.

## Console.WriteLine()

In der zweiten Zeile wird aber Code ausgeführt. Um exakt zu sein, wird die Methode `WriteLine()` der Klasse `Console` ausgeführt. Der Methode 
geben wir Daten mit, in diesem Fall die Zeichenkette `Hello, World!`.

`Console` ist eine Klasse, die standardmässig in unser **Programm importiert** wird, mit welcher wir verschiedene Dinge auf der **Konsole** machen können. 
Neben dem Schreiben auf die Konsole können wir auch **Lesen mit `ReadLine()`** oder sie wieder **leeren mit `Clear()`**.

Klassen und Methoden werden wir später noch genauer anschauen, jedoch können wir sagen, dass **Klassen eine Kollektion mit Daten und Methoden**, 
also Funktionen, sind. 