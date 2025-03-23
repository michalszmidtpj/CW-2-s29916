namespace CW_2_s29916;

public class Containership(double maxSpeed, int maxCapacity, double maxMass)
{
    public override string ToString()
    {
        var x = Containers.Select(x => x.ToString());
        var y = string.Join(", ", x);
        return
            $"Kontenerowiec: VMAX:{MaxSpeed}, CAPMAX{MaxCapacity}, MASSMAX: {MaxMass}\n\tLOAD: {y}";
    }

    public List<AbstractContainer> Containers { get; private set; } = new List<AbstractContainer>();
    public double MaxSpeed { get; private set; } = maxSpeed; // wezly
    public int MaxCapacity { get; private set; } = maxCapacity; // num
    public double MaxMass { get; private set; } = maxMass; // ton


    private double totalMassInTones()
    {
        return totalMassTonesRange(Containers);
    }

    private static double totalMassTonesRange(List<AbstractContainer> containers)
    {
        return containers.Sum(x => x.CargoMass + x.ContainerSelfMass) / 1000;
    }

    public void LoadContainer(AbstractContainer container)
    {
        if (Containers.Count < MaxCapacity &&
            totalMassInTones() + container.CargoMass + container.ContainerSelfMass <= MaxMass)
            Containers.Add(container);
        else
        {
            throw new OverfillException();
        }
    }

    public void LoadContainers(List<AbstractContainer> containers)
    {
        if (Containers.Count < MaxCapacity && totalMassInTones() + totalMassTonesRange(containers) <= MaxMass)
            Containers.AddRange(containers);
        else
        {
            throw new OverfillException();
        }
    }

    public void UnloadContainer(AbstractContainer container)
    {
        if (Containers.Contains(container))
            Containers.Remove(container);
    }

    public List<AbstractContainer> UnloadContainers()
    {
        var copy = Containers.Slice(0, Containers.Count);
        Containers.Clear();
        return copy;
    }

    public AbstractContainer? ReplaceContainer(string containerID, AbstractContainer newContainer)
    {
        if (Containers.Exists(x => x.SN.Equals(containerID)))
        {
            var found = Containers.Find(x => x.SN.Equals(containerID));
            Containers.Remove(found);
            Containers.Add(newContainer);
            return found;
        }

        return null;
    }

    public static void SwapContainers(Containership containership1, Containership containership2,
        AbstractContainer container)
    {
        var stock1 = containership1.Containers;
        var stock2 = containership2.Containers;

        if (stock2.Contains(container) && stock1.Contains(container))
        {
            return;
        }
        else if (stock1.Contains(container))
        {
            stock1.Remove(container);
            stock2.Add(container);
        }
        else if (stock2.Contains(container))
        {
            stock2.Remove(container);
            stock1.Add(container);
        }
    }
}