namespace AoC._2024.day02.v1
{
    public static class ProblemDampener
    {
        public static List<List<T>> GetConfigurations<T>(List<T> fullReport, int toleranceLevel)
        {
            List<List<T>> configurations = [];
            if (toleranceLevel == 1)
            {
                for (int i = 0; i < fullReport.Count; i++)
                {
                    var thisConfiguration = fullReport.ToList();
                    thisConfiguration.RemoveAt(i);
                    configurations.Add(thisConfiguration);
                }
            }
            else
            {
                configurations.Add(fullReport);
            }
            
            return configurations;
        }
    }
}
