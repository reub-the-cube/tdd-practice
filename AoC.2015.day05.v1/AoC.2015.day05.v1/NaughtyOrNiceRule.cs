namespace AoC._2015.day05.v1;

public class NaughtyOrNiceRule
{
    public bool IsNice(string initialInput)
    {
        List<string> mustContain = ["aa", "bb"];
        if (mustContain.Any(initialInput.Contains))
        {
            return true;
        }

        return false;
    }
}