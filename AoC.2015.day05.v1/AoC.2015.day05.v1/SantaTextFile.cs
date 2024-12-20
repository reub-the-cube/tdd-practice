namespace AoC._2015.day05.v1;

public static class SantaTextFile
{
    public static int NumberOfNiceStringsForPartOne(IEnumerable<string> list)
    {
        var stringChecker = new SantaStringCheckerPartOne();
        return list.Count(stringChecker.IsNice);
    }

    public static int NumberOfNiceStringsForPartTwo(IEnumerable<string> list)
    {
        var stringChecker = new SantaStringCheckerPartTwo();
        return list.Count(stringChecker.IsNice);
    }
}