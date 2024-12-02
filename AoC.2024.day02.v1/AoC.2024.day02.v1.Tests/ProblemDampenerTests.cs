using FluentAssertions;

namespace AoC._2024.day02.v1.Tests
{
    public class ProblemDampenerTests
    {
        [Fact]
        public void ZeroToleranceReturnsSameReportInput()
        {
            var initialReport = new List<string> { "3", "4" };
            var reportConfigurations = ProblemDampener.GetConfigurations(initialReport, 0);

            reportConfigurations.Should().HaveCount(1);
            reportConfigurations.Should().Contain(initialReport);
        }

        [Fact]
        public void OneLevelOfToleranceReturnsThreeConfigurationsForThreeItems()
        {
            var initialReport = new List<string> { "3", "4", "5" };
            var reportConfigurations = ProblemDampener.GetConfigurations(initialReport, 1);

            reportConfigurations.Should().HaveCount(3);
        }
    }
}
