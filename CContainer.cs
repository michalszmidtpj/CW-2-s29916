namespace CW_2_s29916;

public class CContainer(double cargoMass, double containerSelfMass, double heigth, double loadMax, double temperature)
    : AbstractContainer(cargoMass, containerSelfMass, heigth, loadMax, GenNextSN())
{
    
    public double Temperature { get; private set; } = temperature;
    
    public static readonly Dictionary<CargoProduct, double> Products = new()
    {
        { CargoProduct.Bananas , 13.3},
        { CargoProduct.Chocolate, 18},
        { CargoProduct.Fish, 2},
        { CargoProduct.Meat, -15},
        { CargoProduct.IceCream, -18},
        { CargoProduct.FrozenPizza, -30},
        { CargoProduct.Cheese, 7.2},
        { CargoProduct.Sausages, 5},
        { CargoProduct.Butter, 20.5},
        { CargoProduct.Eggs, 19},
    };
    
    private static uint _uniqueSNHolder = 0;
    private static string GenNextSN() => $"KON-C-{_uniqueSNHolder++}";
}