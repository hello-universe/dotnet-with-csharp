namespace InterviewPrep.ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        IEnumerable<int> ienum = new List<int>() { 5, 3, 6, 2, 1 };
        foreach (int num in ienum)
        {
            Console.WriteLine(num);
        }
        // Console.WriteLine(ienum[1]); // Will give error because IEnumerable doesn't support indexed access
        ICollection<int> icoll = new List<int>(){5, 3, 9, 2, 4};
        IList<int> ilist = new List<int>() { 9, 4, 7, 2, 1 };
        List<int> list = new List<int>() { 8, 3, 7, 9, 2 };
    }
}