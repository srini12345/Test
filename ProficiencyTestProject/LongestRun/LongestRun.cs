using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace LongestRun
{
    public class Run
    {
        /// <summary>
        /// Returns the Index of Longest Repeated char in a string
        /// </summary>
        /// <param name="str">input String</param>
        /// <returns>Index postin in Integer</returns>
        public static int IndexOfLongestRun(string str)
        {

            string pattern = @"(\w)\1+"; /* \w   Any word character 
                                          * \1+  Match the value of the first capture repeatedly
                                          */
            MatchCollection matches = Regex.Matches(str, pattern);

            int longest = 0;
            int index = 0;
            string val = string.Empty;
            foreach (Match match in matches)
            {
                if (longest < match.Length)
                {
                    longest = match.Length;
                    val = match.Value;
                }
            }
            index = str.IndexOf(val);

            return index;
        }
        public static void Main(string[] args)
        {
            Console.WriteLine(IndexOfLongestRun("abbcccddddcccbba"));
            Console.ReadKey();
        }
    }
}
