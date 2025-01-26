namespace KPO2
{
    class Customer
    {
        public string Name { get; private set; }
        public int LegStrength { get; private set; }
        public int HandStrength { get; private set; }
        public Car Car { get; set; }

        public Customer(string name, int legStrength, int handStrength)
        {
            Name = name;
            LegStrength = legStrength;
            HandStrength = handStrength;
            Car = null;
        }

        public override string ToString()
        {
            return $"Customer: name = {Name}, legStrength = {LegStrength}, handStrength = {HandStrength}, car = {(Car != null ? Car.ToString() : "None")};";
        }
    }
}
