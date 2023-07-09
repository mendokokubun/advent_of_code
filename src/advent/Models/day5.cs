// We will consider each crate as a list of letters and each operation will append a letter

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Day5
{
    public static Dictionary<int, List<string>> InitialData()
    {
        Dictionary<int, List<string>> InitialData = new Dictionary<int, List<string>>();
        
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

        List<string> ListInstructions = new List<string>();

        using (StreamReader reader = new StreamReader(filePath))
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
        List<int> numbers = new List<int>();
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
}
