using System.Linq;

namespace DeclarativeVsImperative
{
    public static class StringExtensions
    {
        public static bool IsAnagramOf(this string s1, string s2) =>
            s1.ToLower().OrderBy(c => c).SequenceEqual(s2.ToLower().OrderBy(c => c));
    }
}
