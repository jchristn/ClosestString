using System;
using System.Collections.Generic;

namespace FindClosestString
{
    /// <summary>
    /// A static class useful for finding the string closest to a supplied value in a list of strings.
    /// </summary>
    public static class ClosestString
    {
        #region Public-Members

        #endregion

        #region Private-Members

        #endregion

        #region Public-Methods

        /// <summary>
        /// Find the closest string using Levenshtein distance (Wagner-Fischer algorithm).
        /// </summary>
        /// <param name="str">String.</param>
        /// <param name="vals">List of valid strings.</param>
        /// <returns>Tuple containing the closest matching string and its edit distance.</returns>
        public static (string, int) UsingLevenshtein(string str, List<string> vals)
        {
            if (String.IsNullOrEmpty(str)) throw new ArgumentNullException(nameof(str));
            if (vals == null) throw new ArgumentNullException(nameof(vals));
            if (vals.Count < 1) throw new ArgumentException("List of values must contain at least one entry.");

            if (vals.Contains(str)) return (str, 0);
            else
            {
                string closest = null;
                int minDistance = int.MaxValue;

                foreach (string s in vals)
                {
                    int distance = LevenshteinDistance(str, s);
                    if (distance < minDistance)
                    {
                        closest = s;
                        minDistance = distance;
                    }
                }

                return (closest, minDistance);
            }
        }

        #endregion

        #region Private-Methods

        private static int LevenshteinDistance(string s1, string s2)
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

        #endregion
    }
}