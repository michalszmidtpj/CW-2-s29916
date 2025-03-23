using Microsoft.VisualBasic;

namespace CW_2_s29916;

public abstract class AbstractContainer(double cargoMass, double containerSelfMass, double heigth, double loadMax, string sn)
{

    public double CargoMass { get; protected set; } = cargoMass; //in kg
    public double ContainerSelfMass { get; protected set; } = containerSelfMass;
    public double Heigth { get; protected set; } = heigth; // in cm
    public string SN { get; protected set; } = sn; // Serial Number
    public double LoadMax { get; protected set; } = loadMax; // in kg


    protected void BasicSafeLoadCheck(double mass)
    {
        if (CargoMass + mass > LoadMax)
            throw new OverfillException();
    }

    protected void BasicSafeUnloadCheck(double mass)
    {
        if (CargoMass - mass < 0) 
            throw new Exception("cannot unload more than there is inside container");
    }

    public virtual void Load(double mass)
    {
        BasicSafeLoadCheck(mass);
        CargoMass += mass;
    }

    public virtual void Unload(double mass)
    {
        BasicSafeUnloadCheck(mass);
        CargoMass -= mass;
    }

    public override string ToString()
    {
        return $"[{SN}]";
    }

    public string Information()
    {
        return $"{SN}: \n\tCargoMass: {CargoMass}, \n\tContainerSelfMass: {ContainerSelfMass}, \n\tHeigth: {Heigth}, \n\toadMax: {LoadMax}";
    }
}