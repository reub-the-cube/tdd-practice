using FluentAssertions;

namespace AoC._2015.day05.v1.Tests
{
    public class SplitterTests
    {
        public class GetAllSubstrings
        {
            [Fact]
            public void StringLessThanSubstringLengthReturnsEmptyList()
            {
                var initialInput = "a";

                var substrings = Splitter.GetAllSubstrings(initialInput, 2);

                substrings.Should().BeEmpty();
            }

            [Fact]
            public void StringLengthOfSubstringLengthReturnsTheString()
            {
                var initialInput = "example";

                var substrings = Splitter.GetAllSubstrings(initialInput, 7);

                substrings.Should().Contain(initialInput);
            }

            [Fact]
            public void StringLongerThanSubstringLengthOf6ReturnsExpectedSubstrings()
            {
                var initialInput = "example";

                var substrings = Splitter.GetAllSubstrings(initialInput, 6);

                substrings.Should().Contain("exampl");
                substrings.Should().Contain("xample");
            }

            [Fact]
            public void StringLongerThanSubstringLengthOf2ReturnsExpectedSubstrings()
            {
                var initialInput = "example";

                var substrings = Splitter.GetAllSubstrings(initialInput, 2);

                substrings.Should().Contain("ex");
                substrings.Should().Contain("xa");
                substrings.Should().Contain("am");
                substrings.Should().Contain("mp");
                substrings.Should().Contain("pl");
                substrings.Should().Contain("le");
            }
        }
    }
}

