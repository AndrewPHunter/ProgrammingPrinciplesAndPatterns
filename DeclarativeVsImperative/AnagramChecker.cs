using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarativeVsImperative
{
    public static class AnagramChecker
    {
        public static bool CheckAnagramImperative(string s1, string s2)
        {
            var first = new int[26];
            var second = new int[26];

            if (String.IsNullOrWhiteSpace(s1) || String.IsNullOrWhiteSpace(s2) || s1.Length != s2.Length)
            {
                return false;
            }

            foreach (var c in s1.ToLower().ToCharArray())
            {
                first[c - 'a']++;
            }

            foreach (var c in s2.ToLower().ToCharArray())
            {
                second[c - 'a']++;
            }

            for (var index = 0; index < 26; index++)
            {
                if (first[index] != second[index])
                {
                    return false;
                }
            }
            return true;
        }

        public static bool CheckAnagramDeclarative(string s1, string s2)
        {
            return s1.ToLower().OrderBy(c => c).SequenceEqual(s2.ToLower().OrderBy(c => c));
        }
    }
}
