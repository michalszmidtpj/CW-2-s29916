namespace CW_2_s29916;

public class GContainer(double cargoMass, double containerSelfMass, double heigth, double loadMax, double pressure)
    : AbstractContainer(cargoMass, containerSelfMass, heigth, loadMax, GenNextSN()), IHazardNotifier
{
    public double Pressure { get; private set; } = pressure;

    private static uint _uniqueSNHolder = 0;
    private static string GenNextSN() => $"KON-G-{_uniqueSNHolder++}";


    public override void Load(double mass)
    {
        if (CargoMass + mass > LoadMax)
        {
            NotifyDanger("Mass > LoadMax");
            return;
        }
        CargoMass += mass;
    }

    public override void Unload(double mass)
    {
        BasicSafeUnloadCheck(mass);
        if (CargoMass - mass < 0.95 * LoadMax)
        {
            NotifyDanger("Unloaded more than 95% LoadMax");
            return;
        }

        CargoMass -= mass;
    }


    public void NotifyDanger(string message)
    {
        Console.Error.WriteLine($"Danger: {message}");
    }
}