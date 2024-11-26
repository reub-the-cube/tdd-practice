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

            var stringPairs = CreatePairs(initialInput);
            if (stringPairs.Any(pair => initialInput.Split(pair).Length > 2))
            {
                return true;
            }

            return false;
        }

        private static List<string> CreatePairs(string input)
        {
            List<string> pairs = [];

            for (int i = 0; i < input.Length - 1; i++)
            {
                pairs.Add(input.Substring(i, 2));
            }

            return pairs;
        }
    }
}
