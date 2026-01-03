using System.Runtime.InteropServices;
using System.Text;

namespace PracticeSolution.ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        string name = "Amit";
        int num = 5;

        StringBuilder sb = new StringBuilder();
        sb.Append("Hello");
        sb.Append("World");
        Console.WriteLine(sb);

        string result = sb.ToString();
        Console.WriteLine(result);
        Console.WriteLine(result.Length);

        foreach (char ch in result)
        {
            Console.WriteLine(ch);
        }

        List<string> countries = new List<string>();
        countries.Add("India");
        countries.Add("USA");
        countries.Add("China");
        
        countries.AddRange(new List<string>(){"UK", "Canada"});
        foreach (string country in countries)
        {
            Console.WriteLine(country);
        }
        
        Console.WriteLine($"Total elements in list: {countries.Count}");
        Console.WriteLine($"Does countries contain Brazil? {countries.Contains("Brazil")}");
        Console.WriteLine($"Does countries contain India? {countries.Contains("India")}");

        string? findChina = countries.Find(x => x == "China");
        string? findIsrael = countries.Find(x => x == "Israel");
        Console.WriteLine(findChina);
        Console.WriteLine(findIsrael);
        
        // ----------- Inner Exception Demo ------------
        DemoInnerException.Method1();
    }
}