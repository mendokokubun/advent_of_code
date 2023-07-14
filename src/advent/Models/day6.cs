using System;
using System.ComponentModel;
using System.Reflection.PortableExecutable;
using System.Text;

/*
Either:
- read the full string and after do a pass for it;
- read it character by character and keep the last four -> probably faster
*/

// Test: 

class Day6
{
    // Reader
    public static void BothParts(string part, string filePath="src/advent/Models/input6.txt")
    {
        StringBuilder stringBuilder = new();
        using (StreamReader reader = new(filePath))
        {
            int character;
            while((character = reader.Read()) != -1)
            {
                char c = (char)character;
                stringBuilder.Append(c);

                int digits_to_check;

                if (part == "Part1")
                {
                    digits_to_check = 4;
                }
                else if (part == "Part2")
                {
                    digits_to_check = 14;
                }
                else 
                {
                    throw new Exception("Uaaarrrrggg");
                }

                if (stringBuilder.Length >= digits_to_check)
                {
                    // Convert to string and get the last four
                    string last_four = stringBuilder.ToString().Substring(stringBuilder.Length - digits_to_check);
                    // Check if all are disticnt
                    bool distinct = last_four.Distinct().Count() == digits_to_check;

                    if (distinct)
                    {
                        // which is the last digit?
                        Console.WriteLine($"Digits processed: {stringBuilder.Length}");
                        break;
                    }
                }
            }
        }

    }
}
