namespace CW_2_s29916;

public class Containership(double maxSpeed, int maxCapacity, double maxMass)
{
    public override string ToString()
    {
        return $"Kontenerowiec: VMAX:{MaxSpeed}, CAPMAX{MaxCapacity}, MASSMAX: {MaxMass}\nLOAD: {Containers.ToString()}";
    }

    public List<AbstractContainer> Containers { get; private set; } = new List<AbstractContainer>();
    public double MaxSpeed { get; private set; } = maxSpeed;
    public int MaxCapacity { get; private set; } = maxCapacity;
    public double MaxMass { get; private set; } = maxMass;


    public void LoadContainer(AbstractContainer container)
    {
        
    }

    public void LoadContainers(List<AbstractContainer> containers)
    {
    }

    public AbstractContainer UnloadContainer(AbstractContainer container)
    {
    }

    public List<AbstractContainer> UnloadContainers()
    {
        
    }

    public AbstractContainer ReplaceContainer(string containerID) 
    {
    }

    public static SwapContainers(Containership containership, Containership containership2, AbstractContainer container)
    {
        
    }
    
    
    

}