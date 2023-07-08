using System.Collections.Generic;
using System.IO;
using System.Linq;

static class FileOperations
{
    public static List<int> ReadBlockSumsFromFile(string filePath)
    {
        List<int> blockSums = new List<int>();
        
        using (StreamReader reader = new StreamReader(filePath))
        {
            int currentBlockSum = 0;
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    if (currentBlockSum > 0)
                    {
                        blockSums.Add(currentBlockSum);
                        currentBlockSum = 0;
                    }
                }
                else
                {
                    if (int.TryParse(line, out int number))
                    {
                        currentBlockSum += number;
                    }
                    else
                    {
                        Console.WriteLine("Invalid number: " + line);
                        // You can choose to handle the invalid number error as needed
                    }
                }
            }

            if (currentBlockSum > 0)
            {
                blockSums.Add(currentBlockSum);
            }
        }

        return blockSums;
    }
    public static void ShowLargestNumber(List<int> blockSums)
    {
        if (blockSums.Count > 0)
        {
            int largestNumber = blockSums[0];
            for (int i = 1; i < blockSums.Count; i++)
            {
                if (blockSums[i] > largestNumber)
                {
                    largestNumber = blockSums[i];
                }
            }

            Console.WriteLine("Largest number: " + largestNumber);
        }
        else
        {
            Console.WriteLine("No block sums found.");
        }
    }

    public static void ShowThreeLargestNumbers(List<int> blockSums)
    {
        if (blockSums.Count > 0)
        {
            var largestNumbers = blockSums.OrderByDescending(x => x).Take(3).ToList();
            Console.WriteLine("Three largest numbers:");
            foreach (int number in largestNumbers)
            {
                Console.WriteLine(number);
            }
        }
        else
        {
            Console.WriteLine("No block sums found.");
        }
    }
}

class Day1
{
    public static void runDay1()
    {
        string filePath = "src/advent/Models/input1.txt"; // Replace with the actual file path
        var blockSums = FileOperations.ReadBlockSumsFromFile(filePath);
        FileOperations.ShowLargestNumber(blockSums);
        FileOperations.ShowThreeLargestNumbers(blockSums);
        }
}