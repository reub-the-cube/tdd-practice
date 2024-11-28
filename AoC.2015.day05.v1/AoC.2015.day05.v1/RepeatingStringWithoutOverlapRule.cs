namespace AoC._2015.day05.v1
{
    public class RepeatingStringWithoutOverlapRule : StringRule
    {
        public override bool IsNice(string initialInput)
        {
            var stringPairs = Splitter.GetAllSubstrings(initialInput, 2);
            var anyStringPairAppearsMoreThanOnce = stringPairs.Any(pair => initialInput.Split(pair).Length > 2);
            return anyStringPairAppearsMoreThanOnce;
        }
    }
}
