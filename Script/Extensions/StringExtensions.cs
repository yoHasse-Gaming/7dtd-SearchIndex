using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class StringExtensions
{
    public static bool IsNullOrWhiteSpace(this string input) =>
        string.IsNullOrWhiteSpace(input);

    public static bool StartsWithIgnoreCase(this string input, string comparer) =>
        input.StartsWith(comparer, StringComparison.OrdinalIgnoreCase);
}
