namespace AoC._2015.day05.v1
{
    public static class Splitter
    {
        public static IEnumerable<string> GetAllSubstrings(string initialInput, int substringLength)
        {
            if (initialInput.Length < substringLength)
            {
                yield break;
            }

            for (int i = 0; i < initialInput.Length - substringLength + 1; i++)
            {
                yield return initialInput.Substring(i, substringLength);
            }
        }
    }
}
