namespace AoC._2015.day05.v1;

public static class SantaTextFile
{
    public static int NumberOfNiceStrings(IEnumerable<string> list)
    {
        var stringChecker = new SantaStringChecker();
        return list.Count(stringChecker.IsNice);
    }
}