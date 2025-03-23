using System.Diagnostics;

namespace CW_2_s29916;

public class LContainer(double cargoMass, double containerSelfMass, double heigth, double loadMax, bool unsafeCargo)
    : AbstractContainer(cargoMass, containerSelfMass, heigth, loadMax, GenNextSN()), IHazardNotifier
{
    private static uint _uniqueSNHolder = 0;
    private static string GenNextSN() => $"KON-L-{_uniqueSNHolder++}";

    public bool UnsafeCargo { get; private set; } = unsafeCargo;

    public override void Load(double mass)
    {
        BasicSafeLoadCheck(mass);
        if (UnsafeCargo && CargoMass + mass >= 0.5 * LoadMax)
        {
            NotifyDanger("Mass > 50% LoadMax");
            return;
        } 
        if (!UnsafeCargo && CargoMass + mass > 0.9 * LoadMax)
        {
            NotifyDanger("Mass > 90% LoadMax");
            return;
        }

        CargoMass += mass;
    }

    public void NotifyDanger(string message)
    {
        Console.Error.WriteLine($"Danger: {message}");
    }
}