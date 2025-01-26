namespace KPO2

{
    internal class Program
    {
        static void Main(string[] args)
        {
            var carService = new CarService();
            var customerStorage = new CustomerStorage();
            var hseCarService = new HseCarService(carService, customerStorage);

            var pedalCarFactory = new PedalCarFactory();
            var handCarFactory = new HandCarFactory();

            customerStorage.AddCustomer(new Customer("Customer1", 6, 4));
            customerStorage.AddCustomer(new Customer("Customer2", 4, 6));
            customerStorage.AddCustomer(new Customer("Customer3", 6, 6));
            customerStorage.AddCustomer(new Customer("Customer4", 4, 4));

            carService.AddCar(pedalCarFactory, new PedalEngineParams { PedalSize = 30 }, 1);
            carService.AddCar(pedalCarFactory, new PedalEngineParams { PedalSize = 35 }, 2);
            carService.AddCar(handCarFactory, EmptyEngineParams.DEFAULT, 3);
            carService.AddCar(handCarFactory, EmptyEngineParams.DEFAULT, 4);

            Console.WriteLine("Before selling cars:");
            foreach (var customer in customerStorage.GetCustomers())
            {
                Console.WriteLine(customer);
            }

            hseCarService.SellCars();

            Console.WriteLine("\nAfter selling cars:");
            foreach (var customer in customerStorage.GetCustomers())
            {
                Console.WriteLine(customer);
            }
        }
    }
}