namespace SingletonDesignPattern;

// ------------ Lazy Singleton ----------------
public sealed class LazySingleton
{
    private static LazySingleton _instance = null;
    private static int _counter = 0;

    private LazySingleton()
    {
        ++_counter;
        Console.WriteLine($"Number of objects created: {_counter}");
    }

    public static LazySingleton GetInstance()
    {
        if (_instance == null)
        {
            _instance = new LazySingleton();
        }

        return _instance;
    }
}