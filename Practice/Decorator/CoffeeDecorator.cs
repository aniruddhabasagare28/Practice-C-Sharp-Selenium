using System;

// Step 1: Define the base component interface
public interface ICoffee
{
    string GetDescription();
    double GetCost();
}

// Step 2: Concrete Component (Basic Coffee)
public class SimpleCoffee : ICoffee
{
    public string GetDescription() => "Plain Coffee";
    public double GetCost() => 5.0; // Base price
}

// Step 3: Decorator Base Class (Implements ICoffee)
public abstract class CoffeeDecorator : ICoffee
{
    protected ICoffee _coffee;  // Composition: wrapping the original object

    public CoffeeDecorator(ICoffee coffee)
    {
        _coffee = coffee;
    }

    public virtual string GetDescription() => _coffee.GetDescription();
    public virtual double GetCost() => _coffee.GetCost();
}

// Step 4: Concrete Decorators (Adding Features)

// Adding Milk
public class MilkDecorator : CoffeeDecorator
{
    public MilkDecorator(ICoffee coffee) : base(coffee) { }

    public override string GetDescription() => _coffee.GetDescription() + ", Milk";
    public override double GetCost() => _coffee.GetCost() + 1.5; // Additional cost for milk
}

// Adding Sugar
public class SugarDecorator : CoffeeDecorator
{
    public SugarDecorator(ICoffee coffee) : base(coffee) { }

    public override string GetDescription() => _coffee.GetDescription() + ", Sugar";
    public override double GetCost() => _coffee.GetCost() + 0.5; // Additional cost for sugar
}
 
