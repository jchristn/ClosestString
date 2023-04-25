using System;
using System.Collections.Generic;
using System.Linq;

namespace FindClosestString
{
    /// <summary>
    /// A static class useful for finding the strings closest to a supplied value in a list of strings.
    /// </summary>
    public static class ClosestStrings
    {
        #region Public-Members

        #endregion

        #region Private-Members

        #endregion

        #region Public-Methods

        /// <summary>
        /// Find the closest strings using Levenshtein distance (Wagner-Fischer algorithm).
        /// </summary>
        /// <param name="str">String.</param>
        /// <param name="vals">List of valid strings.</param>
        /// <returns>List of tuples containing the closest matching strings and their edit distance from the original string.</returns>
        public static List<(string, int)> UsingLevenshtein(string str, List<string> vals, int maxMatches = 10)
        {
            if (String.IsNullOrEmpty(str)) throw new ArgumentNullException(nameof(str));
            if (vals == null) throw new ArgumentNullException(nameof(vals));
            if (vals.Count < 1) throw new ArgumentException("List of values must contain at least one entry.");
            if (maxMatches <= 0) throw new ArgumentOutOfRangeException(nameof(maxMatches));

            List<(string, int)> all = new List<(string, int)>();
            List<(string, int)> matches = new List<(string, int)>();

            foreach (string s in vals)
            {
                int distance = Levenshtein.Distance(str, s);
                all.Add((s, distance));
            }

            if (all.Count > 0)
            {
                all = all.OrderBy(i => i.Item2).ToList();
                matches = all.Take(maxMatches).ToList();
            }

            return matches;
        }

        #endregion

        #region Private-Methods

        #endregion
    }
}