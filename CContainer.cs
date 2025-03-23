namespace CW_2_s29916;

public class CContainer : AbstractContainer
{
    public CContainer(double cargoMass,
        double containerSelfMass,
        double heigth,
        double loadMax,
        double temperature,
        CargoProduct cargoProductType) : base(cargoMass, containerSelfMass, heigth, loadMax, GenNextSN())
    {
        Temperature = temperature;
        var a = Products.GetValueOrDefault(cargoProductType);
        if (temperature < a)
            throw new Exception("temperature is too low");
        CargoProductType = cargoProductType;
    }

    public double Temperature { get; private set; }
    public CargoProduct CargoProductType { get; private set; }

    public static readonly Dictionary<CargoProduct, double> Products = new()
    {
        { CargoProduct.Bananas, 13.3 },
        { CargoProduct.Chocolate, 18 },
        { CargoProduct.Fish, 2 },
        { CargoProduct.Meat, -15 },
        { CargoProduct.IceCream, -18 },
        { CargoProduct.FrozenPizza, -30 },
        { CargoProduct.Cheese, 7.2 },
        { CargoProduct.Sausages, 5 },
        { CargoProduct.Butter, 20.5 },
        { CargoProduct.Eggs, 19 },
    };

    private static uint _uniqueSNHolder = 0;
    private static string GenNextSN() => $"KON-C-{_uniqueSNHolder++}";
}