using System;


static class ReadFile
{
    public static List<(char, char)> ReadLinesWithChars(string filePath)
    {
        List<(char, char)> linesWithChars = new List<(char, char)>();

        try
        {
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] characters = line.Split(' ');

                if (characters.Length == 2 && characters[0].Length == 1 && characters[1].Length == 1)
                {
                    char firstChar = characters[0][0];
                    char secondChar = characters[1][0];

                    linesWithChars.Add((firstChar, secondChar));
                }
                else
                {
                    Console.WriteLine($"Invalid line format: {line}");
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error reading file: {e.Message}");
        }

        return linesWithChars;
    }
}