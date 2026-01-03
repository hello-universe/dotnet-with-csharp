using FactoryDesignPattern;
using SingletonDesignPattern;
using StrategyDesignPattern;

namespace DesignPatterns.ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        // -------- Strategy Design Pattern -------------
        
        // Robot companionRobot = new CompanionRobot(new NormalWalk(), new NormalTalk(), new NoFly());
        // companionRobot.Walk();
        // companionRobot.Talk();
        // companionRobot.Fly();
        
        
        // --------------- Simple Factory -------------

        // string type = "standard";
        // IBurger burger = BurgerFactory.CreateBurger(type);
        // burger?.Prepare();
        
        
        // ----------------- Factory Method Design Pattern --------------

        ICreditCard creditCard1 = new TitaniumFactory().CreateProduct();
        Console.WriteLine(creditCard1.GetCardType());
        Console.WriteLine(creditCard1.GetAnnualCharge());
        Console.WriteLine(creditCard1.GetCreditLimit());
        
        // --------------- Singleton Design Pattern ---------------
        
        LazySingleton instance = LazySingleton.GetInstance();
        LazySingleton instance1 = LazySingleton.GetInstance();
    }
}