namespace AoC._2015.day05.v1;

public class ThreeVowelsRule
{
    public bool IsNice(string initialValue)
    {
        if (initialValue.Where("aeiou".Contains).Count() > 2)
        {
            return true;
        }

        return false;
    }
}