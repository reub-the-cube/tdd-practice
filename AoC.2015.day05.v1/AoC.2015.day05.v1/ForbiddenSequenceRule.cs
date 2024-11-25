namespace AoC._2015.day05.v1;

public class ForbiddenSequenceRule : StringRule
{
    public override bool IsNice(string initialValue)
    {
        List<string> forbiddenSequences = ["ab", "cd", "pq", "xy"];
        if (forbiddenSequences.Any(initialValue.Contains)) {
            return false;
        }
        
        return true;
    }
}