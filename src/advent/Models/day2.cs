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

class Day2
{
    public static void runDay2Part1()
    {   
        int score = 0;
        string FilePath = "src/advent/Models/input2.txt";
        var listChars = ReadFile.ReadLinesWithChars(FilePath);
        foreach ((char,char) line in listChars)
        {
            // We use the unicode converter
            int opponent = System.Convert.ToInt32(line.Item1);
            int mine = System.Convert.ToInt32(line.Item2);

            // Rock
            if (mine == 88)
            {
                score += 1;
                // Draw
                if (mine == opponent + 23)
                {
                    score += 3;
                }
                // Win
                else if (mine == opponent + 21)
                {
                    score += 6;
                }
                // Loss
                else if (mine == opponent + 22)
                {
                    score += 0;
                }
                else
                {
                    Console.WriteLine("WRONG!");
                }

            }
            // Paper
            else if (mine == 89)
            {
                score += 2;
                // Draw
                if (mine == opponent + 23)
                {
                    score += 3;
                }
                // Win
                else if (mine == opponent + 24)
                {
                    score += 6;
                }
                // Loss
                else if (mine == opponent + 22)
                {
                    score += 0;
                }
                else
                {
                    Console.WriteLine("WRONG!");
                }
            }
            // Scissor
            else if (mine == 90)
            {
                score += 3;
                // Draw
                if (mine == opponent + 23)
                {
                    score += 3;
                }
                // Win
                else if (mine == opponent + 24)
                {
                    score += 6;
                }
                // Loss
                else if (mine == opponent + 25)
                {
                    score += 0;
                }
                else
                {
                    Console.WriteLine("WRONG!");
                }
            }
            else
            {
                Console.WriteLine("Wrong dur");
            }
        }
        Console.WriteLine($"Final score: {score}");
    }
    public static void runDay2Part2()
    {   
        int score = 0;
        string FilePath = "src/advent/Models/input2.txt";
        var listChars = ReadFile.ReadLinesWithChars(FilePath);
        foreach ((char,char) line in listChars)
        {
            // We use the unicode converter
            int opponent = System.Convert.ToInt32(line.Item1);
            int mine = System.Convert.ToInt32(line.Item2);

            // Loose
            if (mine == 88)
            {
                score += 0;
                // Rock
                if (opponent == 65)
                {
                    score += 3;
                }
                // Paper
                else if (opponent == 66)
                {
                    score += 1;
                }
                // Scissor
                else if (opponent == 67)
                {
                    score += 2;
                }
                else
                {
                    Console.WriteLine("WRONG!");
                }

            }
            // Draw
            else if (mine == 89)
            {
                score += 3;
                // Rock
                if (opponent == 65)
                {
                    score += 1;
                }
                // Paper
                else if (opponent == 66)
                {
                    score += 2;
                }
                // Scissor
                else if (opponent == 67)
                {
                    score += 3;
                }
                else
                {
                    Console.WriteLine("WRONG!");
                }

            }
            // Win
            else if (mine == 90)
            {
                score += 6;
                // Rock
                if (opponent == 65)
                {
                    score += 2;
                }
                // Paper
                else if (opponent == 66)
                {
                    score += 3;
                }
                // Scissor
                else if (opponent == 67)
                {
                    score += 1;
                }
                else
                {
                    Console.WriteLine("WRONG!");
                }

            }
            else
            {
                Console.WriteLine("Wrong dur");
            }
        }
        Console.WriteLine($"Final score part 2: {score}");
    }
}