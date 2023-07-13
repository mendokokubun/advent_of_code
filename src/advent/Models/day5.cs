// We will consider each crate as a list of letters and each operation will append a letter

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;

class Day5
{
    public static Dictionary<int, List<string>> InitialData()
    {
        Dictionary<int, List<string>> InitialData = new();
        
        List<string> stack1 = new List<string> {"N","B","D","T","V","G","Z","J"};
        List<string> stack2 = new List<string> {"S","R","M","D","W","P","F"};
        List<string> stack3 = new List<string> {"V","C","R","S","Z"};
        List<string> stack4 = new List<string> {"R","T","J","Z","P","H","G"};
        List<string> stack5 = new List<string> {"T","C","J","N","D","Z","Q","F"};
        List<string> stack6 = new List<string> {"N","V","P","W","G","S","F","M"};
        List<string> stack7 = new List<string> {"G","C","V","B","P","Q"};
        List<string> stack8 = new List<string> {"Z","B","P","N"};
        List<string> stack9 = new List<string> {"W","P","J"};

        InitialData.Add(1, stack1);
        InitialData.Add(2, stack2);
        InitialData.Add(3, stack3);
        InitialData.Add(4, stack4);
        InitialData.Add(5, stack5);
        InitialData.Add(6, stack6);
        InitialData.Add(7, stack7);
        InitialData.Add(8, stack8);
        InitialData.Add(9, stack9);

        return InitialData;
    }
    // Read the instructions
    public static List<string> InstructionsReader(string filePath="src/advent/Models/input5.txt") {

        List<string> ListInstructions = new();

        using (StreamReader reader = new(filePath))
        {
            // Skip the first 10 lines
            for (int i=0; i<10; i++)
            {
                reader.ReadLine();
            }

            string line;

            while ((line = reader.ReadLine()) != null)
            {           
                ListInstructions.Add(line);
            }
        }
        return ListInstructions;
    }
    // Get the numbers from a string
    public static List<int> GetNumbersFromInstruction(string line)
    {
        List<int> numbers = new();
        // Regex to get numbers
        MatchCollection matches = Regex.Matches(line, @"\d+");

        foreach (Match match in matches)
        {
            if (int.TryParse(match.Value, out int number))
            {
                numbers.Add(number);
            }
        }
        return numbers;
    } 
    public static void Part1(List<string> ListInstructions, Dictionary<int, List<string>> initialData)
    {
    // Get numbers from instructions
        foreach (string l in ListInstructions)
        {
            List<int> NumbersFromInstr = Day5.GetNumbersFromInstruction(l);
            /* 
            Perform actions:
            1) Take last value of a list and then remove it with RemoveAt(list.Count - 1) 
            2) Append it with list_new.Add(element)
            3) Update elements of dictionary
            */
            int quantity = NumbersFromInstr[0];
            List<string> to_remove = initialData[NumbersFromInstr[1]];
            List<string> to_add = initialData[NumbersFromInstr[2]];

            for (int i=0; i<quantity; i++)
            {
                // 1)
                string r = to_remove[^1];
                to_remove.RemoveAt(to_remove.Count-1);
                // 2)
                to_add.Add(r);
            }
            // 3)
            initialData[NumbersFromInstr[1]] = to_remove;
            initialData[NumbersFromInstr[2]] = to_add;
        }
        // print the top values
        foreach (KeyValuePair<int, List<string>> kvp in initialData)
        {
            string topElement = kvp.Value[^1];
            Console.WriteLine($"Stack: {kvp.Key}. Top: {topElement}");
        }
    }
    public static void Part2(List<string> ListInstructions, Dictionary<int, List<string>> initialData)
    {
        foreach (string l in ListInstructions)
        {
            // Get only the numbers from the instructions
            List<int> NumbersFromInstr = Day5.GetNumbersFromInstruction(l);
            /* 
            Perform actions:
            1) Take the last 'N' values from a list and remove them with RemoveAt(i) for i from smaller to larger
            2) Append it with list_new.Add(i) for i from smaller to larger
            3) Update elements of dictionary
            */
            int quantity = NumbersFromInstr[0];
            List<string> to_remove = initialData[NumbersFromInstr[1]];
            List<string> to_add = initialData[NumbersFromInstr[2]];

            // Get the elements to be removed
            List<string> to_be_moved = to_remove.GetRange(to_remove.Count-quantity, quantity);
            // Remove them from to_remove
            to_remove.RemoveRange(to_remove.Count-quantity, quantity);
            // Append them at the end
            to_add.AddRange(to_be_moved);

            initialData[NumbersFromInstr[1]] = to_remove;
            initialData[NumbersFromInstr[2]] = to_add;
        }
        // print the top values
        foreach (KeyValuePair<int, List<string>> kvp in initialData)
        {
            string topElement = kvp.Value[^1];
            Console.WriteLine($"Stack: {kvp.Key}. Top: {topElement}");
        }
    }
}
