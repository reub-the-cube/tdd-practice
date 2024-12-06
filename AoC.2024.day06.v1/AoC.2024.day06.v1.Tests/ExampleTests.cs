﻿using FluentAssertions;

namespace AoC._2024.day06.v1.Tests
{
    public class ExampleTests
    {
        [Fact]
        public void ExampleDataReturnsXDistinctPointsBeforeLeavingForPartOne()
        {
            var exampleData = File.ReadAllLines("example.txt");

            var lab = Lab.InitialiseFrom(exampleData);
            var guard = InputParser.FindGuard(exampleData);

            var visitedPositions = guard.GetPatrolRoute(lab);

            visitedPositions.Distinct().Should().HaveCount(41);
        }
    }
}