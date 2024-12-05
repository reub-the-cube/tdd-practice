using FluentAssertions;

namespace AoC._2024.day05.v1.Tests
{
    public class ExampleTests
    {
        private readonly string[] exampleText = File.ReadAllLines("example.txt");

        [Fact]
        public void ExampleTextContains50Lines()
        {
            exampleText.Should().HaveCount(28);
        }
    }
}
