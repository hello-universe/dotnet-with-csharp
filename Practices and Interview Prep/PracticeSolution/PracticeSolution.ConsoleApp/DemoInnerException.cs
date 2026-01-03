namespace PracticeSolution.ConsoleApp;

public class DemoInnerException
{
    public static void Method1()
    {
        try
        {
            try
            {
                throw new DivideByZeroException();
            }
            catch (DivideByZeroException dbze)
            {
                Console.WriteLine(dbze.Message);
                throw new Exception("Outer try block exception", dbze);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            // Console.WriteLine(e?.InnerException.Message);
            if (e.InnerException != null)
            {
                Console.WriteLine(e.InnerException.Message);
            }
        }
    }
}