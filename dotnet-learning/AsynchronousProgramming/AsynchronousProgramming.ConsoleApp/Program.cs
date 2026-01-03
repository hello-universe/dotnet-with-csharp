namespace AsynchronousProgramming.ConsoleApp;

class Program
{
    static void SomeMethod(Object stateInfo)
    {
        Console.WriteLine("Some method is executed");
    }
    static void Main(string[] args)
    {
        ThreadPool.QueueUserWorkItem(SomeMethod);
        Console.WriteLine("Main thread does some work and then sleeps");
        // Thread.Sleep(3000);
        Console.WriteLine("Main thread exits");
    }
}