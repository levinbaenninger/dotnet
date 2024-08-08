# Strongly Typed Enums implementieren

Bei normalen Enums ist es schwierig und mühsam zu überprüfen, ob sie valide sind. Deshalb nutzen wir das NuGet-Paket **SmartEnums** von Ardalis.

````C#
public class SubscriptionType : SmartEnum<SubscriptionType>
{
    private static readonly SubscriptionType Free = new(nameof(Free), 0);
    private static readonly SubscriptionType Starter = new(nameof(Starter), 1);
    private static readonly SubscriptionType Pro = new(nameof(Pro), 2);
    public SubscriptionType(string name, int value) : base(name, value)
    {
    }
}
````