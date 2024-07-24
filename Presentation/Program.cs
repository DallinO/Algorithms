using AlgorithmLib;

public class Program
{
    public static void Main(string[] args)
    {
        List<int> bestCaseData = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        List<int> worstCaseData = new List<int> { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
        List<int> averageCaseData = new List<int> { 7, 2, 9, 4, 1, 5, 8, 3, 6, 10 };

        Console.WriteLine("Before Sorting:");
        PrintList(bestCaseData, "Best Case");
        PrintList(worstCaseData, "Worst Case");
        PrintList(averageCaseData, "Average Case");

        QuickSort.Sort(bestCaseData);
        QuickSort.Sort(worstCaseData);
        QuickSort.Sort(averageCaseData);

        Console.WriteLine("\nAfter Sorting:");
        PrintList(bestCaseData, "Best Case");
        PrintList(worstCaseData, "Worst Case");
        PrintList(averageCaseData, "Average Case");
    }

    static void PrintList<T>(List<T> list, string caseType)
    {
        Console.WriteLine($"{caseType}: {string.Join(", ", list)}");
    }
}