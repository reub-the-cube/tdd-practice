namespace AoC._2024.day02.v1
{
    public static class ReactorReportFeed
    {
        public static int CountNumberOfSafeReports(IEnumerable<string> reports)
        {
            var reportInputs = reports
                .Select(r => r.Split(" ", StringSplitOptions.RemoveEmptyEntries))
                .Select(r => new ReactorReport([.. r]));

            return reportInputs.Count(r => r.IsSafe());
        }
    }
}
