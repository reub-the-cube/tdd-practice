namespace AoC._2015.day05.v1;

public class ForbiddenSequenceRule : StringRule
{
    public override bool IsNice(string initialValue)
    {
        if (initialValue == "ab")
        {
            return false;
        }
        
        return true;
    }
}