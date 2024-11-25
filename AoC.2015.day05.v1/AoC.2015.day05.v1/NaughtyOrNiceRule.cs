namespace AoC._2015.day05.v1;

public class NaughtyOrNiceRule
{
    public bool IsNice(string initialInput)
    {
        if (ContainsDoubleLetter(initialInput))
        {
            return true;
        }

        return false;
    }

    private static bool ContainsDoubleLetter(string initialInput)
    {
        List<string> mustContain = ["aa", "bb", "cc", "dd", "ee", "ff", "gg", "hh", "ii", "jj", "kk", "ll", "mm",
            "nn", "oo", "pp", "qq", "rr", "ss", "tt", "uu", "vv", "ww", "xx", "yy", "zz"];
        
        return mustContain.Any(initialInput.Contains);
    }
}