using FluentAssertions;

namespace AoC._2024.day05.v1.Tests
{
    public class SafetyManualProtocolTests
    {
        private readonly string[] protocolInput =
            [ "3|4",
            "3|5",
            "9|7",
            "",
            "3,5,4,6,2",
            "4,3,5"
            ];

        private SafetyManualProtocol _safetyManualProtocol;

        public SafetyManualProtocolTests()
        {
            _safetyManualProtocol = new SafetyManualProtocol(protocolInput);
        }

        [Fact]
        public void ConstructorCreatesRules()
        {
            _safetyManualProtocol.Rules.Should().HaveCount(3);
        }

        [Fact]
        public void ConstructorCreatesPagesToProduce()
        {
            _safetyManualProtocol.PagesToProduce.Should().HaveCount(2);
        }

        [Fact]
        public void NumberOfCorrectUpdatesReturnsOne()
        {
            var numberOfCorrectUpdates = _safetyManualProtocol.NumberOfCorrectUpdates();

            numberOfCorrectUpdates.Should().Be(1);
        }

        [Fact]
        public void MiddleNumberOfEachCorrectUpdateReturnsFour()
        {
            var middleNumberOfCorrectlyOrderedUpdates = _safetyManualProtocol.MiddleNumberOfEachCorrectUpdate();

            middleNumberOfCorrectlyOrderedUpdates.FirstOrDefault().Should().Be(4);
        }
    }
}
