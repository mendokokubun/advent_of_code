using System;

class Program
{
    static void Main()
    {
        Day5 MyClass = new Day5();
        // Get the initial data
        Dictionary<int, List<string>> initialData = Day5.InitialData();
        
        // Get instructions
        List<string> ListInstructions = Day5.InstructionsReader();

        // Part 2
        Day5.Part2(ListInstructions, initialData);
    }
}
