using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresTraining.Extensions
{
    public static class StringExtensions
    {
        public static int FindSubstringIndex(this string haystack, string needle)
        {
            if (string.IsNullOrEmpty(haystack) || string.IsNullOrEmpty(needle)) return -1;
            if (needle.Length > haystack.Length) return -1;
            for (int i = 0; i < haystack.Length; i++)
            {
                if (haystack[i] == needle[0])
                {
                    int temp = i;
                    for (int j = 0; j < needle.Length; j++)
                    {
                        if (needle[j] != haystack[temp]) break;

                        if (j == needle.Length - 1) return i;
                        temp++;
                    }
                }
            }
            return -1;
        }
    }
}
