using System;

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

class Program
{
    static void Main()
    {
        Day2.runDay2Part2();
    }    
}
