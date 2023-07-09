using System;

// Read it pairwise

class Day4
{

    public static void Part1()
    {   
        // Read the file linewise
        string filePath = "src/advent/Models/input4.txt";
        
        using  (StreamReader reader = new StreamReader(filePath))
        {
            // Number of containing
            int numbers = 0;
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                // Split 
                string[] sacks = line.Split(",");
                // Get the range of numbers
                List<int> line1 = ConvertRangeToList(sacks[0]);
                List<int> line2 = ConvertRangeToList(sacks[1]);
                // Compare if all elements of one are contained in the other
                bool isContained1 = line1.All(line2.Contains);
                bool isContained2 = line2.All(line1.Contains);
                if (isContained1 || isContained2)
                {
                    numbers = numbers + 1;
                }
            }
            Console.WriteLine(numbers);
        }
    }
    public static void Part2()
    {   
        // Read the file linewise
        string filePath = "src/advent/Models/input4.txt";
        
        using  (StreamReader reader = new StreamReader(filePath))
        {
            // Number of overlaps
            int numbers = 0;
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                // Split 
                string[] sacks = line.Split(",");
                // Get the range of numbers
                List<int> line1 = ConvertRangeToList(sacks[0]);
                List<int> line2 = ConvertRangeToList(sacks[1]);
                // Go through all elements of list 1
                foreach (int l in line1)
                {
                    bool isContainedSingle = line2.Contains(l);
                    if (isContainedSingle)
                    {
                        numbers = numbers + 1;
                        break;
                    }
                }
            }
            Console.WriteLine(numbers);
        }
    }
    public static List<int> ConvertRangeToList(string input)
    {
        // First get the limiting intervals
        string[] parts = input.Split("-");
        int startNumber = int.Parse(parts[0]);
        int endNumber = int.Parse(parts[1]);
        // Generate the list
        List<int> list_integers = new List<int>();
        for (int i = startNumber; i <= endNumber; i++)
        {
            list_integers.Add(i);
        }
        return list_integers;
    }
}