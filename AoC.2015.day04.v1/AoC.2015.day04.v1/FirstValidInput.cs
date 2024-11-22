namespace Aoc._2015.day04.v1;

public class FirstValidInput
{
    public string? ForSecret(string secret)
    {
        var hasher = new Hasher(secret);

        hasher.IterateOnSecret();

        return hasher.LastHashedString;
    }
}