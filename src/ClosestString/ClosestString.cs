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
        /// <returns>Tuple containing the closest matching string and its edit distance from the original string.</returns>
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
                    int distance = Levenshtein.Distance(str, s);
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

        #endregion
    }
}