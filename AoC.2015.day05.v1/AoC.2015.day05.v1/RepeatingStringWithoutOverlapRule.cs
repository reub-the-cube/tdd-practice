namespace AoC._2015.day05.v1
{
    public class RepeatingStringWithoutOverlapRule : StringRule
    {
        public override bool IsNice(string initialInput)
        {
            if (initialInput == string.Empty)
            {
                return false;
            }

            var stringPairs = Splitter.GetAllSubstrings(initialInput, 2);
            if (stringPairs.Any(pair => initialInput.Split(pair).Length > 2))
            {
                return true;
            }

            return false;
        }
    }
}
