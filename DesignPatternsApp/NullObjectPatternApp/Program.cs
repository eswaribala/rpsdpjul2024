#nullable disable
using NullObjectPatternApp;

namespace NullObjectPatternApp
{
interface Car
    {
        void drive();
        void stop();
    }

class SUV : Car
    {
        public void drive()
        {
            Console.WriteLine("Driving an SUV");
        }

        public void stop()
        {
                Console.WriteLine("Stopping an SUV");
        }
    }

class Sedan: Car
{
    public void drive()
    {
            Console.WriteLine("Driving a Sedan");
    }

    public void stop()
        {
                Console.WriteLine("Stopping a Sedan");
        }
    }
 
class NullCar : Car
{
    public void drive()
    {
    // Do nothing
    }

    public void stop()
    {
        // Do nothing
    }
}
 
class CarRentalService
{
    private Car car;

    public CarRentalService(Car car)
    {
        this.car = car;
    }

    public void rentCar()
    {
        car.drive();
        car.stop();
    }
}

public class Program
{
    public static void Main(String[] args)
    {
        Car suv = new SUV();
        Car sedan = new Sedan();
        Car nullCar = new NullCar();

        CarRentalService rentalService1 = new CarRentalService(suv);
        CarRentalService rentalService2 = new CarRentalService(sedan);
        CarRentalService rentalService3 = new CarRentalService(nullCar);

        rentalService1.rentCar(); // Output: Driving an SUV, Stopping an SUV
        rentalService2.rentCar(); // Output: Driving a Sedan, Stopping a Sedan
        rentalService3.rentCar(); // No output
    }
}
}