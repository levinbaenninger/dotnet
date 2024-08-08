# Architectures

Was verstehen wir unter Software Architektur?

> **It's how we structure our software.** - Amichai Mantinband

Das kann in einer Datei sein, wo wir sagen, wie wir spezifischen Code **aufteilen**, wie wir Dateien in unserem Projekt **verteilen** oder wie wir die **Logik** unserer Applikation in verschiedene Teile **aufteilen**.

Aber warum sollten wir überhaupt solch einer Architektur folgen? 

Einerseits wollen wir unsere Codebase **übersichtlich** machen, indem wir verschiedene Bereiche auch dementsprechend unterteilen. So **finden** wir als Entwickler bestimmten Code **schneller**. Andererseits können wir uns bei einer Komponente im System uns denken, was darin **passiert**, da es einer gewissen Skizze folgt.

## Architekturmuster

Was ist ein Architekturmuster, oder engl. Architectural Pattern?

> **Eine allgemeine, wiederverwendbare Lösung für ein häufig auftretendes Problem in der Softwarearchitektur in einem bestimmten Kontext.** - Richard N. Taylor

Zu Architekturmustern gehören unter anderem folgende:

- N-tier/Layered Architecture
- Hexagonal/Ports and Adapters Architecture
- Microservices Architecture
- Clean Architecture
- Service-Oriented Architecture
- Modular Monolith Architecture
- Event-Driven Architecture
- MVC, MVP, MVVM
- ...

### Layered Architecture

Die Layered Architecture oder N-tier Architecture wird sehr häufig genutzt.

![AllgemeinLayered.png](AllgemeinLayered.png) { width="300" }

Jeder Layer (Tier) enthält einen anderen logischen Teils unseres Systems. Dabei zeigen die Pfeile die Abhängigkeiten an. Heisst, dass zum Beispiel 
Tier 3 die Logik von Tier 4 aufrufen kann. Aber auch Tier 1 und 2 können die Logik von Tier 4 aufrufen, jedoch kann Tier 3 keine Logik von Tier 2 
ausführen.

In .NET ist jeder Layer typischerweise ein eigenes Projekt und die Abhängigkeiten sind einfach eine Projektreferenz.

#### Implementierung

Eine Implementierung der Layered Architecture könnte so aussehen:

![ImplementierungLayered.png](ImplementierungLayered.png) { width="300" }

Der Client/User interagiert direkt mit dem Presentation Layer, z.B. einem Controller in einer Web-API oder mit einer Razor Page Applikation.

Wie man jetzt hier sehen kann, ist dieses Architekturmuster durchaus sinnvoll, denn somit ist die Business Logic nicht abhängig vom Presentation 
Layer, das heisst, dass man ganz einfach den Presentation Layer austauschen kann, ohne sämtlichen anderen Code zu änderen. Das Gleiche gilt 
natürlich auch für den Data Access Layer.

#### Problem

Das Problem bei diesem Ansatz ist, dass einen nichts davon abhält direkt mit z.B. der darunterliegenden Datenbank zu kommunizieren, heisst, dass z.
B. der Business Logic Layer mit der Datenbank kommunizieren kann.

### Domain-Centric Architecture

Bei diesem Ansatz wechseln wir den Fokus von der Datenbank zur eigentlichen Business Logic. Dafür müssen wir sicherstellen, dass der Business 
Logic Layer überhaupt keine Abhängigkeiten hat.

Dafür gibt es ebenfalls mehrere Entwurfsmuster:

- [Clean Architecture](Clean-Architecture.md)
- Hexagonal/Ports and Adapters Architecture
- Onion Architecture