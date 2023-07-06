using System;

class Dictionaries
{
    public Dictionary<string,string> dictWins;
    public Dictionary<string,string> dictLoss;
    public Dictionary<string,string> dictDraw;

    public Dictionary<string,int> dictChoice;
    public Dictionary<string,int> dictResult;

    public Dictionaries()
    {
        dictWins = initializeDictWins();
        dictLoss = initializeDictLoss();
        dictDraw = initializeDictDraw();
        dictChoice = initializeDictChoice();
        dictResult = initializeDictResult();
    }


    private Dictionary<string,string> initializeDictWins()
    {
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        dictionary["A"] = "Y";
        dictionary["B"] = "Z";
        dictionary["C"] = "X";
        return dictionary;
    }
    private Dictionary<string,string> initializeDictLoss()
    {
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        dictionary["A"] = "Z";
        dictionary["B"] = "X";
        dictionary["C"] = "Y";
        return dictionary;
    }
    private Dictionary<string,string> initializeDictDraw()
    {
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        dictionary["A"] = "X";
        dictionary["B"] = "Y";
        dictionary["C"] = "Z";
        return dictionary;
    }
    private Dictionary<string,int> initializeDictChoice()
    {
        Dictionary<string, int> dictionary = new Dictionary<string, int>();
        dictionary["X"] = 1;
        dictionary["Y"] = 2;
        dictionary["Z"] = 3;
        return dictionary;
    }
    private Dictionary<string,int> initializeDictResult()
    {
        Dictionary<string, int> dictionary = new Dictionary<string, int>();
        dictionary["L"] = 0;
        dictionary["D"] = 3;
        dictionary["W"] = 6;
        return dictionary;
    }
}

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