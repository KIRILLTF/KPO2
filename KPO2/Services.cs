namespace KPO2
{
    interface ICarFactory<TParams>
    {
        Car CreateCar(TParams parameters, int serialNumber);
    }

    class PedalEngineParams
    {
        public int PedalSize { get; set; }
    }

    struct EmptyEngineParams
    {
        public static readonly EmptyEngineParams DEFAULT = new EmptyEngineParams();
    }

    class PedalCarFactory : ICarFactory<PedalEngineParams>
    {
        public Car CreateCar(PedalEngineParams parameters, int serialNumber)
        {
            return new Car(serialNumber, new PedalEngine(parameters.PedalSize));
        }
    }

    class HandCarFactory : ICarFactory<EmptyEngineParams>
    {
        public Car CreateCar(EmptyEngineParams parameters, int serialNumber)
        {
            return new Car(serialNumber, new HandEngine());
        }
    }

    interface ICarProvider
    {
        Car GetCompatibleCar(Customer customer);
    }

    class CarService : ICarProvider
    {
        private List<Car> cars = new List<Car>();

        public void AddCar<TParams>(ICarFactory<TParams> factory, TParams parameters, int serialNumber)
        {
            cars.Add(factory.CreateCar(parameters, serialNumber));
        }

        public Car GetCompatibleCar(Customer customer)
        {
            var car = cars.FirstOrDefault(c => c.IsCompatible(customer));
            if (car != null)
            {
                cars.Remove(car);
            }
            return car;
        }
    }

    interface ICustomersProvider
    {
        IEnumerable<Customer> GetCustomers();
    }

    class CustomerStorage : ICustomersProvider
    {
        private List<Customer> customers = new List<Customer>();

        public void AddCustomer(Customer customer)
        {
            customers.Add(customer);
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return customers;
        }
    }

    class HseCarService
    {
        private readonly ICarProvider carProvider;
        private readonly ICustomersProvider customersProvider;

        public HseCarService(ICarProvider carProvider, ICustomersProvider customersProvider)
        {
            this.carProvider = carProvider;
            this.customersProvider = customersProvider;
        }

        public void SellCars()
        {
            foreach (var customer in customersProvider.GetCustomers())
            {
                if (customer.Car == null)
                {
                    customer.Car = carProvider.GetCompatibleCar(customer);
                }
            }
        }
    }

}
