// See https://aka.ms/new-console-template for more information


using CW_2_s29916;


try
{
    // > 50 % masy
    var lc1 = new LContainer(0, 500, 2, 1000, true);
    lc1.Load(999);

    // 5 % zostawić oraz overload
    var gc1 = new GContainer(0, 500, 2, 1000, 10);
    gc1.Load(2000);
    gc1.Load(1000);
    gc1.Unload(999);

    // zła temperatura
    var cc1 = new CContainer(0, 500, 2, 1000, -10, CargoProduct.Bananas);
}

catch (Exception e)
{
    Console.WriteLine(e.Message);
}


try
{
    var cship1 = new Containership(40, 2, 4.5);
    var lc2 = new LContainer(0, 500, 2, 1000, true);
    var gc2 = new GContainer(0, 500, 2, 1000, 10);
    var cc2 = new CContainer(0, 500, 2, 1000, 14, CargoProduct.Bananas);

// za dużo kontenerów
    cship1.LoadContainer(lc2);
    cship1.LoadContainer(gc2);
    cship1.LoadContainer(cc2);
}

catch (Exception e)
{
    Console.WriteLine(e.Message);
}


try
{
// za duża masa
    var cship2 = new Containership(20, 3, 0.5);
    var lc3 = new LContainer(0, 200, 1, 500, false);
    var gc3 = new GContainer(0, 200, 1, 500, 5);
    var cc3 = new CContainer(0, 200, 1, 500, 21, CargoProduct.Butter);

    cship2.LoadContainers([lc3, cc3, gc3]);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

Console.WriteLine();

var cship3 = new Containership(40, 3, 10);
var cship4 = new Containership(20, 3, 5);

var lc4 = new LContainer(0, 500, 2, 1000, true);
var gc4 = new GContainer(0, 500, 2, 1000, 10);
var cc4 = new CContainer(0, 500, 2, 1000, 14, CargoProduct.Bananas);

var lc5 = new LContainer(0, 200, 1, 500, false);
var gc5 = new GContainer(0, 200, 1, 500, 5);
var cc5 = new CContainer(0, 200, 1, 500, 21, CargoProduct.Butter);

var cc6 = new CContainer(0, 200, 1, 500, -20, CargoProduct.FrozenPizza);

Console.WriteLine("Container info");
Console.WriteLine(cc6.Information());
Console.WriteLine();

cship3.LoadContainers([lc4, gc4, cc4]);
cship4.LoadContainers([lc5, gc5, cc5]);

Console.WriteLine("Replace: ");
Console.WriteLine(cship3);
cship3.ReplaceContainer(cc4.SN, cc6);
Console.WriteLine(cship3);
Console.WriteLine();

Console.WriteLine("Swap: ");
Console.WriteLine(cship3);
Console.WriteLine(cship4);
Containership.SwapContainers(cship3,cship4, cc6);
Console.WriteLine(cship3);
Console.WriteLine(cship4);
Console.WriteLine();

Console.WriteLine("unload 1: ");
Console.WriteLine(cship4);
cship4.UnloadContainer(cc6);
Console.WriteLine(cship4);
Console.WriteLine();

Console.WriteLine("unload all: ");
Console.WriteLine(cship3);
cship3.UnloadContainers();
Console.WriteLine(cship3);
Console.WriteLine();
