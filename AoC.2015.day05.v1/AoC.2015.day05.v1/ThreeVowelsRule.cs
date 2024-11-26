namespace AoC._2015.day05.v1;

public class ThreeVowelsRule : StringRule
{
    public override bool IsNice(string initialValue)
    {
        var vowelCountIsMoreThreeOrMore = initialValue.Where("aeiou".Contains).Count() > 2;
        return vowelCountIsMoreThreeOrMore;
    }
}