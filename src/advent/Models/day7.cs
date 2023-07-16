/*
Main Challenge:
- How to keep track in which directory hierarchy we are?

Idea:
- Save the commands and the lines associated with it:
commands = {line1: cd /, line2: ls, ...}

Brainstorm:
- File sizes always appear after a ls command -> thus one can easily calculate the 
*/

using System;
using System.Runtime.CompilerServices;
using System.Text;

class Day7
{
    // Read the file and split between between commands and results from commands
    public static (Dictionary<string, string>, Dictionary<string, string>) ReadFile(string filePath = "src/advent/Models/input7_test.txt")
    {
        Dictionary<string, string> list_commands = new();
        Dictionary<string, string> list_results = new();
        using (StreamReader reader = new(filePath))
        {
            int lineNumber = 0;
            string line;
            while ((line = reader.ReadLine()) != null)
            {           
                lineNumber++;
                if (line.StartsWith("$"))
                {
                    list_commands[$"line_{lineNumber}"] = line;
                }
                else
                {
                    list_results[$"line_{lineNumber}"] = line;
                }
            }
        }
        return (list_commands, list_results);
    }
    // Method that calculates the total size of one ls operation
}
