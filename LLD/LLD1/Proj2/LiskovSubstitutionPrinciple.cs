namespace Proj2;

// ---------- DivideByZeroException comes under ArithmeticException --------------

// ----------- LSP not followed for Exception signature -------------------
// public class Base
// {
//     public virtual void DemoMethod1()
//     {
//         throw new DivideByZeroException();
//     }
// }
//
// public class Child : Base
// {
//     public override void DemoMethod1()
//     {
//         throw new ArithmeticException();
//     }
// }

// ------------------ LSP followed for Exception rule -------------------

public class Base
{
    public virtual void DemoMethod1()
    {
        throw new ArithmeticException();
    }
}

public class Child : Base
{
    public override void DemoMethod1()
    {
        throw new DivideByZeroException();
    }
}

public class Client
{
    private Base _base;

    public Client(Base b)
    {
        _base = b;
    }
    public void CallDemo1()
    {
        try
        {
            _base.DemoMethod1();
        }
        catch (ArithmeticException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}