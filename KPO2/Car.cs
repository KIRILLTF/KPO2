namespace KPO2
{
    class Car
    {
        public int SerialNumber { get; private set; }
        public IEngine Engine { get; private set; }

        public Car(int serialNumber, IEngine engine)
        {
            SerialNumber = serialNumber;
            Engine = engine;
        }

        public bool IsCompatible(Customer customer)
        {
            return Engine.IsCompatible(customer);
        }

        public override string ToString()
        {
            return $"Car: serialNumber = {SerialNumber}, engine = {Engine};";
        }
    }
}