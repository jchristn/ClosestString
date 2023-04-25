using System;
using System.Collections.Generic;
using System.Text;

namespace FindClosestString
{
    /// <summary>
    /// Implementation of the Wagner-Fischer (Levenshtein) edit distance algorithm.
    /// </summary>
    public static class Levenshtein
    {
        /// <summary>
        /// Calculate the Levenshtein distance between two strings.
        /// </summary>
        /// <param name="s1">String 1.</param>
        /// <param name="s2">String 2.</param>
        /// <returns>Levenshtein distance, an integer.</returns>
        public static int Distance(string s1, string s2)
        {
            int[,] distances = new int[s1.Length + 1, s2.Length + 1];

            for (int i = 0; i <= s1.Length; i++)
                distances[i, 0] = i;

            for (int j = 0; j <= s2.Length; j++)
                distances[0, j] = j;

            for (int j = 1; j <= s2.Length; j++)
            {
                for (int i = 1; i <= s1.Length; i++)
                {
                    int cost = (s1[i - 1] == s2[j - 1]) ? 0 : 1;
                    int insertCost = distances[i, j - 1] + 1;
                    int deleteCost = distances[i - 1, j] + 1;
                    int replaceCost = distances[i - 1, j - 1] + cost;
                    distances[i, j] = Math.Min(Math.Min(insertCost, deleteCost), replaceCost);
                }
            }

            return distances[s1.Length, s2.Length];
        }
    }
}
