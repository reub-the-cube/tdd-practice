using FluentAssertions;

namespace AoC._2024.day02.v1.Tests
{
    public class ReactorReportTests
    {
        [Fact]
        public void AnEmptyReportIsSafe()
        {
            var report = new ReactorReport([]);

            var isSafe = report.IsSafe();

            isSafe.Should().Be(true);
        }

        [Fact]
        public void AReportWithTwoEqualAdjacentNumbersIsNotSafe()
        {
            var report = new ReactorReport(["3", "3"]);

            var isSafe = report.IsSafe();

            isSafe.Should().Be(false);
        }

        [Fact]
        public void AReportWithTwoDifferentNumbersThatAreIncreasingASmallAmountIsSafe()
        {
            var report = new ReactorReport(["3", "4"]);

            var isSafe = report.IsSafe();

            isSafe.Should().Be(true);
        }

        [Fact]
        public void AReportWithOneNumberIsSafe()
        {
            var report = new ReactorReport(["3"]);

            var isSafe = report.IsSafe();

            isSafe.Should().Be(true);
        }

        [Fact]
        public void AReportWithTwoDifferentNumbersThatAreIncreasingALargeAmountIsNotSafe()
        {
            var report = new ReactorReport(["3", "7"]);

            var isSafe = report.IsSafe();

            isSafe.Should().Be(false);
        }

        [Fact]
        public void AReportWithThreeDifferentNumbersThatIncreaseCloseAndThenFarApartIsNotSafe()
        {
            var report = new ReactorReport(["3", "4", "8"]);

            var isSafe = report.IsSafe();

            isSafe.Should().Be(false);
        }

        [Fact]
        public void AReportWithThreeDifferentNumbersThatIncreasesAndDecreasesIsNotSafe()
        {
            var report = new ReactorReport(["3", "4", "3"]);

            var isSafe = report.IsSafe();

            isSafe.Should().Be(false);
        }

        [Fact]
        public void AReportWithTwoDifferentNumbersThatDecreaseASmallAmountIsSafe()
        {
            var report = new ReactorReport(["4", "3"]);

            var isSafe = report.IsSafe();

            isSafe.Should().Be(true);
        }

        [Fact]
        public void AReportWithTwoDifferentNumbersThatAreDecreasingALargeAmountIsNotSafe()
        {
            var report = new ReactorReport(["7", "3"]);

            var isSafe = report.IsSafe();

            isSafe.Should().Be(false);
        }


        [Fact]
        public void AReportWithThreeDifferentNumbersThatDecreasesAndIncreasesIsNotSafe()
        {
            var report = new ReactorReport(["4", "3", "4"]);

            var isSafe = report.IsSafe();

            isSafe.Should().Be(false);
        }
    }
}

// Decreasing numbers