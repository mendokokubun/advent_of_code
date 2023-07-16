using System;

class Program
{
    static void Main()
    {
        // Part 1
        Dictionary<string, string> list_commands = new();
        Dictionary<string, string> list_results = new();
        (list_commands, list_results) = Day7.ReadFile();

        // Check the commands
        foreach (KeyValuePair<string, string> kvp in list_commands)
        {
            Console.WriteLine($"Line: {kvp.Key}. Command: {kvp.Value}");
        }  
        // Can I identify the ls commands
    }
}
