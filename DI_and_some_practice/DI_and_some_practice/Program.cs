using System;

public class Program
{
    static void Main(string[] args)
    {
        // Example usage
        IEngine engine = new Engine();
        Car2 car = new Car2(engine);
        car.Start();
    }
}

// Without Dependency Injection
public class Car
{
    private Engine _engine;
    public Car()
    {
        _engine = new Engine(); // Correct syntax: add ()
    }

    public void Start()
    {
        _engine.Run();
    }
}

// Engine Interface
public interface IEngine
{
    void Run();
}

// Concrete Engine class
public class Engine : IEngine
{
    public void Run()
    {
        Console.WriteLine("Engine is running.");
    }
}

// With Dependency Injection
public class Car2
{
    private readonly IEngine _engine;

    // Corrected constructor name to Car2 and param type to IEngine
    public Car2(IEngine engine)
    {
        _engine = engine;
    }

    public void Start()
    {
        _engine.Run();
    }
}
