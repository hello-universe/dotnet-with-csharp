namespace ClassLibrary1;

// ---------------- abstract class can contain 0 abstract method --------------
public abstract class AbsClass1
{
    public void Method1()
    {
        Console.WriteLine("Non-abstract method Method1 inside abstract class AbsClass1");
    }
}

public class NonAbsClass1 : AbsClass1
{
    public void Method2()
    {
        Console.WriteLine("Method2 inside NonAbsClass1");
    }
}

// --------------- The default access modifiers of methods, properties, etc inside interface in public --------------
public interface IMyInterface2
{
    void InterfaceMethod1();
}

// --------------- Polymorphism and method overriding ----------------
// A child class can have same method with same signature as of base class
public class Base
{
    public void Show()
    {
        Console.WriteLine("Show method of Base class");
    }
}

public class Child : Base
{
    public void Show()
    {
        Console.WriteLine("Show method of Child class");
    }
}

public class Base2
{
    public virtual void Display()
    {
        Console.WriteLine("Display method of Base2");
    }
}

public class Child2 : Base2
{
    public override void Display()
    {
        Console.WriteLine("Display method of Child2");
    }
}