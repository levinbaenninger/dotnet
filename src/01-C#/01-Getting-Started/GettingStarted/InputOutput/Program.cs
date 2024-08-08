// Output
Console.WriteLine("Prints on ");
Console.WriteLine("New line");

Console.Write("Prints on ");
Console.Write("Same line");

// Output literals and variables
int value = 10;

// Variable
Console.WriteLine(value);

// Literal
Console.WriteLine(10);

// Concatenation
Console.WriteLine("Value is " + value);
Console.WriteLine($"Value is {value}");

// Input
Console.Write("Enter your name: ");
#pragma warning disable CS8600
string name = Console.ReadLine();
#pragma warning restore CS8600
Console.WriteLine($"Hello, {name}!");
