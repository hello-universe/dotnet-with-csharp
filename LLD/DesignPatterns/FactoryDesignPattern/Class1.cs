namespace FactoryDesignPattern;

// ------------- Simple Factory ------------------
public interface IBurger
{
    void Prepare();
}

public class BasicBurger : IBurger
{
    public void Prepare()
    {
        Console.WriteLine("Preparing Basic Burger");
    }
}

public class StandardBurger : IBurger
{
    public void Prepare()
    {
        Console.WriteLine("Preparing Standard Burger");
    }
}

public class PremiumBurger : IBurger
{
    public void Prepare()
    {
        Console.WriteLine("Preparing Premium Burger");
    }
}

public class BurgerFactory
{
    public static IBurger CreateBurger(string type)
    {
        if (type == "basic")
        {
            return new BasicBurger();
        }
        else if (type == "standard")
        {
            return new StandardBurger();
        }
        else if (type == "premium")
        {
            return new PremiumBurger();
        }
        else
        {
            Console.WriteLine("Invalid Burger type");
            return null;
        }
    }
}