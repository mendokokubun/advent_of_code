using System;


static class FileReader
{
    public static List<string> ReadLinesFile(string FilePath)
    {
        List<string> lines = new List<string>();
        lines = File.ReadAllLines(FilePath).ToList();

        return lines;
    }
}

static class StringMethods
{
    // This method is used in Part 1: splitting a string in two parts
    public static List<(string,string)> SplitInTwo(List<string> lines)
    {
        List<(string,string)> to_return = new List<(string,string)>();

        foreach (string line in lines)
        {
            int halfLength = line.Length / 2;
            string first_half = line.Substring(0, halfLength);
            string second_half = line.Substring(halfLength);
            // Sanity check
            if (first_half.Length != second_half.Length)
            {
                throw new Exception("Lengths should be equal");
            }
            else
            {
                to_return.Add((first_half,second_half));
            }
        }
        return to_return;
    }
    // Method to find the common character between two strings
    public static List<string> FindCommon(List<(string,string)> lines)
    {
        List<string> commonChars = new List<string>();
        foreach ((string,string) l in lines)
        {
            foreach (char c1 in l.Item1)
            {
                if (l.Item2.Contains(c1))
                {
                    commonChars.Add(c1.ToString());
                    break; // We need to break the loop because there might be more matches, but we only care about one!
                 }
            }
        }
        return commonChars;
    }
    // Method to get the priorities. Used in both parts
    public static int CalculatePriorities(List<string> commons)
    {
        int total = 0;
        foreach (string c in commons)
        {
            int p = System.Convert.ToInt32(c[0]);
            int to_add = 0;
            // If lower case, it is larger than 90
            if (p > 90)
            {
                to_add = p-96;
                total += to_add;
            }
            else if (p < 95)
            {
                to_add = p-38;
                total += to_add;
            }
            else
            {
                throw new Exception("CHAOS");
            }
        }
        return total;
    }
}

class Day3
{
    public static void Part1()
    {
        string filePath = "src/advent/Models/input3.txt"; 

        // Read the file
        List<string> linesFile = FileReader.ReadLinesFile(filePath);

        // Split the strings in two parts
        List<(string,string)> spliitedLines = StringMethods.SplitInTwo(linesFile);

        // Find the common character
        List<string> commonChars = StringMethods.FindCommon(spliitedLines);

        // Calculate priorities
        int total = StringMethods.CalculatePriorities(commonChars);

        Console.WriteLine($"Sum of priorities: {total}");
    }
    public static void Part2()
    {
        string filePath = "src/advent/Models/input3.txt"; 
        
        // Read the file, three lines at once and store the commond
        using  (StreamReader reader = new StreamReader(filePath))
        {
            List<string> commonChars = new List<string>();
            while (!reader.EndOfStream)
            {
                string line1 = reader.ReadLine();
                string line2 = reader.ReadLine();
                string line3 = reader.ReadLine();
                
                // Loop through all chars of line1
                foreach (char c in line1)
                {
                    if (line2.Contains(c) && line3.Contains(c))
                    {
                        commonChars.Add(c.ToString());
                        break; // Again, we break to prevent repeating letters
                    }
                }
            }
            // calculate priorities
            int total = StringMethods.CalculatePriorities(commonChars);
            Console.WriteLine($"Total: {total}");
        }
    }
}
