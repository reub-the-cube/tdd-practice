using System.Text.RegularExpressions;

namespace Aoc._2015.day04.v1;

public class FirstValidInput(string pattern)
{
    private readonly Regex Pattern = new (pattern, RegexOptions.IgnoreCase);
    private Hasher Hasher;

    public string? ForSecret(string secret)
    {
        Hasher = new Hasher(secret);

        return GetFirstMatch();
    }

    private string? GetFirstMatch()
    {
        var isMatch = false;
        var i = 0;

        while (!isMatch && i < 10000000)
        {
            var hashedValue = Hasher.IterateOnSecret();
            isMatch = Pattern.IsMatch(hashedValue);
            i++;
        }

        return Hasher.LastHashedString;
    }
}