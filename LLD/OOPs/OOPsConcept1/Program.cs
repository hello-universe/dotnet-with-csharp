using System.Runtime.Intrinsics.X86;
using ClassLibrary1;

namespace OOPsConcept1;

class SampleClass
{
    static SampleClass()
    {
        Console.WriteLine("Static constructor of SampleClass");
    }

    public SampleClass()
    {
        Console.WriteLine("Instance constructor of SampleClass");
    }
}

public static class MathHelper
{
    static MathHelper()
    {
        Console.WriteLine("Static constructor of MathHelper");
    }
    public static int Sum(int a, int b)
    {
        return a + b;
    }
}

public interface IMyInterface
{
    void Method1();
}

public class MyClass : IMyInterface
{
    public void Method1()
    {
        Console.WriteLine("Method1 in MyClass");
    }
}

public static class MyInterfaceExtensions
{
    public static void Method2(this IMyInterface myInterface)
    {
        Console.WriteLine("Extension method2 of MyInterface");
    }
}

public static class MyClassExtensions
{
    public static void Method3(this MyClass myClass)
    {
        Console.WriteLine("Extension method3 of MyClass");
    }

    public static void Method4(this MyClass myClass)
    {
        Console.WriteLine("Extension method4 of MyClass");
    }
}

public class ImplementationClass : IMyInterface2{
    public void InterfaceMethod1()
    {
        Console.WriteLine("Implemented method of interface");
    }
}
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        SampleClass obj = new SampleClass();
        SampleClass obj1 = new SampleClass();
        Console.WriteLine(MathHelper.Sum(5, 4));
        Console.WriteLine(MathHelper.Sum(2, 3));

        Product p1 = new Product();
        p1.Name = "P1";

        Bank b1 = new Bank();
        b1.Amount = 100;
        Console.WriteLine(b1.Amount);
        Console.WriteLine(b1.AccountNumber);
        // b1.AccountNumber = Guid.Empty;

        // ---------- The below code will throw exception ------------
        // Bank b2 = new Bank();
        // b2.Amount = -200;
        // Console.WriteLine(b2.Amount);
        IMyInterface mi = new MyClass();
        mi.Method1();
        mi.Method2();
        // mi.Method3(); //Can't call Method3 with reference variable of Interface because Method3 is extension method
        //of class MyClass and not of the interface

        MyClass mc1 = new MyClass();
        mc1.Method2();
        mc1.Method3();
        mc1.Method3(); //Method 3 can be called with reference variable of MyClass
        
        NonAbsClass1 nac1 = new NonAbsClass1();
        nac1.Method1();
        nac1.Method2();
        
        // ------------ Method overriding and polymorphism ------------------
        Base baseRef = new Child();
        baseRef.Show(); // Show method of base class will be called

        Child childRef = new Child();
        childRef.Show();
        
        //Method overriding
        Base2 base2Ref = new Child2();
        base2Ref.Display(); //Display method of child will be called
        
        Child2 child2Ref = new Child2();
        child2Ref.Display(); //Display method of child will be called
    }
}
