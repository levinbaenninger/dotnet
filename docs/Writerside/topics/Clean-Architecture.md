# Clean Architecture

Bei Clean Architecture fokussieren wir uns vor allem auf die Businesslogik. Das heisst, dass dieser Layer keine Abhängigkeiten hat. Bei Clean 
Architecture sieht das so aus:

![CleanArchitecture.png](CleanArchitecture.png) { width="400" }

Der Domain und der Application Layer zusammen sind die eigentliche Businesslogik unserer Applikation. Eine weitere Darstellungsmöglichkeit zeigt 
uns die Abhängigkeiten genauer:

![LayerDiagramCA.png](LayerDiagramCA.png) { width="500" }

Wie auch bei der [**Layered Architecture**](Architectures.md#layered-architecture) ist der Presentation Layer dafür da, um mit dem Client/User zu 
interagieren.

Des Weiteren haben wir den Infrastructure Layer, welcher unter anderem für den Datenbank-Zugriff zuständig ist.

Vor allem beim oberen Diagramm erkennt man, dass alle anderen Layer in Richtung Application und Domain Layer zeigen. Das heisst, wir können die 
Businesslogik ohne den Presentation oder Infrastructure Layer implementieren, bzw. können wir diese zwei Layer jederzeit ersetzen können.

> Clean Architecture separates the software into layers with a dependency rule that layers only point inwards.
> 
> Inner Layers contain business logic, and outer layers contain infrastructure and interaction with the outer world.

