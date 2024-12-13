using FluentAssertions;

namespace AoC._2024.day10.v1.Tests
{
    public class SolutionTests
    {
        private readonly string[] _inputData = File.ReadAllLines("input.txt");

        [Fact]
        public void ProvidedInputReturnsCorrectAnswerForPartOne()
        {
            var map = new Map(_inputData);

            var score = map.ScoreFromTrailheads();

            score.Should().Be(737);
        }
    }
}
