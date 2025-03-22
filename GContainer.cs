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
            NotifyDanger();
            return;
        }
        CargoMass += mass;
    }

    public override void Unload(double mass)
    {
        BasicSafeUnloadCheck(mass);
        if (CargoMass - mass < 0.95 * LoadMax)
        {
            NotifyDanger();
            return;
        }

        CargoMass -= mass;
    }


    public void NotifyDanger()
    {
        throw new NotImplementedException();
    }
}