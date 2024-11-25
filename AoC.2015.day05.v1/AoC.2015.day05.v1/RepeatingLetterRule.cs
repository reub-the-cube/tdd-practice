namespace AoC._2015.day05.v1;

public class RepeatingLetterRule : StringRule
{
    public override bool IsNice(string initialValue)
    {
        if (ContainsDoubleLetter(initialValue))
        {
            return true;
        }

        return false;
    }

    private static bool ContainsDoubleLetter(string initialValue)
    {
        List<string> mustContain = ["aa", "bb", "cc", "dd", "ee", "ff", "gg", "hh", "ii", "jj", "kk", "ll", "mm",
            "nn", "oo", "pp", "qq", "rr", "ss", "tt", "uu", "vv", "ww", "xx", "yy", "zz"];
        
        return mustContain.Any(initialValue.Contains);
    }
}