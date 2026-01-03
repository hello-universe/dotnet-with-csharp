using System.Runtime.InteropServices;
using Proj2;

namespace LLD1;

public class MyClass
{
    public void Method1()
    {
        Console.WriteLine("Method1 of MyClass");
    }
}

public static class MyExtension
{
    public static void ExtMethod1(this MyClass myClass)
    {
        Console.WriteLine("Ext method 1 of MyClass");
    }
}

class Program
{
    public delegate void MyDelegate(string msg);
    
    public 
    static void Main(string[] args)
    {
        // ------------- Project Reference Demo ---------------------
        // Product p1 = new Product();
        // p1.Name = "TV";
        // p1.Price = 100;
        
        // ---------------- Array Initialization Demo ---------------
        
        // int[] arr = new int[5];
        // arr[0] = 5;
        // Console.WriteLine(arr[0]);

        // ------------- Extension Method Demo -------------------
        
        MyClass obj = new MyClass();
        obj.Method1();
        obj.ExtMethod1();
        
        // -------------- Exception Handling ----------------

        // try
        // {
        //     // int a = 5;
        //     // int b = 0;
        //     // int res = a / b;
        //     throw new Exception("My Exceptin is thrown");
        // }
        // // catch (Exception e)
        // // {
        // //     Console.WriteLine(e.Message);
        // // }
        // finally
        // {
        //     Console.WriteLine("Finally block executed");
        // }
        
        // ----------------- Delegates ----------------
        //TODO
        
        // --------------- Signature Rule - Exception rule in LSP ----------------
        Client obj1 = new Client(new Child());
        obj1.CallDemo1();
        
        // ----------------- Dependency Inversion Principle ----------------
        UserService user = new UserService(new SQLDatabase());
        user.StoreUser();
    }
}