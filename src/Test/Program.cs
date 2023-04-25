using System;
using System.Collections.Generic;
using FindClosestString;
using GetSomeInput;

namespace Test
{
    public static class Program
    {
        private static List<string> _Values = new List<string>
        {
            "the quick brown fox",
            "jumped over the lazy dog",
            "mary had a little lamb",
            "twinkle twinkle little star",
            "la vaca lola tiene cola",
            "yo tengo tio y se llama mario",
            "cuidado la bomba chita",
            "old macdonald had a farm",
            "and on this farm he had a cow",
            "three blind mice",
            "never gonna give you up",
            "never gonna let you down",
            "never gonna run around",
            "and hurt you",
            "i would do anything for love",
            "but i won't do that",
            "don't call me daughter",
            "jeremy spoke in class today",
            "i have found some temporary sanity in this",
            "if you choose to pull the trigger",
            "should your drama prove sincere",
            "do it somewhere far away from here"
        };

        public static void Main(string[] args)
        {
            while (true)
            {
                string val = Inputty.GetString("Value   :", null, false);
                (string, int) ret = ClosestString.UsingLevenshtein(val, _Values);
                List<(string, int)> matches = ClosestStrings.UsingLevenshtein(val, _Values, 10);
                
                Console.WriteLine("Closest : " + ret.Item1 + " [distance: " + ret.Item2 + "]");
                
                Console.WriteLine("All     :");
                foreach ((string, int) match in matches)
                {
                    Console.WriteLine("  " + match.Item2 + ": " + match.Item1);
                }

                Console.WriteLine("");
            }
        }
    }
}