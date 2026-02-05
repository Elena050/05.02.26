public class CarFactory
{
    public Car CreateCar(string type, int wheels, string engine)
    {
        var car = new Car
        {
            Type = type,
            Wheels = wheels,
            Engine = engine
        };
        car.Validate();
        car.Initialize();
        return car;
    }

    public Car CreateSedan() => CreateCar("Sedan", 4, "V6");
    public Car CreateSUV() => CreateCar("SUV", 4, "V8");
    public Car CreateTruck() => CreateCar("Truck", 6, "Diesel");
}
