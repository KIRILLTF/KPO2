using KPO2;

class HandEngine : IEngine
{
    public bool IsCompatible(Customer customer)
    {
        return customer.HandStrength > 5;
    }

    public override string ToString()
    {
        return "HandEngine";
    }
}