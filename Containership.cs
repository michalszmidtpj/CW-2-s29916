namespace CW_2_s29916;

public class Containership(double maxSpeed, int maxCapacity, double maxMass)
{
    public override string ToString()
    {
        return
            $"Kontenerowiec: VMAX:{MaxSpeed}, CAPMAX{MaxCapacity}, MASSMAX: {MaxMass}\nLOAD: {Containers.ToString()}";
    }

    public List<AbstractContainer> Containers { get; private set; } = new List<AbstractContainer>();
    public double MaxSpeed { get; private set; } = maxSpeed;
    public int MaxCapacity { get; private set; } = maxCapacity;
    public double MaxMass { get; private set; } = maxMass;


    public void LoadContainer(AbstractContainer container)
    {
        Containers.Add(container);
    }

    public void LoadContainers(List<AbstractContainer> containers)
    {
        Containers.AddRange(containers);
    }

    public void UnloadContainer(AbstractContainer container)
    {
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