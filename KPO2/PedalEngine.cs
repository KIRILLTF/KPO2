using KPO2;

class PedalEngine : IEngine
{
    public int PedalSize { get; private set; }

    public PedalEngine(int pedalSize)
    {
        PedalSize = pedalSize;
    }

    public bool IsCompatible(Customer customer)
    {
        return customer.LegStrength > 5;
    }

    public override string ToString()
    {
        return "PedalEngine";
    }
}